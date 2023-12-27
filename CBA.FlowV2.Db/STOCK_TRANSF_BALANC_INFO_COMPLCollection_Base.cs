// <fileinfo name="STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSF_BALANC_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_TRANSF_BALANC_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_USUARIO_CREACIONColumnName = "CASO_USUARIO_CREACION";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string SUCURSAL_ORIGENColumnName = "SUCURSAL_ORIGEN";
		public const string SUCURSAL_ORIGEN_ABRColumnName = "SUCURSAL_ORIGEN_ABR";
		public const string FECHAColumnName = "FECHA";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string VEHICULOColumnName = "VEHICULO";
		public const string VEHICULO_MARCAColumnName = "VEHICULO_MARCA";
		public const string VEHICULO_MATRICULAColumnName = "VEHICULO_MATRICULA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string COMPROBANTEColumnName = "COMPROBANTE";
		public const string ES_CASO_ORIGINALColumnName = "ES_CASO_ORIGINAL";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAColumnName = "MONEDA";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string COSTO_TRANSFERENCIAColumnName = "COSTO_TRANSFERENCIA";
		public const string COSTO_ASOCIADOColumnName = "COSTO_ASOCIADO";
		public const string TOTAL_COSTOColumnName = "TOTAL_COSTO";
		public const string FUNCIONARIO_CHOFER_IDColumnName = "FUNCIONARIO_CHOFER_ID";
		public const string ACOMPANANTE1_IDColumnName = "ACOMPANANTE1_ID";
		public const string ACOMPANANTE2_IDColumnName = "ACOMPANANTE2_ID";
		public const string ACOMPANANTE3_IDColumnName = "ACOMPANANTE3_ID";
		public const string REMISION_EXTERNAColumnName = "REMISION_EXTERNA";
		public const string REMISION_AUTONUMERACION_IDColumnName = "REMISION_AUTONUMERACION_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTOColumnName = "TEXTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string CALLE1ColumnName = "CALLE1";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_TRANSF_BALANC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_TRANSF_BALANC_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_TRANSF_BALANC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_TRANSF_BALANC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_TRANSF_BALANC_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_TRANSF_BALANC_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		public STOCK_TRANSF_BALANC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_TRANSF_BALANC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_TRANSF_BALANC_INFO_COMPL";
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
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_TRANSF_BALANC_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_TRANSF_BALANC_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> objects.</returns>
		protected virtual STOCK_TRANSF_BALANC_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int caso_usuario_creacionColumnIndex = reader.GetOrdinal("CASO_USUARIO_CREACION");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int sucursal_origenColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN");
			int sucursal_origen_abrColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ABR");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int vehiculoColumnIndex = reader.GetOrdinal("VEHICULO");
			int vehiculo_marcaColumnIndex = reader.GetOrdinal("VEHICULO_MARCA");
			int vehiculo_matriculaColumnIndex = reader.GetOrdinal("VEHICULO_MATRICULA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int comprobanteColumnIndex = reader.GetOrdinal("COMPROBANTE");
			int es_caso_originalColumnIndex = reader.GetOrdinal("ES_CASO_ORIGINAL");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedaColumnIndex = reader.GetOrdinal("MONEDA");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int costo_transferenciaColumnIndex = reader.GetOrdinal("COSTO_TRANSFERENCIA");
			int costo_asociadoColumnIndex = reader.GetOrdinal("COSTO_ASOCIADO");
			int total_costoColumnIndex = reader.GetOrdinal("TOTAL_COSTO");
			int funcionario_chofer_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_ID");
			int acompanante1_idColumnIndex = reader.GetOrdinal("ACOMPANANTE1_ID");
			int acompanante2_idColumnIndex = reader.GetOrdinal("ACOMPANANTE2_ID");
			int acompanante3_idColumnIndex = reader.GetOrdinal("ACOMPANANTE3_ID");
			int remision_externaColumnIndex = reader.GetOrdinal("REMISION_EXTERNA");
			int remision_autonumeracion_idColumnIndex = reader.GetOrdinal("REMISION_AUTONUMERACION_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int textoColumnIndex = reader.GetOrdinal("TEXTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_TRANSF_BALANC_INFO_COMPLRow record = new STOCK_TRANSF_BALANC_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					if(!reader.IsDBNull(caso_usuario_creacionColumnIndex))
						record.CASO_USUARIO_CREACION = Convert.ToString(reader.GetValue(caso_usuario_creacionColumnIndex));
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN = Convert.ToString(reader.GetValue(sucursal_origenColumnIndex));
					record.SUCURSAL_ORIGEN_ABR = Convert.ToString(reader.GetValue(sucursal_origen_abrColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(vehiculoColumnIndex))
						record.VEHICULO = Convert.ToString(reader.GetValue(vehiculoColumnIndex));
					if(!reader.IsDBNull(vehiculo_marcaColumnIndex))
						record.VEHICULO_MARCA = Convert.ToString(reader.GetValue(vehiculo_marcaColumnIndex));
					if(!reader.IsDBNull(vehiculo_matriculaColumnIndex))
						record.VEHICULO_MATRICULA = Convert.ToString(reader.GetValue(vehiculo_matriculaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(comprobanteColumnIndex))
						record.COMPROBANTE = Convert.ToString(reader.GetValue(comprobanteColumnIndex));
					record.ES_CASO_ORIGINAL = Convert.ToString(reader.GetValue(es_caso_originalColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(monedaColumnIndex))
						record.MONEDA = Convert.ToString(reader.GetValue(monedaColumnIndex));
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_transferenciaColumnIndex))
						record.COSTO_TRANSFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_transferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(costo_asociadoColumnIndex))
						record.COSTO_ASOCIADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_asociadoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costoColumnIndex))
						record.TOTAL_COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costoColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_chofer_idColumnIndex))
						record.FUNCIONARIO_CHOFER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_chofer_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante1_idColumnIndex))
						record.ACOMPANANTE1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante1_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante2_idColumnIndex))
						record.ACOMPANANTE2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante2_idColumnIndex)), 9);
					if(!reader.IsDBNull(acompanante3_idColumnIndex))
						record.ACOMPANANTE3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(acompanante3_idColumnIndex)), 9);
					if(!reader.IsDBNull(remision_externaColumnIndex))
						record.REMISION_EXTERNA = Convert.ToString(reader.GetValue(remision_externaColumnIndex));
					if(!reader.IsDBNull(remision_autonumeracion_idColumnIndex))
						record.REMISION_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(remision_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(razon_socialColumnIndex))
						record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(textoColumnIndex))
						record.TEXTO = Convert.ToString(reader.GetValue(textoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(calle1ColumnIndex))
						record.CALLE1 = Convert.ToString(reader.GetValue(calle1ColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_TRANSF_BALANC_INFO_COMPLRow[])(recordList.ToArray(typeof(STOCK_TRANSF_BALANC_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_TRANSF_BALANC_INFO_COMPLRow"/> object.</returns>
		protected virtual STOCK_TRANSF_BALANC_INFO_COMPLRow MapRow(DataRow row)
		{
			STOCK_TRANSF_BALANC_INFO_COMPLRow mappedObject = new STOCK_TRANSF_BALANC_INFO_COMPLRow();
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
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "CASO_USUARIO_CREACION"
			dataColumn = dataTable.Columns["CASO_USUARIO_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_USUARIO_CREACION = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ABR"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ABR"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ABR = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "VEHICULO"
			dataColumn = dataTable.Columns["VEHICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO = (string)row[dataColumn];
			// Column "VEHICULO_MARCA"
			dataColumn = dataTable.Columns["VEHICULO_MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MARCA = (string)row[dataColumn];
			// Column "VEHICULO_MATRICULA"
			dataColumn = dataTable.Columns["VEHICULO_MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MATRICULA = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "COMPROBANTE"
			dataColumn = dataTable.Columns["COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE = (string)row[dataColumn];
			// Column "ES_CASO_ORIGINAL"
			dataColumn = dataTable.Columns["ES_CASO_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CASO_ORIGINAL = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA"
			dataColumn = dataTable.Columns["MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_TRANSFERENCIA"
			dataColumn = dataTable.Columns["COSTO_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TRANSFERENCIA = (decimal)row[dataColumn];
			// Column "COSTO_ASOCIADO"
			dataColumn = dataTable.Columns["COSTO_ASOCIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ASOCIADO = (decimal)row[dataColumn];
			// Column "TOTAL_COSTO"
			dataColumn = dataTable.Columns["TOTAL_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE1_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE1_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE2_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE2_ID = (decimal)row[dataColumn];
			// Column "ACOMPANANTE3_ID"
			dataColumn = dataTable.Columns["ACOMPANANTE3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACOMPANANTE3_ID = (decimal)row[dataColumn];
			// Column "REMISION_EXTERNA"
			dataColumn = dataTable.Columns["REMISION_EXTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMISION_EXTERNA = (string)row[dataColumn];
			// Column "REMISION_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["REMISION_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMISION_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO"
			dataColumn = dataTable.Columns["TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "CALLE1"
			dataColumn = dataTable.Columns["CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE1 = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_TRANSF_BALANC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_TRANSF_BALANC_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_USUARIO_CREACION", typeof(string));
			dataColumn.MaxLength = 153;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ABR", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_MATRICULA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CASO_ORIGINAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_TRANSFERENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_ASOCIADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACOMPANANTE1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACOMPANANTE2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACOMPANANTE3_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REMISION_EXTERNA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REMISION_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 80;
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

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_USUARIO_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ABR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VEHICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_CASO_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ASOCIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CHOFER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACOMPANANTE3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REMISION_EXTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REMISION_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base class
}  // End of namespace
