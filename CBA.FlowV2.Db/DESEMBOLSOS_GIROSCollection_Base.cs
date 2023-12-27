// <fileinfo name="DESEMBOLSOS_GIROSCollection_Base.cs">
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
	/// The base class for <see cref="DESEMBOLSOS_GIROSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESEMBOLSOS_GIROSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEMBOLSOS_GIROSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHAColumnName = "FECHA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CHEQUE_CTACTE_BANCO_IDColumnName = "CHEQUE_CTACTE_BANCO_ID";
		public const string CHEQUE_FECHA_POSDATADOColumnName = "CHEQUE_FECHA_POSDATADO";
		public const string CHEQUE_FECHA_VENCIMIENTOColumnName = "CHEQUE_FECHA_VENCIMIENTO";
		public const string CHEQUE_NOMBRE_EMISORColumnName = "CHEQUE_NOMBRE_EMISOR";
		public const string CHEQUE_NOMBRE_BENEFICIARIOColumnName = "CHEQUE_NOMBRE_BENEFICIARIO";
		public const string CHEQUE_NRO_CUENTAColumnName = "CHEQUE_NRO_CUENTA";
		public const string CHEQUE_NRO_CHEQUEColumnName = "CHEQUE_NRO_CHEQUE";
		public const string CHEQUE_DOCUMENTO_EMISORColumnName = "CHEQUE_DOCUMENTO_EMISOR";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";
		public const string MONTO_VALORColumnName = "MONTO_VALOR";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CHEQUE_ES_DIFERIDOColumnName = "CHEQUE_ES_DIFERIDO";
		public const string MONTO_COMISIONColumnName = "MONTO_COMISION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESEMBOLSOS_GIROSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESEMBOLSOS_GIROSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESEMBOLSOS_GIROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESEMBOLSOS_GIROSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESEMBOLSOS_GIROSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects that 
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESEMBOLSOS_GIROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESEMBOLSOS_GIROSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESEMBOLSOS_GIROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESEMBOLSOS_GIROSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESEMBOLSOS_GIROSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
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
		/// return records by the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecords(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
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
		/// return records by the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_CASOS</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
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
		/// return records by the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_CTACTE_VALORES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_CTACTE_VALORES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_CTACTE_VALORES</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_IDAsDataTable(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_MONEDAS</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_IDAsDataTable(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_SUCULSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_SUCULSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_SUCULSALES</c> foreign key.
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
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public DESEMBOLSOS_GIROSRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROSRow"/> objects 
		/// by the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROSRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROSRow"/> object to be inserted.</param>
		public virtual void Insert(DESEMBOLSOS_GIROSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESEMBOLSOS_GIROS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA, " +
				"OBSERVACION, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_TOTAL, " +
				"CTACTE_VALOR_ID, " +
				"CHEQUE_CTACTE_BANCO_ID, " +
				"CHEQUE_FECHA_POSDATADO, " +
				"CHEQUE_FECHA_VENCIMIENTO, " +
				"CHEQUE_NOMBRE_EMISOR, " +
				"CHEQUE_NOMBRE_BENEFICIARIO, " +
				"CHEQUE_NRO_CUENTA, " +
				"CHEQUE_NRO_CHEQUE, " +
				"CHEQUE_DOCUMENTO_EMISOR, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"TRANSFERENCIA_BANCARIA_ID, " +
				"DEPOSITO_BANCARIO_ID, " +
				"CTACTE_RED_PAGO_ID, " +
				"CTACTE_PROCESADORA_TARJETA_ID, " +
				"MONTO_VALOR, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"CHEQUE_ES_DIFERIDO, " +
				"MONTO_COMISION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_FECHA_POSDATADO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NRO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_VALOR") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("MONTO_COMISION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_FECHA_POSDATADO",
				value.IsCHEQUE_FECHA_POSDATADONull ? DBNull.Value : (object)value.CHEQUE_FECHA_POSDATADO);
			AddParameter(cmd, "CHEQUE_FECHA_VENCIMIENTO",
				value.IsCHEQUE_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CHEQUE_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CHEQUE_NOMBRE_EMISOR", value.CHEQUE_NOMBRE_EMISOR);
			AddParameter(cmd, "CHEQUE_NOMBRE_BENEFICIARIO", value.CHEQUE_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_NRO_CHEQUE", value.CHEQUE_NRO_CHEQUE);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "MONTO_VALOR",
				value.IsMONTO_VALORNull ? DBNull.Value : (object)value.MONTO_VALOR);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			AddParameter(cmd, "MONTO_COMISION", value.MONTO_COMISION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESEMBOLSOS_GIROSRow value)
		{
			
			string sqlStr = "UPDATE TRC.DESEMBOLSOS_GIROS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				"CHEQUE_FECHA_POSDATADO=" + _db.CreateSqlParameterName("CHEQUE_FECHA_POSDATADO") + ", " +
				"CHEQUE_FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("CHEQUE_FECHA_VENCIMIENTO") + ", " +
				"CHEQUE_NOMBRE_EMISOR=" + _db.CreateSqlParameterName("CHEQUE_NOMBRE_EMISOR") + ", " +
				"CHEQUE_NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("CHEQUE_NOMBRE_BENEFICIARIO") + ", " +
				"CHEQUE_NRO_CUENTA=" + _db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				"CHEQUE_NRO_CHEQUE=" + _db.CreateSqlParameterName("CHEQUE_NRO_CHEQUE") + ", " +
				"CHEQUE_DOCUMENTO_EMISOR=" + _db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				"DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				"CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				"CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				"MONTO_VALOR=" + _db.CreateSqlParameterName("MONTO_VALOR") + ", " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"CHEQUE_ES_DIFERIDO=" + _db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") + ", " +
				"MONTO_COMISION=" + _db.CreateSqlParameterName("MONTO_COMISION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_FECHA_POSDATADO",
				value.IsCHEQUE_FECHA_POSDATADONull ? DBNull.Value : (object)value.CHEQUE_FECHA_POSDATADO);
			AddParameter(cmd, "CHEQUE_FECHA_VENCIMIENTO",
				value.IsCHEQUE_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CHEQUE_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CHEQUE_NOMBRE_EMISOR", value.CHEQUE_NOMBRE_EMISOR);
			AddParameter(cmd, "CHEQUE_NOMBRE_BENEFICIARIO", value.CHEQUE_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_NRO_CHEQUE", value.CHEQUE_NRO_CHEQUE);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "MONTO_VALOR",
				value.IsMONTO_VALORNull ? DBNull.Value : (object)value.MONTO_VALOR);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			AddParameter(cmd, "MONTO_COMISION", value.MONTO_COMISION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESEMBOLSOS_GIROS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESEMBOLSOS_GIROS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESEMBOLSOS_GIROSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESEMBOLSOS_GIROS</c> table using
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
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
		/// delete records using the <c>FK_DESEM_GIROS_AUTONUMERACION</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return DeleteByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_BANCOS</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return DeleteByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
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
		/// delete records using the <c>FK_DESEM_GIROS_CAJA_TESORERIA</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_CASOS</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
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
		/// delete records using the <c>FK_DESEM_GIROS_CTACTE_CHEQ_REC</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_CTACTE_VALORES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_CTACTE_VALORES</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return DeleteByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return CreateDeleteByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_DEPOSITOS_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_MONEDAS</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return DeleteByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_PROC_TARJETAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return DeleteByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return CreateDeleteByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_SUCULSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_SUCULSALES</c> foreign key.
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return DeleteByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS</c> table using the 
		/// <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIROS_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DESEMBOLSOS_GIROS</c> records that match the specified criteria.
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
		/// to delete <c>DESEMBOLSOS_GIROS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESEMBOLSOS_GIROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESEMBOLSOS_GIROS</c> table.
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		protected DESEMBOLSOS_GIROSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		protected DESEMBOLSOS_GIROSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROSRow"/> objects.</returns>
		protected virtual DESEMBOLSOS_GIROSRow[] MapRecords(IDataReader reader, 
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
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int cheque_ctacte_banco_idColumnIndex = reader.GetOrdinal("CHEQUE_CTACTE_BANCO_ID");
			int cheque_fecha_posdatadoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_POSDATADO");
			int cheque_fecha_vencimientoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_VENCIMIENTO");
			int cheque_nombre_emisorColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_EMISOR");
			int cheque_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_BENEFICIARIO");
			int cheque_nro_cuentaColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CUENTA");
			int cheque_nro_chequeColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CHEQUE");
			int cheque_documento_emisorColumnIndex = reader.GetOrdinal("CHEQUE_DOCUMENTO_EMISOR");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");
			int monto_valorColumnIndex = reader.GetOrdinal("MONTO_VALOR");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int cheque_es_diferidoColumnIndex = reader.GetOrdinal("CHEQUE_ES_DIFERIDO");
			int monto_comisionColumnIndex = reader.GetOrdinal("MONTO_COMISION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESEMBOLSOS_GIROSRow record = new DESEMBOLSOS_GIROSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_ctacte_banco_idColumnIndex))
						record.CHEQUE_CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_fecha_posdatadoColumnIndex))
						record.CHEQUE_FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(cheque_fecha_posdatadoColumnIndex));
					if(!reader.IsDBNull(cheque_fecha_vencimientoColumnIndex))
						record.CHEQUE_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cheque_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_emisorColumnIndex))
						record.CHEQUE_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cheque_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_beneficiarioColumnIndex))
						record.CHEQUE_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cheque_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cheque_nro_cuentaColumnIndex))
						record.CHEQUE_NRO_CUENTA = Convert.ToString(reader.GetValue(cheque_nro_cuentaColumnIndex));
					if(!reader.IsDBNull(cheque_nro_chequeColumnIndex))
						record.CHEQUE_NRO_CHEQUE = Convert.ToString(reader.GetValue(cheque_nro_chequeColumnIndex));
					if(!reader.IsDBNull(cheque_documento_emisorColumnIndex))
						record.CHEQUE_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(cheque_documento_emisorColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_tarjeta_idColumnIndex))
						record.CTACTE_PROCESADORA_TARJETA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_tarjeta_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_valorColumnIndex))
						record.MONTO_VALOR = Math.Round(Convert.ToDecimal(reader.GetValue(monto_valorColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_es_diferidoColumnIndex))
						record.CHEQUE_ES_DIFERIDO = Convert.ToString(reader.GetValue(cheque_es_diferidoColumnIndex));
					record.MONTO_COMISION = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comisionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESEMBOLSOS_GIROSRow[])(recordList.ToArray(typeof(DESEMBOLSOS_GIROSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESEMBOLSOS_GIROSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESEMBOLSOS_GIROSRow"/> object.</returns>
		protected virtual DESEMBOLSOS_GIROSRow MapRow(DataRow row)
		{
			DESEMBOLSOS_GIROSRow mappedObject = new DESEMBOLSOS_GIROSRow();
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
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
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
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CHEQUE_CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_FECHA_POSDATADO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CHEQUE_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CUENTA"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CUENTA = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CHEQUE"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CHEQUE = (string)row[dataColumn];
			// Column "CHEQUE_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_TARJETA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_TARJETA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_TARJETA_ID = (decimal)row[dataColumn];
			// Column "MONTO_VALOR"
			dataColumn = dataTable.Columns["MONTO_VALOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_VALOR = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CHEQUE_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ES_DIFERIDO = (string)row[dataColumn];
			// Column "MONTO_COMISION"
			dataColumn = dataTable.Columns["MONTO_COMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESEMBOLSOS_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESEMBOLSOS_GIROS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CHEQUE_CTACTE_BANCO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CHEQUE_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_VALOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHEQUE_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MONTO_COMISION", typeof(decimal));
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

				case "SUCURSAL_ORIGEN_ID":
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

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NRO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NRO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_TARJETA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_VALOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_COMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESEMBOLSOS_GIROSCollection_Base class
}  // End of namespace
