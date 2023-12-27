// <fileinfo name="CTACTE_PAGARES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGARES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CANTIDAD_PAGARESColumnName = "CANTIDAD_PAGARES";
		public const string CANTIDAD_PAGARES_RESTANTESColumnName = "CANTIDAD_PAGARES_RESTANTES";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string MONTO_SALDOColumnName = "MONTO_SALDO";
		public const string MONTO_VENCIDOColumnName = "MONTO_VENCIDO";
		public const string ESTADOColumnName = "ESTADO";
		public const string JUEGO_PAGARES_APROBADOColumnName = "JUEGO_PAGARES_APROBADO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string NOMBRE_DEUDORColumnName = "NOMBRE_DEUDOR";
		public const string DOCUMENTO_DEUDORColumnName = "DOCUMENTO_DEUDOR";
		public const string TELEFONO_DEUDORColumnName = "TELEFONO_DEUDOR";
		public const string DIRECCION_DEUDORColumnName = "DIRECCION_DEUDOR";
		public const string NOMBRE_CODEUDORColumnName = "NOMBRE_CODEUDOR";
		public const string DOCUMENTO_CODEUDORColumnName = "DOCUMENTO_CODEUDOR";
		public const string TELEFONO_CODEUDORColumnName = "TELEFONO_CODEUDOR";
		public const string DIRECCION_CODEUDORColumnName = "DIRECCION_CODEUDOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string DOCUMENTO_BENEFICIARIOColumnName = "DOCUMENTO_BENEFICIARIO";
		public const string TELEFONO_BENEFICIARIOColumnName = "TELEFONO_BENEFICIARIO";
		public const string DIRECCION_BENEFICIARIOColumnName = "DIRECCION_BENEFICIARIO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string FECHA_FIRMAColumnName = "FECHA_FIRMA";
		public const string FECHA_ANULADOColumnName = "FECHA_ANULADO";
		public const string USUARIO_ANULADO_IDColumnName = "USUARIO_ANULADO_ID";
		public const string GARANTIAColumnName = "GARANTIA";
		public const string CASO_GARANTIA_IDColumnName = "CASO_GARANTIA_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGARES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGARES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_PAGARES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGARES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGARES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGARES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGARES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		public CTACTE_PAGARES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_PAGARES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGARES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_PAGARES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_PAGARES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTACTE_PAGARES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int cantidad_pagaresColumnIndex = reader.GetOrdinal("CANTIDAD_PAGARES");
			int cantidad_pagares_restantesColumnIndex = reader.GetOrdinal("CANTIDAD_PAGARES_RESTANTES");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int monto_saldoColumnIndex = reader.GetOrdinal("MONTO_SALDO");
			int monto_vencidoColumnIndex = reader.GetOrdinal("MONTO_VENCIDO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int juego_pagares_aprobadoColumnIndex = reader.GetOrdinal("JUEGO_PAGARES_APROBADO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int nombre_deudorColumnIndex = reader.GetOrdinal("NOMBRE_DEUDOR");
			int documento_deudorColumnIndex = reader.GetOrdinal("DOCUMENTO_DEUDOR");
			int telefono_deudorColumnIndex = reader.GetOrdinal("TELEFONO_DEUDOR");
			int direccion_deudorColumnIndex = reader.GetOrdinal("DIRECCION_DEUDOR");
			int nombre_codeudorColumnIndex = reader.GetOrdinal("NOMBRE_CODEUDOR");
			int documento_codeudorColumnIndex = reader.GetOrdinal("DOCUMENTO_CODEUDOR");
			int telefono_codeudorColumnIndex = reader.GetOrdinal("TELEFONO_CODEUDOR");
			int direccion_codeudorColumnIndex = reader.GetOrdinal("DIRECCION_CODEUDOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int documento_beneficiarioColumnIndex = reader.GetOrdinal("DOCUMENTO_BENEFICIARIO");
			int telefono_beneficiarioColumnIndex = reader.GetOrdinal("TELEFONO_BENEFICIARIO");
			int direccion_beneficiarioColumnIndex = reader.GetOrdinal("DIRECCION_BENEFICIARIO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int fecha_firmaColumnIndex = reader.GetOrdinal("FECHA_FIRMA");
			int fecha_anuladoColumnIndex = reader.GetOrdinal("FECHA_ANULADO");
			int usuario_anulado_idColumnIndex = reader.GetOrdinal("USUARIO_ANULADO_ID");
			int garantiaColumnIndex = reader.GetOrdinal("GARANTIA");
			int caso_garantia_idColumnIndex = reader.GetOrdinal("CASO_GARANTIA_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGARES_INFO_COMPLETARow record = new CTACTE_PAGARES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CANTIDAD_PAGARES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_pagaresColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_pagares_restantesColumnIndex))
						record.CANTIDAD_PAGARES_RESTANTES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_pagares_restantesColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_saldoColumnIndex))
						record.MONTO_SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_saldoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_vencidoColumnIndex))
						record.MONTO_VENCIDO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_vencidoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.JUEGO_PAGARES_APROBADO = Convert.ToString(reader.GetValue(juego_pagares_aprobadoColumnIndex));
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					record.NOMBRE_DEUDOR = Convert.ToString(reader.GetValue(nombre_deudorColumnIndex));
					record.DOCUMENTO_DEUDOR = Convert.ToString(reader.GetValue(documento_deudorColumnIndex));
					if(!reader.IsDBNull(telefono_deudorColumnIndex))
						record.TELEFONO_DEUDOR = Convert.ToString(reader.GetValue(telefono_deudorColumnIndex));
					record.DIRECCION_DEUDOR = Convert.ToString(reader.GetValue(direccion_deudorColumnIndex));
					if(!reader.IsDBNull(nombre_codeudorColumnIndex))
						record.NOMBRE_CODEUDOR = Convert.ToString(reader.GetValue(nombre_codeudorColumnIndex));
					if(!reader.IsDBNull(documento_codeudorColumnIndex))
						record.DOCUMENTO_CODEUDOR = Convert.ToString(reader.GetValue(documento_codeudorColumnIndex));
					if(!reader.IsDBNull(telefono_codeudorColumnIndex))
						record.TELEFONO_CODEUDOR = Convert.ToString(reader.GetValue(telefono_codeudorColumnIndex));
					if(!reader.IsDBNull(direccion_codeudorColumnIndex))
						record.DIRECCION_CODEUDOR = Convert.ToString(reader.GetValue(direccion_codeudorColumnIndex));
					record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					record.DOCUMENTO_BENEFICIARIO = Convert.ToString(reader.GetValue(documento_beneficiarioColumnIndex));
					record.TELEFONO_BENEFICIARIO = Convert.ToString(reader.GetValue(telefono_beneficiarioColumnIndex));
					record.DIRECCION_BENEFICIARIO = Convert.ToString(reader.GetValue(direccion_beneficiarioColumnIndex));
					record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(fecha_firmaColumnIndex))
						record.FECHA_FIRMA = Convert.ToDateTime(reader.GetValue(fecha_firmaColumnIndex));
					if(!reader.IsDBNull(fecha_anuladoColumnIndex))
						record.FECHA_ANULADO = Convert.ToDateTime(reader.GetValue(fecha_anuladoColumnIndex));
					if(!reader.IsDBNull(usuario_anulado_idColumnIndex))
						record.USUARIO_ANULADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_anulado_idColumnIndex)), 9);
					record.GARANTIA = Convert.ToString(reader.GetValue(garantiaColumnIndex));
					if(!reader.IsDBNull(caso_garantia_idColumnIndex))
						record.CASO_GARANTIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_garantia_idColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGARES_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTACTE_PAGARES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGARES_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTACTE_PAGARES_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTACTE_PAGARES_INFO_COMPLETARow mappedObject = new CTACTE_PAGARES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
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
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD_PAGARES"
			dataColumn = dataTable.Columns["CANTIDAD_PAGARES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PAGARES = (decimal)row[dataColumn];
			// Column "CANTIDAD_PAGARES_RESTANTES"
			dataColumn = dataTable.Columns["CANTIDAD_PAGARES_RESTANTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PAGARES_RESTANTES = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "MONTO_SALDO"
			dataColumn = dataTable.Columns["MONTO_SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_SALDO = (decimal)row[dataColumn];
			// Column "MONTO_VENCIDO"
			dataColumn = dataTable.Columns["MONTO_VENCIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_VENCIDO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "JUEGO_PAGARES_APROBADO"
			dataColumn = dataTable.Columns["JUEGO_PAGARES_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUEGO_PAGARES_APROBADO = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "NOMBRE_DEUDOR"
			dataColumn = dataTable.Columns["NOMBRE_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_DEUDOR = (string)row[dataColumn];
			// Column "DOCUMENTO_DEUDOR"
			dataColumn = dataTable.Columns["DOCUMENTO_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_DEUDOR = (string)row[dataColumn];
			// Column "TELEFONO_DEUDOR"
			dataColumn = dataTable.Columns["TELEFONO_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_DEUDOR = (string)row[dataColumn];
			// Column "DIRECCION_DEUDOR"
			dataColumn = dataTable.Columns["DIRECCION_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_DEUDOR = (string)row[dataColumn];
			// Column "NOMBRE_CODEUDOR"
			dataColumn = dataTable.Columns["NOMBRE_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_CODEUDOR = (string)row[dataColumn];
			// Column "DOCUMENTO_CODEUDOR"
			dataColumn = dataTable.Columns["DOCUMENTO_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_CODEUDOR = (string)row[dataColumn];
			// Column "TELEFONO_CODEUDOR"
			dataColumn = dataTable.Columns["TELEFONO_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_CODEUDOR = (string)row[dataColumn];
			// Column "DIRECCION_CODEUDOR"
			dataColumn = dataTable.Columns["DIRECCION_CODEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_CODEUDOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "DOCUMENTO_BENEFICIARIO"
			dataColumn = dataTable.Columns["DOCUMENTO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTO_BENEFICIARIO = (string)row[dataColumn];
			// Column "TELEFONO_BENEFICIARIO"
			dataColumn = dataTable.Columns["TELEFONO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_BENEFICIARIO = (string)row[dataColumn];
			// Column "DIRECCION_BENEFICIARIO"
			dataColumn = dataTable.Columns["DIRECCION_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIRMA"
			dataColumn = dataTable.Columns["FECHA_FIRMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIRMA = (System.DateTime)row[dataColumn];
			// Column "FECHA_ANULADO"
			dataColumn = dataTable.Columns["FECHA_ANULADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ANULADO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ANULADO_ID"
			dataColumn = dataTable.Columns["USUARIO_ANULADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ANULADO_ID = (decimal)row[dataColumn];
			// Column "GARANTIA"
			dataColumn = dataTable.Columns["GARANTIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GARANTIA = (string)row[dataColumn];
			// Column "CASO_GARANTIA_ID"
			dataColumn = dataTable.Columns["CASO_GARANTIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_GARANTIA_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGARES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGARES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_PAGARES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_PAGARES_RESTANTES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_SALDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_VENCIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("JUEGO_PAGARES_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_DEUDOR", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_DEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_DEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION_DEUDOR", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION_CODEUDOR", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DOCUMENTO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIRMA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ANULADO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ANULADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GARANTIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_GARANTIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD_PAGARES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_PAGARES_RESTANTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_VENCIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "JUEGO_PAGARES_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_CODEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIRMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ANULADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ANULADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GARANTIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_GARANTIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGARES_INFO_COMPLETACollection_Base class
}  // End of namespace
