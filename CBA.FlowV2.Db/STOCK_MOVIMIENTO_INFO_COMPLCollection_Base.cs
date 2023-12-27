// <fileinfo name="STOCK_MOVIMIENTO_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_MOVIMIENTO_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_MOVIMIENTO_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_MOVIMIENTO_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";
		public const string ESTADO_IDColumnName = "ESTADO_ID";
		public const string ESTADO_ANTERIOR_IDColumnName = "ESTADO_ANTERIOR_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_NOMBREColumnName = "DEPOSITO_NOMBRE";
		public const string DEPOSITO_ABREVIATURAColumnName = "DEPOSITO_ABREVIATURA";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_FAMILIA_DESCRIPCIONColumnName = "ARTICULO_FAMILIA_DESCRIPCION";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_GRUPO_DESCRIPCIONColumnName = "ARTICULO_GRUPO_DESCRIPCION";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_SUBGRUPO_DESCRIPCIONColumnName = "ARTICULO_SUBGRUPO_DESCRIPCION";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTEColumnName = "LOTE";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string FECHA_FORMULARIOColumnName = "FECHA_FORMULARIO";
		public const string EXISTENCIAColumnName = "EXISTENCIA";
		public const string COSTOColumnName = "COSTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_COTIZACION_MONEDAColumnName = "COSTO_COTIZACION_MONEDA";
		public const string COSTO_ORIGENColumnName = "COSTO_ORIGEN";
		public const string COSTO_MONEDA_ORIGEN_IDColumnName = "COSTO_MONEDA_ORIGEN_ID";
		public const string COSTO_COTIZACION_MONEDA_ORIGENColumnName = "COSTO_COTIZACION_MONEDA_ORIGEN";
		public const string COSTO_MONEDA_NOMBREColumnName = "COSTO_MONEDA_NOMBRE";
		public const string MONEDA_COSTO_SOMBOLOColumnName = "MONEDA_COSTO_SOMBOLO";
		public const string MON_COSTO_CADE_DECIMALESColumnName = "MON_COSTO_CADE_DECIMALES";
		public const string MON_COSTO_CANT_DECIMALESColumnName = "MON_COSTO_CANT_DECIMALES";
		public const string COSTO_PPPColumnName = "COSTO_PPP";
		public const string DESTINOColumnName = "DESTINO";
		public const string ESTADOColumnName = "ESTADO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string REGISTRO_IDColumnName = "REGISTRO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_MOVIMIENTO_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_MOVIMIENTO_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_MOVIMIENTO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_MOVIMIENTO_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_MOVIMIENTO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_MOVIMIENTO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_MOVIMIENTO_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_MOVIMIENTO_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		public STOCK_MOVIMIENTO_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_MOVIMIENTO_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_MOVIMIENTO_INFO_COMPL";
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
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_MOVIMIENTO_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_MOVIMIENTO_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> objects.</returns>
		protected virtual STOCK_MOVIMIENTO_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");
			int estado_idColumnIndex = reader.GetOrdinal("ESTADO_ID");
			int estado_anterior_idColumnIndex = reader.GetOrdinal("ESTADO_ANTERIOR_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_NOMBRE");
			int deposito_abreviaturaColumnIndex = reader.GetOrdinal("DEPOSITO_ABREVIATURA");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_familia_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_DESCRIPCION");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_grupo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_DESCRIPCION");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_subgrupo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_DESCRIPCION");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int fecha_formularioColumnIndex = reader.GetOrdinal("FECHA_FORMULARIO");
			int existenciaColumnIndex = reader.GetOrdinal("EXISTENCIA");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_cotizacion_monedaColumnIndex = reader.GetOrdinal("COSTO_COTIZACION_MONEDA");
			int costo_origenColumnIndex = reader.GetOrdinal("COSTO_ORIGEN");
			int costo_moneda_origen_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ORIGEN_ID");
			int costo_cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COSTO_COTIZACION_MONEDA_ORIGEN");
			int costo_moneda_nombreColumnIndex = reader.GetOrdinal("COSTO_MONEDA_NOMBRE");
			int moneda_costo_somboloColumnIndex = reader.GetOrdinal("MONEDA_COSTO_SOMBOLO");
			int mon_costo_cade_decimalesColumnIndex = reader.GetOrdinal("MON_COSTO_CADE_DECIMALES");
			int mon_costo_cant_decimalesColumnIndex = reader.GetOrdinal("MON_COSTO_CANT_DECIMALES");
			int costo_pppColumnIndex = reader.GetOrdinal("COSTO_PPP");
			int destinoColumnIndex = reader.GetOrdinal("DESTINO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int registro_idColumnIndex = reader.GetOrdinal("REGISTRO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_MOVIMIENTO_INFO_COMPLRow record = new STOCK_MOVIMIENTO_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));
					if(!reader.IsDBNull(estado_idColumnIndex))
						record.ESTADO_ID = Convert.ToString(reader.GetValue(estado_idColumnIndex));
					if(!reader.IsDBNull(estado_anterior_idColumnIndex))
						record.ESTADO_ANTERIOR_ID = Convert.ToString(reader.GetValue(estado_anterior_idColumnIndex));
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(deposito_nombreColumnIndex));
					record.DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(deposito_abreviaturaColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_abreviaturaColumnIndex))
						record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(entidad_idColumnIndex))
						record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_descripcionColumnIndex))
						record.ARTICULO_FAMILIA_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_familia_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_descripcionColumnIndex))
						record.ARTICULO_GRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_grupo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_descripcionColumnIndex))
						record.ARTICULO_SUBGRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_subgrupo_descripcionColumnIndex));
					record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					record.FECHA_FORMULARIO = Convert.ToDateTime(reader.GetValue(fecha_formularioColumnIndex));
					if(!reader.IsDBNull(existenciaColumnIndex))
						record.EXISTENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(existenciaColumnIndex)), 9);
					record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					record.COSTO_COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_cotizacion_monedaColumnIndex)), 9);
					record.COSTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(costo_origenColumnIndex)), 9);
					record.COSTO_MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_origen_idColumnIndex)), 9);
					record.COSTO_COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(costo_cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_nombreColumnIndex))
						record.COSTO_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(costo_moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_costo_somboloColumnIndex))
						record.MONEDA_COSTO_SOMBOLO = Convert.ToString(reader.GetValue(moneda_costo_somboloColumnIndex));
					if(!reader.IsDBNull(mon_costo_cade_decimalesColumnIndex))
						record.MON_COSTO_CADE_DECIMALES = Convert.ToString(reader.GetValue(mon_costo_cade_decimalesColumnIndex));
					if(!reader.IsDBNull(mon_costo_cant_decimalesColumnIndex))
						record.MON_COSTO_CANT_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(mon_costo_cant_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(costo_pppColumnIndex))
						record.COSTO_PPP = Math.Round(Convert.ToDecimal(reader.GetValue(costo_pppColumnIndex)), 9);
					if(!reader.IsDBNull(destinoColumnIndex))
						record.DESTINO = Convert.ToString(reader.GetValue(destinoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.REGISTRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(registro_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_MOVIMIENTO_INFO_COMPLRow[])(recordList.ToArray(typeof(STOCK_MOVIMIENTO_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> object.</returns>
		protected virtual STOCK_MOVIMIENTO_INFO_COMPLRow MapRow(DataRow row)
		{
			STOCK_MOVIMIENTO_INFO_COMPLRow mappedObject = new STOCK_MOVIMIENTO_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "ESTADO_ID"
			dataColumn = dataTable.Columns["ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ID = (string)row[dataColumn];
			// Column "ESTADO_ANTERIOR_ID"
			dataColumn = dataTable.Columns["ESTADO_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ANTERIOR_ID = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "DEPOSITO_ABREVIATURA"
			dataColumn = dataTable.Columns["DEPOSITO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FORMULARIO"
			dataColumn = dataTable.Columns["FECHA_FORMULARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FORMULARIO = (System.DateTime)row[dataColumn];
			// Column "EXISTENCIA"
			dataColumn = dataTable.Columns["EXISTENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COSTO_COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "COSTO_ORIGEN"
			dataColumn = dataTable.Columns["COSTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ORIGEN = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COSTO_COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COSTO_COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["COSTO_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_COSTO_SOMBOLO"
			dataColumn = dataTable.Columns["MONEDA_COSTO_SOMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COSTO_SOMBOLO = (string)row[dataColumn];
			// Column "MON_COSTO_CADE_DECIMALES"
			dataColumn = dataTable.Columns["MON_COSTO_CADE_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MON_COSTO_CADE_DECIMALES = (string)row[dataColumn];
			// Column "MON_COSTO_CANT_DECIMALES"
			dataColumn = dataTable.Columns["MON_COSTO_CANT_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MON_COSTO_CANT_DECIMALES = (decimal)row[dataColumn];
			// Column "COSTO_PPP"
			dataColumn = dataTable.Columns["COSTO_PPP"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_PPP = (decimal)row[dataColumn];
			// Column "DESTINO"
			dataColumn = dataTable.Columns["DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESTINO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "REGISTRO_ID"
			dataColumn = dataTable.Columns["REGISTRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_MOVIMIENTO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_MOVIMIENTO_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ANTERIOR_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 97;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FORMULARIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COSTO_SOMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MON_COSTO_CADE_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MON_COSTO_CANT_DECIMALES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_PPP", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESTINO", typeof(string));
			dataColumn.MaxLength = 308;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REGISTRO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_ANTERIOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FORMULARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EXISTENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_COSTO_SOMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MON_COSTO_CADE_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MON_COSTO_CANT_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_PPP":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGISTRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_MOVIMIENTO_INFO_COMPLCollection_Base class
}  // End of namespace
