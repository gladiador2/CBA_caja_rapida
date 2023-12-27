// <fileinfo name="NOMINA_CONTENEDORES_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENEDORES_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOMINA_CONTENEDORES_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENEDORES_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMINA_CONTENEDORES_IDColumnName = "NOMINA_CONTENEDORES_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PUERTA_MOVIMIENTO_ENTREGA_IDColumnName = "PUERTA_MOVIMIENTO_ENTREGA_ID";
		public const string PUERTA_MOVIMIENTO_DEVOLUC_IDColumnName = "PUERTA_MOVIMIENTO_DEVOLUC_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string RECHAZADOColumnName = "RECHAZADO";
		public const string CONTENEDORES_OPERACIONES_IDColumnName = "CONTENEDORES_OPERACIONES_ID";
		public const string PRE_EMBARQUE_CONTENEDOR_IDColumnName = "PRE_EMBARQUE_CONTENEDOR_ID";
		public const string INTERCAMBIO_EQUIPO_IDColumnName = "INTERCAMBIO_EQUIPO_ID";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORES_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOMINA_CONTENEDORES_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOMINA_CONTENEDORES_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOMINA_CONTENEDORES_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			NOMINA_CONTENEDORES_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByCONTENEDORES_OPERACIONES_ID(decimal contenedores_operaciones_id)
		{
			return GetByCONTENEDORES_OPERACIONES_ID(contenedores_operaciones_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <param name="contenedores_operaciones_idNull">true if the method ignores the contenedores_operaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByCONTENEDORES_OPERACIONES_ID(decimal contenedores_operaciones_id, bool contenedores_operaciones_idNull)
		{
			return MapRecords(CreateGetByCONTENEDORES_OPERACIONES_IDCommand(contenedores_operaciones_id, contenedores_operaciones_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDORES_OPERACIONES_IDAsDataTable(decimal contenedores_operaciones_id)
		{
			return GetByCONTENEDORES_OPERACIONES_IDAsDataTable(contenedores_operaciones_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <param name="contenedores_operaciones_idNull">true if the method ignores the contenedores_operaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDORES_OPERACIONES_IDAsDataTable(decimal contenedores_operaciones_id, bool contenedores_operaciones_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDORES_OPERACIONES_IDCommand(contenedores_operaciones_id, contenedores_operaciones_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <param name="contenedores_operaciones_idNull">true if the method ignores the contenedores_operaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDORES_OPERACIONES_IDCommand(decimal contenedores_operaciones_id, bool contenedores_operaciones_idNull)
		{
			string whereSql = "";
			if(contenedores_operaciones_idNull)
				whereSql += "CONTENEDORES_OPERACIONES_ID IS NULL";
			else
				whereSql += "CONTENEDORES_OPERACIONES_ID=" + _db.CreateSqlParameterName("CONTENEDORES_OPERACIONES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!contenedores_operaciones_idNull)
				AddParameter(cmd, "CONTENEDORES_OPERACIONES_ID", contenedores_operaciones_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
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
		/// return records by the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
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
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return MapRecords(CreateGetByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINTERCAMBIO_EQUIPO_IDAsDataTable(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_IDAsDataTable(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINTERCAMBIO_EQUIPO_IDAsDataTable(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINTERCAMBIO_EQUIPO_IDCommand(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			string whereSql = "";
			if(intercambio_equipo_idNull)
				whereSql += "INTERCAMBIO_EQUIPO_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!intercambio_equipo_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID", intercambio_equipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByPRE_EMBARQUE_CONTENEDOR_ID(decimal pre_embarque_contenedor_id)
		{
			return GetByPRE_EMBARQUE_CONTENEDOR_ID(pre_embarque_contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <param name="pre_embarque_contenedor_idNull">true if the method ignores the pre_embarque_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByPRE_EMBARQUE_CONTENEDOR_ID(decimal pre_embarque_contenedor_id, bool pre_embarque_contenedor_idNull)
		{
			return MapRecords(CreateGetByPRE_EMBARQUE_CONTENEDOR_IDCommand(pre_embarque_contenedor_id, pre_embarque_contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPRE_EMBARQUE_CONTENEDOR_IDAsDataTable(decimal pre_embarque_contenedor_id)
		{
			return GetByPRE_EMBARQUE_CONTENEDOR_IDAsDataTable(pre_embarque_contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <param name="pre_embarque_contenedor_idNull">true if the method ignores the pre_embarque_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRE_EMBARQUE_CONTENEDOR_IDAsDataTable(decimal pre_embarque_contenedor_id, bool pre_embarque_contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPRE_EMBARQUE_CONTENEDOR_IDCommand(pre_embarque_contenedor_id, pre_embarque_contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <param name="pre_embarque_contenedor_idNull">true if the method ignores the pre_embarque_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRE_EMBARQUE_CONTENEDOR_IDCommand(decimal pre_embarque_contenedor_id, bool pre_embarque_contenedor_idNull)
		{
			string whereSql = "";
			if(pre_embarque_contenedor_idNull)
				whereSql += "PRE_EMBARQUE_CONTENEDOR_ID IS NULL";
			else
				whereSql += "PRE_EMBARQUE_CONTENEDOR_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pre_embarque_contenedor_idNull)
				AddParameter(cmd, "PRE_EMBARQUE_CONTENEDOR_ID", pre_embarque_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTA_MOVIMIENTO_DEVOLUC_ID(decimal puerta_movimiento_devoluc_id)
		{
			return GetByPUERTA_MOVIMIENTO_DEVOLUC_ID(puerta_movimiento_devoluc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <param name="puerta_movimiento_devoluc_idNull">true if the method ignores the puerta_movimiento_devoluc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTA_MOVIMIENTO_DEVOLUC_ID(decimal puerta_movimiento_devoluc_id, bool puerta_movimiento_devoluc_idNull)
		{
			return MapRecords(CreateGetByPUERTA_MOVIMIENTO_DEVOLUC_IDCommand(puerta_movimiento_devoluc_id, puerta_movimiento_devoluc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTA_MOVIMIENTO_DEVOLUC_IDAsDataTable(decimal puerta_movimiento_devoluc_id)
		{
			return GetByPUERTA_MOVIMIENTO_DEVOLUC_IDAsDataTable(puerta_movimiento_devoluc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <param name="puerta_movimiento_devoluc_idNull">true if the method ignores the puerta_movimiento_devoluc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTA_MOVIMIENTO_DEVOLUC_IDAsDataTable(decimal puerta_movimiento_devoluc_id, bool puerta_movimiento_devoluc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTA_MOVIMIENTO_DEVOLUC_IDCommand(puerta_movimiento_devoluc_id, puerta_movimiento_devoluc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <param name="puerta_movimiento_devoluc_idNull">true if the method ignores the puerta_movimiento_devoluc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTA_MOVIMIENTO_DEVOLUC_IDCommand(decimal puerta_movimiento_devoluc_id, bool puerta_movimiento_devoluc_idNull)
		{
			string whereSql = "";
			if(puerta_movimiento_devoluc_idNull)
				whereSql += "PUERTA_MOVIMIENTO_DEVOLUC_ID IS NULL";
			else
				whereSql += "PUERTA_MOVIMIENTO_DEVOLUC_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_DEVOLUC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerta_movimiento_devoluc_idNull)
				AddParameter(cmd, "PUERTA_MOVIMIENTO_DEVOLUC_ID", puerta_movimiento_devoluc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTA_MOVIMIENTO_ENTREGA_ID(decimal puerta_movimiento_entrega_id)
		{
			return GetByPUERTA_MOVIMIENTO_ENTREGA_ID(puerta_movimiento_entrega_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <param name="puerta_movimiento_entrega_idNull">true if the method ignores the puerta_movimiento_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTA_MOVIMIENTO_ENTREGA_ID(decimal puerta_movimiento_entrega_id, bool puerta_movimiento_entrega_idNull)
		{
			return MapRecords(CreateGetByPUERTA_MOVIMIENTO_ENTREGA_IDCommand(puerta_movimiento_entrega_id, puerta_movimiento_entrega_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTA_MOVIMIENTO_ENTREGA_IDAsDataTable(decimal puerta_movimiento_entrega_id)
		{
			return GetByPUERTA_MOVIMIENTO_ENTREGA_IDAsDataTable(puerta_movimiento_entrega_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <param name="puerta_movimiento_entrega_idNull">true if the method ignores the puerta_movimiento_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTA_MOVIMIENTO_ENTREGA_IDAsDataTable(decimal puerta_movimiento_entrega_id, bool puerta_movimiento_entrega_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTA_MOVIMIENTO_ENTREGA_IDCommand(puerta_movimiento_entrega_id, puerta_movimiento_entrega_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <param name="puerta_movimiento_entrega_idNull">true if the method ignores the puerta_movimiento_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTA_MOVIMIENTO_ENTREGA_IDCommand(decimal puerta_movimiento_entrega_id, bool puerta_movimiento_entrega_idNull)
		{
			string whereSql = "";
			if(puerta_movimiento_entrega_idNull)
				whereSql += "PUERTA_MOVIMIENTO_ENTREGA_ID IS NULL";
			else
				whereSql += "PUERTA_MOVIMIENTO_ENTREGA_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_ENTREGA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerta_movimiento_entrega_idNull)
				AddParameter(cmd, "PUERTA_MOVIMIENTO_ENTREGA_ID", puerta_movimiento_entrega_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecords(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_IDAsDataTable(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTO_DEVOLUCION_IDCommand(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			string whereSql = "";
			if(puerto_devolucion_idNull)
				whereSql += "PUERTO_DEVOLUCION_ID IS NULL";
			else
				whereSql += "PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerto_devolucion_idNull)
				AddParameter(cmd, "PUERTO_DEVOLUCION_ID", puerto_devolucion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_IDAsDataTable(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return GetByUSUARIO_MODIFICACION_ID(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id)
		{
			return GetByUSUARIO_MODIFICACION_IDAsDataTable(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			string whereSql = "";
			if(usuario_modificacion_idNull)
				whereSql += "USUARIO_MODIFICACION_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_modificacion_idNull)
				AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_DETALLESRow[] GetByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id)
		{
			return GetByNOMINA_CONTENEDORES_ID(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_DETALLESRow[] GetByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return MapRecords(CreateGetByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNOMINA_CONTENEDORES_IDAsDataTable(decimal nomina_contenedores_id)
		{
			return GetByNOMINA_CONTENEDORES_IDAsDataTable(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOMINA_CONTENEDORES_IDAsDataTable(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOMINA_CONTENEDORES_IDCommand(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			string whereSql = "";
			if(nomina_contenedores_idNull)
				whereSql += "NOMINA_CONTENEDORES_ID IS NULL";
			else
				whereSql += "NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nomina_contenedores_idNull)
				AddParameter(cmd, "NOMINA_CONTENEDORES_ID", nomina_contenedores_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(NOMINA_CONTENEDORES_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.NOMINA_CONTENEDORES_DETALLES (" +
				"ID, " +
				"NOMINA_CONTENEDORES_ID, " +
				"CONTENEDOR_ID, " +
				"PERSONA_ID, " +
				"PUERTA_MOVIMIENTO_ENTREGA_ID, " +
				"PUERTA_MOVIMIENTO_DEVOLUC_ID, " +
				"USUARIO_CREADOR_ID, " +
				"USUARIO_MODIFICACION_ID, " +
				"OBSERVACION, " +
				"RECHAZADO, " +
				"CONTENEDORES_OPERACIONES_ID, " +
				"PRE_EMBARQUE_CONTENEDOR_ID, " +
				"INTERCAMBIO_EQUIPO_ID, " +
				"PUERTO_DEVOLUCION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PUERTA_MOVIMIENTO_ENTREGA_ID") + ", " +
				_db.CreateSqlParameterName("PUERTA_MOVIMIENTO_DEVOLUC_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("RECHAZADO") + ", " +
				_db.CreateSqlParameterName("CONTENEDORES_OPERACIONES_ID") + ", " +
				_db.CreateSqlParameterName("PRE_EMBARQUE_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				_db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMINA_CONTENEDORES_ID",
				value.IsNOMINA_CONTENEDORES_IDNull ? DBNull.Value : (object)value.NOMINA_CONTENEDORES_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PUERTA_MOVIMIENTO_ENTREGA_ID",
				value.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull ? DBNull.Value : (object)value.PUERTA_MOVIMIENTO_ENTREGA_ID);
			AddParameter(cmd, "PUERTA_MOVIMIENTO_DEVOLUC_ID",
				value.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull ? DBNull.Value : (object)value.PUERTA_MOVIMIENTO_DEVOLUC_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID",
				value.IsUSUARIO_MODIFICACION_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "RECHAZADO", value.RECHAZADO);
			AddParameter(cmd, "CONTENEDORES_OPERACIONES_ID",
				value.IsCONTENEDORES_OPERACIONES_IDNull ? DBNull.Value : (object)value.CONTENEDORES_OPERACIONES_ID);
			AddParameter(cmd, "PRE_EMBARQUE_CONTENEDOR_ID",
				value.IsPRE_EMBARQUE_CONTENEDOR_IDNull ? DBNull.Value : (object)value.PRE_EMBARQUE_CONTENEDOR_ID);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORES_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(NOMINA_CONTENEDORES_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.NOMINA_CONTENEDORES_DETALLES SET " +
				"NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PUERTA_MOVIMIENTO_ENTREGA_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_ENTREGA_ID") + ", " +
				"PUERTA_MOVIMIENTO_DEVOLUC_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_DEVOLUC_ID") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"RECHAZADO=" + _db.CreateSqlParameterName("RECHAZADO") + ", " +
				"CONTENEDORES_OPERACIONES_ID=" + _db.CreateSqlParameterName("CONTENEDORES_OPERACIONES_ID") + ", " +
				"PRE_EMBARQUE_CONTENEDOR_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_CONTENEDOR_ID") + ", " +
				"INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				"PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMINA_CONTENEDORES_ID",
				value.IsNOMINA_CONTENEDORES_IDNull ? DBNull.Value : (object)value.NOMINA_CONTENEDORES_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PUERTA_MOVIMIENTO_ENTREGA_ID",
				value.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull ? DBNull.Value : (object)value.PUERTA_MOVIMIENTO_ENTREGA_ID);
			AddParameter(cmd, "PUERTA_MOVIMIENTO_DEVOLUC_ID",
				value.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull ? DBNull.Value : (object)value.PUERTA_MOVIMIENTO_DEVOLUC_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID",
				value.IsUSUARIO_MODIFICACION_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "RECHAZADO", value.RECHAZADO);
			AddParameter(cmd, "CONTENEDORES_OPERACIONES_ID",
				value.IsCONTENEDORES_OPERACIONES_IDNull ? DBNull.Value : (object)value.CONTENEDORES_OPERACIONES_ID);
			AddParameter(cmd, "PRE_EMBARQUE_CONTENEDOR_ID",
				value.IsPRE_EMBARQUE_CONTENEDOR_IDNull ? DBNull.Value : (object)value.PRE_EMBARQUE_CONTENEDOR_ID);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>NOMINA_CONTENEDORES_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>NOMINA_CONTENEDORES_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(NOMINA_CONTENEDORES_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using
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
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDORES_OPERACIONES_ID(decimal contenedores_operaciones_id)
		{
			return DeleteByCONTENEDORES_OPERACIONES_ID(contenedores_operaciones_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <param name="contenedores_operaciones_idNull">true if the method ignores the contenedores_operaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDORES_OPERACIONES_ID(decimal contenedores_operaciones_id, bool contenedores_operaciones_idNull)
		{
			return CreateDeleteByCONTENEDORES_OPERACIONES_IDCommand(contenedores_operaciones_id, contenedores_operaciones_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_CONT_OPE_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedores_operaciones_id">The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</param>
		/// <param name="contenedores_operaciones_idNull">true if the method ignores the contenedores_operaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDORES_OPERACIONES_IDCommand(decimal contenedores_operaciones_id, bool contenedores_operaciones_idNull)
		{
			string whereSql = "";
			if(contenedores_operaciones_idNull)
				whereSql += "CONTENEDORES_OPERACIONES_ID IS NULL";
			else
				whereSql += "CONTENEDORES_OPERACIONES_ID=" + _db.CreateSqlParameterName("CONTENEDORES_OPERACIONES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!contenedores_operaciones_idNull)
				AddParameter(cmd, "CONTENEDORES_OPERACIONES_ID", contenedores_operaciones_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
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
		/// delete records using the <c>FK_NOM_CONT_DET_CONTENEDOR_ID</c> foreign key.
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
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return DeleteByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return CreateDeleteByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_INTERC_EQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINTERCAMBIO_EQUIPO_IDCommand(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			string whereSql = "";
			if(intercambio_equipo_idNull)
				whereSql += "INTERCAMBIO_EQUIPO_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!intercambio_equipo_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID", intercambio_equipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRE_EMBARQUE_CONTENEDOR_ID(decimal pre_embarque_contenedor_id)
		{
			return DeleteByPRE_EMBARQUE_CONTENEDOR_ID(pre_embarque_contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <param name="pre_embarque_contenedor_idNull">true if the method ignores the pre_embarque_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRE_EMBARQUE_CONTENEDOR_ID(decimal pre_embarque_contenedor_id, bool pre_embarque_contenedor_idNull)
		{
			return CreateDeleteByPRE_EMBARQUE_CONTENEDOR_IDCommand(pre_embarque_contenedor_id, pre_embarque_contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_PE_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_contenedor_id">The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</param>
		/// <param name="pre_embarque_contenedor_idNull">true if the method ignores the pre_embarque_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRE_EMBARQUE_CONTENEDOR_IDCommand(decimal pre_embarque_contenedor_id, bool pre_embarque_contenedor_idNull)
		{
			string whereSql = "";
			if(pre_embarque_contenedor_idNull)
				whereSql += "PRE_EMBARQUE_CONTENEDOR_ID IS NULL";
			else
				whereSql += "PRE_EMBARQUE_CONTENEDOR_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pre_embarque_contenedor_idNull)
				AddParameter(cmd, "PRE_EMBARQUE_CONTENEDOR_ID", pre_embarque_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTA_MOVIMIENTO_DEVOLUC_ID(decimal puerta_movimiento_devoluc_id)
		{
			return DeleteByPUERTA_MOVIMIENTO_DEVOLUC_ID(puerta_movimiento_devoluc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <param name="puerta_movimiento_devoluc_idNull">true if the method ignores the puerta_movimiento_devoluc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTA_MOVIMIENTO_DEVOLUC_ID(decimal puerta_movimiento_devoluc_id, bool puerta_movimiento_devoluc_idNull)
		{
			return CreateDeleteByPUERTA_MOVIMIENTO_DEVOLUC_IDCommand(puerta_movimiento_devoluc_id, puerta_movimiento_devoluc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_PM_DEV_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_devoluc_id">The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</param>
		/// <param name="puerta_movimiento_devoluc_idNull">true if the method ignores the puerta_movimiento_devoluc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTA_MOVIMIENTO_DEVOLUC_IDCommand(decimal puerta_movimiento_devoluc_id, bool puerta_movimiento_devoluc_idNull)
		{
			string whereSql = "";
			if(puerta_movimiento_devoluc_idNull)
				whereSql += "PUERTA_MOVIMIENTO_DEVOLUC_ID IS NULL";
			else
				whereSql += "PUERTA_MOVIMIENTO_DEVOLUC_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_DEVOLUC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerta_movimiento_devoluc_idNull)
				AddParameter(cmd, "PUERTA_MOVIMIENTO_DEVOLUC_ID", puerta_movimiento_devoluc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTA_MOVIMIENTO_ENTREGA_ID(decimal puerta_movimiento_entrega_id)
		{
			return DeleteByPUERTA_MOVIMIENTO_ENTREGA_ID(puerta_movimiento_entrega_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <param name="puerta_movimiento_entrega_idNull">true if the method ignores the puerta_movimiento_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTA_MOVIMIENTO_ENTREGA_ID(decimal puerta_movimiento_entrega_id, bool puerta_movimiento_entrega_idNull)
		{
			return CreateDeleteByPUERTA_MOVIMIENTO_ENTREGA_IDCommand(puerta_movimiento_entrega_id, puerta_movimiento_entrega_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_PM_ENT_ID</c> foreign key.
		/// </summary>
		/// <param name="puerta_movimiento_entrega_id">The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</param>
		/// <param name="puerta_movimiento_entrega_idNull">true if the method ignores the puerta_movimiento_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTA_MOVIMIENTO_ENTREGA_IDCommand(decimal puerta_movimiento_entrega_id, bool puerta_movimiento_entrega_idNull)
		{
			string whereSql = "";
			if(puerta_movimiento_entrega_idNull)
				whereSql += "PUERTA_MOVIMIENTO_ENTREGA_ID IS NULL";
			else
				whereSql += "PUERTA_MOVIMIENTO_ENTREGA_ID=" + _db.CreateSqlParameterName("PUERTA_MOVIMIENTO_ENTREGA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerta_movimiento_entrega_idNull)
				AddParameter(cmd, "PUERTA_MOVIMIENTO_ENTREGA_ID", puerta_movimiento_entrega_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return DeleteByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return CreateDeleteByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTO_DEVOLUCION_IDCommand(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			string whereSql = "";
			if(puerto_devolucion_idNull)
				whereSql += "PUERTO_DEVOLUCION_ID IS NULL";
			else
				whereSql += "PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerto_devolucion_idNull)
				AddParameter(cmd, "PUERTO_DEVOLUCION_ID", puerto_devolucion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return DeleteByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_USU_CRE_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return DeleteByUSUARIO_MODIFICACION_ID(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return CreateDeleteByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOM_CONT_DET_USU_MOD_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			string whereSql = "";
			if(usuario_modificacion_idNull)
				whereSql += "USUARIO_MODIFICACION_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_modificacion_idNull)
				AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id)
		{
			return DeleteByNOMINA_CONTENEDORES_ID(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return CreateDeleteByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOMINA_CONTENEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOMINA_CONTENEDORES_IDCommand(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			string whereSql = "";
			if(nomina_contenedores_idNull)
				whereSql += "NOMINA_CONTENEDORES_ID IS NULL";
			else
				whereSql += "NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nomina_contenedores_idNull)
				AddParameter(cmd, "NOMINA_CONTENEDORES_ID", nomina_contenedores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>NOMINA_CONTENEDORES_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>NOMINA_CONTENEDORES_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.NOMINA_CONTENEDORES_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected NOMINA_CONTENEDORES_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected NOMINA_CONTENEDORES_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected virtual NOMINA_CONTENEDORES_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nomina_contenedores_idColumnIndex = reader.GetOrdinal("NOMINA_CONTENEDORES_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int puerta_movimiento_entrega_idColumnIndex = reader.GetOrdinal("PUERTA_MOVIMIENTO_ENTREGA_ID");
			int puerta_movimiento_devoluc_idColumnIndex = reader.GetOrdinal("PUERTA_MOVIMIENTO_DEVOLUC_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int rechazadoColumnIndex = reader.GetOrdinal("RECHAZADO");
			int contenedores_operaciones_idColumnIndex = reader.GetOrdinal("CONTENEDORES_OPERACIONES_ID");
			int pre_embarque_contenedor_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_CONTENEDOR_ID");
			int intercambio_equipo_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPO_ID");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOMINA_CONTENEDORES_DETALLESRow record = new NOMINA_CONTENEDORES_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nomina_contenedores_idColumnIndex))
						record.NOMINA_CONTENEDORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nomina_contenedores_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerta_movimiento_entrega_idColumnIndex))
						record.PUERTA_MOVIMIENTO_ENTREGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerta_movimiento_entrega_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerta_movimiento_devoluc_idColumnIndex))
						record.PUERTA_MOVIMIENTO_DEVOLUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerta_movimiento_devoluc_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_modificacion_idColumnIndex))
						record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(rechazadoColumnIndex))
						record.RECHAZADO = Convert.ToString(reader.GetValue(rechazadoColumnIndex));
					if(!reader.IsDBNull(contenedores_operaciones_idColumnIndex))
						record.CONTENEDORES_OPERACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedores_operaciones_idColumnIndex)), 9);
					if(!reader.IsDBNull(pre_embarque_contenedor_idColumnIndex))
						record.PRE_EMBARQUE_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(intercambio_equipo_idColumnIndex))
						record.INTERCAMBIO_EQUIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOMINA_CONTENEDORES_DETALLESRow[])(recordList.ToArray(typeof(NOMINA_CONTENEDORES_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOMINA_CONTENEDORES_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> object.</returns>
		protected virtual NOMINA_CONTENEDORES_DETALLESRow MapRow(DataRow row)
		{
			NOMINA_CONTENEDORES_DETALLESRow mappedObject = new NOMINA_CONTENEDORES_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMINA_CONTENEDORES_ID"
			dataColumn = dataTable.Columns["NOMINA_CONTENEDORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMINA_CONTENEDORES_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PUERTA_MOVIMIENTO_ENTREGA_ID"
			dataColumn = dataTable.Columns["PUERTA_MOVIMIENTO_ENTREGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA_MOVIMIENTO_ENTREGA_ID = (decimal)row[dataColumn];
			// Column "PUERTA_MOVIMIENTO_DEVOLUC_ID"
			dataColumn = dataTable.Columns["PUERTA_MOVIMIENTO_DEVOLUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA_MOVIMIENTO_DEVOLUC_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "RECHAZADO"
			dataColumn = dataTable.Columns["RECHAZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECHAZADO = (string)row[dataColumn];
			// Column "CONTENEDORES_OPERACIONES_ID"
			dataColumn = dataTable.Columns["CONTENEDORES_OPERACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDORES_OPERACIONES_ID = (decimal)row[dataColumn];
			// Column "PRE_EMBARQUE_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "INTERCAMBIO_EQUIPO_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPO_ID = (decimal)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOMINA_CONTENEDORES_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMINA_CONTENEDORES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PUERTA_MOVIMIENTO_ENTREGA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PUERTA_MOVIMIENTO_DEVOLUC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("RECHAZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CONTENEDORES_OPERACIONES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
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

				case "NOMINA_CONTENEDORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTA_MOVIMIENTO_ENTREGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTA_MOVIMIENTO_DEVOLUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECHAZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONTENEDORES_OPERACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRE_EMBARQUE_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERCAMBIO_EQUIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOMINA_CONTENEDORES_DETALLESCollection_Base class
}  // End of namespace
