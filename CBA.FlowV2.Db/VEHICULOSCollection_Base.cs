// <fileinfo name="VEHICULOSCollection_Base.cs">
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
	/// The base class for <see cref="VEHICULOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="VEHICULOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VEHICULOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_VEHICULO_IDColumnName = "TIPO_VEHICULO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string MATRICULAColumnName = "MATRICULA";
		public const string MARCAColumnName = "MARCA";
		public const string MODELOColumnName = "MODELO";
		public const string ANHOColumnName = "ANHO";
		public const string COLORColumnName = "COLOR";
		public const string CONSUMO_ESTIMADOColumnName = "CONSUMO_ESTIMADO";
		public const string KILOMETRAJE_INICIALColumnName = "KILOMETRAJE_INICIAL";
		public const string KILOMETRAJE_ACTUALColumnName = "KILOMETRAJE_ACTUAL";
		public const string TIPO_COMBUSTIBLEColumnName = "TIPO_COMBUSTIBLE";
		public const string CANTIDAD_KM_ENTRE_MANTENIMColumnName = "CANTIDAD_KM_ENTRE_MANTENIM";
		public const string CANTIDAD_DIAS_ENTRE_MANTENIMColumnName = "CANTIDAD_DIAS_ENTRE_MANTENIM";
		public const string KILOMETRAJE_ULTIMO_MANTENIMIENColumnName = "KILOMETRAJE_ULTIMO_MANTENIMIEN";
		public const string FECHA_ULTIMO_MANTENIMIENTOColumnName = "FECHA_ULTIMO_MANTENIMIENTO";
		public const string FECHA_VENCIMIENTO_POLIZAColumnName = "FECHA_VENCIMIENTO_POLIZA";
		public const string FECHA_VENCIMIENTO_PATENTEColumnName = "FECHA_VENCIMIENTO_PATENTE";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_INACTIVADOColumnName = "FECHA_INACTIVADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string CHOFER_HABITUAL_IDColumnName = "CHOFER_HABITUAL_ID";
		public const string CHASIS_NROColumnName = "CHASIS_NRO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string NRO_CELDASColumnName = "NRO_CELDAS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="VEHICULOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public VEHICULOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>VEHICULOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>VEHICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>VEHICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="VEHICULOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="VEHICULOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public VEHICULOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			VEHICULOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public VEHICULOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects that 
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
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.VEHICULOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="VEHICULOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="VEHICULOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual VEHICULOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			VEHICULOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public VEHICULOSRow[] GetByCHOFER_HABITUAL_ID(decimal chofer_habitual_id)
		{
			return GetByCHOFER_HABITUAL_ID(chofer_habitual_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <param name="chofer_habitual_idNull">true if the method ignores the chofer_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetByCHOFER_HABITUAL_ID(decimal chofer_habitual_id, bool chofer_habitual_idNull)
		{
			return MapRecords(CreateGetByCHOFER_HABITUAL_IDCommand(chofer_habitual_id, chofer_habitual_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHOFER_HABITUAL_IDAsDataTable(decimal chofer_habitual_id)
		{
			return GetByCHOFER_HABITUAL_IDAsDataTable(chofer_habitual_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <param name="chofer_habitual_idNull">true if the method ignores the chofer_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCHOFER_HABITUAL_IDAsDataTable(decimal chofer_habitual_id, bool chofer_habitual_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCHOFER_HABITUAL_IDCommand(chofer_habitual_id, chofer_habitual_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <param name="chofer_habitual_idNull">true if the method ignores the chofer_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCHOFER_HABITUAL_IDCommand(decimal chofer_habitual_id, bool chofer_habitual_idNull)
		{
			string whereSql = "";
			if(chofer_habitual_idNull)
				whereSql += "CHOFER_HABITUAL_ID IS NULL";
			else
				whereSql += "CHOFER_HABITUAL_ID=" + _db.CreateSqlParameterName("CHOFER_HABITUAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!chofer_habitual_idNull)
				AddParameter(cmd, "CHOFER_HABITUAL_ID", chofer_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public VEHICULOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_VEHICULO_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public VEHICULOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
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
		/// return records by the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
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
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public VEHICULOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOSRow"/> objects 
		/// by the <c>FK_VEHICULOS_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		public virtual VEHICULOSRow[] GetByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id)
		{
			return MapRecords(CreateGetByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEHICULOS_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_VEHICULO_IDAsDataTable(decimal tipo_vehiculo_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEHICULOS_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_VEHICULO_IDCommand(decimal tipo_vehiculo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_VEHICULO_ID", tipo_vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>VEHICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="VEHICULOSRow"/> object to be inserted.</param>
		public virtual void Insert(VEHICULOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.VEHICULOS (" +
				"ID, " +
				"TIPO_VEHICULO_ID, " +
				"SUCURSAL_ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"MATRICULA, " +
				"MARCA, " +
				"MODELO, " +
				"ANHO, " +
				"COLOR, " +
				"CONSUMO_ESTIMADO, " +
				"KILOMETRAJE_INICIAL, " +
				"KILOMETRAJE_ACTUAL, " +
				"TIPO_COMBUSTIBLE, " +
				"CANTIDAD_KM_ENTRE_MANTENIM, " +
				"CANTIDAD_DIAS_ENTRE_MANTENIM, " +
				"KILOMETRAJE_ULTIMO_MANTENIMIEN, " +
				"FECHA_ULTIMO_MANTENIMIENTO, " +
				"FECHA_VENCIMIENTO_POLIZA, " +
				"FECHA_VENCIMIENTO_PATENTE, " +
				"FECHA_INGRESO, " +
				"FECHA_INACTIVADO, " +
				"ESTADO, " +
				"CHOFER_HABITUAL_ID, " +
				"CHASIS_NRO, " +
				"PROVEEDOR_ID, " +
				"PERSONA_ID, " +
				"NRO_CELDAS" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("MATRICULA") + ", " +
				_db.CreateSqlParameterName("MARCA") + ", " +
				_db.CreateSqlParameterName("MODELO") + ", " +
				_db.CreateSqlParameterName("ANHO") + ", " +
				_db.CreateSqlParameterName("COLOR") + ", " +
				_db.CreateSqlParameterName("CONSUMO_ESTIMADO") + ", " +
				_db.CreateSqlParameterName("KILOMETRAJE_INICIAL") + ", " +
				_db.CreateSqlParameterName("KILOMETRAJE_ACTUAL") + ", " +
				_db.CreateSqlParameterName("TIPO_COMBUSTIBLE") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_KM_ENTRE_MANTENIM") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DIAS_ENTRE_MANTENIM") + ", " +
				_db.CreateSqlParameterName("KILOMETRAJE_ULTIMO_MANTENIMIEN") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMO_MANTENIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO_POLIZA") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO_PATENTE") + ", " +
				_db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				_db.CreateSqlParameterName("FECHA_INACTIVADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CHOFER_HABITUAL_ID") + ", " +
				_db.CreateSqlParameterName("CHASIS_NRO") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("NRO_CELDAS") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_VEHICULO_ID", value.TIPO_VEHICULO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "MATRICULA", value.MATRICULA);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "MODELO", value.MODELO);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "COLOR", value.COLOR);
			AddParameter(cmd, "CONSUMO_ESTIMADO",
				value.IsCONSUMO_ESTIMADONull ? DBNull.Value : (object)value.CONSUMO_ESTIMADO);
			AddParameter(cmd, "KILOMETRAJE_INICIAL", value.KILOMETRAJE_INICIAL);
			AddParameter(cmd, "KILOMETRAJE_ACTUAL", value.KILOMETRAJE_ACTUAL);
			AddParameter(cmd, "TIPO_COMBUSTIBLE", value.TIPO_COMBUSTIBLE);
			AddParameter(cmd, "CANTIDAD_KM_ENTRE_MANTENIM",
				value.IsCANTIDAD_KM_ENTRE_MANTENIMNull ? DBNull.Value : (object)value.CANTIDAD_KM_ENTRE_MANTENIM);
			AddParameter(cmd, "CANTIDAD_DIAS_ENTRE_MANTENIM",
				value.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull ? DBNull.Value : (object)value.CANTIDAD_DIAS_ENTRE_MANTENIM);
			AddParameter(cmd, "KILOMETRAJE_ULTIMO_MANTENIMIEN",
				value.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull ? DBNull.Value : (object)value.KILOMETRAJE_ULTIMO_MANTENIMIEN);
			AddParameter(cmd, "FECHA_ULTIMO_MANTENIMIENTO",
				value.IsFECHA_ULTIMO_MANTENIMIENTONull ? DBNull.Value : (object)value.FECHA_ULTIMO_MANTENIMIENTO);
			AddParameter(cmd, "FECHA_VENCIMIENTO_POLIZA",
				value.IsFECHA_VENCIMIENTO_POLIZANull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO_POLIZA);
			AddParameter(cmd, "FECHA_VENCIMIENTO_PATENTE",
				value.IsFECHA_VENCIMIENTO_PATENTENull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO_PATENTE);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_INACTIVADO",
				value.IsFECHA_INACTIVADONull ? DBNull.Value : (object)value.FECHA_INACTIVADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CHOFER_HABITUAL_ID",
				value.IsCHOFER_HABITUAL_IDNull ? DBNull.Value : (object)value.CHOFER_HABITUAL_ID);
			AddParameter(cmd, "CHASIS_NRO", value.CHASIS_NRO);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "NRO_CELDAS",
				value.IsNRO_CELDASNull ? DBNull.Value : (object)value.NRO_CELDAS);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>VEHICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="VEHICULOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(VEHICULOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.VEHICULOS SET " +
				"TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"MATRICULA=" + _db.CreateSqlParameterName("MATRICULA") + ", " +
				"MARCA=" + _db.CreateSqlParameterName("MARCA") + ", " +
				"MODELO=" + _db.CreateSqlParameterName("MODELO") + ", " +
				"ANHO=" + _db.CreateSqlParameterName("ANHO") + ", " +
				"COLOR=" + _db.CreateSqlParameterName("COLOR") + ", " +
				"CONSUMO_ESTIMADO=" + _db.CreateSqlParameterName("CONSUMO_ESTIMADO") + ", " +
				"KILOMETRAJE_INICIAL=" + _db.CreateSqlParameterName("KILOMETRAJE_INICIAL") + ", " +
				"KILOMETRAJE_ACTUAL=" + _db.CreateSqlParameterName("KILOMETRAJE_ACTUAL") + ", " +
				"TIPO_COMBUSTIBLE=" + _db.CreateSqlParameterName("TIPO_COMBUSTIBLE") + ", " +
				"CANTIDAD_KM_ENTRE_MANTENIM=" + _db.CreateSqlParameterName("CANTIDAD_KM_ENTRE_MANTENIM") + ", " +
				"CANTIDAD_DIAS_ENTRE_MANTENIM=" + _db.CreateSqlParameterName("CANTIDAD_DIAS_ENTRE_MANTENIM") + ", " +
				"KILOMETRAJE_ULTIMO_MANTENIMIEN=" + _db.CreateSqlParameterName("KILOMETRAJE_ULTIMO_MANTENIMIEN") + ", " +
				"FECHA_ULTIMO_MANTENIMIENTO=" + _db.CreateSqlParameterName("FECHA_ULTIMO_MANTENIMIENTO") + ", " +
				"FECHA_VENCIMIENTO_POLIZA=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO_POLIZA") + ", " +
				"FECHA_VENCIMIENTO_PATENTE=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO_PATENTE") + ", " +
				"FECHA_INGRESO=" + _db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				"FECHA_INACTIVADO=" + _db.CreateSqlParameterName("FECHA_INACTIVADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CHOFER_HABITUAL_ID=" + _db.CreateSqlParameterName("CHOFER_HABITUAL_ID") + ", " +
				"CHASIS_NRO=" + _db.CreateSqlParameterName("CHASIS_NRO") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"NRO_CELDAS=" + _db.CreateSqlParameterName("NRO_CELDAS") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_VEHICULO_ID", value.TIPO_VEHICULO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "MATRICULA", value.MATRICULA);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "MODELO", value.MODELO);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "COLOR", value.COLOR);
			AddParameter(cmd, "CONSUMO_ESTIMADO",
				value.IsCONSUMO_ESTIMADONull ? DBNull.Value : (object)value.CONSUMO_ESTIMADO);
			AddParameter(cmd, "KILOMETRAJE_INICIAL", value.KILOMETRAJE_INICIAL);
			AddParameter(cmd, "KILOMETRAJE_ACTUAL", value.KILOMETRAJE_ACTUAL);
			AddParameter(cmd, "TIPO_COMBUSTIBLE", value.TIPO_COMBUSTIBLE);
			AddParameter(cmd, "CANTIDAD_KM_ENTRE_MANTENIM",
				value.IsCANTIDAD_KM_ENTRE_MANTENIMNull ? DBNull.Value : (object)value.CANTIDAD_KM_ENTRE_MANTENIM);
			AddParameter(cmd, "CANTIDAD_DIAS_ENTRE_MANTENIM",
				value.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull ? DBNull.Value : (object)value.CANTIDAD_DIAS_ENTRE_MANTENIM);
			AddParameter(cmd, "KILOMETRAJE_ULTIMO_MANTENIMIEN",
				value.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull ? DBNull.Value : (object)value.KILOMETRAJE_ULTIMO_MANTENIMIEN);
			AddParameter(cmd, "FECHA_ULTIMO_MANTENIMIENTO",
				value.IsFECHA_ULTIMO_MANTENIMIENTONull ? DBNull.Value : (object)value.FECHA_ULTIMO_MANTENIMIENTO);
			AddParameter(cmd, "FECHA_VENCIMIENTO_POLIZA",
				value.IsFECHA_VENCIMIENTO_POLIZANull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO_POLIZA);
			AddParameter(cmd, "FECHA_VENCIMIENTO_PATENTE",
				value.IsFECHA_VENCIMIENTO_PATENTENull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO_PATENTE);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_INACTIVADO",
				value.IsFECHA_INACTIVADONull ? DBNull.Value : (object)value.FECHA_INACTIVADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CHOFER_HABITUAL_ID",
				value.IsCHOFER_HABITUAL_IDNull ? DBNull.Value : (object)value.CHOFER_HABITUAL_ID);
			AddParameter(cmd, "CHASIS_NRO", value.CHASIS_NRO);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "NRO_CELDAS",
				value.IsNRO_CELDASNull ? DBNull.Value : (object)value.NRO_CELDAS);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>VEHICULOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>VEHICULOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>VEHICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="VEHICULOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(VEHICULOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>VEHICULOS</c> table using
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
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHOFER_HABITUAL_ID(decimal chofer_habitual_id)
		{
			return DeleteByCHOFER_HABITUAL_ID(chofer_habitual_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <param name="chofer_habitual_idNull">true if the method ignores the chofer_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHOFER_HABITUAL_ID(decimal chofer_habitual_id, bool chofer_habitual_idNull)
		{
			return CreateDeleteByCHOFER_HABITUAL_IDCommand(chofer_habitual_id, chofer_habitual_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEHICULO_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="chofer_habitual_id">The <c>CHOFER_HABITUAL_ID</c> column value.</param>
		/// <param name="chofer_habitual_idNull">true if the method ignores the chofer_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCHOFER_HABITUAL_IDCommand(decimal chofer_habitual_id, bool chofer_habitual_idNull)
		{
			string whereSql = "";
			if(chofer_habitual_idNull)
				whereSql += "CHOFER_HABITUAL_ID IS NULL";
			else
				whereSql += "CHOFER_HABITUAL_ID=" + _db.CreateSqlParameterName("CHOFER_HABITUAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!chofer_habitual_idNull)
				AddParameter(cmd, "CHOFER_HABITUAL_ID", chofer_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_VEHICULO_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
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
		/// delete records using the <c>FK_VEHICULO_PROVEEDOR</c> foreign key.
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
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEHICULOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>VEHICULOS</c> table using the 
		/// <c>FK_VEHICULOS_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id)
		{
			return CreateDeleteByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEHICULOS_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_VEHICULO_IDCommand(decimal tipo_vehiculo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_VEHICULO_ID", tipo_vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>VEHICULOS</c> records that match the specified criteria.
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
		/// to delete <c>VEHICULOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.VEHICULOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>VEHICULOS</c> table.
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
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		protected VEHICULOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		protected VEHICULOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="VEHICULOSRow"/> objects.</returns>
		protected virtual VEHICULOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_vehiculo_idColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int matriculaColumnIndex = reader.GetOrdinal("MATRICULA");
			int marcaColumnIndex = reader.GetOrdinal("MARCA");
			int modeloColumnIndex = reader.GetOrdinal("MODELO");
			int anhoColumnIndex = reader.GetOrdinal("ANHO");
			int colorColumnIndex = reader.GetOrdinal("COLOR");
			int consumo_estimadoColumnIndex = reader.GetOrdinal("CONSUMO_ESTIMADO");
			int kilometraje_inicialColumnIndex = reader.GetOrdinal("KILOMETRAJE_INICIAL");
			int kilometraje_actualColumnIndex = reader.GetOrdinal("KILOMETRAJE_ACTUAL");
			int tipo_combustibleColumnIndex = reader.GetOrdinal("TIPO_COMBUSTIBLE");
			int cantidad_km_entre_mantenimColumnIndex = reader.GetOrdinal("CANTIDAD_KM_ENTRE_MANTENIM");
			int cantidad_dias_entre_mantenimColumnIndex = reader.GetOrdinal("CANTIDAD_DIAS_ENTRE_MANTENIM");
			int kilometraje_ultimo_mantenimienColumnIndex = reader.GetOrdinal("KILOMETRAJE_ULTIMO_MANTENIMIEN");
			int fecha_ultimo_mantenimientoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_MANTENIMIENTO");
			int fecha_vencimiento_polizaColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_POLIZA");
			int fecha_vencimiento_patenteColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_PATENTE");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_inactivadoColumnIndex = reader.GetOrdinal("FECHA_INACTIVADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int chofer_habitual_idColumnIndex = reader.GetOrdinal("CHOFER_HABITUAL_ID");
			int chasis_nroColumnIndex = reader.GetOrdinal("CHASIS_NRO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int nro_celdasColumnIndex = reader.GetOrdinal("NRO_CELDAS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					VEHICULOSRow record = new VEHICULOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					record.MATRICULA = Convert.ToString(reader.GetValue(matriculaColumnIndex));
					if(!reader.IsDBNull(marcaColumnIndex))
						record.MARCA = Convert.ToString(reader.GetValue(marcaColumnIndex));
					if(!reader.IsDBNull(modeloColumnIndex))
						record.MODELO = Convert.ToString(reader.GetValue(modeloColumnIndex));
					if(!reader.IsDBNull(anhoColumnIndex))
						record.ANHO = Math.Round(Convert.ToDecimal(reader.GetValue(anhoColumnIndex)), 9);
					if(!reader.IsDBNull(colorColumnIndex))
						record.COLOR = Convert.ToString(reader.GetValue(colorColumnIndex));
					if(!reader.IsDBNull(consumo_estimadoColumnIndex))
						record.CONSUMO_ESTIMADO = Math.Round(Convert.ToDecimal(reader.GetValue(consumo_estimadoColumnIndex)), 9);
					record.KILOMETRAJE_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_inicialColumnIndex)), 9);
					record.KILOMETRAJE_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_actualColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_combustibleColumnIndex))
						record.TIPO_COMBUSTIBLE = Convert.ToString(reader.GetValue(tipo_combustibleColumnIndex));
					if(!reader.IsDBNull(cantidad_km_entre_mantenimColumnIndex))
						record.CANTIDAD_KM_ENTRE_MANTENIM = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_km_entre_mantenimColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dias_entre_mantenimColumnIndex))
						record.CANTIDAD_DIAS_ENTRE_MANTENIM = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dias_entre_mantenimColumnIndex)), 9);
					if(!reader.IsDBNull(kilometraje_ultimo_mantenimienColumnIndex))
						record.KILOMETRAJE_ULTIMO_MANTENIMIEN = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_ultimo_mantenimienColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_mantenimientoColumnIndex))
						record.FECHA_ULTIMO_MANTENIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_mantenimientoColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_polizaColumnIndex))
						record.FECHA_VENCIMIENTO_POLIZA = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_polizaColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_patenteColumnIndex))
						record.FECHA_VENCIMIENTO_PATENTE = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_patenteColumnIndex));
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_inactivadoColumnIndex))
						record.FECHA_INACTIVADO = Convert.ToDateTime(reader.GetValue(fecha_inactivadoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(chofer_habitual_idColumnIndex))
						record.CHOFER_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(chofer_habitual_idColumnIndex)), 9);
					if(!reader.IsDBNull(chasis_nroColumnIndex))
						record.CHASIS_NRO = Convert.ToString(reader.GetValue(chasis_nroColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_celdasColumnIndex))
						record.NRO_CELDAS = Math.Round(Convert.ToDecimal(reader.GetValue(nro_celdasColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (VEHICULOSRow[])(recordList.ToArray(typeof(VEHICULOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="VEHICULOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="VEHICULOSRow"/> object.</returns>
		protected virtual VEHICULOSRow MapRow(DataRow row)
		{
			VEHICULOSRow mappedObject = new VEHICULOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_VEHICULO_ID"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "MATRICULA"
			dataColumn = dataTable.Columns["MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MATRICULA = (string)row[dataColumn];
			// Column "MARCA"
			dataColumn = dataTable.Columns["MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA = (string)row[dataColumn];
			// Column "MODELO"
			dataColumn = dataTable.Columns["MODELO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODELO = (string)row[dataColumn];
			// Column "ANHO"
			dataColumn = dataTable.Columns["ANHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO = (decimal)row[dataColumn];
			// Column "COLOR"
			dataColumn = dataTable.Columns["COLOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLOR = (string)row[dataColumn];
			// Column "CONSUMO_ESTIMADO"
			dataColumn = dataTable.Columns["CONSUMO_ESTIMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSUMO_ESTIMADO = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_INICIAL"
			dataColumn = dataTable.Columns["KILOMETRAJE_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_INICIAL = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_ACTUAL"
			dataColumn = dataTable.Columns["KILOMETRAJE_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_ACTUAL = (decimal)row[dataColumn];
			// Column "TIPO_COMBUSTIBLE"
			dataColumn = dataTable.Columns["TIPO_COMBUSTIBLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_COMBUSTIBLE = (string)row[dataColumn];
			// Column "CANTIDAD_KM_ENTRE_MANTENIM"
			dataColumn = dataTable.Columns["CANTIDAD_KM_ENTRE_MANTENIM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_KM_ENTRE_MANTENIM = (decimal)row[dataColumn];
			// Column "CANTIDAD_DIAS_ENTRE_MANTENIM"
			dataColumn = dataTable.Columns["CANTIDAD_DIAS_ENTRE_MANTENIM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DIAS_ENTRE_MANTENIM = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_ULTIMO_MANTENIMIEN"
			dataColumn = dataTable.Columns["KILOMETRAJE_ULTIMO_MANTENIMIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_ULTIMO_MANTENIMIEN = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_MANTENIMIENTO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_MANTENIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_MANTENIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_POLIZA"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_POLIZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_POLIZA = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_PATENTE"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_PATENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_PATENTE = (System.DateTime)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INACTIVADO"
			dataColumn = dataTable.Columns["FECHA_INACTIVADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVADO = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CHOFER_HABITUAL_ID"
			dataColumn = dataTable.Columns["CHOFER_HABITUAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_HABITUAL_ID = (decimal)row[dataColumn];
			// Column "CHASIS_NRO"
			dataColumn = dataTable.Columns["CHASIS_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHASIS_NRO = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "NRO_CELDAS"
			dataColumn = dataTable.Columns["NRO_CELDAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CELDAS = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>VEHICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "VEHICULOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MATRICULA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MODELO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ANHO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COLOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CONSUMO_ESTIMADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_COMBUSTIBLE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CANTIDAD_KM_ENTRE_MANTENIM", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DIAS_ENTRE_MANTENIM", typeof(decimal));
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_ULTIMO_MANTENIMIEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_MANTENIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_POLIZA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_PATENTE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CHOFER_HABITUAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHASIS_NRO", typeof(string));
			dataColumn.MaxLength = 17;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_CELDAS", typeof(decimal));
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

				case "TIPO_VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MODELO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COLOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSUMO_ESTIMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_COMBUSTIBLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_KM_ENTRE_MANTENIM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DIAS_ENTRE_MANTENIM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_ULTIMO_MANTENIMIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_MANTENIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_POLIZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_PATENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INACTIVADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CHOFER_HABITUAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHASIS_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CELDAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of VEHICULOSCollection_Base class
}  // End of namespace
