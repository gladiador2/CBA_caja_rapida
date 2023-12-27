// <fileinfo name="CTACTE_CHEQUES_RECIBIDOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_RECIBIDOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_RECIBIDOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_RECIBIDOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string NUMERO_CHEQUEColumnName = "NUMERO_CHEQUE";
		public const string NOMBRE_EMISORColumnName = "NOMBRE_EMISOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_POSDATADOColumnName = "FECHA_POSDATADO";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_COBROColumnName = "FECHA_COBRO";
		public const string FECHA_RECHAZOColumnName = "FECHA_RECHAZO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONTOColumnName = "MONTO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string CUSTODIA_VALORES_IDColumnName = "CUSTODIA_VALORES_ID";
		public const string MOTIVO_RECHAZOColumnName = "MOTIVO_RECHAZO";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string NUMERO_DOCUMENTO_EMISORColumnName = "NUMERO_DOCUMENTO_EMISOR";
		public const string ESTUDIO_JURIDICOColumnName = "ESTUDIO_JURIDICO";
		public const string CHEQUE_ESTADO_IDColumnName = "CHEQUE_ESTADO_ID";
		public const string CASO_CREADOR_IDColumnName = "CASO_CREADOR_ID";
		public const string FUNCIONARIO_ASIGNADO_IDColumnName = "FUNCIONARIO_ASIGNADO_ID";
		public const string DESCUENTO_DOCUMENTOS_IDColumnName = "DESCUENTO_DOCUMENTOS_ID";
		public const string ES_DIFERIDOColumnName = "ES_DIFERIDO";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_RECIBIDOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_RECIBIDOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_RECIBIDOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_RECIBIDOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CHEQUES_RECIBIDOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByCUSTODIA_VALORES_ID(decimal custodia_valores_id)
		{
			return GetByCUSTODIA_VALORES_ID(custodia_valores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByCUSTODIA_VALORES_ID(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return MapRecords(CreateGetByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCUSTODIA_VALORES_IDAsDataTable(decimal custodia_valores_id)
		{
			return GetByCUSTODIA_VALORES_IDAsDataTable(custodia_valores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUSTODIA_VALORES_IDAsDataTable(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUSTODIA_VALORES_IDCommand(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			string whereSql = "";
			if(custodia_valores_idNull)
				whereSql += "CUSTODIA_VALORES_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!custodia_valores_idNull)
				AddParameter(cmd, "CUSTODIA_VALORES_ID", custodia_valores_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByDESCUENTO_DOCUMENTOS_ID(decimal descuento_documentos_id)
		{
			return GetByDESCUENTO_DOCUMENTOS_ID(descuento_documentos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="descuento_documentos_idNull">true if the method ignores the descuento_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByDESCUENTO_DOCUMENTOS_ID(decimal descuento_documentos_id, bool descuento_documentos_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTOS_IDCommand(descuento_documentos_id, descuento_documentos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_DOCUMENTOS_IDAsDataTable(decimal descuento_documentos_id)
		{
			return GetByDESCUENTO_DOCUMENTOS_IDAsDataTable(descuento_documentos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="descuento_documentos_idNull">true if the method ignores the descuento_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTOS_IDAsDataTable(decimal descuento_documentos_id, bool descuento_documentos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTOS_IDCommand(descuento_documentos_id, descuento_documentos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="descuento_documentos_idNull">true if the method ignores the descuento_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTOS_IDCommand(decimal descuento_documentos_id, bool descuento_documentos_idNull)
		{
			string whereSql = "";
			if(descuento_documentos_idNull)
				whereSql += "DESCUENTO_DOCUMENTOS_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_documentos_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTOS_ID", descuento_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByFUNCIONARIO_ASIGNADO_ID(decimal funcionario_asignado_id)
		{
			return GetByFUNCIONARIO_ASIGNADO_ID(funcionario_asignado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <param name="funcionario_asignado_idNull">true if the method ignores the funcionario_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByFUNCIONARIO_ASIGNADO_ID(decimal funcionario_asignado_id, bool funcionario_asignado_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ASIGNADO_IDCommand(funcionario_asignado_id, funcionario_asignado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ASIGNADO_IDAsDataTable(decimal funcionario_asignado_id)
		{
			return GetByFUNCIONARIO_ASIGNADO_IDAsDataTable(funcionario_asignado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <param name="funcionario_asignado_idNull">true if the method ignores the funcionario_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ASIGNADO_IDAsDataTable(decimal funcionario_asignado_id, bool funcionario_asignado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ASIGNADO_IDCommand(funcionario_asignado_id, funcionario_asignado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <param name="funcionario_asignado_idNull">true if the method ignores the funcionario_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ASIGNADO_IDCommand(decimal funcionario_asignado_id, bool funcionario_asignado_idNull)
		{
			string whereSql = "";
			if(funcionario_asignado_idNull)
				whereSql += "FUNCIONARIO_ASIGNADO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ASIGNADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ASIGNADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_asignado_idNull)
				AddParameter(cmd, "FUNCIONARIO_ASIGNADO_ID", funcionario_asignado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByCASO_CREADOR_ID(decimal caso_creador_id)
		{
			return GetByCASO_CREADOR_ID(caso_creador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <param name="caso_creador_idNull">true if the method ignores the caso_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByCASO_CREADOR_ID(decimal caso_creador_id, bool caso_creador_idNull)
		{
			return MapRecords(CreateGetByCASO_CREADOR_IDCommand(caso_creador_id, caso_creador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_CREADOR_IDAsDataTable(decimal caso_creador_id)
		{
			return GetByCASO_CREADOR_IDAsDataTable(caso_creador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_IDAsDataTable(decimal ctacte_banco_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_RECIBIDOS_BANCO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_IDAsDataTable(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_RECIBIDOSRow[] GetByCHEQUE_ESTADO_ID(decimal cheque_estado_id)
		{
			return GetByCHEQUE_ESTADO_ID(cheque_estado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="cheque_estado_idNull">true if the method ignores the cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByCHEQUE_ESTADO_ID(decimal cheque_estado_id, bool cheque_estado_idNull)
		{
			return MapRecords(CreateGetByCHEQUE_ESTADO_IDCommand(cheque_estado_id, cheque_estado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHEQUE_ESTADO_IDAsDataTable(decimal cheque_estado_id)
		{
			return GetByCHEQUE_ESTADO_IDAsDataTable(cheque_estado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_RECIBIDOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHQ_RECIBIDOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHQ_RECIBIDOS_MONEDA</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CHEQUES_RECIBIDOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CHEQUES_RECIBIDOS (" +
				"ID, " +
				"CTACTE_BANCO_ID, " +
				"NUMERO_CUENTA, " +
				"NUMERO_CHEQUE, " +
				"NOMBRE_EMISOR, " +
				"NOMBRE_BENEFICIARIO, " +
				"FECHA_CREACION, " +
				"FECHA_POSDATADO, " +
				"FECHA_VENCIMIENTO, " +
				"FECHA_COBRO, " +
				"FECHA_RECHAZO, " +
				"MONEDA_ID, " +
				"MONTO, " +
				"COTIZACION_MONEDA, " +
				"DEPOSITO_BANCARIO_ID, " +
				"CUSTODIA_VALORES_ID, " +
				"MOTIVO_RECHAZO, " +
				"CHEQUE_DE_TERCEROS, " +
				"NUMERO_DOCUMENTO_EMISOR, " +
				"ESTUDIO_JURIDICO, " +
				"CHEQUE_ESTADO_ID, " +
				"CASO_CREADOR_ID, " +
				"FUNCIONARIO_ASIGNADO_ID, " +
				"DESCUENTO_DOCUMENTOS_ID, " +
				"ES_DIFERIDO, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUENTA") + ", " +
				_db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_COBRO") + ", " +
				_db.CreateSqlParameterName("FECHA_RECHAZO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("CUSTODIA_VALORES_ID") + ", " +
				_db.CreateSqlParameterName("MOTIVO_RECHAZO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				_db.CreateSqlParameterName("NUMERO_DOCUMENTO_EMISOR") + ", " +
				_db.CreateSqlParameterName("ESTUDIO_JURIDICO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ASIGNADO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_ID") + ", " +
				_db.CreateSqlParameterName("ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_BANCO_ID", value.CTACTE_BANCO_ID);
			AddParameter(cmd, "NUMERO_CUENTA", value.NUMERO_CUENTA);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO", value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_COBRO",
				value.IsFECHA_COBRONull ? DBNull.Value : (object)value.FECHA_COBRO);
			AddParameter(cmd, "FECHA_RECHAZO",
				value.IsFECHA_RECHAZONull ? DBNull.Value : (object)value.FECHA_RECHAZO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "CUSTODIA_VALORES_ID",
				value.IsCUSTODIA_VALORES_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALORES_ID);
			AddParameter(cmd, "MOTIVO_RECHAZO", value.MOTIVO_RECHAZO);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "NUMERO_DOCUMENTO_EMISOR", value.NUMERO_DOCUMENTO_EMISOR);
			AddParameter(cmd, "ESTUDIO_JURIDICO", value.ESTUDIO_JURIDICO);
			AddParameter(cmd, "CHEQUE_ESTADO_ID",
				value.IsCHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CHEQUE_ESTADO_ID);
			AddParameter(cmd, "CASO_CREADOR_ID",
				value.IsCASO_CREADOR_IDNull ? DBNull.Value : (object)value.CASO_CREADOR_ID);
			AddParameter(cmd, "FUNCIONARIO_ASIGNADO_ID",
				value.IsFUNCIONARIO_ASIGNADO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ASIGNADO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_ID",
				value.IsDESCUENTO_DOCUMENTOS_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTOS_ID);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CHEQUES_RECIBIDOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CHEQUES_RECIBIDOS SET " +
				"CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				"NUMERO_CUENTA=" + _db.CreateSqlParameterName("NUMERO_CUENTA") + ", " +
				"NUMERO_CHEQUE=" + _db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				"NOMBRE_EMISOR=" + _db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_POSDATADO=" + _db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"FECHA_COBRO=" + _db.CreateSqlParameterName("FECHA_COBRO") + ", " +
				"FECHA_RECHAZO=" + _db.CreateSqlParameterName("FECHA_RECHAZO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				"CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID") + ", " +
				"MOTIVO_RECHAZO=" + _db.CreateSqlParameterName("MOTIVO_RECHAZO") + ", " +
				"CHEQUE_DE_TERCEROS=" + _db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				"NUMERO_DOCUMENTO_EMISOR=" + _db.CreateSqlParameterName("NUMERO_DOCUMENTO_EMISOR") + ", " +
				"ESTUDIO_JURIDICO=" + _db.CreateSqlParameterName("ESTUDIO_JURIDICO") + ", " +
				"CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CHEQUE_ESTADO_ID") + ", " +
				"CASO_CREADOR_ID=" + _db.CreateSqlParameterName("CASO_CREADOR_ID") + ", " +
				"FUNCIONARIO_ASIGNADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ASIGNADO_ID") + ", " +
				"DESCUENTO_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_ID") + ", " +
				"ES_DIFERIDO=" + _db.CreateSqlParameterName("ES_DIFERIDO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_BANCO_ID", value.CTACTE_BANCO_ID);
			AddParameter(cmd, "NUMERO_CUENTA", value.NUMERO_CUENTA);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO", value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_COBRO",
				value.IsFECHA_COBRONull ? DBNull.Value : (object)value.FECHA_COBRO);
			AddParameter(cmd, "FECHA_RECHAZO",
				value.IsFECHA_RECHAZONull ? DBNull.Value : (object)value.FECHA_RECHAZO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "CUSTODIA_VALORES_ID",
				value.IsCUSTODIA_VALORES_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALORES_ID);
			AddParameter(cmd, "MOTIVO_RECHAZO", value.MOTIVO_RECHAZO);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "NUMERO_DOCUMENTO_EMISOR", value.NUMERO_DOCUMENTO_EMISOR);
			AddParameter(cmd, "ESTUDIO_JURIDICO", value.ESTUDIO_JURIDICO);
			AddParameter(cmd, "CHEQUE_ESTADO_ID",
				value.IsCHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CHEQUE_ESTADO_ID);
			AddParameter(cmd, "CASO_CREADOR_ID",
				value.IsCASO_CREADOR_IDNull ? DBNull.Value : (object)value.CASO_CREADOR_ID);
			AddParameter(cmd, "FUNCIONARIO_ASIGNADO_ID",
				value.IsFUNCIONARIO_ASIGNADO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ASIGNADO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_ID",
				value.IsDESCUENTO_DOCUMENTOS_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTOS_ID);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_RECIBIDOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_RECIBIDOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CHEQUES_RECIBIDOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using
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
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALORES_ID(decimal custodia_valores_id)
		{
			return DeleteByCUSTODIA_VALORES_ID(custodia_valores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALORES_ID(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return CreateDeleteByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_RECIB_CUSTODIA</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUSTODIA_VALORES_IDCommand(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			string whereSql = "";
			if(custodia_valores_idNull)
				whereSql += "CUSTODIA_VALORES_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!custodia_valores_idNull)
				AddParameter(cmd, "CUSTODIA_VALORES_ID", custodia_valores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTOS_ID(decimal descuento_documentos_id)
		{
			return DeleteByDESCUENTO_DOCUMENTOS_ID(descuento_documentos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="descuento_documentos_idNull">true if the method ignores the descuento_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTOS_ID(decimal descuento_documentos_id, bool descuento_documentos_idNull)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTOS_IDCommand(descuento_documentos_id, descuento_documentos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_RECIB_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_id">The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="descuento_documentos_idNull">true if the method ignores the descuento_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTOS_IDCommand(decimal descuento_documentos_id, bool descuento_documentos_idNull)
		{
			string whereSql = "";
			if(descuento_documentos_idNull)
				whereSql += "DESCUENTO_DOCUMENTOS_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_documentos_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTOS_ID", descuento_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ASIGNADO_ID(decimal funcionario_asignado_id)
		{
			return DeleteByFUNCIONARIO_ASIGNADO_ID(funcionario_asignado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <param name="funcionario_asignado_idNull">true if the method ignores the funcionario_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ASIGNADO_ID(decimal funcionario_asignado_id, bool funcionario_asignado_idNull)
		{
			return CreateDeleteByFUNCIONARIO_ASIGNADO_IDCommand(funcionario_asignado_id, funcionario_asignado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_RECIB_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_asignado_id">The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</param>
		/// <param name="funcionario_asignado_idNull">true if the method ignores the funcionario_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ASIGNADO_IDCommand(decimal funcionario_asignado_id, bool funcionario_asignado_idNull)
		{
			string whereSql = "";
			if(funcionario_asignado_idNull)
				whereSql += "FUNCIONARIO_ASIGNADO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ASIGNADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ASIGNADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_asignado_idNull)
				AddParameter(cmd, "FUNCIONARIO_ASIGNADO_ID", funcionario_asignado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="caso_creador_id">The <c>CASO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_CREADOR_ID(decimal caso_creador_id)
		{
			return DeleteByCASO_CREADOR_ID(caso_creador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHQ_RECIB_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return CreateDeleteByCTACTE_BANCO_IDCommand(ctacte_banco_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_RECIBIDOS_BANCO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return DeleteByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHQ_RECIBIDOS_DEP</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
		/// </summary>
		/// <param name="cheque_estado_id">The <c>CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_ESTADO_ID(decimal cheque_estado_id)
		{
			return DeleteByCHEQUE_ESTADO_ID(cheque_estado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHQ_RECIBIDOS_EST_ID</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table using the 
		/// <c>FK_CTACTE_CHQ_RECIBIDOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHQ_RECIBIDOS_MONEDA</c> foreign key.
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
		/// Deletes <c>CTACTE_CHEQUES_RECIBIDOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CHEQUES_RECIBIDOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CHEQUES_RECIBIDOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_RECIBIDOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_RECIBIDOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_RECIBIDOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int numero_chequeColumnIndex = reader.GetOrdinal("NUMERO_CHEQUE");
			int nombre_emisorColumnIndex = reader.GetOrdinal("NOMBRE_EMISOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_posdatadoColumnIndex = reader.GetOrdinal("FECHA_POSDATADO");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_cobroColumnIndex = reader.GetOrdinal("FECHA_COBRO");
			int fecha_rechazoColumnIndex = reader.GetOrdinal("FECHA_RECHAZO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int custodia_valores_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALORES_ID");
			int motivo_rechazoColumnIndex = reader.GetOrdinal("MOTIVO_RECHAZO");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int numero_documento_emisorColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO_EMISOR");
			int estudio_juridicoColumnIndex = reader.GetOrdinal("ESTUDIO_JURIDICO");
			int cheque_estado_idColumnIndex = reader.GetOrdinal("CHEQUE_ESTADO_ID");
			int caso_creador_idColumnIndex = reader.GetOrdinal("CASO_CREADOR_ID");
			int funcionario_asignado_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ASIGNADO_ID");
			int descuento_documentos_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTOS_ID");
			int es_diferidoColumnIndex = reader.GetOrdinal("ES_DIFERIDO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_RECIBIDOSRow record = new CTACTE_CHEQUES_RECIBIDOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_cuentaColumnIndex))
						record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
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
					if(!reader.IsDBNull(fecha_rechazoColumnIndex))
						record.FECHA_RECHAZO = Convert.ToDateTime(reader.GetValue(fecha_rechazoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valores_idColumnIndex))
						record.CUSTODIA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valores_idColumnIndex)), 9);
					if(!reader.IsDBNull(motivo_rechazoColumnIndex))
						record.MOTIVO_RECHAZO = Convert.ToString(reader.GetValue(motivo_rechazoColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					if(!reader.IsDBNull(numero_documento_emisorColumnIndex))
						record.NUMERO_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(numero_documento_emisorColumnIndex));
					if(!reader.IsDBNull(estudio_juridicoColumnIndex))
						record.ESTUDIO_JURIDICO = Convert.ToString(reader.GetValue(estudio_juridicoColumnIndex));
					if(!reader.IsDBNull(cheque_estado_idColumnIndex))
						record.CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_creador_idColumnIndex))
						record.CASO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_asignado_idColumnIndex))
						record.FUNCIONARIO_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documentos_idColumnIndex))
						record.DESCUENTO_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documentos_idColumnIndex)), 9);
					record.ES_DIFERIDO = Convert.ToString(reader.GetValue(es_diferidoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_RECIBIDOSRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_RECIBIDOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_RECIBIDOSRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_RECIBIDOSRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_RECIBIDOSRow mappedObject = new CTACTE_CHEQUES_RECIBIDOSRow();
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
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
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
			// Column "FECHA_RECHAZO"
			dataColumn = dataTable.Columns["FECHA_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECHAZO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALORES_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALORES_ID = (decimal)row[dataColumn];
			// Column "MOTIVO_RECHAZO"
			dataColumn = dataTable.Columns["MOTIVO_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_RECHAZO = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "NUMERO_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "ESTUDIO_JURIDICO"
			dataColumn = dataTable.Columns["ESTUDIO_JURIDICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTUDIO_JURIDICO = (string)row[dataColumn];
			// Column "CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "CASO_CREADOR_ID"
			dataColumn = dataTable.Columns["CASO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ASIGNADO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "ES_DIFERIDO"
			dataColumn = dataTable.Columns["ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DIFERIDO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_RECIBIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_RECIBIDOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
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
			dataColumn = dataTable.Columns.Add("FECHA_RECHAZO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALORES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOTIVO_RECHAZO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ESTUDIO_JURIDICO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_CREADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ASIGNADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "FECHA_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOTIVO_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTUDIO_JURIDICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_RECIBIDOSCollection_Base class
}  // End of namespace
