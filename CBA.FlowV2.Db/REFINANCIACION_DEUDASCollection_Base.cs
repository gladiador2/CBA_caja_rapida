// <fileinfo name="REFINANCIACION_DEUDASCollection_Base.cs">
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
	/// The base class for <see cref="REFINANCIACION_DEUDASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REFINANCIACION_DEUDASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REFINANCIACION_DEUDASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string MONTO_CUOTA_PROPUESTOColumnName = "MONTO_CUOTA_PROPUESTO";
		public const string ENTREGA_INICIALColumnName = "ENTREGA_INICIAL";
		public const string CASO_REFINANCIADO_IDColumnName = "CASO_REFINANCIADO_ID";
		public const string ES_RECALENDARIZACIONColumnName = "ES_RECALENDARIZACION";
		public const string PERSONAS_ESTADO_MOROSIDAD_IDColumnName = "PERSONAS_ESTADO_MOROSIDAD_ID";
		public const string FECHA_PRIMER_VENCIMIENTOColumnName = "FECHA_PRIMER_VENCIMIENTO";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REFINANCIACION_DEUDASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REFINANCIACION_DEUDASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REFINANCIACION_DEUDASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REFINANCIACION_DEUDASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REFINANCIACION_DEUDASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REFINANCIACION_DEUDASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public REFINANCIACION_DEUDASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects that 
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REFINANCIACION_DEUDAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REFINANCIACION_DEUDASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REFINANCIACION_DEUDASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REFINANCIACION_DEUDASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REFINANCIACION_DEUDASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public REFINANCIACION_DEUDASRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_CASO_REFI_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_refinanciado_id">The <c>CASO_REFINANCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByCASO_REFINANCIADO_ID(decimal caso_refinanciado_id)
		{
			return MapRecords(CreateGetByCASO_REFINANCIADO_IDCommand(caso_refinanciado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_CASO_REFI_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_refinanciado_id">The <c>CASO_REFINANCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_REFINANCIADO_IDAsDataTable(decimal caso_refinanciado_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_REFINANCIADO_IDCommand(caso_refinanciado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_CASO_REFI_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_refinanciado_id">The <c>CASO_REFINANCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_REFINANCIADO_IDCommand(decimal caso_refinanciado_id)
		{
			string whereSql = "";
			whereSql += "CASO_REFINANCIADO_ID=" + _db.CreateSqlParameterName("CASO_REFINANCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_REFINANCIADO_ID", caso_refinanciado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public REFINANCIACION_DEUDASRow[] GetByPERSONAS_ESTADO_MOROSIDAD_ID(decimal personas_estado_morosidad_id)
		{
			return GetByPERSONAS_ESTADO_MOROSIDAD_ID(personas_estado_morosidad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="personas_estado_morosidad_idNull">true if the method ignores the personas_estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByPERSONAS_ESTADO_MOROSIDAD_ID(decimal personas_estado_morosidad_id, bool personas_estado_morosidad_idNull)
		{
			return MapRecords(CreateGetByPERSONAS_ESTADO_MOROSIDAD_IDCommand(personas_estado_morosidad_id, personas_estado_morosidad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONAS_ESTADO_MOROSIDAD_IDAsDataTable(decimal personas_estado_morosidad_id)
		{
			return GetByPERSONAS_ESTADO_MOROSIDAD_IDAsDataTable(personas_estado_morosidad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="personas_estado_morosidad_idNull">true if the method ignores the personas_estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONAS_ESTADO_MOROSIDAD_IDAsDataTable(decimal personas_estado_morosidad_id, bool personas_estado_morosidad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONAS_ESTADO_MOROSIDAD_IDCommand(personas_estado_morosidad_id, personas_estado_morosidad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="personas_estado_morosidad_idNull">true if the method ignores the personas_estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONAS_ESTADO_MOROSIDAD_IDCommand(decimal personas_estado_morosidad_id, bool personas_estado_morosidad_idNull)
		{
			string whereSql = "";
			if(personas_estado_morosidad_idNull)
				whereSql += "PERSONAS_ESTADO_MOROSIDAD_ID IS NULL";
			else
				whereSql += "PERSONAS_ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("PERSONAS_ESTADO_MOROSIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!personas_estado_morosidad_idNull)
				AddParameter(cmd, "PERSONAS_ESTADO_MOROSIDAD_ID", personas_estado_morosidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_PERSONA_ID</c> foreign key.
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
		/// Gets an array of <see cref="REFINANCIACION_DEUDASRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDASRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_SUCURSAL_ID</c> foreign key.
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
		/// Adds a new record into the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDASRow"/> object to be inserted.</param>
		public virtual void Insert(REFINANCIACION_DEUDASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REFINANCIACION_DEUDAS (" +
				"ID, " +
				"CASO_ID, " +
				"PERSONA_ID, " +
				"SUCURSAL_ID, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"MONTO_CUOTA_PROPUESTO, " +
				"ENTREGA_INICIAL, " +
				"CASO_REFINANCIADO_ID, " +
				"ES_RECALENDARIZACION, " +
				"PERSONAS_ESTADO_MOROSIDAD_ID, " +
				"FECHA_PRIMER_VENCIMIENTO, " +
				"NRO_COMPROBANTE_EXTERNO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("MONTO_CUOTA_PROPUESTO") + ", " +
				_db.CreateSqlParameterName("ENTREGA_INICIAL") + ", " +
				_db.CreateSqlParameterName("CASO_REFINANCIADO_ID") + ", " +
				_db.CreateSqlParameterName("ES_RECALENDARIZACION") + ", " +
				_db.CreateSqlParameterName("PERSONAS_ESTADO_MOROSIDAD_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_PRIMER_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONTO_CUOTA_PROPUESTO",
				value.IsMONTO_CUOTA_PROPUESTONull ? DBNull.Value : (object)value.MONTO_CUOTA_PROPUESTO);
			AddParameter(cmd, "ENTREGA_INICIAL",
				value.IsENTREGA_INICIALNull ? DBNull.Value : (object)value.ENTREGA_INICIAL);
			AddParameter(cmd, "CASO_REFINANCIADO_ID", value.CASO_REFINANCIADO_ID);
			AddParameter(cmd, "ES_RECALENDARIZACION", value.ES_RECALENDARIZACION);
			AddParameter(cmd, "PERSONAS_ESTADO_MOROSIDAD_ID",
				value.IsPERSONAS_ESTADO_MOROSIDAD_IDNull ? DBNull.Value : (object)value.PERSONAS_ESTADO_MOROSIDAD_ID);
			AddParameter(cmd, "FECHA_PRIMER_VENCIMIENTO",
				value.IsFECHA_PRIMER_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REFINANCIACION_DEUDASRow value)
		{
			
			string sqlStr = "UPDATE TRC.REFINANCIACION_DEUDAS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"MONTO_CUOTA_PROPUESTO=" + _db.CreateSqlParameterName("MONTO_CUOTA_PROPUESTO") + ", " +
				"ENTREGA_INICIAL=" + _db.CreateSqlParameterName("ENTREGA_INICIAL") + ", " +
				"CASO_REFINANCIADO_ID=" + _db.CreateSqlParameterName("CASO_REFINANCIADO_ID") + ", " +
				"ES_RECALENDARIZACION=" + _db.CreateSqlParameterName("ES_RECALENDARIZACION") + ", " +
				"PERSONAS_ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("PERSONAS_ESTADO_MOROSIDAD_ID") + ", " +
				"FECHA_PRIMER_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_PRIMER_VENCIMIENTO") + ", " +
				"NRO_COMPROBANTE_EXTERNO=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONTO_CUOTA_PROPUESTO",
				value.IsMONTO_CUOTA_PROPUESTONull ? DBNull.Value : (object)value.MONTO_CUOTA_PROPUESTO);
			AddParameter(cmd, "ENTREGA_INICIAL",
				value.IsENTREGA_INICIALNull ? DBNull.Value : (object)value.ENTREGA_INICIAL);
			AddParameter(cmd, "CASO_REFINANCIADO_ID", value.CASO_REFINANCIADO_ID);
			AddParameter(cmd, "ES_RECALENDARIZACION", value.ES_RECALENDARIZACION);
			AddParameter(cmd, "PERSONAS_ESTADO_MOROSIDAD_ID",
				value.IsPERSONAS_ESTADO_MOROSIDAD_IDNull ? DBNull.Value : (object)value.PERSONAS_ESTADO_MOROSIDAD_ID);
			AddParameter(cmd, "FECHA_PRIMER_VENCIMIENTO",
				value.IsFECHA_PRIMER_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REFINANCIACION_DEUDAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REFINANCIACION_DEUDAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REFINANCIACION_DEUDASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REFINANCIACION_DEUDAS</c> table using
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_REFI_DEUDAS_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_CASO_REFI_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_refinanciado_id">The <c>CASO_REFINANCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_REFINANCIADO_ID(decimal caso_refinanciado_id)
		{
			return CreateDeleteByCASO_REFINANCIADO_IDCommand(caso_refinanciado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_CASO_REFI_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_refinanciado_id">The <c>CASO_REFINANCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_REFINANCIADO_IDCommand(decimal caso_refinanciado_id)
		{
			string whereSql = "";
			whereSql += "CASO_REFINANCIADO_ID=" + _db.CreateSqlParameterName("CASO_REFINANCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_REFINANCIADO_ID", caso_refinanciado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONAS_ESTADO_MOROSIDAD_ID(decimal personas_estado_morosidad_id)
		{
			return DeleteByPERSONAS_ESTADO_MOROSIDAD_ID(personas_estado_morosidad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="personas_estado_morosidad_idNull">true if the method ignores the personas_estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONAS_ESTADO_MOROSIDAD_ID(decimal personas_estado_morosidad_id, bool personas_estado_morosidad_idNull)
		{
			return CreateDeleteByPERSONAS_ESTADO_MOROSIDAD_IDCommand(personas_estado_morosidad_id, personas_estado_morosidad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_MOROSIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="personas_estado_morosidad_id">The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="personas_estado_morosidad_idNull">true if the method ignores the personas_estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONAS_ESTADO_MOROSIDAD_IDCommand(decimal personas_estado_morosidad_id, bool personas_estado_morosidad_idNull)
		{
			string whereSql = "";
			if(personas_estado_morosidad_idNull)
				whereSql += "PERSONAS_ESTADO_MOROSIDAD_ID IS NULL";
			else
				whereSql += "PERSONAS_ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("PERSONAS_ESTADO_MOROSIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!personas_estado_morosidad_idNull)
				AddParameter(cmd, "PERSONAS_ESTADO_MOROSIDAD_ID", personas_estado_morosidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_PERSONA_ID</c> foreign key.
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS</c> table using the 
		/// <c>FK_REFI_DEUDAS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_SUCURSAL_ID</c> foreign key.
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
		/// Deletes <c>REFINANCIACION_DEUDAS</c> records that match the specified criteria.
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
		/// to delete <c>REFINANCIACION_DEUDAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REFINANCIACION_DEUDAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REFINANCIACION_DEUDAS</c> table.
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		protected REFINANCIACION_DEUDASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		protected REFINANCIACION_DEUDASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDASRow"/> objects.</returns>
		protected virtual REFINANCIACION_DEUDASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int monto_cuota_propuestoColumnIndex = reader.GetOrdinal("MONTO_CUOTA_PROPUESTO");
			int entrega_inicialColumnIndex = reader.GetOrdinal("ENTREGA_INICIAL");
			int caso_refinanciado_idColumnIndex = reader.GetOrdinal("CASO_REFINANCIADO_ID");
			int es_recalendarizacionColumnIndex = reader.GetOrdinal("ES_RECALENDARIZACION");
			int personas_estado_morosidad_idColumnIndex = reader.GetOrdinal("PERSONAS_ESTADO_MOROSIDAD_ID");
			int fecha_primer_vencimientoColumnIndex = reader.GetOrdinal("FECHA_PRIMER_VENCIMIENTO");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REFINANCIACION_DEUDASRow record = new REFINANCIACION_DEUDASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(monto_cuota_propuestoColumnIndex))
						record.MONTO_CUOTA_PROPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cuota_propuestoColumnIndex)), 9);
					if(!reader.IsDBNull(entrega_inicialColumnIndex))
						record.ENTREGA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(entrega_inicialColumnIndex)), 9);
					record.CASO_REFINANCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_refinanciado_idColumnIndex)), 9);
					record.ES_RECALENDARIZACION = Convert.ToString(reader.GetValue(es_recalendarizacionColumnIndex));
					if(!reader.IsDBNull(personas_estado_morosidad_idColumnIndex))
						record.PERSONAS_ESTADO_MOROSIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(personas_estado_morosidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_primer_vencimientoColumnIndex))
						record.FECHA_PRIMER_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_primer_vencimientoColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REFINANCIACION_DEUDASRow[])(recordList.ToArray(typeof(REFINANCIACION_DEUDASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REFINANCIACION_DEUDASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REFINANCIACION_DEUDASRow"/> object.</returns>
		protected virtual REFINANCIACION_DEUDASRow MapRow(DataRow row)
		{
			REFINANCIACION_DEUDASRow mappedObject = new REFINANCIACION_DEUDASRow();
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
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
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "MONTO_CUOTA_PROPUESTO"
			dataColumn = dataTable.Columns["MONTO_CUOTA_PROPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CUOTA_PROPUESTO = (decimal)row[dataColumn];
			// Column "ENTREGA_INICIAL"
			dataColumn = dataTable.Columns["ENTREGA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTREGA_INICIAL = (decimal)row[dataColumn];
			// Column "CASO_REFINANCIADO_ID"
			dataColumn = dataTable.Columns["CASO_REFINANCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_REFINANCIADO_ID = (decimal)row[dataColumn];
			// Column "ES_RECALENDARIZACION"
			dataColumn = dataTable.Columns["ES_RECALENDARIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_RECALENDARIZACION = (string)row[dataColumn];
			// Column "PERSONAS_ESTADO_MOROSIDAD_ID"
			dataColumn = dataTable.Columns["PERSONAS_ESTADO_MOROSIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONAS_ESTADO_MOROSIDAD_ID = (decimal)row[dataColumn];
			// Column "FECHA_PRIMER_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_PRIMER_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_PRIMER_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REFINANCIACION_DEUDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REFINANCIACION_DEUDAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MONTO_CUOTA_PROPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ENTREGA_INICIAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_REFINANCIADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_RECALENDARIZACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONAS_ESTADO_MOROSIDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_PRIMER_VENCIMIENTO", typeof(System.DateTime));
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

				case "PERSONA_ID":
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

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_CUOTA_PROPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTREGA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_REFINANCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_RECALENDARIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONAS_ESTADO_MOROSIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_PRIMER_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REFINANCIACION_DEUDASCollection_Base class
}  // End of namespace
