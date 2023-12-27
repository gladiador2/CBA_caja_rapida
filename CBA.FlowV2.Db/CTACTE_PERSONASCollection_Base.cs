// <fileinfo name="CTACTE_PERSONASCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PERSONASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_POSTERGACIONColumnName = "FECHA_POSTERGACION";
		public const string CUOTA_NUMEROColumnName = "CUOTA_NUMERO";
		public const string CUOTA_TOTALColumnName = "CUOTA_TOTAL";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_PAGARE_DOC_IDColumnName = "CTACTE_PAGARE_DOC_ID";
		public const string CTACTE_PAGARE_DET_IDColumnName = "CTACTE_PAGARE_DET_ID";
		public const string CTACTE_PAGO_PERSONA_DET_IDColumnName = "CTACTE_PAGO_PERSONA_DET_ID";
		public const string CTACTE_PAGO_PERSONA_DOC_IDColumnName = "CTACTE_PAGO_PERSONA_DOC_ID";
		public const string CTACTE_PAGO_PERSONA_REC_IDColumnName = "CTACTE_PAGO_PERSONA_REC_ID";
		public const string CALENDARIO_PAGOS_FC_CLI_IDColumnName = "CALENDARIO_PAGOS_FC_CLI_ID";
		public const string CALENDARIO_PAGOS_CR_CLI_IDColumnName = "CALENDARIO_PAGOS_CR_CLI_ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string CTACTE_DOCUMENTO_VENC_IDColumnName = "CTACTE_DOCUMENTO_VENC_ID";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string CONCEPTOColumnName = "CONCEPTO";
		public const string CTACTE_PERSONA_RELACIONADA_IDColumnName = "CTACTE_PERSONA_RELACIONADA_ID";
		public const string JUDICIALColumnName = "JUDICIAL";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string APLICACION_DOCUMENTOS_IDColumnName = "APLICACION_DOCUMENTOS_ID";
		public const string APLICACION_DOCUMENTOS_VAL_IDColumnName = "APLICACION_DOCUMENTOS_VAL_ID";
		public const string APLICACION_DOCUMENTOS_REC_IDColumnName = "APLICACION_DOCUMENTOS_REC_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PERSONASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PERSONASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PERSONASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PERSONASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PERSONASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PERSONASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PERSONASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_ID(decimal aplicacion_documentos_id)
		{
			return GetByAPLICACION_DOCUMENTOS_ID(aplicacion_documentos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_idNull">true if the method ignores the aplicacion_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_ID(decimal aplicacion_documentos_id, bool aplicacion_documentos_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTOS_IDCommand(aplicacion_documentos_id, aplicacion_documentos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCUMENTOS_IDAsDataTable(decimal aplicacion_documentos_id)
		{
			return GetByAPLICACION_DOCUMENTOS_IDAsDataTable(aplicacion_documentos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_idNull">true if the method ignores the aplicacion_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTOS_IDAsDataTable(decimal aplicacion_documentos_id, bool aplicacion_documentos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTOS_IDCommand(aplicacion_documentos_id, aplicacion_documentos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_idNull">true if the method ignores the aplicacion_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTOS_IDCommand(decimal aplicacion_documentos_id, bool aplicacion_documentos_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_idNull)
				whereSql += "APLICACION_DOCUMENTOS_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_documentos_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_ID", aplicacion_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_REC_ID(decimal aplicacion_documentos_rec_id)
		{
			return GetByAPLICACION_DOCUMENTOS_REC_ID(aplicacion_documentos_rec_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_rec_idNull">true if the method ignores the aplicacion_documentos_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_REC_ID(decimal aplicacion_documentos_rec_id, bool aplicacion_documentos_rec_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTOS_REC_IDCommand(aplicacion_documentos_rec_id, aplicacion_documentos_rec_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCUMENTOS_REC_IDAsDataTable(decimal aplicacion_documentos_rec_id)
		{
			return GetByAPLICACION_DOCUMENTOS_REC_IDAsDataTable(aplicacion_documentos_rec_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_rec_idNull">true if the method ignores the aplicacion_documentos_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTOS_REC_IDAsDataTable(decimal aplicacion_documentos_rec_id, bool aplicacion_documentos_rec_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTOS_REC_IDCommand(aplicacion_documentos_rec_id, aplicacion_documentos_rec_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_rec_idNull">true if the method ignores the aplicacion_documentos_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTOS_REC_IDCommand(decimal aplicacion_documentos_rec_id, bool aplicacion_documentos_rec_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_rec_idNull)
				whereSql += "APLICACION_DOCUMENTOS_REC_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_REC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_REC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_documentos_rec_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_REC_ID", aplicacion_documentos_rec_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_VAL_ID(decimal aplicacion_documentos_val_id)
		{
			return GetByAPLICACION_DOCUMENTOS_VAL_ID(aplicacion_documentos_val_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_val_idNull">true if the method ignores the aplicacion_documentos_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByAPLICACION_DOCUMENTOS_VAL_ID(decimal aplicacion_documentos_val_id, bool aplicacion_documentos_val_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTOS_VAL_IDCommand(aplicacion_documentos_val_id, aplicacion_documentos_val_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCUMENTOS_VAL_IDAsDataTable(decimal aplicacion_documentos_val_id)
		{
			return GetByAPLICACION_DOCUMENTOS_VAL_IDAsDataTable(aplicacion_documentos_val_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_val_idNull">true if the method ignores the aplicacion_documentos_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTOS_VAL_IDAsDataTable(decimal aplicacion_documentos_val_id, bool aplicacion_documentos_val_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTOS_VAL_IDCommand(aplicacion_documentos_val_id, aplicacion_documentos_val_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_val_idNull">true if the method ignores the aplicacion_documentos_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTOS_VAL_IDCommand(decimal aplicacion_documentos_val_id, bool aplicacion_documentos_val_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_val_idNull)
				whereSql += "APLICACION_DOCUMENTOS_VAL_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_VAL_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_VAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_documentos_val_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_VAL_ID", aplicacion_documentos_val_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCALENDARIO_PAGOS_FC_CLI_ID(decimal calendario_pagos_fc_cli_id)
		{
			return GetByCALENDARIO_PAGOS_FC_CLI_ID(calendario_pagos_fc_cli_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cli_idNull">true if the method ignores the calendario_pagos_fc_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCALENDARIO_PAGOS_FC_CLI_ID(decimal calendario_pagos_fc_cli_id, bool calendario_pagos_fc_cli_idNull)
		{
			return MapRecords(CreateGetByCALENDARIO_PAGOS_FC_CLI_IDCommand(calendario_pagos_fc_cli_id, calendario_pagos_fc_cli_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCALENDARIO_PAGOS_FC_CLI_IDAsDataTable(decimal calendario_pagos_fc_cli_id)
		{
			return GetByCALENDARIO_PAGOS_FC_CLI_IDAsDataTable(calendario_pagos_fc_cli_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cli_idNull">true if the method ignores the calendario_pagos_fc_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCALENDARIO_PAGOS_FC_CLI_IDAsDataTable(decimal calendario_pagos_fc_cli_id, bool calendario_pagos_fc_cli_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCALENDARIO_PAGOS_FC_CLI_IDCommand(calendario_pagos_fc_cli_id, calendario_pagos_fc_cli_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cli_idNull">true if the method ignores the calendario_pagos_fc_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCALENDARIO_PAGOS_FC_CLI_IDCommand(decimal calendario_pagos_fc_cli_id, bool calendario_pagos_fc_cli_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_cli_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_CLI_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLI_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!calendario_pagos_fc_cli_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLI_ID", calendario_pagos_fc_cli_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCALENDARIO_PAGOS_CR_CLI_ID(decimal calendario_pagos_cr_cli_id)
		{
			return GetByCALENDARIO_PAGOS_CR_CLI_ID(calendario_pagos_cr_cli_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_cr_cli_idNull">true if the method ignores the calendario_pagos_cr_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCALENDARIO_PAGOS_CR_CLI_ID(decimal calendario_pagos_cr_cli_id, bool calendario_pagos_cr_cli_idNull)
		{
			return MapRecords(CreateGetByCALENDARIO_PAGOS_CR_CLI_IDCommand(calendario_pagos_cr_cli_id, calendario_pagos_cr_cli_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCALENDARIO_PAGOS_CR_CLI_IDAsDataTable(decimal calendario_pagos_cr_cli_id)
		{
			return GetByCALENDARIO_PAGOS_CR_CLI_IDAsDataTable(calendario_pagos_cr_cli_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_cr_cli_idNull">true if the method ignores the calendario_pagos_cr_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCALENDARIO_PAGOS_CR_CLI_IDAsDataTable(decimal calendario_pagos_cr_cli_id, bool calendario_pagos_cr_cli_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCALENDARIO_PAGOS_CR_CLI_IDCommand(calendario_pagos_cr_cli_id, calendario_pagos_cr_cli_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_cr_cli_idNull">true if the method ignores the calendario_pagos_cr_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCALENDARIO_PAGOS_CR_CLI_IDCommand(decimal calendario_pagos_cr_cli_id, bool calendario_pagos_cr_cli_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_cr_cli_idNull)
				whereSql += "CALENDARIO_PAGOS_CR_CLI_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_CR_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_CR_CLI_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!calendario_pagos_cr_cli_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_CR_CLI_ID", calendario_pagos_cr_cli_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_CENCEPTO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return MapRecords(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_CENCEPTO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CONCEPTO_IDAsDataTable(decimal ctacte_concepto_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_CENCEPTO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_DOCUMENTO_VENC_ID(decimal ctacte_documento_venc_id)
		{
			return GetByCTACTE_DOCUMENTO_VENC_ID(ctacte_documento_venc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <param name="ctacte_documento_venc_idNull">true if the method ignores the ctacte_documento_venc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_DOCUMENTO_VENC_ID(decimal ctacte_documento_venc_id, bool ctacte_documento_venc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_DOCUMENTO_VENC_IDCommand(ctacte_documento_venc_id, ctacte_documento_venc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_DOCUMENTO_VENC_IDAsDataTable(decimal ctacte_documento_venc_id)
		{
			return GetByCTACTE_DOCUMENTO_VENC_IDAsDataTable(ctacte_documento_venc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <param name="ctacte_documento_venc_idNull">true if the method ignores the ctacte_documento_venc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_DOCUMENTO_VENC_IDAsDataTable(decimal ctacte_documento_venc_id, bool ctacte_documento_venc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_DOCUMENTO_VENC_IDCommand(ctacte_documento_venc_id, ctacte_documento_venc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <param name="ctacte_documento_venc_idNull">true if the method ignores the ctacte_documento_venc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_DOCUMENTO_VENC_IDCommand(decimal ctacte_documento_venc_id, bool ctacte_documento_venc_idNull)
		{
			string whereSql = "";
			if(ctacte_documento_venc_idNull)
				whereSql += "CTACTE_DOCUMENTO_VENC_ID IS NULL";
			else
				whereSql += "CTACTE_DOCUMENTO_VENC_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_VENC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_documento_venc_idNull)
				AddParameter(cmd, "CTACTE_DOCUMENTO_VENC_ID", ctacte_documento_venc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_IDAsDataTable(orden_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_IDAsDataTable(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PAGARE_DOC_ID(decimal ctacte_pagare_doc_id)
		{
			return GetByCTACTE_PAGARE_DOC_ID(ctacte_pagare_doc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pagare_doc_idNull">true if the method ignores the ctacte_pagare_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PAGARE_DOC_ID(decimal ctacte_pagare_doc_id, bool ctacte_pagare_doc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGARE_DOC_IDCommand(ctacte_pagare_doc_id, ctacte_pagare_doc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGARE_DOC_IDAsDataTable(decimal ctacte_pagare_doc_id)
		{
			return GetByCTACTE_PAGARE_DOC_IDAsDataTable(ctacte_pagare_doc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pagare_doc_idNull">true if the method ignores the ctacte_pagare_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGARE_DOC_IDAsDataTable(decimal ctacte_pagare_doc_id, bool ctacte_pagare_doc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGARE_DOC_IDCommand(ctacte_pagare_doc_id, ctacte_pagare_doc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pagare_doc_idNull">true if the method ignores the ctacte_pagare_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGARE_DOC_IDCommand(decimal ctacte_pagare_doc_id, bool ctacte_pagare_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_doc_idNull)
				whereSql += "CTACTE_PAGARE_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DOC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pagare_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DOC_ID", ctacte_pagare_doc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_REC_ID(decimal ctacte_pago_persona_rec_id)
		{
			return GetByCTACTE_PAGO_PERSONA_REC_ID(ctacte_pago_persona_rec_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_rec_idNull">true if the method ignores the ctacte_pago_persona_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_REC_ID(decimal ctacte_pago_persona_rec_id, bool ctacte_pago_persona_rec_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_REC_IDCommand(ctacte_pago_persona_rec_id, ctacte_pago_persona_rec_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_REC_IDAsDataTable(decimal ctacte_pago_persona_rec_id)
		{
			return GetByCTACTE_PAGO_PERSONA_REC_IDAsDataTable(ctacte_pago_persona_rec_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_rec_idNull">true if the method ignores the ctacte_pago_persona_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_REC_IDAsDataTable(decimal ctacte_pago_persona_rec_id, bool ctacte_pago_persona_rec_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_REC_IDCommand(ctacte_pago_persona_rec_id, ctacte_pago_persona_rec_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_rec_idNull">true if the method ignores the ctacte_pago_persona_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_REC_IDCommand(decimal ctacte_pago_persona_rec_id, bool ctacte_pago_persona_rec_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_rec_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_REC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_REC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_REC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_rec_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_REC_ID", ctacte_pago_persona_rec_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DET_ID(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(decimal ctacte_pago_persona_det_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_DET_IDAsDataTable(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_DET_IDCommand(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_det_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_det_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID", ctacte_pago_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_doc_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID", ctacte_pago_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_PERSONA_RELACIONADA_ID(decimal ctacte_persona_relacionada_id)
		{
			return GetByCTACTE_PERSONA_RELACIONADA_ID(ctacte_persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="ctacte_persona_relacionada_idNull">true if the method ignores the ctacte_persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_PERSONA_RELACIONADA_ID(decimal ctacte_persona_relacionada_id, bool ctacte_persona_relacionada_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_RELACIONADA_IDCommand(ctacte_persona_relacionada_id, ctacte_persona_relacionada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_RELACIONADA_IDAsDataTable(decimal ctacte_persona_relacionada_id)
		{
			return GetByCTACTE_PERSONA_RELACIONADA_IDAsDataTable(ctacte_persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="ctacte_persona_relacionada_idNull">true if the method ignores the ctacte_persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_RELACIONADA_IDAsDataTable(decimal ctacte_persona_relacionada_id, bool ctacte_persona_relacionada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_RELACIONADA_IDCommand(ctacte_persona_relacionada_id, ctacte_persona_relacionada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="ctacte_persona_relacionada_idNull">true if the method ignores the ctacte_persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_RELACIONADA_IDCommand(decimal ctacte_persona_relacionada_id, bool ctacte_persona_relacionada_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_relacionada_idNull)
				whereSql += "CTACTE_PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_relacionada_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_RELACIONADA_ID", ctacte_persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public CTACTE_PERSONASRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONASRow"/> objects 
		/// by the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		public virtual CTACTE_PERSONASRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_IDAsDataTable(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PERSONASRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PERSONASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PERSONAS (" +
				"ID, " +
				"PERSONA_ID, " +
				"CASO_ID, " +
				"FECHA_INSERCION, " +
				"FECHA_VENCIMIENTO, " +
				"FECHA_POSTERGACION, " +
				"CUOTA_NUMERO, " +
				"CUOTA_TOTAL, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"CTACTE_CONCEPTO_ID, " +
				"CTACTE_VALOR_ID, " +
				"CTACTE_PAGARE_DOC_ID, " +
				"CTACTE_PAGARE_DET_ID, " +
				"CTACTE_PAGO_PERSONA_DET_ID, " +
				"CTACTE_PAGO_PERSONA_DOC_ID, " +
				"CTACTE_PAGO_PERSONA_REC_ID, " +
				"CALENDARIO_PAGOS_FC_CLI_ID, " +
				"CALENDARIO_PAGOS_CR_CLI_ID, " +
				"ORDEN_PAGO_ID, " +
				"CTACTE_DOCUMENTO_VENC_ID, " +
				"CREDITO, " +
				"DEBITO, " +
				"CONCEPTO, " +
				"CTACTE_PERSONA_RELACIONADA_ID, " +
				"JUDICIAL, " +
				"BLOQUEADO, " +
				"ESTADO, " +
				"APLICACION_DOCUMENTOS_ID, " +
				"APLICACION_DOCUMENTOS_VAL_ID, " +
				"APLICACION_DOCUMENTOS_REC_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_POSTERGACION") + ", " +
				_db.CreateSqlParameterName("CUOTA_NUMERO") + ", " +
				_db.CreateSqlParameterName("CUOTA_TOTAL") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGARE_DOC_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_REC_ID") + ", " +
				_db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLI_ID") + ", " +
				_db.CreateSqlParameterName("CALENDARIO_PAGOS_CR_CLI_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_DOCUMENTO_VENC_ID") + ", " +
				_db.CreateSqlParameterName("CREDITO") + ", " +
				_db.CreateSqlParameterName("DEBITO") + ", " +
				_db.CreateSqlParameterName("CONCEPTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("JUDICIAL") + ", " +
				_db.CreateSqlParameterName("BLOQUEADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTOS_ID") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTOS_VAL_ID") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTOS_REC_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_POSTERGACION",
				value.IsFECHA_POSTERGACIONNull ? DBNull.Value : (object)value.FECHA_POSTERGACION);
			AddParameter(cmd, "CUOTA_NUMERO",
				value.IsCUOTA_NUMERONull ? DBNull.Value : (object)value.CUOTA_NUMERO);
			AddParameter(cmd, "CUOTA_TOTAL",
				value.IsCUOTA_TOTALNull ? DBNull.Value : (object)value.CUOTA_TOTAL);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DOC_ID",
				value.IsCTACTE_PAGARE_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID",
				value.IsCTACTE_PAGO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_REC_ID",
				value.IsCTACTE_PAGO_PERSONA_REC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_REC_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLI_ID",
				value.IsCALENDARIO_PAGOS_FC_CLI_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_CLI_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_CR_CLI_ID",
				value.IsCALENDARIO_PAGOS_CR_CLI_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_CR_CLI_ID);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "CTACTE_DOCUMENTO_VENC_ID",
				value.IsCTACTE_DOCUMENTO_VENC_IDNull ? DBNull.Value : (object)value.CTACTE_DOCUMENTO_VENC_ID);
			AddParameter(cmd, "CREDITO", value.CREDITO);
			AddParameter(cmd, "DEBITO", value.DEBITO);
			AddParameter(cmd, "CONCEPTO", value.CONCEPTO);
			AddParameter(cmd, "CTACTE_PERSONA_RELACIONADA_ID",
				value.IsCTACTE_PERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "JUDICIAL", value.JUDICIAL);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_ID",
				value.IsAPLICACION_DOCUMENTOS_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_VAL_ID",
				value.IsAPLICACION_DOCUMENTOS_VAL_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_VAL_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_REC_ID",
				value.IsAPLICACION_DOCUMENTOS_REC_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_REC_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PERSONASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PERSONASRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PERSONAS SET " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"FECHA_INSERCION=" + _db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"FECHA_POSTERGACION=" + _db.CreateSqlParameterName("FECHA_POSTERGACION") + ", " +
				"CUOTA_NUMERO=" + _db.CreateSqlParameterName("CUOTA_NUMERO") + ", " +
				"CUOTA_TOTAL=" + _db.CreateSqlParameterName("CUOTA_TOTAL") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"CTACTE_PAGARE_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DOC_ID") + ", " +
				"CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				"CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID") + ", " +
				"CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") + ", " +
				"CTACTE_PAGO_PERSONA_REC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_REC_ID") + ", " +
				"CALENDARIO_PAGOS_FC_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLI_ID") + ", " +
				"CALENDARIO_PAGOS_CR_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_CR_CLI_ID") + ", " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"CTACTE_DOCUMENTO_VENC_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_VENC_ID") + ", " +
				"CREDITO=" + _db.CreateSqlParameterName("CREDITO") + ", " +
				"DEBITO=" + _db.CreateSqlParameterName("DEBITO") + ", " +
				"CONCEPTO=" + _db.CreateSqlParameterName("CONCEPTO") + ", " +
				"CTACTE_PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_RELACIONADA_ID") + ", " +
				"JUDICIAL=" + _db.CreateSqlParameterName("JUDICIAL") + ", " +
				"BLOQUEADO=" + _db.CreateSqlParameterName("BLOQUEADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"APLICACION_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_ID") + ", " +
				"APLICACION_DOCUMENTOS_VAL_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_VAL_ID") + ", " +
				"APLICACION_DOCUMENTOS_REC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_REC_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_POSTERGACION",
				value.IsFECHA_POSTERGACIONNull ? DBNull.Value : (object)value.FECHA_POSTERGACION);
			AddParameter(cmd, "CUOTA_NUMERO",
				value.IsCUOTA_NUMERONull ? DBNull.Value : (object)value.CUOTA_NUMERO);
			AddParameter(cmd, "CUOTA_TOTAL",
				value.IsCUOTA_TOTALNull ? DBNull.Value : (object)value.CUOTA_TOTAL);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DOC_ID",
				value.IsCTACTE_PAGARE_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID",
				value.IsCTACTE_PAGO_PERSONA_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DET_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_REC_ID",
				value.IsCTACTE_PAGO_PERSONA_REC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_REC_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLI_ID",
				value.IsCALENDARIO_PAGOS_FC_CLI_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_CLI_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_CR_CLI_ID",
				value.IsCALENDARIO_PAGOS_CR_CLI_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_CR_CLI_ID);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "CTACTE_DOCUMENTO_VENC_ID",
				value.IsCTACTE_DOCUMENTO_VENC_IDNull ? DBNull.Value : (object)value.CTACTE_DOCUMENTO_VENC_ID);
			AddParameter(cmd, "CREDITO", value.CREDITO);
			AddParameter(cmd, "DEBITO", value.DEBITO);
			AddParameter(cmd, "CONCEPTO", value.CONCEPTO);
			AddParameter(cmd, "CTACTE_PERSONA_RELACIONADA_ID",
				value.IsCTACTE_PERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "JUDICIAL", value.JUDICIAL);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_ID",
				value.IsAPLICACION_DOCUMENTOS_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_VAL_ID",
				value.IsAPLICACION_DOCUMENTOS_VAL_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_VAL_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTOS_REC_ID",
				value.IsAPLICACION_DOCUMENTOS_REC_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTOS_REC_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PERSONAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PERSONAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PERSONASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PERSONASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PERSONAS</c> table using
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
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_ID(decimal aplicacion_documentos_id)
		{
			return DeleteByAPLICACION_DOCUMENTOS_ID(aplicacion_documentos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_idNull">true if the method ignores the aplicacion_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_ID(decimal aplicacion_documentos_id, bool aplicacion_documentos_idNull)
		{
			return CreateDeleteByAPLICACION_DOCUMENTOS_IDCommand(aplicacion_documentos_id, aplicacion_documentos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_APL_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_id">The <c>APLICACION_DOCUMENTOS_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_idNull">true if the method ignores the aplicacion_documentos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTOS_IDCommand(decimal aplicacion_documentos_id, bool aplicacion_documentos_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_idNull)
				whereSql += "APLICACION_DOCUMENTOS_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_documentos_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_ID", aplicacion_documentos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_REC_ID(decimal aplicacion_documentos_rec_id)
		{
			return DeleteByAPLICACION_DOCUMENTOS_REC_ID(aplicacion_documentos_rec_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_rec_idNull">true if the method ignores the aplicacion_documentos_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_REC_ID(decimal aplicacion_documentos_rec_id, bool aplicacion_documentos_rec_idNull)
		{
			return CreateDeleteByAPLICACION_DOCUMENTOS_REC_IDCommand(aplicacion_documentos_rec_id, aplicacion_documentos_rec_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_APL_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_rec_id">The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_rec_idNull">true if the method ignores the aplicacion_documentos_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTOS_REC_IDCommand(decimal aplicacion_documentos_rec_id, bool aplicacion_documentos_rec_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_rec_idNull)
				whereSql += "APLICACION_DOCUMENTOS_REC_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_REC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_REC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_documentos_rec_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_REC_ID", aplicacion_documentos_rec_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_VAL_ID(decimal aplicacion_documentos_val_id)
		{
			return DeleteByAPLICACION_DOCUMENTOS_VAL_ID(aplicacion_documentos_val_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_val_idNull">true if the method ignores the aplicacion_documentos_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTOS_VAL_ID(decimal aplicacion_documentos_val_id, bool aplicacion_documentos_val_idNull)
		{
			return CreateDeleteByAPLICACION_DOCUMENTOS_VAL_IDCommand(aplicacion_documentos_val_id, aplicacion_documentos_val_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_APL_DOC_VAL</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documentos_val_id">The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</param>
		/// <param name="aplicacion_documentos_val_idNull">true if the method ignores the aplicacion_documentos_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTOS_VAL_IDCommand(decimal aplicacion_documentos_val_id, bool aplicacion_documentos_val_idNull)
		{
			string whereSql = "";
			if(aplicacion_documentos_val_idNull)
				whereSql += "APLICACION_DOCUMENTOS_VAL_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTOS_VAL_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTOS_VAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_documentos_val_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTOS_VAL_ID", aplicacion_documentos_val_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_CLI_ID(decimal calendario_pagos_fc_cli_id)
		{
			return DeleteByCALENDARIO_PAGOS_FC_CLI_ID(calendario_pagos_fc_cli_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cli_idNull">true if the method ignores the calendario_pagos_fc_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_CLI_ID(decimal calendario_pagos_fc_cli_id, bool calendario_pagos_fc_cli_idNull)
		{
			return CreateDeleteByCALENDARIO_PAGOS_FC_CLI_IDCommand(calendario_pagos_fc_cli_id, calendario_pagos_fc_cli_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cli_id">The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cli_idNull">true if the method ignores the calendario_pagos_fc_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCALENDARIO_PAGOS_FC_CLI_IDCommand(decimal calendario_pagos_fc_cli_id, bool calendario_pagos_fc_cli_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_cli_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_CLI_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLI_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!calendario_pagos_fc_cli_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLI_ID", calendario_pagos_fc_cli_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_CR_CLI_ID(decimal calendario_pagos_cr_cli_id)
		{
			return DeleteByCALENDARIO_PAGOS_CR_CLI_ID(calendario_pagos_cr_cli_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_cr_cli_idNull">true if the method ignores the calendario_pagos_cr_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_CR_CLI_ID(decimal calendario_pagos_cr_cli_id, bool calendario_pagos_cr_cli_idNull)
		{
			return CreateDeleteByCALENDARIO_PAGOS_CR_CLI_IDCommand(calendario_pagos_cr_cli_id, calendario_pagos_cr_cli_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_CAL_PAG_CRE</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_cr_cli_id">The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</param>
		/// <param name="calendario_pagos_cr_cli_idNull">true if the method ignores the calendario_pagos_cr_cli_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCALENDARIO_PAGOS_CR_CLI_IDCommand(decimal calendario_pagos_cr_cli_id, bool calendario_pagos_cr_cli_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_cr_cli_idNull)
				whereSql += "CALENDARIO_PAGOS_CR_CLI_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_CR_CLI_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_CR_CLI_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!calendario_pagos_cr_cli_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_CR_CLI_ID", calendario_pagos_cr_cli_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PERSONAS_CASO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_CENCEPTO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return CreateDeleteByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_CENCEPTO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_DOCUMENTO_VENC_ID(decimal ctacte_documento_venc_id)
		{
			return DeleteByCTACTE_DOCUMENTO_VENC_ID(ctacte_documento_venc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <param name="ctacte_documento_venc_idNull">true if the method ignores the ctacte_documento_venc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_DOCUMENTO_VENC_ID(decimal ctacte_documento_venc_id, bool ctacte_documento_venc_idNull)
		{
			return CreateDeleteByCTACTE_DOCUMENTO_VENC_IDCommand(ctacte_documento_venc_id, ctacte_documento_venc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_DOC_VEN</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_venc_id">The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</param>
		/// <param name="ctacte_documento_venc_idNull">true if the method ignores the ctacte_documento_venc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_DOCUMENTO_VENC_IDCommand(decimal ctacte_documento_venc_id, bool ctacte_documento_venc_idNull)
		{
			string whereSql = "";
			if(ctacte_documento_venc_idNull)
				whereSql += "CTACTE_DOCUMENTO_VENC_ID IS NULL";
			else
				whereSql += "CTACTE_DOCUMENTO_VENC_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_VENC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_documento_venc_idNull)
				AddParameter(cmd, "CTACTE_DOCUMENTO_VENC_ID", ctacte_documento_venc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return DeleteByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_ORD_PAG</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return DeleteByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return CreateDeleteByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PAG_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DOC_ID(decimal ctacte_pagare_doc_id)
		{
			return DeleteByCTACTE_PAGARE_DOC_ID(ctacte_pagare_doc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pagare_doc_idNull">true if the method ignores the ctacte_pagare_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DOC_ID(decimal ctacte_pagare_doc_id, bool ctacte_pagare_doc_idNull)
		{
			return CreateDeleteByCTACTE_PAGARE_DOC_IDCommand(ctacte_pagare_doc_id, ctacte_pagare_doc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PAG_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_doc_id">The <c>CTACTE_PAGARE_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pagare_doc_idNull">true if the method ignores the ctacte_pagare_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGARE_DOC_IDCommand(decimal ctacte_pagare_doc_id, bool ctacte_pagare_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_doc_idNull)
				whereSql += "CTACTE_PAGARE_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DOC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pagare_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DOC_ID", ctacte_pagare_doc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_REC_ID(decimal ctacte_pago_persona_rec_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_REC_ID(ctacte_pago_persona_rec_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_rec_idNull">true if the method ignores the ctacte_pago_persona_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_REC_ID(decimal ctacte_pago_persona_rec_id, bool ctacte_pago_persona_rec_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_REC_IDCommand(ctacte_pago_persona_rec_id, ctacte_pago_persona_rec_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PAG_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_rec_id">The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_rec_idNull">true if the method ignores the ctacte_pago_persona_rec_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_REC_IDCommand(decimal ctacte_pago_persona_rec_id, bool ctacte_pago_persona_rec_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_rec_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_REC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_REC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_REC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_rec_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_REC_ID", ctacte_pago_persona_rec_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_DET_ID(ctacte_pago_persona_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DET_ID(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_DET_IDCommand(ctacte_pago_persona_det_id, ctacte_pago_persona_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PAGO_DET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_det_id">The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_det_idNull">true if the method ignores the ctacte_pago_persona_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_DET_IDCommand(decimal ctacte_pago_persona_det_id, bool ctacte_pago_persona_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_det_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_det_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DET_ID", ctacte_pago_persona_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PAGO_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_DOC_IDCommand(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_doc_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID", ctacte_pago_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_RELACIONADA_ID(decimal ctacte_persona_relacionada_id)
		{
			return DeleteByCTACTE_PERSONA_RELACIONADA_ID(ctacte_persona_relacionada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="ctacte_persona_relacionada_idNull">true if the method ignores the ctacte_persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_RELACIONADA_ID(decimal ctacte_persona_relacionada_id, bool ctacte_persona_relacionada_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_RELACIONADA_IDCommand(ctacte_persona_relacionada_id, ctacte_persona_relacionada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_USR_RECURS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_relacionada_id">The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="ctacte_persona_relacionada_idNull">true if the method ignores the ctacte_persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_RELACIONADA_IDCommand(decimal ctacte_persona_relacionada_id, bool ctacte_persona_relacionada_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_relacionada_idNull)
				whereSql += "CTACTE_PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_relacionada_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_RELACIONADA_ID", ctacte_persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return DeleteByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PERSONAS</c> table using the 
		/// <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PERSONAS_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PERSONAS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PERSONAS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		protected CTACTE_PERSONASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		protected CTACTE_PERSONASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PERSONASRow"/> objects.</returns>
		protected virtual CTACTE_PERSONASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_postergacionColumnIndex = reader.GetOrdinal("FECHA_POSTERGACION");
			int cuota_numeroColumnIndex = reader.GetOrdinal("CUOTA_NUMERO");
			int cuota_totalColumnIndex = reader.GetOrdinal("CUOTA_TOTAL");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_pagare_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DOC_ID");
			int ctacte_pagare_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DET_ID");
			int ctacte_pago_persona_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DET_ID");
			int ctacte_pago_persona_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DOC_ID");
			int ctacte_pago_persona_rec_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_REC_ID");
			int calendario_pagos_fc_cli_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_FC_CLI_ID");
			int calendario_pagos_cr_cli_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_CR_CLI_ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int ctacte_documento_venc_idColumnIndex = reader.GetOrdinal("CTACTE_DOCUMENTO_VENC_ID");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int conceptoColumnIndex = reader.GetOrdinal("CONCEPTO");
			int ctacte_persona_relacionada_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_RELACIONADA_ID");
			int judicialColumnIndex = reader.GetOrdinal("JUDICIAL");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int aplicacion_documentos_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_ID");
			int aplicacion_documentos_val_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_VAL_ID");
			int aplicacion_documentos_rec_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_REC_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PERSONASRow record = new CTACTE_PERSONASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_postergacionColumnIndex))
						record.FECHA_POSTERGACION = Convert.ToDateTime(reader.GetValue(fecha_postergacionColumnIndex));
					if(!reader.IsDBNull(cuota_numeroColumnIndex))
						record.CUOTA_NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_numeroColumnIndex)), 9);
					if(!reader.IsDBNull(cuota_totalColumnIndex))
						record.CUOTA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_totalColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_doc_idColumnIndex))
						record.CTACTE_PAGARE_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_det_idColumnIndex))
						record.CTACTE_PAGARE_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_det_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_doc_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_rec_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_REC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_rec_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_fc_cli_idColumnIndex))
						record.CALENDARIO_PAGOS_FC_CLI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_fc_cli_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_cr_cli_idColumnIndex))
						record.CALENDARIO_PAGOS_CR_CLI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_cr_cli_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_documento_venc_idColumnIndex))
						record.CTACTE_DOCUMENTO_VENC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_documento_venc_idColumnIndex)), 9);
					record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(conceptoColumnIndex))
						record.CONCEPTO = Convert.ToString(reader.GetValue(conceptoColumnIndex));
					if(!reader.IsDBNull(ctacte_persona_relacionada_idColumnIndex))
						record.CTACTE_PERSONA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_relacionada_idColumnIndex)), 9);
					record.JUDICIAL = Convert.ToString(reader.GetValue(judicialColumnIndex));
					record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(aplicacion_documentos_idColumnIndex))
						record.APLICACION_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documentos_val_idColumnIndex))
						record.APLICACION_DOCUMENTOS_VAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_val_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documentos_rec_idColumnIndex))
						record.APLICACION_DOCUMENTOS_REC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_rec_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PERSONASRow[])(recordList.ToArray(typeof(CTACTE_PERSONASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PERSONASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PERSONASRow"/> object.</returns>
		protected virtual CTACTE_PERSONASRow MapRow(DataRow row)
		{
			CTACTE_PERSONASRow mappedObject = new CTACTE_PERSONASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSTERGACION"
			dataColumn = dataTable.Columns["FECHA_POSTERGACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSTERGACION = (System.DateTime)row[dataColumn];
			// Column "CUOTA_NUMERO"
			dataColumn = dataTable.Columns["CUOTA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_NUMERO = (decimal)row[dataColumn];
			// Column "CUOTA_TOTAL"
			dataColumn = dataTable.Columns["CUOTA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_TOTAL = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_REC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_REC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_REC_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_FC_CLI_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_FC_CLI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_FC_CLI_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_CR_CLI_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_CR_CLI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_CR_CLI_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_DOCUMENTO_VENC_ID"
			dataColumn = dataTable.Columns["CTACTE_DOCUMENTO_VENC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_DOCUMENTO_VENC_ID = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "CONCEPTO"
			dataColumn = dataTable.Columns["CONCEPTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO = (string)row[dataColumn];
			// Column "CTACTE_PERSONA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "JUDICIAL"
			dataColumn = dataTable.Columns["JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUDICIAL = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_VAL_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_VAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_VAL_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_REC_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_REC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_REC_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PERSONAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_POSTERGACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CUOTA_NUMERO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CUOTA_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DOC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DOC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_REC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_FC_CLI_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_CR_CLI_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_DOCUMENTO_VENC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONCEPTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_RELACIONADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("JUDICIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_VAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_REC_ID", typeof(decimal));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSTERGACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CUOTA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_REC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_FC_CLI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_CR_CLI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_DOCUMENTO_VENC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCEPTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PERSONA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APLICACION_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTOS_VAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTOS_REC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PERSONASCollection_Base class
}  // End of namespace
