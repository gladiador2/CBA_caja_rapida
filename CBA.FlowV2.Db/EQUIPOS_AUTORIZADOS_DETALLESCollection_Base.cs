// <fileinfo name="EQUIPOS_AUTORIZADOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EQUIPOS_AUTORIZADOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EQUIPOS_AUTORIZADOS_IDColumnName = "EQUIPOS_AUTORIZADOS_ID";
		public const string PUERTAS_MOVIMIENTO_IDColumnName = "PUERTAS_MOVIMIENTO_ID";
		public const string TIPOColumnName = "TIPO";
		public const string CONOCIMIENTO_DETALLE_IDColumnName = "CONOCIMIENTO_DETALLE_ID";
		public const string CONOCIMIENTO_CONTENIDO_IDColumnName = "CONOCIMIENTO_CONTENIDO_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string BOOKING_BLColumnName = "BOOKING_BL";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_DEVOLUCIONColumnName = "FECHA_DEVOLUCION";
		public const string RETIRADOColumnName = "RETIRADO";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EQUIPOS_AUTORIZADOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EQUIPOS_AUTORIZADOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EQUIPOS_AUTORIZADOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EQUIPOS_AUTORIZADOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONOCIMIENTO_CONTENIDO_ID(decimal conocimiento_contenido_id)
		{
			return GetByCONOCIMIENTO_CONTENIDO_ID(conocimiento_contenido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimiento_contenido_idNull">true if the method ignores the conocimiento_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONOCIMIENTO_CONTENIDO_ID(decimal conocimiento_contenido_id, bool conocimiento_contenido_idNull)
		{
			return MapRecords(CreateGetByCONOCIMIENTO_CONTENIDO_IDCommand(conocimiento_contenido_id, conocimiento_contenido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONOCIMIENTO_CONTENIDO_IDAsDataTable(decimal conocimiento_contenido_id)
		{
			return GetByCONOCIMIENTO_CONTENIDO_IDAsDataTable(conocimiento_contenido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimiento_contenido_idNull">true if the method ignores the conocimiento_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTO_CONTENIDO_IDAsDataTable(decimal conocimiento_contenido_id, bool conocimiento_contenido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTO_CONTENIDO_IDCommand(conocimiento_contenido_id, conocimiento_contenido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimiento_contenido_idNull">true if the method ignores the conocimiento_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTO_CONTENIDO_IDCommand(decimal conocimiento_contenido_id, bool conocimiento_contenido_idNull)
		{
			string whereSql = "";
			if(conocimiento_contenido_idNull)
				whereSql += "CONOCIMIENTO_CONTENIDO_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_CONTENIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conocimiento_contenido_idNull)
				AddParameter(cmd, "CONOCIMIENTO_CONTENIDO_ID", conocimiento_contenido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id)
		{
			return GetByCONOCIMIENTO_DETALLE_ID(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return MapRecords(CreateGetByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONOCIMIENTO_DETALLE_IDAsDataTable(decimal conocimiento_detalle_id)
		{
			return GetByCONOCIMIENTO_DETALLE_IDAsDataTable(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTO_DETALLE_IDAsDataTable(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTO_DETALLE_IDCommand(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			string whereSql = "";
			if(conocimiento_detalle_idNull)
				whereSql += "CONOCIMIENTO_DETALLE_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conocimiento_detalle_idNull)
				AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID", conocimiento_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
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
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
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
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_EQ_AUTOR</c> foreign key.
		/// </summary>
		/// <param name="equipos_autorizados_id">The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByEQUIPOS_AUTORIZADOS_ID(decimal equipos_autorizados_id)
		{
			return MapRecords(CreateGetByEQUIPOS_AUTORIZADOS_IDCommand(equipos_autorizados_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_EQ_AUTOR</c> foreign key.
		/// </summary>
		/// <param name="equipos_autorizados_id">The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEQUIPOS_AUTORIZADOS_IDAsDataTable(decimal equipos_autorizados_id)
		{
			return MapRecordsToDataTable(CreateGetByEQUIPOS_AUTORIZADOS_IDCommand(equipos_autorizados_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_EQ_AUTOR</c> foreign key.
		/// </summary>
		/// <param name="equipos_autorizados_id">The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEQUIPOS_AUTORIZADOS_IDCommand(decimal equipos_autorizados_id)
		{
			string whereSql = "";
			whereSql += "EQUIPOS_AUTORIZADOS_ID=" + _db.CreateSqlParameterName("EQUIPOS_AUTORIZADOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EQUIPOS_AUTORIZADOS_ID", equipos_autorizados_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByPUERTAS_MOVIMIENTO_ID(decimal puertas_movimiento_id)
		{
			return GetByPUERTAS_MOVIMIENTO_ID(puertas_movimiento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="puertas_movimiento_idNull">true if the method ignores the puertas_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByPUERTAS_MOVIMIENTO_ID(decimal puertas_movimiento_id, bool puertas_movimiento_idNull)
		{
			return MapRecords(CreateGetByPUERTAS_MOVIMIENTO_IDCommand(puertas_movimiento_id, puertas_movimiento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTAS_MOVIMIENTO_IDAsDataTable(decimal puertas_movimiento_id)
		{
			return GetByPUERTAS_MOVIMIENTO_IDAsDataTable(puertas_movimiento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="puertas_movimiento_idNull">true if the method ignores the puertas_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTAS_MOVIMIENTO_IDAsDataTable(decimal puertas_movimiento_id, bool puertas_movimiento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTAS_MOVIMIENTO_IDCommand(puertas_movimiento_id, puertas_movimiento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="puertas_movimiento_idNull">true if the method ignores the puertas_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTAS_MOVIMIENTO_IDCommand(decimal puertas_movimiento_id, bool puertas_movimiento_idNull)
		{
			string whereSql = "";
			if(puertas_movimiento_idNull)
				whereSql += "PUERTAS_MOVIMIENTO_ID IS NULL";
			else
				whereSql += "PUERTAS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("PUERTAS_MOVIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puertas_movimiento_idNull)
				AddParameter(cmd, "PUERTAS_MOVIMIENTO_ID", puertas_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecords(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_IDAsDataTable(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
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
		/// return records by the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
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
		/// Adds a new record into the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(EQUIPOS_AUTORIZADOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EQUIPOS_AUTORIZADOS_DETALLES (" +
				"ID, " +
				"EQUIPOS_AUTORIZADOS_ID, " +
				"PUERTAS_MOVIMIENTO_ID, " +
				"TIPO, " +
				"CONOCIMIENTO_DETALLE_ID, " +
				"CONOCIMIENTO_CONTENIDO_ID, " +
				"CONTENEDOR_ID, " +
				"BOOKING_BL, " +
				"FECHA_VENCIMIENTO, " +
				"FECHA_DEVOLUCION, " +
				"RETIRADO, " +
				"PUERTO_DEVOLUCION_ID, " +
				"NRO_COMPROBANTE, " +
				"AUTONUMERACION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EQUIPOS_AUTORIZADOS_ID") + ", " +
				_db.CreateSqlParameterName("PUERTAS_MOVIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO_CONTENIDO_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("BOOKING_BL") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_DEVOLUCION") + ", " +
				_db.CreateSqlParameterName("RETIRADO") + ", " +
				_db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "EQUIPOS_AUTORIZADOS_ID", value.EQUIPOS_AUTORIZADOS_ID);
			AddParameter(cmd, "PUERTAS_MOVIMIENTO_ID",
				value.IsPUERTAS_MOVIMIENTO_IDNull ? DBNull.Value : (object)value.PUERTAS_MOVIMIENTO_ID);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID",
				value.IsCONOCIMIENTO_DETALLE_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_DETALLE_ID);
			AddParameter(cmd, "CONOCIMIENTO_CONTENIDO_ID",
				value.IsCONOCIMIENTO_CONTENIDO_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_CONTENIDO_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "BOOKING_BL", value.BOOKING_BL);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_DEVOLUCION",
				value.IsFECHA_DEVOLUCIONNull ? DBNull.Value : (object)value.FECHA_DEVOLUCION);
			AddParameter(cmd, "RETIRADO", value.RETIRADO);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EQUIPOS_AUTORIZADOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.EQUIPOS_AUTORIZADOS_DETALLES SET " +
				"EQUIPOS_AUTORIZADOS_ID=" + _db.CreateSqlParameterName("EQUIPOS_AUTORIZADOS_ID") + ", " +
				"PUERTAS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("PUERTAS_MOVIMIENTO_ID") + ", " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") + ", " +
				"CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID") + ", " +
				"CONOCIMIENTO_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_CONTENIDO_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"BOOKING_BL=" + _db.CreateSqlParameterName("BOOKING_BL") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"FECHA_DEVOLUCION=" + _db.CreateSqlParameterName("FECHA_DEVOLUCION") + ", " +
				"RETIRADO=" + _db.CreateSqlParameterName("RETIRADO") + ", " +
				"PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "EQUIPOS_AUTORIZADOS_ID", value.EQUIPOS_AUTORIZADOS_ID);
			AddParameter(cmd, "PUERTAS_MOVIMIENTO_ID",
				value.IsPUERTAS_MOVIMIENTO_IDNull ? DBNull.Value : (object)value.PUERTAS_MOVIMIENTO_ID);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID",
				value.IsCONOCIMIENTO_DETALLE_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_DETALLE_ID);
			AddParameter(cmd, "CONOCIMIENTO_CONTENIDO_ID",
				value.IsCONOCIMIENTO_CONTENIDO_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_CONTENIDO_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "BOOKING_BL", value.BOOKING_BL);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_DEVOLUCION",
				value.IsFECHA_DEVOLUCIONNull ? DBNull.Value : (object)value.FECHA_DEVOLUCION);
			AddParameter(cmd, "RETIRADO", value.RETIRADO);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EQUIPOS_AUTORIZADOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using
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
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_AUTONUME</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_CONTENIDO_ID(decimal conocimiento_contenido_id)
		{
			return DeleteByCONOCIMIENTO_CONTENIDO_ID(conocimiento_contenido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimiento_contenido_idNull">true if the method ignores the conocimiento_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_CONTENIDO_ID(decimal conocimiento_contenido_id, bool conocimiento_contenido_idNull)
		{
			return CreateDeleteByCONOCIMIENTO_CONTENIDO_IDCommand(conocimiento_contenido_id, conocimiento_contenido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_CONO_CONT</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_contenido_id">The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimiento_contenido_idNull">true if the method ignores the conocimiento_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTO_CONTENIDO_IDCommand(decimal conocimiento_contenido_id, bool conocimiento_contenido_idNull)
		{
			string whereSql = "";
			if(conocimiento_contenido_idNull)
				whereSql += "CONOCIMIENTO_CONTENIDO_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_CONTENIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conocimiento_contenido_idNull)
				AddParameter(cmd, "CONOCIMIENTO_CONTENIDO_ID", conocimiento_contenido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id)
		{
			return DeleteByCONOCIMIENTO_DETALLE_ID(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return CreateDeleteByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_CONO_DET</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTO_DETALLE_IDCommand(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			string whereSql = "";
			if(conocimiento_detalle_idNull)
				whereSql += "CONOCIMIENTO_DETALLE_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conocimiento_detalle_idNull)
				AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID", conocimiento_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
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
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_CONTENE</c> foreign key.
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
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_EQ_AUTOR</c> foreign key.
		/// </summary>
		/// <param name="equipos_autorizados_id">The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEQUIPOS_AUTORIZADOS_ID(decimal equipos_autorizados_id)
		{
			return CreateDeleteByEQUIPOS_AUTORIZADOS_IDCommand(equipos_autorizados_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_EQ_AUTOR</c> foreign key.
		/// </summary>
		/// <param name="equipos_autorizados_id">The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEQUIPOS_AUTORIZADOS_IDCommand(decimal equipos_autorizados_id)
		{
			string whereSql = "";
			whereSql += "EQUIPOS_AUTORIZADOS_ID=" + _db.CreateSqlParameterName("EQUIPOS_AUTORIZADOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EQUIPOS_AUTORIZADOS_ID", equipos_autorizados_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTAS_MOVIMIENTO_ID(decimal puertas_movimiento_id)
		{
			return DeleteByPUERTAS_MOVIMIENTO_ID(puertas_movimiento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="puertas_movimiento_idNull">true if the method ignores the puertas_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTAS_MOVIMIENTO_ID(decimal puertas_movimiento_id, bool puertas_movimiento_idNull)
		{
			return CreateDeleteByPUERTAS_MOVIMIENTO_IDCommand(puertas_movimiento_id, puertas_movimiento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_PUERTA_M</c> foreign key.
		/// </summary>
		/// <param name="puertas_movimiento_id">The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="puertas_movimiento_idNull">true if the method ignores the puertas_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTAS_MOVIMIENTO_IDCommand(decimal puertas_movimiento_id, bool puertas_movimiento_idNull)
		{
			string whereSql = "";
			if(puertas_movimiento_idNull)
				whereSql += "PUERTAS_MOVIMIENTO_ID IS NULL";
			else
				whereSql += "PUERTAS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("PUERTAS_MOVIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puertas_movimiento_idNull)
				AddParameter(cmd, "PUERTAS_MOVIMIENTO_ID", puertas_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return DeleteByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
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
		/// delete records using the <c>FK_EQUIPOS_AUTOR_DET_PUERTO_D</c> foreign key.
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
		/// Deletes <c>EQUIPOS_AUTORIZADOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>EQUIPOS_AUTORIZADOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EQUIPOS_AUTORIZADOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> objects.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int equipos_autorizados_idColumnIndex = reader.GetOrdinal("EQUIPOS_AUTORIZADOS_ID");
			int puertas_movimiento_idColumnIndex = reader.GetOrdinal("PUERTAS_MOVIMIENTO_ID");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int conocimiento_detalle_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_DETALLE_ID");
			int conocimiento_contenido_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_CONTENIDO_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int booking_blColumnIndex = reader.GetOrdinal("BOOKING_BL");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_devolucionColumnIndex = reader.GetOrdinal("FECHA_DEVOLUCION");
			int retiradoColumnIndex = reader.GetOrdinal("RETIRADO");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EQUIPOS_AUTORIZADOS_DETALLESRow record = new EQUIPOS_AUTORIZADOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.EQUIPOS_AUTORIZADOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(equipos_autorizados_idColumnIndex)), 9);
					if(!reader.IsDBNull(puertas_movimiento_idColumnIndex))
						record.PUERTAS_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puertas_movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(conocimiento_detalle_idColumnIndex))
						record.CONOCIMIENTO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimiento_contenido_idColumnIndex))
						record.CONOCIMIENTO_CONTENIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_contenido_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(booking_blColumnIndex))
						record.BOOKING_BL = Convert.ToString(reader.GetValue(booking_blColumnIndex));
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_devolucionColumnIndex))
						record.FECHA_DEVOLUCION = Convert.ToDateTime(reader.GetValue(fecha_devolucionColumnIndex));
					record.RETIRADO = Convert.ToString(reader.GetValue(retiradoColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EQUIPOS_AUTORIZADOS_DETALLESRow[])(recordList.ToArray(typeof(EQUIPOS_AUTORIZADOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EQUIPOS_AUTORIZADOS_DETALLESRow"/> object.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_DETALLESRow MapRow(DataRow row)
		{
			EQUIPOS_AUTORIZADOS_DETALLESRow mappedObject = new EQUIPOS_AUTORIZADOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EQUIPOS_AUTORIZADOS_ID"
			dataColumn = dataTable.Columns["EQUIPOS_AUTORIZADOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EQUIPOS_AUTORIZADOS_ID = (decimal)row[dataColumn];
			// Column "PUERTAS_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["PUERTAS_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTAS_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "CONOCIMIENTO_DETALLE_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO_CONTENIDO_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_CONTENIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_CONTENIDO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "BOOKING_BL"
			dataColumn = dataTable.Columns["BOOKING_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING_BL = (string)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_DEVOLUCION"
			dataColumn = dataTable.Columns["FECHA_DEVOLUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DEVOLUCION = (System.DateTime)row[dataColumn];
			// Column "RETIRADO"
			dataColumn = dataTable.Columns["RETIRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETIRADO = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EQUIPOS_AUTORIZADOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EQUIPOS_AUTORIZADOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EQUIPOS_AUTORIZADOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PUERTAS_MOVIMIENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_DETALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_CONTENIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BOOKING_BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_DEVOLUCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("RETIRADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
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

				case "EQUIPOS_AUTORIZADOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTAS_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONOCIMIENTO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTO_CONTENIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOOKING_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DEVOLUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "RETIRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EQUIPOS_AUTORIZADOS_DETALLESCollection_Base class
}  // End of namespace
