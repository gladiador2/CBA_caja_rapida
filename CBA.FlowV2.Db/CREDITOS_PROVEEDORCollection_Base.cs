// <fileinfo name="CREDITOS_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="CREDITOS_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CREDITOS_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_PROVEEDORCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_RELAC_INGRESA_VALORES_IDColumnName = "CASO_RELAC_INGRESA_VALORES_ID";
		public const string TIPO_CREDITO_IDColumnName = "TIPO_CREDITO_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_SOLICITUDColumnName = "FECHA_SOLICITUD";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string FECHA_DESEMBOLSOColumnName = "FECHA_DESEMBOLSO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_CAPITALColumnName = "MONTO_CAPITAL";
		public const string MONTO_INTERESColumnName = "MONTO_INTERES";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string INTERES_ANUALColumnName = "INTERES_ANUAL";
		public const string PORCENTAJE_DIARIO_MORAColumnName = "PORCENTAJE_DIARIO_MORA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FACTURAR_INTERESES_EN_PAGOSColumnName = "FACTURAR_INTERESES_EN_PAGOS";
		public const string FACTURAR_CAPITAL_EN_PAGOSColumnName = "FACTURAR_CAPITAL_EN_PAGOS";
		public const string FACTURAR_SOLO_INTERESESColumnName = "FACTURAR_SOLO_INTERESES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CREDITOS_PROVEEDORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CREDITOS_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CREDITOS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CREDITOS_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CREDITOS_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public CREDITOS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CREDITOS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CREDITOS_PROVEEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CREDITOS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CREDITOS_PROVEEDORRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CREDITOS_PROVEEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public CREDITOS_PROVEEDORRow[] GetByCASO_RELAC_INGRESA_VALORES_ID(decimal caso_relac_ingresa_valores_id)
		{
			return GetByCASO_RELAC_INGRESA_VALORES_ID(caso_relac_ingresa_valores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <param name="caso_relac_ingresa_valores_idNull">true if the method ignores the caso_relac_ingresa_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetByCASO_RELAC_INGRESA_VALORES_ID(decimal caso_relac_ingresa_valores_id, bool caso_relac_ingresa_valores_idNull)
		{
			return MapRecords(CreateGetByCASO_RELAC_INGRESA_VALORES_IDCommand(caso_relac_ingresa_valores_id, caso_relac_ingresa_valores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_RELAC_INGRESA_VALORES_IDAsDataTable(decimal caso_relac_ingresa_valores_id)
		{
			return GetByCASO_RELAC_INGRESA_VALORES_IDAsDataTable(caso_relac_ingresa_valores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <param name="caso_relac_ingresa_valores_idNull">true if the method ignores the caso_relac_ingresa_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_RELAC_INGRESA_VALORES_IDAsDataTable(decimal caso_relac_ingresa_valores_id, bool caso_relac_ingresa_valores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_RELAC_INGRESA_VALORES_IDCommand(caso_relac_ingresa_valores_id, caso_relac_ingresa_valores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <param name="caso_relac_ingresa_valores_idNull">true if the method ignores the caso_relac_ingresa_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_RELAC_INGRESA_VALORES_IDCommand(decimal caso_relac_ingresa_valores_id, bool caso_relac_ingresa_valores_idNull)
		{
			string whereSql = "";
			if(caso_relac_ingresa_valores_idNull)
				whereSql += "CASO_RELAC_INGRESA_VALORES_ID IS NULL";
			else
				whereSql += "CASO_RELAC_INGRESA_VALORES_ID=" + _db.CreateSqlParameterName("CASO_RELAC_INGRESA_VALORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_relac_ingresa_valores_idNull)
				AddParameter(cmd, "CASO_RELAC_INGRESA_VALORES_ID", caso_relac_ingresa_valores_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_SUC</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_TIPO_CR</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDORRow[] GetByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return MapRecords(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_TIPO_CR</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CREDITO_IDAsDataTable(decimal tipo_credito_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_TIPO_CR</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(CREDITOS_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CREDITOS_PROVEEDOR (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"CASO_ID, " +
				"CASO_RELAC_INGRESA_VALORES_ID, " +
				"TIPO_CREDITO_ID, " +
				"PROVEEDOR_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA_SOLICITUD, " +
				"FECHA_APROBACION, " +
				"FECHA_DESEMBOLSO, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_CAPITAL, " +
				"MONTO_INTERES, " +
				"MONTO_TOTAL, " +
				"PORCENTAJE_IMPUESTO, " +
				"MONTO_IMPUESTO, " +
				"INTERES_ANUAL, " +
				"PORCENTAJE_DIARIO_MORA, " +
				"OBSERVACION, " +
				"FACTURAR_INTERESES_EN_PAGOS, " +
				"FACTURAR_CAPITAL_EN_PAGOS, " +
				"FACTURAR_SOLO_INTERESES" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_RELAC_INGRESA_VALORES_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_SOLICITUD") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("INTERES_ANUAL") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("FACTURAR_INTERESES_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("FACTURAR_CAPITAL_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("FACTURAR_SOLO_INTERESES") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CASO_RELAC_INGRESA_VALORES_ID",
				value.IsCASO_RELAC_INGRESA_VALORES_IDNull ? DBNull.Value : (object)value.CASO_RELAC_INGRESA_VALORES_ID);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_SOLICITUD",
				value.IsFECHA_SOLICITUDNull ? DBNull.Value : (object)value.FECHA_SOLICITUD);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "FECHA_DESEMBOLSO",
				value.IsFECHA_DESEMBOLSONull ? DBNull.Value : (object)value.FECHA_DESEMBOLSO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "INTERES_ANUAL", value.INTERES_ANUAL);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA", value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FACTURAR_INTERESES_EN_PAGOS", value.FACTURAR_INTERESES_EN_PAGOS);
			AddParameter(cmd, "FACTURAR_CAPITAL_EN_PAGOS", value.FACTURAR_CAPITAL_EN_PAGOS);
			AddParameter(cmd, "FACTURAR_SOLO_INTERESES", value.FACTURAR_SOLO_INTERESES);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CREDITOS_PROVEEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.CREDITOS_PROVEEDOR SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"CASO_RELAC_INGRESA_VALORES_ID=" + _db.CreateSqlParameterName("CASO_RELAC_INGRESA_VALORES_ID") + ", " +
				"TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_SOLICITUD=" + _db.CreateSqlParameterName("FECHA_SOLICITUD") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"FECHA_DESEMBOLSO=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_CAPITAL=" + _db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				"MONTO_INTERES=" + _db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"MONTO_IMPUESTO=" + _db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				"INTERES_ANUAL=" + _db.CreateSqlParameterName("INTERES_ANUAL") + ", " +
				"PORCENTAJE_DIARIO_MORA=" + _db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"FACTURAR_INTERESES_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_INTERESES_EN_PAGOS") + ", " +
				"FACTURAR_CAPITAL_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_CAPITAL_EN_PAGOS") + ", " +
				"FACTURAR_SOLO_INTERESES=" + _db.CreateSqlParameterName("FACTURAR_SOLO_INTERESES") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CASO_RELAC_INGRESA_VALORES_ID",
				value.IsCASO_RELAC_INGRESA_VALORES_IDNull ? DBNull.Value : (object)value.CASO_RELAC_INGRESA_VALORES_ID);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_SOLICITUD",
				value.IsFECHA_SOLICITUDNull ? DBNull.Value : (object)value.FECHA_SOLICITUD);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "FECHA_DESEMBOLSO",
				value.IsFECHA_DESEMBOLSONull ? DBNull.Value : (object)value.FECHA_DESEMBOLSO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "INTERES_ANUAL", value.INTERES_ANUAL);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA", value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FACTURAR_INTERESES_EN_PAGOS", value.FACTURAR_INTERESES_EN_PAGOS);
			AddParameter(cmd, "FACTURAR_CAPITAL_EN_PAGOS", value.FACTURAR_CAPITAL_EN_PAGOS);
			AddParameter(cmd, "FACTURAR_SOLO_INTERESES", value.FACTURAR_SOLO_INTERESES);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CREDITOS_PROVEEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CREDITOS_PROVEEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CREDITOS_PROVEEDORRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CREDITOS_PROVEEDOR</c> table using
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
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELAC_INGRESA_VALORES_ID(decimal caso_relac_ingresa_valores_id)
		{
			return DeleteByCASO_RELAC_INGRESA_VALORES_ID(caso_relac_ingresa_valores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <param name="caso_relac_ingresa_valores_idNull">true if the method ignores the caso_relac_ingresa_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELAC_INGRESA_VALORES_ID(decimal caso_relac_ingresa_valores_id, bool caso_relac_ingresa_valores_idNull)
		{
			return CreateDeleteByCASO_RELAC_INGRESA_VALORES_IDCommand(caso_relac_ingresa_valores_id, caso_relac_ingresa_valores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relac_ingresa_valores_id">The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</param>
		/// <param name="caso_relac_ingresa_valores_idNull">true if the method ignores the caso_relac_ingresa_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_RELAC_INGRESA_VALORES_IDCommand(decimal caso_relac_ingresa_valores_id, bool caso_relac_ingresa_valores_idNull)
		{
			string whereSql = "";
			if(caso_relac_ingresa_valores_idNull)
				whereSql += "CASO_RELAC_INGRESA_VALORES_ID IS NULL";
			else
				whereSql += "CASO_RELAC_INGRESA_VALORES_ID=" + _db.CreateSqlParameterName("CASO_RELAC_INGRESA_VALORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_relac_ingresa_valores_idNull)
				AddParameter(cmd, "CASO_RELAC_INGRESA_VALORES_ID", caso_relac_ingresa_valores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_SUC</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS_PROVEEDOR</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_TIPO_CR</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return CreateDeleteByTIPO_CREDITO_IDCommand(tipo_credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_TIPO_CR</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CREDITOS_PROVEEDOR</c> records that match the specified criteria.
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
		/// to delete <c>CREDITOS_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CREDITOS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CREDITOS_PROVEEDOR</c> table.
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		protected CREDITOS_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		protected CREDITOS_PROVEEDORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDORRow"/> objects.</returns>
		protected virtual CREDITOS_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_relac_ingresa_valores_idColumnIndex = reader.GetOrdinal("CASO_RELAC_INGRESA_VALORES_ID");
			int tipo_credito_idColumnIndex = reader.GetOrdinal("TIPO_CREDITO_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_solicitudColumnIndex = reader.GetOrdinal("FECHA_SOLICITUD");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int fecha_desembolsoColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_capitalColumnIndex = reader.GetOrdinal("MONTO_CAPITAL");
			int monto_interesColumnIndex = reader.GetOrdinal("MONTO_INTERES");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int interes_anualColumnIndex = reader.GetOrdinal("INTERES_ANUAL");
			int porcentaje_diario_moraColumnIndex = reader.GetOrdinal("PORCENTAJE_DIARIO_MORA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int facturar_intereses_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_INTERESES_EN_PAGOS");
			int facturar_capital_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_CAPITAL_EN_PAGOS");
			int facturar_solo_interesesColumnIndex = reader.GetOrdinal("FACTURAR_SOLO_INTERESES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CREDITOS_PROVEEDORRow record = new CREDITOS_PROVEEDORRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_relac_ingresa_valores_idColumnIndex))
						record.CASO_RELAC_INGRESA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relac_ingresa_valores_idColumnIndex)), 9);
					record.TIPO_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_credito_idColumnIndex)), 9);
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fecha_solicitudColumnIndex))
						record.FECHA_SOLICITUD = Convert.ToDateTime(reader.GetValue(fecha_solicitudColumnIndex));
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(fecha_desembolsoColumnIndex))
						record.FECHA_DESEMBOLSO = Convert.ToDateTime(reader.GetValue(fecha_desembolsoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capitalColumnIndex)), 9);
					record.MONTO_INTERES = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interesColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					record.INTERES_ANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(interes_anualColumnIndex)), 9);
					record.PORCENTAJE_DIARIO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_diario_moraColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.FACTURAR_INTERESES_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_intereses_en_pagosColumnIndex));
					record.FACTURAR_CAPITAL_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_capital_en_pagosColumnIndex));
					record.FACTURAR_SOLO_INTERESES = Convert.ToString(reader.GetValue(facturar_solo_interesesColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CREDITOS_PROVEEDORRow[])(recordList.ToArray(typeof(CREDITOS_PROVEEDORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CREDITOS_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CREDITOS_PROVEEDORRow"/> object.</returns>
		protected virtual CREDITOS_PROVEEDORRow MapRow(DataRow row)
		{
			CREDITOS_PROVEEDORRow mappedObject = new CREDITOS_PROVEEDORRow();
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
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_RELAC_INGRESA_VALORES_ID"
			dataColumn = dataTable.Columns["CASO_RELAC_INGRESA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELAC_INGRESA_VALORES_ID = (decimal)row[dataColumn];
			// Column "TIPO_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CREDITO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_SOLICITUD"
			dataColumn = dataTable.Columns["FECHA_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SOLICITUD = (System.DateTime)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESEMBOLSO"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL"
			dataColumn = dataTable.Columns["MONTO_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL = (decimal)row[dataColumn];
			// Column "MONTO_INTERES"
			dataColumn = dataTable.Columns["MONTO_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "INTERES_ANUAL"
			dataColumn = dataTable.Columns["INTERES_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_ANUAL = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DIARIO_MORA"
			dataColumn = dataTable.Columns["PORCENTAJE_DIARIO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DIARIO_MORA = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FACTURAR_INTERESES_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_INTERESES_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_INTERESES_EN_PAGOS = (string)row[dataColumn];
			// Column "FACTURAR_CAPITAL_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_CAPITAL_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_CAPITAL_EN_PAGOS = (string)row[dataColumn];
			// Column "FACTURAR_SOLO_INTERESES"
			dataColumn = dataTable.Columns["FACTURAR_SOLO_INTERESES"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_SOLO_INTERESES = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CREDITOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CREDITOS_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_RELAC_INGRESA_VALORES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_SOLICITUD", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_ANUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DIARIO_MORA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("FACTURAR_INTERESES_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_CAPITAL_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_SOLO_INTERESES", typeof(string));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_RELAC_INGRESA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DIARIO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURAR_INTERESES_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_CAPITAL_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_SOLO_INTERESES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CREDITOS_PROVEEDORCollection_Base class
}  // End of namespace
