// <fileinfo name="FACTURAS_PROVEEDOR_DET_INFO_CCollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDOR_DET_INFO_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_PROVEEDOR_DET_INFO_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDOR_DET_INFO_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FACTURAS_PROVEEDOR_IDColumnName = "FACTURAS_PROVEEDOR_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string IMPUESTO_COMPRA_IDColumnName = "IMPUESTO_COMPRA_ID";
		public const string ARTICULO_MARCA_IDColumnName = "ARTICULO_MARCA_ID";
		public const string SERVICIOColumnName = "SERVICIO";
		public const string MARCA_NOMBREColumnName = "MARCA_NOMBRE";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string ARTICULO_DESCRIPCION_COMPLETAColumnName = "ARTICULO_DESCRIPCION_COMPLETA";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTE_NOMBREColumnName = "LOTE_NOMBRE";
		public const string UNIDAD_ID_DESTINOColumnName = "UNIDAD_ID_DESTINO";
		public const string UNIDAD_DESTINO_DESCRIPCIONColumnName = "UNIDAD_DESTINO_DESCRIPCION";
		public const string CANTIDAD_EMBALADA_DESTINOColumnName = "CANTIDAD_EMBALADA_DESTINO";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string PRECIO_BRUTO_UNITARIO_DESTColumnName = "PRECIO_BRUTO_UNITARIO_DEST";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string UNIDAD_ID_ORIGENColumnName = "UNIDAD_ID_ORIGEN";
		public const string UNIDAD_ORIGEN_DESCRIPCIONColumnName = "UNIDAD_ORIGEN_DESCRIPCION";
		public const string CANTIDAD_EMBALADA_ORIGENColumnName = "CANTIDAD_EMBALADA_ORIGEN";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string PRECIO_BRUTO_UNITARIO_ORIGColumnName = "PRECIO_BRUTO_UNITARIO_ORIG";
		public const string PORCENTAJE_DESCUENTOColumnName = "PORCENTAJE_DESCUENTO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string TOTAL_BRUTOColumnName = "TOTAL_BRUTO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_IMPUESTO_DESCONTADOColumnName = "TOTAL_IMPUESTO_DESCONTADO";
		public const string TOTAL_PAGOColumnName = "TOTAL_PAGO";
		public const string CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName = "CANTIDAD_DEVUELTA_NOTA_CREDITO";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUBRO_NOMBREColumnName = "RUBRO_NOMBRE";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTO_NOMBREColumnName = "IMPUESTO_NOMBRE";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDO_TEXTOColumnName = "TEXTO_PREDEFINIDO_TEXTO";
		public const string TIPO_DETALLEColumnName = "TIPO_DETALLE";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";
		public const string PROVEEDOR_RELACIONADO_IDColumnName = "PROVEEDOR_RELACIONADO_ID";
		public const string PROVEEDOR_RELACIONADO_NOMBREColumnName = "PROVEEDOR_RELACIONADO_NOMBRE";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string RUBRO_IVA_IDColumnName = "RUBRO_IVA_ID";
		public const string CODIGO_RUBROColumnName = "CODIGO_RUBRO";
		public const string DESCRIPCION_RUBROColumnName = "DESCRIPCION_RUBRO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDOR_DET_INFO_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_PROVEEDOR_DET_INFO_CCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this view belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>FACTURAS_PROVEEDOR_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DET_INFO_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_PROVEEDOR_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_PROVEEDOR_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_PROVEEDOR_DET_INFO_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_PROVEEDOR_DET_INFO_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_DET_INFO_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_DET_INFO_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_PROVEEDOR_DET_INFO_C";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_DET_INFO_CRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_DET_INFO_CRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> objects.</returns>
		protected virtual FACTURAS_PROVEEDOR_DET_INFO_CRow[] MapRecords(IDataReader reader, 
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
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int impuesto_compra_idColumnIndex = reader.GetOrdinal("IMPUESTO_COMPRA_ID");
			int articulo_marca_idColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_ID");
			int servicioColumnIndex = reader.GetOrdinal("SERVICIO");
			int marca_nombreColumnIndex = reader.GetOrdinal("MARCA_NOMBRE");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int articulo_descripcion_completaColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION_COMPLETA");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int lote_nombreColumnIndex = reader.GetOrdinal("LOTE_NOMBRE");
			int unidad_id_destinoColumnIndex = reader.GetOrdinal("UNIDAD_ID_DESTINO");
			int unidad_destino_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_DESCRIPCION");
			int cantidad_embalada_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA_DESTINO");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int precio_bruto_unitario_destColumnIndex = reader.GetOrdinal("PRECIO_BRUTO_UNITARIO_DEST");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int unidad_id_origenColumnIndex = reader.GetOrdinal("UNIDAD_ID_ORIGEN");
			int unidad_origen_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_DESCRIPCION");
			int cantidad_embalada_origenColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA_ORIGEN");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int precio_bruto_unitario_origColumnIndex = reader.GetOrdinal("PRECIO_BRUTO_UNITARIO_ORIG");
			int porcentaje_descuentoColumnIndex = reader.GetOrdinal("PORCENTAJE_DESCUENTO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int total_brutoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_impuesto_descontadoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO_DESCONTADO");
			int total_pagoColumnIndex = reader.GetOrdinal("TOTAL_PAGO");
			int cantidad_devuelta_nota_creditoColumnIndex = reader.GetOrdinal("CANTIDAD_DEVUELTA_NOTA_CREDITO");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rubro_nombreColumnIndex = reader.GetOrdinal("RUBRO_NOMBRE");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuesto_nombreColumnIndex = reader.GetOrdinal("IMPUESTO_NOMBRE");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int texto_predefinido_textoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_TEXTO");
			int tipo_detalleColumnIndex = reader.GetOrdinal("TIPO_DETALLE");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");
			int proveedor_relacionado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_RELACIONADO_ID");
			int proveedor_relacionado_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_RELACIONADO_NOMBRE");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int rubro_iva_idColumnIndex = reader.GetOrdinal("RUBRO_IVA_ID");
			int codigo_rubroColumnIndex = reader.GetOrdinal("CODIGO_RUBRO");
			int descripcion_rubroColumnIndex = reader.GetOrdinal("DESCRIPCION_RUBRO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_PROVEEDOR_DET_INFO_CRow record = new FACTURAS_PROVEEDOR_DET_INFO_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FACTURAS_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_compra_idColumnIndex))
						record.IMPUESTO_COMPRA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_compra_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_marca_idColumnIndex))
						record.ARTICULO_MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_marca_idColumnIndex)), 9);
					if(!reader.IsDBNull(servicioColumnIndex))
						record.SERVICIO = Convert.ToString(reader.GetValue(servicioColumnIndex));
					if(!reader.IsDBNull(marca_nombreColumnIndex))
						record.MARCA_NOMBRE = Convert.ToString(reader.GetValue(marca_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_descripcion_completaColumnIndex))
						record.ARTICULO_DESCRIPCION_COMPLETA = Convert.ToString(reader.GetValue(articulo_descripcion_completaColumnIndex));
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_nombreColumnIndex))
						record.LOTE_NOMBRE = Convert.ToString(reader.GetValue(lote_nombreColumnIndex));
					record.UNIDAD_ID_DESTINO = Convert.ToString(reader.GetValue(unidad_id_destinoColumnIndex));
					if(!reader.IsDBNull(unidad_destino_descripcionColumnIndex))
						record.UNIDAD_DESTINO_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_destino_descripcionColumnIndex));
					record.CANTIDAD_EMBALADA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embalada_destinoColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					record.PRECIO_BRUTO_UNITARIO_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(precio_bruto_unitario_destColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_id_origenColumnIndex))
						record.UNIDAD_ID_ORIGEN = Convert.ToString(reader.GetValue(unidad_id_origenColumnIndex));
					if(!reader.IsDBNull(unidad_origen_descripcionColumnIndex))
						record.UNIDAD_ORIGEN_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_origen_descripcionColumnIndex));
					if(!reader.IsDBNull(cantidad_embalada_origenColumnIndex))
						record.CANTIDAD_EMBALADA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embalada_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unidad_origenColumnIndex))
						record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_caja_origenColumnIndex))
						record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_origColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origColumnIndex)), 9);
					if(!reader.IsDBNull(precio_bruto_unitario_origColumnIndex))
						record.PRECIO_BRUTO_UNITARIO_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(precio_bruto_unitario_origColumnIndex)), 9);
					record.PORCENTAJE_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_descuentoColumnIndex)), 9);
					record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					record.TOTAL_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_brutoColumnIndex)), 9);
					record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					record.TOTAL_IMPUESTO_DESCONTADO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuesto_descontadoColumnIndex)), 9);
					record.TOTAL_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(total_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_devuelta_nota_creditoColumnIndex))
						record.CANTIDAD_DEVUELTA_NOTA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_devuelta_nota_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_nombreColumnIndex))
						record.RUBRO_NOMBRE = Convert.ToString(reader.GetValue(rubro_nombreColumnIndex));
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.IMPUESTO_NOMBRE = Convert.ToString(reader.GetValue(impuesto_nombreColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_textoColumnIndex))
						record.TEXTO_PREDEFINIDO_TEXTO = Convert.ToString(reader.GetValue(texto_predefinido_textoColumnIndex));
					record.TIPO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(afecta_stockColumnIndex))
						record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));
					if(!reader.IsDBNull(proveedor_relacionado_idColumnIndex))
						record.PROVEEDOR_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_relacionado_nombreColumnIndex))
						record.PROVEEDOR_RELACIONADO_NOMBRE = Convert.ToString(reader.GetValue(proveedor_relacionado_nombreColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_iva_idColumnIndex))
						record.RUBRO_IVA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_iva_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_rubroColumnIndex))
						record.CODIGO_RUBRO = Convert.ToString(reader.GetValue(codigo_rubroColumnIndex));
					if(!reader.IsDBNull(descripcion_rubroColumnIndex))
						record.DESCRIPCION_RUBRO = Convert.ToString(reader.GetValue(descripcion_rubroColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_PROVEEDOR_DET_INFO_CRow[])(recordList.ToArray(typeof(FACTURAS_PROVEEDOR_DET_INFO_CRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_PROVEEDOR_DET_INFO_CRow"/> object.</returns>
		protected virtual FACTURAS_PROVEEDOR_DET_INFO_CRow MapRow(DataRow row)
		{
			FACTURAS_PROVEEDOR_DET_INFO_CRow mappedObject = new FACTURAS_PROVEEDOR_DET_INFO_CRow();
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
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
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
			// Column "IMPUESTO_COMPRA_ID"
			dataColumn = dataTable.Columns["IMPUESTO_COMPRA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_COMPRA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_MARCA_ID"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_ID = (decimal)row[dataColumn];
			// Column "SERVICIO"
			dataColumn = dataTable.Columns["SERVICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SERVICIO = (string)row[dataColumn];
			// Column "MARCA_NOMBRE"
			dataColumn = dataTable.Columns["MARCA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION_COMPLETA"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION_COMPLETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION_COMPLETA = (string)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE_NOMBRE"
			dataColumn = dataTable.Columns["LOTE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_NOMBRE = (string)row[dataColumn];
			// Column "UNIDAD_ID_DESTINO"
			dataColumn = dataTable.Columns["UNIDAD_ID_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID_DESTINO = (string)row[dataColumn];
			// Column "UNIDAD_DESTINO_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_DESCRIPCION = (string)row[dataColumn];
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
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "UNIDAD_ID_ORIGEN"
			dataColumn = dataTable.Columns["UNIDAD_ID_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID_ORIGEN = (string)row[dataColumn];
			// Column "UNIDAD_ORIGEN_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_DESCRIPCION = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIG"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)row[dataColumn];
			// Column "PRECIO_BRUTO_UNITARIO_ORIG"
			dataColumn = dataTable.Columns["PRECIO_BRUTO_UNITARIO_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_BRUTO_UNITARIO_ORIG = (decimal)row[dataColumn];
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
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_NOMBRE"
			dataColumn = dataTable.Columns["IMPUESTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_TEXTO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_TEXTO = (string)row[dataColumn];
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
			// Column "PROVEEDOR_RELACIONADO_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_RELACIONADO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RELACIONADO_NOMBRE = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_IVA_ID"
			dataColumn = dataTable.Columns["RUBRO_IVA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_IVA_ID = (decimal)row[dataColumn];
			// Column "CODIGO_RUBRO"
			dataColumn = dataTable.Columns["CODIGO_RUBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_RUBRO = (string)row[dataColumn];
			// Column "DESCRIPCION_RUBRO"
			dataColumn = dataTable.Columns["DESCRIPCION_RUBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_RUBRO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_PROVEEDOR_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_PROVEEDOR_DET_INFO_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURAS_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_COMPRA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SERVICIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION_COMPLETA", typeof(string));
			dataColumn.MaxLength = 1363;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID_DESTINO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_BRUTO_UNITARIO_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID_ORIGEN", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIG", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_BRUTO_UNITARIO_ORIG", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO_DESCONTADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_PAGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEVUELTA_NOTA_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DETALLE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RELACIONADO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_IVA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_RUBRO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_RUBRO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
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

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "IMPUESTO_COMPRA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SERVICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MARCA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION_COMPLETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_ID_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_DESTINO_DESCRIPCION":
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

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_ORIGEN_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_BRUTO_UNITARIO_ORIG":
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

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "PROVEEDOR_RELACIONADO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_IVA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_RUBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_RUBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_PROVEEDOR_DET_INFO_CCollection_Base class
}  // End of namespace
