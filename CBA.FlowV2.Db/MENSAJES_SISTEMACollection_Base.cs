// <fileinfo name="MENSAJES_SISTEMACollection_Base.cs">
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
	/// The base class for <see cref="MENSAJES_SISTEMACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MENSAJES_SISTEMACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MENSAJES_SISTEMACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string ROL_IDColumnName = "ROL_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string TEXTOColumnName = "TEXTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_MENSAJEColumnName = "TIPO_MENSAJE";
		public const string SOBRE_ARTICULO_IDColumnName = "SOBRE_ARTICULO_ID";
		public const string SOBRE_PERSONA_IDColumnName = "SOBRE_PERSONA_ID";
		public const string SOBRE_PROVEEDOR_IDColumnName = "SOBRE_PROVEEDOR_ID";
		public const string SOBRE_FUNCIONARIO_IDColumnName = "SOBRE_FUNCIONARIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MENSAJES_SISTEMACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MENSAJES_SISTEMACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MENSAJES_SISTEMARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MENSAJES_SISTEMARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MENSAJES_SISTEMARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MENSAJES_SISTEMARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects that 
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MENSAJES_SISTEMA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="MENSAJES_SISTEMARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="MENSAJES_SISTEMARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual MENSAJES_SISTEMARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			MENSAJES_SISTEMARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetBySOBRE_ARTICULO_ID(decimal sobre_articulo_id)
		{
			return GetBySOBRE_ARTICULO_ID(sobre_articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <param name="sobre_articulo_idNull">true if the method ignores the sobre_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetBySOBRE_ARTICULO_ID(decimal sobre_articulo_id, bool sobre_articulo_idNull)
		{
			return MapRecords(CreateGetBySOBRE_ARTICULO_IDCommand(sobre_articulo_id, sobre_articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySOBRE_ARTICULO_IDAsDataTable(decimal sobre_articulo_id)
		{
			return GetBySOBRE_ARTICULO_IDAsDataTable(sobre_articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <param name="sobre_articulo_idNull">true if the method ignores the sobre_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySOBRE_ARTICULO_IDAsDataTable(decimal sobre_articulo_id, bool sobre_articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySOBRE_ARTICULO_IDCommand(sobre_articulo_id, sobre_articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <param name="sobre_articulo_idNull">true if the method ignores the sobre_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySOBRE_ARTICULO_IDCommand(decimal sobre_articulo_id, bool sobre_articulo_idNull)
		{
			string whereSql = "";
			if(sobre_articulo_idNull)
				whereSql += "SOBRE_ARTICULO_ID IS NULL";
			else
				whereSql += "SOBRE_ARTICULO_ID=" + _db.CreateSqlParameterName("SOBRE_ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sobre_articulo_idNull)
				AddParameter(cmd, "SOBRE_ARTICULO_ID", sobre_articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return GetByENTIDAD_ID(entidad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="entidad_idNull">true if the method ignores the entidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetByENTIDAD_ID(decimal entidad_id, bool entidad_idNull)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id, entidad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return GetByENTIDAD_IDAsDataTable(entidad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="entidad_idNull">true if the method ignores the entidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id, bool entidad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id, entidad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="entidad_idNull">true if the method ignores the entidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id, bool entidad_idNull)
		{
			string whereSql = "";
			if(entidad_idNull)
				whereSql += "ENTIDAD_ID IS NULL";
			else
				whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!entidad_idNull)
				AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetBySOBRE_FUNCIONARIO_ID(decimal sobre_funcionario_id)
		{
			return GetBySOBRE_FUNCIONARIO_ID(sobre_funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <param name="sobre_funcionario_idNull">true if the method ignores the sobre_funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetBySOBRE_FUNCIONARIO_ID(decimal sobre_funcionario_id, bool sobre_funcionario_idNull)
		{
			return MapRecords(CreateGetBySOBRE_FUNCIONARIO_IDCommand(sobre_funcionario_id, sobre_funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySOBRE_FUNCIONARIO_IDAsDataTable(decimal sobre_funcionario_id)
		{
			return GetBySOBRE_FUNCIONARIO_IDAsDataTable(sobre_funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <param name="sobre_funcionario_idNull">true if the method ignores the sobre_funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySOBRE_FUNCIONARIO_IDAsDataTable(decimal sobre_funcionario_id, bool sobre_funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySOBRE_FUNCIONARIO_IDCommand(sobre_funcionario_id, sobre_funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <param name="sobre_funcionario_idNull">true if the method ignores the sobre_funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySOBRE_FUNCIONARIO_IDCommand(decimal sobre_funcionario_id, bool sobre_funcionario_idNull)
		{
			string whereSql = "";
			if(sobre_funcionario_idNull)
				whereSql += "SOBRE_FUNCIONARIO_ID IS NULL";
			else
				whereSql += "SOBRE_FUNCIONARIO_ID=" + _db.CreateSqlParameterName("SOBRE_FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sobre_funcionario_idNull)
				AddParameter(cmd, "SOBRE_FUNCIONARIO_ID", sobre_funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetBySOBRE_PERSONA_ID(decimal sobre_persona_id)
		{
			return GetBySOBRE_PERSONA_ID(sobre_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <param name="sobre_persona_idNull">true if the method ignores the sobre_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetBySOBRE_PERSONA_ID(decimal sobre_persona_id, bool sobre_persona_idNull)
		{
			return MapRecords(CreateGetBySOBRE_PERSONA_IDCommand(sobre_persona_id, sobre_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySOBRE_PERSONA_IDAsDataTable(decimal sobre_persona_id)
		{
			return GetBySOBRE_PERSONA_IDAsDataTable(sobre_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <param name="sobre_persona_idNull">true if the method ignores the sobre_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySOBRE_PERSONA_IDAsDataTable(decimal sobre_persona_id, bool sobre_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySOBRE_PERSONA_IDCommand(sobre_persona_id, sobre_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <param name="sobre_persona_idNull">true if the method ignores the sobre_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySOBRE_PERSONA_IDCommand(decimal sobre_persona_id, bool sobre_persona_idNull)
		{
			string whereSql = "";
			if(sobre_persona_idNull)
				whereSql += "SOBRE_PERSONA_ID IS NULL";
			else
				whereSql += "SOBRE_PERSONA_ID=" + _db.CreateSqlParameterName("SOBRE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sobre_persona_idNull)
				AddParameter(cmd, "SOBRE_PERSONA_ID", sobre_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetBySOBRE_PROVEEDOR_ID(decimal sobre_proveedor_id)
		{
			return GetBySOBRE_PROVEEDOR_ID(sobre_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="sobre_proveedor_idNull">true if the method ignores the sobre_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetBySOBRE_PROVEEDOR_ID(decimal sobre_proveedor_id, bool sobre_proveedor_idNull)
		{
			return MapRecords(CreateGetBySOBRE_PROVEEDOR_IDCommand(sobre_proveedor_id, sobre_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySOBRE_PROVEEDOR_IDAsDataTable(decimal sobre_proveedor_id)
		{
			return GetBySOBRE_PROVEEDOR_IDAsDataTable(sobre_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="sobre_proveedor_idNull">true if the method ignores the sobre_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySOBRE_PROVEEDOR_IDAsDataTable(decimal sobre_proveedor_id, bool sobre_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySOBRE_PROVEEDOR_IDCommand(sobre_proveedor_id, sobre_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="sobre_proveedor_idNull">true if the method ignores the sobre_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySOBRE_PROVEEDOR_IDCommand(decimal sobre_proveedor_id, bool sobre_proveedor_idNull)
		{
			string whereSql = "";
			if(sobre_proveedor_idNull)
				whereSql += "SOBRE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "SOBRE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("SOBRE_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sobre_proveedor_idNull)
				AddParameter(cmd, "SOBRE_PROVEEDOR_ID", sobre_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetByROL_ID(decimal rol_id)
		{
			return GetByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return MapRecords(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_IDAsDataTable(decimal rol_id)
		{
			return GetByROL_IDAsDataTable(rol_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_IDAsDataTable(decimal rol_id, bool rol_idNull)
		{
			return MapRecordsToDataTable(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
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
		/// return records by the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
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
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_USR_CREADOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_USR_CREADOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MENSAJE_SISTEMA_USR_CREADOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public MENSAJES_SISTEMARow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMARow"/> objects 
		/// by the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		public virtual MENSAJES_SISTEMARow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
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
		/// return records by the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
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
		/// Adds a new record into the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MENSAJES_SISTEMARow"/> object to be inserted.</param>
		public virtual void Insert(MENSAJES_SISTEMARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.MENSAJES_SISTEMA (" +
				"ID, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"ENTIDAD_ID, " +
				"USUARIO_ID, " +
				"SUCURSAL_ID, " +
				"ROL_ID, " +
				"USUARIO_CREADOR_ID, " +
				"TEXTO, " +
				"ESTADO, " +
				"TIPO_MENSAJE, " +
				"SOBRE_ARTICULO_ID, " +
				"SOBRE_PERSONA_ID, " +
				"SOBRE_PROVEEDOR_ID, " +
				"SOBRE_FUNCIONARIO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("ROL_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO_MENSAJE") + ", " +
				_db.CreateSqlParameterName("SOBRE_ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("SOBRE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("SOBRE_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("SOBRE_FUNCIONARIO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ENTIDAD_ID",
				value.IsENTIDAD_IDNull ? DBNull.Value : (object)value.ENTIDAD_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "TEXTO", value.TEXTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_MENSAJE", value.TIPO_MENSAJE);
			AddParameter(cmd, "SOBRE_ARTICULO_ID",
				value.IsSOBRE_ARTICULO_IDNull ? DBNull.Value : (object)value.SOBRE_ARTICULO_ID);
			AddParameter(cmd, "SOBRE_PERSONA_ID",
				value.IsSOBRE_PERSONA_IDNull ? DBNull.Value : (object)value.SOBRE_PERSONA_ID);
			AddParameter(cmd, "SOBRE_PROVEEDOR_ID",
				value.IsSOBRE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.SOBRE_PROVEEDOR_ID);
			AddParameter(cmd, "SOBRE_FUNCIONARIO_ID",
				value.IsSOBRE_FUNCIONARIO_IDNull ? DBNull.Value : (object)value.SOBRE_FUNCIONARIO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MENSAJES_SISTEMARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(MENSAJES_SISTEMARow value)
		{
			
			string sqlStr = "UPDATE TRC.MENSAJES_SISTEMA SET " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"ROL_ID=" + _db.CreateSqlParameterName("ROL_ID") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"TEXTO=" + _db.CreateSqlParameterName("TEXTO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO_MENSAJE=" + _db.CreateSqlParameterName("TIPO_MENSAJE") + ", " +
				"SOBRE_ARTICULO_ID=" + _db.CreateSqlParameterName("SOBRE_ARTICULO_ID") + ", " +
				"SOBRE_PERSONA_ID=" + _db.CreateSqlParameterName("SOBRE_PERSONA_ID") + ", " +
				"SOBRE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("SOBRE_PROVEEDOR_ID") + ", " +
				"SOBRE_FUNCIONARIO_ID=" + _db.CreateSqlParameterName("SOBRE_FUNCIONARIO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ENTIDAD_ID",
				value.IsENTIDAD_IDNull ? DBNull.Value : (object)value.ENTIDAD_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "TEXTO", value.TEXTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_MENSAJE", value.TIPO_MENSAJE);
			AddParameter(cmd, "SOBRE_ARTICULO_ID",
				value.IsSOBRE_ARTICULO_IDNull ? DBNull.Value : (object)value.SOBRE_ARTICULO_ID);
			AddParameter(cmd, "SOBRE_PERSONA_ID",
				value.IsSOBRE_PERSONA_IDNull ? DBNull.Value : (object)value.SOBRE_PERSONA_ID);
			AddParameter(cmd, "SOBRE_PROVEEDOR_ID",
				value.IsSOBRE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.SOBRE_PROVEEDOR_ID);
			AddParameter(cmd, "SOBRE_FUNCIONARIO_ID",
				value.IsSOBRE_FUNCIONARIO_IDNull ? DBNull.Value : (object)value.SOBRE_FUNCIONARIO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>MENSAJES_SISTEMA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>MENSAJES_SISTEMA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MENSAJES_SISTEMARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(MENSAJES_SISTEMARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>MENSAJES_SISTEMA</c> table using
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
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_ARTICULO_ID(decimal sobre_articulo_id)
		{
			return DeleteBySOBRE_ARTICULO_ID(sobre_articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <param name="sobre_articulo_idNull">true if the method ignores the sobre_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_ARTICULO_ID(decimal sobre_articulo_id, bool sobre_articulo_idNull)
		{
			return CreateDeleteBySOBRE_ARTICULO_IDCommand(sobre_articulo_id, sobre_articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="sobre_articulo_id">The <c>SOBRE_ARTICULO_ID</c> column value.</param>
		/// <param name="sobre_articulo_idNull">true if the method ignores the sobre_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySOBRE_ARTICULO_IDCommand(decimal sobre_articulo_id, bool sobre_articulo_idNull)
		{
			string whereSql = "";
			if(sobre_articulo_idNull)
				whereSql += "SOBRE_ARTICULO_ID IS NULL";
			else
				whereSql += "SOBRE_ARTICULO_ID=" + _db.CreateSqlParameterName("SOBRE_ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sobre_articulo_idNull)
				AddParameter(cmd, "SOBRE_ARTICULO_ID", sobre_articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return DeleteByENTIDAD_ID(entidad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="entidad_idNull">true if the method ignores the entidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id, bool entidad_idNull)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id, entidad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="entidad_idNull">true if the method ignores the entidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id, bool entidad_idNull)
		{
			string whereSql = "";
			if(entidad_idNull)
				whereSql += "ENTIDAD_ID IS NULL";
			else
				whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!entidad_idNull)
				AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_FUNCIONARIO_ID(decimal sobre_funcionario_id)
		{
			return DeleteBySOBRE_FUNCIONARIO_ID(sobre_funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <param name="sobre_funcionario_idNull">true if the method ignores the sobre_funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_FUNCIONARIO_ID(decimal sobre_funcionario_id, bool sobre_funcionario_idNull)
		{
			return CreateDeleteBySOBRE_FUNCIONARIO_IDCommand(sobre_funcionario_id, sobre_funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="sobre_funcionario_id">The <c>SOBRE_FUNCIONARIO_ID</c> column value.</param>
		/// <param name="sobre_funcionario_idNull">true if the method ignores the sobre_funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySOBRE_FUNCIONARIO_IDCommand(decimal sobre_funcionario_id, bool sobre_funcionario_idNull)
		{
			string whereSql = "";
			if(sobre_funcionario_idNull)
				whereSql += "SOBRE_FUNCIONARIO_ID IS NULL";
			else
				whereSql += "SOBRE_FUNCIONARIO_ID=" + _db.CreateSqlParameterName("SOBRE_FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sobre_funcionario_idNull)
				AddParameter(cmd, "SOBRE_FUNCIONARIO_ID", sobre_funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_PERSONA_ID(decimal sobre_persona_id)
		{
			return DeleteBySOBRE_PERSONA_ID(sobre_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <param name="sobre_persona_idNull">true if the method ignores the sobre_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_PERSONA_ID(decimal sobre_persona_id, bool sobre_persona_idNull)
		{
			return CreateDeleteBySOBRE_PERSONA_IDCommand(sobre_persona_id, sobre_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="sobre_persona_id">The <c>SOBRE_PERSONA_ID</c> column value.</param>
		/// <param name="sobre_persona_idNull">true if the method ignores the sobre_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySOBRE_PERSONA_IDCommand(decimal sobre_persona_id, bool sobre_persona_idNull)
		{
			string whereSql = "";
			if(sobre_persona_idNull)
				whereSql += "SOBRE_PERSONA_ID IS NULL";
			else
				whereSql += "SOBRE_PERSONA_ID=" + _db.CreateSqlParameterName("SOBRE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sobre_persona_idNull)
				AddParameter(cmd, "SOBRE_PERSONA_ID", sobre_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_PROVEEDOR_ID(decimal sobre_proveedor_id)
		{
			return DeleteBySOBRE_PROVEEDOR_ID(sobre_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="sobre_proveedor_idNull">true if the method ignores the sobre_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySOBRE_PROVEEDOR_ID(decimal sobre_proveedor_id, bool sobre_proveedor_idNull)
		{
			return CreateDeleteBySOBRE_PROVEEDOR_IDCommand(sobre_proveedor_id, sobre_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="sobre_proveedor_id">The <c>SOBRE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="sobre_proveedor_idNull">true if the method ignores the sobre_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySOBRE_PROVEEDOR_IDCommand(decimal sobre_proveedor_id, bool sobre_proveedor_idNull)
		{
			string whereSql = "";
			if(sobre_proveedor_idNull)
				whereSql += "SOBRE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "SOBRE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("SOBRE_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sobre_proveedor_idNull)
				AddParameter(cmd, "SOBRE_PROVEEDOR_ID", sobre_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id)
		{
			return DeleteByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return CreateDeleteByROL_IDCommand(rol_id, rol_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
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
		/// delete records using the <c>FK_MENSAJE_SISTEMA_SUCURSAL</c> foreign key.
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
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_USR_CREADOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MENSAJE_SISTEMA_USR_CREADOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MENSAJES_SISTEMA</c> table using the 
		/// <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
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
		/// delete records using the <c>FK_MENSAJE_SISTEMA_USUARIO</c> foreign key.
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
		/// Deletes <c>MENSAJES_SISTEMA</c> records that match the specified criteria.
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
		/// to delete <c>MENSAJES_SISTEMA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.MENSAJES_SISTEMA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>MENSAJES_SISTEMA</c> table.
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		protected MENSAJES_SISTEMARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		protected MENSAJES_SISTEMARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMARow"/> objects.</returns>
		protected virtual MENSAJES_SISTEMARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int textoColumnIndex = reader.GetOrdinal("TEXTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_mensajeColumnIndex = reader.GetOrdinal("TIPO_MENSAJE");
			int sobre_articulo_idColumnIndex = reader.GetOrdinal("SOBRE_ARTICULO_ID");
			int sobre_persona_idColumnIndex = reader.GetOrdinal("SOBRE_PERSONA_ID");
			int sobre_proveedor_idColumnIndex = reader.GetOrdinal("SOBRE_PROVEEDOR_ID");
			int sobre_funcionario_idColumnIndex = reader.GetOrdinal("SOBRE_FUNCIONARIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MENSAJES_SISTEMARow record = new MENSAJES_SISTEMARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(entidad_idColumnIndex))
						record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(rol_idColumnIndex))
						record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);
					record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.TEXTO = Convert.ToString(reader.GetValue(textoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.TIPO_MENSAJE = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_mensajeColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_articulo_idColumnIndex))
						record.SOBRE_ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_persona_idColumnIndex))
						record.SOBRE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_proveedor_idColumnIndex))
						record.SOBRE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_funcionario_idColumnIndex))
						record.SOBRE_FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_funcionario_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MENSAJES_SISTEMARow[])(recordList.ToArray(typeof(MENSAJES_SISTEMARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MENSAJES_SISTEMARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MENSAJES_SISTEMARow"/> object.</returns>
		protected virtual MENSAJES_SISTEMARow MapRow(DataRow row)
		{
			MENSAJES_SISTEMARow mappedObject = new MENSAJES_SISTEMARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "TEXTO"
			dataColumn = dataTable.Columns["TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_MENSAJE"
			dataColumn = dataTable.Columns["TIPO_MENSAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MENSAJE = (decimal)row[dataColumn];
			// Column "SOBRE_ARTICULO_ID"
			dataColumn = dataTable.Columns["SOBRE_ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_ARTICULO_ID = (decimal)row[dataColumn];
			// Column "SOBRE_PERSONA_ID"
			dataColumn = dataTable.Columns["SOBRE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "SOBRE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["SOBRE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SOBRE_FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["SOBRE_FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_FUNCIONARIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MENSAJES_SISTEMA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MENSAJES_SISTEMA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_MENSAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SOBRE_ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SOBRE_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SOBRE_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SOBRE_FUNCIONARIO_ID", typeof(decimal));
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

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_MENSAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MENSAJES_SISTEMACollection_Base class
}  // End of namespace
