// <fileinfo name="PLANES_FACT_ETAPAS_DET_INFO_CCollection_Base.cs">
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
	/// The base class for <see cref="PLANES_FACT_ETAPAS_DET_INFO_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANES_FACT_ETAPAS_DET_INFO_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANES_FACT_ETAPAS_DET_INFO_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLAN_FACTURACION_ETAPA_IDColumnName = "PLAN_FACTURACION_ETAPA_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_UNITARIAColumnName = "CANTIDAD_UNITARIA";
		public const string MONTO_BRUTOColumnName = "MONTO_BRUTO";
		public const string CALCULAR_MONTOColumnName = "CALCULAR_MONTO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string ARTICULO_CODIGO_EMPRESAColumnName = "ARTICULO_CODIGO_EMPRESA";
		public const string ARTICULO_UNIDAD_MEDIDA_IDColumnName = "ARTICULO_UNIDAD_MEDIDA_ID";
		public const string CANTIDAD_POR_CAJAColumnName = "CANTIDAD_POR_CAJA";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string ARTICULO_PARA_VENTAColumnName = "ARTICULO_PARA_VENTA";
		public const string IMPUESTO_NOMBREColumnName = "IMPUESTO_NOMBRE";
		public const string IMPUESTO_PORCENTAJEColumnName = "IMPUESTO_PORCENTAJE";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACT_ETAPAS_DET_INFO_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANES_FACT_ETAPAS_DET_INFO_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANES_FACT_ETAPAS_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		public virtual PLANES_FACT_ETAPAS_DET_INFO_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANES_FACT_ETAPAS_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANES_FACT_ETAPAS_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANES_FACT_ETAPAS_DET_INFO_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANES_FACT_ETAPAS_DET_INFO_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		public PLANES_FACT_ETAPAS_DET_INFO_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		public virtual PLANES_FACT_ETAPAS_DET_INFO_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANES_FACT_ETAPAS_DET_INFO_C";
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
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		protected PLANES_FACT_ETAPAS_DET_INFO_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		protected PLANES_FACT_ETAPAS_DET_INFO_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> objects.</returns>
		protected virtual PLANES_FACT_ETAPAS_DET_INFO_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int plan_facturacion_etapa_idColumnIndex = reader.GetOrdinal("PLAN_FACTURACION_ETAPA_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA");
			int monto_brutoColumnIndex = reader.GetOrdinal("MONTO_BRUTO");
			int calcular_montoColumnIndex = reader.GetOrdinal("CALCULAR_MONTO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int articulo_codigo_empresaColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO_EMPRESA");
			int articulo_unidad_medida_idColumnIndex = reader.GetOrdinal("ARTICULO_UNIDAD_MEDIDA_ID");
			int cantidad_por_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int articulo_para_ventaColumnIndex = reader.GetOrdinal("ARTICULO_PARA_VENTA");
			int impuesto_nombreColumnIndex = reader.GetOrdinal("IMPUESTO_NOMBRE");
			int impuesto_porcentajeColumnIndex = reader.GetOrdinal("IMPUESTO_PORCENTAJE");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANES_FACT_ETAPAS_DET_INFO_CRow record = new PLANES_FACT_ETAPAS_DET_INFO_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLAN_FACTURACION_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(plan_facturacion_etapa_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_brutoColumnIndex))
						record.MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_brutoColumnIndex)), 9);
					record.CALCULAR_MONTO = Convert.ToString(reader.GetValue(calcular_montoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(articulo_codigo_empresaColumnIndex))
						record.ARTICULO_CODIGO_EMPRESA = Convert.ToString(reader.GetValue(articulo_codigo_empresaColumnIndex));
					record.ARTICULO_UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(articulo_unidad_medida_idColumnIndex));
					record.CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_cajaColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.ARTICULO_PARA_VENTA = Convert.ToString(reader.GetValue(articulo_para_ventaColumnIndex));
					record.IMPUESTO_NOMBRE = Convert.ToString(reader.GetValue(impuesto_nombreColumnIndex));
					record.IMPUESTO_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANES_FACT_ETAPAS_DET_INFO_CRow[])(recordList.ToArray(typeof(PLANES_FACT_ETAPAS_DET_INFO_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> object.</returns>
		protected virtual PLANES_FACT_ETAPAS_DET_INFO_CRow MapRow(DataRow row)
		{
			PLANES_FACT_ETAPAS_DET_INFO_CRow mappedObject = new PLANES_FACT_ETAPAS_DET_INFO_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLAN_FACTURACION_ETAPA_ID"
			dataColumn = dataTable.Columns["PLAN_FACTURACION_ETAPA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLAN_FACTURACION_ETAPA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO"
			dataColumn = dataTable.Columns["MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "CALCULAR_MONTO"
			dataColumn = dataTable.Columns["CALCULAR_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALCULAR_MONTO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "ARTICULO_UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["ARTICULO_UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_PARA_VENTA"
			dataColumn = dataTable.Columns["ARTICULO_PARA_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PARA_VENTA = (string)row[dataColumn];
			// Column "IMPUESTO_NOMBRE"
			dataColumn = dataTable.Columns["IMPUESTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_NOMBRE = (string)row[dataColumn];
			// Column "IMPUESTO_PORCENTAJE"
			dataColumn = dataTable.Columns["IMPUESTO_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_PORCENTAJE = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANES_FACT_ETAPAS_DET_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANES_FACT_ETAPAS_DET_INFO_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PLAN_FACTURACION_ETAPA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALCULAR_MONTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_PARA_VENTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
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

				case "PLAN_FACTURACION_ETAPA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALCULAR_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_PARA_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMPUESTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
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
	} // End of PLANES_FACT_ETAPAS_DET_INFO_CCollection_Base class
}  // End of namespace
