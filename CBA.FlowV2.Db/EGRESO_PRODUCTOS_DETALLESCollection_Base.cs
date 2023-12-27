// <fileinfo name="EGRESO_PRODUCTOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="EGRESO_PRODUCTOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EGRESO_PRODUCTOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESO_PRODUCTOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EGRESO_PRODUCTO_IDColumnName = "EGRESO_PRODUCTO_ID";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_TELEFONOColumnName = "CHOFER_TELEFONO";
		public const string DESTINOColumnName = "DESTINO";
		public const string DESTINO_CLIENTEColumnName = "DESTINO_CLIENTE";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string USAR_CANTIDADColumnName = "USAR_CANTIDAD";
		public const string PRESENTACION_IDColumnName = "PRESENTACION_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string CANTIDAD_PRESENTACIONColumnName = "CANTIDAD_PRESENTACION";
		public const string CANTIDAD_BASCULAColumnName = "CANTIDAD_BASCULA";
		public const string USAR_CANTIDAD_BASCULAColumnName = "USAR_CANTIDAD_BASCULA";
		public const string UNIDAD_MEDIDA_BASCULAColumnName = "UNIDAD_MEDIDA_BASCULA";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NROCOMPROBANTEColumnName = "NROCOMPROBANTE";
		public const string MARCAColumnName = "MARCA";
		public const string CIUDAD_IDColumnName = "CIUDAD_ID";
		public const string DEPARTAMENTO_IDColumnName = "DEPARTAMENTO_ID";
		public const string CHOFER_DIRECCIONColumnName = "CHOFER_DIRECCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESO_PRODUCTOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EGRESO_PRODUCTOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EGRESO_PRODUCTOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EGRESO_PRODUCTOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EGRESO_PRODUCTOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
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
		/// return records by the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
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
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByCIUDAD_ID(decimal ciudad_id)
		{
			return GetByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id)
		{
			return GetByCIUDAD_IDAsDataTable(ciudad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_IDCommand(decimal ciudad_id, bool ciudad_idNull)
		{
			string whereSql = "";
			if(ciudad_idNull)
				whereSql += "CIUDAD_ID IS NULL";
			else
				whereSql += "CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_idNull)
				AddParameter(cmd, "CIUDAD_ID", ciudad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_IDAsDataTable(departamento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_IDCommand(decimal departamento_id, bool departamento_idNull)
		{
			string whereSql = "";
			if(departamento_idNull)
				whereSql += "DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ID", departamento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByEGRESO_PRODUCTO_ID(decimal egreso_producto_id)
		{
			return MapRecords(CreateGetByEGRESO_PRODUCTO_IDCommand(egreso_producto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_PRODUCTO_IDAsDataTable(decimal egreso_producto_id)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_PRODUCTO_IDCommand(egreso_producto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_PRODUCTO_IDCommand(decimal egreso_producto_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID", egreso_producto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
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
		/// return records by the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
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
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByPRESENTACION_ID(decimal presentacion_id)
		{
			return GetByPRESENTACION_ID(presentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByPRESENTACION_ID(decimal presentacion_id, bool presentacion_idNull)
		{
			return MapRecords(CreateGetByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPRESENTACION_IDAsDataTable(decimal presentacion_id)
		{
			return GetByPRESENTACION_IDAsDataTable(presentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRESENTACION_IDAsDataTable(decimal presentacion_id, bool presentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRESENTACION_IDCommand(decimal presentacion_id, bool presentacion_idNull)
		{
			string whereSql = "";
			if(presentacion_idNull)
				whereSql += "PRESENTACION_ID IS NULL";
			else
				whereSql += "PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!presentacion_idNull)
				AddParameter(cmd, "PRESENTACION_ID", presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public EGRESO_PRODUCTOS_DETALLESRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
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
		/// return records by the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
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
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_UNIDAD_BAS</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_bascula">The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByUNIDAD_MEDIDA_BASCULA(string unidad_medida_bascula)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_BASCULACommand(unidad_medida_bascula));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_UNIDAD_BAS</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_bascula">The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_BASCULAAsDataTable(string unidad_medida_bascula)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_BASCULACommand(unidad_medida_bascula));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_UNIDAD_BAS</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_bascula">The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_BASCULACommand(string unidad_medida_bascula)
		{
			string whereSql = "";
			if(null == unidad_medida_bascula)
				whereSql += "UNIDAD_MEDIDA_BASCULA IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_BASCULA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_BASCULA");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_bascula)
				AddParameter(cmd, "UNIDAD_MEDIDA_BASCULA", unidad_medida_bascula);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects 
		/// by the <c>FK_EGRESO_PRODU_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		public virtual EGRESO_PRODUCTOS_DETALLESRow[] GetByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESO_PRODU_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_IDAsDataTable(string unidad_medida_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESO_PRODU_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			if(null == unidad_medida_id)
				whereSql += "UNIDAD_MEDIDA_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(EGRESO_PRODUCTOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EGRESO_PRODUCTOS_DETALLES (" +
				"ID, " +
				"EGRESO_PRODUCTO_ID, " +
				"CHAPA_CAMION, " +
				"CHAPA_CARRETA, " +
				"CHOFER_DOCUMENTO, " +
				"CHOFER_NOMBRE, " +
				"CHOFER_TELEFONO, " +
				"DESTINO, " +
				"DESTINO_CLIENTE, " +
				"UNIDAD_MEDIDA_ID, " +
				"USAR_CANTIDAD, " +
				"PRESENTACION_ID, " +
				"CANTIDAD, " +
				"CANTIDAD_PRESENTACION, " +
				"CANTIDAD_BASCULA, " +
				"USAR_CANTIDAD_BASCULA, " +
				"UNIDAD_MEDIDA_BASCULA, " +
				"PERSONA_ID, " +
				"PROVEEDOR_ID, " +
				"AUTONUMERACION_ID, " +
				"NROCOMPROBANTE, " +
				"MARCA, " +
				"CIUDAD_ID, " +
				"DEPARTAMENTO_ID, " +
				"CHOFER_DIRECCION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_PRODUCTO_ID") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CHOFER_TELEFONO") + ", " +
				_db.CreateSqlParameterName("DESTINO") + ", " +
				_db.CreateSqlParameterName("DESTINO_CLIENTE") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD") + ", " +
				_db.CreateSqlParameterName("PRESENTACION_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_PRESENTACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_BASCULA") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD_BASCULA") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_BASCULA") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NROCOMPROBANTE") + ", " +
				_db.CreateSqlParameterName("MARCA") + ", " +
				_db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				_db.CreateSqlParameterName("CHOFER_DIRECCION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID", value.EGRESO_PRODUCTO_ID);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_TELEFONO", value.CHOFER_TELEFONO);
			AddParameter(cmd, "DESTINO", value.DESTINO);
			AddParameter(cmd, "DESTINO_CLIENTE", value.DESTINO_CLIENTE);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "USAR_CANTIDAD", value.USAR_CANTIDAD);
			AddParameter(cmd, "PRESENTACION_ID",
				value.IsPRESENTACION_IDNull ? DBNull.Value : (object)value.PRESENTACION_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "CANTIDAD_PRESENTACION",
				value.IsCANTIDAD_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_PRESENTACION);
			AddParameter(cmd, "CANTIDAD_BASCULA",
				value.IsCANTIDAD_BASCULANull ? DBNull.Value : (object)value.CANTIDAD_BASCULA);
			AddParameter(cmd, "USAR_CANTIDAD_BASCULA", value.USAR_CANTIDAD_BASCULA);
			AddParameter(cmd, "UNIDAD_MEDIDA_BASCULA", value.UNIDAD_MEDIDA_BASCULA);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NROCOMPROBANTE", value.NROCOMPROBANTE);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "CHOFER_DIRECCION", value.CHOFER_DIRECCION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESO_PRODUCTOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EGRESO_PRODUCTOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.EGRESO_PRODUCTOS_DETALLES SET " +
				"EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHAPA_CARRETA=" + _db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"CHOFER_TELEFONO=" + _db.CreateSqlParameterName("CHOFER_TELEFONO") + ", " +
				"DESTINO=" + _db.CreateSqlParameterName("DESTINO") + ", " +
				"DESTINO_CLIENTE=" + _db.CreateSqlParameterName("DESTINO_CLIENTE") + ", " +
				"UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				"USAR_CANTIDAD=" + _db.CreateSqlParameterName("USAR_CANTIDAD") + ", " +
				"PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"CANTIDAD_PRESENTACION=" + _db.CreateSqlParameterName("CANTIDAD_PRESENTACION") + ", " +
				"CANTIDAD_BASCULA=" + _db.CreateSqlParameterName("CANTIDAD_BASCULA") + ", " +
				"USAR_CANTIDAD_BASCULA=" + _db.CreateSqlParameterName("USAR_CANTIDAD_BASCULA") + ", " +
				"UNIDAD_MEDIDA_BASCULA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_BASCULA") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NROCOMPROBANTE=" + _db.CreateSqlParameterName("NROCOMPROBANTE") + ", " +
				"MARCA=" + _db.CreateSqlParameterName("MARCA") + ", " +
				"CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				"DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				"CHOFER_DIRECCION=" + _db.CreateSqlParameterName("CHOFER_DIRECCION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID", value.EGRESO_PRODUCTO_ID);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_TELEFONO", value.CHOFER_TELEFONO);
			AddParameter(cmd, "DESTINO", value.DESTINO);
			AddParameter(cmd, "DESTINO_CLIENTE", value.DESTINO_CLIENTE);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "USAR_CANTIDAD", value.USAR_CANTIDAD);
			AddParameter(cmd, "PRESENTACION_ID",
				value.IsPRESENTACION_IDNull ? DBNull.Value : (object)value.PRESENTACION_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "CANTIDAD_PRESENTACION",
				value.IsCANTIDAD_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_PRESENTACION);
			AddParameter(cmd, "CANTIDAD_BASCULA",
				value.IsCANTIDAD_BASCULANull ? DBNull.Value : (object)value.CANTIDAD_BASCULA);
			AddParameter(cmd, "USAR_CANTIDAD_BASCULA", value.USAR_CANTIDAD_BASCULA);
			AddParameter(cmd, "UNIDAD_MEDIDA_BASCULA", value.UNIDAD_MEDIDA_BASCULA);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NROCOMPROBANTE", value.NROCOMPROBANTE);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "CHOFER_DIRECCION", value.CHOFER_DIRECCION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EGRESO_PRODUCTOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EGRESO_PRODUCTOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EGRESO_PRODUCTOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using
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
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
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
		/// delete records using the <c>FK_EGRESO_PRODU_DET_AUTONUM_ID</c> foreign key.
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
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id)
		{
			return DeleteByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return CreateDeleteByCIUDAD_IDCommand(ciudad_id, ciudad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_CIUDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_IDCommand(decimal ciudad_id, bool ciudad_idNull)
		{
			string whereSql = "";
			if(ciudad_idNull)
				whereSql += "CIUDAD_ID IS NULL";
			else
				whereSql += "CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_idNull)
				AddParameter(cmd, "CIUDAD_ID", ciudad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return DeleteByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_DEPART_ID</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_IDCommand(decimal departamento_id, bool departamento_idNull)
		{
			string whereSql = "";
			if(departamento_idNull)
				whereSql += "DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ID", departamento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_PRODUCTO_ID(decimal egreso_producto_id)
		{
			return CreateDeleteByEGRESO_PRODUCTO_IDCommand(egreso_producto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_PRODUCTO_IDCommand(decimal egreso_producto_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID", egreso_producto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
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
		/// delete records using the <c>FK_EGRESO_PRODU_DET_PERSONA_ID</c> foreign key.
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
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESENTACION_ID(decimal presentacion_id)
		{
			return DeleteByPRESENTACION_ID(presentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESENTACION_ID(decimal presentacion_id, bool presentacion_idNull)
		{
			return CreateDeleteByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_PRESEN_ID</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRESENTACION_IDCommand(decimal presentacion_id, bool presentacion_idNull)
		{
			string whereSql = "";
			if(presentacion_idNull)
				whereSql += "PRESENTACION_ID IS NULL";
			else
				whereSql += "PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!presentacion_idNull)
				AddParameter(cmd, "PRESENTACION_ID", presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
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
		/// delete records using the <c>FK_EGRESO_PRODU_DET_PROVEE_ID</c> foreign key.
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
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_UNIDAD_BAS</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_bascula">The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_BASCULA(string unidad_medida_bascula)
		{
			return CreateDeleteByUNIDAD_MEDIDA_BASCULACommand(unidad_medida_bascula).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_UNIDAD_BAS</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_bascula">The <c>UNIDAD_MEDIDA_BASCULA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_BASCULACommand(string unidad_medida_bascula)
		{
			string whereSql = "";
			if(null == unidad_medida_bascula)
				whereSql += "UNIDAD_MEDIDA_BASCULA IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_BASCULA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_BASCULA");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_bascula)
				AddParameter(cmd, "UNIDAD_MEDIDA_BASCULA", unidad_medida_bascula);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table using the 
		/// <c>FK_EGRESO_PRODU_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_IDCommand(unidad_medida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESO_PRODU_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			if(null == unidad_medida_id)
				whereSql += "UNIDAD_MEDIDA_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>EGRESO_PRODUCTOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>EGRESO_PRODUCTOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EGRESO_PRODUCTOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		protected EGRESO_PRODUCTOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		protected EGRESO_PRODUCTOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> objects.</returns>
		protected virtual EGRESO_PRODUCTOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int egreso_producto_idColumnIndex = reader.GetOrdinal("EGRESO_PRODUCTO_ID");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_telefonoColumnIndex = reader.GetOrdinal("CHOFER_TELEFONO");
			int destinoColumnIndex = reader.GetOrdinal("DESTINO");
			int destino_clienteColumnIndex = reader.GetOrdinal("DESTINO_CLIENTE");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int usar_cantidadColumnIndex = reader.GetOrdinal("USAR_CANTIDAD");
			int presentacion_idColumnIndex = reader.GetOrdinal("PRESENTACION_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int cantidad_presentacionColumnIndex = reader.GetOrdinal("CANTIDAD_PRESENTACION");
			int cantidad_basculaColumnIndex = reader.GetOrdinal("CANTIDAD_BASCULA");
			int usar_cantidad_basculaColumnIndex = reader.GetOrdinal("USAR_CANTIDAD_BASCULA");
			int unidad_medida_basculaColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_BASCULA");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nrocomprobanteColumnIndex = reader.GetOrdinal("NROCOMPROBANTE");
			int marcaColumnIndex = reader.GetOrdinal("MARCA");
			int ciudad_idColumnIndex = reader.GetOrdinal("CIUDAD_ID");
			int departamento_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ID");
			int chofer_direccionColumnIndex = reader.GetOrdinal("CHOFER_DIRECCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EGRESO_PRODUCTOS_DETALLESRow record = new EGRESO_PRODUCTOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.EGRESO_PRODUCTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_producto_idColumnIndex)), 9);
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_telefonoColumnIndex))
						record.CHOFER_TELEFONO = Convert.ToString(reader.GetValue(chofer_telefonoColumnIndex));
					if(!reader.IsDBNull(destinoColumnIndex))
						record.DESTINO = Convert.ToString(reader.GetValue(destinoColumnIndex));
					if(!reader.IsDBNull(destino_clienteColumnIndex))
						record.DESTINO_CLIENTE = Convert.ToString(reader.GetValue(destino_clienteColumnIndex));
					if(!reader.IsDBNull(unidad_medida_idColumnIndex))
						record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(usar_cantidadColumnIndex))
						record.USAR_CANTIDAD = Convert.ToString(reader.GetValue(usar_cantidadColumnIndex));
					if(!reader.IsDBNull(presentacion_idColumnIndex))
						record.PRESENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_presentacionColumnIndex))
						record.CANTIDAD_PRESENTACION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_presentacionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_basculaColumnIndex))
						record.CANTIDAD_BASCULA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_basculaColumnIndex)), 9);
					if(!reader.IsDBNull(usar_cantidad_basculaColumnIndex))
						record.USAR_CANTIDAD_BASCULA = Convert.ToString(reader.GetValue(usar_cantidad_basculaColumnIndex));
					if(!reader.IsDBNull(unidad_medida_basculaColumnIndex))
						record.UNIDAD_MEDIDA_BASCULA = Convert.ToString(reader.GetValue(unidad_medida_basculaColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nrocomprobanteColumnIndex))
						record.NROCOMPROBANTE = Convert.ToString(reader.GetValue(nrocomprobanteColumnIndex));
					if(!reader.IsDBNull(marcaColumnIndex))
						record.MARCA = Convert.ToString(reader.GetValue(marcaColumnIndex));
					if(!reader.IsDBNull(ciudad_idColumnIndex))
						record.CIUDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_idColumnIndex))
						record.DEPARTAMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_idColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_direccionColumnIndex))
						record.CHOFER_DIRECCION = Convert.ToString(reader.GetValue(chofer_direccionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EGRESO_PRODUCTOS_DETALLESRow[])(recordList.ToArray(typeof(EGRESO_PRODUCTOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EGRESO_PRODUCTOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EGRESO_PRODUCTOS_DETALLESRow"/> object.</returns>
		protected virtual EGRESO_PRODUCTOS_DETALLESRow MapRow(DataRow row)
		{
			EGRESO_PRODUCTOS_DETALLESRow mappedObject = new EGRESO_PRODUCTOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EGRESO_PRODUCTO_ID"
			dataColumn = dataTable.Columns["EGRESO_PRODUCTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_PRODUCTO_ID = (decimal)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_TELEFONO"
			dataColumn = dataTable.Columns["CHOFER_TELEFONO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_TELEFONO = (string)row[dataColumn];
			// Column "DESTINO"
			dataColumn = dataTable.Columns["DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESTINO = (string)row[dataColumn];
			// Column "DESTINO_CLIENTE"
			dataColumn = dataTable.Columns["DESTINO_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESTINO_CLIENTE = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "USAR_CANTIDAD"
			dataColumn = dataTable.Columns["USAR_CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD = (string)row[dataColumn];
			// Column "PRESENTACION_ID"
			dataColumn = dataTable.Columns["PRESENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESENTACION_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "CANTIDAD_PRESENTACION"
			dataColumn = dataTable.Columns["CANTIDAD_PRESENTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PRESENTACION = (decimal)row[dataColumn];
			// Column "CANTIDAD_BASCULA"
			dataColumn = dataTable.Columns["CANTIDAD_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_BASCULA = (decimal)row[dataColumn];
			// Column "USAR_CANTIDAD_BASCULA"
			dataColumn = dataTable.Columns["USAR_CANTIDAD_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD_BASCULA = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_BASCULA"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_BASCULA = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NROCOMPROBANTE"
			dataColumn = dataTable.Columns["NROCOMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NROCOMPROBANTE = (string)row[dataColumn];
			// Column "MARCA"
			dataColumn = dataTable.Columns["MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA = (string)row[dataColumn];
			// Column "CIUDAD_ID"
			dataColumn = dataTable.Columns["CIUDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ID = (decimal)row[dataColumn];
			// Column "CHOFER_DIRECCION"
			dataColumn = dataTable.Columns["CHOFER_DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DIRECCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EGRESO_PRODUCTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EGRESO_PRODUCTOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EGRESO_PRODUCTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHOFER_TELEFONO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("DESTINO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DESTINO_CLIENTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PRESENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_PRESENTACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_BASCULA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD_BASCULA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_BASCULA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NROCOMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("MARCA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CIUDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_DIRECCION", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "EGRESO_PRODUCTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_TELEFONO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESTINO_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USAR_CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRESENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_PRESENTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USAR_CANTIDAD_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UNIDAD_MEDIDA_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NROCOMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EGRESO_PRODUCTOS_DETALLESCollection_Base class
}  // End of namespace
