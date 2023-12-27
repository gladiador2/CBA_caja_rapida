// <fileinfo name="USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="USO_DE_INSUMOS_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="USO_DE_INSUMOS_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string USO_DE_INSUMO_IDColumnName = "USO_DE_INSUMO_ID";
		public const string ARTICULO_LOTE_IDColumnName = "ARTICULO_LOTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_LOTE_DESCRIPCIONColumnName = "ARTICULO_LOTE_DESCRIPCION";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_TOTALColumnName = "COSTO_TOTAL";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_NOMBREColumnName = "COSTO_MONEDA_NOMBRE";
		public const string COSTO_MONEDA_SIMBOLOColumnName = "COSTO_MONEDA_SIMBOLO";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string UNIDAD_DESTINO_DESCRIPCIONColumnName = "UNIDAD_DESTINO_DESCRIPCION";
		public const string FACTOR_DE_CONVERSIONColumnName = "FACTOR_DE_CONVERSION";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGENColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string VALOR_MEDICIONColumnName = "VALOR_MEDICION";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string UNIDAD_ORIGEN_DESCRIPCIONColumnName = "UNIDAD_ORIGEN_DESCRIPCION";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string SUCURSA_DESTINO_NOMBREColumnName = "SUCURSA_DESTINO_NOMBRE";
		public const string PROVEEDOR_ASIGNADO_IDColumnName = "PROVEEDOR_ASIGNADO_ID";
		public const string PROVEEDOR_ASIG_RAZON_SOCIALColumnName = "PROVEEDOR_ASIG_RAZON_SOCIAL";
		public const string PROVEEDOR_ASIGNADO_CODIGOColumnName = "PROVEEDOR_ASIGNADO_CODIGO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>USO_DE_INSUMOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>USO_DE_INSUMOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>USO_DE_INSUMOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public USO_DE_INSUMOS_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			USO_DE_INSUMOS_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		public USO_DE_INSUMOS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.USO_DE_INSUMOS_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected USO_DE_INSUMOS_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected USO_DE_INSUMOS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual USO_DE_INSUMOS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int uso_de_insumo_idColumnIndex = reader.GetOrdinal("USO_DE_INSUMO_ID");
			int articulo_lote_idColumnIndex = reader.GetOrdinal("ARTICULO_LOTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_lote_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_LOTE_DESCRIPCION");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_totalColumnIndex = reader.GetOrdinal("COSTO_TOTAL");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_nombreColumnIndex = reader.GetOrdinal("COSTO_MONEDA_NOMBRE");
			int costo_moneda_simboloColumnIndex = reader.GetOrdinal("COSTO_MONEDA_SIMBOLO");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int unidad_destino_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_DESCRIPCION");
			int factor_de_conversionColumnIndex = reader.GetOrdinal("FACTOR_DE_CONVERSION");
			int cantidad_unitaria_total_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int valor_medicionColumnIndex = reader.GetOrdinal("VALOR_MEDICION");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int unidad_origen_descripcionColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_DESCRIPCION");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int sucursa_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSA_DESTINO_NOMBRE");
			int proveedor_asignado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ASIGNADO_ID");
			int proveedor_asig_razon_socialColumnIndex = reader.GetOrdinal("PROVEEDOR_ASIG_RAZON_SOCIAL");
			int proveedor_asignado_codigoColumnIndex = reader.GetOrdinal("PROVEEDOR_ASIGNADO_CODIGO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					USO_DE_INSUMOS_DET_INFO_COMPLRow record = new USO_DE_INSUMOS_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.USO_DE_INSUMO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(uso_de_insumo_idColumnIndex)), 9);
					record.ARTICULO_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_lote_descripcionColumnIndex))
						record.ARTICULO_LOTE_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_lote_descripcionColumnIndex));
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					record.COSTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_totalColumnIndex)), 9);
					record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					record.COSTO_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(costo_moneda_nombreColumnIndex));
					record.COSTO_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(costo_moneda_simboloColumnIndex));
					record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					if(!reader.IsDBNull(unidad_destino_descripcionColumnIndex))
						record.UNIDAD_DESTINO_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_destino_descripcionColumnIndex));
					record.FACTOR_DE_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_de_conversionColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origenColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(valor_medicionColumnIndex))
						record.VALOR_MEDICION = Math.Round(Convert.ToDecimal(reader.GetValue(valor_medicionColumnIndex)), 9);
					record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_origen_descripcionColumnIndex))
						record.UNIDAD_ORIGEN_DESCRIPCION = Convert.ToString(reader.GetValue(unidad_origen_descripcionColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursa_destino_nombreColumnIndex))
						record.SUCURSA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursa_destino_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_asignado_idColumnIndex))
						record.PROVEEDOR_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_asig_razon_socialColumnIndex))
						record.PROVEEDOR_ASIG_RAZON_SOCIAL = Convert.ToString(reader.GetValue(proveedor_asig_razon_socialColumnIndex));
					if(!reader.IsDBNull(proveedor_asignado_codigoColumnIndex))
						record.PROVEEDOR_ASIGNADO_CODIGO = Convert.ToString(reader.GetValue(proveedor_asignado_codigoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (USO_DE_INSUMOS_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(USO_DE_INSUMOS_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual USO_DE_INSUMOS_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			USO_DE_INSUMOS_DET_INFO_COMPLRow mappedObject = new USO_DE_INSUMOS_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "USO_DE_INSUMO_ID"
			dataColumn = dataTable.Columns["USO_DE_INSUMO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_DE_INSUMO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_LOTE_ID"
			dataColumn = dataTable.Columns["ARTICULO_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LOTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
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
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_LOTE_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_LOTE_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LOTE_DESCRIPCION = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
			// Column "COSTO_TOTAL"
			dataColumn = dataTable.Columns["COSTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["COSTO_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "COSTO_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["COSTO_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "UNIDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_ID = (string)row[dataColumn];
			// Column "UNIDAD_DESTINO_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_DESCRIPCION = (string)row[dataColumn];
			// Column "FACTOR_DE_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_DE_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_DE_CONVERSION = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "VALOR_MEDICION"
			dataColumn = dataTable.Columns["VALOR_MEDICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MEDICION = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_DESCRIPCION"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_DESCRIPCION = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_ASIGNADO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ASIG_RAZON_SOCIAL"
			dataColumn = dataTable.Columns["PROVEEDOR_ASIG_RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ASIG_RAZON_SOCIAL = (string)row[dataColumn];
			// Column "PROVEEDOR_ASIGNADO_CODIGO"
			dataColumn = dataTable.Columns["PROVEEDOR_ASIGNADO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ASIGNADO_CODIGO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>USO_DE_INSUMOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "USO_DE_INSUMOS_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_DE_INSUMO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LOTE_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_DE_CONVERSION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_MEDICION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ASIGNADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ASIG_RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ASIGNADO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
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

				case "USO_DE_INSUMO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
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

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_LOTE_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_DESTINO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTOR_DE_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MEDICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ASIG_RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ASIGNADO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base class
}  // End of namespace
