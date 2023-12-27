// <fileinfo name="STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSFERENCIA_BALANCEADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_TRANSFERENCIA_BALANCEADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string FECHAColumnName = "FECHA";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string FUNCIONARIO_CHOFER_IDColumnName = "FUNCIONARIO_CHOFER_ID";
		public const string ACOMPANANTE1_IDColumnName = "ACOMPANANTE1_ID";
		public const string ACOMPANANTE2_IDColumnName = "ACOMPANANTE2_ID";
		public const string ACOMPANANTE3_IDColumnName = "ACOMPANANTE3_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string COMPROBANTEColumnName = "COMPROBANTE";
		public const string ES_CASO_ORIGINALColumnName = "ES_CASO_ORIGINAL";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string COSTO_TRANSFERENCIAColumnName = "COSTO_TRANSFERENCIA";
		public const string COSTO_ASOCIADOColumnName = "COSTO_ASOCIADO";
		public const string TOTAL_COSTOColumnName = "TOTAL_COSTO";
		public const string REMISION_EXTERNAColumnName = "REMISION_EXTERNA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string VEHICULO_MATRICULAColumnName = "VEHICULO_MATRICULA";
		public const string VEHICULO_MARCAColumnName = "VEHICULO_MARCA";
		public const string REMISION_AUTONUMERACION_IDColumnName = "REMISION_AUTONUMERACION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_TRANSFERENCIA_BALANCEADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_TRANSFERENCIA_BALANCEADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_TRANSFERENCIA_BALANCEADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE1_ID(decimal acompanante1_id)
		{
			return GetByACOMPANANTE1_ID(acompanante1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <param name="acompanante1_idNull">true if the method ignores the acompanante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE1_ID(decimal acompanante1_id, bool acompanante1_idNull)
		{
			return MapRecords(CreateGetByACOMPANANTE1_IDCommand(acompanante1_id, acompanante1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACOMPANANTE1_IDAsDataTable(decimal acompanante1_id)
		{
			return GetByACOMPANANTE1_IDAsDataTable(acompanante1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <param name="acompanante1_idNull">true if the method ignores the acompanante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACOMPANANTE1_IDAsDataTable(decimal acompanante1_id, bool acompanante1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACOMPANANTE1_IDCommand(acompanante1_id, acompanante1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <param name="acompanante1_idNull">true if the method ignores the acompanante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACOMPANANTE1_IDCommand(decimal acompanante1_id, bool acompanante1_idNull)
		{
			string whereSql = "";
			if(acompanante1_idNull)
				whereSql += "ACOMPANANTE1_ID IS NULL";
			else
				whereSql += "ACOMPANANTE1_ID=" + _db.CreateSqlParameterName("ACOMPANANTE1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!acompanante1_idNull)
				AddParameter(cmd, "ACOMPANANTE1_ID", acompanante1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE2_ID(decimal acompanante2_id)
		{
			return GetByACOMPANANTE2_ID(acompanante2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <param name="acompanante2_idNull">true if the method ignores the acompanante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE2_ID(decimal acompanante2_id, bool acompanante2_idNull)
		{
			return MapRecords(CreateGetByACOMPANANTE2_IDCommand(acompanante2_id, acompanante2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACOMPANANTE2_IDAsDataTable(decimal acompanante2_id)
		{
			return GetByACOMPANANTE2_IDAsDataTable(acompanante2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <param name="acompanante2_idNull">true if the method ignores the acompanante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACOMPANANTE2_IDAsDataTable(decimal acompanante2_id, bool acompanante2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACOMPANANTE2_IDCommand(acompanante2_id, acompanante2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <param name="acompanante2_idNull">true if the method ignores the acompanante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACOMPANANTE2_IDCommand(decimal acompanante2_id, bool acompanante2_idNull)
		{
			string whereSql = "";
			if(acompanante2_idNull)
				whereSql += "ACOMPANANTE2_ID IS NULL";
			else
				whereSql += "ACOMPANANTE2_ID=" + _db.CreateSqlParameterName("ACOMPANANTE2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!acompanante2_idNull)
				AddParameter(cmd, "ACOMPANANTE2_ID", acompanante2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE3_ID(decimal acompanante3_id)
		{
			return GetByACOMPANANTE3_ID(acompanante3_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <param name="acompanante3_idNull">true if the method ignores the acompanante3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByACOMPANANTE3_ID(decimal acompanante3_id, bool acompanante3_idNull)
		{
			return MapRecords(CreateGetByACOMPANANTE3_IDCommand(acompanante3_id, acompanante3_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACOMPANANTE3_IDAsDataTable(decimal acompanante3_id)
		{
			return GetByACOMPANANTE3_IDAsDataTable(acompanante3_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <param name="acompanante3_idNull">true if the method ignores the acompanante3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACOMPANANTE3_IDAsDataTable(decimal acompanante3_id, bool acompanante3_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACOMPANANTE3_IDCommand(acompanante3_id, acompanante3_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <param name="acompanante3_idNull">true if the method ignores the acompanante3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACOMPANANTE3_IDCommand(decimal acompanante3_id, bool acompanante3_idNull)
		{
			string whereSql = "";
			if(acompanante3_idNull)
				whereSql += "ACOMPANANTE3_ID IS NULL";
			else
				whereSql += "ACOMPANANTE3_ID=" + _db.CreateSqlParameterName("ACOMPANANTE3_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!acompanante3_idNull)
				AddParameter(cmd, "ACOMPANANTE3_ID", acompanante3_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_IDAsDataTable(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
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
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByREMISION_AUTONUMERACION_ID(decimal remision_autonumeracion_id)
		{
			return GetByREMISION_AUTONUMERACION_ID(remision_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="remision_autonumeracion_idNull">true if the method ignores the remision_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByREMISION_AUTONUMERACION_ID(decimal remision_autonumeracion_id, bool remision_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByREMISION_AUTONUMERACION_IDCommand(remision_autonumeracion_id, remision_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREMISION_AUTONUMERACION_IDAsDataTable(decimal remision_autonumeracion_id)
		{
			return GetByREMISION_AUTONUMERACION_IDAsDataTable(remision_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="remision_autonumeracion_idNull">true if the method ignores the remision_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREMISION_AUTONUMERACION_IDAsDataTable(decimal remision_autonumeracion_id, bool remision_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREMISION_AUTONUMERACION_IDCommand(remision_autonumeracion_id, remision_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="remision_autonumeracion_idNull">true if the method ignores the remision_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREMISION_AUTONUMERACION_IDCommand(decimal remision_autonumeracion_id, bool remision_autonumeracion_idNull)
		{
			string whereSql = "";
			if(remision_autonumeracion_idNull)
				whereSql += "REMISION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "REMISION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("REMISION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!remision_autonumeracion_idNull)
				AddParameter(cmd, "REMISION_AUTONUMERACION_ID", remision_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_SUC_ORIG</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
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
		/// return records by the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
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
		/// Adds a new record into the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_TRANSFERENCIA_BALANCEADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_TRANSFERENCIA_BALANCEADOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"FECHA, " +
				"VEHICULO_ID, " +
				"FUNCIONARIO_CHOFER_ID, " +
				"ACOMPANANTE1_ID, " +
				"ACOMPANANTE2_ID, " +
				"ACOMPANANTE3_ID, " +
				"AUTONUMERACION_ID, " +
				"COMPROBANTE, " +
				"ES_CASO_ORIGINAL, " +
				"CASO_ASOCIADO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"COSTO_TRANSFERENCIA, " +
				"COSTO_ASOCIADO, " +
				"TOTAL_COSTO, " +
				"REMISION_EXTERNA, " +
				"OBSERVACION, " +
				"PROVEEDOR_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"CHOFER_NOMBRE, " +
				"IMPRESO, " +
				"VEHICULO_MATRICULA, " +
				"VEHICULO_MARCA, " +
				"REMISION_AUTONUMERACION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				_db.CreateSqlParameterName("ACOMPANANTE1_ID") + ", " +
				_db.CreateSqlParameterName("ACOMPANANTE2_ID") + ", " +
				_db.CreateSqlParameterName("ACOMPANANTE3_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("ES_CASO_ORIGINAL") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("COSTO_TRANSFERENCIA") + ", " +
				_db.CreateSqlParameterName("COSTO_ASOCIADO") + ", " +
				_db.CreateSqlParameterName("TOTAL_COSTO") + ", " +
				_db.CreateSqlParameterName("REMISION_EXTERNA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("IMPRESO") + ", " +
				_db.CreateSqlParameterName("VEHICULO_MATRICULA") + ", " +
				_db.CreateSqlParameterName("VEHICULO_MARCA") + ", " +
				_db.CreateSqlParameterName("REMISION_AUTONUMERACION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "ACOMPANANTE1_ID",
				value.IsACOMPANANTE1_IDNull ? DBNull.Value : (object)value.ACOMPANANTE1_ID);
			AddParameter(cmd, "ACOMPANANTE2_ID",
				value.IsACOMPANANTE2_IDNull ? DBNull.Value : (object)value.ACOMPANANTE2_ID);
			AddParameter(cmd, "ACOMPANANTE3_ID",
				value.IsACOMPANANTE3_IDNull ? DBNull.Value : (object)value.ACOMPANANTE3_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "ES_CASO_ORIGINAL", value.ES_CASO_ORIGINAL);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "COSTO_TRANSFERENCIA",
				value.IsCOSTO_TRANSFERENCIANull ? DBNull.Value : (object)value.COSTO_TRANSFERENCIA);
			AddParameter(cmd, "COSTO_ASOCIADO",
				value.IsCOSTO_ASOCIADONull ? DBNull.Value : (object)value.COSTO_ASOCIADO);
			AddParameter(cmd, "TOTAL_COSTO",
				value.IsTOTAL_COSTONull ? DBNull.Value : (object)value.TOTAL_COSTO);
			AddParameter(cmd, "REMISION_EXTERNA", value.REMISION_EXTERNA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "VEHICULO_MATRICULA", value.VEHICULO_MATRICULA);
			AddParameter(cmd, "VEHICULO_MARCA", value.VEHICULO_MARCA);
			AddParameter(cmd, "REMISION_AUTONUMERACION_ID",
				value.IsREMISION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.REMISION_AUTONUMERACION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_TRANSFERENCIA_BALANCEADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_TRANSFERENCIA_BALANCEADOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				"FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				"ACOMPANANTE1_ID=" + _db.CreateSqlParameterName("ACOMPANANTE1_ID") + ", " +
				"ACOMPANANTE2_ID=" + _db.CreateSqlParameterName("ACOMPANANTE2_ID") + ", " +
				"ACOMPANANTE3_ID=" + _db.CreateSqlParameterName("ACOMPANANTE3_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"COMPROBANTE=" + _db.CreateSqlParameterName("COMPROBANTE") + ", " +
				"ES_CASO_ORIGINAL=" + _db.CreateSqlParameterName("ES_CASO_ORIGINAL") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"COSTO_TRANSFERENCIA=" + _db.CreateSqlParameterName("COSTO_TRANSFERENCIA") + ", " +
				"COSTO_ASOCIADO=" + _db.CreateSqlParameterName("COSTO_ASOCIADO") + ", " +
				"TOTAL_COSTO=" + _db.CreateSqlParameterName("TOTAL_COSTO") + ", " +
				"REMISION_EXTERNA=" + _db.CreateSqlParameterName("REMISION_EXTERNA") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"IMPRESO=" + _db.CreateSqlParameterName("IMPRESO") + ", " +
				"VEHICULO_MATRICULA=" + _db.CreateSqlParameterName("VEHICULO_MATRICULA") + ", " +
				"VEHICULO_MARCA=" + _db.CreateSqlParameterName("VEHICULO_MARCA") + ", " +
				"REMISION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("REMISION_AUTONUMERACION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "ACOMPANANTE1_ID",
				value.IsACOMPANANTE1_IDNull ? DBNull.Value : (object)value.ACOMPANANTE1_ID);
			AddParameter(cmd, "ACOMPANANTE2_ID",
				value.IsACOMPANANTE2_IDNull ? DBNull.Value : (object)value.ACOMPANANTE2_ID);
			AddParameter(cmd, "ACOMPANANTE3_ID",
				value.IsACOMPANANTE3_IDNull ? DBNull.Value : (object)value.ACOMPANANTE3_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "ES_CASO_ORIGINAL", value.ES_CASO_ORIGINAL);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "COSTO_TRANSFERENCIA",
				value.IsCOSTO_TRANSFERENCIANull ? DBNull.Value : (object)value.COSTO_TRANSFERENCIA);
			AddParameter(cmd, "COSTO_ASOCIADO",
				value.IsCOSTO_ASOCIADONull ? DBNull.Value : (object)value.COSTO_ASOCIADO);
			AddParameter(cmd, "TOTAL_COSTO",
				value.IsTOTAL_COSTONull ? DBNull.Value : (object)value.TOTAL_COSTO);
			AddParameter(cmd, "REMISION_EXTERNA", value.REMISION_EXTERNA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "VEHICULO_MATRICULA", value.VEHICULO_MATRICULA);
			AddParameter(cmd, "VEHICULO_MARCA", value.VEHICULO_MARCA);
			AddParameter(cmd, "REMISION_AUTONUMERACION_ID",
				value.IsREMISION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.REMISION_AUTONUMERACION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_TRANSFERENCIA_BALANCEADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_CASO_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE1_ID(decimal acompanante1_id)
		{
			return DeleteByACOMPANANTE1_ID(acompanante1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <param name="acompanante1_idNull">true if the method ignores the acompanante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE1_ID(decimal acompanante1_id, bool acompanante1_idNull)
		{
			return CreateDeleteByACOMPANANTE1_IDCommand(acompanante1_id, acompanante1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO1</c> foreign key.
		/// </summary>
		/// <param name="acompanante1_id">The <c>ACOMPANANTE1_ID</c> column value.</param>
		/// <param name="acompanante1_idNull">true if the method ignores the acompanante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACOMPANANTE1_IDCommand(decimal acompanante1_id, bool acompanante1_idNull)
		{
			string whereSql = "";
			if(acompanante1_idNull)
				whereSql += "ACOMPANANTE1_ID IS NULL";
			else
				whereSql += "ACOMPANANTE1_ID=" + _db.CreateSqlParameterName("ACOMPANANTE1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!acompanante1_idNull)
				AddParameter(cmd, "ACOMPANANTE1_ID", acompanante1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE2_ID(decimal acompanante2_id)
		{
			return DeleteByACOMPANANTE2_ID(acompanante2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <param name="acompanante2_idNull">true if the method ignores the acompanante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE2_ID(decimal acompanante2_id, bool acompanante2_idNull)
		{
			return CreateDeleteByACOMPANANTE2_IDCommand(acompanante2_id, acompanante2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO2</c> foreign key.
		/// </summary>
		/// <param name="acompanante2_id">The <c>ACOMPANANTE2_ID</c> column value.</param>
		/// <param name="acompanante2_idNull">true if the method ignores the acompanante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACOMPANANTE2_IDCommand(decimal acompanante2_id, bool acompanante2_idNull)
		{
			string whereSql = "";
			if(acompanante2_idNull)
				whereSql += "ACOMPANANTE2_ID IS NULL";
			else
				whereSql += "ACOMPANANTE2_ID=" + _db.CreateSqlParameterName("ACOMPANANTE2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!acompanante2_idNull)
				AddParameter(cmd, "ACOMPANANTE2_ID", acompanante2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE3_ID(decimal acompanante3_id)
		{
			return DeleteByACOMPANANTE3_ID(acompanante3_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <param name="acompanante3_idNull">true if the method ignores the acompanante3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACOMPANANTE3_ID(decimal acompanante3_id, bool acompanante3_idNull)
		{
			return CreateDeleteByACOMPANANTE3_IDCommand(acompanante3_id, acompanante3_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_FUNC_ACO3</c> foreign key.
		/// </summary>
		/// <param name="acompanante3_id">The <c>ACOMPANANTE3_ID</c> column value.</param>
		/// <param name="acompanante3_idNull">true if the method ignores the acompanante3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACOMPANANTE3_IDCommand(decimal acompanante3_id, bool acompanante3_idNull)
		{
			string whereSql = "";
			if(acompanante3_idNull)
				whereSql += "ACOMPANANTE3_ID IS NULL";
			else
				whereSql += "ACOMPANANTE3_ID=" + _db.CreateSqlParameterName("ACOMPANANTE3_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!acompanante3_idNull)
				AddParameter(cmd, "ACOMPANANTE3_ID", acompanante3_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return DeleteByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_FUNC_CHOF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_PROV_ID</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREMISION_AUTONUMERACION_ID(decimal remision_autonumeracion_id)
		{
			return DeleteByREMISION_AUTONUMERACION_ID(remision_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="remision_autonumeracion_idNull">true if the method ignores the remision_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREMISION_AUTONUMERACION_ID(decimal remision_autonumeracion_id, bool remision_autonumeracion_idNull)
		{
			return CreateDeleteByREMISION_AUTONUMERACION_IDCommand(remision_autonumeracion_id, remision_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_REM_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="remision_autonumeracion_id">The <c>REMISION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="remision_autonumeracion_idNull">true if the method ignores the remision_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREMISION_AUTONUMERACION_IDCommand(decimal remision_autonumeracion_id, bool remision_autonumeracion_idNull)
		{
			string whereSql = "";
			if(remision_autonumeracion_idNull)
				whereSql += "REMISION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "REMISION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("REMISION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!remision_autonumeracion_idNull)
				AddParameter(cmd, "REMISION_AUTONUMERACION_ID", remision_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_SUC_ORIG</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_SUC_ORIG</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table using the 
		/// <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_TRANSF_BALAN_TEXTO_PREDEF_ID</c> foreign key.
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
		/// Deletes <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_TRANSFERENCIA_BALANCEADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_BALANCEADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_BALANCEADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> objects.</returns>
		protected virtual STOCK_TRANSFERENCIA_BALANCEADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int funcionario_chofer_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_ID");
			int acompanante1_idColumnIndex = reader.GetOrdinal("ACOMPANANTE1_ID");
			int acompanante2_idColumnIndex = reader.GetOrdinal("ACOMPANANTE2_ID");
			int acompanante3_idColumnIndex = reader.GetOrdinal("ACOMPANANTE3_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int comprobanteColumnIndex = reader.GetOrdinal("COMPROBANTE");
			int es_caso_originalColumnIndex = reader.GetOrdinal("ES_CASO_ORIGINAL");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int costo_transferenciaColumnIndex = reader.GetOrdinal("COSTO_TRANSFERENCIA");
			int costo_asociadoColumnIndex = reader.GetOrdinal("COSTO_ASOCIADO");
			int total_costoColumnIndex = reader.GetOrdinal("TOTAL_COSTO");
			int remision_externaColumnIndex = reader.GetOrdinal("REMISION_EXTERNA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int vehiculo_matriculaColumnIndex = reader.GetOrdinal("VEHICULO_MATRICULA");
			int vehiculo_marcaColumnIndex = reader.GetOrdinal("VEHICULO_MARCA");
			int remision_autonumeracion_idColumnIndex = reader.GetOrdinal("REMISION_AUTONUMERACION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_TRANSFERENCIA_BALANCEADOSRow record = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_chofer_idColumnIndex))
						record.FUNCIONARIO_CHOFER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_chofer_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante1_idColumnIndex))
						record.ACOMPANANTE1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante1_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante2_idColumnIndex))
						record.ACOMPANANTE2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante2_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante3_idColumnIndex))
						record.ACOMPANANTE3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante3_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(comprobanteColumnIndex))
						record.COMPROBANTE = Convert.ToString(reader.GetValue(comprobanteColumnIndex));
					record.ES_CASO_ORIGINAL = Convert.ToString(reader.GetValue(es_caso_originalColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_transferenciaColumnIndex))
						record.COSTO_TRANSFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_transferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(costo_asociadoColumnIndex))
						record.COSTO_ASOCIADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_asociadoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costoColumnIndex))
						record.TOTAL_COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costoColumnIndex)), 9);
					if(!reader.IsDBNull(remision_externaColumnIndex))
						record.REMISION_EXTERNA = Convert.ToString(reader.GetValue(remision_externaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(vehiculo_matriculaColumnIndex))
						record.VEHICULO_MATRICULA = Convert.ToString(reader.GetValue(vehiculo_matriculaColumnIndex));
					if(!reader.IsDBNull(vehiculo_marcaColumnIndex))
						record.VEHICULO_MARCA = Convert.ToString(reader.GetValue(vehiculo_marcaColumnIndex));
					if(!reader.IsDBNull(remision_autonumeracion_idColumnIndex))
						record.REMISION_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(remision_autonumeracion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_TRANSFERENCIA_BALANCEADOSRow[])(recordList.ToArray(typeof(STOCK_TRANSFERENCIA_BALANCEADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_TRANSFERENCIA_BALANCEADOSRow"/> object.</returns>
		protected virtual STOCK_TRANSFERENCIA_BALANCEADOSRow MapRow(DataRow row)
		{
			STOCK_TRANSFERENCIA_BALANCEADOSRow mappedObject = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
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
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE1_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE1_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE2_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE2_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE3_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE3_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "COMPROBANTE"
			dataColumn = dataTable.Columns["COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE = (string)row[dataColumn];
			// Column "ES_CASO_ORIGINAL"
			dataColumn = dataTable.Columns["ES_CASO_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CASO_ORIGINAL = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_TRANSFERENCIA"
			dataColumn = dataTable.Columns["COSTO_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TRANSFERENCIA = (decimal)row[dataColumn];
			// Column "COSTO_ASOCIADO"
			dataColumn = dataTable.Columns["COSTO_ASOCIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ASOCIADO = (decimal)row[dataColumn];
			// Column "TOTAL_COSTO"
			dataColumn = dataTable.Columns["TOTAL_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO = (decimal)row[dataColumn];
			// Column "REMISION_EXTERNA"
			dataColumn = dataTable.Columns["REMISION_EXTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMISION_EXTERNA = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "VEHICULO_MATRICULA"
			dataColumn = dataTable.Columns["VEHICULO_MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MATRICULA = (string)row[dataColumn];
			// Column "VEHICULO_MARCA"
			dataColumn = dataTable.Columns["VEHICULO_MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MARCA = (string)row[dataColumn];
			// Column "REMISION_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["REMISION_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMISION_AUTONUMERACION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_TRANSFERENCIA_BALANCEADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_TRANSFERENCIA_BALANCEADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACOMPANANTE1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACOMPANANTE2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACOMPANANTE3_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ES_CASO_ORIGINAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_TRANSFERENCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_ASOCIADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REMISION_EXTERNA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VEHICULO_MATRICULA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("VEHICULO_MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("REMISION_AUTONUMERACION_ID", typeof(decimal));
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

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CHOFER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_CASO_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ASOCIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REMISION_EXTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VEHICULO_MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REMISION_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base class
}  // End of namespace
