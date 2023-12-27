// <fileinfo name="APLICACION_DOCUMENTOSCollection_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="APLICACION_DOCUMENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PERSONA_DOCUMENTOS_IDColumnName = "PERSONA_DOCUMENTOS_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string TOTAL_VALORESColumnName = "TOTAL_VALORES";
		public const string TOTAL_DOCUMENTOSColumnName = "TOTAL_DOCUMENTOS";
		public const string PERSONA_VALORES_IDColumnName = "PERSONA_VALORES_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string AUTONUMERACION_RECIBO_IDColumnName = "AUTONUMERACION_RECIBO_ID";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string NRO_RECIBO_MANUALColumnName = "NRO_RECIBO_MANUAL";
		public const string CONSOLIDACION_DEUDAColumnName = "CONSOLIDACION_DEUDA";
		public const string NC_DEPOSITO_IDColumnName = "NC_DEPOSITO_ID";
		public const string NC_AUTONUMERACION_IDColumnName = "NC_AUTONUMERACION_ID";
		public const string NC_NRO_COMPROBANTEColumnName = "NC_NRO_COMPROBANTE";
		public const string NC_CTACTE_CAJA_SUCURSAL_IDColumnName = "NC_CTACTE_CAJA_SUCURSAL_ID";
		public const string FC_DEPOSITO_IDColumnName = "FC_DEPOSITO_ID";
		public const string FC_AUTONUMERACION_IDColumnName = "FC_AUTONUMERACION_ID";
		public const string FC_NRO_COMPROBANTEColumnName = "FC_NRO_COMPROBANTE";
		public const string FC_CTACTE_CAJA_SUCURSAL_IDColumnName = "FC_CTACTE_CAJA_SUCURSAL_ID";
		public const string FC_CASO_IDColumnName = "FC_CASO_ID";
		public const string MONTO_NUEVA_CUOTAColumnName = "MONTO_NUEVA_CUOTA";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public APLICACION_DOCUMENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="APLICACION_DOCUMENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="APLICACION_DOCUMENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public APLICACION_DOCUMENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			APLICACION_DOCUMENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.APLICACION_DOCUMENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="APLICACION_DOCUMENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="APLICACION_DOCUMENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual APLICACION_DOCUMENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			APLICACION_DOCUMENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
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
		/// return records by the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
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
		/// return records by the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id)
		{
			return GetByFC_AUTONUMERACION_ID(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_AUTONUMERACION_IDAsDataTable(decimal fc_autonumeracion_id)
		{
			return GetByFC_AUTONUMERACION_IDAsDataTable(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_AUTONUMERACION_IDAsDataTable(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_AUTONUMERACION_IDCommand(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(fc_autonumeracion_idNull)
				whereSql += "FC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_autonumeracion_idNull)
				AddParameter(cmd, "FC_AUTONUMERACION_ID", fc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByFC_CTACTE_CAJA_SUCURSAL_ID(decimal fc_ctacte_caja_sucursal_id)
		{
			return GetByFC_CTACTE_CAJA_SUCURSAL_ID(fc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="fc_ctacte_caja_sucursal_idNull">true if the method ignores the fc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByFC_CTACTE_CAJA_SUCURSAL_ID(decimal fc_ctacte_caja_sucursal_id, bool fc_ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByFC_CTACTE_CAJA_SUCURSAL_IDCommand(fc_ctacte_caja_sucursal_id, fc_ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal fc_ctacte_caja_sucursal_id)
		{
			return GetByFC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(fc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="fc_ctacte_caja_sucursal_idNull">true if the method ignores the fc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal fc_ctacte_caja_sucursal_id, bool fc_ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CTACTE_CAJA_SUCURSAL_IDCommand(fc_ctacte_caja_sucursal_id, fc_ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="fc_ctacte_caja_sucursal_idNull">true if the method ignores the fc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CTACTE_CAJA_SUCURSAL_IDCommand(decimal fc_ctacte_caja_sucursal_id, bool fc_ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(fc_ctacte_caja_sucursal_idNull)
				whereSql += "FC_CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "FC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("FC_CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "FC_CTACTE_CAJA_SUCURSAL_ID", fc_ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByFC_CASO_ID(decimal fc_caso_id)
		{
			return GetByFC_CASO_ID(fc_caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <param name="fc_caso_idNull">true if the method ignores the fc_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByFC_CASO_ID(decimal fc_caso_id, bool fc_caso_idNull)
		{
			return MapRecords(CreateGetByFC_CASO_IDCommand(fc_caso_id, fc_caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CASO_IDAsDataTable(decimal fc_caso_id)
		{
			return GetByFC_CASO_IDAsDataTable(fc_caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <param name="fc_caso_idNull">true if the method ignores the fc_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CASO_IDAsDataTable(decimal fc_caso_id, bool fc_caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CASO_IDCommand(fc_caso_id, fc_caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <param name="fc_caso_idNull">true if the method ignores the fc_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CASO_IDCommand(decimal fc_caso_id, bool fc_caso_idNull)
		{
			string whereSql = "";
			if(fc_caso_idNull)
				whereSql += "FC_CASO_ID IS NULL";
			else
				whereSql += "FC_CASO_ID=" + _db.CreateSqlParameterName("FC_CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_caso_idNull)
				AddParameter(cmd, "FC_CASO_ID", fc_caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByFC_DEPOSITO_ID(decimal fc_deposito_id)
		{
			return GetByFC_DEPOSITO_ID(fc_deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <param name="fc_deposito_idNull">true if the method ignores the fc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByFC_DEPOSITO_ID(decimal fc_deposito_id, bool fc_deposito_idNull)
		{
			return MapRecords(CreateGetByFC_DEPOSITO_IDCommand(fc_deposito_id, fc_deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_DEPOSITO_IDAsDataTable(decimal fc_deposito_id)
		{
			return GetByFC_DEPOSITO_IDAsDataTable(fc_deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <param name="fc_deposito_idNull">true if the method ignores the fc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_DEPOSITO_IDAsDataTable(decimal fc_deposito_id, bool fc_deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_DEPOSITO_IDCommand(fc_deposito_id, fc_deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <param name="fc_deposito_idNull">true if the method ignores the fc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_DEPOSITO_IDCommand(decimal fc_deposito_id, bool fc_deposito_idNull)
		{
			string whereSql = "";
			if(fc_deposito_idNull)
				whereSql += "FC_DEPOSITO_ID IS NULL";
			else
				whereSql += "FC_DEPOSITO_ID=" + _db.CreateSqlParameterName("FC_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_deposito_idNull)
				AddParameter(cmd, "FC_DEPOSITO_ID", fc_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
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
		/// return records by the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByNC_AUTONUMERACION_ID(decimal nc_autonumeracion_id)
		{
			return GetByNC_AUTONUMERACION_ID(nc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="nc_autonumeracion_idNull">true if the method ignores the nc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByNC_AUTONUMERACION_ID(decimal nc_autonumeracion_id, bool nc_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByNC_AUTONUMERACION_IDCommand(nc_autonumeracion_id, nc_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNC_AUTONUMERACION_IDAsDataTable(decimal nc_autonumeracion_id)
		{
			return GetByNC_AUTONUMERACION_IDAsDataTable(nc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="nc_autonumeracion_idNull">true if the method ignores the nc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNC_AUTONUMERACION_IDAsDataTable(decimal nc_autonumeracion_id, bool nc_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNC_AUTONUMERACION_IDCommand(nc_autonumeracion_id, nc_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="nc_autonumeracion_idNull">true if the method ignores the nc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNC_AUTONUMERACION_IDCommand(decimal nc_autonumeracion_id, bool nc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(nc_autonumeracion_idNull)
				whereSql += "NC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "NC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("NC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nc_autonumeracion_idNull)
				AddParameter(cmd, "NC_AUTONUMERACION_ID", nc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByNC_CTACTE_CAJA_SUCURSAL_ID(decimal nc_ctacte_caja_sucursal_id)
		{
			return GetByNC_CTACTE_CAJA_SUCURSAL_ID(nc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="nc_ctacte_caja_sucursal_idNull">true if the method ignores the nc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByNC_CTACTE_CAJA_SUCURSAL_ID(decimal nc_ctacte_caja_sucursal_id, bool nc_ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByNC_CTACTE_CAJA_SUCURSAL_IDCommand(nc_ctacte_caja_sucursal_id, nc_ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal nc_ctacte_caja_sucursal_id)
		{
			return GetByNC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(nc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="nc_ctacte_caja_sucursal_idNull">true if the method ignores the nc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNC_CTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal nc_ctacte_caja_sucursal_id, bool nc_ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNC_CTACTE_CAJA_SUCURSAL_IDCommand(nc_ctacte_caja_sucursal_id, nc_ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="nc_ctacte_caja_sucursal_idNull">true if the method ignores the nc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNC_CTACTE_CAJA_SUCURSAL_IDCommand(decimal nc_ctacte_caja_sucursal_id, bool nc_ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(nc_ctacte_caja_sucursal_idNull)
				whereSql += "NC_CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "NC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("NC_CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nc_ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "NC_CTACTE_CAJA_SUCURSAL_ID", nc_ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByNC_DEPOSITO_ID(decimal nc_deposito_id)
		{
			return GetByNC_DEPOSITO_ID(nc_deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <param name="nc_deposito_idNull">true if the method ignores the nc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByNC_DEPOSITO_ID(decimal nc_deposito_id, bool nc_deposito_idNull)
		{
			return MapRecords(CreateGetByNC_DEPOSITO_IDCommand(nc_deposito_id, nc_deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNC_DEPOSITO_IDAsDataTable(decimal nc_deposito_id)
		{
			return GetByNC_DEPOSITO_IDAsDataTable(nc_deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <param name="nc_deposito_idNull">true if the method ignores the nc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNC_DEPOSITO_IDAsDataTable(decimal nc_deposito_id, bool nc_deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNC_DEPOSITO_IDCommand(nc_deposito_id, nc_deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <param name="nc_deposito_idNull">true if the method ignores the nc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNC_DEPOSITO_IDCommand(decimal nc_deposito_id, bool nc_deposito_idNull)
		{
			string whereSql = "";
			if(nc_deposito_idNull)
				whereSql += "NC_DEPOSITO_ID IS NULL";
			else
				whereSql += "NC_DEPOSITO_ID=" + _db.CreateSqlParameterName("NC_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nc_deposito_idNull)
				AddParameter(cmd, "NC_DEPOSITO_ID", nc_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_PER_DOC_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_documentos_id">The <c>PERSONA_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByPERSONA_DOCUMENTOS_ID(decimal persona_documentos_id)
		{
			return MapRecords(CreateGetByPERSONA_DOCUMENTOS_IDCommand(persona_documentos_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_PER_DOC_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_documentos_id">The <c>PERSONA_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_DOCUMENTOS_IDAsDataTable(decimal persona_documentos_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_DOCUMENTOS_IDCommand(persona_documentos_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_PER_DOC_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_documentos_id">The <c>PERSONA_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_DOCUMENTOS_IDCommand(decimal persona_documentos_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("PERSONA_DOCUMENTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_DOCUMENTOS_ID", persona_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_PER_VAL_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_valores_id">The <c>PERSONA_VALORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByPERSONA_VALORES_ID(decimal persona_valores_id)
		{
			return MapRecords(CreateGetByPERSONA_VALORES_IDCommand(persona_valores_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_PER_VAL_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_valores_id">The <c>PERSONA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_VALORES_IDAsDataTable(decimal persona_valores_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_VALORES_IDCommand(persona_valores_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_PER_VAL_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_valores_id">The <c>PERSONA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_VALORES_IDCommand(decimal persona_valores_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_VALORES_ID=" + _db.CreateSqlParameterName("PERSONA_VALORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_VALORES_ID", persona_valores_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_IDAsDataTable(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_SUCURSAL_ID</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public APLICACION_DOCUMENTOSRow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_IDAsDataTable(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOSRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_USUARIO_ID</c> foreign key.
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
		/// Adds a new record into the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(APLICACION_DOCUMENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.APLICACION_DOCUMENTOS (" +
				"ID, " +
				"CASO_ID, " +
				"PERSONA_DOCUMENTOS_ID, " +
				"SUCURSAL_ID, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"USUARIO_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"TOTAL_VALORES, " +
				"TOTAL_DOCUMENTOS, " +
				"PERSONA_VALORES_ID, " +
				"FUNCIONARIO_ID, " +
				"AUTONUMERACION_RECIBO_ID, " +
				"CTACTE_RECIBO_ID, " +
				"NRO_RECIBO_MANUAL, " +
				"CONSOLIDACION_DEUDA, " +
				"NC_DEPOSITO_ID, " +
				"NC_AUTONUMERACION_ID, " +
				"NC_NRO_COMPROBANTE, " +
				"NC_CTACTE_CAJA_SUCURSAL_ID, " +
				"FC_DEPOSITO_ID, " +
				"FC_AUTONUMERACION_ID, " +
				"FC_NRO_COMPROBANTE, " +
				"FC_CTACTE_CAJA_SUCURSAL_ID, " +
				"FC_CASO_ID, " +
				"MONTO_NUEVA_CUOTA, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"OBSERVACION, " +
				"NRO_COMPROBANTE_EXTERNO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_DOCUMENTOS_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("TOTAL_VALORES") + ", " +
				_db.CreateSqlParameterName("TOTAL_DOCUMENTOS") + ", " +
				_db.CreateSqlParameterName("PERSONA_VALORES_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("NRO_RECIBO_MANUAL") + ", " +
				_db.CreateSqlParameterName("CONSOLIDACION_DEUDA") + ", " +
				_db.CreateSqlParameterName("NC_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("NC_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NC_NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("NC_CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FC_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FC_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("FC_NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FC_CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FC_CASO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_NUEVA_CUOTA") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PERSONA_DOCUMENTOS_ID", value.PERSONA_DOCUMENTOS_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "TOTAL_VALORES", value.TOTAL_VALORES);
			AddParameter(cmd, "TOTAL_DOCUMENTOS", value.TOTAL_DOCUMENTOS);
			AddParameter(cmd, "PERSONA_VALORES_ID", value.PERSONA_VALORES_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "NRO_RECIBO_MANUAL", value.NRO_RECIBO_MANUAL);
			AddParameter(cmd, "CONSOLIDACION_DEUDA", value.CONSOLIDACION_DEUDA);
			AddParameter(cmd, "NC_DEPOSITO_ID",
				value.IsNC_DEPOSITO_IDNull ? DBNull.Value : (object)value.NC_DEPOSITO_ID);
			AddParameter(cmd, "NC_AUTONUMERACION_ID",
				value.IsNC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.NC_AUTONUMERACION_ID);
			AddParameter(cmd, "NC_NRO_COMPROBANTE", value.NC_NRO_COMPROBANTE);
			AddParameter(cmd, "NC_CTACTE_CAJA_SUCURSAL_ID",
				value.IsNC_CTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.NC_CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_DEPOSITO_ID",
				value.IsFC_DEPOSITO_IDNull ? DBNull.Value : (object)value.FC_DEPOSITO_ID);
			AddParameter(cmd, "FC_AUTONUMERACION_ID",
				value.IsFC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.FC_AUTONUMERACION_ID);
			AddParameter(cmd, "FC_NRO_COMPROBANTE", value.FC_NRO_COMPROBANTE);
			AddParameter(cmd, "FC_CTACTE_CAJA_SUCURSAL_ID",
				value.IsFC_CTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.FC_CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_CASO_ID",
				value.IsFC_CASO_IDNull ? DBNull.Value : (object)value.FC_CASO_ID);
			AddParameter(cmd, "MONTO_NUEVA_CUOTA",
				value.IsMONTO_NUEVA_CUOTANull ? DBNull.Value : (object)value.MONTO_NUEVA_CUOTA);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(APLICACION_DOCUMENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.APLICACION_DOCUMENTOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"PERSONA_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("PERSONA_DOCUMENTOS_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"TOTAL_VALORES=" + _db.CreateSqlParameterName("TOTAL_VALORES") + ", " +
				"TOTAL_DOCUMENTOS=" + _db.CreateSqlParameterName("TOTAL_DOCUMENTOS") + ", " +
				"PERSONA_VALORES_ID=" + _db.CreateSqlParameterName("PERSONA_VALORES_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				"CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				"NRO_RECIBO_MANUAL=" + _db.CreateSqlParameterName("NRO_RECIBO_MANUAL") + ", " +
				"CONSOLIDACION_DEUDA=" + _db.CreateSqlParameterName("CONSOLIDACION_DEUDA") + ", " +
				"NC_DEPOSITO_ID=" + _db.CreateSqlParameterName("NC_DEPOSITO_ID") + ", " +
				"NC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("NC_AUTONUMERACION_ID") + ", " +
				"NC_NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NC_NRO_COMPROBANTE") + ", " +
				"NC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("NC_CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"FC_DEPOSITO_ID=" + _db.CreateSqlParameterName("FC_DEPOSITO_ID") + ", " +
				"FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID") + ", " +
				"FC_NRO_COMPROBANTE=" + _db.CreateSqlParameterName("FC_NRO_COMPROBANTE") + ", " +
				"FC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("FC_CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"FC_CASO_ID=" + _db.CreateSqlParameterName("FC_CASO_ID") + ", " +
				"MONTO_NUEVA_CUOTA=" + _db.CreateSqlParameterName("MONTO_NUEVA_CUOTA") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"NRO_COMPROBANTE_EXTERNO=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PERSONA_DOCUMENTOS_ID", value.PERSONA_DOCUMENTOS_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "TOTAL_VALORES", value.TOTAL_VALORES);
			AddParameter(cmd, "TOTAL_DOCUMENTOS", value.TOTAL_DOCUMENTOS);
			AddParameter(cmd, "PERSONA_VALORES_ID", value.PERSONA_VALORES_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "NRO_RECIBO_MANUAL", value.NRO_RECIBO_MANUAL);
			AddParameter(cmd, "CONSOLIDACION_DEUDA", value.CONSOLIDACION_DEUDA);
			AddParameter(cmd, "NC_DEPOSITO_ID",
				value.IsNC_DEPOSITO_IDNull ? DBNull.Value : (object)value.NC_DEPOSITO_ID);
			AddParameter(cmd, "NC_AUTONUMERACION_ID",
				value.IsNC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.NC_AUTONUMERACION_ID);
			AddParameter(cmd, "NC_NRO_COMPROBANTE", value.NC_NRO_COMPROBANTE);
			AddParameter(cmd, "NC_CTACTE_CAJA_SUCURSAL_ID",
				value.IsNC_CTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.NC_CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_DEPOSITO_ID",
				value.IsFC_DEPOSITO_IDNull ? DBNull.Value : (object)value.FC_DEPOSITO_ID);
			AddParameter(cmd, "FC_AUTONUMERACION_ID",
				value.IsFC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.FC_AUTONUMERACION_ID);
			AddParameter(cmd, "FC_NRO_COMPROBANTE", value.FC_NRO_COMPROBANTE);
			AddParameter(cmd, "FC_CTACTE_CAJA_SUCURSAL_ID",
				value.IsFC_CTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.FC_CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_CASO_ID",
				value.IsFC_CASO_IDNull ? DBNull.Value : (object)value.FC_CASO_ID);
			AddParameter(cmd, "MONTO_NUEVA_CUOTA",
				value.IsMONTO_NUEVA_CUOTANull ? DBNull.Value : (object)value.MONTO_NUEVA_CUOTA);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>APLICACION_DOCUMENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>APLICACION_DOCUMENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(APLICACION_DOCUMENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>APLICACION_DOCUMENTOS</c> table using
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
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
		/// delete records using the <c>FK_APLIC_DOCUMEN_AUTO_ID</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
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
		/// delete records using the <c>FK_APLIC_DOCUMEN_CAJA_SUC</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id)
		{
			return DeleteByFC_AUTONUMERACION_ID(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return CreateDeleteByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_AUTONUMERACION_IDCommand(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(fc_autonumeracion_idNull)
				whereSql += "FC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_autonumeracion_idNull)
				AddParameter(cmd, "FC_AUTONUMERACION_ID", fc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CTACTE_CAJA_SUCURSAL_ID(decimal fc_ctacte_caja_sucursal_id)
		{
			return DeleteByFC_CTACTE_CAJA_SUCURSAL_ID(fc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="fc_ctacte_caja_sucursal_idNull">true if the method ignores the fc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CTACTE_CAJA_SUCURSAL_ID(decimal fc_ctacte_caja_sucursal_id, bool fc_ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByFC_CTACTE_CAJA_SUCURSAL_IDCommand(fc_ctacte_caja_sucursal_id, fc_ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_FC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="fc_ctacte_caja_sucursal_id">The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="fc_ctacte_caja_sucursal_idNull">true if the method ignores the fc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CTACTE_CAJA_SUCURSAL_IDCommand(decimal fc_ctacte_caja_sucursal_id, bool fc_ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(fc_ctacte_caja_sucursal_idNull)
				whereSql += "FC_CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "FC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("FC_CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "FC_CTACTE_CAJA_SUCURSAL_ID", fc_ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CASO_ID(decimal fc_caso_id)
		{
			return DeleteByFC_CASO_ID(fc_caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <param name="fc_caso_idNull">true if the method ignores the fc_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CASO_ID(decimal fc_caso_id, bool fc_caso_idNull)
		{
			return CreateDeleteByFC_CASO_IDCommand(fc_caso_id, fc_caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_FC_CASO</c> foreign key.
		/// </summary>
		/// <param name="fc_caso_id">The <c>FC_CASO_ID</c> column value.</param>
		/// <param name="fc_caso_idNull">true if the method ignores the fc_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CASO_IDCommand(decimal fc_caso_id, bool fc_caso_idNull)
		{
			string whereSql = "";
			if(fc_caso_idNull)
				whereSql += "FC_CASO_ID IS NULL";
			else
				whereSql += "FC_CASO_ID=" + _db.CreateSqlParameterName("FC_CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_caso_idNull)
				AddParameter(cmd, "FC_CASO_ID", fc_caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_DEPOSITO_ID(decimal fc_deposito_id)
		{
			return DeleteByFC_DEPOSITO_ID(fc_deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <param name="fc_deposito_idNull">true if the method ignores the fc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_DEPOSITO_ID(decimal fc_deposito_id, bool fc_deposito_idNull)
		{
			return CreateDeleteByFC_DEPOSITO_IDCommand(fc_deposito_id, fc_deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_FC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="fc_deposito_id">The <c>FC_DEPOSITO_ID</c> column value.</param>
		/// <param name="fc_deposito_idNull">true if the method ignores the fc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_DEPOSITO_IDCommand(decimal fc_deposito_id, bool fc_deposito_idNull)
		{
			string whereSql = "";
			if(fc_deposito_idNull)
				whereSql += "FC_DEPOSITO_ID IS NULL";
			else
				whereSql += "FC_DEPOSITO_ID=" + _db.CreateSqlParameterName("FC_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_deposito_idNull)
				AddParameter(cmd, "FC_DEPOSITO_ID", fc_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
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
		/// delete records using the <c>FK_APLIC_DOCUMEN_FUNC_ID</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_AUTONUMERACION_ID(decimal nc_autonumeracion_id)
		{
			return DeleteByNC_AUTONUMERACION_ID(nc_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="nc_autonumeracion_idNull">true if the method ignores the nc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_AUTONUMERACION_ID(decimal nc_autonumeracion_id, bool nc_autonumeracion_idNull)
		{
			return CreateDeleteByNC_AUTONUMERACION_IDCommand(nc_autonumeracion_id, nc_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_NC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="nc_autonumeracion_id">The <c>NC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="nc_autonumeracion_idNull">true if the method ignores the nc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNC_AUTONUMERACION_IDCommand(decimal nc_autonumeracion_id, bool nc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(nc_autonumeracion_idNull)
				whereSql += "NC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "NC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("NC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nc_autonumeracion_idNull)
				AddParameter(cmd, "NC_AUTONUMERACION_ID", nc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_CTACTE_CAJA_SUCURSAL_ID(decimal nc_ctacte_caja_sucursal_id)
		{
			return DeleteByNC_CTACTE_CAJA_SUCURSAL_ID(nc_ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="nc_ctacte_caja_sucursal_idNull">true if the method ignores the nc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_CTACTE_CAJA_SUCURSAL_ID(decimal nc_ctacte_caja_sucursal_id, bool nc_ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByNC_CTACTE_CAJA_SUCURSAL_IDCommand(nc_ctacte_caja_sucursal_id, nc_ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_NC_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="nc_ctacte_caja_sucursal_id">The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="nc_ctacte_caja_sucursal_idNull">true if the method ignores the nc_ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNC_CTACTE_CAJA_SUCURSAL_IDCommand(decimal nc_ctacte_caja_sucursal_id, bool nc_ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(nc_ctacte_caja_sucursal_idNull)
				whereSql += "NC_CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "NC_CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("NC_CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nc_ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "NC_CTACTE_CAJA_SUCURSAL_ID", nc_ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_DEPOSITO_ID(decimal nc_deposito_id)
		{
			return DeleteByNC_DEPOSITO_ID(nc_deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <param name="nc_deposito_idNull">true if the method ignores the nc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_DEPOSITO_ID(decimal nc_deposito_id, bool nc_deposito_idNull)
		{
			return CreateDeleteByNC_DEPOSITO_IDCommand(nc_deposito_id, nc_deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_NC_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="nc_deposito_id">The <c>NC_DEPOSITO_ID</c> column value.</param>
		/// <param name="nc_deposito_idNull">true if the method ignores the nc_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNC_DEPOSITO_IDCommand(decimal nc_deposito_id, bool nc_deposito_idNull)
		{
			string whereSql = "";
			if(nc_deposito_idNull)
				whereSql += "NC_DEPOSITO_ID IS NULL";
			else
				whereSql += "NC_DEPOSITO_ID=" + _db.CreateSqlParameterName("NC_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nc_deposito_idNull)
				AddParameter(cmd, "NC_DEPOSITO_ID", nc_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_PER_DOC_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_documentos_id">The <c>PERSONA_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_DOCUMENTOS_ID(decimal persona_documentos_id)
		{
			return CreateDeleteByPERSONA_DOCUMENTOS_IDCommand(persona_documentos_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_PER_DOC_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_documentos_id">The <c>PERSONA_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_DOCUMENTOS_IDCommand(decimal persona_documentos_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("PERSONA_DOCUMENTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_DOCUMENTOS_ID", persona_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_PER_VAL_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_valores_id">The <c>PERSONA_VALORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_VALORES_ID(decimal persona_valores_id)
		{
			return CreateDeleteByPERSONA_VALORES_IDCommand(persona_valores_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_PER_VAL_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_valores_id">The <c>PERSONA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_VALORES_IDCommand(decimal persona_valores_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_VALORES_ID=" + _db.CreateSqlParameterName("PERSONA_VALORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_VALORES_ID", persona_valores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return DeleteByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return CreateDeleteByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_SUCURSAL_ID</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return DeleteByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_TAL_RECIBO_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_USUARIO_ID</c> foreign key.
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
		/// Deletes <c>APLICACION_DOCUMENTOS</c> records that match the specified criteria.
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
		/// to delete <c>APLICACION_DOCUMENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.APLICACION_DOCUMENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>APLICACION_DOCUMENTOS</c> table.
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOSRow"/> objects.</returns>
		protected virtual APLICACION_DOCUMENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int persona_documentos_idColumnIndex = reader.GetOrdinal("PERSONA_DOCUMENTOS_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int total_valoresColumnIndex = reader.GetOrdinal("TOTAL_VALORES");
			int total_documentosColumnIndex = reader.GetOrdinal("TOTAL_DOCUMENTOS");
			int persona_valores_idColumnIndex = reader.GetOrdinal("PERSONA_VALORES_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int autonumeracion_recibo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_ID");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int nro_recibo_manualColumnIndex = reader.GetOrdinal("NRO_RECIBO_MANUAL");
			int consolidacion_deudaColumnIndex = reader.GetOrdinal("CONSOLIDACION_DEUDA");
			int nc_deposito_idColumnIndex = reader.GetOrdinal("NC_DEPOSITO_ID");
			int nc_autonumeracion_idColumnIndex = reader.GetOrdinal("NC_AUTONUMERACION_ID");
			int nc_nro_comprobanteColumnIndex = reader.GetOrdinal("NC_NRO_COMPROBANTE");
			int nc_ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("NC_CTACTE_CAJA_SUCURSAL_ID");
			int fc_deposito_idColumnIndex = reader.GetOrdinal("FC_DEPOSITO_ID");
			int fc_autonumeracion_idColumnIndex = reader.GetOrdinal("FC_AUTONUMERACION_ID");
			int fc_nro_comprobanteColumnIndex = reader.GetOrdinal("FC_NRO_COMPROBANTE");
			int fc_ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("FC_CTACTE_CAJA_SUCURSAL_ID");
			int fc_caso_idColumnIndex = reader.GetOrdinal("FC_CASO_ID");
			int monto_nueva_cuotaColumnIndex = reader.GetOrdinal("MONTO_NUEVA_CUOTA");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					APLICACION_DOCUMENTOSRow record = new APLICACION_DOCUMENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.PERSONA_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_documentos_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.TOTAL_VALORES = Math.Round(Convert.ToDecimal(reader.GetValue(total_valoresColumnIndex)), 9);
					record.TOTAL_DOCUMENTOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_documentosColumnIndex)), 9);
					record.PERSONA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_valores_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_recibo_idColumnIndex))
						record.AUTONUMERACION_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_recibo_manualColumnIndex))
						record.NRO_RECIBO_MANUAL = Convert.ToString(reader.GetValue(nro_recibo_manualColumnIndex));
					if(!reader.IsDBNull(consolidacion_deudaColumnIndex))
						record.CONSOLIDACION_DEUDA = Convert.ToString(reader.GetValue(consolidacion_deudaColumnIndex));
					if(!reader.IsDBNull(nc_deposito_idColumnIndex))
						record.NC_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_autonumeracion_idColumnIndex))
						record.NC_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_nro_comprobanteColumnIndex))
						record.NC_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nc_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(nc_ctacte_caja_sucursal_idColumnIndex))
						record.NC_CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_deposito_idColumnIndex))
						record.FC_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_autonumeracion_idColumnIndex))
						record.FC_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_nro_comprobanteColumnIndex))
						record.FC_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(fc_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fc_ctacte_caja_sucursal_idColumnIndex))
						record.FC_CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_caso_idColumnIndex))
						record.FC_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_nueva_cuotaColumnIndex))
						record.MONTO_NUEVA_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_nueva_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (APLICACION_DOCUMENTOSRow[])(recordList.ToArray(typeof(APLICACION_DOCUMENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="APLICACION_DOCUMENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="APLICACION_DOCUMENTOSRow"/> object.</returns>
		protected virtual APLICACION_DOCUMENTOSRow MapRow(DataRow row)
		{
			APLICACION_DOCUMENTOSRow mappedObject = new APLICACION_DOCUMENTOSRow();
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
			// Column "PERSONA_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["PERSONA_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "TOTAL_VALORES"
			dataColumn = dataTable.Columns["TOTAL_VALORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_VALORES = (decimal)row[dataColumn];
			// Column "TOTAL_DOCUMENTOS"
			dataColumn = dataTable.Columns["TOTAL_DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DOCUMENTOS = (decimal)row[dataColumn];
			// Column "PERSONA_VALORES_ID"
			dataColumn = dataTable.Columns["PERSONA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_VALORES_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "NRO_RECIBO_MANUAL"
			dataColumn = dataTable.Columns["NRO_RECIBO_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_MANUAL = (string)row[dataColumn];
			// Column "CONSOLIDACION_DEUDA"
			dataColumn = dataTable.Columns["CONSOLIDACION_DEUDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_DEUDA = (string)row[dataColumn];
			// Column "NC_DEPOSITO_ID"
			dataColumn = dataTable.Columns["NC_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "NC_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["NC_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NC_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NC_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NC_CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["NC_CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FC_DEPOSITO_ID"
			dataColumn = dataTable.Columns["FC_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FC_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["FC_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "FC_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["FC_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FC_CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["FC_CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FC_CASO_ID"
			dataColumn = dataTable.Columns["FC_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO_NUEVA_CUOTA"
			dataColumn = dataTable.Columns["MONTO_NUEVA_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NUEVA_CUOTA = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>APLICACION_DOCUMENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "APLICACION_DOCUMENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_DOCUMENTOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TOTAL_VALORES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_DOCUMENTOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_VALORES_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_MANUAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_DEUDA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NC_DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NC_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NC_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NC_CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FC_CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_NUEVA_CUOTA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_EXTERNO", typeof(string));
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

				case "PERSONA_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_VALORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_RECIBO_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSOLIDACION_DEUDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NC_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NC_CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FC_CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NUEVA_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of APLICACION_DOCUMENTOSCollection_Base class
}  // End of namespace
