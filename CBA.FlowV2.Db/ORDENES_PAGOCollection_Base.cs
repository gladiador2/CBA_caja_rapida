// <fileinfo name="ORDENES_PAGOCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_PAGOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string RETENCION_AUTONUMERACION_IDColumnName = "RETENCION_AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHAColumnName = "FECHA";
		public const string NRO_RECIBO_BENEFICIARIOColumnName = "NRO_RECIBO_BENEFICIARIO";
		public const string FECHA_RECIBO_BENEFICIARIOColumnName = "FECHA_RECIBO_BENEFICIARIO";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string OBSERVACION_INTERNAColumnName = "OBSERVACION_INTERNA";
		public const string ORDEN_PAGO_TIPO_IDColumnName = "ORDEN_PAGO_TIPO_ID";
		public const string CTACTE_CAJA_TESO_ORIGEN_IDColumnName = "CTACTE_CAJA_TESO_ORIGEN_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string CASO_ORIGINARIO_IDColumnName = "CASO_ORIGINARIO_ID";
		public const string RETENCION_UNIFICADAColumnName = "RETENCION_UNIFICADA";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string NUMERO_SOLICITUDColumnName = "NUMERO_SOLICITUD";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_PAGOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_PAGORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_PAGORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_PAGORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_PAGO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ORDENES_PAGORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ORDENES_PAGORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ORDENES_PAGORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByCTACTE_CAJA_TESO_ORIGEN_ID(decimal ctacte_caja_teso_origen_id)
		{
			return GetByCTACTE_CAJA_TESO_ORIGEN_ID(ctacte_caja_teso_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_origen_idNull">true if the method ignores the ctacte_caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByCTACTE_CAJA_TESO_ORIGEN_ID(decimal ctacte_caja_teso_origen_id, bool ctacte_caja_teso_origen_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESO_ORIGEN_IDCommand(ctacte_caja_teso_origen_id, ctacte_caja_teso_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESO_ORIGEN_IDAsDataTable(decimal ctacte_caja_teso_origen_id)
		{
			return GetByCTACTE_CAJA_TESO_ORIGEN_IDAsDataTable(ctacte_caja_teso_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_origen_idNull">true if the method ignores the ctacte_caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESO_ORIGEN_IDAsDataTable(decimal ctacte_caja_teso_origen_id, bool ctacte_caja_teso_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESO_ORIGEN_IDCommand(ctacte_caja_teso_origen_id, ctacte_caja_teso_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_origen_idNull">true if the method ignores the ctacte_caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESO_ORIGEN_IDCommand(decimal ctacte_caja_teso_origen_id, bool ctacte_caja_teso_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_origen_idNull)
				whereSql += "CTACTE_CAJA_TESO_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_teso_origen_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_ORIGEN_ID", ctacte_caja_teso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_CASO</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByCASO_ORIGINARIO_ID(decimal caso_originario_id)
		{
			return GetByCASO_ORIGINARIO_ID(caso_originario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByCASO_ORIGINARIO_ID(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return MapRecords(CreateGetByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ORIGINARIO_IDAsDataTable(decimal caso_originario_id)
		{
			return GetByCASO_ORIGINARIO_IDAsDataTable(caso_originario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGINARIO_IDAsDataTable(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGINARIO_IDCommand(decimal caso_originario_id, bool caso_originario_idNull)
		{
			string whereSql = "";
			if(caso_originario_idNull)
				whereSql += "CASO_ORIGINARIO_ID IS NULL";
			else
				whereSql += "CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_originario_idNull)
				AddParameter(cmd, "CASO_ORIGINARIO_ID", caso_originario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id)
		{
			return GetByRETENCION_AUTONUMERACION_ID(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_AUTONUMERACION_IDAsDataTable(decimal retencion_autonumeracion_id)
		{
			return GetByRETENCION_AUTONUMERACION_IDAsDataTable(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_AUTONUMERACION_IDAsDataTable(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_AUTONUMERACION_IDCommand(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			string whereSql = "";
			if(retencion_autonumeracion_idNull)
				whereSql += "RETENCION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_autonumeracion_idNull)
				AddParameter(cmd, "RETENCION_AUTONUMERACION_ID", retencion_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public ORDENES_PAGORow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGORow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_tipo_id">The <c>ORDEN_PAGO_TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		public virtual ORDENES_PAGORow[] GetByORDEN_PAGO_TIPO_ID(decimal orden_pago_tipo_id)
		{
			return MapRecords(CreateGetByORDEN_PAGO_TIPO_IDCommand(orden_pago_tipo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_tipo_id">The <c>ORDEN_PAGO_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_TIPO_IDAsDataTable(decimal orden_pago_tipo_id)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_TIPO_IDCommand(orden_pago_tipo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_tipo_id">The <c>ORDEN_PAGO_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_TIPO_IDCommand(decimal orden_pago_tipo_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_TIPO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_TIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ORDEN_PAGO_TIPO_ID", orden_pago_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGORow"/> object to be inserted.</param>
		public virtual void Insert(ORDENES_PAGORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ORDENES_PAGO (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"AUTONUMERACION_ID, " +
				"RETENCION_AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA, " +
				"NRO_RECIBO_BENEFICIARIO, " +
				"FECHA_RECIBO_BENEFICIARIO, " +
				"NOMBRE_BENEFICIARIO, " +
				"OBSERVACION, " +
				"OBSERVACION_INTERNA, " +
				"ORDEN_PAGO_TIPO_ID, " +
				"CTACTE_CAJA_TESO_ORIGEN_ID, " +
				"PROVEEDOR_ID, " +
				"PERSONA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_TOTAL, " +
				"CASO_ORIGINARIO_ID, " +
				"RETENCION_UNIFICADA, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"NUMERO_SOLICITUD" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("NRO_RECIBO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_RECIBO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_INTERNA") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_TIPO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGINARIO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_UNIFICADA") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_SOLICITUD") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "RETENCION_AUTONUMERACION_ID",
				value.IsRETENCION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.RETENCION_AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "NRO_RECIBO_BENEFICIARIO", value.NRO_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "FECHA_RECIBO_BENEFICIARIO",
				value.IsFECHA_RECIBO_BENEFICIARIONull ? DBNull.Value : (object)value.FECHA_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "OBSERVACION_INTERNA", value.OBSERVACION_INTERNA);
			AddParameter(cmd, "ORDEN_PAGO_TIPO_ID", value.ORDEN_PAGO_TIPO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_ORIGEN_ID",
				value.IsCTACTE_CAJA_TESO_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_ORIGEN_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "CASO_ORIGINARIO_ID",
				value.IsCASO_ORIGINARIO_IDNull ? DBNull.Value : (object)value.CASO_ORIGINARIO_ID);
			AddParameter(cmd, "RETENCION_UNIFICADA", value.RETENCION_UNIFICADA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "NUMERO_SOLICITUD", value.NUMERO_SOLICITUD);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ORDENES_PAGORow value)
		{
			
			string sqlStr = "UPDATE TRC.ORDENES_PAGO SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"NRO_RECIBO_BENEFICIARIO=" + _db.CreateSqlParameterName("NRO_RECIBO_BENEFICIARIO") + ", " +
				"FECHA_RECIBO_BENEFICIARIO=" + _db.CreateSqlParameterName("FECHA_RECIBO_BENEFICIARIO") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"OBSERVACION_INTERNA=" + _db.CreateSqlParameterName("OBSERVACION_INTERNA") + ", " +
				"ORDEN_PAGO_TIPO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_TIPO_ID") + ", " +
				"CTACTE_CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ORIGEN_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID") + ", " +
				"RETENCION_UNIFICADA=" + _db.CreateSqlParameterName("RETENCION_UNIFICADA") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"NUMERO_SOLICITUD=" + _db.CreateSqlParameterName("NUMERO_SOLICITUD") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "RETENCION_AUTONUMERACION_ID",
				value.IsRETENCION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.RETENCION_AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "NRO_RECIBO_BENEFICIARIO", value.NRO_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "FECHA_RECIBO_BENEFICIARIO",
				value.IsFECHA_RECIBO_BENEFICIARIONull ? DBNull.Value : (object)value.FECHA_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "OBSERVACION_INTERNA", value.OBSERVACION_INTERNA);
			AddParameter(cmd, "ORDEN_PAGO_TIPO_ID", value.ORDEN_PAGO_TIPO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_ORIGEN_ID",
				value.IsCTACTE_CAJA_TESO_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_ORIGEN_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "CASO_ORIGINARIO_ID",
				value.IsCASO_ORIGINARIO_IDNull ? DBNull.Value : (object)value.CASO_ORIGINARIO_ID);
			AddParameter(cmd, "RETENCION_UNIFICADA", value.RETENCION_UNIFICADA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "NUMERO_SOLICITUD", value.NUMERO_SOLICITUD);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ORDENES_PAGORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ORDENES_PAGO</c> table using
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
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_AUTONUM</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_ORIGEN_ID(decimal ctacte_caja_teso_origen_id)
		{
			return DeleteByCTACTE_CAJA_TESO_ORIGEN_ID(ctacte_caja_teso_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_origen_idNull">true if the method ignores the ctacte_caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_ORIGEN_ID(decimal ctacte_caja_teso_origen_id, bool ctacte_caja_teso_origen_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESO_ORIGEN_IDCommand(ctacte_caja_teso_origen_id, ctacte_caja_teso_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_CAJA_TESO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_origen_id">The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_origen_idNull">true if the method ignores the ctacte_caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESO_ORIGEN_IDCommand(decimal ctacte_caja_teso_origen_id, bool ctacte_caja_teso_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_origen_idNull)
				whereSql += "CTACTE_CAJA_TESO_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_teso_origen_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_ORIGEN_ID", ctacte_caja_teso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_CASO</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGINARIO_ID(decimal caso_originario_id)
		{
			return DeleteByCASO_ORIGINARIO_ID(caso_originario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGINARIO_ID(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return CreateDeleteByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_CASO_ORIG</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGINARIO_IDCommand(decimal caso_originario_id, bool caso_originario_idNull)
		{
			string whereSql = "";
			if(caso_originario_idNull)
				whereSql += "CASO_ORIGINARIO_ID IS NULL";
			else
				whereSql += "CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_originario_idNull)
				AddParameter(cmd, "CASO_ORIGINARIO_ID", caso_originario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_PESONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_PROVEEDOR</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id)
		{
			return DeleteByRETENCION_AUTONUMERACION_ID(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return CreateDeleteByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_RETENC_AUTON</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_AUTONUMERACION_IDCommand(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			string whereSql = "";
			if(retencion_autonumeracion_idNull)
				whereSql += "RETENCION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_autonumeracion_idNull)
				AddParameter(cmd, "RETENCION_AUTONUMERACION_ID", retencion_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO</c> table using the 
		/// <c>FK_ORDENES_PAGO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_tipo_id">The <c>ORDEN_PAGO_TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_TIPO_ID(decimal orden_pago_tipo_id)
		{
			return CreateDeleteByORDEN_PAGO_TIPO_IDCommand(orden_pago_tipo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_tipo_id">The <c>ORDEN_PAGO_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_TIPO_IDCommand(decimal orden_pago_tipo_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_TIPO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_TIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ORDEN_PAGO_TIPO_ID", orden_pago_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ORDENES_PAGO</c> records that match the specified criteria.
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
		/// to delete <c>ORDENES_PAGO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ORDENES_PAGO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ORDENES_PAGO</c> table.
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
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		protected ORDENES_PAGORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		protected ORDENES_PAGORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_PAGORow"/> objects.</returns>
		protected virtual ORDENES_PAGORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int retencion_autonumeracion_idColumnIndex = reader.GetOrdinal("RETENCION_AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int nro_recibo_beneficiarioColumnIndex = reader.GetOrdinal("NRO_RECIBO_BENEFICIARIO");
			int fecha_recibo_beneficiarioColumnIndex = reader.GetOrdinal("FECHA_RECIBO_BENEFICIARIO");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int observacion_internaColumnIndex = reader.GetOrdinal("OBSERVACION_INTERNA");
			int orden_pago_tipo_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_TIPO_ID");
			int ctacte_caja_teso_origen_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_ORIGEN_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int caso_originario_idColumnIndex = reader.GetOrdinal("CASO_ORIGINARIO_ID");
			int retencion_unificadaColumnIndex = reader.GetOrdinal("RETENCION_UNIFICADA");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int numero_solicitudColumnIndex = reader.GetOrdinal("NUMERO_SOLICITUD");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_PAGORow record = new ORDENES_PAGORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_autonumeracion_idColumnIndex))
						record.RETENCION_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(nro_recibo_beneficiarioColumnIndex))
						record.NRO_RECIBO_BENEFICIARIO = Convert.ToString(reader.GetValue(nro_recibo_beneficiarioColumnIndex));
					if(!reader.IsDBNull(fecha_recibo_beneficiarioColumnIndex))
						record.FECHA_RECIBO_BENEFICIARIO = Convert.ToDateTime(reader.GetValue(fecha_recibo_beneficiarioColumnIndex));
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(observacion_internaColumnIndex))
						record.OBSERVACION_INTERNA = Convert.ToString(reader.GetValue(observacion_internaColumnIndex));
					record.ORDEN_PAGO_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_teso_origen_idColumnIndex))
						record.CTACTE_CAJA_TESO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_teso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(caso_originario_idColumnIndex))
						record.CASO_ORIGINARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_originario_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_unificadaColumnIndex))
						record.RETENCION_UNIFICADA = Convert.ToString(reader.GetValue(retencion_unificadaColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_solicitudColumnIndex))
						record.NUMERO_SOLICITUD = Convert.ToString(reader.GetValue(numero_solicitudColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_PAGORow[])(recordList.ToArray(typeof(ORDENES_PAGORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_PAGORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_PAGORow"/> object.</returns>
		protected virtual ORDENES_PAGORow MapRow(DataRow row)
		{
			ORDENES_PAGORow mappedObject = new ORDENES_PAGORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "RETENCION_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["RETENCION_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "NRO_RECIBO_BENEFICIARIO"
			dataColumn = dataTable.Columns["NRO_RECIBO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_RECIBO_BENEFICIARIO"
			dataColumn = dataTable.Columns["FECHA_RECIBO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECIBO_BENEFICIARIO = (System.DateTime)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "OBSERVACION_INTERNA"
			dataColumn = dataTable.Columns["OBSERVACION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_INTERNA = (string)row[dataColumn];
			// Column "ORDEN_PAGO_TIPO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_TIPO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "CASO_ORIGINARIO_ID"
			dataColumn = dataTable.Columns["CASO_ORIGINARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGINARIO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_UNIFICADA"
			dataColumn = dataTable.Columns["RETENCION_UNIFICADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_UNIFICADA = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "NUMERO_SOLICITUD"
			dataColumn = dataTable.Columns["NUMERO_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_SOLICITUD = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_PAGO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_PAGO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_RECIBO_BENEFICIARIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("OBSERVACION_INTERNA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_TIPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ORIGINARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_UNIFICADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_SOLICITUD", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_RECIBO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_RECIBO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_PAGO_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ORIGINARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_UNIFICADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_PAGOCollection_Base class
}  // End of namespace
