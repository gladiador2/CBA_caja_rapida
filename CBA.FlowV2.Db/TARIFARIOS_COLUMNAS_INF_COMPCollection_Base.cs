// <fileinfo name="TARIFARIOS_COLUMNAS_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="TARIFARIOS_COLUMNAS_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TARIFARIOS_COLUMNAS_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TARIFARIOS_COLUMNAS_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TARIFARIO_IDColumnName = "TARIFARIO_ID";
		public const string TARIFARIO_NOMBREColumnName = "TARIFARIO_NOMBRE";
		public const string NOMBREColumnName = "NOMBRE";
		public const string TIPO_DATO_IDColumnName = "TIPO_DATO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string OBLIGATORIOColumnName = "OBLIGATORIO";
		public const string FECHA_MODIFICACIONColumnName = "FECHA_MODIFICACION";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string USUARIO_MODIFICACION_NOMBREColumnName = "USUARIO_MODIFICACION_NOMBRE";
		public const string ORDENColumnName = "ORDEN";
		public const string ARTICULO_RELACIONADO_IDColumnName = "ARTICULO_RELACIONADO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string TARIFARIOS_GRUPO_IDColumnName = "TARIFARIOS_GRUPO_ID";
		public const string TARIFARIO_GRUPO_NOMBREColumnName = "TARIFARIO_GRUPO_NOMBRE";
		public const string TARIFARIO_GRUPO_OPERACIONColumnName = "TARIFARIO_GRUPO_OPERACION";
		public const string MINIMOColumnName = "MINIMO";
		public const string MAXIMOColumnName = "MAXIMO";
		public const string VALOR_POR_DEFECTOColumnName = "VALOR_POR_DEFECTO";
		public const string INCLUIR_SIEMPREColumnName = "INCLUIR_SIEMPRE";
		public const string TOMAR_DATO_INGRESADOColumnName = "TOMAR_DATO_INGRESADO";
		public const string PRIMER_PERIODOColumnName = "PRIMER_PERIODO";
		public const string PERIODOS_POSTERIORESColumnName = "PERIODOS_POSTERIORES";
		public const string PRORRATEO_PERIODOSColumnName = "PRORRATEO_PERIODOS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_COLUMNAS_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TARIFARIOS_COLUMNAS_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TARIFARIOS_COLUMNAS_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNAS_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TARIFARIOS_COLUMNAS_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TARIFARIOS_COLUMNAS_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TARIFARIOS_COLUMNAS_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TARIFARIOS_COLUMNAS_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		public TARIFARIOS_COLUMNAS_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNAS_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TARIFARIOS_COLUMNAS_INF_COMP";
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		protected TARIFARIOS_COLUMNAS_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		protected TARIFARIOS_COLUMNAS_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> objects.</returns>
		protected virtual TARIFARIOS_COLUMNAS_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tarifario_idColumnIndex = reader.GetOrdinal("TARIFARIO_ID");
			int tarifario_nombreColumnIndex = reader.GetOrdinal("TARIFARIO_NOMBRE");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int tipo_dato_idColumnIndex = reader.GetOrdinal("TIPO_DATO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int obligatorioColumnIndex = reader.GetOrdinal("OBLIGATORIO");
			int fecha_modificacionColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int usuario_modificacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_NOMBRE");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int articulo_relacionado_idColumnIndex = reader.GetOrdinal("ARTICULO_RELACIONADO_ID");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int tarifarios_grupo_idColumnIndex = reader.GetOrdinal("TARIFARIOS_GRUPO_ID");
			int tarifario_grupo_nombreColumnIndex = reader.GetOrdinal("TARIFARIO_GRUPO_NOMBRE");
			int tarifario_grupo_operacionColumnIndex = reader.GetOrdinal("TARIFARIO_GRUPO_OPERACION");
			int minimoColumnIndex = reader.GetOrdinal("MINIMO");
			int maximoColumnIndex = reader.GetOrdinal("MAXIMO");
			int valor_por_defectoColumnIndex = reader.GetOrdinal("VALOR_POR_DEFECTO");
			int incluir_siempreColumnIndex = reader.GetOrdinal("INCLUIR_SIEMPRE");
			int tomar_dato_ingresadoColumnIndex = reader.GetOrdinal("TOMAR_DATO_INGRESADO");
			int primer_periodoColumnIndex = reader.GetOrdinal("PRIMER_PERIODO");
			int periodos_posterioresColumnIndex = reader.GetOrdinal("PERIODOS_POSTERIORES");
			int prorrateo_periodosColumnIndex = reader.GetOrdinal("PRORRATEO_PERIODOS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TARIFARIOS_COLUMNAS_INF_COMPRow record = new TARIFARIOS_COLUMNAS_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TARIFARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tarifario_idColumnIndex)), 9);
					record.TARIFARIO_NOMBRE = Convert.ToString(reader.GetValue(tarifario_nombreColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.TIPO_DATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_dato_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.OBLIGATORIO = Convert.ToString(reader.GetValue(obligatorioColumnIndex));
					record.FECHA_MODIFICACION = Convert.ToDateTime(reader.GetValue(fecha_modificacionColumnIndex));
					record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					record.USUARIO_MODIFICACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_modificacion_nombreColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_relacionado_idColumnIndex))
						record.ARTICULO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(tarifarios_grupo_idColumnIndex))
						record.TARIFARIOS_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tarifarios_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(tarifario_grupo_nombreColumnIndex))
						record.TARIFARIO_GRUPO_NOMBRE = Convert.ToString(reader.GetValue(tarifario_grupo_nombreColumnIndex));
					if(!reader.IsDBNull(tarifario_grupo_operacionColumnIndex))
						record.TARIFARIO_GRUPO_OPERACION = Convert.ToString(reader.GetValue(tarifario_grupo_operacionColumnIndex));
					if(!reader.IsDBNull(minimoColumnIndex))
						record.MINIMO = Math.Round(Convert.ToDecimal(reader.GetValue(minimoColumnIndex)), 9);
					if(!reader.IsDBNull(maximoColumnIndex))
						record.MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(maximoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_por_defectoColumnIndex))
						record.VALOR_POR_DEFECTO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_por_defectoColumnIndex)), 9);
					record.INCLUIR_SIEMPRE = Convert.ToString(reader.GetValue(incluir_siempreColumnIndex));
					record.TOMAR_DATO_INGRESADO = Convert.ToString(reader.GetValue(tomar_dato_ingresadoColumnIndex));
					if(!reader.IsDBNull(primer_periodoColumnIndex))
						record.PRIMER_PERIODO = Math.Round(Convert.ToDecimal(reader.GetValue(primer_periodoColumnIndex)), 9);
					if(!reader.IsDBNull(periodos_posterioresColumnIndex))
						record.PERIODOS_POSTERIORES = Math.Round(Convert.ToDecimal(reader.GetValue(periodos_posterioresColumnIndex)), 9);
					if(!reader.IsDBNull(prorrateo_periodosColumnIndex))
						record.PRORRATEO_PERIODOS = Math.Round(Convert.ToDecimal(reader.GetValue(prorrateo_periodosColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TARIFARIOS_COLUMNAS_INF_COMPRow[])(recordList.ToArray(typeof(TARIFARIOS_COLUMNAS_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TARIFARIOS_COLUMNAS_INF_COMPRow"/> object.</returns>
		protected virtual TARIFARIOS_COLUMNAS_INF_COMPRow MapRow(DataRow row)
		{
			TARIFARIOS_COLUMNAS_INF_COMPRow mappedObject = new TARIFARIOS_COLUMNAS_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TARIFARIO_ID"
			dataColumn = dataTable.Columns["TARIFARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_ID = (decimal)row[dataColumn];
			// Column "TARIFARIO_NOMBRE"
			dataColumn = dataTable.Columns["TARIFARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_NOMBRE = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "TIPO_DATO_ID"
			dataColumn = dataTable.Columns["TIPO_DATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "OBLIGATORIO"
			dataColumn = dataTable.Columns["OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBLIGATORIO = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_NOMBRE = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "ARTICULO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["ARTICULO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "TARIFARIOS_GRUPO_ID"
			dataColumn = dataTable.Columns["TARIFARIOS_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIOS_GRUPO_ID = (decimal)row[dataColumn];
			// Column "TARIFARIO_GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["TARIFARIO_GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "TARIFARIO_GRUPO_OPERACION"
			dataColumn = dataTable.Columns["TARIFARIO_GRUPO_OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_GRUPO_OPERACION = (string)row[dataColumn];
			// Column "MINIMO"
			dataColumn = dataTable.Columns["MINIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINIMO = (decimal)row[dataColumn];
			// Column "MAXIMO"
			dataColumn = dataTable.Columns["MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAXIMO = (decimal)row[dataColumn];
			// Column "VALOR_POR_DEFECTO"
			dataColumn = dataTable.Columns["VALOR_POR_DEFECTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_POR_DEFECTO = (decimal)row[dataColumn];
			// Column "INCLUIR_SIEMPRE"
			dataColumn = dataTable.Columns["INCLUIR_SIEMPRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUIR_SIEMPRE = (string)row[dataColumn];
			// Column "TOMAR_DATO_INGRESADO"
			dataColumn = dataTable.Columns["TOMAR_DATO_INGRESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOMAR_DATO_INGRESADO = (string)row[dataColumn];
			// Column "PRIMER_PERIODO"
			dataColumn = dataTable.Columns["PRIMER_PERIODO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRIMER_PERIODO = (decimal)row[dataColumn];
			// Column "PERIODOS_POSTERIORES"
			dataColumn = dataTable.Columns["PERIODOS_POSTERIORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERIODOS_POSTERIORES = (decimal)row[dataColumn];
			// Column "PRORRATEO_PERIODOS"
			dataColumn = dataTable.Columns["PRORRATEO_PERIODOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRORRATEO_PERIODOS = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TARIFARIOS_COLUMNAS_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TARIFARIOS_COLUMNAS_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARIFARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARIFARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DATO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARIFARIOS_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARIFARIO_GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARIFARIO_GRUPO_OPERACION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MINIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MAXIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_POR_DEFECTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INCLUIR_SIEMPRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOMAR_DATO_INGRESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRIMER_PERIODO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERIODOS_POSTERIORES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRORRATEO_PERIODOS", typeof(decimal));
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

				case "TARIFARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARIFARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARIFARIOS_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARIFARIO_GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARIFARIO_GRUPO_OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MINIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_POR_DEFECTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUIR_SIEMPRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TOMAR_DATO_INGRESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRIMER_PERIODO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERIODOS_POSTERIORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRORRATEO_PERIODOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TARIFARIOS_COLUMNAS_INF_COMPCollection_Base class
}  // End of namespace
