// <fileinfo name="CTACTE_FONDOS_FIJOS_MOVCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_FONDOS_FIJOS_MOVCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_FONDOS_FIJOS_MOVCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_FONDOS_FIJOS_MOVCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string INGRESOColumnName = "INGRESO";
		public const string EGRESOColumnName = "EGRESO";
		public const string SALDOColumnName = "SALDO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string MOVIMIENTO_FONDO_FIJO_IDColumnName = "MOVIMIENTO_FONDO_FIJO_ID";
		public const string TRANSFERENCIA_CAJA_SUC_IDColumnName = "TRANSFERENCIA_CAJA_SUC_ID";
		public const string MOVIMIENTO_FONDO_FIJO_DET_IDColumnName = "MOVIMIENTO_FONDO_FIJO_DET_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_FONDOS_FIJOS_MOVCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_FONDOS_FIJOS_MOVCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_FONDOS_FIJOS_MOVRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_FONDOS_FIJOS_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_FONDOS_FIJOS_MOVRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_IDAsDataTable(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_ID(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id, movimiento_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(decimal movimiento_fondo_fijo_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id, movimiento_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_fondo_fijo_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", movimiento_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(decimal movimiento_fondo_fijo_det_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_det_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_fondo_fijo_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID", movimiento_fondo_fijo_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_IDAsDataTable(orden_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public CTACTE_FONDOS_FIJOS_MOVRow[] GetByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_ID(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		public virtual CTACTE_FONDOS_FIJOS_MOVRow[] GetByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_CAJA_SUC_IDCommand(transferencia_caja_suc_id, transferencia_caja_suc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_CAJA_SUC_IDAsDataTable(decimal transferencia_caja_suc_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_IDAsDataTable(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_CAJA_SUC_IDAsDataTable(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_CAJA_SUC_IDCommand(transferencia_caja_suc_id, transferencia_caja_suc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_CAJA_SUC_IDCommand(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_suc_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUC_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_caja_suc_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID", transferencia_caja_suc_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_FONDOS_FIJOS_MOVRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_FONDOS_FIJOS_MOV (" +
				"ID, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"FECHA, " +
				"USUARIO_ID, " +
				"INGRESO, " +
				"EGRESO, " +
				"SALDO, " +
				"COTIZACION_MONEDA, " +
				"ORDEN_PAGO_ID, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"OBSERVACION, " +
				"MOVIMIENTO_FONDO_FIJO_ID, " +
				"TRANSFERENCIA_CAJA_SUC_ID, " +
				"MOVIMIENTO_FONDO_FIJO_DET_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("INGRESO") + ", " +
				_db.CreateSqlParameterName("EGRESO") + ", " +
				_db.CreateSqlParameterName("SALDO") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_DET_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_FONDOS_FIJOS_MOVRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_FONDOS_FIJOS_MOV SET " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"INGRESO=" + _db.CreateSqlParameterName("INGRESO") + ", " +
				"EGRESO=" + _db.CreateSqlParameterName("EGRESO") + ", " +
				"SALDO=" + _db.CreateSqlParameterName("SALDO") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") + ", " +
				"TRANSFERENCIA_CAJA_SUC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID") + ", " +
				"MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_DET_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_FONDOS_FIJOS_MOV</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_FONDOS_FIJOS_MOV</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_FONDOS_FIJOS_MOVRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using
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
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return DeleteByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_EV</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return DeleteByMOVIMIENTO_FONDO_FIJO_ID(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			return CreateDeleteByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id, movimiento_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_FONDO_FIJO_IDCommand(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_fondo_fijo_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", movimiento_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id)
		{
			return DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return CreateDeleteByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_det_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_fondo_fijo_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID", movimiento_fondo_fijo_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MOV_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_MOV_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return DeleteByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id)
		{
			return DeleteByTRANSFERENCIA_CAJA_SUC_ID(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table using the 
		/// <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_CAJA_SUC_IDCommand(transferencia_caja_suc_id, transferencia_caja_suc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_FONDOS_FIJOS_TCS</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_CAJA_SUC_IDCommand(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_suc_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUC_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_caja_suc_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID", transferencia_caja_suc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_FONDOS_FIJOS_MOV</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_FONDOS_FIJOS_MOV</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_FONDOS_FIJOS_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
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
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		protected CTACTE_FONDOS_FIJOS_MOVRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		protected CTACTE_FONDOS_FIJOS_MOVRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> objects.</returns>
		protected virtual CTACTE_FONDOS_FIJOS_MOVRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int ingresoColumnIndex = reader.GetOrdinal("INGRESO");
			int egresoColumnIndex = reader.GetOrdinal("EGRESO");
			int saldoColumnIndex = reader.GetOrdinal("SALDO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int movimiento_fondo_fijo_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_ID");
			int transferencia_caja_suc_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CAJA_SUC_ID");
			int movimiento_fondo_fijo_det_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_DET_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_FONDOS_FIJOS_MOVRow record = new CTACTE_FONDOS_FIJOS_MOVRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingresoColumnIndex))
						record.INGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(ingresoColumnIndex)), 9);
					if(!reader.IsDBNull(egresoColumnIndex))
						record.EGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(egresoColumnIndex)), 9);
					if(!reader.IsDBNull(saldoColumnIndex))
						record.SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(saldoColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(movimiento_fondo_fijo_idColumnIndex))
						record.MOVIMIENTO_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_caja_suc_idColumnIndex))
						record.TRANSFERENCIA_CAJA_SUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_caja_suc_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_fondo_fijo_det_idColumnIndex))
						record.MOVIMIENTO_FONDO_FIJO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_det_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_FONDOS_FIJOS_MOVRow[])(recordList.ToArray(typeof(CTACTE_FONDOS_FIJOS_MOVRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> object.</returns>
		protected virtual CTACTE_FONDOS_FIJOS_MOVRow MapRow(DataRow row)
		{
			CTACTE_FONDOS_FIJOS_MOVRow mappedObject = new CTACTE_FONDOS_FIJOS_MOVRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "INGRESO"
			dataColumn = dataTable.Columns["INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO = (decimal)row[dataColumn];
			// Column "EGRESO"
			dataColumn = dataTable.Columns["EGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO = (decimal)row[dataColumn];
			// Column "SALDO"
			dataColumn = dataTable.Columns["SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_CAJA_SUC_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CAJA_SUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CAJA_SUC_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_DET_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_DET_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_FONDOS_FIJOS_MOV";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SALDO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CAJA_SUC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_DET_ID", typeof(decimal));
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

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_CAJA_SUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_FONDO_FIJO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_FONDOS_FIJOS_MOVCollection_Base class
}  // End of namespace
