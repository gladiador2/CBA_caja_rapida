// <fileinfo name="ACTIVOSCollection_Base.cs">
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
	/// The base class for <see cref="ACTIVOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ACTIVOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string INMUEBLE_IDColumnName = "INMUEBLE_ID";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string MONTO_COMPRAColumnName = "MONTO_COMPRA";
		public const string MONEDA_COMPRA_IDColumnName = "MONEDA_COMPRA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string FECHA_COMPRAColumnName = "FECHA_COMPRA";
		public const string TIPO_ACTIVO_IDColumnName = "TIPO_ACTIVO_ID";
		public const string ACTIVO_RUBRO_IDColumnName = "ACTIVO_RUBRO_ID";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ACTIVOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ACTIVOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ACTIVOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ACTIVOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ACTIVOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ACTIVOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ACTIVOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ACTIVOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ACTIVOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ACTIVOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ACTIVOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ACTIVOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ACTIVOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_ACTIVO_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByACTIVO_RUBRO_ID(decimal activo_rubro_id)
		{
			return MapRecords(CreateGetByACTIVO_RUBRO_IDCommand(activo_rubro_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_ACTIVO_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_RUBRO_IDAsDataTable(decimal activo_rubro_id)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_RUBRO_IDCommand(activo_rubro_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_ACTIVO_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_RUBRO_IDCommand(decimal activo_rubro_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ACTIVO_RUBRO_ID", activo_rubro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
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
		/// return records by the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
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
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecords(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_IDAsDataTable(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
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
		/// return records by the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
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
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_ENTIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_ENTIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_ENTIDAD_ID</c> foreign key.
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
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByINMUEBLE_ID(decimal inmueble_id)
		{
			return GetByINMUEBLE_ID(inmueble_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <param name="inmueble_idNull">true if the method ignores the inmueble_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByINMUEBLE_ID(decimal inmueble_id, bool inmueble_idNull)
		{
			return MapRecords(CreateGetByINMUEBLE_IDCommand(inmueble_id, inmueble_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINMUEBLE_IDAsDataTable(decimal inmueble_id)
		{
			return GetByINMUEBLE_IDAsDataTable(inmueble_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <param name="inmueble_idNull">true if the method ignores the inmueble_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINMUEBLE_IDAsDataTable(decimal inmueble_id, bool inmueble_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINMUEBLE_IDCommand(inmueble_id, inmueble_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <param name="inmueble_idNull">true if the method ignores the inmueble_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINMUEBLE_IDCommand(decimal inmueble_id, bool inmueble_idNull)
		{
			string whereSql = "";
			if(inmueble_idNull)
				whereSql += "INMUEBLE_ID IS NULL";
			else
				whereSql += "INMUEBLE_ID=" + _db.CreateSqlParameterName("INMUEBLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!inmueble_idNull)
				AddParameter(cmd, "INMUEBLE_ID", inmueble_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByMONEDA_COMPRA_ID(decimal moneda_compra_id)
		{
			return GetByMONEDA_COMPRA_ID(moneda_compra_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <param name="moneda_compra_idNull">true if the method ignores the moneda_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByMONEDA_COMPRA_ID(decimal moneda_compra_id, bool moneda_compra_idNull)
		{
			return MapRecords(CreateGetByMONEDA_COMPRA_IDCommand(moneda_compra_id, moneda_compra_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_COMPRA_IDAsDataTable(decimal moneda_compra_id)
		{
			return GetByMONEDA_COMPRA_IDAsDataTable(moneda_compra_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <param name="moneda_compra_idNull">true if the method ignores the moneda_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_COMPRA_IDAsDataTable(decimal moneda_compra_id, bool moneda_compra_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_COMPRA_IDCommand(moneda_compra_id, moneda_compra_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <param name="moneda_compra_idNull">true if the method ignores the moneda_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_COMPRA_IDCommand(decimal moneda_compra_id, bool moneda_compra_idNull)
		{
			string whereSql = "";
			if(moneda_compra_idNull)
				whereSql += "MONEDA_COMPRA_ID IS NULL";
			else
				whereSql += "MONEDA_COMPRA_ID=" + _db.CreateSqlParameterName("MONEDA_COMPRA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_compra_idNull)
				AddParameter(cmd, "MONEDA_COMPRA_ID", moneda_compra_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
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
		/// return records by the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
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
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_TIPO_ACITVO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_activo_id">The <c>TIPO_ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByTIPO_ACTIVO_ID(decimal tipo_activo_id)
		{
			return MapRecords(CreateGetByTIPO_ACTIVO_IDCommand(tipo_activo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_TIPO_ACITVO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_activo_id">The <c>TIPO_ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_ACTIVO_IDAsDataTable(decimal tipo_activo_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_ACTIVO_IDCommand(tipo_activo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_TIPO_ACITVO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_activo_id">The <c>TIPO_ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_ACTIVO_IDCommand(decimal tipo_activo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ACTIVO_ID=" + _db.CreateSqlParameterName("TIPO_ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ACTIVO_ID", tipo_activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public ACTIVOSRow[] GetByVEHICULO_ID(decimal vehiculo_id)
		{
			return GetByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		public virtual ACTIVOSRow[] GetByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecords(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id)
		{
			return GetByVEHICULO_IDAsDataTable(vehiculo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
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
		/// return records by the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
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
		/// Adds a new record into the <c>ACTIVOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOSRow"/> object to be inserted.</param>
		public virtual void Insert(ACTIVOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ACTIVOS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"INMUEBLE_ID, " +
				"VEHICULO_ID, " +
				"CODIGO, " +
				"SUCURSAL_ID, " +
				"MONTO_COMPRA, " +
				"MONEDA_COMPRA_ID, " +
				"COTIZACION_MONEDA, " +
				"INGRESO_APROBADO, " +
				"ESTADO, " +
				"NOMBRE, " +
				"CENTRO_COSTO_ID, " +
				"FECHA_COMPRA, " +
				"TIPO_ACTIVO_ID, " +
				"ACTIVO_RUBRO_ID, " +
				"CASO_RELACIONADO_ID, " +
				"ARTICULO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("INMUEBLE_ID") + ", " +
				_db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_COMPRA") + ", " +
				_db.CreateSqlParameterName("MONEDA_COMPRA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_COMPRA") + ", " +
				_db.CreateSqlParameterName("TIPO_ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "INMUEBLE_ID",
				value.IsINMUEBLE_IDNull ? DBNull.Value : (object)value.INMUEBLE_ID);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "MONTO_COMPRA",
				value.IsMONTO_COMPRANull ? DBNull.Value : (object)value.MONTO_COMPRA);
			AddParameter(cmd, "MONEDA_COMPRA_ID",
				value.IsMONEDA_COMPRA_IDNull ? DBNull.Value : (object)value.MONEDA_COMPRA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "FECHA_COMPRA",
				value.IsFECHA_COMPRANull ? DBNull.Value : (object)value.FECHA_COMPRA);
			AddParameter(cmd, "TIPO_ACTIVO_ID", value.TIPO_ACTIVO_ID);
			AddParameter(cmd, "ACTIVO_RUBRO_ID", value.ACTIVO_RUBRO_ID);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ACTIVOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ACTIVOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ACTIVOS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"INMUEBLE_ID=" + _db.CreateSqlParameterName("INMUEBLE_ID") + ", " +
				"VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"MONTO_COMPRA=" + _db.CreateSqlParameterName("MONTO_COMPRA") + ", " +
				"MONEDA_COMPRA_ID=" + _db.CreateSqlParameterName("MONEDA_COMPRA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"INGRESO_APROBADO=" + _db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"FECHA_COMPRA=" + _db.CreateSqlParameterName("FECHA_COMPRA") + ", " +
				"TIPO_ACTIVO_ID=" + _db.CreateSqlParameterName("TIPO_ACTIVO_ID") + ", " +
				"ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID") + ", " +
				"CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "INMUEBLE_ID",
				value.IsINMUEBLE_IDNull ? DBNull.Value : (object)value.INMUEBLE_ID);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "MONTO_COMPRA",
				value.IsMONTO_COMPRANull ? DBNull.Value : (object)value.MONTO_COMPRA);
			AddParameter(cmd, "MONEDA_COMPRA_ID",
				value.IsMONEDA_COMPRA_IDNull ? DBNull.Value : (object)value.MONEDA_COMPRA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "FECHA_COMPRA",
				value.IsFECHA_COMPRANull ? DBNull.Value : (object)value.FECHA_COMPRA);
			AddParameter(cmd, "TIPO_ACTIVO_ID", value.TIPO_ACTIVO_ID);
			AddParameter(cmd, "ACTIVO_RUBRO_ID", value.ACTIVO_RUBRO_ID);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ACTIVOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ACTIVOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ACTIVOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ACTIVOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ACTIVOS</c> table using
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
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_ACTIVO_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_RUBRO_ID(decimal activo_rubro_id)
		{
			return CreateDeleteByACTIVO_RUBRO_IDCommand(activo_rubro_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_ACTIVO_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_RUBRO_IDCommand(decimal activo_rubro_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ACTIVO_RUBRO_ID", activo_rubro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
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
		/// delete records using the <c>FK_ACTIVOS_ARTICULO_ID</c> foreign key.
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
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return DeleteByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return CreateDeleteByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_CASO_RELACIONADO</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
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
		/// delete records using the <c>FK_ACTIVOS_CENTRO_COSTO</c> foreign key.
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
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_ENTIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_ENTIDAD_ID</c> foreign key.
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
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINMUEBLE_ID(decimal inmueble_id)
		{
			return DeleteByINMUEBLE_ID(inmueble_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <param name="inmueble_idNull">true if the method ignores the inmueble_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINMUEBLE_ID(decimal inmueble_id, bool inmueble_idNull)
		{
			return CreateDeleteByINMUEBLE_IDCommand(inmueble_id, inmueble_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_id">The <c>INMUEBLE_ID</c> column value.</param>
		/// <param name="inmueble_idNull">true if the method ignores the inmueble_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINMUEBLE_IDCommand(decimal inmueble_id, bool inmueble_idNull)
		{
			string whereSql = "";
			if(inmueble_idNull)
				whereSql += "INMUEBLE_ID IS NULL";
			else
				whereSql += "INMUEBLE_ID=" + _db.CreateSqlParameterName("INMUEBLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!inmueble_idNull)
				AddParameter(cmd, "INMUEBLE_ID", inmueble_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_COMPRA_ID(decimal moneda_compra_id)
		{
			return DeleteByMONEDA_COMPRA_ID(moneda_compra_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <param name="moneda_compra_idNull">true if the method ignores the moneda_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_COMPRA_ID(decimal moneda_compra_id, bool moneda_compra_idNull)
		{
			return CreateDeleteByMONEDA_COMPRA_IDCommand(moneda_compra_id, moneda_compra_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_compra_id">The <c>MONEDA_COMPRA_ID</c> column value.</param>
		/// <param name="moneda_compra_idNull">true if the method ignores the moneda_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_COMPRA_IDCommand(decimal moneda_compra_id, bool moneda_compra_idNull)
		{
			string whereSql = "";
			if(moneda_compra_idNull)
				whereSql += "MONEDA_COMPRA_ID IS NULL";
			else
				whereSql += "MONEDA_COMPRA_ID=" + _db.CreateSqlParameterName("MONEDA_COMPRA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_compra_idNull)
				AddParameter(cmd, "MONEDA_COMPRA_ID", moneda_compra_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
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
		/// delete records using the <c>FK_ACTIVOS_SUCURSALES</c> foreign key.
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
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_TIPO_ACITVO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_activo_id">The <c>TIPO_ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ACTIVO_ID(decimal tipo_activo_id)
		{
			return CreateDeleteByTIPO_ACTIVO_IDCommand(tipo_activo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_TIPO_ACITVO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_activo_id">The <c>TIPO_ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_ACTIVO_IDCommand(decimal tipo_activo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ACTIVO_ID=" + _db.CreateSqlParameterName("TIPO_ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ACTIVO_ID", tipo_activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id)
		{
			return DeleteByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS</c> table using the 
		/// <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
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
		/// delete records using the <c>FK_ACTIVOS_VEHICULOS</c> foreign key.
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
		/// Deletes <c>ACTIVOS</c> records that match the specified criteria.
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
		/// to delete <c>ACTIVOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ACTIVOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ACTIVOS</c> table.
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
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		protected ACTIVOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		protected ACTIVOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ACTIVOSRow"/> objects.</returns>
		protected virtual ACTIVOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int inmueble_idColumnIndex = reader.GetOrdinal("INMUEBLE_ID");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int monto_compraColumnIndex = reader.GetOrdinal("MONTO_COMPRA");
			int moneda_compra_idColumnIndex = reader.GetOrdinal("MONEDA_COMPRA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int fecha_compraColumnIndex = reader.GetOrdinal("FECHA_COMPRA");
			int tipo_activo_idColumnIndex = reader.GetOrdinal("TIPO_ACTIVO_ID");
			int activo_rubro_idColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_ID");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ACTIVOSRow record = new ACTIVOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(inmueble_idColumnIndex))
						record.INMUEBLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(inmueble_idColumnIndex)), 9);
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_compraColumnIndex))
						record.MONTO_COMPRA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_compraColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_compra_idColumnIndex))
						record.MONEDA_COMPRA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_compra_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_monedaColumnIndex))
						record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_aprobadoColumnIndex))
						record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_compraColumnIndex))
						record.FECHA_COMPRA = Convert.ToDateTime(reader.GetValue(fecha_compraColumnIndex));
					record.TIPO_ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_activo_idColumnIndex)), 9);
					record.ACTIVO_RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ACTIVOSRow[])(recordList.ToArray(typeof(ACTIVOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ACTIVOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ACTIVOSRow"/> object.</returns>
		protected virtual ACTIVOSRow MapRow(DataRow row)
		{
			ACTIVOSRow mappedObject = new ACTIVOSRow();
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
			// Column "INMUEBLE_ID"
			dataColumn = dataTable.Columns["INMUEBLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INMUEBLE_ID = (decimal)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "MONTO_COMPRA"
			dataColumn = dataTable.Columns["MONTO_COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMPRA = (decimal)row[dataColumn];
			// Column "MONEDA_COMPRA_ID"
			dataColumn = dataTable.Columns["MONEDA_COMPRA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COMPRA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "INGRESO_APROBADO"
			dataColumn = dataTable.Columns["INGRESO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_APROBADO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "FECHA_COMPRA"
			dataColumn = dataTable.Columns["FECHA_COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COMPRA = (System.DateTime)row[dataColumn];
			// Column "TIPO_ACTIVO_ID"
			dataColumn = dataTable.Columns["TIPO_ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_RUBRO_ID"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_ID = (decimal)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ACTIVOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ACTIVOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INMUEBLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COMPRA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_COMPRA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_COMPRA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TIPO_ACTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
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

				case "INMUEBLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COMPRA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ACTIVOSCollection_Base class
}  // End of namespace
