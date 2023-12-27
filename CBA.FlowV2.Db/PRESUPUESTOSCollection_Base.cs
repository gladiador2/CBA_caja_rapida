// <fileinfo name="PRESUPUESTOSCollection_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRESUPUESTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_VALIDEZColumnName = "FECHA_VALIDEZ";
		public const string FECHA_ENTREGAColumnName = "FECHA_ENTREGA";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string OBJETOColumnName = "OBJETO";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";
		public const string TEXTO_PREDEFINIDO_TIPO_IDColumnName = "TEXTO_PREDEFINIDO_TIPO_ID";
		public const string TEXTO_PREDEFINIDO_FUERO_IDColumnName = "TEXTO_PREDEFINIDO_FUERO_ID";
		public const string TRAMITES_TIPOS_IDColumnName = "TRAMITES_TIPOS_ID";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string PERSONA_GARANTE_1_IDColumnName = "PERSONA_GARANTE_1_ID";
		public const string PERSONA_GARANTE_2_IDColumnName = "PERSONA_GARANTE_2_ID";
		public const string PERSONA_GARANTE_3_IDColumnName = "PERSONA_GARANTE_3_ID";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_MONTOColumnName = "ARTICULO_MONTO";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRESUPUESTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRESUPUESTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRESUPUESTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRESUPUESTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRESUPUESTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PRESUPUESTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PRESUPUESTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PRESUPUESTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
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
		/// return records by the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id)
		{
			return GetByPERSONA_GARANTE_1_ID(persona_garante_1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_1_IDAsDataTable(decimal persona_garante_1_id)
		{
			return GetByPERSONA_GARANTE_1_IDAsDataTable(persona_garante_1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_1_IDAsDataTable(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_1_IDCommand(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			string whereSql = "";
			if(persona_garante_1_idNull)
				whereSql += "PERSONA_GARANTE_1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_1_ID", persona_garante_1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id)
		{
			return GetByPERSONA_GARANTE_2_ID(persona_garante_2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_2_IDAsDataTable(decimal persona_garante_2_id)
		{
			return GetByPERSONA_GARANTE_2_IDAsDataTable(persona_garante_2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_2_IDAsDataTable(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_2_IDCommand(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			string whereSql = "";
			if(persona_garante_2_idNull)
				whereSql += "PERSONA_GARANTE_2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_2_ID", persona_garante_2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id)
		{
			return GetByPERSONA_GARANTE_3_ID(persona_garante_3_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_3_IDAsDataTable(decimal persona_garante_3_id)
		{
			return GetByPERSONA_GARANTE_3_IDAsDataTable(persona_garante_3_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_3_IDAsDataTable(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_3_IDCommand(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			string whereSql = "";
			if(persona_garante_3_idNull)
				whereSql += "PERSONA_GARANTE_3_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_3_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_3_ID", persona_garante_3_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByTEXTO_PREDEFINIDO_FUERO_ID(decimal texto_predefinido_fuero_id)
		{
			return GetByTEXTO_PREDEFINIDO_FUERO_ID(texto_predefinido_fuero_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <param name="texto_predefinido_fuero_idNull">true if the method ignores the texto_predefinido_fuero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByTEXTO_PREDEFINIDO_FUERO_ID(decimal texto_predefinido_fuero_id, bool texto_predefinido_fuero_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_FUERO_IDCommand(texto_predefinido_fuero_id, texto_predefinido_fuero_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_FUERO_IDAsDataTable(decimal texto_predefinido_fuero_id)
		{
			return GetByTEXTO_PREDEFINIDO_FUERO_IDAsDataTable(texto_predefinido_fuero_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <param name="texto_predefinido_fuero_idNull">true if the method ignores the texto_predefinido_fuero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_FUERO_IDAsDataTable(decimal texto_predefinido_fuero_id, bool texto_predefinido_fuero_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_FUERO_IDCommand(texto_predefinido_fuero_id, texto_predefinido_fuero_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <param name="texto_predefinido_fuero_idNull">true if the method ignores the texto_predefinido_fuero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_FUERO_IDCommand(decimal texto_predefinido_fuero_id, bool texto_predefinido_fuero_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_fuero_idNull)
				whereSql += "TEXTO_PREDEFINIDO_FUERO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_FUERO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_FUERO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_fuero_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_FUERO_ID", texto_predefinido_fuero_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByTRAMITES_TIPOS_ID(decimal tramites_tipos_id)
		{
			return GetByTRAMITES_TIPOS_ID(tramites_tipos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <param name="tramites_tipos_idNull">true if the method ignores the tramites_tipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByTRAMITES_TIPOS_ID(decimal tramites_tipos_id, bool tramites_tipos_idNull)
		{
			return MapRecords(CreateGetByTRAMITES_TIPOS_IDCommand(tramites_tipos_id, tramites_tipos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRAMITES_TIPOS_IDAsDataTable(decimal tramites_tipos_id)
		{
			return GetByTRAMITES_TIPOS_IDAsDataTable(tramites_tipos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <param name="tramites_tipos_idNull">true if the method ignores the tramites_tipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRAMITES_TIPOS_IDAsDataTable(decimal tramites_tipos_id, bool tramites_tipos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRAMITES_TIPOS_IDCommand(tramites_tipos_id, tramites_tipos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <param name="tramites_tipos_idNull">true if the method ignores the tramites_tipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRAMITES_TIPOS_IDCommand(decimal tramites_tipos_id, bool tramites_tipos_idNull)
		{
			string whereSql = "";
			if(tramites_tipos_idNull)
				whereSql += "TRAMITES_TIPOS_ID IS NULL";
			else
				whereSql += "TRAMITES_TIPOS_ID=" + _db.CreateSqlParameterName("TRAMITES_TIPOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tramites_tipos_idNull)
				AddParameter(cmd, "TRAMITES_TIPOS_ID", tramites_tipos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByVEHICULO_ID(decimal vehiculo_id)
		{
			return GetByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecords(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id)
		{
			return GetByVEHICULO_IDAsDataTable(vehiculo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecords(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_IDAsDataTable(caso_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_FUNCIONARIO_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_PERSONA_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_SUCURSAL_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public PRESUPUESTOSRow[] GetByTEXTO_PREDEFINIDO_TIPO_ID(decimal texto_predefinido_tipo_id)
		{
			return GetByTEXTO_PREDEFINIDO_TIPO_ID(texto_predefinido_tipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOSRow"/> objects 
		/// by the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <param name="texto_predefinido_tipo_idNull">true if the method ignores the texto_predefinido_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		public virtual PRESUPUESTOSRow[] GetByTEXTO_PREDEFINIDO_TIPO_ID(decimal texto_predefinido_tipo_id, bool texto_predefinido_tipo_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_TIPO_IDCommand(texto_predefinido_tipo_id, texto_predefinido_tipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_TIPO_IDAsDataTable(decimal texto_predefinido_tipo_id)
		{
			return GetByTEXTO_PREDEFINIDO_TIPO_IDAsDataTable(texto_predefinido_tipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <param name="texto_predefinido_tipo_idNull">true if the method ignores the texto_predefinido_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_TIPO_IDAsDataTable(decimal texto_predefinido_tipo_id, bool texto_predefinido_tipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_TIPO_IDCommand(texto_predefinido_tipo_id, texto_predefinido_tipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <param name="texto_predefinido_tipo_idNull">true if the method ignores the texto_predefinido_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_TIPO_IDCommand(decimal texto_predefinido_tipo_id, bool texto_predefinido_tipo_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_tipo_idNull)
				whereSql += "TEXTO_PREDEFINIDO_TIPO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_TIPO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_TIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_tipo_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_TIPO_ID", texto_predefinido_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOSRow"/> object to be inserted.</param>
		public virtual void Insert(PRESUPUESTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PRESUPUESTOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"FECHA_CREACION, " +
				"FECHA_VALIDEZ, " +
				"FECHA_ENTREGA, " +
				"FECHA_APROBACION, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"OBSERVACION, " +
				"FUNCIONARIO_ID, " +
				"OBJETO, " +
				"CASO_ORIGEN_ID, " +
				"TEXTO_PREDEFINIDO_TIPO_ID, " +
				"TEXTO_PREDEFINIDO_FUERO_ID, " +
				"TRAMITES_TIPOS_ID, " +
				"VEHICULO_ID, " +
				"PERSONA_GARANTE_1_ID, " +
				"PERSONA_GARANTE_2_ID, " +
				"PERSONA_GARANTE_3_ID, " +
				"NRO_COMPROBANTE_EXTERNO, " +
				"ARTICULO_ID, " +
				"ARTICULO_MONTO, " +
				"LISTA_PRECIO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_VALIDEZ") + ", " +
				_db.CreateSqlParameterName("FECHA_ENTREGA") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("OBJETO") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_TIPO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_FUERO_ID") + ", " +
				_db.CreateSqlParameterName("TRAMITES_TIPOS_ID") + ", " +
				_db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_1_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_2_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_3_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_MONTO") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_VALIDEZ", value.FECHA_VALIDEZ);
			AddParameter(cmd, "FECHA_ENTREGA",
				value.IsFECHA_ENTREGANull ? DBNull.Value : (object)value.FECHA_ENTREGA);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "OBJETO", value.OBJETO);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_TIPO_ID",
				value.IsTEXTO_PREDEFINIDO_TIPO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_TIPO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_FUERO_ID",
				value.IsTEXTO_PREDEFINIDO_FUERO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_FUERO_ID);
			AddParameter(cmd, "TRAMITES_TIPOS_ID",
				value.IsTRAMITES_TIPOS_IDNull ? DBNull.Value : (object)value.TRAMITES_TIPOS_ID);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "PERSONA_GARANTE_1_ID",
				value.IsPERSONA_GARANTE_1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_1_ID);
			AddParameter(cmd, "PERSONA_GARANTE_2_ID",
				value.IsPERSONA_GARANTE_2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_2_ID);
			AddParameter(cmd, "PERSONA_GARANTE_3_ID",
				value.IsPERSONA_GARANTE_3_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_3_ID);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "ARTICULO_MONTO",
				value.IsARTICULO_MONTONull ? DBNull.Value : (object)value.ARTICULO_MONTO);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PRESUPUESTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.PRESUPUESTOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_VALIDEZ=" + _db.CreateSqlParameterName("FECHA_VALIDEZ") + ", " +
				"FECHA_ENTREGA=" + _db.CreateSqlParameterName("FECHA_ENTREGA") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"OBJETO=" + _db.CreateSqlParameterName("OBJETO") + ", " +
				"CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				"TEXTO_PREDEFINIDO_TIPO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_TIPO_ID") + ", " +
				"TEXTO_PREDEFINIDO_FUERO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_FUERO_ID") + ", " +
				"TRAMITES_TIPOS_ID=" + _db.CreateSqlParameterName("TRAMITES_TIPOS_ID") + ", " +
				"VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				"PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID") + ", " +
				"PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID") + ", " +
				"PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID") + ", " +
				"NRO_COMPROBANTE_EXTERNO=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"ARTICULO_MONTO=" + _db.CreateSqlParameterName("ARTICULO_MONTO") + ", " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_VALIDEZ", value.FECHA_VALIDEZ);
			AddParameter(cmd, "FECHA_ENTREGA",
				value.IsFECHA_ENTREGANull ? DBNull.Value : (object)value.FECHA_ENTREGA);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "OBJETO", value.OBJETO);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_TIPO_ID",
				value.IsTEXTO_PREDEFINIDO_TIPO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_TIPO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_FUERO_ID",
				value.IsTEXTO_PREDEFINIDO_FUERO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_FUERO_ID);
			AddParameter(cmd, "TRAMITES_TIPOS_ID",
				value.IsTRAMITES_TIPOS_IDNull ? DBNull.Value : (object)value.TRAMITES_TIPOS_ID);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "PERSONA_GARANTE_1_ID",
				value.IsPERSONA_GARANTE_1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_1_ID);
			AddParameter(cmd, "PERSONA_GARANTE_2_ID",
				value.IsPERSONA_GARANTE_2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_2_ID);
			AddParameter(cmd, "PERSONA_GARANTE_3_ID",
				value.IsPERSONA_GARANTE_3_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_3_ID);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "ARTICULO_MONTO",
				value.IsARTICULO_MONTONull ? DBNull.Value : (object)value.ARTICULO_MONTO);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PRESUPUESTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PRESUPUESTOS</c> table using
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRESUP_AUTONUMERACION_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id)
		{
			return DeleteByPERSONA_GARANTE_1_ID(persona_garante_1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_PERSONA_GARAN_1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_1_IDCommand(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			string whereSql = "";
			if(persona_garante_1_idNull)
				whereSql += "PERSONA_GARANTE_1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_1_ID", persona_garante_1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id)
		{
			return DeleteByPERSONA_GARANTE_2_ID(persona_garante_2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_PERSONA_GARAN_2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_2_IDCommand(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			string whereSql = "";
			if(persona_garante_2_idNull)
				whereSql += "PERSONA_GARANTE_2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_2_ID", persona_garante_2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id)
		{
			return DeleteByPERSONA_GARANTE_3_ID(persona_garante_3_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_PERSONA_GARAN_3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_3_IDCommand(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			string whereSql = "";
			if(persona_garante_3_idNull)
				whereSql += "PERSONA_GARANTE_3_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_3_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_3_ID", persona_garante_3_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTO_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return CreateDeleteByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTO_LISTA_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_FUERO_ID(decimal texto_predefinido_fuero_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_FUERO_ID(texto_predefinido_fuero_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <param name="texto_predefinido_fuero_idNull">true if the method ignores the texto_predefinido_fuero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_FUERO_ID(decimal texto_predefinido_fuero_id, bool texto_predefinido_fuero_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_FUERO_IDCommand(texto_predefinido_fuero_id, texto_predefinido_fuero_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTO_TEXT_PRED_FUERO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_fuero_id">The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</param>
		/// <param name="texto_predefinido_fuero_idNull">true if the method ignores the texto_predefinido_fuero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_FUERO_IDCommand(decimal texto_predefinido_fuero_id, bool texto_predefinido_fuero_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_fuero_idNull)
				whereSql += "TEXTO_PREDEFINIDO_FUERO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_FUERO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_FUERO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_fuero_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_FUERO_ID", texto_predefinido_fuero_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRAMITES_TIPOS_ID(decimal tramites_tipos_id)
		{
			return DeleteByTRAMITES_TIPOS_ID(tramites_tipos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <param name="tramites_tipos_idNull">true if the method ignores the tramites_tipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRAMITES_TIPOS_ID(decimal tramites_tipos_id, bool tramites_tipos_idNull)
		{
			return CreateDeleteByTRAMITES_TIPOS_IDCommand(tramites_tipos_id, tramites_tipos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTO_TRAMITES_TIPOS</c> foreign key.
		/// </summary>
		/// <param name="tramites_tipos_id">The <c>TRAMITES_TIPOS_ID</c> column value.</param>
		/// <param name="tramites_tipos_idNull">true if the method ignores the tramites_tipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRAMITES_TIPOS_IDCommand(decimal tramites_tipos_id, bool tramites_tipos_idNull)
		{
			string whereSql = "";
			if(tramites_tipos_idNull)
				whereSql += "TRAMITES_TIPOS_ID IS NULL";
			else
				whereSql += "TRAMITES_TIPOS_ID=" + _db.CreateSqlParameterName("TRAMITES_TIPOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tramites_tipos_idNull)
				AddParameter(cmd, "TRAMITES_TIPOS_ID", tramites_tipos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id)
		{
			return DeleteByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return CreateDeleteByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return DeleteByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return CreateDeleteByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_CASO_ORIGEN_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_FUNCIONARIO_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_PERSONA_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_SUCURSAL_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_TIPO_ID(decimal texto_predefinido_tipo_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_TIPO_ID(texto_predefinido_tipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS</c> table using the 
		/// <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <param name="texto_predefinido_tipo_idNull">true if the method ignores the texto_predefinido_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_TIPO_ID(decimal texto_predefinido_tipo_id, bool texto_predefinido_tipo_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_TIPO_IDCommand(texto_predefinido_tipo_id, texto_predefinido_tipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUPUESTOS_TEXT_PRED_TIPO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_tipo_id">The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</param>
		/// <param name="texto_predefinido_tipo_idNull">true if the method ignores the texto_predefinido_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_TIPO_IDCommand(decimal texto_predefinido_tipo_id, bool texto_predefinido_tipo_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_tipo_idNull)
				whereSql += "TEXTO_PREDEFINIDO_TIPO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_TIPO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_TIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_tipo_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_TIPO_ID", texto_predefinido_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PRESUPUESTOS</c> records that match the specified criteria.
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
		/// to delete <c>PRESUPUESTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PRESUPUESTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PRESUPUESTOS</c> table.
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
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		protected PRESUPUESTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		protected PRESUPUESTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRESUPUESTOSRow"/> objects.</returns>
		protected virtual PRESUPUESTOSRow[] MapRecords(IDataReader reader, 
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
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_validezColumnIndex = reader.GetOrdinal("FECHA_VALIDEZ");
			int fecha_entregaColumnIndex = reader.GetOrdinal("FECHA_ENTREGA");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int objetoColumnIndex = reader.GetOrdinal("OBJETO");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");
			int texto_predefinido_tipo_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_TIPO_ID");
			int texto_predefinido_fuero_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_FUERO_ID");
			int tramites_tipos_idColumnIndex = reader.GetOrdinal("TRAMITES_TIPOS_ID");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int persona_garante_1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_1_ID");
			int persona_garante_2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_2_ID");
			int persona_garante_3_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_3_ID");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_montoColumnIndex = reader.GetOrdinal("ARTICULO_MONTO");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRESUPUESTOSRow record = new PRESUPUESTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.FECHA_VALIDEZ = Convert.ToDateTime(reader.GetValue(fecha_validezColumnIndex));
					if(!reader.IsDBNull(fecha_entregaColumnIndex))
						record.FECHA_ENTREGA = Convert.ToDateTime(reader.GetValue(fecha_entregaColumnIndex));
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(objetoColumnIndex))
						record.OBJETO = Convert.ToString(reader.GetValue(objetoColumnIndex));
					if(!reader.IsDBNull(caso_origen_idColumnIndex))
						record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_tipo_idColumnIndex))
						record.TEXTO_PREDEFINIDO_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_fuero_idColumnIndex))
						record.TEXTO_PREDEFINIDO_FUERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_fuero_idColumnIndex)), 9);
					if(!reader.IsDBNull(tramites_tipos_idColumnIndex))
						record.TRAMITES_TIPOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramites_tipos_idColumnIndex)), 9);
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_1_idColumnIndex))
						record.PERSONA_GARANTE_1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_2_idColumnIndex))
						record.PERSONA_GARANTE_2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_2_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_3_idColumnIndex))
						record.PERSONA_GARANTE_3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_3_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_montoColumnIndex))
						record.ARTICULO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRESUPUESTOSRow[])(recordList.ToArray(typeof(PRESUPUESTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRESUPUESTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRESUPUESTOSRow"/> object.</returns>
		protected virtual PRESUPUESTOSRow MapRow(DataRow row)
		{
			PRESUPUESTOSRow mappedObject = new PRESUPUESTOSRow();
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
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VALIDEZ"
			dataColumn = dataTable.Columns["FECHA_VALIDEZ"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VALIDEZ = (System.DateTime)row[dataColumn];
			// Column "FECHA_ENTREGA"
			dataColumn = dataTable.Columns["FECHA_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTREGA = (System.DateTime)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "OBJETO"
			dataColumn = dataTable.Columns["OBJETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBJETO = (string)row[dataColumn];
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_TIPO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_TIPO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_FUERO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_FUERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_FUERO_ID = (decimal)row[dataColumn];
			// Column "TRAMITES_TIPOS_ID"
			dataColumn = dataTable.Columns["TRAMITES_TIPOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITES_TIPOS_ID = (decimal)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_1_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_1_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_2_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_2_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_3_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_3_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_MONTO"
			dataColumn = dataTable.Columns["ARTICULO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MONTO = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRESUPUESTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRESUPUESTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VALIDEZ", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ENTREGA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBJETO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_TIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_FUERO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRAMITES_TIPOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_3_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
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

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VALIDEZ":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBJETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_FUERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITES_TIPOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRESUPUESTOSCollection_Base class
}  // End of namespace
