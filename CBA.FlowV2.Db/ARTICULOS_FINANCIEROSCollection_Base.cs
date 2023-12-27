// <fileinfo name="ARTICULOS_FINANCIEROSCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_FINANCIEROSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_FINANCIEROSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_FINANCIEROSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string TIPO_FRECUENCIAColumnName = "TIPO_FRECUENCIA";
		public const string CANTIDAD_CUOTASColumnName = "CANTIDAD_CUOTAS";
		public const string FRECUENCIAColumnName = "FRECUENCIA";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_CREDITO_IDColumnName = "TIPO_CREDITO_ID";
		public const string ANHO_COMERCIALColumnName = "ANHO_COMERCIAL";
		public const string DESEMBOLSAR_PARA_CLIENTEColumnName = "DESEMBOLSAR_PARA_CLIENTE";
		public const string FACTURAR_CONCEPTOS_EN_PAGOSColumnName = "FACTURAR_CONCEPTOS_EN_PAGOS";
		public const string INTERES_INCLUYE_IMPUESTOColumnName = "INTERES_INCLUYE_IMPUESTO";
		public const string AUMENTAR_CAPITAL_POR_DESCUENTColumnName = "AUMENTAR_CAPITAL_POR_DESCUENT";
		public const string CON_RECURSOColumnName = "CON_RECURSO";
		public const string MONTO_REDONDEOColumnName = "MONTO_REDONDEO";
		public const string TIPO_INTERES_ANUALColumnName = "TIPO_INTERES_ANUAL";
		public const string CONCEPTO_INCLUYE_IMPUESTOColumnName = "CONCEPTO_INCLUYE_IMPUESTO";
		public const string FACTURAR_BONIFICACION_EN_PAGOSColumnName = "FACTURAR_BONIFICACION_EN_PAGOS";
		public const string BONIFICACION_INCLUYE_IMPUESTOColumnName = "BONIFICACION_INCLUYE_IMPUESTO";
		public const string FECHA_DESDEColumnName = "FECHA_DESDE";
		public const string FECHA_HASTAColumnName = "FECHA_HASTA";
		public const string TIPO_ARTICULO_FINANCIERO_IDColumnName = "TIPO_ARTICULO_FINANCIERO_ID";
		public const string FACTURAR_INTERESESColumnName = "FACTURAR_INTERESES";
		public const string CUOTA_MONTO_BASEColumnName = "CUOTA_MONTO_BASE";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string FACTURAR_CAPITALColumnName = "FACTURAR_CAPITAL";
		public const string POLITICA_BUSQUEDA_RANGO_DIASColumnName = "POLITICA_BUSQUEDA_RANGO_DIAS";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string REGLAS_PRIMER_VENCIMIENTOColumnName = "REGLAS_PRIMER_VENCIMIENTO";
		public const string ARTICULO_REFINANCIACION_IDColumnName = "ARTICULO_REFINANCIACION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FINANCIEROSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_FINANCIEROSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_FINANCIEROSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FINANCIEROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_FINANCIEROSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_FINANCIEROSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public ARTICULOS_FINANCIEROSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_FINANCIEROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_FINANCIEROSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FINANCIEROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_FINANCIEROSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_FINANCIEROSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public ARTICULOS_FINANCIEROSRow[] GetByARTICULO_REFINANCIACION_ID(decimal articulo_refinanciacion_id)
		{
			return GetByARTICULO_REFINANCIACION_ID(articulo_refinanciacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <param name="articulo_refinanciacion_idNull">true if the method ignores the articulo_refinanciacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByARTICULO_REFINANCIACION_ID(decimal articulo_refinanciacion_id, bool articulo_refinanciacion_idNull)
		{
			return MapRecords(CreateGetByARTICULO_REFINANCIACION_IDCommand(articulo_refinanciacion_id, articulo_refinanciacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_REFINANCIACION_IDAsDataTable(decimal articulo_refinanciacion_id)
		{
			return GetByARTICULO_REFINANCIACION_IDAsDataTable(articulo_refinanciacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <param name="articulo_refinanciacion_idNull">true if the method ignores the articulo_refinanciacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_REFINANCIACION_IDAsDataTable(decimal articulo_refinanciacion_id, bool articulo_refinanciacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_REFINANCIACION_IDCommand(articulo_refinanciacion_id, articulo_refinanciacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <param name="articulo_refinanciacion_idNull">true if the method ignores the articulo_refinanciacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_REFINANCIACION_IDCommand(decimal articulo_refinanciacion_id, bool articulo_refinanciacion_idNull)
		{
			string whereSql = "";
			if(articulo_refinanciacion_idNull)
				whereSql += "ARTICULO_REFINANCIACION_ID IS NULL";
			else
				whereSql += "ARTICULO_REFINANCIACION_ID=" + _db.CreateSqlParameterName("ARTICULO_REFINANCIACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_refinanciacion_idNull)
				AddParameter(cmd, "ARTICULO_REFINANCIACION_ID", articulo_refinanciacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FINAN_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public ARTICULOS_FINANCIEROSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
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
		/// return records by the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
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
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FINAN_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public ARTICULOS_FINANCIEROSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_TIPO_ART</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financiero_id">The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByTIPO_ARTICULO_FINANCIERO_ID(decimal tipo_articulo_financiero_id)
		{
			return MapRecords(CreateGetByTIPO_ARTICULO_FINANCIERO_IDCommand(tipo_articulo_financiero_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_TIPO_ART</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financiero_id">The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_ARTICULO_FINANCIERO_IDAsDataTable(decimal tipo_articulo_financiero_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_ARTICULO_FINANCIERO_IDCommand(tipo_articulo_financiero_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FINAN_TIPO_ART</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financiero_id">The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_ARTICULO_FINANCIERO_IDCommand(decimal tipo_articulo_financiero_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANCIERO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ARTICULO_FINANCIERO_ID", tipo_articulo_financiero_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FINAN_TIPO_CRE</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROSRow[] GetByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return MapRecords(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FINAN_TIPO_CRE</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CREDITO_IDAsDataTable(decimal tipo_credito_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FINAN_TIPO_CRE</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROSRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_FINANCIEROSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_FINANCIEROS (" +
				"ID, " +
				"ARTICULO_ID, " +
				"MONEDA_ID, " +
				"TIPO_FRECUENCIA, " +
				"CANTIDAD_CUOTAS, " +
				"FRECUENCIA, " +
				"ESTADO, " +
				"TIPO_CREDITO_ID, " +
				"ANHO_COMERCIAL, " +
				"DESEMBOLSAR_PARA_CLIENTE, " +
				"FACTURAR_CONCEPTOS_EN_PAGOS, " +
				"INTERES_INCLUYE_IMPUESTO, " +
				"AUMENTAR_CAPITAL_POR_DESCUENT, " +
				"CON_RECURSO, " +
				"MONTO_REDONDEO, " +
				"TIPO_INTERES_ANUAL, " +
				"CONCEPTO_INCLUYE_IMPUESTO, " +
				"FACTURAR_BONIFICACION_EN_PAGOS, " +
				"BONIFICACION_INCLUYE_IMPUESTO, " +
				"FECHA_DESDE, " +
				"FECHA_HASTA, " +
				"TIPO_ARTICULO_FINANCIERO_ID, " +
				"FACTURAR_INTERESES, " +
				"CUOTA_MONTO_BASE, " +
				"CANAL_VENTA_ID, " +
				"FACTURAR_CAPITAL, " +
				"POLITICA_BUSQUEDA_RANGO_DIAS, " +
				"PERSONA_ID, " +
				"REGLAS_PRIMER_VENCIMIENTO, " +
				"ARTICULO_REFINANCIACION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_FRECUENCIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				_db.CreateSqlParameterName("FRECUENCIA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("ANHO_COMERCIAL") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSAR_PARA_CLIENTE") + ", " +
				_db.CreateSqlParameterName("FACTURAR_CONCEPTOS_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("AUMENTAR_CAPITAL_POR_DESCUENT") + ", " +
				_db.CreateSqlParameterName("CON_RECURSO") + ", " +
				_db.CreateSqlParameterName("MONTO_REDONDEO") + ", " +
				_db.CreateSqlParameterName("TIPO_INTERES_ANUAL") + ", " +
				_db.CreateSqlParameterName("CONCEPTO_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("FACTURAR_BONIFICACION_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("BONIFICACION_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				_db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				_db.CreateSqlParameterName("TIPO_ARTICULO_FINANCIERO_ID") + ", " +
				_db.CreateSqlParameterName("FACTURAR_INTERESES") + ", " +
				_db.CreateSqlParameterName("CUOTA_MONTO_BASE") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("FACTURAR_CAPITAL") + ", " +
				_db.CreateSqlParameterName("POLITICA_BUSQUEDA_RANGO_DIAS") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("REGLAS_PRIMER_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_REFINANCIACION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "TIPO_FRECUENCIA", value.TIPO_FRECUENCIA);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "FRECUENCIA", value.FRECUENCIA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "ANHO_COMERCIAL", value.ANHO_COMERCIAL);
			AddParameter(cmd, "DESEMBOLSAR_PARA_CLIENTE", value.DESEMBOLSAR_PARA_CLIENTE);
			AddParameter(cmd, "FACTURAR_CONCEPTOS_EN_PAGOS", value.FACTURAR_CONCEPTOS_EN_PAGOS);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			AddParameter(cmd, "AUMENTAR_CAPITAL_POR_DESCUENT", value.AUMENTAR_CAPITAL_POR_DESCUENT);
			AddParameter(cmd, "CON_RECURSO", value.CON_RECURSO);
			AddParameter(cmd, "MONTO_REDONDEO", value.MONTO_REDONDEO);
			AddParameter(cmd, "TIPO_INTERES_ANUAL", value.TIPO_INTERES_ANUAL);
			AddParameter(cmd, "CONCEPTO_INCLUYE_IMPUESTO", value.CONCEPTO_INCLUYE_IMPUESTO);
			AddParameter(cmd, "FACTURAR_BONIFICACION_EN_PAGOS", value.FACTURAR_BONIFICACION_EN_PAGOS);
			AddParameter(cmd, "BONIFICACION_INCLUYE_IMPUESTO", value.BONIFICACION_INCLUYE_IMPUESTO);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "TIPO_ARTICULO_FINANCIERO_ID", value.TIPO_ARTICULO_FINANCIERO_ID);
			AddParameter(cmd, "FACTURAR_INTERESES", value.FACTURAR_INTERESES);
			AddParameter(cmd, "CUOTA_MONTO_BASE",
				value.IsCUOTA_MONTO_BASENull ? DBNull.Value : (object)value.CUOTA_MONTO_BASE);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "FACTURAR_CAPITAL", value.FACTURAR_CAPITAL);
			AddParameter(cmd, "POLITICA_BUSQUEDA_RANGO_DIAS", value.POLITICA_BUSQUEDA_RANGO_DIAS);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "REGLAS_PRIMER_VENCIMIENTO", value.REGLAS_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "ARTICULO_REFINANCIACION_ID",
				value.IsARTICULO_REFINANCIACION_IDNull ? DBNull.Value : (object)value.ARTICULO_REFINANCIACION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_FINANCIEROSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_FINANCIEROS SET " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"TIPO_FRECUENCIA=" + _db.CreateSqlParameterName("TIPO_FRECUENCIA") + ", " +
				"CANTIDAD_CUOTAS=" + _db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				"FRECUENCIA=" + _db.CreateSqlParameterName("FRECUENCIA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				"ANHO_COMERCIAL=" + _db.CreateSqlParameterName("ANHO_COMERCIAL") + ", " +
				"DESEMBOLSAR_PARA_CLIENTE=" + _db.CreateSqlParameterName("DESEMBOLSAR_PARA_CLIENTE") + ", " +
				"FACTURAR_CONCEPTOS_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_CONCEPTOS_EN_PAGOS") + ", " +
				"INTERES_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") + ", " +
				"AUMENTAR_CAPITAL_POR_DESCUENT=" + _db.CreateSqlParameterName("AUMENTAR_CAPITAL_POR_DESCUENT") + ", " +
				"CON_RECURSO=" + _db.CreateSqlParameterName("CON_RECURSO") + ", " +
				"MONTO_REDONDEO=" + _db.CreateSqlParameterName("MONTO_REDONDEO") + ", " +
				"TIPO_INTERES_ANUAL=" + _db.CreateSqlParameterName("TIPO_INTERES_ANUAL") + ", " +
				"CONCEPTO_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("CONCEPTO_INCLUYE_IMPUESTO") + ", " +
				"FACTURAR_BONIFICACION_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_BONIFICACION_EN_PAGOS") + ", " +
				"BONIFICACION_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("BONIFICACION_INCLUYE_IMPUESTO") + ", " +
				"FECHA_DESDE=" + _db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				"FECHA_HASTA=" + _db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				"TIPO_ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANCIERO_ID") + ", " +
				"FACTURAR_INTERESES=" + _db.CreateSqlParameterName("FACTURAR_INTERESES") + ", " +
				"CUOTA_MONTO_BASE=" + _db.CreateSqlParameterName("CUOTA_MONTO_BASE") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				"FACTURAR_CAPITAL=" + _db.CreateSqlParameterName("FACTURAR_CAPITAL") + ", " +
				"POLITICA_BUSQUEDA_RANGO_DIAS=" + _db.CreateSqlParameterName("POLITICA_BUSQUEDA_RANGO_DIAS") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"REGLAS_PRIMER_VENCIMIENTO=" + _db.CreateSqlParameterName("REGLAS_PRIMER_VENCIMIENTO") + ", " +
				"ARTICULO_REFINANCIACION_ID=" + _db.CreateSqlParameterName("ARTICULO_REFINANCIACION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "TIPO_FRECUENCIA", value.TIPO_FRECUENCIA);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "FRECUENCIA", value.FRECUENCIA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "ANHO_COMERCIAL", value.ANHO_COMERCIAL);
			AddParameter(cmd, "DESEMBOLSAR_PARA_CLIENTE", value.DESEMBOLSAR_PARA_CLIENTE);
			AddParameter(cmd, "FACTURAR_CONCEPTOS_EN_PAGOS", value.FACTURAR_CONCEPTOS_EN_PAGOS);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			AddParameter(cmd, "AUMENTAR_CAPITAL_POR_DESCUENT", value.AUMENTAR_CAPITAL_POR_DESCUENT);
			AddParameter(cmd, "CON_RECURSO", value.CON_RECURSO);
			AddParameter(cmd, "MONTO_REDONDEO", value.MONTO_REDONDEO);
			AddParameter(cmd, "TIPO_INTERES_ANUAL", value.TIPO_INTERES_ANUAL);
			AddParameter(cmd, "CONCEPTO_INCLUYE_IMPUESTO", value.CONCEPTO_INCLUYE_IMPUESTO);
			AddParameter(cmd, "FACTURAR_BONIFICACION_EN_PAGOS", value.FACTURAR_BONIFICACION_EN_PAGOS);
			AddParameter(cmd, "BONIFICACION_INCLUYE_IMPUESTO", value.BONIFICACION_INCLUYE_IMPUESTO);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "TIPO_ARTICULO_FINANCIERO_ID", value.TIPO_ARTICULO_FINANCIERO_ID);
			AddParameter(cmd, "FACTURAR_INTERESES", value.FACTURAR_INTERESES);
			AddParameter(cmd, "CUOTA_MONTO_BASE",
				value.IsCUOTA_MONTO_BASENull ? DBNull.Value : (object)value.CUOTA_MONTO_BASE);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "FACTURAR_CAPITAL", value.FACTURAR_CAPITAL);
			AddParameter(cmd, "POLITICA_BUSQUEDA_RANGO_DIAS", value.POLITICA_BUSQUEDA_RANGO_DIAS);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "REGLAS_PRIMER_VENCIMIENTO", value.REGLAS_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "ARTICULO_REFINANCIACION_ID",
				value.IsARTICULO_REFINANCIACION_IDNull ? DBNull.Value : (object)value.ARTICULO_REFINANCIACION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FINANCIEROS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FINANCIEROS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_FINANCIEROSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_FINANCIEROS</c> table using
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
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_REFINANCIACION_ID(decimal articulo_refinanciacion_id)
		{
			return DeleteByARTICULO_REFINANCIACION_ID(articulo_refinanciacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <param name="articulo_refinanciacion_idNull">true if the method ignores the articulo_refinanciacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_REFINANCIACION_ID(decimal articulo_refinanciacion_id, bool articulo_refinanciacion_idNull)
		{
			return CreateDeleteByARTICULO_REFINANCIACION_IDCommand(articulo_refinanciacion_id, articulo_refinanciacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FINAN_ARTIC_REFI</c> foreign key.
		/// </summary>
		/// <param name="articulo_refinanciacion_id">The <c>ARTICULO_REFINANCIACION_ID</c> column value.</param>
		/// <param name="articulo_refinanciacion_idNull">true if the method ignores the articulo_refinanciacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_REFINANCIACION_IDCommand(decimal articulo_refinanciacion_id, bool articulo_refinanciacion_idNull)
		{
			string whereSql = "";
			if(articulo_refinanciacion_idNull)
				whereSql += "ARTICULO_REFINANCIACION_ID IS NULL";
			else
				whereSql += "ARTICULO_REFINANCIACION_ID=" + _db.CreateSqlParameterName("ARTICULO_REFINANCIACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_refinanciacion_idNull)
				AddParameter(cmd, "ARTICULO_REFINANCIACION_ID", articulo_refinanciacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FINAN_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
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
		/// delete records using the <c>FK_ARTICULOS_FINAN_CANAL_VENTA</c> foreign key.
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
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FINAN_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_ARTICULOS_FINAN_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_TIPO_ART</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financiero_id">The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ARTICULO_FINANCIERO_ID(decimal tipo_articulo_financiero_id)
		{
			return CreateDeleteByTIPO_ARTICULO_FINANCIERO_IDCommand(tipo_articulo_financiero_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FINAN_TIPO_ART</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financiero_id">The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_ARTICULO_FINANCIERO_IDCommand(decimal tipo_articulo_financiero_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANCIERO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ARTICULO_FINANCIERO_ID", tipo_articulo_financiero_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS</c> table using the 
		/// <c>FK_ARTICULOS_FINAN_TIPO_CRE</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return CreateDeleteByTIPO_CREDITO_IDCommand(tipo_credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FINAN_TIPO_CRE</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_FINANCIEROS</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_FINANCIEROS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_FINANCIEROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_FINANCIEROS</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		protected ARTICULOS_FINANCIEROSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		protected ARTICULOS_FINANCIEROSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROSRow"/> objects.</returns>
		protected virtual ARTICULOS_FINANCIEROSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int tipo_frecuenciaColumnIndex = reader.GetOrdinal("TIPO_FRECUENCIA");
			int cantidad_cuotasColumnIndex = reader.GetOrdinal("CANTIDAD_CUOTAS");
			int frecuenciaColumnIndex = reader.GetOrdinal("FRECUENCIA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_credito_idColumnIndex = reader.GetOrdinal("TIPO_CREDITO_ID");
			int anho_comercialColumnIndex = reader.GetOrdinal("ANHO_COMERCIAL");
			int desembolsar_para_clienteColumnIndex = reader.GetOrdinal("DESEMBOLSAR_PARA_CLIENTE");
			int facturar_conceptos_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_CONCEPTOS_EN_PAGOS");
			int interes_incluye_impuestoColumnIndex = reader.GetOrdinal("INTERES_INCLUYE_IMPUESTO");
			int aumentar_capital_por_descuentColumnIndex = reader.GetOrdinal("AUMENTAR_CAPITAL_POR_DESCUENT");
			int con_recursoColumnIndex = reader.GetOrdinal("CON_RECURSO");
			int monto_redondeoColumnIndex = reader.GetOrdinal("MONTO_REDONDEO");
			int tipo_interes_anualColumnIndex = reader.GetOrdinal("TIPO_INTERES_ANUAL");
			int concepto_incluye_impuestoColumnIndex = reader.GetOrdinal("CONCEPTO_INCLUYE_IMPUESTO");
			int facturar_bonificacion_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_BONIFICACION_EN_PAGOS");
			int bonificacion_incluye_impuestoColumnIndex = reader.GetOrdinal("BONIFICACION_INCLUYE_IMPUESTO");
			int fecha_desdeColumnIndex = reader.GetOrdinal("FECHA_DESDE");
			int fecha_hastaColumnIndex = reader.GetOrdinal("FECHA_HASTA");
			int tipo_articulo_financiero_idColumnIndex = reader.GetOrdinal("TIPO_ARTICULO_FINANCIERO_ID");
			int facturar_interesesColumnIndex = reader.GetOrdinal("FACTURAR_INTERESES");
			int cuota_monto_baseColumnIndex = reader.GetOrdinal("CUOTA_MONTO_BASE");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int facturar_capitalColumnIndex = reader.GetOrdinal("FACTURAR_CAPITAL");
			int politica_busqueda_rango_diasColumnIndex = reader.GetOrdinal("POLITICA_BUSQUEDA_RANGO_DIAS");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int reglas_primer_vencimientoColumnIndex = reader.GetOrdinal("REGLAS_PRIMER_VENCIMIENTO");
			int articulo_refinanciacion_idColumnIndex = reader.GetOrdinal("ARTICULO_REFINANCIACION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_FINANCIEROSRow record = new ARTICULOS_FINANCIEROSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.TIPO_FRECUENCIA = Convert.ToString(reader.GetValue(tipo_frecuenciaColumnIndex));
					record.CANTIDAD_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cuotasColumnIndex)), 9);
					record.FRECUENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(frecuenciaColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.TIPO_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_credito_idColumnIndex)), 9);
					record.ANHO_COMERCIAL = Convert.ToString(reader.GetValue(anho_comercialColumnIndex));
					record.DESEMBOLSAR_PARA_CLIENTE = Convert.ToString(reader.GetValue(desembolsar_para_clienteColumnIndex));
					record.FACTURAR_CONCEPTOS_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_conceptos_en_pagosColumnIndex));
					record.INTERES_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(interes_incluye_impuestoColumnIndex));
					record.AUMENTAR_CAPITAL_POR_DESCUENT = Convert.ToString(reader.GetValue(aumentar_capital_por_descuentColumnIndex));
					record.CON_RECURSO = Convert.ToString(reader.GetValue(con_recursoColumnIndex));
					record.MONTO_REDONDEO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_redondeoColumnIndex)), 9);
					record.TIPO_INTERES_ANUAL = Convert.ToString(reader.GetValue(tipo_interes_anualColumnIndex));
					record.CONCEPTO_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(concepto_incluye_impuestoColumnIndex));
					if(!reader.IsDBNull(facturar_bonificacion_en_pagosColumnIndex))
						record.FACTURAR_BONIFICACION_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_bonificacion_en_pagosColumnIndex));
					record.BONIFICACION_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(bonificacion_incluye_impuestoColumnIndex));
					if(!reader.IsDBNull(fecha_desdeColumnIndex))
						record.FECHA_DESDE = Convert.ToDateTime(reader.GetValue(fecha_desdeColumnIndex));
					if(!reader.IsDBNull(fecha_hastaColumnIndex))
						record.FECHA_HASTA = Convert.ToDateTime(reader.GetValue(fecha_hastaColumnIndex));
					record.TIPO_ARTICULO_FINANCIERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_articulo_financiero_idColumnIndex)), 9);
					record.FACTURAR_INTERESES = Math.Round(Convert.ToDecimal(reader.GetValue(facturar_interesesColumnIndex)), 9);
					if(!reader.IsDBNull(cuota_monto_baseColumnIndex))
						record.CUOTA_MONTO_BASE = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_monto_baseColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					record.FACTURAR_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(facturar_capitalColumnIndex)), 9);
					record.POLITICA_BUSQUEDA_RANGO_DIAS = Math.Round(Convert.ToDecimal(reader.GetValue(politica_busqueda_rango_diasColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(reglas_primer_vencimientoColumnIndex))
						record.REGLAS_PRIMER_VENCIMIENTO = Convert.ToString(reader.GetValue(reglas_primer_vencimientoColumnIndex));
					if(!reader.IsDBNull(articulo_refinanciacion_idColumnIndex))
						record.ARTICULO_REFINANCIACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_refinanciacion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_FINANCIEROSRow[])(recordList.ToArray(typeof(ARTICULOS_FINANCIEROSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_FINANCIEROSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_FINANCIEROSRow"/> object.</returns>
		protected virtual ARTICULOS_FINANCIEROSRow MapRow(DataRow row)
		{
			ARTICULOS_FINANCIEROSRow mappedObject = new ARTICULOS_FINANCIEROSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "TIPO_FRECUENCIA"
			dataColumn = dataTable.Columns["TIPO_FRECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FRECUENCIA = (string)row[dataColumn];
			// Column "CANTIDAD_CUOTAS"
			dataColumn = dataTable.Columns["CANTIDAD_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CUOTAS = (decimal)row[dataColumn];
			// Column "FRECUENCIA"
			dataColumn = dataTable.Columns["FRECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FRECUENCIA = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CREDITO_ID = (decimal)row[dataColumn];
			// Column "ANHO_COMERCIAL"
			dataColumn = dataTable.Columns["ANHO_COMERCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO_COMERCIAL = (string)row[dataColumn];
			// Column "DESEMBOLSAR_PARA_CLIENTE"
			dataColumn = dataTable.Columns["DESEMBOLSAR_PARA_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSAR_PARA_CLIENTE = (string)row[dataColumn];
			// Column "FACTURAR_CONCEPTOS_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_CONCEPTOS_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_CONCEPTOS_EN_PAGOS = (string)row[dataColumn];
			// Column "INTERES_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["INTERES_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "AUMENTAR_CAPITAL_POR_DESCUENT"
			dataColumn = dataTable.Columns["AUMENTAR_CAPITAL_POR_DESCUENT"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUMENTAR_CAPITAL_POR_DESCUENT = (string)row[dataColumn];
			// Column "CON_RECURSO"
			dataColumn = dataTable.Columns["CON_RECURSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CON_RECURSO = (string)row[dataColumn];
			// Column "MONTO_REDONDEO"
			dataColumn = dataTable.Columns["MONTO_REDONDEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_REDONDEO = (decimal)row[dataColumn];
			// Column "TIPO_INTERES_ANUAL"
			dataColumn = dataTable.Columns["TIPO_INTERES_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_INTERES_ANUAL = (string)row[dataColumn];
			// Column "CONCEPTO_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["CONCEPTO_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "FACTURAR_BONIFICACION_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_BONIFICACION_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_BONIFICACION_EN_PAGOS = (string)row[dataColumn];
			// Column "BONIFICACION_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["BONIFICACION_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "FECHA_DESDE"
			dataColumn = dataTable.Columns["FECHA_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA"
			dataColumn = dataTable.Columns["FECHA_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA = (System.DateTime)row[dataColumn];
			// Column "TIPO_ARTICULO_FINANCIERO_ID"
			dataColumn = dataTable.Columns["TIPO_ARTICULO_FINANCIERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ARTICULO_FINANCIERO_ID = (decimal)row[dataColumn];
			// Column "FACTURAR_INTERESES"
			dataColumn = dataTable.Columns["FACTURAR_INTERESES"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_INTERESES = (decimal)row[dataColumn];
			// Column "CUOTA_MONTO_BASE"
			dataColumn = dataTable.Columns["CUOTA_MONTO_BASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_MONTO_BASE = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "FACTURAR_CAPITAL"
			dataColumn = dataTable.Columns["FACTURAR_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_CAPITAL = (decimal)row[dataColumn];
			// Column "POLITICA_BUSQUEDA_RANGO_DIAS"
			dataColumn = dataTable.Columns["POLITICA_BUSQUEDA_RANGO_DIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.POLITICA_BUSQUEDA_RANGO_DIAS = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "REGLAS_PRIMER_VENCIMIENTO"
			dataColumn = dataTable.Columns["REGLAS_PRIMER_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGLAS_PRIMER_VENCIMIENTO = (string)row[dataColumn];
			// Column "ARTICULO_REFINANCIACION_ID"
			dataColumn = dataTable.Columns["ARTICULO_REFINANCIACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_REFINANCIACION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_FINANCIEROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_FINANCIEROS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_FRECUENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CUOTAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FRECUENCIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ANHO_COMERCIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESEMBOLSAR_PARA_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_CONCEPTOS_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUMENTAR_CAPITAL_POR_DESCUENT", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CON_RECURSO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_REDONDEO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_INTERES_ANUAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONCEPTO_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_BONIFICACION_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("BONIFICACION_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_DESDE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_HASTA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TIPO_ARTICULO_FINANCIERO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_INTERESES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUOTA_MONTO_BASE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTURAR_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("POLITICA_BUSQUEDA_RANGO_DIAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REGLAS_PRIMER_VENCIMIENTO", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ARTICULO_REFINANCIACION_ID", typeof(decimal));
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

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FRECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANTIDAD_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FRECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANHO_COMERCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESEMBOLSAR_PARA_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_CONCEPTOS_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERES_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUMENTAR_CAPITAL_POR_DESCUENT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CON_RECURSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_REDONDEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_INTERES_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONCEPTO_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_BONIFICACION_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BONIFICACION_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_ARTICULO_FINANCIERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAR_INTERESES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA_MONTO_BASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAR_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POLITICA_BUSQUEDA_RANGO_DIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGLAS_PRIMER_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_REFINANCIACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_FINANCIEROSCollection_Base class
}  // End of namespace
