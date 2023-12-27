// <fileinfo name="CTACTE_PAGARESCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGARESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CANTIDAD_PAGARESColumnName = "CANTIDAD_PAGARES";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string NOMBRE_DEUDORColumnName = "NOMBRE_DEUDOR";
		public const string DOCUMENTO_DEUDORColumnName = "DOCUMENTO_DEUDOR";
		public const string TELEFONO_DEUDORColumnName = "TELEFONO_DEUDOR";
		public const string DIRECCION_DEUDORColumnName = "DIRECCION_DEUDOR";
		public const string NOMBRE_CODEUDORColumnName = "NOMBRE_CODEUDOR";
		public const string DOCUMENTO_CODEUDORColumnName = "DOCUMENTO_CODEUDOR";
		public const string TELEFONO_CODEUDORColumnName = "TELEFONO_CODEUDOR";
		public const string DIRECCION_CODEUDORColumnName = "DIRECCION_CODEUDOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string DOCUMENTO_BENEFICIARIOColumnName = "DOCUMENTO_BENEFICIARIO";
		public const string TELEFONO_BENEFICIARIOColumnName = "TELEFONO_BENEFICIARIO";
		public const string DIRECCION_BENEFICIARIOColumnName = "DIRECCION_BENEFICIARIO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string FECHA_FIRMAColumnName = "FECHA_FIRMA";
		public const string FECHA_ANULADOColumnName = "FECHA_ANULADO";
		public const string USUARIO_ANULADO_IDColumnName = "USUARIO_ANULADO_ID";
		public const string JUEGO_PAGARES_APROBADOColumnName = "JUEGO_PAGARES_APROBADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string GARANTIAColumnName = "GARANTIA";
		public const string CASO_GARANTIA_IDColumnName = "CASO_GARANTIA_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGARESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGARESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGARESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGARESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGARESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public CTACTE_PAGARESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGARES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PAGARESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGARESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PAGARESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PAGARESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public CTACTE_PAGARESRow[] GetByCASO_GARANTIA_ID(decimal caso_garantia_id)
		{
			return GetByCASO_GARANTIA_ID(caso_garantia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <param name="caso_garantia_idNull">true if the method ignores the caso_garantia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByCASO_GARANTIA_ID(decimal caso_garantia_id, bool caso_garantia_idNull)
		{
			return MapRecords(CreateGetByCASO_GARANTIA_IDCommand(caso_garantia_id, caso_garantia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_GARANTIA_IDAsDataTable(decimal caso_garantia_id)
		{
			return GetByCASO_GARANTIA_IDAsDataTable(caso_garantia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <param name="caso_garantia_idNull">true if the method ignores the caso_garantia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_GARANTIA_IDAsDataTable(decimal caso_garantia_id, bool caso_garantia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_GARANTIA_IDCommand(caso_garantia_id, caso_garantia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <param name="caso_garantia_idNull">true if the method ignores the caso_garantia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_GARANTIA_IDCommand(decimal caso_garantia_id, bool caso_garantia_idNull)
		{
			string whereSql = "";
			if(caso_garantia_idNull)
				whereSql += "CASO_GARANTIA_ID IS NULL";
			else
				whereSql += "CASO_GARANTIA_ID=" + _db.CreateSqlParameterName("CASO_GARANTIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_garantia_idNull)
				AddParameter(cmd, "CASO_GARANTIA_ID", caso_garantia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_PERSONA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_PERSONA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_PERSONA_AUTO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_SUC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_USR</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public CTACTE_PAGARESRow[] GetByUSUARIO_ANULADO_ID(decimal usuario_anulado_id)
		{
			return GetByUSUARIO_ANULADO_ID(usuario_anulado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARESRow"/> objects 
		/// by the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <param name="usuario_anulado_idNull">true if the method ignores the usuario_anulado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		public virtual CTACTE_PAGARESRow[] GetByUSUARIO_ANULADO_ID(decimal usuario_anulado_id, bool usuario_anulado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ANULADO_IDCommand(usuario_anulado_id, usuario_anulado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ANULADO_IDAsDataTable(decimal usuario_anulado_id)
		{
			return GetByUSUARIO_ANULADO_IDAsDataTable(usuario_anulado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <param name="usuario_anulado_idNull">true if the method ignores the usuario_anulado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ANULADO_IDAsDataTable(decimal usuario_anulado_id, bool usuario_anulado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ANULADO_IDCommand(usuario_anulado_id, usuario_anulado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <param name="usuario_anulado_idNull">true if the method ignores the usuario_anulado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ANULADO_IDCommand(decimal usuario_anulado_id, bool usuario_anulado_idNull)
		{
			string whereSql = "";
			if(usuario_anulado_idNull)
				whereSql += "USUARIO_ANULADO_ID IS NULL";
			else
				whereSql += "USUARIO_ANULADO_ID=" + _db.CreateSqlParameterName("USUARIO_ANULADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_anulado_idNull)
				AddParameter(cmd, "USUARIO_ANULADO_ID", usuario_anulado_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGARESRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PAGARESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PAGARES (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"USUARIO_ID, " +
				"PERSONA_ID, " +
				"FECHA, " +
				"CANTIDAD_PAGARES, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_TOTAL, " +
				"NOMBRE_DEUDOR, " +
				"DOCUMENTO_DEUDOR, " +
				"TELEFONO_DEUDOR, " +
				"DIRECCION_DEUDOR, " +
				"NOMBRE_CODEUDOR, " +
				"DOCUMENTO_CODEUDOR, " +
				"TELEFONO_CODEUDOR, " +
				"DIRECCION_CODEUDOR, " +
				"NOMBRE_BENEFICIARIO, " +
				"DOCUMENTO_BENEFICIARIO, " +
				"TELEFONO_BENEFICIARIO, " +
				"DIRECCION_BENEFICIARIO, " +
				"FECHA_EMISION, " +
				"FECHA_FIRMA, " +
				"FECHA_ANULADO, " +
				"USUARIO_ANULADO_ID, " +
				"JUEGO_PAGARES_APROBADO, " +
				"ESTADO, " +
				"GARANTIA, " +
				"CASO_GARANTIA_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_PAGARES") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("NOMBRE_DEUDOR") + ", " +
				_db.CreateSqlParameterName("DOCUMENTO_DEUDOR") + ", " +
				_db.CreateSqlParameterName("TELEFONO_DEUDOR") + ", " +
				_db.CreateSqlParameterName("DIRECCION_DEUDOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_CODEUDOR") + ", " +
				_db.CreateSqlParameterName("DOCUMENTO_CODEUDOR") + ", " +
				_db.CreateSqlParameterName("TELEFONO_CODEUDOR") + ", " +
				_db.CreateSqlParameterName("DIRECCION_CODEUDOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("DOCUMENTO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("TELEFONO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("DIRECCION_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("FECHA_FIRMA") + ", " +
				_db.CreateSqlParameterName("FECHA_ANULADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ANULADO_ID") + ", " +
				_db.CreateSqlParameterName("JUEGO_PAGARES_APROBADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("GARANTIA") + ", " +
				_db.CreateSqlParameterName("CASO_GARANTIA_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CANTIDAD_PAGARES", value.CANTIDAD_PAGARES);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "NOMBRE_DEUDOR", value.NOMBRE_DEUDOR);
			AddParameter(cmd, "DOCUMENTO_DEUDOR", value.DOCUMENTO_DEUDOR);
			AddParameter(cmd, "TELEFONO_DEUDOR", value.TELEFONO_DEUDOR);
			AddParameter(cmd, "DIRECCION_DEUDOR", value.DIRECCION_DEUDOR);
			AddParameter(cmd, "NOMBRE_CODEUDOR", value.NOMBRE_CODEUDOR);
			AddParameter(cmd, "DOCUMENTO_CODEUDOR", value.DOCUMENTO_CODEUDOR);
			AddParameter(cmd, "TELEFONO_CODEUDOR", value.TELEFONO_CODEUDOR);
			AddParameter(cmd, "DIRECCION_CODEUDOR", value.DIRECCION_CODEUDOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "DOCUMENTO_BENEFICIARIO", value.DOCUMENTO_BENEFICIARIO);
			AddParameter(cmd, "TELEFONO_BENEFICIARIO", value.TELEFONO_BENEFICIARIO);
			AddParameter(cmd, "DIRECCION_BENEFICIARIO", value.DIRECCION_BENEFICIARIO);
			AddParameter(cmd, "FECHA_EMISION", value.FECHA_EMISION);
			AddParameter(cmd, "FECHA_FIRMA",
				value.IsFECHA_FIRMANull ? DBNull.Value : (object)value.FECHA_FIRMA);
			AddParameter(cmd, "FECHA_ANULADO",
				value.IsFECHA_ANULADONull ? DBNull.Value : (object)value.FECHA_ANULADO);
			AddParameter(cmd, "USUARIO_ANULADO_ID",
				value.IsUSUARIO_ANULADO_IDNull ? DBNull.Value : (object)value.USUARIO_ANULADO_ID);
			AddParameter(cmd, "JUEGO_PAGARES_APROBADO", value.JUEGO_PAGARES_APROBADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GARANTIA", value.GARANTIA);
			AddParameter(cmd, "CASO_GARANTIA_ID",
				value.IsCASO_GARANTIA_IDNull ? DBNull.Value : (object)value.CASO_GARANTIA_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGARESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PAGARESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PAGARES SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CANTIDAD_PAGARES=" + _db.CreateSqlParameterName("CANTIDAD_PAGARES") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"NOMBRE_DEUDOR=" + _db.CreateSqlParameterName("NOMBRE_DEUDOR") + ", " +
				"DOCUMENTO_DEUDOR=" + _db.CreateSqlParameterName("DOCUMENTO_DEUDOR") + ", " +
				"TELEFONO_DEUDOR=" + _db.CreateSqlParameterName("TELEFONO_DEUDOR") + ", " +
				"DIRECCION_DEUDOR=" + _db.CreateSqlParameterName("DIRECCION_DEUDOR") + ", " +
				"NOMBRE_CODEUDOR=" + _db.CreateSqlParameterName("NOMBRE_CODEUDOR") + ", " +
				"DOCUMENTO_CODEUDOR=" + _db.CreateSqlParameterName("DOCUMENTO_CODEUDOR") + ", " +
				"TELEFONO_CODEUDOR=" + _db.CreateSqlParameterName("TELEFONO_CODEUDOR") + ", " +
				"DIRECCION_CODEUDOR=" + _db.CreateSqlParameterName("DIRECCION_CODEUDOR") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"DOCUMENTO_BENEFICIARIO=" + _db.CreateSqlParameterName("DOCUMENTO_BENEFICIARIO") + ", " +
				"TELEFONO_BENEFICIARIO=" + _db.CreateSqlParameterName("TELEFONO_BENEFICIARIO") + ", " +
				"DIRECCION_BENEFICIARIO=" + _db.CreateSqlParameterName("DIRECCION_BENEFICIARIO") + ", " +
				"FECHA_EMISION=" + _db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				"FECHA_FIRMA=" + _db.CreateSqlParameterName("FECHA_FIRMA") + ", " +
				"FECHA_ANULADO=" + _db.CreateSqlParameterName("FECHA_ANULADO") + ", " +
				"USUARIO_ANULADO_ID=" + _db.CreateSqlParameterName("USUARIO_ANULADO_ID") + ", " +
				"JUEGO_PAGARES_APROBADO=" + _db.CreateSqlParameterName("JUEGO_PAGARES_APROBADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"GARANTIA=" + _db.CreateSqlParameterName("GARANTIA") + ", " +
				"CASO_GARANTIA_ID=" + _db.CreateSqlParameterName("CASO_GARANTIA_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CANTIDAD_PAGARES", value.CANTIDAD_PAGARES);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "NOMBRE_DEUDOR", value.NOMBRE_DEUDOR);
			AddParameter(cmd, "DOCUMENTO_DEUDOR", value.DOCUMENTO_DEUDOR);
			AddParameter(cmd, "TELEFONO_DEUDOR", value.TELEFONO_DEUDOR);
			AddParameter(cmd, "DIRECCION_DEUDOR", value.DIRECCION_DEUDOR);
			AddParameter(cmd, "NOMBRE_CODEUDOR", value.NOMBRE_CODEUDOR);
			AddParameter(cmd, "DOCUMENTO_CODEUDOR", value.DOCUMENTO_CODEUDOR);
			AddParameter(cmd, "TELEFONO_CODEUDOR", value.TELEFONO_CODEUDOR);
			AddParameter(cmd, "DIRECCION_CODEUDOR", value.DIRECCION_CODEUDOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "DOCUMENTO_BENEFICIARIO", value.DOCUMENTO_BENEFICIARIO);
			AddParameter(cmd, "TELEFONO_BENEFICIARIO", value.TELEFONO_BENEFICIARIO);
			AddParameter(cmd, "DIRECCION_BENEFICIARIO", value.DIRECCION_BENEFICIARIO);
			AddParameter(cmd, "FECHA_EMISION", value.FECHA_EMISION);
			AddParameter(cmd, "FECHA_FIRMA",
				value.IsFECHA_FIRMANull ? DBNull.Value : (object)value.FECHA_FIRMA);
			AddParameter(cmd, "FECHA_ANULADO",
				value.IsFECHA_ANULADONull ? DBNull.Value : (object)value.FECHA_ANULADO);
			AddParameter(cmd, "USUARIO_ANULADO_ID",
				value.IsUSUARIO_ANULADO_IDNull ? DBNull.Value : (object)value.USUARIO_ANULADO_ID);
			AddParameter(cmd, "JUEGO_PAGARES_APROBADO", value.JUEGO_PAGARES_APROBADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GARANTIA", value.GARANTIA);
			AddParameter(cmd, "CASO_GARANTIA_ID",
				value.IsCASO_GARANTIA_IDNull ? DBNull.Value : (object)value.CASO_GARANTIA_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGARES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGARES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGARESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PAGARESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PAGARES</c> table using
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_GARANTIA_ID(decimal caso_garantia_id)
		{
			return DeleteByCASO_GARANTIA_ID(caso_garantia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <param name="caso_garantia_idNull">true if the method ignores the caso_garantia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_GARANTIA_ID(decimal caso_garantia_id, bool caso_garantia_idNull)
		{
			return CreateDeleteByCASO_GARANTIA_IDCommand(caso_garantia_id, caso_garantia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_PER_CASO_GA</c> foreign key.
		/// </summary>
		/// <param name="caso_garantia_id">The <c>CASO_GARANTIA_ID</c> column value.</param>
		/// <param name="caso_garantia_idNull">true if the method ignores the caso_garantia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_GARANTIA_IDCommand(decimal caso_garantia_id, bool caso_garantia_idNull)
		{
			string whereSql = "";
			if(caso_garantia_idNull)
				whereSql += "CASO_GARANTIA_ID IS NULL";
			else
				whereSql += "CASO_GARANTIA_ID=" + _db.CreateSqlParameterName("CASO_GARANTIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_garantia_idNull)
				AddParameter(cmd, "CASO_GARANTIA_ID", caso_garantia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_PERSONA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_PERSONA_AUTO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_SUC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_USR</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ANULADO_ID(decimal usuario_anulado_id)
		{
			return DeleteByUSUARIO_ANULADO_ID(usuario_anulado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGARES</c> table using the 
		/// <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <param name="usuario_anulado_idNull">true if the method ignores the usuario_anulado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ANULADO_ID(decimal usuario_anulado_id, bool usuario_anulado_idNull)
		{
			return CreateDeleteByUSUARIO_ANULADO_IDCommand(usuario_anulado_id, usuario_anulado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGARES_USR_ANULA</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulado_id">The <c>USUARIO_ANULADO_ID</c> column value.</param>
		/// <param name="usuario_anulado_idNull">true if the method ignores the usuario_anulado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ANULADO_IDCommand(decimal usuario_anulado_id, bool usuario_anulado_idNull)
		{
			string whereSql = "";
			if(usuario_anulado_idNull)
				whereSql += "USUARIO_ANULADO_ID IS NULL";
			else
				whereSql += "USUARIO_ANULADO_ID=" + _db.CreateSqlParameterName("USUARIO_ANULADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_anulado_idNull)
				AddParameter(cmd, "USUARIO_ANULADO_ID", usuario_anulado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PAGARES</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PAGARES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PAGARES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PAGARES</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		protected CTACTE_PAGARESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		protected CTACTE_PAGARESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGARESRow"/> objects.</returns>
		protected virtual CTACTE_PAGARESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int cantidad_pagaresColumnIndex = reader.GetOrdinal("CANTIDAD_PAGARES");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int nombre_deudorColumnIndex = reader.GetOrdinal("NOMBRE_DEUDOR");
			int documento_deudorColumnIndex = reader.GetOrdinal("DOCUMENTO_DEUDOR");
			int telefono_deudorColumnIndex = reader.GetOrdinal("TELEFONO_DEUDOR");
			int direccion_deudorColumnIndex = reader.GetOrdinal("DIRECCION_DEUDOR");
			int nombre_codeudorColumnIndex = reader.GetOrdinal("NOMBRE_CODEUDOR");
			int documento_codeudorColumnIndex = reader.GetOrdinal("DOCUMENTO_CODEUDOR");
			int telefono_codeudorColumnIndex = reader.GetOrdinal("TELEFONO_CODEUDOR");
			int direccion_codeudorColumnIndex = reader.GetOrdinal("DIRECCION_CODEUDOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int documento_beneficiarioColumnIndex = reader.GetOrdinal("DOCUMENTO_BENEFICIARIO");
			int telefono_beneficiarioColumnIndex = reader.GetOrdinal("TELEFONO_BENEFICIARIO");
			int direccion_beneficiarioColumnIndex = reader.GetOrdinal("DIRECCION_BENEFICIARIO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int fecha_firmaColumnIndex = reader.GetOrdinal("FECHA_FIRMA");
			int fecha_anuladoColumnIndex = reader.GetOrdinal("FECHA_ANULADO");
			int usuario_anulado_idColumnIndex = reader.GetOrdinal("USUARIO_ANULADO_ID");
			int juego_pagares_aprobadoColumnIndex = reader.GetOrdinal("JUEGO_PAGARES_APROBADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int garantiaColumnIndex = reader.GetOrdinal("GARANTIA");
			int caso_garantia_idColumnIndex = reader.GetOrdinal("CASO_GARANTIA_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGARESRow record = new CTACTE_PAGARESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CANTIDAD_PAGARES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_pagaresColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					record.NOMBRE_DEUDOR = Convert.ToString(reader.GetValue(nombre_deudorColumnIndex));
					record.DOCUMENTO_DEUDOR = Convert.ToString(reader.GetValue(documento_deudorColumnIndex));
					if(!reader.IsDBNull(telefono_deudorColumnIndex))
						record.TELEFONO_DEUDOR = Convert.ToString(reader.GetValue(telefono_deudorColumnIndex));
					record.DIRECCION_DEUDOR = Convert.ToString(reader.GetValue(direccion_deudorColumnIndex));
					if(!reader.IsDBNull(nombre_codeudorColumnIndex))
						record.NOMBRE_CODEUDOR = Convert.ToString(reader.GetValue(nombre_codeudorColumnIndex));
					if(!reader.IsDBNull(documento_codeudorColumnIndex))
						record.DOCUMENTO_CODEUDOR = Convert.ToString(reader.GetValue(documento_codeudorColumnIndex));
					if(!reader.IsDBNull(telefono_codeudorColumnIndex))
						record.TELEFONO_CODEUDOR = Convert.ToString(reader.GetValue(telefono_codeudorColumnIndex));
					if(!reader.IsDBNull(direccion_codeudorColumnIndex))
						record.DIRECCION_CODEUDOR = Convert.ToString(reader.GetValue(direccion_codeudorColumnIndex));
					record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					record.DOCUMENTO_BENEFICIARIO = Convert.ToString(reader.GetValue(documento_beneficiarioColumnIndex));
					record.TELEFONO_BENEFICIARIO = Convert.ToString(reader.GetValue(telefono_beneficiarioColumnIndex));
					record.DIRECCION_BENEFICIARIO = Convert.ToString(reader.GetValue(direccion_beneficiarioColumnIndex));
					record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(fecha_firmaColumnIndex))
						record.FECHA_FIRMA = Convert.ToDateTime(reader.GetValue(fecha_firmaColumnIndex));
					if(!reader.IsDBNull(fecha_anuladoColumnIndex))
						record.FECHA_ANULADO = Convert.ToDateTime(reader.GetValue(fecha_anuladoColumnIndex));
					if(!reader.IsDBNull(usuario_anulado_idColumnIndex))
						record.USUARIO_ANULADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_anulado_idColumnIndex)), 9);
					record.JUEGO_PAGARES_APROBADO = Convert.ToString(reader.GetValue(juego_pagares_aprobadoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.GARANTIA = Convert.ToString(reader.GetValue(garantiaColumnIndex));
					if(!reader.IsDBNull(caso_garantia_idColumnIndex))
						record.CASO_GARANTIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_garantia_idColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGARESRow[])(recordList.ToArray(typeof(CTACTE_PAGARESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGARESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGARESRow"/> object.</returns>
		protected virtual CTACTE_PAGARESRow MapRow(DataRow row)
		{
			CTACTE_PAGARESRow mappedObject = new CTACTE_PAGARESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD_PAGARES"
			dataColumn = dataTable.Columns["CANTIDAD_PAGARES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PAGARES = (decimal)row[dataColumn];
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
			// Column "NOMBRE_DEUDOR"
			dataColumn = dataTable.Columns["NOMBRE_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_DEUDOR = (string)row[dataColumn];
			// Column "DOCUMENTO_DEUDOR"
			dataColumn = dataTable.Columns["DOCUMENTO_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_DEUDOR = (string)row[dataColumn];
			// Column "TELEFONO_DEUDOR"
			dataColumn = dataTable.Columns["TELEFONO_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_DEUDOR = (string)row[dataColumn];
			// Column "DIRECCION_DEUDOR"
			dataColumn = dataTable.Columns["DIRECCION_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_DEUDOR = (string)row[dataColumn];
			// Column "NOMBRE_CODEUDOR"
			dataColumn = dataTable.Columns["NOMBRE_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_CODEUDOR = (string)row[dataColumn];
			// Column "DOCUMENTO_CODEUDOR"
			dataColumn = dataTable.Columns["DOCUMENTO_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_CODEUDOR = (string)row[dataColumn];
			// Column "TELEFONO_CODEUDOR"
			dataColumn = dataTable.Columns["TELEFONO_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_CODEUDOR = (string)row[dataColumn];
			// Column "DIRECCION_CODEUDOR"
			dataColumn = dataTable.Columns["DIRECCION_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_CODEUDOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "DOCUMENTO_BENEFICIARIO"
			dataColumn = dataTable.Columns["DOCUMENTO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_BENEFICIARIO = (string)row[dataColumn];
			// Column "TELEFONO_BENEFICIARIO"
			dataColumn = dataTable.Columns["TELEFONO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_BENEFICIARIO = (string)row[dataColumn];
			// Column "DIRECCION_BENEFICIARIO"
			dataColumn = dataTable.Columns["DIRECCION_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIRMA"
			dataColumn = dataTable.Columns["FECHA_FIRMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIRMA = (System.DateTime)row[dataColumn];
			// Column "FECHA_ANULADO"
			dataColumn = dataTable.Columns["FECHA_ANULADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ANULADO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ANULADO_ID"
			dataColumn = dataTable.Columns["USUARIO_ANULADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ANULADO_ID = (decimal)row[dataColumn];
			// Column "JUEGO_PAGARES_APROBADO"
			dataColumn = dataTable.Columns["JUEGO_PAGARES_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUEGO_PAGARES_APROBADO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "GARANTIA"
			dataColumn = dataTable.Columns["GARANTIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GARANTIA = (string)row[dataColumn];
			// Column "CASO_GARANTIA_ID"
			dataColumn = dataTable.Columns["CASO_GARANTIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_GARANTIA_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGARES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_PAGARES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_DEUDOR", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_DEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TELEFONO_DEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DIRECCION_DEUDOR", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TELEFONO_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DIRECCION_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TELEFONO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIRECCION_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIRMA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ANULADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_ANULADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("JUEGO_PAGARES_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GARANTIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_GARANTIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD_PAGARES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "NOMBRE_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIRMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ANULADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ANULADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "JUEGO_PAGARES_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GARANTIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_GARANTIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGARESCollection_Base class
}  // End of namespace
