// <fileinfo name="ORDENES_PAGO_DET_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_DET_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_PAGO_DET_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_DET_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string SUCURSAL_DESTINO_NOMBREColumnName = "SUCURSAL_DESTINO_NOMBRE";
		public const string SUCURSAL_DESTINO_ABREVIATURAColumnName = "SUCURSAL_DESTINO_ABREVIATURA";
		public const string CTACTE_CAJA_TESO_DESTINO_IDColumnName = "CTACTE_CAJA_TESO_DESTINO_ID";
		public const string CTACTE_CAJA_TESO_DEST_NOMBREColumnName = "CTACTE_CAJA_TESO_DEST_NOMBRE";
		public const string CTACTE_CAJA_TESO_DEST_ABREVColumnName = "CTACTE_CAJA_TESO_DEST_ABREV";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string CTACTE_FONDO_FIJO_NOMBREColumnName = "CTACTE_FONDO_FIJO_NOMBRE";
		public const string CTACTE_FONDO_FIJO_ABREVIATURAColumnName = "CTACTE_FONDO_FIJO_ABREVIATURA";
		public const string CTACTE_PROVEEDOR_IDColumnName = "CTACTE_PROVEEDOR_ID";
		public const string CTACTE_CONCEPTO_DESCRIPCIONColumnName = "CTACTE_CONCEPTO_DESCRIPCION";
		public const string CTACTE_PROVEEDOR_CASO_IDColumnName = "CTACTE_PROVEEDOR_CASO_ID";
		public const string CTACTE_PERSONA_CASO_IDColumnName = "CTACTE_PERSONA_CASO_ID";
		public const string CTACTE_FECHA_VENCIMIENTOColumnName = "CTACTE_FECHA_VENCIMIENTO";
		public const string FACTURA_FECHA_EMISIONColumnName = "FACTURA_FECHA_EMISION";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGEN_NOMBREColumnName = "MONEDA_ORIGEN_NOMBRE";
		public const string MONEDA_ORIGEN_SIMBOLOColumnName = "MONEDA_ORIGEN_SIMBOLO";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string FLUJO_REFERIDO_IDColumnName = "FLUJO_REFERIDO_ID";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";
		public const string FLUJO_DESCRIPCION_IMPRESIONColumnName = "FLUJO_DESCRIPCION_IMPRESION";
		public const string CASO_REFERIDO_IDColumnName = "CASO_REFERIDO_ID";
		public const string CASO_REFERIDO_ESTADO_IDColumnName = "CASO_REFERIDO_ESTADO_ID";
		public const string LIQUIDACION_IDColumnName = "LIQUIDACION_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_DET_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_PAGO_DET_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_PAGO_DET_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DET_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_PAGO_DET_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_PAGO_DET_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_PAGO_DET_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_PAGO_DET_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		public ORDENES_PAGO_DET_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DET_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_PAGO_DET_INFO_COMP";
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		protected ORDENES_PAGO_DET_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		protected ORDENES_PAGO_DET_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> objects.</returns>
		protected virtual ORDENES_PAGO_DET_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int sucursal_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_NOMBRE");
			int sucursal_destino_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ABREVIATURA");
			int ctacte_caja_teso_destino_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_DESTINO_ID");
			int ctacte_caja_teso_dest_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_DEST_NOMBRE");
			int ctacte_caja_teso_dest_abrevColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_DEST_ABREV");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int ctacte_fondo_fijo_nombreColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_NOMBRE");
			int ctacte_fondo_fijo_abreviaturaColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ABREVIATURA");
			int ctacte_proveedor_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_ID");
			int ctacte_concepto_descripcionColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_DESCRIPCION");
			int ctacte_proveedor_caso_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_CASO_ID");
			int ctacte_persona_caso_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_CASO_ID");
			int ctacte_fecha_vencimientoColumnIndex = reader.GetOrdinal("CTACTE_FECHA_VENCIMIENTO");
			int factura_fecha_emisionColumnIndex = reader.GetOrdinal("FACTURA_FECHA_EMISION");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origen_nombreColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_NOMBRE");
			int moneda_origen_simboloColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_SIMBOLO");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int flujo_referido_idColumnIndex = reader.GetOrdinal("FLUJO_REFERIDO_ID");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");
			int flujo_descripcion_impresionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION_IMPRESION");
			int caso_referido_idColumnIndex = reader.GetOrdinal("CASO_REFERIDO_ID");
			int caso_referido_estado_idColumnIndex = reader.GetOrdinal("CASO_REFERIDO_ESTADO_ID");
			int liquidacion_idColumnIndex = reader.GetOrdinal("LIQUIDACION_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_PAGO_DET_INFO_COMPRow record = new ORDENES_PAGO_DET_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_nombreColumnIndex))
						record.SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_destino_abreviaturaColumnIndex))
						record.SUCURSAL_DESTINO_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_destino_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_teso_destino_idColumnIndex))
						record.CTACTE_CAJA_TESO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_teso_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_teso_dest_nombreColumnIndex))
						record.CTACTE_CAJA_TESO_DEST_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_teso_dest_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_teso_dest_abrevColumnIndex))
						record.CTACTE_CAJA_TESO_DEST_ABREV = Convert.ToString(reader.GetValue(ctacte_caja_teso_dest_abrevColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_nombreColumnIndex))
						record.CTACTE_FONDO_FIJO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_fondo_fijo_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_abreviaturaColumnIndex))
						record.CTACTE_FONDO_FIJO_ABREVIATURA = Convert.ToString(reader.GetValue(ctacte_fondo_fijo_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ctacte_proveedor_idColumnIndex))
						record.CTACTE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_concepto_descripcionColumnIndex))
						record.CTACTE_CONCEPTO_DESCRIPCION = Convert.ToString(reader.GetValue(ctacte_concepto_descripcionColumnIndex));
					if(!reader.IsDBNull(ctacte_proveedor_caso_idColumnIndex))
						record.CTACTE_PROVEEDOR_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_caso_idColumnIndex))
						record.CTACTE_PERSONA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fecha_vencimientoColumnIndex))
						record.CTACTE_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(ctacte_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(factura_fecha_emisionColumnIndex))
						record.FACTURA_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(factura_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(moneda_origen_nombreColumnIndex));
					record.MONEDA_ORIGEN_SIMBOLO = Convert.ToString(reader.GetValue(moneda_origen_simboloColumnIndex));
					if(!reader.IsDBNull(monto_origenColumnIndex))
						record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_origenColumnIndex))
						record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_destinoColumnIndex))
						record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_referido_idColumnIndex))
						record.FLUJO_REFERIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_referido_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));
					if(!reader.IsDBNull(flujo_descripcion_impresionColumnIndex))
						record.FLUJO_DESCRIPCION_IMPRESION = Convert.ToString(reader.GetValue(flujo_descripcion_impresionColumnIndex));
					if(!reader.IsDBNull(caso_referido_idColumnIndex))
						record.CASO_REFERIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_referido_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_referido_estado_idColumnIndex))
						record.CASO_REFERIDO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_referido_estado_idColumnIndex));
					if(!reader.IsDBNull(liquidacion_idColumnIndex))
						record.LIQUIDACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(liquidacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_PAGO_DET_INFO_COMPRow[])(recordList.ToArray(typeof(ORDENES_PAGO_DET_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> object.</returns>
		protected virtual ORDENES_PAGO_DET_INFO_COMPRow MapRow(DataRow row)
		{
			ORDENES_PAGO_DET_INFO_COMPRow mappedObject = new ORDENES_PAGO_DET_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_DEST_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_DEST_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_DEST_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_DEST_ABREV"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_DEST_ABREV"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_DEST_ABREV = (string)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ABREVIATURA"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_DESCRIPCION"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_DESCRIPCION = (string)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_CASO_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_CASO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_CASO_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_CASO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CTACTE_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FACTURA_FECHA_EMISION"
			dataColumn = dataTable.Columns["FACTURA_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_SIMBOLO = (string)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "FLUJO_REFERIDO_ID"
			dataColumn = dataTable.Columns["FLUJO_REFERIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_REFERIDO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "FLUJO_DESCRIPCION_IMPRESION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION_IMPRESION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION_IMPRESION = (string)row[dataColumn];
			// Column "CASO_REFERIDO_ID"
			dataColumn = dataTable.Columns["CASO_REFERIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_REFERIDO_ID = (decimal)row[dataColumn];
			// Column "CASO_REFERIDO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_REFERIDO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_REFERIDO_ESTADO_ID = (string)row[dataColumn];
			// Column "LIQUIDACION_ID"
			dataColumn = dataTable.Columns["LIQUIDACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIQUIDACION_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_PAGO_DET_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_PAGO_DET_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_DEST_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_DEST_ABREV", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_REFERIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 63;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION_IMPRESION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_REFERIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_REFERIDO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LIQUIDACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESO_DEST_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESO_DEST_ABREV":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_FONDO_FIJO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PROVEEDOR_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_REFERIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_DESCRIPCION_IMPRESION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_REFERIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_REFERIDO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIQUIDACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_PAGO_DET_INFO_COMPCollection_Base class
}  // End of namespace
