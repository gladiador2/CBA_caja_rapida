// <fileinfo name="DESCUENTO_DOCUMENTOS_CLIENTECollection_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOCUMENTOS_CLIENTECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESCUENTO_DOCUMENTOS_CLIENTECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOCUMENTOS_CLIENTECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_GASTO_EXTRAColumnName = "MONTO_GASTO_EXTRA";
		public const string PORCENTAJE_DIARIO_MORAColumnName = "PORCENTAJE_DIARIO_MORA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string PERSONA_GARANTE_IDColumnName = "PERSONA_GARANTE_ID";
		public const string AFECTAR_CTACTE_PERSONA_DEBITOColumnName = "AFECTAR_CTACTE_PERSONA_DEBITO";
		public const string DESCUENTO_DOC_CON_RECURSOColumnName = "DESCUENTO_DOC_CON_RECURSO";
		public const string USAR_INTERES_EN_CALCULOColumnName = "USAR_INTERES_EN_CALCULO";
		public const string INTERES_INCLUYE_IMPUESTOColumnName = "INTERES_INCLUYE_IMPUESTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOCUMENTOS_CLIENTECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESCUENTO_DOCUMENTOS_CLIENTECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESCUENTO_DOCUMENTOS_CLIENTERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESCUENTO_DOCUMENTOS_CLIENTERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLIENTERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects that 
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESCUENTO_DOCUMENTOS_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESCUENTO_DOCUMENTOS_CLIENTERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByPERSONA_GARANTE_ID(decimal persona_garante_id)
		{
			return GetByPERSONA_GARANTE_ID(persona_garante_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <param name="persona_garante_idNull">true if the method ignores the persona_garante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByPERSONA_GARANTE_ID(decimal persona_garante_id, bool persona_garante_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_IDCommand(persona_garante_id, persona_garante_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_IDAsDataTable(decimal persona_garante_id)
		{
			return GetByPERSONA_GARANTE_IDAsDataTable(persona_garante_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <param name="persona_garante_idNull">true if the method ignores the persona_garante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_IDAsDataTable(decimal persona_garante_id, bool persona_garante_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_IDCommand(persona_garante_id, persona_garante_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <param name="persona_garante_idNull">true if the method ignores the persona_garante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_IDCommand(decimal persona_garante_id, bool persona_garante_idNull)
		{
			string whereSql = "";
			if(persona_garante_idNull)
				whereSql += "PERSONA_GARANTE_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_ID", persona_garante_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_AUTONUMER</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_AUTONUMER</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_AUTONUMER</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_CASO</c> foreign key.
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
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_FUN</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_FUN</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_FUN</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_MON</c> foreign key.
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
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_PERSON</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_PERSON</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_PERSON</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects 
		/// by the <c>FK_DESCUENTO_DOC_CLI_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_DOC_CLI_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_DOC_CLI_SUCURSAL</c> foreign key.
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
		/// Adds a new record into the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> object to be inserted.</param>
		public virtual void Insert(DESCUENTO_DOCUMENTOS_CLIENTERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESCUENTO_DOCUMENTOS_CLIENTE (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"FUNCIONARIO_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_GASTO_EXTRA, " +
				"PORCENTAJE_DIARIO_MORA, " +
				"OBSERVACION, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"PERSONA_GARANTE_ID, " +
				"AFECTAR_CTACTE_PERSONA_DEBITO, " +
				"DESCUENTO_DOC_CON_RECURSO, " +
				"USAR_INTERES_EN_CALCULO, " +
				"INTERES_INCLUYE_IMPUESTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_GASTO_EXTRA") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_ID") + ", " +
				_db.CreateSqlParameterName("AFECTAR_CTACTE_PERSONA_DEBITO") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOC_CON_RECURSO") + ", " +
				_db.CreateSqlParameterName("USAR_INTERES_EN_CALCULO") + ", " +
				_db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_GASTO_EXTRA", value.MONTO_GASTO_EXTRA);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA", value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "PERSONA_GARANTE_ID",
				value.IsPERSONA_GARANTE_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_ID);
			AddParameter(cmd, "AFECTAR_CTACTE_PERSONA_DEBITO", value.AFECTAR_CTACTE_PERSONA_DEBITO);
			AddParameter(cmd, "DESCUENTO_DOC_CON_RECURSO", value.DESCUENTO_DOC_CON_RECURSO);
			AddParameter(cmd, "USAR_INTERES_EN_CALCULO", value.USAR_INTERES_EN_CALCULO);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESCUENTO_DOCUMENTOS_CLIENTERow value)
		{
			
			string sqlStr = "UPDATE TRC.DESCUENTO_DOCUMENTOS_CLIENTE SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_GASTO_EXTRA=" + _db.CreateSqlParameterName("MONTO_GASTO_EXTRA") + ", " +
				"PORCENTAJE_DIARIO_MORA=" + _db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"PERSONA_GARANTE_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_ID") + ", " +
				"AFECTAR_CTACTE_PERSONA_DEBITO=" + _db.CreateSqlParameterName("AFECTAR_CTACTE_PERSONA_DEBITO") + ", " +
				"DESCUENTO_DOC_CON_RECURSO=" + _db.CreateSqlParameterName("DESCUENTO_DOC_CON_RECURSO") + ", " +
				"USAR_INTERES_EN_CALCULO=" + _db.CreateSqlParameterName("USAR_INTERES_EN_CALCULO") + ", " +
				"INTERES_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_GASTO_EXTRA", value.MONTO_GASTO_EXTRA);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA", value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "PERSONA_GARANTE_ID",
				value.IsPERSONA_GARANTE_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_ID);
			AddParameter(cmd, "AFECTAR_CTACTE_PERSONA_DEBITO", value.AFECTAR_CTACTE_PERSONA_DEBITO);
			AddParameter(cmd, "DESCUENTO_DOC_CON_RECURSO", value.DESCUENTO_DOC_CON_RECURSO);
			AddParameter(cmd, "USAR_INTERES_EN_CALCULO", value.USAR_INTERES_EN_CALCULO);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESCUENTO_DOCUMENTOS_CLIENTERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_ID(decimal persona_garante_id)
		{
			return DeleteByPERSONA_GARANTE_ID(persona_garante_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <param name="persona_garante_idNull">true if the method ignores the persona_garante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_ID(decimal persona_garante_id, bool persona_garante_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_IDCommand(persona_garante_id, persona_garante_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_PERSONA_GAR_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_id">The <c>PERSONA_GARANTE_ID</c> column value.</param>
		/// <param name="persona_garante_idNull">true if the method ignores the persona_garante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_IDCommand(decimal persona_garante_id, bool persona_garante_idNull)
		{
			string whereSql = "";
			if(persona_garante_idNull)
				whereSql += "PERSONA_GARANTE_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_ID", persona_garante_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_AUTONUMER</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_AUTONUMER</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return DeleteByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_CAJ_TESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_CASO</c> foreign key.
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_FUN</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_FUN</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_MON</c> foreign key.
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_PERSON</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_PERSON</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table using the 
		/// <c>FK_DESCUENTO_DOC_CLI_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_DOC_CLI_SUCURSAL</c> foreign key.
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
		/// Deletes <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> records that match the specified criteria.
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
		/// to delete <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESCUENTO_DOCUMENTOS_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		protected DESCUENTO_DOCUMENTOS_CLIENTERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		protected DESCUENTO_DOCUMENTOS_CLIENTERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> objects.</returns>
		protected virtual DESCUENTO_DOCUMENTOS_CLIENTERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_gasto_extraColumnIndex = reader.GetOrdinal("MONTO_GASTO_EXTRA");
			int porcentaje_diario_moraColumnIndex = reader.GetOrdinal("PORCENTAJE_DIARIO_MORA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int persona_garante_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_ID");
			int afectar_ctacte_persona_debitoColumnIndex = reader.GetOrdinal("AFECTAR_CTACTE_PERSONA_DEBITO");
			int descuento_doc_con_recursoColumnIndex = reader.GetOrdinal("DESCUENTO_DOC_CON_RECURSO");
			int usar_interes_en_calculoColumnIndex = reader.GetOrdinal("USAR_INTERES_EN_CALCULO");
			int interes_incluye_impuestoColumnIndex = reader.GetOrdinal("INTERES_INCLUYE_IMPUESTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESCUENTO_DOCUMENTOS_CLIENTERow record = new DESCUENTO_DOCUMENTOS_CLIENTERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_GASTO_EXTRA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_gasto_extraColumnIndex)), 9);
					record.PORCENTAJE_DIARIO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_diario_moraColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_idColumnIndex))
						record.PERSONA_GARANTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_idColumnIndex)), 9);
					if(!reader.IsDBNull(afectar_ctacte_persona_debitoColumnIndex))
						record.AFECTAR_CTACTE_PERSONA_DEBITO = Convert.ToString(reader.GetValue(afectar_ctacte_persona_debitoColumnIndex));
					if(!reader.IsDBNull(descuento_doc_con_recursoColumnIndex))
						record.DESCUENTO_DOC_CON_RECURSO = Convert.ToString(reader.GetValue(descuento_doc_con_recursoColumnIndex));
					record.USAR_INTERES_EN_CALCULO = Convert.ToString(reader.GetValue(usar_interes_en_calculoColumnIndex));
					record.INTERES_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(interes_incluye_impuestoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESCUENTO_DOCUMENTOS_CLIENTERow[])(recordList.ToArray(typeof(DESCUENTO_DOCUMENTOS_CLIENTERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESCUENTO_DOCUMENTOS_CLIENTERow"/> object.</returns>
		protected virtual DESCUENTO_DOCUMENTOS_CLIENTERow MapRow(DataRow row)
		{
			DESCUENTO_DOCUMENTOS_CLIENTERow mappedObject = new DESCUENTO_DOCUMENTOS_CLIENTERow();
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_GASTO_EXTRA"
			dataColumn = dataTable.Columns["MONTO_GASTO_EXTRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_GASTO_EXTRA = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DIARIO_MORA"
			dataColumn = dataTable.Columns["PORCENTAJE_DIARIO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DIARIO_MORA = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_ID = (decimal)row[dataColumn];
			// Column "AFECTAR_CTACTE_PERSONA_DEBITO"
			dataColumn = dataTable.Columns["AFECTAR_CTACTE_PERSONA_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTAR_CTACTE_PERSONA_DEBITO = (string)row[dataColumn];
			// Column "DESCUENTO_DOC_CON_RECURSO"
			dataColumn = dataTable.Columns["DESCUENTO_DOC_CON_RECURSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOC_CON_RECURSO = (string)row[dataColumn];
			// Column "USAR_INTERES_EN_CALCULO"
			dataColumn = dataTable.Columns["USAR_INTERES_EN_CALCULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_INTERES_EN_CALCULO = (string)row[dataColumn];
			// Column "INTERES_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["INTERES_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_INCLUYE_IMPUESTO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESCUENTO_DOCUMENTOS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESCUENTO_DOCUMENTOS_CLIENTE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_GASTO_EXTRA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DIARIO_MORA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AFECTAR_CTACTE_PERSONA_DEBITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOC_CON_RECURSO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("USAR_INTERES_EN_CALCULO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_INCLUYE_IMPUESTO", typeof(string));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_GASTO_EXTRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DIARIO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTAR_CTACTE_PERSONA_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTO_DOC_CON_RECURSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USAR_INTERES_EN_CALCULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERES_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESCUENTO_DOCUMENTOS_CLIENTECollection_Base class
}  // End of namespace
