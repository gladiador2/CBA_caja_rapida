// <fileinfo name="ORDENES_SERVICIOCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_SERVICIOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TITULOColumnName = "TITULO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string CASO_ORIGINARIO_IDColumnName = "CASO_ORIGINARIO_ID";
		public const string DEBE_FACTURARColumnName = "DEBE_FACTURAR";
		public const string VISTO_BUENO_FUNCIONARIOColumnName = "VISTO_BUENO_FUNCIONARIO";
		public const string VISTO_BUENO_PERSONAColumnName = "VISTO_BUENO_PERSONA";
		public const string VISTO_BUENO_GERENCIAColumnName = "VISTO_BUENO_GERENCIA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string ES_PARA_CLIENTEColumnName = "ES_PARA_CLIENTE";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string ANTICIPO_REQUERIDOColumnName = "ANTICIPO_REQUERIDO";
		public const string ANTICIPO_GENERARColumnName = "ANTICIPO_GENERAR";
		public const string ANTICIPO_MONTOColumnName = "ANTICIPO_MONTO";
		public const string APLICAR_RETENCIONColumnName = "APLICAR_RETENCION";
		public const string FACTURA_DETALLADAColumnName = "FACTURA_DETALLADA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_SERVICIOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_SERVICIORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_SERVICIORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_SERVICIORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_SERVICIORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_SERVICIO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ORDENES_SERVICIORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ORDENES_SERVICIORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ORDENES_SERVICIORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ORDENES_SERVICIORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByCASO_ORIGINARIO_ID(decimal caso_originario_id)
		{
			return GetByCASO_ORIGINARIO_ID(caso_originario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByCASO_ORIGINARIO_ID(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return MapRecords(CreateGetByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ORIGINARIO_IDAsDataTable(decimal caso_originario_id)
		{
			return GetByCASO_ORIGINARIO_IDAsDataTable(caso_originario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGINARIO_IDAsDataTable(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGINARIO_IDCommand(decimal caso_originario_id, bool caso_originario_idNull)
		{
			string whereSql = "";
			if(caso_originario_idNull)
				whereSql += "CASO_ORIGINARIO_ID IS NULL";
			else
				whereSql += "CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_originario_idNull)
				AddParameter(cmd, "CASO_ORIGINARIO_ID", caso_originario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_IDAsDataTable(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public ORDENES_SERVICIORow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_SUCURSAL_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIORow"/> objects 
		/// by the <c>FK_ORDENES_SERV_TEXT_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		public virtual ORDENES_SERVICIORow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_SERV_TEXT_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_SERV_TEXT_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIORow"/> object to be inserted.</param>
		public virtual void Insert(ORDENES_SERVICIORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ORDENES_SERVICIO (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"TITULO, " +
				"DESCRIPCION, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"CASO_ORIGINARIO_ID, " +
				"DEBE_FACTURAR, " +
				"VISTO_BUENO_FUNCIONARIO, " +
				"VISTO_BUENO_PERSONA, " +
				"VISTO_BUENO_GERENCIA, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"ES_PARA_CLIENTE, " +
				"PROVEEDOR_ID, " +
				"CENTRO_COSTO_ID, " +
				"CONDICION_PAGO_ID, " +
				"ANTICIPO_REQUERIDO, " +
				"ANTICIPO_GENERAR, " +
				"ANTICIPO_MONTO, " +
				"APLICAR_RETENCION, " +
				"FACTURA_DETALLADA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("TITULO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGINARIO_ID") + ", " +
				_db.CreateSqlParameterName("DEBE_FACTURAR") + ", " +
				_db.CreateSqlParameterName("VISTO_BUENO_FUNCIONARIO") + ", " +
				_db.CreateSqlParameterName("VISTO_BUENO_PERSONA") + ", " +
				_db.CreateSqlParameterName("VISTO_BUENO_GERENCIA") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("ES_PARA_CLIENTE") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_REQUERIDO") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_GENERAR") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_MONTO") + ", " +
				_db.CreateSqlParameterName("APLICAR_RETENCION") + ", " +
				_db.CreateSqlParameterName("FACTURA_DETALLADA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TITULO", value.TITULO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "CASO_ORIGINARIO_ID",
				value.IsCASO_ORIGINARIO_IDNull ? DBNull.Value : (object)value.CASO_ORIGINARIO_ID);
			AddParameter(cmd, "DEBE_FACTURAR", value.DEBE_FACTURAR);
			AddParameter(cmd, "VISTO_BUENO_FUNCIONARIO", value.VISTO_BUENO_FUNCIONARIO);
			AddParameter(cmd, "VISTO_BUENO_PERSONA", value.VISTO_BUENO_PERSONA);
			AddParameter(cmd, "VISTO_BUENO_GERENCIA", value.VISTO_BUENO_GERENCIA);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ES_PARA_CLIENTE", value.ES_PARA_CLIENTE);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "ANTICIPO_REQUERIDO", value.ANTICIPO_REQUERIDO);
			AddParameter(cmd, "ANTICIPO_GENERAR", value.ANTICIPO_GENERAR);
			AddParameter(cmd, "ANTICIPO_MONTO",
				value.IsANTICIPO_MONTONull ? DBNull.Value : (object)value.ANTICIPO_MONTO);
			AddParameter(cmd, "APLICAR_RETENCION", value.APLICAR_RETENCION);
			AddParameter(cmd, "FACTURA_DETALLADA", value.FACTURA_DETALLADA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ORDENES_SERVICIORow value)
		{
			
			string sqlStr = "UPDATE TRC.ORDENES_SERVICIO SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"TITULO=" + _db.CreateSqlParameterName("TITULO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID") + ", " +
				"DEBE_FACTURAR=" + _db.CreateSqlParameterName("DEBE_FACTURAR") + ", " +
				"VISTO_BUENO_FUNCIONARIO=" + _db.CreateSqlParameterName("VISTO_BUENO_FUNCIONARIO") + ", " +
				"VISTO_BUENO_PERSONA=" + _db.CreateSqlParameterName("VISTO_BUENO_PERSONA") + ", " +
				"VISTO_BUENO_GERENCIA=" + _db.CreateSqlParameterName("VISTO_BUENO_GERENCIA") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"ES_PARA_CLIENTE=" + _db.CreateSqlParameterName("ES_PARA_CLIENTE") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				"ANTICIPO_REQUERIDO=" + _db.CreateSqlParameterName("ANTICIPO_REQUERIDO") + ", " +
				"ANTICIPO_GENERAR=" + _db.CreateSqlParameterName("ANTICIPO_GENERAR") + ", " +
				"ANTICIPO_MONTO=" + _db.CreateSqlParameterName("ANTICIPO_MONTO") + ", " +
				"APLICAR_RETENCION=" + _db.CreateSqlParameterName("APLICAR_RETENCION") + ", " +
				"FACTURA_DETALLADA=" + _db.CreateSqlParameterName("FACTURA_DETALLADA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TITULO", value.TITULO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "CASO_ORIGINARIO_ID",
				value.IsCASO_ORIGINARIO_IDNull ? DBNull.Value : (object)value.CASO_ORIGINARIO_ID);
			AddParameter(cmd, "DEBE_FACTURAR", value.DEBE_FACTURAR);
			AddParameter(cmd, "VISTO_BUENO_FUNCIONARIO", value.VISTO_BUENO_FUNCIONARIO);
			AddParameter(cmd, "VISTO_BUENO_PERSONA", value.VISTO_BUENO_PERSONA);
			AddParameter(cmd, "VISTO_BUENO_GERENCIA", value.VISTO_BUENO_GERENCIA);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ES_PARA_CLIENTE", value.ES_PARA_CLIENTE);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "ANTICIPO_REQUERIDO", value.ANTICIPO_REQUERIDO);
			AddParameter(cmd, "ANTICIPO_GENERAR", value.ANTICIPO_GENERAR);
			AddParameter(cmd, "ANTICIPO_MONTO",
				value.IsANTICIPO_MONTONull ? DBNull.Value : (object)value.ANTICIPO_MONTO);
			AddParameter(cmd, "APLICAR_RETENCION", value.APLICAR_RETENCION);
			AddParameter(cmd, "FACTURA_DETALLADA", value.FACTURA_DETALLADA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ORDENES_SERVICIO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ORDENES_SERVICIO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ORDENES_SERVICIORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ORDENES_SERVICIO</c> table using
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
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_SERV_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGINARIO_ID(decimal caso_originario_id)
		{
			return DeleteByCASO_ORIGINARIO_ID(caso_originario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGINARIO_ID(decimal caso_originario_id, bool caso_originario_idNull)
		{
			return CreateDeleteByCASO_ORIGINARIO_IDCommand(caso_originario_id, caso_originario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_CASO_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_originario_id">The <c>CASO_ORIGINARIO_ID</c> column value.</param>
		/// <param name="caso_originario_idNull">true if the method ignores the caso_originario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGINARIO_IDCommand(decimal caso_originario_id, bool caso_originario_idNull)
		{
			string whereSql = "";
			if(caso_originario_idNull)
				whereSql += "CASO_ORIGINARIO_ID IS NULL";
			else
				whereSql += "CASO_ORIGINARIO_ID=" + _db.CreateSqlParameterName("CASO_ORIGINARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_originario_idNull)
				AddParameter(cmd, "CASO_ORIGINARIO_ID", caso_originario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_CEN_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return DeleteByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_COND_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_SERV_PROVEEDORES_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_SUCURSAL_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO</c> table using the 
		/// <c>FK_ORDENES_SERV_TEXT_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_SERV_TEXT_PREDEF_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ORDENES_SERVICIO</c> records that match the specified criteria.
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
		/// to delete <c>ORDENES_SERVICIO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ORDENES_SERVICIO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ORDENES_SERVICIO</c> table.
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
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		protected ORDENES_SERVICIORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		protected ORDENES_SERVICIORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIORow"/> objects.</returns>
		protected virtual ORDENES_SERVICIORow[] MapRecords(IDataReader reader, 
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
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int tituloColumnIndex = reader.GetOrdinal("TITULO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int caso_originario_idColumnIndex = reader.GetOrdinal("CASO_ORIGINARIO_ID");
			int debe_facturarColumnIndex = reader.GetOrdinal("DEBE_FACTURAR");
			int visto_bueno_funcionarioColumnIndex = reader.GetOrdinal("VISTO_BUENO_FUNCIONARIO");
			int visto_bueno_personaColumnIndex = reader.GetOrdinal("VISTO_BUENO_PERSONA");
			int visto_bueno_gerenciaColumnIndex = reader.GetOrdinal("VISTO_BUENO_GERENCIA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int es_para_clienteColumnIndex = reader.GetOrdinal("ES_PARA_CLIENTE");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int anticipo_requeridoColumnIndex = reader.GetOrdinal("ANTICIPO_REQUERIDO");
			int anticipo_generarColumnIndex = reader.GetOrdinal("ANTICIPO_GENERAR");
			int anticipo_montoColumnIndex = reader.GetOrdinal("ANTICIPO_MONTO");
			int aplicar_retencionColumnIndex = reader.GetOrdinal("APLICAR_RETENCION");
			int factura_detalladaColumnIndex = reader.GetOrdinal("FACTURA_DETALLADA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_SERVICIORow record = new ORDENES_SERVICIORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(tituloColumnIndex))
						record.TITULO = Convert.ToString(reader.GetValue(tituloColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(caso_originario_idColumnIndex))
						record.CASO_ORIGINARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_originario_idColumnIndex)), 9);
					record.DEBE_FACTURAR = Convert.ToString(reader.GetValue(debe_facturarColumnIndex));
					record.VISTO_BUENO_FUNCIONARIO = Convert.ToString(reader.GetValue(visto_bueno_funcionarioColumnIndex));
					record.VISTO_BUENO_PERSONA = Convert.ToString(reader.GetValue(visto_bueno_personaColumnIndex));
					record.VISTO_BUENO_GERENCIA = Convert.ToString(reader.GetValue(visto_bueno_gerenciaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.ES_PARA_CLIENTE = Convert.ToString(reader.GetValue(es_para_clienteColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_requeridoColumnIndex))
						record.ANTICIPO_REQUERIDO = Convert.ToString(reader.GetValue(anticipo_requeridoColumnIndex));
					if(!reader.IsDBNull(anticipo_generarColumnIndex))
						record.ANTICIPO_GENERAR = Convert.ToString(reader.GetValue(anticipo_generarColumnIndex));
					if(!reader.IsDBNull(anticipo_montoColumnIndex))
						record.ANTICIPO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(aplicar_retencionColumnIndex))
						record.APLICAR_RETENCION = Convert.ToString(reader.GetValue(aplicar_retencionColumnIndex));
					if(!reader.IsDBNull(factura_detalladaColumnIndex))
						record.FACTURA_DETALLADA = Convert.ToString(reader.GetValue(factura_detalladaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_SERVICIORow[])(recordList.ToArray(typeof(ORDENES_SERVICIORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_SERVICIORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_SERVICIORow"/> object.</returns>
		protected virtual ORDENES_SERVICIORow MapRow(DataRow row)
		{
			ORDENES_SERVICIORow mappedObject = new ORDENES_SERVICIORow();
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
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TITULO"
			dataColumn = dataTable.Columns["TITULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "CASO_ORIGINARIO_ID"
			dataColumn = dataTable.Columns["CASO_ORIGINARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGINARIO_ID = (decimal)row[dataColumn];
			// Column "DEBE_FACTURAR"
			dataColumn = dataTable.Columns["DEBE_FACTURAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE_FACTURAR = (string)row[dataColumn];
			// Column "VISTO_BUENO_FUNCIONARIO"
			dataColumn = dataTable.Columns["VISTO_BUENO_FUNCIONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_FUNCIONARIO = (string)row[dataColumn];
			// Column "VISTO_BUENO_PERSONA"
			dataColumn = dataTable.Columns["VISTO_BUENO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_PERSONA = (string)row[dataColumn];
			// Column "VISTO_BUENO_GERENCIA"
			dataColumn = dataTable.Columns["VISTO_BUENO_GERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_GERENCIA = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "ES_PARA_CLIENTE"
			dataColumn = dataTable.Columns["ES_PARA_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_PARA_CLIENTE = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_REQUERIDO"
			dataColumn = dataTable.Columns["ANTICIPO_REQUERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_REQUERIDO = (string)row[dataColumn];
			// Column "ANTICIPO_GENERAR"
			dataColumn = dataTable.Columns["ANTICIPO_GENERAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_GENERAR = (string)row[dataColumn];
			// Column "ANTICIPO_MONTO"
			dataColumn = dataTable.Columns["ANTICIPO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_MONTO = (decimal)row[dataColumn];
			// Column "APLICAR_RETENCION"
			dataColumn = dataTable.Columns["APLICAR_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_RETENCION = (string)row[dataColumn];
			// Column "FACTURA_DETALLADA"
			dataColumn = dataTable.Columns["FACTURA_DETALLADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_DETALLADA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_SERVICIO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_SERVICIO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TITULO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CASO_ORIGINARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEBE_FACTURAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_FUNCIONARIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_GERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ES_PARA_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANTICIPO_REQUERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ANTICIPO_GENERAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ANTICIPO_MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICAR_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FACTURA_DETALLADA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TITULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ORIGINARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBE_FACTURAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_FUNCIONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_GERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_PARA_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_REQUERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ANTICIPO_GENERAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ANTICIPO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURA_DETALLADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_SERVICIOCollection_Base class
}  // End of namespace
