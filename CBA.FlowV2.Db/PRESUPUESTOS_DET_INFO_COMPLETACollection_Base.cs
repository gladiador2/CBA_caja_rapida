// <fileinfo name="PRESUPUESTOS_DET_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_DET_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRESUPUESTOS_DET_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_DET_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRESUPUESTO_ETAPA_IDColumnName = "PRESUPUESTO_ETAPA_ID";
		public const string PRESUPUESTO_ETAPA_NOMBREColumnName = "PRESUPUESTO_ETAPA_NOMBRE";
		public const string PRESUPUESTO_IDColumnName = "PRESUPUESTO_ID";
		public const string PRESUPUESTO_OBJETOColumnName = "PRESUPUESTO_OBJETO";
		public const string MONTO_BRUTO_UNITARIOColumnName = "MONTO_BRUTO_UNITARIO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_DESC_INTERNAColumnName = "ARTICULO_DESC_INTERNA";
		public const string ARTICULO_COD_EMPRESAColumnName = "ARTICULO_COD_EMPRESA";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_FAMILIA_DESCColumnName = "ARTICULO_FAMILIA_DESC";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_GRUPO_DESCColumnName = "ARTICULO_GRUPO_DESC";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_SUBGRUPO_DESCColumnName = "ARTICULO_SUBGRUPO_DESC";
		public const string ARTICULO_UNIDAD_MED_IDColumnName = "ARTICULO_UNIDAD_MED_ID";
		public const string ARTICULO_UNIDAD_MED_DESCColumnName = "ARTICULO_UNIDAD_MED_DESC";
		public const string ARTICULO_CANTIDAD_POR_CAJAColumnName = "ARTICULO_CANTIDAD_POR_CAJA";
		public const string UNIDAD_MEDIDAColumnName = "UNIDAD_MEDIDA";
		public const string UNIDAD_MEDIDA_DESCRIPCIONColumnName = "UNIDAD_MEDIDA_DESCRIPCION";
		public const string CANTIDAD_CAJASColumnName = "CANTIDAD_CAJAS";
		public const string CANTIDAD_UNIDADESColumnName = "CANTIDAD_UNIDADES";
		public const string CANTIDAD_POR_CAJAColumnName = "CANTIDAD_POR_CAJA";
		public const string CANTIDAD_UNITARIA_TOTALColumnName = "CANTIDAD_UNITARIA_TOTAL";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PORCENTAJE_DESCColumnName = "PORCENTAJE_DESC";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTO_NOMBREColumnName = "IMPUESTO_NOMBRE";
		public const string IMPUESTO_PORCENTAJEColumnName = "IMPUESTO_PORCENTAJE";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CANTIDAD_UNITARIA_FACTURADAColumnName = "CANTIDAD_UNITARIA_FACTURADA";
		public const string MONTO_NETO_UNITARIOColumnName = "MONTO_NETO_UNITARIO";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string MONTO_BRUTO_DESCONTADO_TOTALColumnName = "MONTO_BRUTO_DESCONTADO_TOTAL";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DET_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRESUPUESTOS_DET_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRESUPUESTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRESUPUESTOS_DET_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRESUPUESTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRESUPUESTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRESUPUESTOS_DET_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRESUPUESTOS_DET_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public PRESUPUESTOS_DET_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRESUPUESTOS_DET_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRESUPUESTOS_DET_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected PRESUPUESTOS_DET_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected PRESUPUESTOS_DET_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected virtual PRESUPUESTOS_DET_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int presupuesto_etapa_idColumnIndex = reader.GetOrdinal("PRESUPUESTO_ETAPA_ID");
			int presupuesto_etapa_nombreColumnIndex = reader.GetOrdinal("PRESUPUESTO_ETAPA_NOMBRE");
			int presupuesto_idColumnIndex = reader.GetOrdinal("PRESUPUESTO_ID");
			int presupuesto_objetoColumnIndex = reader.GetOrdinal("PRESUPUESTO_OBJETO");
			int monto_bruto_unitarioColumnIndex = reader.GetOrdinal("MONTO_BRUTO_UNITARIO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_desc_internaColumnIndex = reader.GetOrdinal("ARTICULO_DESC_INTERNA");
			int articulo_cod_empresaColumnIndex = reader.GetOrdinal("ARTICULO_COD_EMPRESA");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_familia_descColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_DESC");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_grupo_descColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_DESC");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_subgrupo_descColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_DESC");
			int articulo_unidad_med_idColumnIndex = reader.GetOrdinal("ARTICULO_UNIDAD_MED_ID");
			int articulo_unidad_med_descColumnIndex = reader.GetOrdinal("ARTICULO_UNIDAD_MED_DESC");
			int articulo_cantidad_por_cajaColumnIndex = reader.GetOrdinal("ARTICULO_CANTIDAD_POR_CAJA");
			int unidad_medidaColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA");
			int unidad_medida_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_DESCRIPCION");
			int cantidad_cajasColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS");
			int cantidad_unidadesColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDADES");
			int cantidad_por_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA");
			int cantidad_unitaria_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int porcentaje_descColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuesto_nombreColumnIndex = reader.GetOrdinal("IMPUESTO_NOMBRE");
			int impuesto_porcentajeColumnIndex = reader.GetOrdinal("IMPUESTO_PORCENTAJE");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cantidad_unitaria_facturadaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_FACTURADA");
			int monto_neto_unitarioColumnIndex = reader.GetOrdinal("MONTO_NETO_UNITARIO");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int monto_bruto_descontado_totalColumnIndex = reader.GetOrdinal("MONTO_BRUTO_DESCONTADO_TOTAL");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRESUPUESTOS_DET_INFO_COMPLETARow record = new PRESUPUESTOS_DET_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRESUPUESTO_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presupuesto_etapa_idColumnIndex)), 9);
					record.PRESUPUESTO_ETAPA_NOMBRE = Convert.ToString(reader.GetValue(presupuesto_etapa_nombreColumnIndex));
					record.PRESUPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presupuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(presupuesto_objetoColumnIndex))
						record.PRESUPUESTO_OBJETO = Convert.ToString(reader.GetValue(presupuesto_objetoColumnIndex));
					if(!reader.IsDBNull(monto_bruto_unitarioColumnIndex))
						record.MONTO_BRUTO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bruto_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_desc_internaColumnIndex))
						record.ARTICULO_DESC_INTERNA = Convert.ToString(reader.GetValue(articulo_desc_internaColumnIndex));
					if(!reader.IsDBNull(articulo_cod_empresaColumnIndex))
						record.ARTICULO_COD_EMPRESA = Convert.ToString(reader.GetValue(articulo_cod_empresaColumnIndex));
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_descColumnIndex))
						record.ARTICULO_FAMILIA_DESC = Convert.ToString(reader.GetValue(articulo_familia_descColumnIndex));
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_descColumnIndex))
						record.ARTICULO_GRUPO_DESC = Convert.ToString(reader.GetValue(articulo_grupo_descColumnIndex));
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_descColumnIndex))
						record.ARTICULO_SUBGRUPO_DESC = Convert.ToString(reader.GetValue(articulo_subgrupo_descColumnIndex));
					if(!reader.IsDBNull(articulo_unidad_med_idColumnIndex))
						record.ARTICULO_UNIDAD_MED_ID = Convert.ToString(reader.GetValue(articulo_unidad_med_idColumnIndex));
					if(!reader.IsDBNull(articulo_unidad_med_descColumnIndex))
						record.ARTICULO_UNIDAD_MED_DESC = Convert.ToString(reader.GetValue(articulo_unidad_med_descColumnIndex));
					if(!reader.IsDBNull(articulo_cantidad_por_cajaColumnIndex))
						record.ARTICULO_CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_cantidad_por_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medidaColumnIndex))
						record.UNIDAD_MEDIDA = Convert.ToString(reader.GetValue(unidad_medidaColumnIndex));
					if(!reader.IsDBNull(unidad_medida_descripcionColumnIndex))
						record.UNIDAD_MEDIDA_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_medida_descripcionColumnIndex));
					if(!reader.IsDBNull(cantidad_cajasColumnIndex))
						record.CANTIDAD_CAJAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajasColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unidadesColumnIndex))
						record.CANTIDAD_UNIDADES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidadesColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_cajaColumnIndex))
						record.CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_totalColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_totalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_descuentoColumnIndex))
						record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_descColumnIndex))
						record.PORCENTAJE_DESC = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_descColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_nombreColumnIndex))
						record.IMPUESTO_NOMBRE = Convert.ToString(reader.GetValue(impuesto_nombreColumnIndex));
					if(!reader.IsDBNull(impuesto_porcentajeColumnIndex))
						record.IMPUESTO_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cantidad_unitaria_facturadaColumnIndex))
						record.CANTIDAD_UNITARIA_FACTURADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_facturadaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_neto_unitarioColumnIndex))
						record.MONTO_NETO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_neto_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(monto_impuestoColumnIndex))
						record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_bruto_descontado_totalColumnIndex))
						record.MONTO_BRUTO_DESCONTADO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bruto_descontado_totalColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRESUPUESTOS_DET_INFO_COMPLETARow[])(recordList.ToArray(typeof(PRESUPUESTOS_DET_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> object.</returns>
		protected virtual PRESUPUESTOS_DET_INFO_COMPLETARow MapRow(DataRow row)
		{
			PRESUPUESTOS_DET_INFO_COMPLETARow mappedObject = new PRESUPUESTOS_DET_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRESUPUESTO_ETAPA_ID"
			dataColumn = dataTable.Columns["PRESUPUESTO_ETAPA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_ETAPA_ID = (decimal)row[dataColumn];
			// Column "PRESUPUESTO_ETAPA_NOMBRE"
			dataColumn = dataTable.Columns["PRESUPUESTO_ETAPA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_ETAPA_NOMBRE = (string)row[dataColumn];
			// Column "PRESUPUESTO_ID"
			dataColumn = dataTable.Columns["PRESUPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_ID = (decimal)row[dataColumn];
			// Column "PRESUPUESTO_OBJETO"
			dataColumn = dataTable.Columns["PRESUPUESTO_OBJETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_OBJETO = (string)row[dataColumn];
			// Column "MONTO_BRUTO_UNITARIO"
			dataColumn = dataTable.Columns["MONTO_BRUTO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO_UNITARIO = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_DESC_INTERNA"
			dataColumn = dataTable.Columns["ARTICULO_DESC_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESC_INTERNA = (string)row[dataColumn];
			// Column "ARTICULO_COD_EMPRESA"
			dataColumn = dataTable.Columns["ARTICULO_COD_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_COD_EMPRESA = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_DESC"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_DESC = (string)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_DESC"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_DESC = (string)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_DESC"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_DESC = (string)row[dataColumn];
			// Column "ARTICULO_UNIDAD_MED_ID"
			dataColumn = dataTable.Columns["ARTICULO_UNIDAD_MED_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_UNIDAD_MED_ID = (string)row[dataColumn];
			// Column "ARTICULO_UNIDAD_MED_DESC"
			dataColumn = dataTable.Columns["ARTICULO_UNIDAD_MED_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_UNIDAD_MED_DESC = (string)row[dataColumn];
			// Column "ARTICULO_CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["ARTICULO_CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_DESCRIPCION = (string)row[dataColumn];
			// Column "CANTIDAD_CAJAS"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDADES"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDADES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDADES = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESC"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_NOMBRE"
			dataColumn = dataTable.Columns["IMPUESTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_NOMBRE = (string)row[dataColumn];
			// Column "IMPUESTO_PORCENTAJE"
			dataColumn = dataTable.Columns["IMPUESTO_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_PORCENTAJE = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_FACTURADA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_FACTURADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_FACTURADA = (decimal)row[dataColumn];
			// Column "MONTO_NETO_UNITARIO"
			dataColumn = dataTable.Columns["MONTO_NETO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NETO_UNITARIO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO_DESCONTADO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_BRUTO_DESCONTADO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO_DESCONTADO_TOTAL = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRESUPUESTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRESUPUESTOS_DET_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_ETAPA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_ETAPA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_OBJETO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO_UNITARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESC_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_COD_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_DESC", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_DESC", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_DESC", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_UNIDAD_MED_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_UNIDAD_MED_DESC", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDADES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_PORCENTAJE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_FACTURADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_NETO_UNITARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO_DESCONTADO_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
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

				case "PRESUPUESTO_ETAPA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRESUPUESTO_ETAPA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRESUPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRESUPUESTO_OBJETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_BRUTO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DESC_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_COD_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_UNIDAD_MED_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_UNIDAD_MED_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CAJAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDADES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_UNITARIA_FACTURADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NETO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO_DESCONTADO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRESUPUESTOS_DET_INFO_COMPLETACollection_Base class
}  // End of namespace
