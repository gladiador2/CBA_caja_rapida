// <fileinfo name="AUTONUMERACIONESCollection_Base.cs">
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
	/// The base class for <see cref="AUTONUMERACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="AUTONUMERACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AUTONUMERACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_AUTONUMERACION_IDColumnName = "TIPO_AUTONUMERACION_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string LIMITE_INFERIORColumnName = "LIMITE_INFERIOR";
		public const string LIMITE_SUPERIORColumnName = "LIMITE_SUPERIOR";
		public const string NUMERO_ACTUALColumnName = "NUMERO_ACTUAL";
		public const string PREFIJOColumnName = "PREFIJO";
		public const string SUFIJOColumnName = "SUFIJO";
		public const string VENCIMIENTOColumnName = "VENCIMIENTO";
		public const string NUMERO_TIMBRADOColumnName = "NUMERO_TIMBRADO";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_AGOTO_NUMERACIONColumnName = "FECHA_AGOTO_NUMERACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_GENERACIONColumnName = "TIPO_GENERACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string IMPRIMIBLEColumnName = "IMPRIMIBLE";
		public const string CODIGOColumnName = "CODIGO";
		public const string CANTIDAD_CARACTERESColumnName = "CANTIDAD_CARACTERES";
		public const string AUTONUMERACION_SIGUIENTE_IDColumnName = "AUTONUMERACION_SIGUIENTE_ID";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FUNCIONARIO_USO_EXCLUSIVOColumnName = "FUNCIONARIO_USO_EXCLUSIVO";
		public const string IMPRESION_DELTA_ALTURAColumnName = "IMPRESION_DELTA_ALTURA";
		public const string DETALLES_CANTIDAD_MAXIMAColumnName = "DETALLES_CANTIDAD_MAXIMA";
		public const string IMPRESION_DELTA_ANCHOColumnName = "IMPRESION_DELTA_ANCHO";
		public const string ELECTRONICOColumnName = "ELECTRONICO";
		public const string ARTICULOS_FAMILIA_IDColumnName = "ARTICULOS_FAMILIA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="AUTONUMERACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public AUTONUMERACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="AUTONUMERACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="AUTONUMERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public AUTONUMERACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			AUTONUMERACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.AUTONUMERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="AUTONUMERACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="AUTONUMERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual AUTONUMERACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			AUTONUMERACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetByARTICULOS_FAMILIA_ID(decimal articulos_familia_id)
		{
			return GetByARTICULOS_FAMILIA_ID(articulos_familia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <param name="articulos_familia_idNull">true if the method ignores the articulos_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByARTICULOS_FAMILIA_ID(decimal articulos_familia_id, bool articulos_familia_idNull)
		{
			return MapRecords(CreateGetByARTICULOS_FAMILIA_IDCommand(articulos_familia_id, articulos_familia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULOS_FAMILIA_IDAsDataTable(decimal articulos_familia_id)
		{
			return GetByARTICULOS_FAMILIA_IDAsDataTable(articulos_familia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <param name="articulos_familia_idNull">true if the method ignores the articulos_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULOS_FAMILIA_IDAsDataTable(decimal articulos_familia_id, bool articulos_familia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULOS_FAMILIA_IDCommand(articulos_familia_id, articulos_familia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <param name="articulos_familia_idNull">true if the method ignores the articulos_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULOS_FAMILIA_IDCommand(decimal articulos_familia_id, bool articulos_familia_idNull)
		{
			string whereSql = "";
			if(articulos_familia_idNull)
				whereSql += "ARTICULOS_FAMILIA_ID IS NULL";
			else
				whereSql += "ARTICULOS_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULOS_FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulos_familia_idNull)
				AddParameter(cmd, "ARTICULOS_FAMILIA_ID", articulos_familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return GetByCTACTE_BANCARIA_ID(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id)
		{
			return GetByCTACTE_BANCARIA_IDAsDataTable(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_idNull)
				whereSql += "CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_bancaria_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return GetByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return GetByFLUJO_IDAsDataTable(flujo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetByAUTONUMERACION_SIGUIENTE_ID(decimal autonumeracion_siguiente_id)
		{
			return GetByAUTONUMERACION_SIGUIENTE_ID(autonumeracion_siguiente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <param name="autonumeracion_siguiente_idNull">true if the method ignores the autonumeracion_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByAUTONUMERACION_SIGUIENTE_ID(decimal autonumeracion_siguiente_id, bool autonumeracion_siguiente_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_SIGUIENTE_IDCommand(autonumeracion_siguiente_id, autonumeracion_siguiente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_SIGUIENTE_IDAsDataTable(decimal autonumeracion_siguiente_id)
		{
			return GetByAUTONUMERACION_SIGUIENTE_IDAsDataTable(autonumeracion_siguiente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <param name="autonumeracion_siguiente_idNull">true if the method ignores the autonumeracion_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_SIGUIENTE_IDAsDataTable(decimal autonumeracion_siguiente_id, bool autonumeracion_siguiente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_SIGUIENTE_IDCommand(autonumeracion_siguiente_id, autonumeracion_siguiente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <param name="autonumeracion_siguiente_idNull">true if the method ignores the autonumeracion_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_SIGUIENTE_IDCommand(decimal autonumeracion_siguiente_id, bool autonumeracion_siguiente_idNull)
		{
			string whereSql = "";
			if(autonumeracion_siguiente_idNull)
				whereSql += "AUTONUMERACION_SIGUIENTE_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_SIGUIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_siguiente_idNull)
				AddParameter(cmd, "AUTONUMERACION_SIGUIENTE_ID", autonumeracion_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public AUTONUMERACIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_TIPO_AUTO</c> foreign key.
		/// </summary>
		/// <param name="tipo_autonumeracion_id">The <c>TIPO_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByTIPO_AUTONUMERACION_ID(decimal tipo_autonumeracion_id)
		{
			return MapRecords(CreateGetByTIPO_AUTONUMERACION_IDCommand(tipo_autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_TIPO_AUTO</c> foreign key.
		/// </summary>
		/// <param name="tipo_autonumeracion_id">The <c>TIPO_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_AUTONUMERACION_IDAsDataTable(decimal tipo_autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_AUTONUMERACION_IDCommand(tipo_autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_TIPO_AUTO</c> foreign key.
		/// </summary>
		/// <param name="tipo_autonumeracion_id">The <c>TIPO_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_AUTONUMERACION_IDCommand(decimal tipo_autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "TIPO_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("TIPO_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_AUTONUMERACION_ID", tipo_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONESRow"/> objects 
		/// by the <c>FK_AUTONUMERACIONES_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		public virtual AUTONUMERACIONESRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUMERACIONES_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUMERACIONES_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(AUTONUMERACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.AUTONUMERACIONES (" +
				"ID, " +
				"TIPO_AUTONUMERACION_ID, " +
				"SUCURSAL_ID, " +
				"ENTIDAD_ID, " +
				"FLUJO_ID, " +
				"TABLA_ID, " +
				"LIMITE_INFERIOR, " +
				"LIMITE_SUPERIOR, " +
				"NUMERO_ACTUAL, " +
				"PREFIJO, " +
				"SUFIJO, " +
				"VENCIMIENTO, " +
				"NUMERO_TIMBRADO, " +
				"CTACTE_BANCARIA_ID, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION, " +
				"FECHA_AGOTO_NUMERACION, " +
				"ESTADO, " +
				"TIPO_GENERACION, " +
				"FUNCIONARIO_ID, " +
				"IMPRIMIBLE, " +
				"CODIGO, " +
				"CANTIDAD_CARACTERES, " +
				"AUTONUMERACION_SIGUIENTE_ID, " +
				"FECHA_INICIO, " +
				"FUNCIONARIO_USO_EXCLUSIVO, " +
				"IMPRESION_DELTA_ALTURA, " +
				"DETALLES_CANTIDAD_MAXIMA, " +
				"IMPRESION_DELTA_ANCHO, " +
				"ELECTRONICO, " +
				"ARTICULOS_FAMILIA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("LIMITE_INFERIOR") + ", " +
				_db.CreateSqlParameterName("LIMITE_SUPERIOR") + ", " +
				_db.CreateSqlParameterName("NUMERO_ACTUAL") + ", " +
				_db.CreateSqlParameterName("PREFIJO") + ", " +
				_db.CreateSqlParameterName("SUFIJO") + ", " +
				_db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("NUMERO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_AGOTO_NUMERACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO_GENERACION") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("IMPRIMIBLE") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CARACTERES") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_SIGUIENTE_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_USO_EXCLUSIVO") + ", " +
				_db.CreateSqlParameterName("IMPRESION_DELTA_ALTURA") + ", " +
				_db.CreateSqlParameterName("DETALLES_CANTIDAD_MAXIMA") + ", " +
				_db.CreateSqlParameterName("IMPRESION_DELTA_ANCHO") + ", " +
				_db.CreateSqlParameterName("ELECTRONICO") + ", " +
				_db.CreateSqlParameterName("ARTICULOS_FAMILIA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_AUTONUMERACION_ID", value.TIPO_AUTONUMERACION_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "LIMITE_INFERIOR", value.LIMITE_INFERIOR);
			AddParameter(cmd, "LIMITE_SUPERIOR", value.LIMITE_SUPERIOR);
			AddParameter(cmd, "NUMERO_ACTUAL", value.NUMERO_ACTUAL);
			AddParameter(cmd, "PREFIJO", value.PREFIJO);
			AddParameter(cmd, "SUFIJO", value.SUFIJO);
			AddParameter(cmd, "VENCIMIENTO",
				value.IsVENCIMIENTONull ? DBNull.Value : (object)value.VENCIMIENTO);
			AddParameter(cmd, "NUMERO_TIMBRADO", value.NUMERO_TIMBRADO);
			AddParameter(cmd, "CTACTE_BANCARIA_ID",
				value.IsCTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_AGOTO_NUMERACION",
				value.IsFECHA_AGOTO_NUMERACIONNull ? DBNull.Value : (object)value.FECHA_AGOTO_NUMERACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_GENERACION", value.TIPO_GENERACION);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "IMPRIMIBLE", value.IMPRIMIBLE);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "CANTIDAD_CARACTERES", value.CANTIDAD_CARACTERES);
			AddParameter(cmd, "AUTONUMERACION_SIGUIENTE_ID",
				value.IsAUTONUMERACION_SIGUIENTE_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_SIGUIENTE_ID);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FUNCIONARIO_USO_EXCLUSIVO", value.FUNCIONARIO_USO_EXCLUSIVO);
			AddParameter(cmd, "IMPRESION_DELTA_ALTURA", value.IMPRESION_DELTA_ALTURA);
			AddParameter(cmd, "DETALLES_CANTIDAD_MAXIMA",
				value.IsDETALLES_CANTIDAD_MAXIMANull ? DBNull.Value : (object)value.DETALLES_CANTIDAD_MAXIMA);
			AddParameter(cmd, "IMPRESION_DELTA_ANCHO", value.IMPRESION_DELTA_ANCHO);
			AddParameter(cmd, "ELECTRONICO", value.ELECTRONICO);
			AddParameter(cmd, "ARTICULOS_FAMILIA_ID",
				value.IsARTICULOS_FAMILIA_IDNull ? DBNull.Value : (object)value.ARTICULOS_FAMILIA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(AUTONUMERACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.AUTONUMERACIONES SET " +
				"TIPO_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("TIPO_AUTONUMERACION_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"LIMITE_INFERIOR=" + _db.CreateSqlParameterName("LIMITE_INFERIOR") + ", " +
				"LIMITE_SUPERIOR=" + _db.CreateSqlParameterName("LIMITE_SUPERIOR") + ", " +
				"NUMERO_ACTUAL=" + _db.CreateSqlParameterName("NUMERO_ACTUAL") + ", " +
				"PREFIJO=" + _db.CreateSqlParameterName("PREFIJO") + ", " +
				"SUFIJO=" + _db.CreateSqlParameterName("SUFIJO") + ", " +
				"VENCIMIENTO=" + _db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				"NUMERO_TIMBRADO=" + _db.CreateSqlParameterName("NUMERO_TIMBRADO") + ", " +
				"CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_AGOTO_NUMERACION=" + _db.CreateSqlParameterName("FECHA_AGOTO_NUMERACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO_GENERACION=" + _db.CreateSqlParameterName("TIPO_GENERACION") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"IMPRIMIBLE=" + _db.CreateSqlParameterName("IMPRIMIBLE") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"CANTIDAD_CARACTERES=" + _db.CreateSqlParameterName("CANTIDAD_CARACTERES") + ", " +
				"AUTONUMERACION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_SIGUIENTE_ID") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FUNCIONARIO_USO_EXCLUSIVO=" + _db.CreateSqlParameterName("FUNCIONARIO_USO_EXCLUSIVO") + ", " +
				"IMPRESION_DELTA_ALTURA=" + _db.CreateSqlParameterName("IMPRESION_DELTA_ALTURA") + ", " +
				"DETALLES_CANTIDAD_MAXIMA=" + _db.CreateSqlParameterName("DETALLES_CANTIDAD_MAXIMA") + ", " +
				"IMPRESION_DELTA_ANCHO=" + _db.CreateSqlParameterName("IMPRESION_DELTA_ANCHO") + ", " +
				"ELECTRONICO=" + _db.CreateSqlParameterName("ELECTRONICO") + ", " +
				"ARTICULOS_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULOS_FAMILIA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_AUTONUMERACION_ID", value.TIPO_AUTONUMERACION_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "LIMITE_INFERIOR", value.LIMITE_INFERIOR);
			AddParameter(cmd, "LIMITE_SUPERIOR", value.LIMITE_SUPERIOR);
			AddParameter(cmd, "NUMERO_ACTUAL", value.NUMERO_ACTUAL);
			AddParameter(cmd, "PREFIJO", value.PREFIJO);
			AddParameter(cmd, "SUFIJO", value.SUFIJO);
			AddParameter(cmd, "VENCIMIENTO",
				value.IsVENCIMIENTONull ? DBNull.Value : (object)value.VENCIMIENTO);
			AddParameter(cmd, "NUMERO_TIMBRADO", value.NUMERO_TIMBRADO);
			AddParameter(cmd, "CTACTE_BANCARIA_ID",
				value.IsCTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_AGOTO_NUMERACION",
				value.IsFECHA_AGOTO_NUMERACIONNull ? DBNull.Value : (object)value.FECHA_AGOTO_NUMERACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_GENERACION", value.TIPO_GENERACION);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "IMPRIMIBLE", value.IMPRIMIBLE);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "CANTIDAD_CARACTERES", value.CANTIDAD_CARACTERES);
			AddParameter(cmd, "AUTONUMERACION_SIGUIENTE_ID",
				value.IsAUTONUMERACION_SIGUIENTE_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_SIGUIENTE_ID);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FUNCIONARIO_USO_EXCLUSIVO", value.FUNCIONARIO_USO_EXCLUSIVO);
			AddParameter(cmd, "IMPRESION_DELTA_ALTURA", value.IMPRESION_DELTA_ALTURA);
			AddParameter(cmd, "DETALLES_CANTIDAD_MAXIMA",
				value.IsDETALLES_CANTIDAD_MAXIMANull ? DBNull.Value : (object)value.DETALLES_CANTIDAD_MAXIMA);
			AddParameter(cmd, "IMPRESION_DELTA_ANCHO", value.IMPRESION_DELTA_ANCHO);
			AddParameter(cmd, "ELECTRONICO", value.ELECTRONICO);
			AddParameter(cmd, "ARTICULOS_FAMILIA_ID",
				value.IsARTICULOS_FAMILIA_IDNull ? DBNull.Value : (object)value.ARTICULOS_FAMILIA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>AUTONUMERACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>AUTONUMERACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(AUTONUMERACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>AUTONUMERACIONES</c> table using
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
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_FAMILIA_ID(decimal articulos_familia_id)
		{
			return DeleteByARTICULOS_FAMILIA_ID(articulos_familia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <param name="articulos_familia_idNull">true if the method ignores the articulos_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_FAMILIA_ID(decimal articulos_familia_id, bool articulos_familia_idNull)
		{
			return CreateDeleteByARTICULOS_FAMILIA_IDCommand(articulos_familia_id, articulos_familia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_ART_FAM_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_familia_id">The <c>ARTICULOS_FAMILIA_ID</c> column value.</param>
		/// <param name="articulos_familia_idNull">true if the method ignores the articulos_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULOS_FAMILIA_IDCommand(decimal articulos_familia_id, bool articulos_familia_idNull)
		{
			string whereSql = "";
			if(articulos_familia_idNull)
				whereSql += "ARTICULOS_FAMILIA_ID IS NULL";
			else
				whereSql += "ARTICULOS_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULOS_FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulos_familia_idNull)
				AddParameter(cmd, "ARTICULOS_FAMILIA_ID", articulos_familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return DeleteByCTACTE_BANCARIA_ID(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return CreateDeleteByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_CTA_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_idNull)
				whereSql += "CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_bancaria_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return DeleteByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id, flujo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_SIGUIENTE_ID(decimal autonumeracion_siguiente_id)
		{
			return DeleteByAUTONUMERACION_SIGUIENTE_ID(autonumeracion_siguiente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <param name="autonumeracion_siguiente_idNull">true if the method ignores the autonumeracion_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_SIGUIENTE_ID(decimal autonumeracion_siguiente_id, bool autonumeracion_siguiente_idNull)
		{
			return CreateDeleteByAUTONUMERACION_SIGUIENTE_IDCommand(autonumeracion_siguiente_id, autonumeracion_siguiente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_SGTE_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_siguiente_id">The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</param>
		/// <param name="autonumeracion_siguiente_idNull">true if the method ignores the autonumeracion_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_SIGUIENTE_IDCommand(decimal autonumeracion_siguiente_id, bool autonumeracion_siguiente_idNull)
		{
			string whereSql = "";
			if(autonumeracion_siguiente_idNull)
				whereSql += "AUTONUMERACION_SIGUIENTE_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_SIGUIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_siguiente_idNull)
				AddParameter(cmd, "AUTONUMERACION_SIGUIENTE_ID", autonumeracion_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_TIPO_AUTO</c> foreign key.
		/// </summary>
		/// <param name="tipo_autonumeracion_id">The <c>TIPO_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_AUTONUMERACION_ID(decimal tipo_autonumeracion_id)
		{
			return CreateDeleteByTIPO_AUTONUMERACION_IDCommand(tipo_autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_TIPO_AUTO</c> foreign key.
		/// </summary>
		/// <param name="tipo_autonumeracion_id">The <c>TIPO_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_AUTONUMERACION_IDCommand(decimal tipo_autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "TIPO_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("TIPO_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_AUTONUMERACION_ID", tipo_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES</c> table using the 
		/// <c>FK_AUTONUMERACIONES_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUMERACIONES_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>AUTONUMERACIONES</c> records that match the specified criteria.
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
		/// to delete <c>AUTONUMERACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.AUTONUMERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>AUTONUMERACIONES</c> table.
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
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		protected AUTONUMERACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		protected AUTONUMERACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="AUTONUMERACIONESRow"/> objects.</returns>
		protected virtual AUTONUMERACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_autonumeracion_idColumnIndex = reader.GetOrdinal("TIPO_AUTONUMERACION_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int limite_inferiorColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR");
			int limite_superiorColumnIndex = reader.GetOrdinal("LIMITE_SUPERIOR");
			int numero_actualColumnIndex = reader.GetOrdinal("NUMERO_ACTUAL");
			int prefijoColumnIndex = reader.GetOrdinal("PREFIJO");
			int sufijoColumnIndex = reader.GetOrdinal("SUFIJO");
			int vencimientoColumnIndex = reader.GetOrdinal("VENCIMIENTO");
			int numero_timbradoColumnIndex = reader.GetOrdinal("NUMERO_TIMBRADO");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_agoto_numeracionColumnIndex = reader.GetOrdinal("FECHA_AGOTO_NUMERACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_generacionColumnIndex = reader.GetOrdinal("TIPO_GENERACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int imprimibleColumnIndex = reader.GetOrdinal("IMPRIMIBLE");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int cantidad_caracteresColumnIndex = reader.GetOrdinal("CANTIDAD_CARACTERES");
			int autonumeracion_siguiente_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_SIGUIENTE_ID");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int funcionario_uso_exclusivoColumnIndex = reader.GetOrdinal("FUNCIONARIO_USO_EXCLUSIVO");
			int impresion_delta_alturaColumnIndex = reader.GetOrdinal("IMPRESION_DELTA_ALTURA");
			int detalles_cantidad_maximaColumnIndex = reader.GetOrdinal("DETALLES_CANTIDAD_MAXIMA");
			int impresion_delta_anchoColumnIndex = reader.GetOrdinal("IMPRESION_DELTA_ANCHO");
			int electronicoColumnIndex = reader.GetOrdinal("ELECTRONICO");
			int articulos_familia_idColumnIndex = reader.GetOrdinal("ARTICULOS_FAMILIA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					AUTONUMERACIONESRow record = new AUTONUMERACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_idColumnIndex))
						record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					record.LIMITE_INFERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferiorColumnIndex)), 9);
					record.LIMITE_SUPERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_superiorColumnIndex)), 9);
					record.NUMERO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(numero_actualColumnIndex)), 9);
					if(!reader.IsDBNull(prefijoColumnIndex))
						record.PREFIJO = Convert.ToString(reader.GetValue(prefijoColumnIndex));
					if(!reader.IsDBNull(sufijoColumnIndex))
						record.SUFIJO = Convert.ToString(reader.GetValue(sufijoColumnIndex));
					if(!reader.IsDBNull(vencimientoColumnIndex))
						record.VENCIMIENTO = Convert.ToDateTime(reader.GetValue(vencimientoColumnIndex));
					if(!reader.IsDBNull(numero_timbradoColumnIndex))
						record.NUMERO_TIMBRADO = Convert.ToString(reader.GetValue(numero_timbradoColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_idColumnIndex))
						record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(fecha_agoto_numeracionColumnIndex))
						record.FECHA_AGOTO_NUMERACION = Convert.ToDateTime(reader.GetValue(fecha_agoto_numeracionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.TIPO_GENERACION = Convert.ToString(reader.GetValue(tipo_generacionColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.IMPRIMIBLE = Convert.ToString(reader.GetValue(imprimibleColumnIndex));
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.CANTIDAD_CARACTERES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_caracteresColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_siguiente_idColumnIndex))
						record.AUTONUMERACION_SIGUIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_siguiente_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					record.FUNCIONARIO_USO_EXCLUSIVO = Convert.ToString(reader.GetValue(funcionario_uso_exclusivoColumnIndex));
					record.IMPRESION_DELTA_ALTURA = Math.Round(Convert.ToDecimal(reader.GetValue(impresion_delta_alturaColumnIndex)), 9);
					if(!reader.IsDBNull(detalles_cantidad_maximaColumnIndex))
						record.DETALLES_CANTIDAD_MAXIMA = Math.Round(Convert.ToDecimal(reader.GetValue(detalles_cantidad_maximaColumnIndex)), 9);
					record.IMPRESION_DELTA_ANCHO = Math.Round(Convert.ToDecimal(reader.GetValue(impresion_delta_anchoColumnIndex)), 9);
					record.ELECTRONICO = Convert.ToString(reader.GetValue(electronicoColumnIndex));
					if(!reader.IsDBNull(articulos_familia_idColumnIndex))
						record.ARTICULOS_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_familia_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AUTONUMERACIONESRow[])(recordList.ToArray(typeof(AUTONUMERACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="AUTONUMERACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="AUTONUMERACIONESRow"/> object.</returns>
		protected virtual AUTONUMERACIONESRow MapRow(DataRow row)
		{
			AUTONUMERACIONESRow mappedObject = new AUTONUMERACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["TIPO_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "LIMITE_INFERIOR"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR = (decimal)row[dataColumn];
			// Column "LIMITE_SUPERIOR"
			dataColumn = dataTable.Columns["LIMITE_SUPERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_SUPERIOR = (decimal)row[dataColumn];
			// Column "NUMERO_ACTUAL"
			dataColumn = dataTable.Columns["NUMERO_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_ACTUAL = (decimal)row[dataColumn];
			// Column "PREFIJO"
			dataColumn = dataTable.Columns["PREFIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREFIJO = (string)row[dataColumn];
			// Column "SUFIJO"
			dataColumn = dataTable.Columns["SUFIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUFIJO = (string)row[dataColumn];
			// Column "VENCIMIENTO"
			dataColumn = dataTable.Columns["VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "NUMERO_TIMBRADO"
			dataColumn = dataTable.Columns["NUMERO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_TIMBRADO = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_AGOTO_NUMERACION"
			dataColumn = dataTable.Columns["FECHA_AGOTO_NUMERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_AGOTO_NUMERACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_GENERACION"
			dataColumn = dataTable.Columns["TIPO_GENERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_GENERACION = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "IMPRIMIBLE"
			dataColumn = dataTable.Columns["IMPRIMIBLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRIMIBLE = (string)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "CANTIDAD_CARACTERES"
			dataColumn = dataTable.Columns["CANTIDAD_CARACTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CARACTERES = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_SIGUIENTE_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_SIGUIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_SIGUIENTE_ID = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_USO_EXCLUSIVO"
			dataColumn = dataTable.Columns["FUNCIONARIO_USO_EXCLUSIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_USO_EXCLUSIVO = (string)row[dataColumn];
			// Column "IMPRESION_DELTA_ALTURA"
			dataColumn = dataTable.Columns["IMPRESION_DELTA_ALTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESION_DELTA_ALTURA = (decimal)row[dataColumn];
			// Column "DETALLES_CANTIDAD_MAXIMA"
			dataColumn = dataTable.Columns["DETALLES_CANTIDAD_MAXIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DETALLES_CANTIDAD_MAXIMA = (decimal)row[dataColumn];
			// Column "IMPRESION_DELTA_ANCHO"
			dataColumn = dataTable.Columns["IMPRESION_DELTA_ANCHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESION_DELTA_ANCHO = (decimal)row[dataColumn];
			// Column "ELECTRONICO"
			dataColumn = dataTable.Columns["ELECTRONICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ELECTRONICO = (string)row[dataColumn];
			// Column "ARTICULOS_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULOS_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_FAMILIA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>AUTONUMERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "AUTONUMERACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_SUPERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PREFIJO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("SUFIJO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NUMERO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_AGOTO_NUMERACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_GENERACION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPRIMIBLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CARACTERES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_SIGUIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_USO_EXCLUSIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPRESION_DELTA_ALTURA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DETALLES_CANTIDAD_MAXIMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPRESION_DELTA_ANCHO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ELECTRONICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULOS_FAMILIA_ID", typeof(decimal));
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

				case "TIPO_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_INFERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_SUPERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PREFIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUFIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NUMERO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_AGOTO_NUMERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_GENERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRIMIBLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CARACTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_SIGUIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_USO_EXCLUSIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMPRESION_DELTA_ALTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DETALLES_CANTIDAD_MAXIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESION_DELTA_ANCHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ELECTRONICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULOS_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of AUTONUMERACIONESCollection_Base class
}  // End of namespace
