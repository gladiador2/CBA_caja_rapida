// <fileinfo name="CTACTE_CHEQUES_GIRADOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_GIRADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_GIRADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_GIRADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string NUMERO_CHEQUEColumnName = "NUMERO_CHEQUE";
		public const string NOMBRE_EMISORColumnName = "NOMBRE_EMISOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_POSDATADOColumnName = "FECHA_POSDATADO";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_COBROColumnName = "FECHA_COBRO";
		public const string FECHA_ENTREGAColumnName = "FECHA_ENTREGA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string SALDO_AFECTADOColumnName = "SALDO_AFECTADO";
		public const string MOTIVO_ANULACIONColumnName = "MOTIVO_ANULACION";
		public const string CHEQUE_ESTADO_IDColumnName = "CHEQUE_ESTADO_ID";
		public const string CASO_CREADOR_IDColumnName = "CASO_CREADOR_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string ES_DIFERIDOColumnName = "ES_DIFERIDO";
		public const string ESTADOColumnName = "ESTADO";
		public const string NUMERO_CTA_BENEFICIARIOColumnName = "NUMERO_CTA_BENEFICIARIO";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_GIRADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_GIRADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_GIRADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_GIRADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_GIRADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_GIRADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CHEQUES_GIRADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CHEQUES_GIRADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_GIRADOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_GIRADOSRow[] GetByCASO_CREADOR_ID(decimal caso_creador_id)
		{
			return GetByCASO_CREADOR_ID(caso_creador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByCASO_CREADOR_ID(decimal caso_creador_id, bool caso_creador_idNull)
		{
			return MapRecords(CreateGetByCASO_CREADOR_IDCommand(caso_creador_id, caso_creador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_CREADOR_IDAsDataTable(decimal caso_creador_id)
		{
			return GetByCASO_CREADOR_IDAsDataTable(caso_creador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_CREADOR_IDAsDataTable(decimal caso_creador_id, bool caso_creador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_CREADOR_IDCommand(caso_creador_id, caso_creador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_CREADOR_IDCommand(decimal caso_creador_id, bool caso_creador_idNull)
		{
			string whereSql = "";
			if(caso_creador_idNull)
				whereSql += "CASO_CREADOR_ID IS NULL";
			else
				whereSql += "CASO_CREADOR_ID=" + _db.CreateSqlParameterName("CASO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_creador_idNull)
				AddParameter(cmd, "CASO_CREADOR_ID", caso_creador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_GIRADOSRow[] GetByCHEQUE_ESTADO_ID(decimal cheque_estado_id)
		{
			return GetByCHEQUE_ESTADO_ID(cheque_estado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByCHEQUE_ESTADO_ID(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			return MapRecords(CreateGetByCHEQUE_ESTADO_IDCommand(cheque_estado_id, cheque_estado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHEQUE_ESTADO_IDAsDataTable(decimal cheque_estado_id)
		{
			return GetByCHEQUE_ESTADO_IDAsDataTable(cheque_estado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCHEQUE_ESTADO_IDAsDataTable(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCHEQUE_ESTADO_IDCommand(cheque_estado_id, cheque_estado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCHEQUE_ESTADO_IDCommand(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			string whereSql = "";
			if(cheque_estado_idNull)
				whereSql += "CHEQUE_ESTADO_ID IS NULL";
			else
				whereSql += "CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CHEQUE_ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cheque_estado_idNull)
				AddParameter(cmd, "CHEQUE_ESTADO_ID", cheque_estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_IDAsDataTable(decimal ctacte_banco_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_GIRADOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCO_IDCommand(decimal ctacte_banco_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCO_ID", ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_GIRADOS_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_GIRADOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_GIRADOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_GIRADOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CHEQUES_GIRADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CHEQUES_GIRADOS (" +
				"ID, " +
				"CTACTE_BANCO_ID, " +
				"CTACTE_BANCARIA_ID, " +
				"NUMERO_CHEQUE, " +
				"NOMBRE_EMISOR, " +
				"NOMBRE_BENEFICIARIO, " +
				"FECHA_CREACION, " +
				"FECHA_POSDATADO, " +
				"FECHA_VENCIMIENTO, " +
				"FECHA_COBRO, " +
				"FECHA_ENTREGA, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"SALDO_AFECTADO, " +
				"MOTIVO_ANULACION, " +
				"CHEQUE_ESTADO_ID, " +
				"CASO_CREADOR_ID, " +
				"AUTONUMERACION_ID, " +
				"ES_DIFERIDO, " +
				"ESTADO, " +
				"NUMERO_CTA_BENEFICIARIO, " +
				"OBSERVACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_COBRO") + ", " +
				_db.CreateSqlParameterName("FECHA_ENTREGA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("SALDO_AFECTADO") + ", " +
				_db.CreateSqlParameterName("MOTIVO_ANULACION") + ", " +
				_db.CreateSqlParameterName("CHEQUE_ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("NUMERO_CTA_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_BANCO_ID", value.CTACTE_BANCO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO", value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_COBRO",
				value.IsFECHA_COBRONull ? DBNull.Value : (object)value.FECHA_COBRO);
			AddParameter(cmd, "FECHA_ENTREGA",
				value.IsFECHA_ENTREGANull ? DBNull.Value : (object)value.FECHA_ENTREGA);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "SALDO_AFECTADO", value.SALDO_AFECTADO);
			AddParameter(cmd, "MOTIVO_ANULACION", value.MOTIVO_ANULACION);
			AddParameter(cmd, "CHEQUE_ESTADO_ID",
				value.IsCHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CHEQUE_ESTADO_ID);
			AddParameter(cmd, "CASO_CREADOR_ID",
				value.IsCASO_CREADOR_IDNull ? DBNull.Value : (object)value.CASO_CREADOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NUMERO_CTA_BENEFICIARIO", value.NUMERO_CTA_BENEFICIARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_GIRADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CHEQUES_GIRADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CHEQUES_GIRADOS SET " +
				"CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				"CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				"NUMERO_CHEQUE=" + _db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				"NOMBRE_EMISOR=" + _db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_POSDATADO=" + _db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"FECHA_COBRO=" + _db.CreateSqlParameterName("FECHA_COBRO") + ", " +
				"FECHA_ENTREGA=" + _db.CreateSqlParameterName("FECHA_ENTREGA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"SALDO_AFECTADO=" + _db.CreateSqlParameterName("SALDO_AFECTADO") + ", " +
				"MOTIVO_ANULACION=" + _db.CreateSqlParameterName("MOTIVO_ANULACION") + ", " +
				"CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CHEQUE_ESTADO_ID") + ", " +
				"CASO_CREADOR_ID=" + _db.CreateSqlParameterName("CASO_CREADOR_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"ES_DIFERIDO=" + _db.CreateSqlParameterName("ES_DIFERIDO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"NUMERO_CTA_BENEFICIARIO=" + _db.CreateSqlParameterName("NUMERO_CTA_BENEFICIARIO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_BANCO_ID", value.CTACTE_BANCO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO", value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_COBRO",
				value.IsFECHA_COBRONull ? DBNull.Value : (object)value.FECHA_COBRO);
			AddParameter(cmd, "FECHA_ENTREGA",
				value.IsFECHA_ENTREGANull ? DBNull.Value : (object)value.FECHA_ENTREGA);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "SALDO_AFECTADO", value.SALDO_AFECTADO);
			AddParameter(cmd, "MOTIVO_ANULACION", value.MOTIVO_ANULACION);
			AddParameter(cmd, "CHEQUE_ESTADO_ID",
				value.IsCHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CHEQUE_ESTADO_ID);
			AddParameter(cmd, "CASO_CREADOR_ID",
				value.IsCASO_CREADOR_IDNull ? DBNull.Value : (object)value.CASO_CREADOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NUMERO_CTA_BENEFICIARIO", value.NUMERO_CTA_BENEFICIARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_GIRADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_GIRADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_GIRADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CHEQUES_GIRADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CHEQUES_GIRADOS</c> table using
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
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHQ_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_CREADOR_ID(decimal caso_creador_id)
		{
			return DeleteByCASO_CREADOR_ID(caso_creador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_CREADOR_ID(decimal caso_creador_id, bool caso_creador_idNull)
		{
			return CreateDeleteByCASO_CREADOR_IDCommand(caso_creador_id, caso_creador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_GIR_CASO_CR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_CREADOR_IDCommand(decimal caso_creador_id, bool caso_creador_idNull)
		{
			string whereSql = "";
			if(caso_creador_idNull)
				whereSql += "CASO_CREADOR_ID IS NULL";
			else
				whereSql += "CASO_CREADOR_ID=" + _db.CreateSqlParameterName("CASO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_creador_idNull)
				AddParameter(cmd, "CASO_CREADOR_ID", caso_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_ESTADO_ID(decimal cheque_estado_id)
		{
			return DeleteByCHEQUE_ESTADO_ID(cheque_estado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_ESTADO_ID(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			return CreateDeleteByCHEQUE_ESTADO_IDCommand(cheque_estado_id, cheque_estado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_GIR_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCHEQUE_ESTADO_IDCommand(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			string whereSql = "";
			if(cheque_estado_idNull)
				whereSql += "CHEQUE_ESTADO_ID IS NULL";
			else
				whereSql += "CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CHEQUE_ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cheque_estado_idNull)
				AddParameter(cmd, "CHEQUE_ESTADO_ID", cheque_estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIRADOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return CreateDeleteByCTACTE_BANCO_IDCommand(ctacte_banco_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_GIRADOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCO_IDCommand(decimal ctacte_banco_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCO_ID", ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIRADOS_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return CreateDeleteByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_GIRADOS_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_GIRADOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHQ_GIRADOS_MONEDA</c> foreign key.
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
		/// Deletes <c>CTACTE_CHEQUES_GIRADOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CHEQUES_GIRADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CHEQUES_GIRADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CHEQUES_GIRADOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_GIRADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_GIRADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_GIRADOSRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_GIRADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int numero_chequeColumnIndex = reader.GetOrdinal("NUMERO_CHEQUE");
			int nombre_emisorColumnIndex = reader.GetOrdinal("NOMBRE_EMISOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_posdatadoColumnIndex = reader.GetOrdinal("FECHA_POSDATADO");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_cobroColumnIndex = reader.GetOrdinal("FECHA_COBRO");
			int fecha_entregaColumnIndex = reader.GetOrdinal("FECHA_ENTREGA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int saldo_afectadoColumnIndex = reader.GetOrdinal("SALDO_AFECTADO");
			int motivo_anulacionColumnIndex = reader.GetOrdinal("MOTIVO_ANULACION");
			int cheque_estado_idColumnIndex = reader.GetOrdinal("CHEQUE_ESTADO_ID");
			int caso_creador_idColumnIndex = reader.GetOrdinal("CASO_CREADOR_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int es_diferidoColumnIndex = reader.GetOrdinal("ES_DIFERIDO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int numero_cta_beneficiarioColumnIndex = reader.GetOrdinal("NUMERO_CTA_BENEFICIARIO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_GIRADOSRow record = new CTACTE_CHEQUES_GIRADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					record.NUMERO_CHEQUE = Convert.ToString(reader.GetValue(numero_chequeColumnIndex));
					if(!reader.IsDBNull(nombre_emisorColumnIndex))
						record.NOMBRE_EMISOR = Convert.ToString(reader.GetValue(nombre_emisorColumnIndex));
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(fecha_posdatadoColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_cobroColumnIndex))
						record.FECHA_COBRO = Convert.ToDateTime(reader.GetValue(fecha_cobroColumnIndex));
					if(!reader.IsDBNull(fecha_entregaColumnIndex))
						record.FECHA_ENTREGA = Convert.ToDateTime(reader.GetValue(fecha_entregaColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.SALDO_AFECTADO = Convert.ToString(reader.GetValue(saldo_afectadoColumnIndex));
					if(!reader.IsDBNull(motivo_anulacionColumnIndex))
						record.MOTIVO_ANULACION = Convert.ToString(reader.GetValue(motivo_anulacionColumnIndex));
					if(!reader.IsDBNull(cheque_estado_idColumnIndex))
						record.CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_creador_idColumnIndex))
						record.CASO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					record.ES_DIFERIDO = Convert.ToString(reader.GetValue(es_diferidoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(numero_cta_beneficiarioColumnIndex))
						record.NUMERO_CTA_BENEFICIARIO = Convert.ToString(reader.GetValue(numero_cta_beneficiarioColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_GIRADOSRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_GIRADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_GIRADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_GIRADOSRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_GIRADOSRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_GIRADOSRow mappedObject = new CTACTE_CHEQUES_GIRADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSDATADO"
			dataColumn = dataTable.Columns["FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_COBRO"
			dataColumn = dataTable.Columns["FECHA_COBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COBRO = (System.DateTime)row[dataColumn];
			// Column "FECHA_ENTREGA"
			dataColumn = dataTable.Columns["FECHA_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTREGA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "SALDO_AFECTADO"
			dataColumn = dataTable.Columns["SALDO_AFECTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_AFECTADO = (string)row[dataColumn];
			// Column "MOTIVO_ANULACION"
			dataColumn = dataTable.Columns["MOTIVO_ANULACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_ANULACION = (string)row[dataColumn];
			// Column "CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "CASO_CREADOR_ID"
			dataColumn = dataTable.Columns["CASO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "ES_DIFERIDO"
			dataColumn = dataTable.Columns["ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DIFERIDO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NUMERO_CTA_BENEFICIARIO"
			dataColumn = dataTable.Columns["NUMERO_CTA_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CTA_BENEFICIARIO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_GIRADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_GIRADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_COBRO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ENTREGA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SALDO_AFECTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOTIVO_ANULACION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_CREADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CTA_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_COBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_AFECTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MOTIVO_ANULACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_CTA_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_GIRADOSCollection_Base class
}  // End of namespace
