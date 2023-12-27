// <fileinfo name="TRANSFERENCIA_CAJAS_SUCURSALCollection_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIA_CAJAS_SUCURSALCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSFERENCIA_CAJAS_SUCURSALCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIA_CAJAS_SUCURSALCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CAJA_SUC_ORIGEN_IDColumnName = "CAJA_SUC_ORIGEN_ID";
		public const string CAJA_SUC_DES_IDColumnName = "CAJA_SUC_DES_ID";
		public const string FONDO_FIJO_ORIGEN_IDColumnName = "FONDO_FIJO_ORIGEN_ID";
		public const string FONDO_FIJO_DES_IDColumnName = "FONDO_FIJO_DES_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CAJA_TESO_ORIGEN_IDColumnName = "CAJA_TESO_ORIGEN_ID";
		public const string CAJA_TESO_DESTINO_IDColumnName = "CAJA_TESO_DESTINO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIA_CAJAS_SUCURSALCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSFERENCIA_CAJAS_SUCURSALCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSFERENCIA_CAJAS_SUCURSALRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSFERENCIA_CAJAS_SUCURSAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRANSFERENCIA_CAJAS_SUCURSALRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_SUC_DES_ID(decimal caja_suc_des_id)
		{
			return GetByCAJA_SUC_DES_ID(caja_suc_des_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <param name="caja_suc_des_idNull">true if the method ignores the caja_suc_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_SUC_DES_ID(decimal caja_suc_des_id, bool caja_suc_des_idNull)
		{
			return MapRecords(CreateGetByCAJA_SUC_DES_IDCommand(caja_suc_des_id, caja_suc_des_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAJA_SUC_DES_IDAsDataTable(decimal caja_suc_des_id)
		{
			return GetByCAJA_SUC_DES_IDAsDataTable(caja_suc_des_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <param name="caja_suc_des_idNull">true if the method ignores the caja_suc_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAJA_SUC_DES_IDAsDataTable(decimal caja_suc_des_id, bool caja_suc_des_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAJA_SUC_DES_IDCommand(caja_suc_des_id, caja_suc_des_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <param name="caja_suc_des_idNull">true if the method ignores the caja_suc_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAJA_SUC_DES_IDCommand(decimal caja_suc_des_id, bool caja_suc_des_idNull)
		{
			string whereSql = "";
			if(caja_suc_des_idNull)
				whereSql += "CAJA_SUC_DES_ID IS NULL";
			else
				whereSql += "CAJA_SUC_DES_ID=" + _db.CreateSqlParameterName("CAJA_SUC_DES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caja_suc_des_idNull)
				AddParameter(cmd, "CAJA_SUC_DES_ID", caja_suc_des_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_SUC_ORIGEN_ID(decimal caja_suc_origen_id)
		{
			return GetByCAJA_SUC_ORIGEN_ID(caja_suc_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_suc_origen_idNull">true if the method ignores the caja_suc_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_SUC_ORIGEN_ID(decimal caja_suc_origen_id, bool caja_suc_origen_idNull)
		{
			return MapRecords(CreateGetByCAJA_SUC_ORIGEN_IDCommand(caja_suc_origen_id, caja_suc_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAJA_SUC_ORIGEN_IDAsDataTable(decimal caja_suc_origen_id)
		{
			return GetByCAJA_SUC_ORIGEN_IDAsDataTable(caja_suc_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_suc_origen_idNull">true if the method ignores the caja_suc_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAJA_SUC_ORIGEN_IDAsDataTable(decimal caja_suc_origen_id, bool caja_suc_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAJA_SUC_ORIGEN_IDCommand(caja_suc_origen_id, caja_suc_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_suc_origen_idNull">true if the method ignores the caja_suc_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAJA_SUC_ORIGEN_IDCommand(decimal caja_suc_origen_id, bool caja_suc_origen_idNull)
		{
			string whereSql = "";
			if(caja_suc_origen_idNull)
				whereSql += "CAJA_SUC_ORIGEN_ID IS NULL";
			else
				whereSql += "CAJA_SUC_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_SUC_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caja_suc_origen_idNull)
				AddParameter(cmd, "CAJA_SUC_ORIGEN_ID", caja_suc_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_TESO_DESTINO_ID(decimal caja_teso_destino_id)
		{
			return GetByCAJA_TESO_DESTINO_ID(caja_teso_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="caja_teso_destino_idNull">true if the method ignores the caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_TESO_DESTINO_ID(decimal caja_teso_destino_id, bool caja_teso_destino_idNull)
		{
			return MapRecords(CreateGetByCAJA_TESO_DESTINO_IDCommand(caja_teso_destino_id, caja_teso_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAJA_TESO_DESTINO_IDAsDataTable(decimal caja_teso_destino_id)
		{
			return GetByCAJA_TESO_DESTINO_IDAsDataTable(caja_teso_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="caja_teso_destino_idNull">true if the method ignores the caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAJA_TESO_DESTINO_IDAsDataTable(decimal caja_teso_destino_id, bool caja_teso_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAJA_TESO_DESTINO_IDCommand(caja_teso_destino_id, caja_teso_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="caja_teso_destino_idNull">true if the method ignores the caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAJA_TESO_DESTINO_IDCommand(decimal caja_teso_destino_id, bool caja_teso_destino_idNull)
		{
			string whereSql = "";
			if(caja_teso_destino_idNull)
				whereSql += "CAJA_TESO_DESTINO_ID IS NULL";
			else
				whereSql += "CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CAJA_TESO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caja_teso_destino_idNull)
				AddParameter(cmd, "CAJA_TESO_DESTINO_ID", caja_teso_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_TESO_ORIGEN_ID(decimal caja_teso_origen_id)
		{
			return GetByCAJA_TESO_ORIGEN_ID(caja_teso_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_teso_origen_idNull">true if the method ignores the caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCAJA_TESO_ORIGEN_ID(decimal caja_teso_origen_id, bool caja_teso_origen_idNull)
		{
			return MapRecords(CreateGetByCAJA_TESO_ORIGEN_IDCommand(caja_teso_origen_id, caja_teso_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAJA_TESO_ORIGEN_IDAsDataTable(decimal caja_teso_origen_id)
		{
			return GetByCAJA_TESO_ORIGEN_IDAsDataTable(caja_teso_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_teso_origen_idNull">true if the method ignores the caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAJA_TESO_ORIGEN_IDAsDataTable(decimal caja_teso_origen_id, bool caja_teso_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAJA_TESO_ORIGEN_IDCommand(caja_teso_origen_id, caja_teso_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_teso_origen_idNull">true if the method ignores the caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAJA_TESO_ORIGEN_IDCommand(decimal caja_teso_origen_id, bool caja_teso_origen_idNull)
		{
			string whereSql = "";
			if(caja_teso_origen_idNull)
				whereSql += "CAJA_TESO_ORIGEN_ID IS NULL";
			else
				whereSql += "CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_TESO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caja_teso_origen_idNull)
				AddParameter(cmd, "CAJA_TESO_ORIGEN_ID", caja_teso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_CASO</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByFONDO_FIJO_DES_ID(decimal fondo_fijo_des_id)
		{
			return GetByFONDO_FIJO_DES_ID(fondo_fijo_des_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <param name="fondo_fijo_des_idNull">true if the method ignores the fondo_fijo_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByFONDO_FIJO_DES_ID(decimal fondo_fijo_des_id, bool fondo_fijo_des_idNull)
		{
			return MapRecords(CreateGetByFONDO_FIJO_DES_IDCommand(fondo_fijo_des_id, fondo_fijo_des_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFONDO_FIJO_DES_IDAsDataTable(decimal fondo_fijo_des_id)
		{
			return GetByFONDO_FIJO_DES_IDAsDataTable(fondo_fijo_des_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <param name="fondo_fijo_des_idNull">true if the method ignores the fondo_fijo_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFONDO_FIJO_DES_IDAsDataTable(decimal fondo_fijo_des_id, bool fondo_fijo_des_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFONDO_FIJO_DES_IDCommand(fondo_fijo_des_id, fondo_fijo_des_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <param name="fondo_fijo_des_idNull">true if the method ignores the fondo_fijo_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFONDO_FIJO_DES_IDCommand(decimal fondo_fijo_des_id, bool fondo_fijo_des_idNull)
		{
			string whereSql = "";
			if(fondo_fijo_des_idNull)
				whereSql += "FONDO_FIJO_DES_ID IS NULL";
			else
				whereSql += "FONDO_FIJO_DES_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_DES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fondo_fijo_des_idNull)
				AddParameter(cmd, "FONDO_FIJO_DES_ID", fondo_fijo_des_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByFONDO_FIJO_ORIGEN_ID(decimal fondo_fijo_origen_id)
		{
			return GetByFONDO_FIJO_ORIGEN_ID(fondo_fijo_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <param name="fondo_fijo_origen_idNull">true if the method ignores the fondo_fijo_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByFONDO_FIJO_ORIGEN_ID(decimal fondo_fijo_origen_id, bool fondo_fijo_origen_idNull)
		{
			return MapRecords(CreateGetByFONDO_FIJO_ORIGEN_IDCommand(fondo_fijo_origen_id, fondo_fijo_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFONDO_FIJO_ORIGEN_IDAsDataTable(decimal fondo_fijo_origen_id)
		{
			return GetByFONDO_FIJO_ORIGEN_IDAsDataTable(fondo_fijo_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <param name="fondo_fijo_origen_idNull">true if the method ignores the fondo_fijo_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFONDO_FIJO_ORIGEN_IDAsDataTable(decimal fondo_fijo_origen_id, bool fondo_fijo_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFONDO_FIJO_ORIGEN_IDCommand(fondo_fijo_origen_id, fondo_fijo_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <param name="fondo_fijo_origen_idNull">true if the method ignores the fondo_fijo_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFONDO_FIJO_ORIGEN_IDCommand(decimal fondo_fijo_origen_id, bool fondo_fijo_origen_idNull)
		{
			string whereSql = "";
			if(fondo_fijo_origen_idNull)
				whereSql += "FONDO_FIJO_ORIGEN_ID IS NULL";
			else
				whereSql += "FONDO_FIJO_ORIGEN_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fondo_fijo_origen_idNull)
				AddParameter(cmd, "FONDO_FIJO_ORIGEN_ID", fondo_fijo_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_SUC_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_SUC_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_SUC_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_SUC_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_SUC_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_SUC_SUC_ORIG</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
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
		/// return records by the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_TRANSF_CAJAS_SUC_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSF_CAJAS_SUC_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSF_CAJAS_SUC_USUARIO</c> foreign key.
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
		/// Adds a new record into the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSFERENCIA_CAJAS_SUCURSALRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSFERENCIA_CAJAS_SUCURSAL (" +
				"ID, " +
				"CASO_ID, " +
				"CAJA_SUC_ORIGEN_ID, " +
				"CAJA_SUC_DES_ID, " +
				"FONDO_FIJO_ORIGEN_ID, " +
				"FONDO_FIJO_DES_ID, " +
				"FECHA, " +
				"USUARIO_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"SUCURSAL_DESTINO_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"CAJA_TESO_ORIGEN_ID, " +
				"CAJA_TESO_DESTINO_ID, " +
				"OBSERVACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("CAJA_SUC_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CAJA_SUC_DES_ID") + ", " +
				_db.CreateSqlParameterName("FONDO_FIJO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("FONDO_FIJO_DES_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("CAJA_TESO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CAJA_TESO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CAJA_SUC_ORIGEN_ID",
				value.IsCAJA_SUC_ORIGEN_IDNull ? DBNull.Value : (object)value.CAJA_SUC_ORIGEN_ID);
			AddParameter(cmd, "CAJA_SUC_DES_ID",
				value.IsCAJA_SUC_DES_IDNull ? DBNull.Value : (object)value.CAJA_SUC_DES_ID);
			AddParameter(cmd, "FONDO_FIJO_ORIGEN_ID",
				value.IsFONDO_FIJO_ORIGEN_IDNull ? DBNull.Value : (object)value.FONDO_FIJO_ORIGEN_ID);
			AddParameter(cmd, "FONDO_FIJO_DES_ID",
				value.IsFONDO_FIJO_DES_IDNull ? DBNull.Value : (object)value.FONDO_FIJO_DES_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CAJA_TESO_ORIGEN_ID",
				value.IsCAJA_TESO_ORIGEN_IDNull ? DBNull.Value : (object)value.CAJA_TESO_ORIGEN_ID);
			AddParameter(cmd, "CAJA_TESO_DESTINO_ID",
				value.IsCAJA_TESO_DESTINO_IDNull ? DBNull.Value : (object)value.CAJA_TESO_DESTINO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSFERENCIA_CAJAS_SUCURSALRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSFERENCIA_CAJAS_SUCURSAL SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"CAJA_SUC_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_SUC_ORIGEN_ID") + ", " +
				"CAJA_SUC_DES_ID=" + _db.CreateSqlParameterName("CAJA_SUC_DES_ID") + ", " +
				"FONDO_FIJO_ORIGEN_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_ORIGEN_ID") + ", " +
				"FONDO_FIJO_DES_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_DES_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_TESO_ORIGEN_ID") + ", " +
				"CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CAJA_TESO_DESTINO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CAJA_SUC_ORIGEN_ID",
				value.IsCAJA_SUC_ORIGEN_IDNull ? DBNull.Value : (object)value.CAJA_SUC_ORIGEN_ID);
			AddParameter(cmd, "CAJA_SUC_DES_ID",
				value.IsCAJA_SUC_DES_IDNull ? DBNull.Value : (object)value.CAJA_SUC_DES_ID);
			AddParameter(cmd, "FONDO_FIJO_ORIGEN_ID",
				value.IsFONDO_FIJO_ORIGEN_IDNull ? DBNull.Value : (object)value.FONDO_FIJO_ORIGEN_ID);
			AddParameter(cmd, "FONDO_FIJO_DES_ID",
				value.IsFONDO_FIJO_DES_IDNull ? DBNull.Value : (object)value.FONDO_FIJO_DES_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CAJA_TESO_ORIGEN_ID",
				value.IsCAJA_TESO_ORIGEN_IDNull ? DBNull.Value : (object)value.CAJA_TESO_ORIGEN_ID);
			AddParameter(cmd, "CAJA_TESO_DESTINO_ID",
				value.IsCAJA_TESO_DESTINO_IDNull ? DBNull.Value : (object)value.CAJA_TESO_DESTINO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSFERENCIA_CAJAS_SUCURSALRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using
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
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_SUC_DES_ID(decimal caja_suc_des_id)
		{
			return DeleteByCAJA_SUC_DES_ID(caja_suc_des_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <param name="caja_suc_des_idNull">true if the method ignores the caja_suc_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_SUC_DES_ID(decimal caja_suc_des_id, bool caja_suc_des_idNull)
		{
			return CreateDeleteByCAJA_SUC_DES_IDCommand(caja_suc_des_id, caja_suc_des_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_CAJA_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_des_id">The <c>CAJA_SUC_DES_ID</c> column value.</param>
		/// <param name="caja_suc_des_idNull">true if the method ignores the caja_suc_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAJA_SUC_DES_IDCommand(decimal caja_suc_des_id, bool caja_suc_des_idNull)
		{
			string whereSql = "";
			if(caja_suc_des_idNull)
				whereSql += "CAJA_SUC_DES_ID IS NULL";
			else
				whereSql += "CAJA_SUC_DES_ID=" + _db.CreateSqlParameterName("CAJA_SUC_DES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caja_suc_des_idNull)
				AddParameter(cmd, "CAJA_SUC_DES_ID", caja_suc_des_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_SUC_ORIGEN_ID(decimal caja_suc_origen_id)
		{
			return DeleteByCAJA_SUC_ORIGEN_ID(caja_suc_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_suc_origen_idNull">true if the method ignores the caja_suc_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_SUC_ORIGEN_ID(decimal caja_suc_origen_id, bool caja_suc_origen_idNull)
		{
			return CreateDeleteByCAJA_SUC_ORIGEN_IDCommand(caja_suc_origen_id, caja_suc_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_CAJA_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_suc_origen_id">The <c>CAJA_SUC_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_suc_origen_idNull">true if the method ignores the caja_suc_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAJA_SUC_ORIGEN_IDCommand(decimal caja_suc_origen_id, bool caja_suc_origen_idNull)
		{
			string whereSql = "";
			if(caja_suc_origen_idNull)
				whereSql += "CAJA_SUC_ORIGEN_ID IS NULL";
			else
				whereSql += "CAJA_SUC_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_SUC_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caja_suc_origen_idNull)
				AddParameter(cmd, "CAJA_SUC_ORIGEN_ID", caja_suc_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_TESO_DESTINO_ID(decimal caja_teso_destino_id)
		{
			return DeleteByCAJA_TESO_DESTINO_ID(caja_teso_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="caja_teso_destino_idNull">true if the method ignores the caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_TESO_DESTINO_ID(decimal caja_teso_destino_id, bool caja_teso_destino_idNull)
		{
			return CreateDeleteByCAJA_TESO_DESTINO_IDCommand(caja_teso_destino_id, caja_teso_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_CAJA_TESO_DEST</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_destino_id">The <c>CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="caja_teso_destino_idNull">true if the method ignores the caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAJA_TESO_DESTINO_IDCommand(decimal caja_teso_destino_id, bool caja_teso_destino_idNull)
		{
			string whereSql = "";
			if(caja_teso_destino_idNull)
				whereSql += "CAJA_TESO_DESTINO_ID IS NULL";
			else
				whereSql += "CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CAJA_TESO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caja_teso_destino_idNull)
				AddParameter(cmd, "CAJA_TESO_DESTINO_ID", caja_teso_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_TESO_ORIGEN_ID(decimal caja_teso_origen_id)
		{
			return DeleteByCAJA_TESO_ORIGEN_ID(caja_teso_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_teso_origen_idNull">true if the method ignores the caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAJA_TESO_ORIGEN_ID(decimal caja_teso_origen_id, bool caja_teso_origen_idNull)
		{
			return CreateDeleteByCAJA_TESO_ORIGEN_IDCommand(caja_teso_origen_id, caja_teso_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_CAJA_TESO_ORI</c> foreign key.
		/// </summary>
		/// <param name="caja_teso_origen_id">The <c>CAJA_TESO_ORIGEN_ID</c> column value.</param>
		/// <param name="caja_teso_origen_idNull">true if the method ignores the caja_teso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAJA_TESO_ORIGEN_IDCommand(decimal caja_teso_origen_id, bool caja_teso_origen_idNull)
		{
			string whereSql = "";
			if(caja_teso_origen_idNull)
				whereSql += "CAJA_TESO_ORIGEN_ID IS NULL";
			else
				whereSql += "CAJA_TESO_ORIGEN_ID=" + _db.CreateSqlParameterName("CAJA_TESO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caja_teso_origen_idNull)
				AddParameter(cmd, "CAJA_TESO_ORIGEN_ID", caja_teso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_CASO</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFONDO_FIJO_DES_ID(decimal fondo_fijo_des_id)
		{
			return DeleteByFONDO_FIJO_DES_ID(fondo_fijo_des_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <param name="fondo_fijo_des_idNull">true if the method ignores the fondo_fijo_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFONDO_FIJO_DES_ID(decimal fondo_fijo_des_id, bool fondo_fijo_des_idNull)
		{
			return CreateDeleteByFONDO_FIJO_DES_IDCommand(fondo_fijo_des_id, fondo_fijo_des_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_FONDO_FIJO_DES</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_des_id">The <c>FONDO_FIJO_DES_ID</c> column value.</param>
		/// <param name="fondo_fijo_des_idNull">true if the method ignores the fondo_fijo_des_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFONDO_FIJO_DES_IDCommand(decimal fondo_fijo_des_id, bool fondo_fijo_des_idNull)
		{
			string whereSql = "";
			if(fondo_fijo_des_idNull)
				whereSql += "FONDO_FIJO_DES_ID IS NULL";
			else
				whereSql += "FONDO_FIJO_DES_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_DES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fondo_fijo_des_idNull)
				AddParameter(cmd, "FONDO_FIJO_DES_ID", fondo_fijo_des_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFONDO_FIJO_ORIGEN_ID(decimal fondo_fijo_origen_id)
		{
			return DeleteByFONDO_FIJO_ORIGEN_ID(fondo_fijo_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <param name="fondo_fijo_origen_idNull">true if the method ignores the fondo_fijo_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFONDO_FIJO_ORIGEN_ID(decimal fondo_fijo_origen_id, bool fondo_fijo_origen_idNull)
		{
			return CreateDeleteByFONDO_FIJO_ORIGEN_IDCommand(fondo_fijo_origen_id, fondo_fijo_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_FONDO_FIJO_ORI</c> foreign key.
		/// </summary>
		/// <param name="fondo_fijo_origen_id">The <c>FONDO_FIJO_ORIGEN_ID</c> column value.</param>
		/// <param name="fondo_fijo_origen_idNull">true if the method ignores the fondo_fijo_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFONDO_FIJO_ORIGEN_IDCommand(decimal fondo_fijo_origen_id, bool fondo_fijo_origen_idNull)
		{
			string whereSql = "";
			if(fondo_fijo_origen_idNull)
				whereSql += "FONDO_FIJO_ORIGEN_ID IS NULL";
			else
				whereSql += "FONDO_FIJO_ORIGEN_ID=" + _db.CreateSqlParameterName("FONDO_FIJO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fondo_fijo_origen_idNull)
				AddParameter(cmd, "FONDO_FIJO_ORIGEN_ID", fondo_fijo_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_SUC_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return CreateDeleteBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_SUC_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_SUC_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_SUC_SUC_ORIG</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
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
		/// delete records using the <c>FK_TRANSF_CAJAS_SUC_TEX_PRED</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_TRANSF_CAJAS_SUC_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSF_CAJAS_SUC_USUARIO</c> foreign key.
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
		/// Deletes <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> records that match the specified criteria.
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
		/// to delete <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSFERENCIA_CAJAS_SUCURSAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		protected TRANSFERENCIA_CAJAS_SUCURSALRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		protected TRANSFERENCIA_CAJAS_SUCURSALRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> objects.</returns>
		protected virtual TRANSFERENCIA_CAJAS_SUCURSALRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caja_suc_origen_idColumnIndex = reader.GetOrdinal("CAJA_SUC_ORIGEN_ID");
			int caja_suc_des_idColumnIndex = reader.GetOrdinal("CAJA_SUC_DES_ID");
			int fondo_fijo_origen_idColumnIndex = reader.GetOrdinal("FONDO_FIJO_ORIGEN_ID");
			int fondo_fijo_des_idColumnIndex = reader.GetOrdinal("FONDO_FIJO_DES_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int caja_teso_origen_idColumnIndex = reader.GetOrdinal("CAJA_TESO_ORIGEN_ID");
			int caja_teso_destino_idColumnIndex = reader.GetOrdinal("CAJA_TESO_DESTINO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSFERENCIA_CAJAS_SUCURSALRow record = new TRANSFERENCIA_CAJAS_SUCURSALRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_suc_origen_idColumnIndex))
						record.CAJA_SUC_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_suc_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_suc_des_idColumnIndex))
						record.CAJA_SUC_DES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_suc_des_idColumnIndex)), 9);
					if(!reader.IsDBNull(fondo_fijo_origen_idColumnIndex))
						record.FONDO_FIJO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijo_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(fondo_fijo_des_idColumnIndex))
						record.FONDO_FIJO_DES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijo_des_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_teso_origen_idColumnIndex))
						record.CAJA_TESO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_teso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_teso_destino_idColumnIndex))
						record.CAJA_TESO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_teso_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSFERENCIA_CAJAS_SUCURSALRow[])(recordList.ToArray(typeof(TRANSFERENCIA_CAJAS_SUCURSALRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSFERENCIA_CAJAS_SUCURSALRow"/> object.</returns>
		protected virtual TRANSFERENCIA_CAJAS_SUCURSALRow MapRow(DataRow row)
		{
			TRANSFERENCIA_CAJAS_SUCURSALRow mappedObject = new TRANSFERENCIA_CAJAS_SUCURSALRow();
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
			// Column "CAJA_SUC_ORIGEN_ID"
			dataColumn = dataTable.Columns["CAJA_SUC_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CAJA_SUC_DES_ID"
			dataColumn = dataTable.Columns["CAJA_SUC_DES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_DES_ID = (decimal)row[dataColumn];
			// Column "FONDO_FIJO_ORIGEN_ID"
			dataColumn = dataTable.Columns["FONDO_FIJO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "FONDO_FIJO_DES_ID"
			dataColumn = dataTable.Columns["FONDO_FIJO_DES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_DES_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CAJA_TESO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESO_DESTINO_ID"
			dataColumn = dataTable.Columns["CAJA_TESO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSFERENCIA_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSFERENCIA_CAJAS_SUCURSAL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAJA_SUC_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CAJA_SUC_DES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_DES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CAJA_TESO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CAJA_TESO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
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

				case "CAJA_SUC_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_SUC_DES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO_DES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSFERENCIA_CAJAS_SUCURSALCollection_Base class
}  // End of namespace
