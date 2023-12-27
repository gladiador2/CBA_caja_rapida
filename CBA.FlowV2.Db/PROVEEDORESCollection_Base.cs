// <fileinfo name="PROVEEDORESCollection_Base.cs">
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
	/// The base class for <see cref="PROVEEDORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PROVEEDORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROVEEDORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string NOMBRE_FANTASIAColumnName = "NOMBRE_FANTASIA";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUCColumnName = "RUC";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string OPERA_CREDITOColumnName = "OPERA_CREDITO";
		public const string CONDICION_HABITUAL_PAGO_IDColumnName = "CONDICION_HABITUAL_PAGO_ID";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string DEPARTAMENTO1_IDColumnName = "DEPARTAMENTO1_ID";
		public const string CIUDAD1_IDColumnName = "CIUDAD1_ID";
		public const string BARRIO1_IDColumnName = "BARRIO1_ID";
		public const string CALLE1ColumnName = "CALLE1";
		public const string CODIGO_POSTAL1ColumnName = "CODIGO_POSTAL1";
		public const string LATITUD1ColumnName = "LATITUD1";
		public const string LONGITUD1ColumnName = "LONGITUD1";
		public const string DEPARTAMENTO2_IDColumnName = "DEPARTAMENTO2_ID";
		public const string CIUDAD2_IDColumnName = "CIUDAD2_ID";
		public const string BARRIO2_IDColumnName = "BARRIO2_ID";
		public const string CALLE2ColumnName = "CALLE2";
		public const string CODIGO_POSTAL2ColumnName = "CODIGO_POSTAL2";
		public const string LATITUD2ColumnName = "LATITUD2";
		public const string LONGITUD2ColumnName = "LONGITUD2";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string TELEFONO4ColumnName = "TELEFONO4";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string EMAIL3ColumnName = "EMAIL3";
		public const string PASIBLE_RETENCIONColumnName = "PASIBLE_RETENCION";
		public const string BANDERA_RETENCIONColumnName = "BANDERA_RETENCION";
		public const string FECHA_FUNDACIONColumnName = "FECHA_FUNDACION";
		public const string CONTACTO_PERSONAColumnName = "CONTACTO_PERSONA";
		public const string CONTACTO_TELEFONOColumnName = "CONTACTO_TELEFONO";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string SOLICITA_REFERENCIAColumnName = "SOLICITA_REFERENCIA";
		public const string ES_NACIONALColumnName = "ES_NACIONAL";
		public const string FC_OBSERVACION_DETALLEColumnName = "FC_OBSERVACION_DETALLE";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string CONTACTO_EMAILColumnName = "CONTACTO_EMAIL";
		public const string ES_CONTRIBUYENTEColumnName = "ES_CONTRIBUYENTE";
		public const string FECHA_DESDE_NO_RETENERColumnName = "FECHA_DESDE_NO_RETENER";
		public const string FECHA_HASTA_NO_RETENERColumnName = "FECHA_HASTA_NO_RETENER";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROVEEDORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PROVEEDORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PROVEEDORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PROVEEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PROVEEDORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PROVEEDORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects that 
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
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PROVEEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PROVEEDORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PROVEEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PROVEEDORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PROVEEDORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByBARRIO1_ID(decimal barrio1_id)
		{
			return GetByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecords(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id)
		{
			return GetByBARRIO1_IDAsDataTable(barrio1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByBARRIO2_ID(decimal barrio2_id)
		{
			return GetByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecords(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id)
		{
			return GetByBARRIO2_IDAsDataTable(barrio2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
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
		/// return records by the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
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
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByCIUDAD1_ID(decimal ciudad1_id)
		{
			return GetByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecords(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id)
		{
			return GetByCIUDAD1_IDAsDataTable(ciudad1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByCIUDAD2_ID(decimal ciudad2_id)
		{
			return GetByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecords(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id)
		{
			return GetByCIUDAD2_IDAsDataTable(ciudad2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id)
		{
			return GetByCONDICION_HABITUAL_PAGO_ID(condicion_habitual_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <param name="condicion_habitual_pago_idNull">true if the method ignores the condicion_habitual_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id, bool condicion_habitual_pago_idNull)
		{
			return MapRecords(CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id, condicion_habitual_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_HABITUAL_PAGO_IDAsDataTable(decimal condicion_habitual_pago_id)
		{
			return GetByCONDICION_HABITUAL_PAGO_IDAsDataTable(condicion_habitual_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <param name="condicion_habitual_pago_idNull">true if the method ignores the condicion_habitual_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_HABITUAL_PAGO_IDAsDataTable(decimal condicion_habitual_pago_id, bool condicion_habitual_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id, condicion_habitual_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <param name="condicion_habitual_pago_idNull">true if the method ignores the condicion_habitual_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(decimal condicion_habitual_pago_id, bool condicion_habitual_pago_idNull)
		{
			string whereSql = "";
			if(condicion_habitual_pago_idNull)
				whereSql += "CONDICION_HABITUAL_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_habitual_pago_idNull)
				AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", condicion_habitual_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_IDAsDataTable(departamento1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_IDAsDataTable(departamento2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByPAIS_ID(decimal pais_id)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByRUBRO_ID(decimal rubro_id)
		{
			return GetByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id)
		{
			return GetByRUBRO_IDAsDataTable(rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public PROVEEDORESRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORESRow"/> objects 
		/// by the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		public virtual PROVEEDORESRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PROVEEDORESRow"/> object to be inserted.</param>
		public virtual void Insert(PROVEEDORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PROVEEDORES (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"CODIGO, " +
				"RAZON_SOCIAL, " +
				"NOMBRE_FANTASIA, " +
				"RUBRO_ID, " +
				"RUC, " +
				"MONEDA_ID, " +
				"OPERA_CREDITO, " +
				"CONDICION_HABITUAL_PAGO_ID, " +
				"PAIS_ID, " +
				"DEPARTAMENTO1_ID, " +
				"CIUDAD1_ID, " +
				"BARRIO1_ID, " +
				"CALLE1, " +
				"CODIGO_POSTAL1, " +
				"LATITUD1, " +
				"LONGITUD1, " +
				"DEPARTAMENTO2_ID, " +
				"CIUDAD2_ID, " +
				"BARRIO2_ID, " +
				"CALLE2, " +
				"CODIGO_POSTAL2, " +
				"LATITUD2, " +
				"LONGITUD2, " +
				"TELEFONO1, " +
				"TELEFONO2, " +
				"TELEFONO3, " +
				"TELEFONO4, " +
				"EMAIL1, " +
				"EMAIL2, " +
				"EMAIL3, " +
				"PASIBLE_RETENCION, " +
				"BANDERA_RETENCION, " +
				"FECHA_FUNDACION, " +
				"CONTACTO_PERSONA, " +
				"CONTACTO_TELEFONO, " +
				"ESTADO, " +
				"INGRESO_APROBADO, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"SOLICITA_REFERENCIA, " +
				"ES_NACIONAL, " +
				"FC_OBSERVACION_DETALLE, " +
				"PERSONA_ID, " +
				"CENTRO_COSTO_ID, " +
				"CONTACTO_EMAIL, " +
				"ES_CONTRIBUYENTE, " +
				"FECHA_DESDE_NO_RETENER, " +
				"FECHA_HASTA_NO_RETENER" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("RAZON_SOCIAL") + ", " +
				_db.CreateSqlParameterName("NOMBRE_FANTASIA") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("OPERA_CREDITO") + ", " +
				_db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				_db.CreateSqlParameterName("CALLE1") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				_db.CreateSqlParameterName("LATITUD1") + ", " +
				_db.CreateSqlParameterName("LONGITUD1") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				_db.CreateSqlParameterName("CALLE2") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				_db.CreateSqlParameterName("LATITUD2") + ", " +
				_db.CreateSqlParameterName("LONGITUD2") + ", " +
				_db.CreateSqlParameterName("TELEFONO1") + ", " +
				_db.CreateSqlParameterName("TELEFONO2") + ", " +
				_db.CreateSqlParameterName("TELEFONO3") + ", " +
				_db.CreateSqlParameterName("TELEFONO4") + ", " +
				_db.CreateSqlParameterName("EMAIL1") + ", " +
				_db.CreateSqlParameterName("EMAIL2") + ", " +
				_db.CreateSqlParameterName("EMAIL3") + ", " +
				_db.CreateSqlParameterName("PASIBLE_RETENCION") + ", " +
				_db.CreateSqlParameterName("BANDERA_RETENCION") + ", " +
				_db.CreateSqlParameterName("FECHA_FUNDACION") + ", " +
				_db.CreateSqlParameterName("CONTACTO_PERSONA") + ", " +
				_db.CreateSqlParameterName("CONTACTO_TELEFONO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("SOLICITA_REFERENCIA") + ", " +
				_db.CreateSqlParameterName("ES_NACIONAL") + ", " +
				_db.CreateSqlParameterName("FC_OBSERVACION_DETALLE") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("CONTACTO_EMAIL") + ", " +
				_db.CreateSqlParameterName("ES_CONTRIBUYENTE") + ", " +
				_db.CreateSqlParameterName("FECHA_DESDE_NO_RETENER") + ", " +
				_db.CreateSqlParameterName("FECHA_HASTA_NO_RETENER") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "RAZON_SOCIAL", value.RAZON_SOCIAL);
			AddParameter(cmd, "NOMBRE_FANTASIA", value.NOMBRE_FANTASIA);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "OPERA_CREDITO", value.OPERA_CREDITO);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID",
				value.IsCONDICION_HABITUAL_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_HABITUAL_PAGO_ID);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "PASIBLE_RETENCION", value.PASIBLE_RETENCION);
			AddParameter(cmd, "BANDERA_RETENCION", value.BANDERA_RETENCION);
			AddParameter(cmd, "FECHA_FUNDACION",
				value.IsFECHA_FUNDACIONNull ? DBNull.Value : (object)value.FECHA_FUNDACION);
			AddParameter(cmd, "CONTACTO_PERSONA", value.CONTACTO_PERSONA);
			AddParameter(cmd, "CONTACTO_TELEFONO", value.CONTACTO_TELEFONO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "SOLICITA_REFERENCIA", value.SOLICITA_REFERENCIA);
			AddParameter(cmd, "ES_NACIONAL", value.ES_NACIONAL);
			AddParameter(cmd, "FC_OBSERVACION_DETALLE", value.FC_OBSERVACION_DETALLE);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "CONTACTO_EMAIL", value.CONTACTO_EMAIL);
			AddParameter(cmd, "ES_CONTRIBUYENTE", value.ES_CONTRIBUYENTE);
			AddParameter(cmd, "FECHA_DESDE_NO_RETENER",
				value.IsFECHA_DESDE_NO_RETENERNull ? DBNull.Value : (object)value.FECHA_DESDE_NO_RETENER);
			AddParameter(cmd, "FECHA_HASTA_NO_RETENER",
				value.IsFECHA_HASTA_NO_RETENERNull ? DBNull.Value : (object)value.FECHA_HASTA_NO_RETENER);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PROVEEDORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PROVEEDORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.PROVEEDORES SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"RAZON_SOCIAL=" + _db.CreateSqlParameterName("RAZON_SOCIAL") + ", " +
				"NOMBRE_FANTASIA=" + _db.CreateSqlParameterName("NOMBRE_FANTASIA") + ", " +
				"RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID") + ", " +
				"RUC=" + _db.CreateSqlParameterName("RUC") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"OPERA_CREDITO=" + _db.CreateSqlParameterName("OPERA_CREDITO") + ", " +
				"CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				"CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				"BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				"CALLE1=" + _db.CreateSqlParameterName("CALLE1") + ", " +
				"CODIGO_POSTAL1=" + _db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				"LATITUD1=" + _db.CreateSqlParameterName("LATITUD1") + ", " +
				"LONGITUD1=" + _db.CreateSqlParameterName("LONGITUD1") + ", " +
				"DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				"CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				"BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				"CALLE2=" + _db.CreateSqlParameterName("CALLE2") + ", " +
				"CODIGO_POSTAL2=" + _db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				"LATITUD2=" + _db.CreateSqlParameterName("LATITUD2") + ", " +
				"LONGITUD2=" + _db.CreateSqlParameterName("LONGITUD2") + ", " +
				"TELEFONO1=" + _db.CreateSqlParameterName("TELEFONO1") + ", " +
				"TELEFONO2=" + _db.CreateSqlParameterName("TELEFONO2") + ", " +
				"TELEFONO3=" + _db.CreateSqlParameterName("TELEFONO3") + ", " +
				"TELEFONO4=" + _db.CreateSqlParameterName("TELEFONO4") + ", " +
				"EMAIL1=" + _db.CreateSqlParameterName("EMAIL1") + ", " +
				"EMAIL2=" + _db.CreateSqlParameterName("EMAIL2") + ", " +
				"EMAIL3=" + _db.CreateSqlParameterName("EMAIL3") + ", " +
				"PASIBLE_RETENCION=" + _db.CreateSqlParameterName("PASIBLE_RETENCION") + ", " +
				"BANDERA_RETENCION=" + _db.CreateSqlParameterName("BANDERA_RETENCION") + ", " +
				"FECHA_FUNDACION=" + _db.CreateSqlParameterName("FECHA_FUNDACION") + ", " +
				"CONTACTO_PERSONA=" + _db.CreateSqlParameterName("CONTACTO_PERSONA") + ", " +
				"CONTACTO_TELEFONO=" + _db.CreateSqlParameterName("CONTACTO_TELEFONO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"INGRESO_APROBADO=" + _db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"SOLICITA_REFERENCIA=" + _db.CreateSqlParameterName("SOLICITA_REFERENCIA") + ", " +
				"ES_NACIONAL=" + _db.CreateSqlParameterName("ES_NACIONAL") + ", " +
				"FC_OBSERVACION_DETALLE=" + _db.CreateSqlParameterName("FC_OBSERVACION_DETALLE") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"CONTACTO_EMAIL=" + _db.CreateSqlParameterName("CONTACTO_EMAIL") + ", " +
				"ES_CONTRIBUYENTE=" + _db.CreateSqlParameterName("ES_CONTRIBUYENTE") + ", " +
				"FECHA_DESDE_NO_RETENER=" + _db.CreateSqlParameterName("FECHA_DESDE_NO_RETENER") + ", " +
				"FECHA_HASTA_NO_RETENER=" + _db.CreateSqlParameterName("FECHA_HASTA_NO_RETENER") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "RAZON_SOCIAL", value.RAZON_SOCIAL);
			AddParameter(cmd, "NOMBRE_FANTASIA", value.NOMBRE_FANTASIA);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "OPERA_CREDITO", value.OPERA_CREDITO);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID",
				value.IsCONDICION_HABITUAL_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_HABITUAL_PAGO_ID);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "PASIBLE_RETENCION", value.PASIBLE_RETENCION);
			AddParameter(cmd, "BANDERA_RETENCION", value.BANDERA_RETENCION);
			AddParameter(cmd, "FECHA_FUNDACION",
				value.IsFECHA_FUNDACIONNull ? DBNull.Value : (object)value.FECHA_FUNDACION);
			AddParameter(cmd, "CONTACTO_PERSONA", value.CONTACTO_PERSONA);
			AddParameter(cmd, "CONTACTO_TELEFONO", value.CONTACTO_TELEFONO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "SOLICITA_REFERENCIA", value.SOLICITA_REFERENCIA);
			AddParameter(cmd, "ES_NACIONAL", value.ES_NACIONAL);
			AddParameter(cmd, "FC_OBSERVACION_DETALLE", value.FC_OBSERVACION_DETALLE);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "CONTACTO_EMAIL", value.CONTACTO_EMAIL);
			AddParameter(cmd, "ES_CONTRIBUYENTE", value.ES_CONTRIBUYENTE);
			AddParameter(cmd, "FECHA_DESDE_NO_RETENER",
				value.IsFECHA_DESDE_NO_RETENERNull ? DBNull.Value : (object)value.FECHA_DESDE_NO_RETENER);
			AddParameter(cmd, "FECHA_HASTA_NO_RETENER",
				value.IsFECHA_HASTA_NO_RETENERNull ? DBNull.Value : (object)value.FECHA_HASTA_NO_RETENER);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PROVEEDORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PROVEEDORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PROVEEDORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PROVEEDORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PROVEEDORES</c> table using
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
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id)
		{
			return DeleteByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return CreateDeleteByBARRIO1_IDCommand(barrio1_id, barrio1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id)
		{
			return DeleteByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return CreateDeleteByBARRIO2_IDCommand(barrio2_id, barrio2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
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
		/// delete records using the <c>FK_PROVEEDORES_CENTRO_COSTO</c> foreign key.
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
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id)
		{
			return DeleteByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return CreateDeleteByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id)
		{
			return DeleteByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return CreateDeleteByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id)
		{
			return DeleteByCONDICION_HABITUAL_PAGO_ID(condicion_habitual_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <param name="condicion_habitual_pago_idNull">true if the method ignores the condicion_habitual_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id, bool condicion_habitual_pago_idNull)
		{
			return CreateDeleteByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id, condicion_habitual_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_CTACTE_CON_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <param name="condicion_habitual_pago_idNull">true if the method ignores the condicion_habitual_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_HABITUAL_PAGO_IDCommand(decimal condicion_habitual_pago_id, bool condicion_habitual_pago_idNull)
		{
			string whereSql = "";
			if(condicion_habitual_pago_idNull)
				whereSql += "CONDICION_HABITUAL_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_habitual_pago_idNull)
				AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", condicion_habitual_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return DeleteByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return CreateDeleteByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return DeleteByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return CreateDeleteByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_PROVEEDORES_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_PROVEEDORES_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id)
		{
			return DeleteByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return CreateDeleteByRUBRO_IDCommand(rubro_id, rubro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PROVEEDORES</c> table using the 
		/// <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PROVEEDORES_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PROVEEDORES</c> records that match the specified criteria.
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
		/// to delete <c>PROVEEDORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PROVEEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PROVEEDORES</c> table.
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
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		protected PROVEEDORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		protected PROVEEDORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PROVEEDORESRow"/> objects.</returns>
		protected virtual PROVEEDORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int nombre_fantasiaColumnIndex = reader.GetOrdinal("NOMBRE_FANTASIA");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int opera_creditoColumnIndex = reader.GetOrdinal("OPERA_CREDITO");
			int condicion_habitual_pago_idColumnIndex = reader.GetOrdinal("CONDICION_HABITUAL_PAGO_ID");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int departamento1_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ID");
			int ciudad1_idColumnIndex = reader.GetOrdinal("CIUDAD1_ID");
			int barrio1_idColumnIndex = reader.GetOrdinal("BARRIO1_ID");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");
			int codigo_postal1ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL1");
			int latitud1ColumnIndex = reader.GetOrdinal("LATITUD1");
			int longitud1ColumnIndex = reader.GetOrdinal("LONGITUD1");
			int departamento2_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ID");
			int ciudad2_idColumnIndex = reader.GetOrdinal("CIUDAD2_ID");
			int barrio2_idColumnIndex = reader.GetOrdinal("BARRIO2_ID");
			int calle2ColumnIndex = reader.GetOrdinal("CALLE2");
			int codigo_postal2ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL2");
			int latitud2ColumnIndex = reader.GetOrdinal("LATITUD2");
			int longitud2ColumnIndex = reader.GetOrdinal("LONGITUD2");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int telefono4ColumnIndex = reader.GetOrdinal("TELEFONO4");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int email3ColumnIndex = reader.GetOrdinal("EMAIL3");
			int pasible_retencionColumnIndex = reader.GetOrdinal("PASIBLE_RETENCION");
			int bandera_retencionColumnIndex = reader.GetOrdinal("BANDERA_RETENCION");
			int fecha_fundacionColumnIndex = reader.GetOrdinal("FECHA_FUNDACION");
			int contacto_personaColumnIndex = reader.GetOrdinal("CONTACTO_PERSONA");
			int contacto_telefonoColumnIndex = reader.GetOrdinal("CONTACTO_TELEFONO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int solicita_referenciaColumnIndex = reader.GetOrdinal("SOLICITA_REFERENCIA");
			int es_nacionalColumnIndex = reader.GetOrdinal("ES_NACIONAL");
			int fc_observacion_detalleColumnIndex = reader.GetOrdinal("FC_OBSERVACION_DETALLE");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int contacto_emailColumnIndex = reader.GetOrdinal("CONTACTO_EMAIL");
			int es_contribuyenteColumnIndex = reader.GetOrdinal("ES_CONTRIBUYENTE");
			int fecha_desde_no_retenerColumnIndex = reader.GetOrdinal("FECHA_DESDE_NO_RETENER");
			int fecha_hasta_no_retenerColumnIndex = reader.GetOrdinal("FECHA_HASTA_NO_RETENER");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PROVEEDORESRow record = new PROVEEDORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					if(!reader.IsDBNull(nombre_fantasiaColumnIndex))
						record.NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(opera_creditoColumnIndex))
						record.OPERA_CREDITO = Convert.ToString(reader.GetValue(opera_creditoColumnIndex));
					if(!reader.IsDBNull(condicion_habitual_pago_idColumnIndex))
						record.CONDICION_HABITUAL_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_habitual_pago_idColumnIndex)), 9);
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento1_idColumnIndex))
						record.DEPARTAMENTO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento1_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad1_idColumnIndex))
						record.CIUDAD1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad1_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio1_idColumnIndex))
						record.BARRIO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio1_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle1ColumnIndex))
						record.CALLE1 = Convert.ToString(reader.GetValue(calle1ColumnIndex));
					if(!reader.IsDBNull(codigo_postal1ColumnIndex))
						record.CODIGO_POSTAL1 = Convert.ToString(reader.GetValue(codigo_postal1ColumnIndex));
					if(!reader.IsDBNull(latitud1ColumnIndex))
						record.LATITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud1ColumnIndex))
						record.LONGITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(departamento2_idColumnIndex))
						record.DEPARTAMENTO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento2_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad2_idColumnIndex))
						record.CIUDAD2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad2_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio2_idColumnIndex))
						record.BARRIO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio2_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle2ColumnIndex))
						record.CALLE2 = Convert.ToString(reader.GetValue(calle2ColumnIndex));
					if(!reader.IsDBNull(codigo_postal2ColumnIndex))
						record.CODIGO_POSTAL2 = Convert.ToString(reader.GetValue(codigo_postal2ColumnIndex));
					if(!reader.IsDBNull(latitud2ColumnIndex))
						record.LATITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud2ColumnIndex))
						record.LONGITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(telefono1ColumnIndex))
						record.TELEFONO1 = Convert.ToString(reader.GetValue(telefono1ColumnIndex));
					if(!reader.IsDBNull(telefono2ColumnIndex))
						record.TELEFONO2 = Convert.ToString(reader.GetValue(telefono2ColumnIndex));
					if(!reader.IsDBNull(telefono3ColumnIndex))
						record.TELEFONO3 = Convert.ToString(reader.GetValue(telefono3ColumnIndex));
					if(!reader.IsDBNull(telefono4ColumnIndex))
						record.TELEFONO4 = Convert.ToString(reader.GetValue(telefono4ColumnIndex));
					if(!reader.IsDBNull(email1ColumnIndex))
						record.EMAIL1 = Convert.ToString(reader.GetValue(email1ColumnIndex));
					if(!reader.IsDBNull(email2ColumnIndex))
						record.EMAIL2 = Convert.ToString(reader.GetValue(email2ColumnIndex));
					if(!reader.IsDBNull(email3ColumnIndex))
						record.EMAIL3 = Convert.ToString(reader.GetValue(email3ColumnIndex));
					record.PASIBLE_RETENCION = Convert.ToString(reader.GetValue(pasible_retencionColumnIndex));
					record.BANDERA_RETENCION = Convert.ToString(reader.GetValue(bandera_retencionColumnIndex));
					if(!reader.IsDBNull(fecha_fundacionColumnIndex))
						record.FECHA_FUNDACION = Convert.ToDateTime(reader.GetValue(fecha_fundacionColumnIndex));
					if(!reader.IsDBNull(contacto_personaColumnIndex))
						record.CONTACTO_PERSONA = Convert.ToString(reader.GetValue(contacto_personaColumnIndex));
					if(!reader.IsDBNull(contacto_telefonoColumnIndex))
						record.CONTACTO_TELEFONO = Convert.ToString(reader.GetValue(contacto_telefonoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					record.SOLICITA_REFERENCIA = Convert.ToString(reader.GetValue(solicita_referenciaColumnIndex));
					record.ES_NACIONAL = Convert.ToString(reader.GetValue(es_nacionalColumnIndex));
					if(!reader.IsDBNull(fc_observacion_detalleColumnIndex))
						record.FC_OBSERVACION_DETALLE = Convert.ToString(reader.GetValue(fc_observacion_detalleColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(contacto_emailColumnIndex))
						record.CONTACTO_EMAIL = Convert.ToString(reader.GetValue(contacto_emailColumnIndex));
					record.ES_CONTRIBUYENTE = Convert.ToString(reader.GetValue(es_contribuyenteColumnIndex));
					if(!reader.IsDBNull(fecha_desde_no_retenerColumnIndex))
						record.FECHA_DESDE_NO_RETENER = Convert.ToDateTime(reader.GetValue(fecha_desde_no_retenerColumnIndex));
					if(!reader.IsDBNull(fecha_hasta_no_retenerColumnIndex))
						record.FECHA_HASTA_NO_RETENER = Convert.ToDateTime(reader.GetValue(fecha_hasta_no_retenerColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PROVEEDORESRow[])(recordList.ToArray(typeof(PROVEEDORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PROVEEDORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PROVEEDORESRow"/> object.</returns>
		protected virtual PROVEEDORESRow MapRow(DataRow row)
		{
			PROVEEDORESRow mappedObject = new PROVEEDORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "OPERA_CREDITO"
			dataColumn = dataTable.Columns["OPERA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERA_CREDITO = (string)row[dataColumn];
			// Column "CONDICION_HABITUAL_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_HABITUAL_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_HABITUAL_PAGO_ID = (decimal)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO1_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ID = (decimal)row[dataColumn];
			// Column "CIUDAD1_ID"
			dataColumn = dataTable.Columns["CIUDAD1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ID = (decimal)row[dataColumn];
			// Column "BARRIO1_ID"
			dataColumn = dataTable.Columns["BARRIO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ID = (decimal)row[dataColumn];
			// Column "CALLE1"
			dataColumn = dataTable.Columns["CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE1 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL1"
			dataColumn = dataTable.Columns["CODIGO_POSTAL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL1 = (string)row[dataColumn];
			// Column "LATITUD1"
			dataColumn = dataTable.Columns["LATITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD1 = (decimal)row[dataColumn];
			// Column "LONGITUD1"
			dataColumn = dataTable.Columns["LONGITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD1 = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO2_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_ID = (decimal)row[dataColumn];
			// Column "CIUDAD2_ID"
			dataColumn = dataTable.Columns["CIUDAD2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ID = (decimal)row[dataColumn];
			// Column "BARRIO2_ID"
			dataColumn = dataTable.Columns["BARRIO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ID = (decimal)row[dataColumn];
			// Column "CALLE2"
			dataColumn = dataTable.Columns["CALLE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE2 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL2"
			dataColumn = dataTable.Columns["CODIGO_POSTAL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL2 = (string)row[dataColumn];
			// Column "LATITUD2"
			dataColumn = dataTable.Columns["LATITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD2 = (decimal)row[dataColumn];
			// Column "LONGITUD2"
			dataColumn = dataTable.Columns["LONGITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD2 = (decimal)row[dataColumn];
			// Column "TELEFONO1"
			dataColumn = dataTable.Columns["TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO1 = (string)row[dataColumn];
			// Column "TELEFONO2"
			dataColumn = dataTable.Columns["TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO2 = (string)row[dataColumn];
			// Column "TELEFONO3"
			dataColumn = dataTable.Columns["TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO3 = (string)row[dataColumn];
			// Column "TELEFONO4"
			dataColumn = dataTable.Columns["TELEFONO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO4 = (string)row[dataColumn];
			// Column "EMAIL1"
			dataColumn = dataTable.Columns["EMAIL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL1 = (string)row[dataColumn];
			// Column "EMAIL2"
			dataColumn = dataTable.Columns["EMAIL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL2 = (string)row[dataColumn];
			// Column "EMAIL3"
			dataColumn = dataTable.Columns["EMAIL3"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL3 = (string)row[dataColumn];
			// Column "PASIBLE_RETENCION"
			dataColumn = dataTable.Columns["PASIBLE_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASIBLE_RETENCION = (string)row[dataColumn];
			// Column "BANDERA_RETENCION"
			dataColumn = dataTable.Columns["BANDERA_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANDERA_RETENCION = (string)row[dataColumn];
			// Column "FECHA_FUNDACION"
			dataColumn = dataTable.Columns["FECHA_FUNDACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FUNDACION = (System.DateTime)row[dataColumn];
			// Column "CONTACTO_PERSONA"
			dataColumn = dataTable.Columns["CONTACTO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_PERSONA = (string)row[dataColumn];
			// Column "CONTACTO_TELEFONO"
			dataColumn = dataTable.Columns["CONTACTO_TELEFONO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_TELEFONO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "INGRESO_APROBADO"
			dataColumn = dataTable.Columns["INGRESO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "SOLICITA_REFERENCIA"
			dataColumn = dataTable.Columns["SOLICITA_REFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOLICITA_REFERENCIA = (string)row[dataColumn];
			// Column "ES_NACIONAL"
			dataColumn = dataTable.Columns["ES_NACIONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_NACIONAL = (string)row[dataColumn];
			// Column "FC_OBSERVACION_DETALLE"
			dataColumn = dataTable.Columns["FC_OBSERVACION_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_OBSERVACION_DETALLE = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "CONTACTO_EMAIL"
			dataColumn = dataTable.Columns["CONTACTO_EMAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_EMAIL = (string)row[dataColumn];
			// Column "ES_CONTRIBUYENTE"
			dataColumn = dataTable.Columns["ES_CONTRIBUYENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CONTRIBUYENTE = (string)row[dataColumn];
			// Column "FECHA_DESDE_NO_RETENER"
			dataColumn = dataTable.Columns["FECHA_DESDE_NO_RETENER"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE_NO_RETENER = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA_NO_RETENER"
			dataColumn = dataTable.Columns["FECHA_HASTA_NO_RETENER"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA_NO_RETENER = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PROVEEDORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OPERA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CONDICION_HABITUAL_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL1", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PASIBLE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BANDERA_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FUNDACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CONTACTO_PERSONA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CONTACTO_TELEFONO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("SOLICITA_REFERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_NACIONAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FC_OBSERVACION_DETALLE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTACTO_EMAIL", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ES_CONTRIBUYENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_DESDE_NO_RETENER", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_HASTA_NO_RETENER", typeof(System.DateTime));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OPERA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONDICION_HABITUAL_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASIBLE_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BANDERA_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_FUNDACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONTACTO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTACTO_TELEFONO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SOLICITA_REFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_NACIONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FC_OBSERVACION_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTACTO_EMAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_CONTRIBUYENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_DESDE_NO_RETENER":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA_NO_RETENER":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PROVEEDORESCollection_Base class
}  // End of namespace
