// <fileinfo name="FACTURAS_PROVEEDOR_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDOR_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_PROVEEDOR_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDOR_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FACTURAS_PROVEEDOR_IDColumnName = "FACTURAS_PROVEEDOR_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string UNIDAD_ID_DESTINOColumnName = "UNIDAD_ID_DESTINO";
		public const string CANTIDAD_EMBALADA_DESTINOColumnName = "CANTIDAD_EMBALADA_DESTINO";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string PRECIO_BRUTO_UNITARIO_DESTColumnName = "PRECIO_BRUTO_UNITARIO_DEST";
		public const string PORCENTAJE_DESCUENTOColumnName = "PORCENTAJE_DESCUENTO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string TOTAL_BRUTOColumnName = "TOTAL_BRUTO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_IMPUESTO_DESCONTADOColumnName = "TOTAL_IMPUESTO_DESCONTADO";
		public const string TOTAL_PAGOColumnName = "TOTAL_PAGO";
		public const string CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName = "CANTIDAD_DEVUELTA_NOTA_CREDITO";
		public const string UNIDAD_ID_ORIGENColumnName = "UNIDAD_ID_ORIGEN";
		public const string CANTIDAD_EMBALADA_ORIGENColumnName = "CANTIDAD_EMBALADA_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string PRECIO_BRUTO_UNITARIO_ORIGColumnName = "PRECIO_BRUTO_UNITARIO_ORIG";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TIPO_DETALLEColumnName = "TIPO_DETALLE";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";
		public const string PROVEEDOR_RELACIONADO_IDColumnName = "PROVEEDOR_RELACIONADO_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string RUBRO_IVA_IDColumnName = "RUBRO_IVA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDOR_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_PROVEEDOR_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_PROVEEDOR_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FACTURAS_PROVEEDOR_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id, bool activo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_FC</c> foreign key.
		/// </summary>
		/// <param name="facturas_proveedor_id">The <c>FACTURAS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByFACTURAS_PROVEEDOR_ID(decimal facturas_proveedor_id)
		{
			return MapRecords(CreateGetByFACTURAS_PROVEEDOR_IDCommand(facturas_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_FC</c> foreign key.
		/// </summary>
		/// <param name="facturas_proveedor_id">The <c>FACTURAS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURAS_PROVEEDOR_IDAsDataTable(decimal facturas_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByFACTURAS_PROVEEDOR_IDCommand(facturas_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_FC</c> foreign key.
		/// </summary>
		/// <param name="facturas_proveedor_id">The <c>FACTURAS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURAS_PROVEEDOR_IDCommand(decimal facturas_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FACTURAS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURAS_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_ID", facturas_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOTE_IDAsDataTable(decimal lote_id, bool lote_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id)
		{
			return GetByPROVEEDOR_RELACIONADO_ID(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_RELACIONADO_IDCommand(proveedor_relacionado_id, proveedor_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_RELACIONADO_IDAsDataTable(decimal proveedor_relacionado_id)
		{
			return GetByPROVEEDOR_RELACIONADO_IDAsDataTable(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_RELACIONADO_IDAsDataTable(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_RELACIONADO_IDCommand(proveedor_relacionado_id, proveedor_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_RELACIONADO_IDCommand(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			string whereSql = "";
			if(proveedor_relacionado_idNull)
				whereSql += "PROVEEDOR_RELACIONADO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_RELACIONADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_relacionado_idNull)
				AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID", proveedor_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByRUBRO_ID(decimal rubro_id)
		{
			return GetByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id)
		{
			return GetByRUBRO_IDAsDataTable(rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByRUBRO_IVA_ID(decimal rubro_iva_id)
		{
			return GetByRUBRO_IVA_ID(rubro_iva_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <param name="rubro_iva_idNull">true if the method ignores the rubro_iva_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByRUBRO_IVA_ID(decimal rubro_iva_id, bool rubro_iva_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IVA_IDCommand(rubro_iva_id, rubro_iva_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IVA_IDAsDataTable(decimal rubro_iva_id)
		{
			return GetByRUBRO_IVA_IDAsDataTable(rubro_iva_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <param name="rubro_iva_idNull">true if the method ignores the rubro_iva_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRUBRO_IVA_IDAsDataTable(decimal rubro_iva_id, bool rubro_iva_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRUBRO_IVA_IDCommand(rubro_iva_id, rubro_iva_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <param name="rubro_iva_idNull">true if the method ignores the rubro_iva_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRUBRO_IVA_IDCommand(decimal rubro_iva_id, bool rubro_iva_idNull)
		{
			string whereSql = "";
			if(rubro_iva_idNull)
				whereSql += "RUBRO_IVA_ID IS NULL";
			else
				whereSql += "RUBRO_IVA_ID=" + _db.CreateSqlParameterName("RUBRO_IVA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rubro_iva_idNull)
				AddParameter(cmd, "RUBRO_IVA_ID", rubro_iva_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DETALLERow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_UNID_D</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_destino">The <c>UNIDAD_ID_DESTINO</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByUNIDAD_ID_DESTINO(string unidad_id_destino)
		{
			return MapRecords(CreateGetByUNIDAD_ID_DESTINOCommand(unidad_id_destino));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_UNID_D</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_destino">The <c>UNIDAD_ID_DESTINO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_ID_DESTINOAsDataTable(string unidad_id_destino)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_ID_DESTINOCommand(unidad_id_destino));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_UNID_D</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_destino">The <c>UNIDAD_ID_DESTINO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_ID_DESTINOCommand(string unidad_id_destino)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ID_DESTINO=" + _db.CreateSqlParameterName("UNIDAD_ID_DESTINO");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_ID_DESTINO", unidad_id_destino);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_DET_UNID_O</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_origen">The <c>UNIDAD_ID_ORIGEN</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DETALLERow[] GetByUNIDAD_ID_ORIGEN(string unidad_id_origen)
		{
			return MapRecords(CreateGetByUNIDAD_ID_ORIGENCommand(unidad_id_origen));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_DET_UNID_O</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_origen">The <c>UNIDAD_ID_ORIGEN</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_ID_ORIGENAsDataTable(string unidad_id_origen)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_ID_ORIGENCommand(unidad_id_origen));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_DET_UNID_O</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_origen">The <c>UNIDAD_ID_ORIGEN</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_ID_ORIGENCommand(string unidad_id_origen)
		{
			string whereSql = "";
			if(null == unidad_id_origen)
				whereSql += "UNIDAD_ID_ORIGEN IS NULL";
			else
				whereSql += "UNIDAD_ID_ORIGEN=" + _db.CreateSqlParameterName("UNIDAD_ID_ORIGEN");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_id_origen)
				AddParameter(cmd, "UNIDAD_ID_ORIGEN", unidad_id_origen);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(FACTURAS_PROVEEDOR_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FACTURAS_PROVEEDOR_DETALLE (" +
				"ID, " +
				"FACTURAS_PROVEEDOR_ID, " +
				"OBSERVACION, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"UNIDAD_ID_DESTINO, " +
				"CANTIDAD_EMBALADA_DESTINO, " +
				"CANTIDAD_UNIDAD_DESTINO, " +
				"CANTIDAD_POR_CAJA_DESTINO, " +
				"CANTIDAD_UNITARIA_TOTAL_DEST, " +
				"PRECIO_BRUTO_UNITARIO_DEST, " +
				"PORCENTAJE_DESCUENTO, " +
				"PORCENTAJE_IMPUESTO, " +
				"TOTAL_BRUTO, " +
				"TOTAL_DESCUENTO, " +
				"TOTAL_IMPUESTO_DESCONTADO, " +
				"TOTAL_PAGO, " +
				"CANTIDAD_DEVUELTA_NOTA_CREDITO, " +
				"UNIDAD_ID_ORIGEN, " +
				"CANTIDAD_EMBALADA_ORIGEN, " +
				"CANTIDAD_POR_CAJA_ORIGEN, " +
				"CANTIDAD_UNIDAD_ORIGEN, " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG, " +
				"FACTOR_CONVERSION, " +
				"PRECIO_BRUTO_UNITARIO_ORIG, " +
				"RUBRO_ID, " +
				"ACTIVO_ID, " +
				"IMPUESTO_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"TIPO_DETALLE, " +
				"AFECTA_STOCK, " +
				"PROVEEDOR_RELACIONADO_ID, " +
				"CASO_ASOCIADO_ID, " +
				"RUBRO_IVA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FACTURAS_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
				_db.CreateSqlParameterName("PRECIO_BRUTO_UNITARIO_DEST") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_IMPUESTO_DESCONTADO") + ", " +
				_db.CreateSqlParameterName("TOTAL_PAGO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEVUELTA_NOTA_CREDITO") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("PRECIO_BRUTO_UNITARIO_ORIG") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_DETALLE") + ", " +
				_db.CreateSqlParameterName("AFECTA_STOCK") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("RUBRO_IVA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_ID", value.FACTURAS_PROVEEDOR_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_ID_DESTINO", value.UNIDAD_ID_DESTINO);
			AddParameter(cmd, "CANTIDAD_EMBALADA_DESTINO", value.CANTIDAD_EMBALADA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
			AddParameter(cmd, "PRECIO_BRUTO_UNITARIO_DEST", value.PRECIO_BRUTO_UNITARIO_DEST);
			AddParameter(cmd, "PORCENTAJE_DESCUENTO", value.PORCENTAJE_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "TOTAL_BRUTO", value.TOTAL_BRUTO);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_IMPUESTO_DESCONTADO", value.TOTAL_IMPUESTO_DESCONTADO);
			AddParameter(cmd, "TOTAL_PAGO", value.TOTAL_PAGO);
			AddParameter(cmd, "CANTIDAD_DEVUELTA_NOTA_CREDITO",
				value.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull ? DBNull.Value : (object)value.CANTIDAD_DEVUELTA_NOTA_CREDITO);
			AddParameter(cmd, "UNIDAD_ID_ORIGEN", value.UNIDAD_ID_ORIGEN);
			AddParameter(cmd, "CANTIDAD_EMBALADA_ORIGEN",
				value.IsCANTIDAD_EMBALADA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_EMBALADA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "PRECIO_BRUTO_UNITARIO_ORIG",
				value.IsPRECIO_BRUTO_UNITARIO_ORIGNull ? DBNull.Value : (object)value.PRECIO_BRUTO_UNITARIO_ORIG);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TIPO_DETALLE", value.TIPO_DETALLE);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID",
				value.IsPROVEEDOR_RELACIONADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_RELACIONADO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "RUBRO_IVA_ID",
				value.IsRUBRO_IVA_IDNull ? DBNull.Value : (object)value.RUBRO_IVA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDOR_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FACTURAS_PROVEEDOR_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.FACTURAS_PROVEEDOR_DETALLE SET " +
				"FACTURAS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURAS_PROVEEDOR_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"UNIDAD_ID_DESTINO=" + _db.CreateSqlParameterName("UNIDAD_ID_DESTINO") + ", " +
				"CANTIDAD_EMBALADA_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA_DESTINO") + ", " +
				"CANTIDAD_UNIDAD_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				"CANTIDAD_POR_CAJA_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_DEST=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
				"PRECIO_BRUTO_UNITARIO_DEST=" + _db.CreateSqlParameterName("PRECIO_BRUTO_UNITARIO_DEST") + ", " +
				"PORCENTAJE_DESCUENTO=" + _db.CreateSqlParameterName("PORCENTAJE_DESCUENTO") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"TOTAL_BRUTO=" + _db.CreateSqlParameterName("TOTAL_BRUTO") + ", " +
				"TOTAL_DESCUENTO=" + _db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				"TOTAL_IMPUESTO_DESCONTADO=" + _db.CreateSqlParameterName("TOTAL_IMPUESTO_DESCONTADO") + ", " +
				"TOTAL_PAGO=" + _db.CreateSqlParameterName("TOTAL_PAGO") + ", " +
				"CANTIDAD_DEVUELTA_NOTA_CREDITO=" + _db.CreateSqlParameterName("CANTIDAD_DEVUELTA_NOTA_CREDITO") + ", " +
				"UNIDAD_ID_ORIGEN=" + _db.CreateSqlParameterName("UNIDAD_ID_ORIGEN") + ", " +
				"CANTIDAD_EMBALADA_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA_ORIGEN") + ", " +
				"CANTIDAD_POR_CAJA_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				"CANTIDAD_UNIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"PRECIO_BRUTO_UNITARIO_ORIG=" + _db.CreateSqlParameterName("PRECIO_BRUTO_UNITARIO_ORIG") + ", " +
				"RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"TIPO_DETALLE=" + _db.CreateSqlParameterName("TIPO_DETALLE") + ", " +
				"AFECTA_STOCK=" + _db.CreateSqlParameterName("AFECTA_STOCK") + ", " +
				"PROVEEDOR_RELACIONADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"RUBRO_IVA_ID=" + _db.CreateSqlParameterName("RUBRO_IVA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_ID", value.FACTURAS_PROVEEDOR_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_ID_DESTINO", value.UNIDAD_ID_DESTINO);
			AddParameter(cmd, "CANTIDAD_EMBALADA_DESTINO", value.CANTIDAD_EMBALADA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
			AddParameter(cmd, "PRECIO_BRUTO_UNITARIO_DEST", value.PRECIO_BRUTO_UNITARIO_DEST);
			AddParameter(cmd, "PORCENTAJE_DESCUENTO", value.PORCENTAJE_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "TOTAL_BRUTO", value.TOTAL_BRUTO);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_IMPUESTO_DESCONTADO", value.TOTAL_IMPUESTO_DESCONTADO);
			AddParameter(cmd, "TOTAL_PAGO", value.TOTAL_PAGO);
			AddParameter(cmd, "CANTIDAD_DEVUELTA_NOTA_CREDITO",
				value.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull ? DBNull.Value : (object)value.CANTIDAD_DEVUELTA_NOTA_CREDITO);
			AddParameter(cmd, "UNIDAD_ID_ORIGEN", value.UNIDAD_ID_ORIGEN);
			AddParameter(cmd, "CANTIDAD_EMBALADA_ORIGEN",
				value.IsCANTIDAD_EMBALADA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_EMBALADA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "PRECIO_BRUTO_UNITARIO_ORIG",
				value.IsPRECIO_BRUTO_UNITARIO_ORIGNull ? DBNull.Value : (object)value.PRECIO_BRUTO_UNITARIO_ORIG);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "TIPO_DETALLE", value.TIPO_DETALLE);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID",
				value.IsPROVEEDOR_RELACIONADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_RELACIONADO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "RUBRO_IVA_ID",
				value.IsRUBRO_IVA_IDNull ? DBNull.Value : (object)value.RUBRO_IVA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FACTURAS_PROVEEDOR_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FACTURAS_PROVEEDOR_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FACTURAS_PROVEEDOR_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using
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
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id, activo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_PROV_DET_ART</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_FC</c> foreign key.
		/// </summary>
		/// <param name="facturas_proveedor_id">The <c>FACTURAS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURAS_PROVEEDOR_ID(decimal facturas_proveedor_id)
		{
			return CreateDeleteByFACTURAS_PROVEEDOR_IDCommand(facturas_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_FC</c> foreign key.
		/// </summary>
		/// <param name="facturas_proveedor_id">The <c>FACTURAS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURAS_PROVEEDOR_IDCommand(decimal facturas_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FACTURAS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURAS_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_ID", facturas_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return CreateDeleteByLOTE_IDCommand(lote_id, lote_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id)
		{
			return DeleteByPROVEEDOR_RELACIONADO_ID(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			return CreateDeleteByPROVEEDOR_RELACIONADO_IDCommand(proveedor_relacionado_id, proveedor_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_RELACIONADO_IDCommand(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			string whereSql = "";
			if(proveedor_relacionado_idNull)
				whereSql += "PROVEEDOR_RELACIONADO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_RELACIONADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_relacionado_idNull)
				AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID", proveedor_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id)
		{
			return DeleteByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_PROV_DET_RUBRO</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_IVA_ID(decimal rubro_iva_id)
		{
			return DeleteByRUBRO_IVA_ID(rubro_iva_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <param name="rubro_iva_idNull">true if the method ignores the rubro_iva_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_IVA_ID(decimal rubro_iva_id, bool rubro_iva_idNull)
		{
			return CreateDeleteByRUBRO_IVA_IDCommand(rubro_iva_id, rubro_iva_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_RUBRO_IVA_ID</c> foreign key.
		/// </summary>
		/// <param name="rubro_iva_id">The <c>RUBRO_IVA_ID</c> column value.</param>
		/// <param name="rubro_iva_idNull">true if the method ignores the rubro_iva_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRUBRO_IVA_IDCommand(decimal rubro_iva_id, bool rubro_iva_idNull)
		{
			string whereSql = "";
			if(rubro_iva_idNull)
				whereSql += "RUBRO_IVA_ID IS NULL";
			else
				whereSql += "RUBRO_IVA_ID=" + _db.CreateSqlParameterName("RUBRO_IVA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rubro_iva_idNull)
				AddParameter(cmd, "RUBRO_IVA_ID", rubro_iva_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_UNID_D</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_destino">The <c>UNIDAD_ID_DESTINO</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID_DESTINO(string unidad_id_destino)
		{
			return CreateDeleteByUNIDAD_ID_DESTINOCommand(unidad_id_destino).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_UNID_D</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_destino">The <c>UNIDAD_ID_DESTINO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_ID_DESTINOCommand(string unidad_id_destino)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ID_DESTINO=" + _db.CreateSqlParameterName("UNIDAD_ID_DESTINO");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_ID_DESTINO", unidad_id_destino);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_PROV_DET_UNID_O</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_origen">The <c>UNIDAD_ID_ORIGEN</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID_ORIGEN(string unidad_id_origen)
		{
			return CreateDeleteByUNIDAD_ID_ORIGENCommand(unidad_id_origen).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_DET_UNID_O</c> foreign key.
		/// </summary>
		/// <param name="unidad_id_origen">The <c>UNIDAD_ID_ORIGEN</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_ID_ORIGENCommand(string unidad_id_origen)
		{
			string whereSql = "";
			if(null == unidad_id_origen)
				whereSql += "UNIDAD_ID_ORIGEN IS NULL";
			else
				whereSql += "UNIDAD_ID_ORIGEN=" + _db.CreateSqlParameterName("UNIDAD_ID_ORIGEN");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_id_origen)
				AddParameter(cmd, "UNIDAD_ID_ORIGEN", unidad_id_origen);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FACTURAS_PROVEEDOR_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>FACTURAS_PROVEEDOR_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FACTURAS_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected virtual FACTURAS_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int facturas_proveedor_idColumnIndex = reader.GetOrdinal("FACTURAS_PROVEEDOR_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int unidad_id_destinoColumnIndex = reader.GetOrdinal("UNIDAD_ID_DESTINO");
			int cantidad_embalada_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA_DESTINO");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int precio_bruto_unitario_destColumnIndex = reader.GetOrdinal("PRECIO_BRUTO_UNITARIO_DEST");
			int porcentaje_descuentoColumnIndex = reader.GetOrdinal("PORCENTAJE_DESCUENTO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int total_brutoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_impuesto_descontadoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO_DESCONTADO");
			int total_pagoColumnIndex = reader.GetOrdinal("TOTAL_PAGO");
			int cantidad_devuelta_nota_creditoColumnIndex = reader.GetOrdinal("CANTIDAD_DEVUELTA_NOTA_CREDITO");
			int unidad_id_origenColumnIndex = reader.GetOrdinal("UNIDAD_ID_ORIGEN");
			int cantidad_embalada_origenColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int precio_bruto_unitario_origColumnIndex = reader.GetOrdinal("PRECIO_BRUTO_UNITARIO_ORIG");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int tipo_detalleColumnIndex = reader.GetOrdinal("TIPO_DETALLE");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");
			int proveedor_relacionado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_RELACIONADO_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int rubro_iva_idColumnIndex = reader.GetOrdinal("RUBRO_IVA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_PROVEEDOR_DETALLERow record = new FACTURAS_PROVEEDOR_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FACTURAS_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					record.UNIDAD_ID_DESTINO = Convert.ToString(reader.GetValue(unidad_id_destinoColumnIndex));
					record.CANTIDAD_EMBALADA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embalada_destinoColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					record.PRECIO_BRUTO_UNITARIO_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(precio_bruto_unitario_destColumnIndex)), 9);
					record.PORCENTAJE_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_descuentoColumnIndex)), 9);
					record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					record.TOTAL_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_brutoColumnIndex)), 9);
					record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					record.TOTAL_IMPUESTO_DESCONTADO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuesto_descontadoColumnIndex)), 9);
					record.TOTAL_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(total_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_devuelta_nota_creditoColumnIndex))
						record.CANTIDAD_DEVUELTA_NOTA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_devuelta_nota_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_id_origenColumnIndex))
						record.UNIDAD_ID_ORIGEN = Convert.ToString(reader.GetValue(unidad_id_origenColumnIndex));
					if(!reader.IsDBNull(cantidad_embalada_origenColumnIndex))
						record.CANTIDAD_EMBALADA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embalada_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_caja_origenColumnIndex))
						record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unidad_origenColumnIndex))
						record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_origColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(precio_bruto_unitario_origColumnIndex))
						record.PRECIO_BRUTO_UNITARIO_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(precio_bruto_unitario_origColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.TIPO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(afecta_stockColumnIndex))
						record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));
					if(!reader.IsDBNull(proveedor_relacionado_idColumnIndex))
						record.PROVEEDOR_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_iva_idColumnIndex))
						record.RUBRO_IVA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_iva_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_PROVEEDOR_DETALLERow[])(recordList.ToArray(typeof(FACTURAS_PROVEEDOR_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_PROVEEDOR_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> object.</returns>
		protected virtual FACTURAS_PROVEEDOR_DETALLERow MapRow(DataRow row)
		{
			FACTURAS_PROVEEDOR_DETALLERow mappedObject = new FACTURAS_PROVEEDOR_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FACTURAS_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["FACTURAS_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_ID_DESTINO"
			dataColumn = dataTable.Columns["UNIDAD_ID_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID_DESTINO = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
			// Column "PRECIO_BRUTO_UNITARIO_DEST"
			dataColumn = dataTable.Columns["PRECIO_BRUTO_UNITARIO_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_BRUTO_UNITARIO_DEST = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESCUENTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESCUENTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO_DESCONTADO"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO_DESCONTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO_DESCONTADO = (decimal)row[dataColumn];
			// Column "TOTAL_PAGO"
			dataColumn = dataTable.Columns["TOTAL_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_PAGO = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEVUELTA_NOTA_CREDITO"
			dataColumn = dataTable.Columns["CANTIDAD_DEVUELTA_NOTA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEVUELTA_NOTA_CREDITO = (decimal)row[dataColumn];
			// Column "UNIDAD_ID_ORIGEN"
			dataColumn = dataTable.Columns["UNIDAD_ID_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID_ORIGEN = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIG"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "PRECIO_BRUTO_UNITARIO_ORIG"
			dataColumn = dataTable.Columns["PRECIO_BRUTO_UNITARIO_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_BRUTO_UNITARIO_ORIG = (decimal)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TIPO_DETALLE"
			dataColumn = dataTable.Columns["TIPO_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DETALLE = (decimal)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			// Column "PROVEEDOR_RELACIONADO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_IVA_ID"
			dataColumn = dataTable.Columns["RUBRO_IVA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_IVA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_PROVEEDOR_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAS_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ID_DESTINO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECIO_BRUTO_UNITARIO_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO_DESCONTADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_PAGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEVUELTA_NOTA_CREDITO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ID_ORIGEN", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIG", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO_BRUTO_UNITARIO_ORIG", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_DETALLE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUBRO_IVA_ID", typeof(decimal));
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

				case "FACTURAS_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_BRUTO_UNITARIO_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO_DESCONTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEVUELTA_NOTA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_BRUTO_UNITARIO_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROVEEDOR_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_IVA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_PROVEEDOR_DETALLECollection_Base class
}  // End of namespace
