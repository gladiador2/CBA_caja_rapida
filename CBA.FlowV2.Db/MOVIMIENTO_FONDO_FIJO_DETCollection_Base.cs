// <fileinfo name="MOVIMIENTO_FONDO_FIJO_DETCollection_Base.cs">
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
	/// The base class for <see cref="MOVIMIENTO_FONDO_FIJO_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MOVIMIENTO_FONDO_FIJO_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOVIMIENTO_FONDO_FIJO_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string MOVIMIENTO_FONDO_FIJO_IDColumnName = "MOVIMIENTO_FONDO_FIJO_ID";
		public const string TIPO_TEXTO_PREDEFINIDO_IDColumnName = "TIPO_TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string MONTO_INGRESO_ORIGENColumnName = "MONTO_INGRESO_ORIGEN";
		public const string MONTO_INGRESO_DESTINOColumnName = "MONTO_INGRESO_DESTINO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string COMENTARIOColumnName = "COMENTARIO";
		public const string MONTO_EGRESO_ORIGENColumnName = "MONTO_EGRESO_ORIGEN";
		public const string MONTO_EGRESO_DESTINOColumnName = "MONTO_EGRESO_DESTINO";
		public const string SUCURSAL_MOVIMIENTO_IDColumnName = "SUCURSAL_MOVIMIENTO_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string GENERAR_ADELANTO_FUNCColumnName = "GENERAR_ADELANTO_FUNC";
		public const string GENERAR_ANTICIPO_PROVEEDORColumnName = "GENERAR_ANTICIPO_PROVEEDOR";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOVIMIENTO_FONDO_FIJO_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MOVIMIENTO_FONDO_FIJO_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MOVIMIENTO_FONDO_FIJO_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MOVIMIENTO_FONDO_FIJO_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public MOVIMIENTO_FONDO_FIJO_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MOVIMIENTO_FONDO_FIJO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			MOVIMIENTO_FONDO_FIJO_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MO_FONDO_FIJO_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MO_FONDO_FIJO_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MO_FONDO_FIJO_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MO_FONDO_FIJO_DET_MON_DEST</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return MapRecords(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MO_FONDO_FIJO_DET_MON_DEST</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_DESTINO_IDAsDataTable(decimal moneda_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MO_FONDO_FIJO_DET_MON_DEST</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public MOVIMIENTO_FONDO_FIJO_DETRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
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
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
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
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_MOV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return MapRecords(CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_MOV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_FONDO_FIJO_IDAsDataTable(decimal movimiento_fondo_fijo_id)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_MOV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_FONDO_FIJO_IDCommand(decimal movimiento_fondo_fijo_id)
		{
			string whereSql = "";
			whereSql += "MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", movimiento_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public MOVIMIENTO_FONDO_FIJO_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public MOVIMIENTO_FONDO_FIJO_DETRow[] GetBySUCURSAL_MOVIMIENTO_ID(decimal sucursal_movimiento_id)
		{
			return GetBySUCURSAL_MOVIMIENTO_ID(sucursal_movimiento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="sucursal_movimiento_idNull">true if the method ignores the sucursal_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetBySUCURSAL_MOVIMIENTO_ID(decimal sucursal_movimiento_id, bool sucursal_movimiento_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_MOVIMIENTO_IDCommand(sucursal_movimiento_id, sucursal_movimiento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_MOVIMIENTO_IDAsDataTable(decimal sucursal_movimiento_id)
		{
			return GetBySUCURSAL_MOVIMIENTO_IDAsDataTable(sucursal_movimiento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="sucursal_movimiento_idNull">true if the method ignores the sucursal_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_MOVIMIENTO_IDAsDataTable(decimal sucursal_movimiento_id, bool sucursal_movimiento_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_MOVIMIENTO_IDCommand(sucursal_movimiento_id, sucursal_movimiento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="sucursal_movimiento_idNull">true if the method ignores the sucursal_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_MOVIMIENTO_IDCommand(decimal sucursal_movimiento_id, bool sucursal_movimiento_idNull)
		{
			string whereSql = "";
			if(sucursal_movimiento_idNull)
				whereSql += "SUCURSAL_MOVIMIENTO_ID IS NULL";
			else
				whereSql += "SUCURSAL_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("SUCURSAL_MOVIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_movimiento_idNull)
				AddParameter(cmd, "SUCURSAL_MOVIMIENTO_ID", sucursal_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_TEX</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_TEX</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_TEX</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_texto_predefinido_id">The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DETRow[] GetByTIPO_TEXTO_PREDEFINIDO_ID(decimal tipo_texto_predefinido_id)
		{
			return MapRecords(CreateGetByTIPO_TEXTO_PREDEFINIDO_IDCommand(tipo_texto_predefinido_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FONDO_FIJO_DET_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_texto_predefinido_id">The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_TEXTO_PREDEFINIDO_IDAsDataTable(decimal tipo_texto_predefinido_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_TEXTO_PREDEFINIDO_IDCommand(tipo_texto_predefinido_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FONDO_FIJO_DET_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_texto_predefinido_id">The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_TEXTO_PREDEFINIDO_IDCommand(decimal tipo_texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TIPO_TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TIPO_TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_TEXTO_PREDEFINIDO_ID", tipo_texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> object to be inserted.</param>
		public virtual void Insert(MOVIMIENTO_FONDO_FIJO_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.MOVIMIENTO_FONDO_FIJO_DET (" +
				"ID, " +
				"MOVIMIENTO_FONDO_FIJO_ID, " +
				"TIPO_TEXTO_PREDEFINIDO_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"MONEDA_DESTINO_ID, " +
				"COTIZACION_ORIGEN, " +
				"COTIZACION_DESTINO, " +
				"MONTO_INGRESO_ORIGEN, " +
				"MONTO_INGRESO_DESTINO, " +
				"CANTIDAD, " +
				"COMENTARIO, " +
				"MONTO_EGRESO_ORIGEN, " +
				"MONTO_EGRESO_DESTINO, " +
				"SUCURSAL_MOVIMIENTO_ID, " +
				"FUNCIONARIO_ID, " +
				"PROVEEDOR_ID, " +
				"ESTADO, " +
				"GENERAR_ADELANTO_FUNC, " +
				"GENERAR_ANTICIPO_PROVEEDOR" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				_db.CreateSqlParameterName("COTIZACION_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONTO_INGRESO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_INGRESO_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("COMENTARIO") + ", " +
				_db.CreateSqlParameterName("MONTO_EGRESO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_EGRESO_DESTINO") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_MOVIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("GENERAR_ADELANTO_FUNC") + ", " +
				_db.CreateSqlParameterName("GENERAR_ANTICIPO_PROVEEDOR") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", value.MOVIMIENTO_FONDO_FIJO_ID);
			AddParameter(cmd, "TIPO_TEXTO_PREDEFINIDO_ID", value.TIPO_TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONEDA_DESTINO_ID", value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN", value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_DESTINO", value.COTIZACION_DESTINO);
			AddParameter(cmd, "MONTO_INGRESO_ORIGEN", value.MONTO_INGRESO_ORIGEN);
			AddParameter(cmd, "MONTO_INGRESO_DESTINO", value.MONTO_INGRESO_DESTINO);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "MONTO_EGRESO_ORIGEN", value.MONTO_EGRESO_ORIGEN);
			AddParameter(cmd, "MONTO_EGRESO_DESTINO", value.MONTO_EGRESO_DESTINO);
			AddParameter(cmd, "SUCURSAL_MOVIMIENTO_ID",
				value.IsSUCURSAL_MOVIMIENTO_IDNull ? DBNull.Value : (object)value.SUCURSAL_MOVIMIENTO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GENERAR_ADELANTO_FUNC", value.GENERAR_ADELANTO_FUNC);
			AddParameter(cmd, "GENERAR_ANTICIPO_PROVEEDOR", value.GENERAR_ANTICIPO_PROVEEDOR);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(MOVIMIENTO_FONDO_FIJO_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.MOVIMIENTO_FONDO_FIJO_DET SET " +
				"MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID") + ", " +
				"TIPO_TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TIPO_TEXTO_PREDEFINIDO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				"COTIZACION_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				"COTIZACION_DESTINO=" + _db.CreateSqlParameterName("COTIZACION_DESTINO") + ", " +
				"MONTO_INGRESO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_INGRESO_ORIGEN") + ", " +
				"MONTO_INGRESO_DESTINO=" + _db.CreateSqlParameterName("MONTO_INGRESO_DESTINO") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"COMENTARIO=" + _db.CreateSqlParameterName("COMENTARIO") + ", " +
				"MONTO_EGRESO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_EGRESO_ORIGEN") + ", " +
				"MONTO_EGRESO_DESTINO=" + _db.CreateSqlParameterName("MONTO_EGRESO_DESTINO") + ", " +
				"SUCURSAL_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("SUCURSAL_MOVIMIENTO_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"GENERAR_ADELANTO_FUNC=" + _db.CreateSqlParameterName("GENERAR_ADELANTO_FUNC") + ", " +
				"GENERAR_ANTICIPO_PROVEEDOR=" + _db.CreateSqlParameterName("GENERAR_ANTICIPO_PROVEEDOR") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", value.MOVIMIENTO_FONDO_FIJO_ID);
			AddParameter(cmd, "TIPO_TEXTO_PREDEFINIDO_ID", value.TIPO_TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONEDA_DESTINO_ID", value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN", value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_DESTINO", value.COTIZACION_DESTINO);
			AddParameter(cmd, "MONTO_INGRESO_ORIGEN", value.MONTO_INGRESO_ORIGEN);
			AddParameter(cmd, "MONTO_INGRESO_DESTINO", value.MONTO_INGRESO_DESTINO);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "MONTO_EGRESO_ORIGEN", value.MONTO_EGRESO_ORIGEN);
			AddParameter(cmd, "MONTO_EGRESO_DESTINO", value.MONTO_EGRESO_DESTINO);
			AddParameter(cmd, "SUCURSAL_MOVIMIENTO_ID",
				value.IsSUCURSAL_MOVIMIENTO_IDNull ? DBNull.Value : (object)value.SUCURSAL_MOVIMIENTO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GENERAR_ADELANTO_FUNC", value.GENERAR_ADELANTO_FUNC);
			AddParameter(cmd, "GENERAR_ANTICIPO_PROVEEDOR", value.GENERAR_ANTICIPO_PROVEEDOR);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(MOVIMIENTO_FONDO_FIJO_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using
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
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MO_FONDO_FIJO_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MO_FONDO_FIJO_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MO_FONDO_FIJO_DET_MON_DEST</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return CreateDeleteByMONEDA_DESTINO_IDCommand(moneda_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MO_FONDO_FIJO_DET_MON_DEST</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
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
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_FUN_ID</c> foreign key.
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
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_MOV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_ID(decimal movimiento_fondo_fijo_id)
		{
			return CreateDeleteByMOVIMIENTO_FONDO_FIJO_IDCommand(movimiento_fondo_fijo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_MOV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_id">The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_FONDO_FIJO_IDCommand(decimal movimiento_fondo_fijo_id)
		{
			string whereSql = "";
			whereSql += "MOVIMIENTO_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_ID", movimiento_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_PRO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_MOVIMIENTO_ID(decimal sucursal_movimiento_id)
		{
			return DeleteBySUCURSAL_MOVIMIENTO_ID(sucursal_movimiento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="sucursal_movimiento_idNull">true if the method ignores the sucursal_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_MOVIMIENTO_ID(decimal sucursal_movimiento_id, bool sucursal_movimiento_idNull)
		{
			return CreateDeleteBySUCURSAL_MOVIMIENTO_IDCommand(sucursal_movimiento_id, sucursal_movimiento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_movimiento_id">The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</param>
		/// <param name="sucursal_movimiento_idNull">true if the method ignores the sucursal_movimiento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_MOVIMIENTO_IDCommand(decimal sucursal_movimiento_id, bool sucursal_movimiento_idNull)
		{
			string whereSql = "";
			if(sucursal_movimiento_idNull)
				whereSql += "SUCURSAL_MOVIMIENTO_ID IS NULL";
			else
				whereSql += "SUCURSAL_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("SUCURSAL_MOVIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_movimiento_idNull)
				AddParameter(cmd, "SUCURSAL_MOVIMIENTO_ID", sucursal_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_TEX</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_TEX</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table using the 
		/// <c>FK_MOV_FONDO_FIJO_DET_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_texto_predefinido_id">The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_TEXTO_PREDEFINIDO_ID(decimal tipo_texto_predefinido_id)
		{
			return CreateDeleteByTIPO_TEXTO_PREDEFINIDO_IDCommand(tipo_texto_predefinido_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FONDO_FIJO_DET_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_texto_predefinido_id">The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_TEXTO_PREDEFINIDO_IDCommand(decimal tipo_texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TIPO_TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TIPO_TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_TEXTO_PREDEFINIDO_ID", tipo_texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>MOVIMIENTO_FONDO_FIJO_DET</c> records that match the specified criteria.
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
		/// to delete <c>MOVIMIENTO_FONDO_FIJO_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.MOVIMIENTO_FONDO_FIJO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		protected MOVIMIENTO_FONDO_FIJO_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		protected MOVIMIENTO_FONDO_FIJO_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> objects.</returns>
		protected virtual MOVIMIENTO_FONDO_FIJO_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int movimiento_fondo_fijo_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_ID");
			int tipo_texto_predefinido_idColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int monto_ingreso_origenColumnIndex = reader.GetOrdinal("MONTO_INGRESO_ORIGEN");
			int monto_ingreso_destinoColumnIndex = reader.GetOrdinal("MONTO_INGRESO_DESTINO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int comentarioColumnIndex = reader.GetOrdinal("COMENTARIO");
			int monto_egreso_origenColumnIndex = reader.GetOrdinal("MONTO_EGRESO_ORIGEN");
			int monto_egreso_destinoColumnIndex = reader.GetOrdinal("MONTO_EGRESO_DESTINO");
			int sucursal_movimiento_idColumnIndex = reader.GetOrdinal("SUCURSAL_MOVIMIENTO_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int generar_adelanto_funcColumnIndex = reader.GetOrdinal("GENERAR_ADELANTO_FUNC");
			int generar_anticipo_proveedorColumnIndex = reader.GetOrdinal("GENERAR_ANTICIPO_PROVEEDOR");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MOVIMIENTO_FONDO_FIJO_DETRow record = new MOVIMIENTO_FONDO_FIJO_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.MOVIMIENTO_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_idColumnIndex)), 9);
					record.TIPO_TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_texto_predefinido_idColumnIndex)), 9);
					record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					record.MONTO_INGRESO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_ingreso_origenColumnIndex)), 9);
					record.MONTO_INGRESO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_ingreso_destinoColumnIndex)), 9);
					record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(comentarioColumnIndex))
						record.COMENTARIO = Convert.ToString(reader.GetValue(comentarioColumnIndex));
					record.MONTO_EGRESO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_egreso_origenColumnIndex)), 9);
					record.MONTO_EGRESO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_egreso_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_movimiento_idColumnIndex))
						record.SUCURSAL_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.GENERAR_ADELANTO_FUNC = Convert.ToString(reader.GetValue(generar_adelanto_funcColumnIndex));
					record.GENERAR_ANTICIPO_PROVEEDOR = Convert.ToString(reader.GetValue(generar_anticipo_proveedorColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MOVIMIENTO_FONDO_FIJO_DETRow[])(recordList.ToArray(typeof(MOVIMIENTO_FONDO_FIJO_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> object.</returns>
		protected virtual MOVIMIENTO_FONDO_FIJO_DETRow MapRow(DataRow row)
		{
			MOVIMIENTO_FONDO_FIJO_DETRow mappedObject = new MOVIMIENTO_FONDO_FIJO_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_INGRESO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_INGRESO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INGRESO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_INGRESO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_INGRESO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INGRESO_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "COMENTARIO"
			dataColumn = dataTable.Columns["COMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO = (string)row[dataColumn];
			// Column "MONTO_EGRESO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_EGRESO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EGRESO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_EGRESO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_EGRESO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EGRESO_DESTINO = (decimal)row[dataColumn];
			// Column "SUCURSAL_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "GENERAR_ADELANTO_FUNC"
			dataColumn = dataTable.Columns["GENERAR_ADELANTO_FUNC"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_ADELANTO_FUNC = (string)row[dataColumn];
			// Column "GENERAR_ANTICIPO_PROVEEDOR"
			dataColumn = dataTable.Columns["GENERAR_ANTICIPO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_ANTICIPO_PROVEEDOR = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MOVIMIENTO_FONDO_FIJO_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INGRESO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INGRESO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COMENTARIO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("MONTO_EGRESO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_EGRESO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_MOVIMIENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GENERAR_ADELANTO_FUNC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GENERAR_ANTICIPO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "MOVIMIENTO_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INGRESO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INGRESO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_EGRESO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_EGRESO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_ADELANTO_FUNC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_ANTICIPO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MOVIMIENTO_FONDO_FIJO_DETCollection_Base class
}  // End of namespace
