// <fileinfo name="NOTAS_CRED_PRO_DET_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="NOTAS_CRED_PRO_DET_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOTAS_CRED_PRO_DET_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CRED_PRO_DET_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOTA_CREDITO_PROVEEDOR_IDColumnName = "NOTA_CREDITO_PROVEEDOR_ID";
		public const string FACTURA_PROVEEDOR_IDColumnName = "FACTURA_PROVEEDOR_ID";
		public const string NOTA_CREDITO_PROVEEDOR_CASO_IDColumnName = "NOTA_CREDITO_PROVEEDOR_CASO_ID";
		public const string NOTA_CRED_PROV_COMPROBANTEColumnName = "NOTA_CRED_PROV_COMPROBANTE";
		public const string NOTA_CREDITO_PROVEEDOR_FECHAColumnName = "NOTA_CREDITO_PROVEEDOR_FECHA";
		public const string FACTURA_NRO_COMPROBANTEColumnName = "FACTURA_NRO_COMPROBANTE";
		public const string FACTURA_CASO_IDColumnName = "FACTURA_CASO_ID";
		public const string FACTURA_FECHAColumnName = "FACTURA_FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_COTIZACIONColumnName = "MONEDA_COTIZACION";
		public const string FACTURA_PROVEEDOR_DETALLE_IDColumnName = "FACTURA_PROVEEDOR_DETALLE_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_NOMBREColumnName = "DEPOSITO_NOMBRE";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTEColumnName = "LOTE";
		public const string COSTO_UNITARIOColumnName = "COSTO_UNITARIO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string IMPUESTO_PORCENTAJEColumnName = "IMPUESTO_PORCENTAJE";
		public const string TOTALColumnName = "TOTAL";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string IMPUESTO_MONTOColumnName = "IMPUESTO_MONTO";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string NOMBRE_IMPUESTOColumnName = "NOMBRE_IMPUESTO";
		public const string TEXTOColumnName = "TEXTO";
		public const string MONTO_CONCEPTOColumnName = "MONTO_CONCEPTO";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CRED_PRO_DET_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOTAS_CRED_PRO_DET_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOTAS_CRED_PRO_DET_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		public virtual NOTAS_CRED_PRO_DET_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOTAS_CRED_PRO_DET_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOTAS_CRED_PRO_DET_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOTAS_CRED_PRO_DET_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOTAS_CRED_PRO_DET_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		public NOTAS_CRED_PRO_DET_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		public virtual NOTAS_CRED_PRO_DET_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOTAS_CRED_PRO_DET_INF_COMP";
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
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		protected NOTAS_CRED_PRO_DET_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		protected NOTAS_CRED_PRO_DET_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> objects.</returns>
		protected virtual NOTAS_CRED_PRO_DET_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nota_credito_proveedor_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR_ID");
			int factura_proveedor_idColumnIndex = reader.GetOrdinal("FACTURA_PROVEEDOR_ID");
			int nota_credito_proveedor_caso_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR_CASO_ID");
			int nota_cred_prov_comprobanteColumnIndex = reader.GetOrdinal("NOTA_CRED_PROV_COMPROBANTE");
			int nota_credito_proveedor_fechaColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR_FECHA");
			int factura_nro_comprobanteColumnIndex = reader.GetOrdinal("FACTURA_NRO_COMPROBANTE");
			int factura_caso_idColumnIndex = reader.GetOrdinal("FACTURA_CASO_ID");
			int factura_fechaColumnIndex = reader.GetOrdinal("FACTURA_FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_COTIZACION");
			int factura_proveedor_detalle_idColumnIndex = reader.GetOrdinal("FACTURA_PROVEEDOR_DETALLE_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_NOMBRE");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int costo_unitarioColumnIndex = reader.GetOrdinal("COSTO_UNITARIO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int impuesto_porcentajeColumnIndex = reader.GetOrdinal("IMPUESTO_PORCENTAJE");
			int totalColumnIndex = reader.GetOrdinal("TOTAL");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int impuesto_montoColumnIndex = reader.GetOrdinal("IMPUESTO_MONTO");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int nombre_impuestoColumnIndex = reader.GetOrdinal("NOMBRE_IMPUESTO");
			int textoColumnIndex = reader.GetOrdinal("TEXTO");
			int monto_conceptoColumnIndex = reader.GetOrdinal("MONTO_CONCEPTO");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOTAS_CRED_PRO_DET_INF_COMPRow record = new NOTAS_CRED_PRO_DET_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOTA_CREDITO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_proveedor_idColumnIndex)), 9);
					record.FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nota_credito_proveedor_caso_idColumnIndex))
						record.NOTA_CREDITO_PROVEEDOR_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_proveedor_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(nota_cred_prov_comprobanteColumnIndex))
						record.NOTA_CRED_PROV_COMPROBANTE = Convert.ToString(reader.GetValue(nota_cred_prov_comprobanteColumnIndex));
					if(!reader.IsDBNull(nota_credito_proveedor_fechaColumnIndex))
						record.NOTA_CREDITO_PROVEEDOR_FECHA = Convert.ToDateTime(reader.GetValue(nota_credito_proveedor_fechaColumnIndex));
					if(!reader.IsDBNull(factura_nro_comprobanteColumnIndex))
						record.FACTURA_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(factura_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(factura_caso_idColumnIndex))
						record.FACTURA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_fechaColumnIndex))
						record.FACTURA_FECHA = Convert.ToDateTime(reader.GetValue(factura_fechaColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cotizacionColumnIndex))
						record.MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(factura_proveedor_detalle_idColumnIndex))
						record.FACTURA_PROVEEDOR_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_proveedor_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_nombreColumnIndex))
						record.DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(deposito_nombreColumnIndex));
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
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					if(!reader.IsDBNull(costo_unitarioColumnIndex))
						record.COSTO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_porcentajeColumnIndex))
						record.IMPUESTO_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(totalColumnIndex))
						record.TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(totalColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(impuesto_montoColumnIndex))
						record.IMPUESTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_montoColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_impuestoColumnIndex))
						record.NOMBRE_IMPUESTO = Convert.ToString(reader.GetValue(nombre_impuestoColumnIndex));
					if(!reader.IsDBNull(textoColumnIndex))
						record.TEXTO = Convert.ToString(reader.GetValue(textoColumnIndex));
					if(!reader.IsDBNull(monto_conceptoColumnIndex))
						record.MONTO_CONCEPTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_conceptoColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOTAS_CRED_PRO_DET_INF_COMPRow[])(recordList.ToArray(typeof(NOTAS_CRED_PRO_DET_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> object.</returns>
		protected virtual NOTAS_CRED_PRO_DET_INF_COMPRow MapRow(DataRow row)
		{
			NOTAS_CRED_PRO_DET_INF_COMPRow mappedObject = new NOTAS_CRED_PRO_DET_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR_CASO_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR_CASO_ID = (decimal)row[dataColumn];
			// Column "NOTA_CRED_PROV_COMPROBANTE"
			dataColumn = dataTable.Columns["NOTA_CRED_PROV_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CRED_PROV_COMPROBANTE = (string)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR_FECHA"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR_FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["FACTURA_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FACTURA_CASO_ID"
			dataColumn = dataTable.Columns["FACTURA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CASO_ID = (decimal)row[dataColumn];
			// Column "FACTURA_FECHA"
			dataColumn = dataTable.Columns["FACTURA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "FACTURA_PROVEEDOR_DETALLE_ID"
			dataColumn = dataTable.Columns["FACTURA_PROVEEDOR_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PROVEEDOR_DETALLE_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NOMBRE = (string)row[dataColumn];
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
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "COSTO_UNITARIO"
			dataColumn = dataTable.Columns["COSTO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_UNITARIO = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "IMPUESTO_PORCENTAJE"
			dataColumn = dataTable.Columns["IMPUESTO_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_PORCENTAJE = (decimal)row[dataColumn];
			// Column "TOTAL"
			dataColumn = dataTable.Columns["TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "IMPUESTO_MONTO"
			dataColumn = dataTable.Columns["IMPUESTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_MONTO = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_IMPUESTO"
			dataColumn = dataTable.Columns["NOMBRE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_IMPUESTO = (string)row[dataColumn];
			// Column "TEXTO"
			dataColumn = dataTable.Columns["TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO = (string)row[dataColumn];
			// Column "MONTO_CONCEPTO"
			dataColumn = dataTable.Columns["MONTO_CONCEPTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CONCEPTO = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOTAS_CRED_PRO_DET_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOTAS_CRED_PRO_DET_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CRED_PROV_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_PROVEEDOR_DETALLE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_UNITARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_PORCENTAJE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CONCEPTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
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

				case "NOTA_CREDITO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_PROVEEDOR_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CRED_PROV_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOTA_CREDITO_PROVEEDOR_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_PROVEEDOR_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_CONCEPTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOTAS_CRED_PRO_DET_INF_COMPCollection_Base class
}  // End of namespace
