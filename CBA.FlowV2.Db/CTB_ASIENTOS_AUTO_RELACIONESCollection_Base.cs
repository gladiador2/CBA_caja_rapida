// <fileinfo name="CTB_ASIENTOS_AUTO_RELACIONESCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_RELACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTO_RELACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_RELACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_AUTO_DET_IDColumnName = "CTB_ASIENTO_AUTO_DET_ID";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string INVERTIR_DEBE_Y_HABERColumnName = "INVERTIR_DEBE_Y_HABER";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string STOCK_DEPOSITO_IDColumnName = "STOCK_DEPOSITO_ID";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CTACTE_CAJA_TESO_IDColumnName = "CTACTE_CAJA_TESO_ID";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string ARTICULO_USADOColumnName = "ARTICULO_USADO";
		public const string ARTICULO_DANHADOColumnName = "ARTICULO_DANHADO";
		public const string CTACTE_CHEQUE_ESTADO_IDColumnName = "CTACTE_CHEQUE_ESTADO_ID";
		public const string TIPO_NOTAS_CREDITO_IDColumnName = "TIPO_NOTAS_CREDITO_ID";
		public const string TIPO_CLIENTE_IDColumnName = "TIPO_CLIENTE_ID";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string TIPO_ORDEN_PAGO_IDColumnName = "TIPO_ORDEN_PAGO_ID";
		public const string INVERTIR_SI_ES_NEGATIVOColumnName = "INVERTIR_SI_ES_NEGATIVO";
		public const string DESCUENTO_IDColumnName = "DESCUENTO_ID";
		public const string BONIFICACION_IDColumnName = "BONIFICACION_ID";
		public const string EXCLUSIONESColumnName = "EXCLUSIONES";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string INCLUSIONESColumnName = "INCLUSIONES";
		public const string CREAR_ASIENTOColumnName = "CREAR_ASIENTO";
		public const string PERSONA_RELACIONADA_IDColumnName = "PERSONA_RELACIONADA_ID";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string ACTIVO_RUBRO_IDColumnName = "ACTIVO_RUBRO_ID";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string PROVEEDOR_RELACIONADO_IDColumnName = "PROVEEDOR_RELACIONADO_ID";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_RELACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTO_RELACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTO_RELACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTO_RELACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOS_AUTO_RELACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_AS_AUTO_REL_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_auto_det_id">The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTB_ASIENTO_AUTO_DET_ID(decimal ctb_asiento_auto_det_id)
		{
			return MapRecords(CreateGetByCTB_ASIENTO_AUTO_DET_IDCommand(ctb_asiento_auto_det_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_AS_AUTO_REL_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_auto_det_id">The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_ASIENTO_AUTO_DET_IDAsDataTable(decimal ctb_asiento_auto_det_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_ASIENTO_AUTO_DET_IDCommand(ctb_asiento_auto_det_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_AS_AUTO_REL_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_auto_det_id">The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_ASIENTO_AUTO_DET_IDCommand(decimal ctb_asiento_auto_det_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_AUTO_DET_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_ASIENTO_AUTO_DET_ID", ctb_asiento_auto_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_IDAsDataTable(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
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
		/// return records by the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByACTIVO_RUBRO_ID(decimal activo_rubro_id)
		{
			return GetByACTIVO_RUBRO_ID(activo_rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <param name="activo_rubro_idNull">true if the method ignores the activo_rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByACTIVO_RUBRO_ID(decimal activo_rubro_id, bool activo_rubro_idNull)
		{
			return MapRecords(CreateGetByACTIVO_RUBRO_IDCommand(activo_rubro_id, activo_rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_RUBRO_IDAsDataTable(decimal activo_rubro_id)
		{
			return GetByACTIVO_RUBRO_IDAsDataTable(activo_rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <param name="activo_rubro_idNull">true if the method ignores the activo_rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_RUBRO_IDAsDataTable(decimal activo_rubro_id, bool activo_rubro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_RUBRO_IDCommand(activo_rubro_id, activo_rubro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <param name="activo_rubro_idNull">true if the method ignores the activo_rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_RUBRO_IDCommand(decimal activo_rubro_id, bool activo_rubro_idNull)
		{
			string whereSql = "";
			if(activo_rubro_idNull)
				whereSql += "ACTIVO_RUBRO_ID IS NULL";
			else
				whereSql += "ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_rubro_idNull)
				AddParameter(cmd, "ACTIVO_RUBRO_ID", activo_rubro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_FAMILIA_ID(decimal articulo_familia_id)
		{
			return GetByARTICULO_FAMILIA_ID(articulo_familia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <param name="articulo_familia_idNull">true if the method ignores the articulo_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_FAMILIA_ID(decimal articulo_familia_id, bool articulo_familia_idNull)
		{
			return MapRecords(CreateGetByARTICULO_FAMILIA_IDCommand(articulo_familia_id, articulo_familia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_FAMILIA_IDAsDataTable(decimal articulo_familia_id)
		{
			return GetByARTICULO_FAMILIA_IDAsDataTable(articulo_familia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <param name="articulo_familia_idNull">true if the method ignores the articulo_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_FAMILIA_IDAsDataTable(decimal articulo_familia_id, bool articulo_familia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_FAMILIA_IDCommand(articulo_familia_id, articulo_familia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <param name="articulo_familia_idNull">true if the method ignores the articulo_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_FAMILIA_IDCommand(decimal articulo_familia_id, bool articulo_familia_idNull)
		{
			string whereSql = "";
			if(articulo_familia_idNull)
				whereSql += "ARTICULO_FAMILIA_ID IS NULL";
			else
				whereSql += "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_familia_idNull)
				AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_GRUPO_ID(decimal articulo_grupo_id)
		{
			return GetByARTICULO_GRUPO_ID(articulo_grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <param name="articulo_grupo_idNull">true if the method ignores the articulo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_GRUPO_ID(decimal articulo_grupo_id, bool articulo_grupo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_GRUPO_IDCommand(articulo_grupo_id, articulo_grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_GRUPO_IDAsDataTable(decimal articulo_grupo_id)
		{
			return GetByARTICULO_GRUPO_IDAsDataTable(articulo_grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <param name="articulo_grupo_idNull">true if the method ignores the articulo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_GRUPO_IDAsDataTable(decimal articulo_grupo_id, bool articulo_grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_GRUPO_IDCommand(articulo_grupo_id, articulo_grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <param name="articulo_grupo_idNull">true if the method ignores the articulo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_GRUPO_IDCommand(decimal articulo_grupo_id, bool articulo_grupo_idNull)
		{
			string whereSql = "";
			if(articulo_grupo_idNull)
				whereSql += "ARTICULO_GRUPO_ID IS NULL";
			else
				whereSql += "ARTICULO_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_grupo_idNull)
				AddParameter(cmd, "ARTICULO_GRUPO_ID", articulo_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_SUBGRUPO_ID(decimal articulo_subgrupo_id)
		{
			return GetByARTICULO_SUBGRUPO_ID(articulo_subgrupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <param name="articulo_subgrupo_idNull">true if the method ignores the articulo_subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByARTICULO_SUBGRUPO_ID(decimal articulo_subgrupo_id, bool articulo_subgrupo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_SUBGRUPO_IDCommand(articulo_subgrupo_id, articulo_subgrupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_SUBGRUPO_IDAsDataTable(decimal articulo_subgrupo_id)
		{
			return GetByARTICULO_SUBGRUPO_IDAsDataTable(articulo_subgrupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <param name="articulo_subgrupo_idNull">true if the method ignores the articulo_subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_SUBGRUPO_IDAsDataTable(decimal articulo_subgrupo_id, bool articulo_subgrupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_SUBGRUPO_IDCommand(articulo_subgrupo_id, articulo_subgrupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <param name="articulo_subgrupo_idNull">true if the method ignores the articulo_subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_SUBGRUPO_IDCommand(decimal articulo_subgrupo_id, bool articulo_subgrupo_idNull)
		{
			string whereSql = "";
			if(articulo_subgrupo_idNull)
				whereSql += "ARTICULO_SUBGRUPO_ID IS NULL";
			else
				whereSql += "ARTICULO_SUBGRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_SUBGRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_subgrupo_idNull)
				AddParameter(cmd, "ARTICULO_SUBGRUPO_ID", articulo_subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByBONIFICACION_ID(decimal bonificacion_id)
		{
			return GetByBONIFICACION_ID(bonificacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <param name="bonificacion_idNull">true if the method ignores the bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByBONIFICACION_ID(decimal bonificacion_id, bool bonificacion_idNull)
		{
			return MapRecords(CreateGetByBONIFICACION_IDCommand(bonificacion_id, bonificacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBONIFICACION_IDAsDataTable(decimal bonificacion_id)
		{
			return GetByBONIFICACION_IDAsDataTable(bonificacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <param name="bonificacion_idNull">true if the method ignores the bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBONIFICACION_IDAsDataTable(decimal bonificacion_id, bool bonificacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBONIFICACION_IDCommand(bonificacion_id, bonificacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <param name="bonificacion_idNull">true if the method ignores the bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBONIFICACION_IDCommand(decimal bonificacion_id, bool bonificacion_idNull)
		{
			string whereSql = "";
			if(bonificacion_idNull)
				whereSql += "BONIFICACION_ID IS NULL";
			else
				whereSql += "BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!bonificacion_idNull)
				AddParameter(cmd, "BONIFICACION_ID", bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_CAJA_TESO_ID(decimal ctacte_caja_teso_id)
		{
			return GetByCTACTE_CAJA_TESO_ID(ctacte_caja_teso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_idNull">true if the method ignores the ctacte_caja_teso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_CAJA_TESO_ID(decimal ctacte_caja_teso_id, bool ctacte_caja_teso_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESO_IDCommand(ctacte_caja_teso_id, ctacte_caja_teso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESO_IDAsDataTable(decimal ctacte_caja_teso_id)
		{
			return GetByCTACTE_CAJA_TESO_IDAsDataTable(ctacte_caja_teso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_idNull">true if the method ignores the ctacte_caja_teso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESO_IDAsDataTable(decimal ctacte_caja_teso_id, bool ctacte_caja_teso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESO_IDCommand(ctacte_caja_teso_id, ctacte_caja_teso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_idNull">true if the method ignores the ctacte_caja_teso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESO_IDCommand(decimal ctacte_caja_teso_id, bool ctacte_caja_teso_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_idNull)
				whereSql += "CTACTE_CAJA_TESO_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_teso_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_ID", ctacte_caja_teso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return GetByCTACTE_BANCARIA_ID(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id)
		{
			return GetByCTACTE_BANCARIA_IDAsDataTable(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_idNull)
				whereSql += "CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_bancaria_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_CHEQUE_ESTADO_ID(decimal ctacte_cheque_estado_id)
		{
			return GetByCTACTE_CHEQUE_ESTADO_ID(ctacte_cheque_estado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_estado_idNull">true if the method ignores the ctacte_cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_CHEQUE_ESTADO_ID(decimal ctacte_cheque_estado_id, bool ctacte_cheque_estado_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_ESTADO_IDCommand(ctacte_cheque_estado_id, ctacte_cheque_estado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_ESTADO_IDAsDataTable(decimal ctacte_cheque_estado_id)
		{
			return GetByCTACTE_CHEQUE_ESTADO_IDAsDataTable(ctacte_cheque_estado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_estado_idNull">true if the method ignores the ctacte_cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_ESTADO_IDAsDataTable(decimal ctacte_cheque_estado_id, bool ctacte_cheque_estado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_ESTADO_IDCommand(ctacte_cheque_estado_id, ctacte_cheque_estado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_estado_idNull">true if the method ignores the ctacte_cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_ESTADO_IDCommand(decimal ctacte_cheque_estado_id, bool ctacte_cheque_estado_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_estado_idNull)
				whereSql += "CTACTE_CHEQUE_ESTADO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_cheque_estado_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_ESTADO_ID", ctacte_cheque_estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetBySTOCK_DEPOSITO_ID(decimal stock_deposito_id)
		{
			return GetBySTOCK_DEPOSITO_ID(stock_deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <param name="stock_deposito_idNull">true if the method ignores the stock_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetBySTOCK_DEPOSITO_ID(decimal stock_deposito_id, bool stock_deposito_idNull)
		{
			return MapRecords(CreateGetBySTOCK_DEPOSITO_IDCommand(stock_deposito_id, stock_deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySTOCK_DEPOSITO_IDAsDataTable(decimal stock_deposito_id)
		{
			return GetBySTOCK_DEPOSITO_IDAsDataTable(stock_deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <param name="stock_deposito_idNull">true if the method ignores the stock_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySTOCK_DEPOSITO_IDAsDataTable(decimal stock_deposito_id, bool stock_deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySTOCK_DEPOSITO_IDCommand(stock_deposito_id, stock_deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <param name="stock_deposito_idNull">true if the method ignores the stock_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySTOCK_DEPOSITO_IDCommand(decimal stock_deposito_id, bool stock_deposito_idNull)
		{
			string whereSql = "";
			if(stock_deposito_idNull)
				whereSql += "STOCK_DEPOSITO_ID IS NULL";
			else
				whereSql += "STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!stock_deposito_idNull)
				AddParameter(cmd, "STOCK_DEPOSITO_ID", stock_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByDESCUENTO_ID(decimal descuento_id)
		{
			return GetByDESCUENTO_ID(descuento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <param name="descuento_idNull">true if the method ignores the descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByDESCUENTO_ID(decimal descuento_id, bool descuento_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_IDCommand(descuento_id, descuento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_IDAsDataTable(decimal descuento_id)
		{
			return GetByDESCUENTO_IDAsDataTable(descuento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <param name="descuento_idNull">true if the method ignores the descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_IDAsDataTable(decimal descuento_id, bool descuento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_IDCommand(descuento_id, descuento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <param name="descuento_idNull">true if the method ignores the descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_IDCommand(decimal descuento_id, bool descuento_idNull)
		{
			string whereSql = "";
			if(descuento_idNull)
				whereSql += "DESCUENTO_ID IS NULL";
			else
				whereSql += "DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_idNull)
				AddParameter(cmd, "DESCUENTO_ID", descuento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_IDAsDataTable(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return GetByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return GetByIMPUESTO_IDAsDataTable(impuesto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return MapRecords(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PLAN_CUENTA_IDAsDataTable(decimal ctb_plan_cuenta_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id)
		{
			return GetByPROVEEDOR_RELACIONADO_ID(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <param name="proveedor_relacionado_idNull">true if the method ignores the proveedor_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id, bool proveedor_relacionado_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_RELACIONADO_IDCommand(proveedor_relacionado_id, proveedor_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_RELACIONADO_IDAsDataTable(decimal proveedor_relacionado_id)
		{
			return GetByPROVEEDOR_RELACIONADO_IDAsDataTable(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREGION_IDAsDataTable(decimal region_id, bool region_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByRUBRO_ID(decimal rubro_id)
		{
			return GetByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id)
		{
			return GetByRUBRO_IDAsDataTable(rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_CLIENTE_ID(decimal tipo_cliente_id)
		{
			return GetByTIPO_CLIENTE_ID(tipo_cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_CLIENTE_ID(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return MapRecords(CreateGetByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CLIENTE_IDAsDataTable(decimal tipo_cliente_id)
		{
			return GetByTIPO_CLIENTE_IDAsDataTable(tipo_cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CLIENTE_IDAsDataTable(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CLIENTE_IDCommand(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			string whereSql = "";
			if(tipo_cliente_idNull)
				whereSql += "TIPO_CLIENTE_ID IS NULL";
			else
				whereSql += "TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_cliente_idNull)
				AddParameter(cmd, "TIPO_CLIENTE_ID", tipo_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_NOTAS_CREDITO_ID(decimal tipo_notas_credito_id)
		{
			return GetByTIPO_NOTAS_CREDITO_ID(tipo_notas_credito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <param name="tipo_notas_credito_idNull">true if the method ignores the tipo_notas_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_NOTAS_CREDITO_ID(decimal tipo_notas_credito_id, bool tipo_notas_credito_idNull)
		{
			return MapRecords(CreateGetByTIPO_NOTAS_CREDITO_IDCommand(tipo_notas_credito_id, tipo_notas_credito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_NOTAS_CREDITO_IDAsDataTable(decimal tipo_notas_credito_id)
		{
			return GetByTIPO_NOTAS_CREDITO_IDAsDataTable(tipo_notas_credito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <param name="tipo_notas_credito_idNull">true if the method ignores the tipo_notas_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_NOTAS_CREDITO_IDAsDataTable(decimal tipo_notas_credito_id, bool tipo_notas_credito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_NOTAS_CREDITO_IDCommand(tipo_notas_credito_id, tipo_notas_credito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <param name="tipo_notas_credito_idNull">true if the method ignores the tipo_notas_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_NOTAS_CREDITO_IDCommand(decimal tipo_notas_credito_id, bool tipo_notas_credito_idNull)
		{
			string whereSql = "";
			if(tipo_notas_credito_idNull)
				whereSql += "TIPO_NOTAS_CREDITO_ID IS NULL";
			else
				whereSql += "TIPO_NOTAS_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_NOTAS_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_notas_credito_idNull)
				AddParameter(cmd, "TIPO_NOTAS_CREDITO_ID", tipo_notas_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_ORDEN_PAGO_ID(decimal tipo_orden_pago_id)
		{
			return GetByTIPO_ORDEN_PAGO_ID(tipo_orden_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="tipo_orden_pago_idNull">true if the method ignores the tipo_orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTIPO_ORDEN_PAGO_ID(decimal tipo_orden_pago_id, bool tipo_orden_pago_idNull)
		{
			return MapRecords(CreateGetByTIPO_ORDEN_PAGO_IDCommand(tipo_orden_pago_id, tipo_orden_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_ORDEN_PAGO_IDAsDataTable(decimal tipo_orden_pago_id)
		{
			return GetByTIPO_ORDEN_PAGO_IDAsDataTable(tipo_orden_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="tipo_orden_pago_idNull">true if the method ignores the tipo_orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_ORDEN_PAGO_IDAsDataTable(decimal tipo_orden_pago_id, bool tipo_orden_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_ORDEN_PAGO_IDCommand(tipo_orden_pago_id, tipo_orden_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="tipo_orden_pago_idNull">true if the method ignores the tipo_orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_ORDEN_PAGO_IDCommand(decimal tipo_orden_pago_id, bool tipo_orden_pago_idNull)
		{
			string whereSql = "";
			if(tipo_orden_pago_idNull)
				whereSql += "TIPO_ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "TIPO_ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("TIPO_ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_orden_pago_idNull)
				AddParameter(cmd, "TIPO_ORDEN_PAGO_ID", tipo_orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return GetByCTB_CUENTA_ID(ctb_cuenta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <param name="ctb_cuenta_idNull">true if the method ignores the ctb_cuenta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByCTB_CUENTA_ID(decimal ctb_cuenta_id, bool ctb_cuenta_idNull)
		{
			return MapRecords(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id, ctb_cuenta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_CUENTA_IDAsDataTable(decimal ctb_cuenta_id)
		{
			return GetByCTB_CUENTA_IDAsDataTable(ctb_cuenta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <param name="ctb_cuenta_idNull">true if the method ignores the ctb_cuenta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTA_IDAsDataTable(decimal ctb_cuenta_id, bool ctb_cuenta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id, ctb_cuenta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <param name="ctb_cuenta_idNull">true if the method ignores the ctb_cuenta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id, bool ctb_cuenta_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_idNull)
				whereSql += "CTB_CUENTA_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_cuenta_idNull)
				AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id)
		{
			return GetByPERSONA_RELACIONADA_ID(persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects 
		/// by the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] GetByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return MapRecords(CreateGetByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_RELACIONADA_IDAsDataTable(decimal persona_relacionada_id)
		{
			return GetByPERSONA_RELACIONADA_IDAsDataTable(persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_RELACIONADA_IDAsDataTable(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_RELACIONADA_IDCommand(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			string whereSql = "";
			if(persona_relacionada_idNull)
				whereSql += "PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_relacionada_idNull)
				AddParameter(cmd, "PERSONA_RELACIONADA_ID", persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOS_AUTO_RELACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS_AUTO_RELACIONES (" +
				"ID, " +
				"CTB_ASIENTO_AUTO_DET_ID, " +
				"CTB_CUENTA_ID, " +
				"INVERTIR_DEBE_Y_HABER, " +
				"MONEDA_ID, " +
				"SUCURSAL_ID, " +
				"CTACTE_VALOR_ID, " +
				"STOCK_DEPOSITO_ID, " +
				"CTACTE_BANCARIA_ID, " +
				"PROVEEDOR_ID, " +
				"PERSONA_ID, " +
				"FUNCIONARIO_ID, " +
				"ARTICULO_FAMILIA_ID, " +
				"ARTICULO_GRUPO_ID, " +
				"ARTICULO_SUBGRUPO_ID, " +
				"ARTICULO_ID, " +
				"RUBRO_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"CTACTE_CAJA_TESO_ID, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"ARTICULO_USADO, " +
				"ARTICULO_DANHADO, " +
				"CTACTE_CHEQUE_ESTADO_ID, " +
				"TIPO_NOTAS_CREDITO_ID, " +
				"TIPO_CLIENTE_ID, " +
				"REGION_ID, " +
				"TIPO_ORDEN_PAGO_ID, " +
				"INVERTIR_SI_ES_NEGATIVO, " +
				"DESCUENTO_ID, " +
				"BONIFICACION_ID, " +
				"EXCLUSIONES, " +
				"CTB_PLAN_CUENTA_ID, " +
				"INCLUSIONES, " +
				"CREAR_ASIENTO, " +
				"PERSONA_RELACIONADA_ID, " +
				"CANAL_VENTA_ID, " +
				"ACTIVO_RUBRO_ID, " +
				"IMPUESTO_ID, " +
				"PROVEEDOR_RELACIONADO_ID, " +
				"CTACTE_PROCESADORA_TARJETA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_ASIENTO_AUTO_DET_ID") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("INVERTIR_DEBE_Y_HABER") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("STOCK_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_SUBGRUPO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_USADO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_DANHADO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_NOTAS_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("INVERTIR_SI_ES_NEGATIVO") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_ID") + ", " +
				_db.CreateSqlParameterName("BONIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("EXCLUSIONES") + ", " +
				_db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("INCLUSIONES") + ", " +
				_db.CreateSqlParameterName("CREAR_ASIENTO") + ", " +
				_db.CreateSqlParameterName("PERSONA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_ASIENTO_AUTO_DET_ID", value.CTB_ASIENTO_AUTO_DET_ID);
			AddParameter(cmd, "CTB_CUENTA_ID",
				value.IsCTB_CUENTA_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_ID);
			AddParameter(cmd, "INVERTIR_DEBE_Y_HABER", value.INVERTIR_DEBE_Y_HABER);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "STOCK_DEPOSITO_ID",
				value.IsSTOCK_DEPOSITO_IDNull ? DBNull.Value : (object)value.STOCK_DEPOSITO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ID",
				value.IsCTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID",
				value.IsARTICULO_FAMILIA_IDNull ? DBNull.Value : (object)value.ARTICULO_FAMILIA_ID);
			AddParameter(cmd, "ARTICULO_GRUPO_ID",
				value.IsARTICULO_GRUPO_IDNull ? DBNull.Value : (object)value.ARTICULO_GRUPO_ID);
			AddParameter(cmd, "ARTICULO_SUBGRUPO_ID",
				value.IsARTICULO_SUBGRUPO_IDNull ? DBNull.Value : (object)value.ARTICULO_SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_ID",
				value.IsCTACTE_CAJA_TESO_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "ARTICULO_USADO", value.ARTICULO_USADO);
			AddParameter(cmd, "ARTICULO_DANHADO", value.ARTICULO_DANHADO);
			AddParameter(cmd, "CTACTE_CHEQUE_ESTADO_ID",
				value.IsCTACTE_CHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_ESTADO_ID);
			AddParameter(cmd, "TIPO_NOTAS_CREDITO_ID",
				value.IsTIPO_NOTAS_CREDITO_IDNull ? DBNull.Value : (object)value.TIPO_NOTAS_CREDITO_ID);
			AddParameter(cmd, "TIPO_CLIENTE_ID",
				value.IsTIPO_CLIENTE_IDNull ? DBNull.Value : (object)value.TIPO_CLIENTE_ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "TIPO_ORDEN_PAGO_ID",
				value.IsTIPO_ORDEN_PAGO_IDNull ? DBNull.Value : (object)value.TIPO_ORDEN_PAGO_ID);
			AddParameter(cmd, "INVERTIR_SI_ES_NEGATIVO", value.INVERTIR_SI_ES_NEGATIVO);
			AddParameter(cmd, "DESCUENTO_ID",
				value.IsDESCUENTO_IDNull ? DBNull.Value : (object)value.DESCUENTO_ID);
			AddParameter(cmd, "BONIFICACION_ID",
				value.IsBONIFICACION_IDNull ? DBNull.Value : (object)value.BONIFICACION_ID);
			AddParameter(cmd, "EXCLUSIONES", value.EXCLUSIONES);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "INCLUSIONES", value.INCLUSIONES);
			AddParameter(cmd, "CREAR_ASIENTO", value.CREAR_ASIENTO);
			AddParameter(cmd, "PERSONA_RELACIONADA_ID",
				value.IsPERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "ACTIVO_RUBRO_ID",
				value.IsACTIVO_RUBRO_IDNull ? DBNull.Value : (object)value.ACTIVO_RUBRO_ID);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID",
				value.IsPROVEEDOR_RELACIONADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_RELACIONADO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOS_AUTO_RELACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS_AUTO_RELACIONES SET " +
				"CTB_ASIENTO_AUTO_DET_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTO_DET_ID") + ", " +
				"CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				"INVERTIR_DEBE_Y_HABER=" + _db.CreateSqlParameterName("INVERTIR_DEBE_Y_HABER") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID") + ", " +
				"CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID") + ", " +
				"ARTICULO_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_GRUPO_ID") + ", " +
				"ARTICULO_SUBGRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_SUBGRUPO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"CTACTE_CAJA_TESO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ID") + ", " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"ARTICULO_USADO=" + _db.CreateSqlParameterName("ARTICULO_USADO") + ", " +
				"ARTICULO_DANHADO=" + _db.CreateSqlParameterName("ARTICULO_DANHADO") + ", " +
				"CTACTE_CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_ESTADO_ID") + ", " +
				"TIPO_NOTAS_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_NOTAS_CREDITO_ID") + ", " +
				"TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID") + ", " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"TIPO_ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("TIPO_ORDEN_PAGO_ID") + ", " +
				"INVERTIR_SI_ES_NEGATIVO=" + _db.CreateSqlParameterName("INVERTIR_SI_ES_NEGATIVO") + ", " +
				"DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID") + ", " +
				"BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID") + ", " +
				"EXCLUSIONES=" + _db.CreateSqlParameterName("EXCLUSIONES") + ", " +
				"CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				"INCLUSIONES=" + _db.CreateSqlParameterName("INCLUSIONES") + ", " +
				"CREAR_ASIENTO=" + _db.CreateSqlParameterName("CREAR_ASIENTO") + ", " +
				"PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				"ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"PROVEEDOR_RELACIONADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_RELACIONADO_ID") + ", " +
				"CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_ASIENTO_AUTO_DET_ID", value.CTB_ASIENTO_AUTO_DET_ID);
			AddParameter(cmd, "CTB_CUENTA_ID",
				value.IsCTB_CUENTA_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_ID);
			AddParameter(cmd, "INVERTIR_DEBE_Y_HABER", value.INVERTIR_DEBE_Y_HABER);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "STOCK_DEPOSITO_ID",
				value.IsSTOCK_DEPOSITO_IDNull ? DBNull.Value : (object)value.STOCK_DEPOSITO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ID",
				value.IsCTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID",
				value.IsARTICULO_FAMILIA_IDNull ? DBNull.Value : (object)value.ARTICULO_FAMILIA_ID);
			AddParameter(cmd, "ARTICULO_GRUPO_ID",
				value.IsARTICULO_GRUPO_IDNull ? DBNull.Value : (object)value.ARTICULO_GRUPO_ID);
			AddParameter(cmd, "ARTICULO_SUBGRUPO_ID",
				value.IsARTICULO_SUBGRUPO_IDNull ? DBNull.Value : (object)value.ARTICULO_SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_ID",
				value.IsCTACTE_CAJA_TESO_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "ARTICULO_USADO", value.ARTICULO_USADO);
			AddParameter(cmd, "ARTICULO_DANHADO", value.ARTICULO_DANHADO);
			AddParameter(cmd, "CTACTE_CHEQUE_ESTADO_ID",
				value.IsCTACTE_CHEQUE_ESTADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_ESTADO_ID);
			AddParameter(cmd, "TIPO_NOTAS_CREDITO_ID",
				value.IsTIPO_NOTAS_CREDITO_IDNull ? DBNull.Value : (object)value.TIPO_NOTAS_CREDITO_ID);
			AddParameter(cmd, "TIPO_CLIENTE_ID",
				value.IsTIPO_CLIENTE_IDNull ? DBNull.Value : (object)value.TIPO_CLIENTE_ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "TIPO_ORDEN_PAGO_ID",
				value.IsTIPO_ORDEN_PAGO_IDNull ? DBNull.Value : (object)value.TIPO_ORDEN_PAGO_ID);
			AddParameter(cmd, "INVERTIR_SI_ES_NEGATIVO", value.INVERTIR_SI_ES_NEGATIVO);
			AddParameter(cmd, "DESCUENTO_ID",
				value.IsDESCUENTO_IDNull ? DBNull.Value : (object)value.DESCUENTO_ID);
			AddParameter(cmd, "BONIFICACION_ID",
				value.IsBONIFICACION_IDNull ? DBNull.Value : (object)value.BONIFICACION_ID);
			AddParameter(cmd, "EXCLUSIONES", value.EXCLUSIONES);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "INCLUSIONES", value.INCLUSIONES);
			AddParameter(cmd, "CREAR_ASIENTO", value.CREAR_ASIENTO);
			AddParameter(cmd, "PERSONA_RELACIONADA_ID",
				value.IsPERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "ACTIVO_RUBRO_ID",
				value.IsACTIVO_RUBRO_IDNull ? DBNull.Value : (object)value.ACTIVO_RUBRO_ID);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PROVEEDOR_RELACIONADO_ID",
				value.IsPROVEEDOR_RELACIONADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_RELACIONADO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOS_AUTO_RELACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_AS_AUTO_REL_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_auto_det_id">The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_ASIENTO_AUTO_DET_ID(decimal ctb_asiento_auto_det_id)
		{
			return CreateDeleteByCTB_ASIENTO_AUTO_DET_IDCommand(ctb_asiento_auto_det_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_AS_AUTO_REL_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_auto_det_id">The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_ASIENTO_AUTO_DET_IDCommand(decimal ctb_asiento_auto_det_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_AUTO_DET_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_ASIENTO_AUTO_DET_ID", ctb_asiento_auto_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return DeleteByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
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
		/// delete records using the <c>FK_CTB_AS_AUTO_REL_VALOR</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_RUBRO_ID(decimal activo_rubro_id)
		{
			return DeleteByACTIVO_RUBRO_ID(activo_rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <param name="activo_rubro_idNull">true if the method ignores the activo_rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_RUBRO_ID(decimal activo_rubro_id, bool activo_rubro_idNull)
		{
			return CreateDeleteByACTIVO_RUBRO_IDCommand(activo_rubro_id, activo_rubro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_ACT_R</c> foreign key.
		/// </summary>
		/// <param name="activo_rubro_id">The <c>ACTIVO_RUBRO_ID</c> column value.</param>
		/// <param name="activo_rubro_idNull">true if the method ignores the activo_rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_RUBRO_IDCommand(decimal activo_rubro_id, bool activo_rubro_idNull)
		{
			string whereSql = "";
			if(activo_rubro_idNull)
				whereSql += "ACTIVO_RUBRO_ID IS NULL";
			else
				whereSql += "ACTIVO_RUBRO_ID=" + _db.CreateSqlParameterName("ACTIVO_RUBRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_rubro_idNull)
				AddParameter(cmd, "ACTIVO_RUBRO_ID", activo_rubro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_ART</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_FAMILIA_ID(decimal articulo_familia_id)
		{
			return DeleteByARTICULO_FAMILIA_ID(articulo_familia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <param name="articulo_familia_idNull">true if the method ignores the articulo_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_FAMILIA_ID(decimal articulo_familia_id, bool articulo_familia_idNull)
		{
			return CreateDeleteByARTICULO_FAMILIA_IDCommand(articulo_familia_id, articulo_familia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_ARTF</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <param name="articulo_familia_idNull">true if the method ignores the articulo_familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_FAMILIA_IDCommand(decimal articulo_familia_id, bool articulo_familia_idNull)
		{
			string whereSql = "";
			if(articulo_familia_idNull)
				whereSql += "ARTICULO_FAMILIA_ID IS NULL";
			else
				whereSql += "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_familia_idNull)
				AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_GRUPO_ID(decimal articulo_grupo_id)
		{
			return DeleteByARTICULO_GRUPO_ID(articulo_grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <param name="articulo_grupo_idNull">true if the method ignores the articulo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_GRUPO_ID(decimal articulo_grupo_id, bool articulo_grupo_idNull)
		{
			return CreateDeleteByARTICULO_GRUPO_IDCommand(articulo_grupo_id, articulo_grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_ARTG</c> foreign key.
		/// </summary>
		/// <param name="articulo_grupo_id">The <c>ARTICULO_GRUPO_ID</c> column value.</param>
		/// <param name="articulo_grupo_idNull">true if the method ignores the articulo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_GRUPO_IDCommand(decimal articulo_grupo_id, bool articulo_grupo_idNull)
		{
			string whereSql = "";
			if(articulo_grupo_idNull)
				whereSql += "ARTICULO_GRUPO_ID IS NULL";
			else
				whereSql += "ARTICULO_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_grupo_idNull)
				AddParameter(cmd, "ARTICULO_GRUPO_ID", articulo_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_SUBGRUPO_ID(decimal articulo_subgrupo_id)
		{
			return DeleteByARTICULO_SUBGRUPO_ID(articulo_subgrupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <param name="articulo_subgrupo_idNull">true if the method ignores the articulo_subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_SUBGRUPO_ID(decimal articulo_subgrupo_id, bool articulo_subgrupo_idNull)
		{
			return CreateDeleteByARTICULO_SUBGRUPO_IDCommand(articulo_subgrupo_id, articulo_subgrupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_ARTS</c> foreign key.
		/// </summary>
		/// <param name="articulo_subgrupo_id">The <c>ARTICULO_SUBGRUPO_ID</c> column value.</param>
		/// <param name="articulo_subgrupo_idNull">true if the method ignores the articulo_subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_SUBGRUPO_IDCommand(decimal articulo_subgrupo_id, bool articulo_subgrupo_idNull)
		{
			string whereSql = "";
			if(articulo_subgrupo_idNull)
				whereSql += "ARTICULO_SUBGRUPO_ID IS NULL";
			else
				whereSql += "ARTICULO_SUBGRUPO_ID=" + _db.CreateSqlParameterName("ARTICULO_SUBGRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_subgrupo_idNull)
				AddParameter(cmd, "ARTICULO_SUBGRUPO_ID", articulo_subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBONIFICACION_ID(decimal bonificacion_id)
		{
			return DeleteByBONIFICACION_ID(bonificacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <param name="bonificacion_idNull">true if the method ignores the bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBONIFICACION_ID(decimal bonificacion_id, bool bonificacion_idNull)
		{
			return CreateDeleteByBONIFICACION_IDCommand(bonificacion_id, bonificacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_BONIFI</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <param name="bonificacion_idNull">true if the method ignores the bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBONIFICACION_IDCommand(decimal bonificacion_id, bool bonificacion_idNull)
		{
			string whereSql = "";
			if(bonificacion_idNull)
				whereSql += "BONIFICACION_ID IS NULL";
			else
				whereSql += "BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!bonificacion_idNull)
				AddParameter(cmd, "BONIFICACION_ID", bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_ID(decimal ctacte_caja_teso_id)
		{
			return DeleteByCTACTE_CAJA_TESO_ID(ctacte_caja_teso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_idNull">true if the method ignores the ctacte_caja_teso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_ID(decimal ctacte_caja_teso_id, bool ctacte_caja_teso_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESO_IDCommand(ctacte_caja_teso_id, ctacte_caja_teso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_CAJA_T</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_id">The <c>CTACTE_CAJA_TESO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_idNull">true if the method ignores the ctacte_caja_teso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESO_IDCommand(decimal ctacte_caja_teso_id, bool ctacte_caja_teso_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_idNull)
				whereSql += "CTACTE_CAJA_TESO_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_teso_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_ID", ctacte_caja_teso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return DeleteByCTACTE_BANCARIA_ID(ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			return CreateDeleteByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id, ctacte_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_CBANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_idNull">true if the method ignores the ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id, bool ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_idNull)
				whereSql += "CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_bancaria_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_ESTADO_ID(decimal ctacte_cheque_estado_id)
		{
			return DeleteByCTACTE_CHEQUE_ESTADO_ID(ctacte_cheque_estado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_estado_idNull">true if the method ignores the ctacte_cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_ESTADO_ID(decimal ctacte_cheque_estado_id, bool ctacte_cheque_estado_idNull)
		{
			return CreateDeleteByCTACTE_CHEQUE_ESTADO_IDCommand(ctacte_cheque_estado_id, ctacte_cheque_estado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_CH_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_estado_id">The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_estado_idNull">true if the method ignores the ctacte_cheque_estado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_ESTADO_IDCommand(decimal ctacte_cheque_estado_id, bool ctacte_cheque_estado_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_estado_idNull)
				whereSql += "CTACTE_CHEQUE_ESTADO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_cheque_estado_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_ESTADO_ID", ctacte_cheque_estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_DEPOSITO_ID(decimal stock_deposito_id)
		{
			return DeleteBySTOCK_DEPOSITO_ID(stock_deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <param name="stock_deposito_idNull">true if the method ignores the stock_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_DEPOSITO_ID(decimal stock_deposito_id, bool stock_deposito_idNull)
		{
			return CreateDeleteBySTOCK_DEPOSITO_IDCommand(stock_deposito_id, stock_deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <param name="stock_deposito_idNull">true if the method ignores the stock_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySTOCK_DEPOSITO_IDCommand(decimal stock_deposito_id, bool stock_deposito_idNull)
		{
			string whereSql = "";
			if(stock_deposito_idNull)
				whereSql += "STOCK_DEPOSITO_ID IS NULL";
			else
				whereSql += "STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!stock_deposito_idNull)
				AddParameter(cmd, "STOCK_DEPOSITO_ID", stock_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_ID(decimal descuento_id)
		{
			return DeleteByDESCUENTO_ID(descuento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <param name="descuento_idNull">true if the method ignores the descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_ID(decimal descuento_id, bool descuento_idNull)
		{
			return CreateDeleteByDESCUENTO_IDCommand(descuento_id, descuento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_DESCUE</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <param name="descuento_idNull">true if the method ignores the descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_IDCommand(decimal descuento_id, bool descuento_idNull)
		{
			string whereSql = "";
			if(descuento_idNull)
				whereSql += "DESCUENTO_ID IS NULL";
			else
				whereSql += "DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_idNull)
				AddParameter(cmd, "DESCUENTO_ID", descuento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_FF</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return DeleteByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_IMP</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_MONE</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_PERS</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return CreateDeleteByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
		/// </summary>
		/// <param name="proveedor_relacionado_id">The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_RELACIONADO_ID(decimal proveedor_relacionado_id)
		{
			return DeleteByPROVEEDOR_RELACIONADO_ID(proveedor_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_RL</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return DeleteByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_PRO_TC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_PROV</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id, bool region_idNull)
		{
			return CreateDeleteByREGION_IDCommand(region_id, region_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id)
		{
			return DeleteByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_RUB</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_SUC_ID</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CLIENTE_ID(decimal tipo_cliente_id)
		{
			return DeleteByTIPO_CLIENTE_ID(tipo_cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CLIENTE_ID(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return CreateDeleteByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_CL</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CLIENTE_IDCommand(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			string whereSql = "";
			if(tipo_cliente_idNull)
				whereSql += "TIPO_CLIENTE_ID IS NULL";
			else
				whereSql += "TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_cliente_idNull)
				AddParameter(cmd, "TIPO_CLIENTE_ID", tipo_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_NOTAS_CREDITO_ID(decimal tipo_notas_credito_id)
		{
			return DeleteByTIPO_NOTAS_CREDITO_ID(tipo_notas_credito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <param name="tipo_notas_credito_idNull">true if the method ignores the tipo_notas_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_NOTAS_CREDITO_ID(decimal tipo_notas_credito_id, bool tipo_notas_credito_idNull)
		{
			return CreateDeleteByTIPO_NOTAS_CREDITO_IDCommand(tipo_notas_credito_id, tipo_notas_credito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_TIP_NC</c> foreign key.
		/// </summary>
		/// <param name="tipo_notas_credito_id">The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</param>
		/// <param name="tipo_notas_credito_idNull">true if the method ignores the tipo_notas_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_NOTAS_CREDITO_IDCommand(decimal tipo_notas_credito_id, bool tipo_notas_credito_idNull)
		{
			string whereSql = "";
			if(tipo_notas_credito_idNull)
				whereSql += "TIPO_NOTAS_CREDITO_ID IS NULL";
			else
				whereSql += "TIPO_NOTAS_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_NOTAS_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_notas_credito_idNull)
				AddParameter(cmd, "TIPO_NOTAS_CREDITO_ID", tipo_notas_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ORDEN_PAGO_ID(decimal tipo_orden_pago_id)
		{
			return DeleteByTIPO_ORDEN_PAGO_ID(tipo_orden_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="tipo_orden_pago_idNull">true if the method ignores the tipo_orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ORDEN_PAGO_ID(decimal tipo_orden_pago_id, bool tipo_orden_pago_idNull)
		{
			return CreateDeleteByTIPO_ORDEN_PAGO_IDCommand(tipo_orden_pago_id, tipo_orden_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_TIPOOP</c> foreign key.
		/// </summary>
		/// <param name="tipo_orden_pago_id">The <c>TIPO_ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="tipo_orden_pago_idNull">true if the method ignores the tipo_orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_ORDEN_PAGO_IDCommand(decimal tipo_orden_pago_id, bool tipo_orden_pago_idNull)
		{
			string whereSql = "";
			if(tipo_orden_pago_idNull)
				whereSql += "TIPO_ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "TIPO_ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("TIPO_ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_orden_pago_idNull)
				AddParameter(cmd, "TIPO_ORDEN_PAGO_ID", tipo_orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_AUT_REL_TXT</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return CreateDeleteByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUTO_CAN_VEN</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return DeleteByCTB_CUENTA_ID(ctb_cuenta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <param name="ctb_cuenta_idNull">true if the method ignores the ctb_cuenta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_ID(decimal ctb_cuenta_id, bool ctb_cuenta_idNull)
		{
			return CreateDeleteByCTB_CUENTA_IDCommand(ctb_cuenta_id, ctb_cuenta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUTO_REL_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <param name="ctb_cuenta_idNull">true if the method ignores the ctb_cuenta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id, bool ctb_cuenta_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_idNull)
				whereSql += "CTB_CUENTA_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_cuenta_idNull)
				AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id)
		{
			return DeleteByPERSONA_RELACIONADA_ID(persona_relacionada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table using the 
		/// <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return CreateDeleteByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>KF_CTB_ASIENTOS_AUT_REL_PR_RL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_RELACIONADA_IDCommand(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			string whereSql = "";
			if(persona_relacionada_idNull)
				whereSql += "PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_relacionada_idNull)
				AddParameter(cmd, "PERSONA_RELACIONADA_ID", persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_ASIENTOS_AUTO_RELACIONES</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS_AUTO_RELACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS_AUTO_RELACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_RELACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_RELACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTO_RELACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asiento_auto_det_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTO_DET_ID");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int invertir_debe_y_haberColumnIndex = reader.GetOrdinal("INVERTIR_DEBE_Y_HABER");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int stock_deposito_idColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_ID");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int ctacte_caja_teso_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_ID");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int articulo_usadoColumnIndex = reader.GetOrdinal("ARTICULO_USADO");
			int articulo_danhadoColumnIndex = reader.GetOrdinal("ARTICULO_DANHADO");
			int ctacte_cheque_estado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_ESTADO_ID");
			int tipo_notas_credito_idColumnIndex = reader.GetOrdinal("TIPO_NOTAS_CREDITO_ID");
			int tipo_cliente_idColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_ID");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int tipo_orden_pago_idColumnIndex = reader.GetOrdinal("TIPO_ORDEN_PAGO_ID");
			int invertir_si_es_negativoColumnIndex = reader.GetOrdinal("INVERTIR_SI_ES_NEGATIVO");
			int descuento_idColumnIndex = reader.GetOrdinal("DESCUENTO_ID");
			int bonificacion_idColumnIndex = reader.GetOrdinal("BONIFICACION_ID");
			int exclusionesColumnIndex = reader.GetOrdinal("EXCLUSIONES");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int inclusionesColumnIndex = reader.GetOrdinal("INCLUSIONES");
			int crear_asientoColumnIndex = reader.GetOrdinal("CREAR_ASIENTO");
			int persona_relacionada_idColumnIndex = reader.GetOrdinal("PERSONA_RELACIONADA_ID");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int activo_rubro_idColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_ID");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int proveedor_relacionado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_RELACIONADO_ID");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_AUTO_RELACIONESRow record = new CTB_ASIENTOS_AUTO_RELACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTO_AUTO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_auto_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_idColumnIndex))
						record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					record.INVERTIR_DEBE_Y_HABER = Convert.ToString(reader.GetValue(invertir_debe_y_haberColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(stock_deposito_idColumnIndex))
						record.STOCK_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_idColumnIndex))
						record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_teso_idColumnIndex))
						record.CTACTE_CAJA_TESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_teso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_usadoColumnIndex))
						record.ARTICULO_USADO = Convert.ToString(reader.GetValue(articulo_usadoColumnIndex));
					if(!reader.IsDBNull(articulo_danhadoColumnIndex))
						record.ARTICULO_DANHADO = Convert.ToString(reader.GetValue(articulo_danhadoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_estado_idColumnIndex))
						record.CTACTE_CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_notas_credito_idColumnIndex))
						record.TIPO_NOTAS_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_notas_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_cliente_idColumnIndex))
						record.TIPO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_orden_pago_idColumnIndex))
						record.TIPO_ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_orden_pago_idColumnIndex)), 9);
					record.INVERTIR_SI_ES_NEGATIVO = Convert.ToString(reader.GetValue(invertir_si_es_negativoColumnIndex));
					if(!reader.IsDBNull(descuento_idColumnIndex))
						record.DESCUENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_idColumnIndex)), 9);
					if(!reader.IsDBNull(bonificacion_idColumnIndex))
						record.BONIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(bonificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(exclusionesColumnIndex))
						record.EXCLUSIONES = Convert.ToString(reader.GetValue(exclusionesColumnIndex));
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					if(!reader.IsDBNull(inclusionesColumnIndex))
						record.INCLUSIONES = Convert.ToString(reader.GetValue(inclusionesColumnIndex));
					record.CREAR_ASIENTO = Convert.ToString(reader.GetValue(crear_asientoColumnIndex));
					if(!reader.IsDBNull(persona_relacionada_idColumnIndex))
						record.PERSONA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_relacionada_idColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_rubro_idColumnIndex))
						record.ACTIVO_RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_relacionado_idColumnIndex))
						record.PROVEEDOR_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_tarjeta_idColumnIndex))
						record.CTACTE_PROCESADORA_TARJETA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_tarjeta_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_AUTO_RELACIONESRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTO_RELACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTO_RELACIONESRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTO_RELACIONESRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTO_RELACIONESRow mappedObject = new CTB_ASIENTOS_AUTO_RELACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_AUTO_DET_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTO_DET_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "INVERTIR_DEBE_Y_HABER"
			dataColumn = dataTable.Columns["INVERTIR_DEBE_Y_HABER"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVERTIR_DEBE_Y_HABER = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "STOCK_DEPOSITO_ID"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_USADO"
			dataColumn = dataTable.Columns["ARTICULO_USADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_USADO = (string)row[dataColumn];
			// Column "ARTICULO_DANHADO"
			dataColumn = dataTable.Columns["ARTICULO_DANHADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DANHADO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "TIPO_NOTAS_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_NOTAS_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOTAS_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTE_ID"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "TIPO_ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["TIPO_ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "INVERTIR_SI_ES_NEGATIVO"
			dataColumn = dataTable.Columns["INVERTIR_SI_ES_NEGATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVERTIR_SI_ES_NEGATIVO = (string)row[dataColumn];
			// Column "DESCUENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_ID = (decimal)row[dataColumn];
			// Column "BONIFICACION_ID"
			dataColumn = dataTable.Columns["BONIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_ID = (decimal)row[dataColumn];
			// Column "EXCLUSIONES"
			dataColumn = dataTable.Columns["EXCLUSIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXCLUSIONES = (string)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "INCLUSIONES"
			dataColumn = dataTable.Columns["INCLUSIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUSIONES = (string)row[dataColumn];
			// Column "CREAR_ASIENTO"
			dataColumn = dataTable.Columns["CREAR_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREAR_ASIENTO = (string)row[dataColumn];
			// Column "PERSONA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["PERSONA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_RUBRO_ID"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_RELACIONADO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_TARJETA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_TARJETA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_TARJETA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_AUTO_RELACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTO_RELACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTO_DET_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INVERTIR_DEBE_Y_HABER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_USADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ARTICULO_DANHADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_NOTAS_CREDITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_ORDEN_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INVERTIR_SI_ES_NEGATIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BONIFICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EXCLUSIONES", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INCLUSIONES", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CREAR_ASIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_RELACIONADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
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

				case "CTB_ASIENTO_AUTO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INVERTIR_DEBE_Y_HABER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "STOCK_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_USADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_DANHADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_NOTAS_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INVERTIR_SI_ES_NEGATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BONIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EXCLUSIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUSIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CREAR_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_TARJETA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_AUTO_RELACIONESCollection_Base class
}  // End of namespace
