// <fileinfo name="CTACTE_CAJACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FUNCIONARIO_COBRADOR_IDColumnName = "FUNCIONARIO_COBRADOR_ID";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONTOColumnName = "MONTO";
		public const string FECHAColumnName = "FECHA";
		public const string CTACTE_PAGO_PERSONA_IDColumnName = "CTACTE_PAGO_PERSONA_ID";
		public const string CTACTE_PAGO_PERSONA_DET_IDColumnName = "CTACTE_PAGO_PERSONA_DET_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string EGRESO_VARIO_IDColumnName = "EGRESO_VARIO_ID";
		public const string CTACTE_FONDO_FIJO_MOV_IDColumnName = "CTACTE_FONDO_FIJO_MOV_ID";
		public const string ANTICIPO_PERSONA_IDColumnName = "ANTICIPO_PERSONA_ID";
		public const string ANTICIPO_PERSONA_DET_IDColumnName = "ANTICIPO_PERSONA_DET_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string DEPOSITO_BANCARIO_DET_IDColumnName = "DEPOSITO_BANCARIO_DET_ID";
		public const string TRANSFERENCIA_CAJA_SUC_IDColumnName = "TRANSFERENCIA_CAJA_SUC_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string CTACTE_CAJA_RESERVA_DET_IDColumnName = "CTACTE_CAJA_RESERVA_DET_ID";
		public const string MOVIMIENTO_FONDO_FIJO_IDColumnName = "MOVIMIENTO_FONDO_FIJO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CAJARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CAJARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CAJARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByANTICIPO_PERSONA_DET_ID(decimal anticipo_persona_det_id)
		{
			return GetByANTICIPO_PERSONA_DET_ID(anticipo_persona_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="anticipo_persona_det_idNull">true if the method ignores the anticipo_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByANTICIPO_PERSONA_DET_ID(decimal anticipo_persona_det_id, bool anticipo_persona_det_idNull)
		{
			return MapRecords(CreateGetByANTICIPO_PERSONA_DET_IDCommand(anticipo_persona_det_id, anticipo_persona_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByANTICIPO_PERSONA_DET_IDAsDataTable(decimal anticipo_persona_det_id)
		{
			return GetByANTICIPO_PERSONA_DET_IDAsDataTable(anticipo_persona_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="anticipo_persona_det_idNull">true if the method ignores the anticipo_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByANTICIPO_PERSONA_DET_IDAsDataTable(decimal anticipo_persona_det_id, bool anticipo_persona_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByANTICIPO_PERSONA_DET_IDCommand(anticipo_persona_det_id, anticipo_persona_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="anticipo_persona_det_idNull">true if the method ignores the anticipo_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByANTICIPO_PERSONA_DET_IDCommand(decimal anticipo_persona_det_id, bool anticipo_persona_det_idNull)
		{
			string whereSql = "";
			if(anticipo_persona_det_idNull)
				whereSql += "ANTICIPO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "ANTICIPO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!anticipo_persona_det_idNull)
				AddParameter(cmd, "ANTICIPO_PERSONA_DET_ID", anticipo_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByANTICIPO_PERSONA_ID(decimal anticipo_persona_id)
		{
			return GetByANTICIPO_PERSONA_ID(anticipo_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <param name="anticipo_persona_idNull">true if the method ignores the anticipo_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByANTICIPO_PERSONA_ID(decimal anticipo_persona_id, bool anticipo_persona_idNull)
		{
			return MapRecords(CreateGetByANTICIPO_PERSONA_IDCommand(anticipo_persona_id, anticipo_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByANTICIPO_PERSONA_IDAsDataTable(decimal anticipo_persona_id)
		{
			return GetByANTICIPO_PERSONA_IDAsDataTable(anticipo_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <param name="anticipo_persona_idNull">true if the method ignores the anticipo_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByANTICIPO_PERSONA_IDAsDataTable(decimal anticipo_persona_id, bool anticipo_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByANTICIPO_PERSONA_IDCommand(anticipo_persona_id, anticipo_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <param name="anticipo_persona_idNull">true if the method ignores the anticipo_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByANTICIPO_PERSONA_IDCommand(decimal anticipo_persona_id, bool anticipo_persona_idNull)
		{
			string whereSql = "";
			if(anticipo_persona_idNull)
				whereSql += "ANTICIPO_PERSONA_ID IS NULL";
			else
				whereSql += "ANTICIPO_PERSONA_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!anticipo_persona_idNull)
				AddParameter(cmd, "ANTICIPO_PERSONA_ID", anticipo_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CONC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return MapRecords(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CONC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CONCEPTO_IDAsDataTable(decimal ctacte_concepto_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_CONC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_CAJA_RESERVA_DET_ID(decimal ctacte_caja_reserva_det_id)
		{
			return GetByCTACTE_CAJA_RESERVA_DET_ID(ctacte_caja_reserva_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <param name="ctacte_caja_reserva_det_idNull">true if the method ignores the ctacte_caja_reserva_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_CAJA_RESERVA_DET_ID(decimal ctacte_caja_reserva_det_id, bool ctacte_caja_reserva_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_RESERVA_DET_IDCommand(ctacte_caja_reserva_det_id, ctacte_caja_reserva_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_RESERVA_DET_IDAsDataTable(decimal ctacte_caja_reserva_det_id)
		{
			return GetByCTACTE_CAJA_RESERVA_DET_IDAsDataTable(ctacte_caja_reserva_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <param name="ctacte_caja_reserva_det_idNull">true if the method ignores the ctacte_caja_reserva_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_RESERVA_DET_IDAsDataTable(decimal ctacte_caja_reserva_det_id, bool ctacte_caja_reserva_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_RESERVA_DET_IDCommand(ctacte_caja_reserva_det_id, ctacte_caja_reserva_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <param name="ctacte_caja_reserva_det_idNull">true if the method ignores the ctacte_caja_reserva_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_RESERVA_DET_IDCommand(decimal ctacte_caja_reserva_det_id, bool ctacte_caja_reserva_det_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_reserva_det_idNull)
				whereSql += "CTACTE_CAJA_RESERVA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_RESERVA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_RESERVA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_reserva_det_idNull)
				AddParameter(cmd, "CTACTE_CAJA_RESERVA_DET_ID", ctacte_caja_reserva_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id)
		{
			return GetByDEPOSITO_BANCARIO_DET_ID(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(decimal deposito_bancario_det_id)
		{
			return GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_det_idNull)
				whereSql += "DEPOSITO_BANCARIO_DET_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_bancario_det_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID", deposito_bancario_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_FONDO_FIJO_MOV_ID(decimal ctacte_fondo_fijo_mov_id)
		{
			return GetByCTACTE_FONDO_FIJO_MOV_ID(ctacte_fondo_fijo_mov_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_mov_idNull">true if the method ignores the ctacte_fondo_fijo_mov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_FONDO_FIJO_MOV_ID(decimal ctacte_fondo_fijo_mov_id, bool ctacte_fondo_fijo_mov_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_MOV_IDCommand(ctacte_fondo_fijo_mov_id, ctacte_fondo_fijo_mov_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_MOV_IDAsDataTable(decimal ctacte_fondo_fijo_mov_id)
		{
			return GetByCTACTE_FONDO_FIJO_MOV_IDAsDataTable(ctacte_fondo_fijo_mov_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_mov_idNull">true if the method ignores the ctacte_fondo_fijo_mov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_MOV_IDAsDataTable(decimal ctacte_fondo_fijo_mov_id, bool ctacte_fondo_fijo_mov_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_MOV_IDCommand(ctacte_fondo_fijo_mov_id, ctacte_fondo_fijo_mov_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_mov_idNull">true if the method ignores the ctacte_fondo_fijo_mov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_MOV_IDCommand(decimal ctacte_fondo_fijo_mov_id, bool ctacte_fondo_fijo_mov_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_mov_idNull)
				whereSql += "CTACTE_FONDO_FIJO_MOV_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_MOV_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_MOV_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_mov_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_MOV_ID", ctacte_fondo_fijo_mov_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_COBRADOR_IDAsDataTable(decimal funcionario_cobrador_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_ID(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_idNull">true if the method ignores the movimiento_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id, bool movimiento_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id, movimiento_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(decimal movimiento_fondo_fijo_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id)
		{
			return GetByCTACTE_PAGO_PERSONA_ID(ctacte_pago_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_idNull">true if the method ignores the ctacte_pago_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id, bool ctacte_pago_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id, ctacte_pago_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_IDAsDataTable(decimal ctacte_pago_persona_id)
		{
			return GetByCTACTE_PAGO_PERSONA_IDAsDataTable(ctacte_pago_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_idNull">true if the method ignores the ctacte_pago_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_IDAsDataTable(decimal ctacte_pago_persona_id, bool ctacte_pago_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id, ctacte_pago_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_idNull">true if the method ignores the ctacte_pago_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_IDCommand(decimal ctacte_pago_persona_id, bool ctacte_pago_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", ctacte_pago_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DET_ID(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(decimal ctacte_pago_persona_det_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_det_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_det_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID", ctacte_pago_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_USR</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_CAJA_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJA_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJA_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_TRCS_ID</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public CTACTE_CAJARow[] GetByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_ID(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJARow"/> objects 
		/// by the <c>FK_CTACTE_TRCS_ID</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_idNull">true if the method ignores the transferencia_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		public virtual CTACTE_CAJARow[] GetByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id, bool transferencia_caja_suc_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_CAJA_SUC_IDCommand(transferencia_caja_suc_id, transferencia_caja_suc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TRCS_ID</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_CAJA_SUC_IDAsDataTable(decimal transferencia_caja_suc_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_IDAsDataTable(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TRCS_ID</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_TRCS_ID</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJARow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CAJARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CAJA (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"USUARIO_ID, " +
				"FUNCIONARIO_COBRADOR_ID, " +
				"CTACTE_CONCEPTO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"CTACTE_VALOR_ID, " +
				"MONTO, " +
				"FECHA, " +
				"CTACTE_PAGO_PERSONA_ID, " +
				"CTACTE_PAGO_PERSONA_DET_ID, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"EGRESO_VARIO_ID, " +
				"CTACTE_FONDO_FIJO_MOV_ID, " +
				"ANTICIPO_PERSONA_ID, " +
				"ANTICIPO_PERSONA_DET_ID, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"DEPOSITO_BANCARIO_DET_ID, " +
				"TRANSFERENCIA_CAJA_SUC_ID, " +
				"ESTADO, " +
				"CTACTE_CAJA_RESERVA_DET_ID, " +
				"MOVIMIENTO_FONDO_FIJO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_MOV_ID") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_PERSONA_DET_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_RESERVA_DET_ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID",
				value.IsCTACTE_PAGO_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID",
				value.IsCTACTE_PAGO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "EGRESO_VARIO_ID",
				value.IsEGRESO_VARIO_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_MOV_ID",
				value.IsCTACTE_FONDO_FIJO_MOV_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_MOV_ID);
			AddParameter(cmd, "ANTICIPO_PERSONA_ID",
				value.IsANTICIPO_PERSONA_IDNull ? DBNull.Value : (object)value.ANTICIPO_PERSONA_ID);
			AddParameter(cmd, "ANTICIPO_PERSONA_DET_ID",
				value.IsANTICIPO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.ANTICIPO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID",
				value.IsDEPOSITO_BANCARIO_DET_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CTACTE_CAJA_RESERVA_DET_ID",
				value.IsCTACTE_CAJA_RESERVA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_RESERVA_DET_ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CAJARow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CAJA SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				"CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID") + ", " +
				"CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"EGRESO_VARIO_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_ID") + ", " +
				"CTACTE_FONDO_FIJO_MOV_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_MOV_ID") + ", " +
				"ANTICIPO_PERSONA_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_ID") + ", " +
				"ANTICIPO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_DET_ID") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID") + ", " +
				"TRANSFERENCIA_CAJA_SUC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CTACTE_CAJA_RESERVA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_RESERVA_DET_ID") + ", " +
				"MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID",
				value.IsCTACTE_PAGO_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID",
				value.IsCTACTE_PAGO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "EGRESO_VARIO_ID",
				value.IsEGRESO_VARIO_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_MOV_ID",
				value.IsCTACTE_FONDO_FIJO_MOV_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_MOV_ID);
			AddParameter(cmd, "ANTICIPO_PERSONA_ID",
				value.IsANTICIPO_PERSONA_IDNull ? DBNull.Value : (object)value.ANTICIPO_PERSONA_ID);
			AddParameter(cmd, "ANTICIPO_PERSONA_DET_ID",
				value.IsANTICIPO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.ANTICIPO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID",
				value.IsDEPOSITO_BANCARIO_DET_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CTACTE_CAJA_RESERVA_DET_ID",
				value.IsCTACTE_CAJA_RESERVA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_RESERVA_DET_ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CAJARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CAJA</c> table using
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
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PERSONA_DET_ID(decimal anticipo_persona_det_id)
		{
			return DeleteByANTICIPO_PERSONA_DET_ID(anticipo_persona_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="anticipo_persona_det_idNull">true if the method ignores the anticipo_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PERSONA_DET_ID(decimal anticipo_persona_det_id, bool anticipo_persona_det_idNull)
		{
			return CreateDeleteByANTICIPO_PERSONA_DET_IDCommand(anticipo_persona_det_id, anticipo_persona_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_ANT_D</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_det_id">The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="anticipo_persona_det_idNull">true if the method ignores the anticipo_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByANTICIPO_PERSONA_DET_IDCommand(decimal anticipo_persona_det_id, bool anticipo_persona_det_idNull)
		{
			string whereSql = "";
			if(anticipo_persona_det_idNull)
				whereSql += "ANTICIPO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "ANTICIPO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!anticipo_persona_det_idNull)
				AddParameter(cmd, "ANTICIPO_PERSONA_DET_ID", anticipo_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PERSONA_ID(decimal anticipo_persona_id)
		{
			return DeleteByANTICIPO_PERSONA_ID(anticipo_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <param name="anticipo_persona_idNull">true if the method ignores the anticipo_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PERSONA_ID(decimal anticipo_persona_id, bool anticipo_persona_idNull)
		{
			return CreateDeleteByANTICIPO_PERSONA_IDCommand(anticipo_persona_id, anticipo_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_ANTIC</c> foreign key.
		/// </summary>
		/// <param name="anticipo_persona_id">The <c>ANTICIPO_PERSONA_ID</c> column value.</param>
		/// <param name="anticipo_persona_idNull">true if the method ignores the anticipo_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByANTICIPO_PERSONA_IDCommand(decimal anticipo_persona_id, bool anticipo_persona_idNull)
		{
			string whereSql = "";
			if(anticipo_persona_idNull)
				whereSql += "ANTICIPO_PERSONA_ID IS NULL";
			else
				whereSql += "ANTICIPO_PERSONA_ID=" + _db.CreateSqlParameterName("ANTICIPO_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!anticipo_persona_idNull)
				AddParameter(cmd, "ANTICIPO_PERSONA_ID", anticipo_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CONC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return CreateDeleteByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_CONC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_RESERVA_DET_ID(decimal ctacte_caja_reserva_det_id)
		{
			return DeleteByCTACTE_CAJA_RESERVA_DET_ID(ctacte_caja_reserva_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <param name="ctacte_caja_reserva_det_idNull">true if the method ignores the ctacte_caja_reserva_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_RESERVA_DET_ID(decimal ctacte_caja_reserva_det_id, bool ctacte_caja_reserva_det_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_RESERVA_DET_IDCommand(ctacte_caja_reserva_det_id, ctacte_caja_reserva_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_CTACTE_RESERV_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_reserva_det_id">The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</param>
		/// <param name="ctacte_caja_reserva_det_idNull">true if the method ignores the ctacte_caja_reserva_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_RESERVA_DET_IDCommand(decimal ctacte_caja_reserva_det_id, bool ctacte_caja_reserva_det_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_reserva_det_idNull)
				whereSql += "CTACTE_CAJA_RESERVA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_RESERVA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_RESERVA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_reserva_det_idNull)
				AddParameter(cmd, "CTACTE_CAJA_RESERVA_DET_ID", ctacte_caja_reserva_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id)
		{
			return DeleteByDEPOSITO_BANCARIO_DET_ID(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return CreateDeleteByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_BANCARIO_DET_IDCommand(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_det_idNull)
				whereSql += "DEPOSITO_BANCARIO_DET_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_bancario_det_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID", deposito_bancario_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_MOV_ID(decimal ctacte_fondo_fijo_mov_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_MOV_ID(ctacte_fondo_fijo_mov_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_mov_idNull">true if the method ignores the ctacte_fondo_fijo_mov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_MOV_ID(decimal ctacte_fondo_fijo_mov_id, bool ctacte_fondo_fijo_mov_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_MOV_IDCommand(ctacte_fondo_fijo_mov_id, ctacte_fondo_fijo_mov_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_FF_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_mov_id">The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_mov_idNull">true if the method ignores the ctacte_fondo_fijo_mov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_MOV_IDCommand(decimal ctacte_fondo_fijo_mov_id, bool ctacte_fondo_fijo_mov_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_mov_idNull)
				whereSql += "CTACTE_FONDO_FIJO_MOV_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_MOV_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_MOV_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_mov_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_MOV_ID", ctacte_fondo_fijo_mov_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_MFF</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return DeleteByMOVIMIENTO_FONDO_FIJO_ID(movimiento_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_MFF</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CAJA_MFF</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_ID(ctacte_pago_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_idNull">true if the method ignores the ctacte_pago_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id, bool ctacte_pago_persona_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id, ctacte_pago_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_idNull">true if the method ignores the ctacte_pago_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_IDCommand(decimal ctacte_pago_persona_id, bool ctacte_pago_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", ctacte_pago_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_DET_ID(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_PAGO_D</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_DET_IDCommand(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_det_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_det_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID", ctacte_pago_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_USR</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_CAJA_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJA_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_TRCS_ID</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_id">The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUC_ID(decimal transferencia_caja_suc_id)
		{
			return DeleteByTRANSFERENCIA_CAJA_SUC_ID(transferencia_caja_suc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA</c> table using the 
		/// <c>FK_CTACTE_TRCS_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_TRCS_ID</c> foreign key.
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
		/// Deletes <c>CTACTE_CAJA</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CAJA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CAJA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CAJA</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		protected CTACTE_CAJARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		protected CTACTE_CAJARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CAJARow"/> objects.</returns>
		protected virtual CTACTE_CAJARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int funcionario_cobrador_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_ID");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int ctacte_pago_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_ID");
			int ctacte_pago_persona_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DET_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int egreso_vario_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_ID");
			int ctacte_fondo_fijo_mov_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_MOV_ID");
			int anticipo_persona_idColumnIndex = reader.GetOrdinal("ANTICIPO_PERSONA_ID");
			int anticipo_persona_det_idColumnIndex = reader.GetOrdinal("ANTICIPO_PERSONA_DET_ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int deposito_bancario_det_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_DET_ID");
			int transferencia_caja_suc_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CAJA_SUC_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ctacte_caja_reserva_det_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_RESERVA_DET_ID");
			int movimiento_fondo_fijo_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJARow record = new CTACTE_CAJARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.FUNCIONARIO_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_idColumnIndex)), 9);
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(ctacte_pago_persona_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_det_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_idColumnIndex))
						record.EGRESO_VARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_mov_idColumnIndex))
						record.CTACTE_FONDO_FIJO_MOV_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_mov_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_persona_idColumnIndex))
						record.ANTICIPO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_persona_det_idColumnIndex))
						record.ANTICIPO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_det_idColumnIndex))
						record.DEPOSITO_BANCARIO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_caja_suc_idColumnIndex))
						record.TRANSFERENCIA_CAJA_SUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_caja_suc_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_reserva_det_idColumnIndex))
						record.CTACTE_CAJA_RESERVA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_reserva_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_fondo_fijo_idColumnIndex))
						record.MOVIMIENTO_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJARow[])(recordList.ToArray(typeof(CTACTE_CAJARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJARow"/> object.</returns>
		protected virtual CTACTE_CAJARow MapRow(DataRow row)
		{
			CTACTE_CAJARow mappedObject = new CTACTE_CAJARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_MOV_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_MOV_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_MOV_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PERSONA_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_DET_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_DET_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_CAJA_SUC_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CAJA_SUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CAJA_SUC_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_RESERVA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_RESERVA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_RESERVA_DET_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_MOV_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANTICIPO_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANTICIPO_PERSONA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CAJA_SUC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_RESERVA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_ID", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_PAGO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_MOV_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_CAJA_SUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_RESERVA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJACollection_Base class
}  // End of namespace
