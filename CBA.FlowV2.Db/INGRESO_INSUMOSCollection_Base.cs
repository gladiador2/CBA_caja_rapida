// <fileinfo name="INGRESO_INSUMOSCollection_Base.cs">
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
	/// The base class for <see cref="INGRESO_INSUMOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INGRESO_INSUMOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_INSUMOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string BOX_IDColumnName = "BOX_ID";
		public const string TIPO_INGRESOColumnName = "TIPO_INGRESO";
		public const string FACTURAColumnName = "FACTURA";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string BUQUE_IDColumnName = "BUQUE_ID";
		public const string REGISTROColumnName = "REGISTRO";
		public const string AUTORIZACION_DNAColumnName = "AUTORIZACION_DNA";
		public const string TRANSPORTISTAColumnName = "TRANSPORTISTA";
		public const string MERMAColumnName = "MERMA";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string PERSONA_IDColumnName = "PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_INSUMOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INGRESO_INSUMOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INGRESO_INSUMOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INGRESO_INSUMOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INGRESO_INSUMOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INGRESO_INSUMOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects that 
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
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INGRESO_INSUMOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INGRESO_INSUMOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INGRESO_INSUMOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INGRESO_INSUMOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INGRESO_INSUMOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetByBUQUE_ID(decimal buque_id)
		{
			return GetByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetByBUQUE_ID(decimal buque_id, bool buque_idNull)
		{
			return MapRecords(CreateGetByBUQUE_IDCommand(buque_id, buque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBUQUE_IDAsDataTable(decimal buque_id)
		{
			return GetByBUQUE_IDAsDataTable(buque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBUQUE_IDAsDataTable(decimal buque_id, bool buque_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBUQUE_IDCommand(buque_id, buque_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBUQUE_IDCommand(decimal buque_id, bool buque_idNull)
		{
			string whereSql = "";
			if(buque_idNull)
				whereSql += "BUQUE_ID IS NULL";
			else
				whereSql += "BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!buque_idNull)
				AddParameter(cmd, "BUQUE_ID", buque_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRESO_INSUMOS_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
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
		/// return records by the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public INGRESO_INSUMOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOSRow"/> objects 
		/// by the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		public virtual INGRESO_INSUMOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
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
		/// return records by the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
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
		/// Adds a new record into the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOSRow"/> object to be inserted.</param>
		public virtual void Insert(INGRESO_INSUMOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INGRESO_INSUMOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"BOX_ID, " +
				"TIPO_INGRESO, " +
				"FACTURA, " +
				"DESPACHO, " +
				"BUQUE_ID, " +
				"REGISTRO, " +
				"AUTORIZACION_DNA, " +
				"TRANSPORTISTA, " +
				"MERMA, " +
				"OBSERVACIONES, " +
				"PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("BOX_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_INGRESO") + ", " +
				_db.CreateSqlParameterName("FACTURA") + ", " +
				_db.CreateSqlParameterName("DESPACHO") + ", " +
				_db.CreateSqlParameterName("BUQUE_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO") + ", " +
				_db.CreateSqlParameterName("AUTORIZACION_DNA") + ", " +
				_db.CreateSqlParameterName("TRANSPORTISTA") + ", " +
				_db.CreateSqlParameterName("MERMA") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "BOX_ID",
				value.IsBOX_IDNull ? DBNull.Value : (object)value.BOX_ID);
			AddParameter(cmd, "TIPO_INGRESO", value.TIPO_INGRESO);
			AddParameter(cmd, "FACTURA", value.FACTURA);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "REGISTRO", value.REGISTRO);
			AddParameter(cmd, "AUTORIZACION_DNA", value.AUTORIZACION_DNA);
			AddParameter(cmd, "TRANSPORTISTA", value.TRANSPORTISTA);
			AddParameter(cmd, "MERMA",
				value.IsMERMANull ? DBNull.Value : (object)value.MERMA);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INGRESO_INSUMOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.INGRESO_INSUMOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"BOX_ID=" + _db.CreateSqlParameterName("BOX_ID") + ", " +
				"TIPO_INGRESO=" + _db.CreateSqlParameterName("TIPO_INGRESO") + ", " +
				"FACTURA=" + _db.CreateSqlParameterName("FACTURA") + ", " +
				"DESPACHO=" + _db.CreateSqlParameterName("DESPACHO") + ", " +
				"BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID") + ", " +
				"REGISTRO=" + _db.CreateSqlParameterName("REGISTRO") + ", " +
				"AUTORIZACION_DNA=" + _db.CreateSqlParameterName("AUTORIZACION_DNA") + ", " +
				"TRANSPORTISTA=" + _db.CreateSqlParameterName("TRANSPORTISTA") + ", " +
				"MERMA=" + _db.CreateSqlParameterName("MERMA") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "BOX_ID",
				value.IsBOX_IDNull ? DBNull.Value : (object)value.BOX_ID);
			AddParameter(cmd, "TIPO_INGRESO", value.TIPO_INGRESO);
			AddParameter(cmd, "FACTURA", value.FACTURA);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "REGISTRO", value.REGISTRO);
			AddParameter(cmd, "AUTORIZACION_DNA", value.AUTORIZACION_DNA);
			AddParameter(cmd, "TRANSPORTISTA", value.TRANSPORTISTA);
			AddParameter(cmd, "MERMA",
				value.IsMERMANull ? DBNull.Value : (object)value.MERMA);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INGRESO_INSUMOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INGRESO_INSUMOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INGRESO_INSUMOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INGRESO_INSUMOS</c> table using
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
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_INGRESO_INSUMOS_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBUQUE_ID(decimal buque_id)
		{
			return DeleteByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBUQUE_ID(decimal buque_id, bool buque_idNull)
		{
			return CreateDeleteByBUQUE_IDCommand(buque_id, buque_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRESO_INSUMOS_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBUQUE_IDCommand(decimal buque_id, bool buque_idNull)
		{
			string whereSql = "";
			if(buque_idNull)
				whereSql += "BUQUE_ID IS NULL";
			else
				whereSql += "BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!buque_idNull)
				AddParameter(cmd, "BUQUE_ID", buque_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRESO_INSUMOS_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRESO_INSUMOS_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
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
		/// delete records using the <c>FK_INGRESO_INSUMOS_PERSONA_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS</c> table using the 
		/// <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
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
		/// delete records using the <c>FK_INGRESO_INSUMOS_SUCURSAL_ID</c> foreign key.
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
		/// Deletes <c>INGRESO_INSUMOS</c> records that match the specified criteria.
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
		/// to delete <c>INGRESO_INSUMOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INGRESO_INSUMOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INGRESO_INSUMOS</c> table.
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
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		protected INGRESO_INSUMOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		protected INGRESO_INSUMOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INGRESO_INSUMOSRow"/> objects.</returns>
		protected virtual INGRESO_INSUMOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int box_idColumnIndex = reader.GetOrdinal("BOX_ID");
			int tipo_ingresoColumnIndex = reader.GetOrdinal("TIPO_INGRESO");
			int facturaColumnIndex = reader.GetOrdinal("FACTURA");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int buque_idColumnIndex = reader.GetOrdinal("BUQUE_ID");
			int registroColumnIndex = reader.GetOrdinal("REGISTRO");
			int autorizacion_dnaColumnIndex = reader.GetOrdinal("AUTORIZACION_DNA");
			int transportistaColumnIndex = reader.GetOrdinal("TRANSPORTISTA");
			int mermaColumnIndex = reader.GetOrdinal("MERMA");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INGRESO_INSUMOSRow record = new INGRESO_INSUMOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(box_idColumnIndex))
						record.BOX_ID = Math.Round(Convert.ToDecimal(reader.GetValue(box_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_ingresoColumnIndex))
						record.TIPO_INGRESO = Convert.ToString(reader.GetValue(tipo_ingresoColumnIndex));
					if(!reader.IsDBNull(facturaColumnIndex))
						record.FACTURA = Convert.ToString(reader.GetValue(facturaColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(buque_idColumnIndex))
						record.BUQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(buque_idColumnIndex)), 9);
					if(!reader.IsDBNull(registroColumnIndex))
						record.REGISTRO = Convert.ToString(reader.GetValue(registroColumnIndex));
					if(!reader.IsDBNull(autorizacion_dnaColumnIndex))
						record.AUTORIZACION_DNA = Convert.ToString(reader.GetValue(autorizacion_dnaColumnIndex));
					if(!reader.IsDBNull(transportistaColumnIndex))
						record.TRANSPORTISTA = Convert.ToString(reader.GetValue(transportistaColumnIndex));
					if(!reader.IsDBNull(mermaColumnIndex))
						record.MERMA = Math.Round(Convert.ToDecimal(reader.GetValue(mermaColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INGRESO_INSUMOSRow[])(recordList.ToArray(typeof(INGRESO_INSUMOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INGRESO_INSUMOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INGRESO_INSUMOSRow"/> object.</returns>
		protected virtual INGRESO_INSUMOSRow MapRow(DataRow row)
		{
			INGRESO_INSUMOSRow mappedObject = new INGRESO_INSUMOSRow();
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
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "BOX_ID"
			dataColumn = dataTable.Columns["BOX_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOX_ID = (decimal)row[dataColumn];
			// Column "TIPO_INGRESO"
			dataColumn = dataTable.Columns["TIPO_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_INGRESO = (string)row[dataColumn];
			// Column "FACTURA"
			dataColumn = dataTable.Columns["FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA = (string)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "BUQUE_ID"
			dataColumn = dataTable.Columns["BUQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_ID = (decimal)row[dataColumn];
			// Column "REGISTRO"
			dataColumn = dataTable.Columns["REGISTRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO = (string)row[dataColumn];
			// Column "AUTORIZACION_DNA"
			dataColumn = dataTable.Columns["AUTORIZACION_DNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTORIZACION_DNA = (string)row[dataColumn];
			// Column "TRANSPORTISTA"
			dataColumn = dataTable.Columns["TRANSPORTISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTISTA = (string)row[dataColumn];
			// Column "MERMA"
			dataColumn = dataTable.Columns["MERMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERMA = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INGRESO_INSUMOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INGRESO_INSUMOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("BOX_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_INGRESO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("FACTURA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("BUQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REGISTRO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("AUTORIZACION_DNA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("TRANSPORTISTA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("MERMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "BOX_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGISTRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTORIZACION_DNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INGRESO_INSUMOSCollection_Base class
}  // End of namespace
