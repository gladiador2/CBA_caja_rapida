// <fileinfo name="INGRESO_STOCKCollection_Base.cs">
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
	/// The base class for <see cref="INGRESO_STOCKCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INGRESO_STOCKCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_STOCKCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CASO_FC_PROVEEDOR_IDColumnName = "CASO_FC_PROVEEDOR_ID";
		public const string PORCENTAJE_PRORATEOColumnName = "PORCENTAJE_PRORATEO";
		public const string MONTO_PRORATEOColumnName = "MONTO_PRORATEO";
		public const string APLICAR_PRORRATEOColumnName = "APLICAR_PRORRATEO";
		public const string TIPO_PRORRATEOColumnName = "TIPO_PRORRATEO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string NRO_DOCUMENTO_EXTERNOColumnName = "NRO_DOCUMENTO_EXTERNO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCKCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INGRESO_STOCKCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INGRESO_STOCKRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INGRESO_STOCKRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INGRESO_STOCKRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INGRESO_STOCKRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public INGRESO_STOCKRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects that 
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
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INGRESO_STOCK";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INGRESO_STOCKRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INGRESO_STOCKRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INGRESO_STOCKRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INGRESO_STOCKRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public INGRESO_STOCKRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public INGRESO_STOCKRow[] GetByCASO_FC_PROVEEDOR_ID(decimal caso_fc_proveedor_id)
		{
			return GetByCASO_FC_PROVEEDOR_ID(caso_fc_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_fc_proveedor_idNull">true if the method ignores the caso_fc_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetByCASO_FC_PROVEEDOR_ID(decimal caso_fc_proveedor_id, bool caso_fc_proveedor_idNull)
		{
			return MapRecords(CreateGetByCASO_FC_PROVEEDOR_IDCommand(caso_fc_proveedor_id, caso_fc_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_FC_PROVEEDOR_IDAsDataTable(decimal caso_fc_proveedor_id)
		{
			return GetByCASO_FC_PROVEEDOR_IDAsDataTable(caso_fc_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_fc_proveedor_idNull">true if the method ignores the caso_fc_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_FC_PROVEEDOR_IDAsDataTable(decimal caso_fc_proveedor_id, bool caso_fc_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_FC_PROVEEDOR_IDCommand(caso_fc_proveedor_id, caso_fc_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_fc_proveedor_idNull">true if the method ignores the caso_fc_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_FC_PROVEEDOR_IDCommand(decimal caso_fc_proveedor_id, bool caso_fc_proveedor_idNull)
		{
			string whereSql = "";
			if(caso_fc_proveedor_idNull)
				whereSql += "CASO_FC_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CASO_FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FC_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_fc_proveedor_idNull)
				AddParameter(cmd, "CASO_FC_PROVEEDOR_ID", caso_fc_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_SUC_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public INGRESO_STOCKRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCKRow"/> objects 
		/// by the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		public virtual INGRESO_STOCKRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
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
		/// return records by the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
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
		/// Adds a new record into the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCKRow"/> object to be inserted.</param>
		public virtual void Insert(INGRESO_STOCKRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INGRESO_STOCK (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"FECHA, " +
				"CASO_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"CASO_FC_PROVEEDOR_ID, " +
				"PORCENTAJE_PRORATEO, " +
				"MONTO_PRORATEO, " +
				"APLICAR_PRORRATEO, " +
				"TIPO_PRORRATEO, " +
				"OBSERVACION, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"NRO_DOCUMENTO_EXTERNO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("CASO_FC_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_PRORATEO") + ", " +
				_db.CreateSqlParameterName("MONTO_PRORATEO") + ", " +
				_db.CreateSqlParameterName("APLICAR_PRORRATEO") + ", " +
				_db.CreateSqlParameterName("TIPO_PRORRATEO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CASO_FC_PROVEEDOR_ID",
				value.IsCASO_FC_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CASO_FC_PROVEEDOR_ID);
			AddParameter(cmd, "PORCENTAJE_PRORATEO",
				value.IsPORCENTAJE_PRORATEONull ? DBNull.Value : (object)value.PORCENTAJE_PRORATEO);
			AddParameter(cmd, "MONTO_PRORATEO",
				value.IsMONTO_PRORATEONull ? DBNull.Value : (object)value.MONTO_PRORATEO);
			AddParameter(cmd, "APLICAR_PRORRATEO", value.APLICAR_PRORRATEO);
			AddParameter(cmd, "TIPO_PRORRATEO", value.TIPO_PRORRATEO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCKRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INGRESO_STOCKRow value)
		{
			
			string sqlStr = "UPDATE TRC.INGRESO_STOCK SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"CASO_FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FC_PROVEEDOR_ID") + ", " +
				"PORCENTAJE_PRORATEO=" + _db.CreateSqlParameterName("PORCENTAJE_PRORATEO") + ", " +
				"MONTO_PRORATEO=" + _db.CreateSqlParameterName("MONTO_PRORATEO") + ", " +
				"APLICAR_PRORRATEO=" + _db.CreateSqlParameterName("APLICAR_PRORRATEO") + ", " +
				"TIPO_PRORRATEO=" + _db.CreateSqlParameterName("TIPO_PRORRATEO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"NRO_DOCUMENTO_EXTERNO=" + _db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CASO_FC_PROVEEDOR_ID",
				value.IsCASO_FC_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CASO_FC_PROVEEDOR_ID);
			AddParameter(cmd, "PORCENTAJE_PRORATEO",
				value.IsPORCENTAJE_PRORATEONull ? DBNull.Value : (object)value.PORCENTAJE_PRORATEO);
			AddParameter(cmd, "MONTO_PRORATEO",
				value.IsMONTO_PRORATEONull ? DBNull.Value : (object)value.MONTO_PRORATEO);
			AddParameter(cmd, "APLICAR_PRORRATEO", value.APLICAR_PRORRATEO);
			AddParameter(cmd, "TIPO_PRORRATEO", value.TIPO_PRORRATEO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INGRESO_STOCK</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INGRESO_STOCK</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCKRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INGRESO_STOCKRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INGRESO_STOCK</c> table using
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
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_ING_STOCK_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FC_PROVEEDOR_ID(decimal caso_fc_proveedor_id)
		{
			return DeleteByCASO_FC_PROVEEDOR_ID(caso_fc_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_fc_proveedor_idNull">true if the method ignores the caso_fc_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FC_PROVEEDOR_ID(decimal caso_fc_proveedor_id, bool caso_fc_proveedor_idNull)
		{
			return CreateDeleteByCASO_FC_PROVEEDOR_IDCommand(caso_fc_proveedor_id, caso_fc_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_CASO_FC_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_fc_proveedor_id">The <c>CASO_FC_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_fc_proveedor_idNull">true if the method ignores the caso_fc_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_FC_PROVEEDOR_IDCommand(decimal caso_fc_proveedor_id, bool caso_fc_proveedor_idNull)
		{
			string whereSql = "";
			if(caso_fc_proveedor_idNull)
				whereSql += "CASO_FC_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CASO_FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FC_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_fc_proveedor_idNull)
				AddParameter(cmd, "CASO_FC_PROVEEDOR_ID", caso_fc_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_SUC_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK</c> table using the 
		/// <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
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
		/// delete records using the <c>FK_ING_STOCK_TEXTO_PRED</c> foreign key.
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
		/// Deletes <c>INGRESO_STOCK</c> records that match the specified criteria.
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
		/// to delete <c>INGRESO_STOCK</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INGRESO_STOCK";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INGRESO_STOCK</c> table.
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
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		protected INGRESO_STOCKRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		protected INGRESO_STOCKRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INGRESO_STOCKRow"/> objects.</returns>
		protected virtual INGRESO_STOCKRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int caso_fc_proveedor_idColumnIndex = reader.GetOrdinal("CASO_FC_PROVEEDOR_ID");
			int porcentaje_prorateoColumnIndex = reader.GetOrdinal("PORCENTAJE_PRORATEO");
			int monto_prorateoColumnIndex = reader.GetOrdinal("MONTO_PRORATEO");
			int aplicar_prorrateoColumnIndex = reader.GetOrdinal("APLICAR_PRORRATEO");
			int tipo_prorrateoColumnIndex = reader.GetOrdinal("TIPO_PRORRATEO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int nro_documento_externoColumnIndex = reader.GetOrdinal("NRO_DOCUMENTO_EXTERNO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INGRESO_STOCKRow record = new INGRESO_STOCKRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(caso_fc_proveedor_idColumnIndex))
						record.CASO_FC_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_fc_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_prorateoColumnIndex))
						record.PORCENTAJE_PRORATEO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_prorateoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_prorateoColumnIndex))
						record.MONTO_PRORATEO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorateoColumnIndex)), 9);
					if(!reader.IsDBNull(aplicar_prorrateoColumnIndex))
						record.APLICAR_PRORRATEO = Convert.ToString(reader.GetValue(aplicar_prorrateoColumnIndex));
					record.TIPO_PRORRATEO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_prorrateoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_documento_externoColumnIndex))
						record.NRO_DOCUMENTO_EXTERNO = Convert.ToString(reader.GetValue(nro_documento_externoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INGRESO_STOCKRow[])(recordList.ToArray(typeof(INGRESO_STOCKRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INGRESO_STOCKRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INGRESO_STOCKRow"/> object.</returns>
		protected virtual INGRESO_STOCKRow MapRow(DataRow row)
		{
			INGRESO_STOCKRow mappedObject = new INGRESO_STOCKRow();
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
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_FC_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CASO_FC_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FC_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_PRORATEO"
			dataColumn = dataTable.Columns["PORCENTAJE_PRORATEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_PRORATEO = (decimal)row[dataColumn];
			// Column "MONTO_PRORATEO"
			dataColumn = dataTable.Columns["MONTO_PRORATEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORATEO = (decimal)row[dataColumn];
			// Column "APLICAR_PRORRATEO"
			dataColumn = dataTable.Columns["APLICAR_PRORRATEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_PRORRATEO = (string)row[dataColumn];
			// Column "TIPO_PRORRATEO"
			dataColumn = dataTable.Columns["TIPO_PRORRATEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_PRORRATEO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "NRO_DOCUMENTO_EXTERNO"
			dataColumn = dataTable.Columns["NRO_DOCUMENTO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_DOCUMENTO_EXTERNO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INGRESO_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INGRESO_STOCK";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CASO_FC_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_PRORATEO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_PRORATEO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICAR_PRORRATEO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TIPO_PRORRATEO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_DOCUMENTO_EXTERNO", typeof(string));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FC_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_PRORATEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRORATEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_PRORRATEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_PRORRATEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_DOCUMENTO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INGRESO_STOCKCollection_Base class
}  // End of namespace
