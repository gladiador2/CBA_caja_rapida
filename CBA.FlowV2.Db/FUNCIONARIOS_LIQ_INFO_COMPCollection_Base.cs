// <fileinfo name="FUNCIONARIOS_LIQ_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_LIQ_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_LIQ_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_LIQ_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string TIPOColumnName = "TIPO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string DIAS_TRABAJADOSColumnName = "DIAS_TRABAJADOS";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIOS_USUARIOColumnName = "USUARIOS_USUARIO";
		public const string TOTAL_SALARIOColumnName = "TOTAL_SALARIO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_BONIFICACIONESColumnName = "TOTAL_BONIFICACIONES";
		public const string TOTAL_COBRARColumnName = "TOTAL_COBRAR";
		public const string TOTAL_APORTES_EMPRESAColumnName = "TOTAL_APORTES_EMPRESA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAS_NOMBREColumnName = "MONEDAS_NOMBRE";
		public const string MONEDAS_SIMBOLOColumnName = "MONEDAS_SIMBOLO";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PLANILLA_SALARIO_IDColumnName = "PLANILLA_SALARIO_ID";
		public const string PLANILLA_SALARIO_DET_IDColumnName = "PLANILLA_SALARIO_DET_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string CASO_ASOCIADO_NRO_COMPROBANTEColumnName = "CASO_ASOCIADO_NRO_COMPROBANTE";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string ORDEN_PAGO_CASO_IDColumnName = "ORDEN_PAGO_CASO_ID";
		public const string ORDEN_PAGO_CASO_ESTADOColumnName = "ORDEN_PAGO_CASO_ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQ_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_LIQ_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_LIQ_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQ_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_LIQ_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_LIQ_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_LIQ_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_LIQ_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		public FUNCIONARIOS_LIQ_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQ_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_LIQ_INFO_COMP";
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		protected FUNCIONARIOS_LIQ_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		protected FUNCIONARIOS_LIQ_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> objects.</returns>
		protected virtual FUNCIONARIOS_LIQ_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int dias_trabajadosColumnIndex = reader.GetOrdinal("DIAS_TRABAJADOS");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuarios_usuarioColumnIndex = reader.GetOrdinal("USUARIOS_USUARIO");
			int total_salarioColumnIndex = reader.GetOrdinal("TOTAL_SALARIO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_bonificacionesColumnIndex = reader.GetOrdinal("TOTAL_BONIFICACIONES");
			int total_cobrarColumnIndex = reader.GetOrdinal("TOTAL_COBRAR");
			int total_aportes_empresaColumnIndex = reader.GetOrdinal("TOTAL_APORTES_EMPRESA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedas_nombreColumnIndex = reader.GetOrdinal("MONEDAS_NOMBRE");
			int monedas_simboloColumnIndex = reader.GetOrdinal("MONEDAS_SIMBOLO");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int planilla_salario_idColumnIndex = reader.GetOrdinal("PLANILLA_SALARIO_ID");
			int planilla_salario_det_idColumnIndex = reader.GetOrdinal("PLANILLA_SALARIO_DET_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int caso_asociado_nro_comprobanteColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_NRO_COMPROBANTE");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int orden_pago_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CASO_ID");
			int orden_pago_caso_estadoColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CASO_ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_LIQ_INFO_COMPRow record = new FUNCIONARIOS_LIQ_INFO_COMPRow();
					recordList.Add(record);

					if(!reader.IsDBNull(idColumnIndex))
						record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_creacionColumnIndex))
						record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(tipoColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(dias_trabajadosColumnIndex))
						record.DIAS_TRABAJADOS = Math.Round(Convert.ToDecimal(reader.GetValue(dias_trabajadosColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.USUARIOS_USUARIO = Convert.ToString(reader.GetValue(usuarios_usuarioColumnIndex));
					if(!reader.IsDBNull(total_salarioColumnIndex))
						record.TOTAL_SALARIO = Math.Round(Convert.ToDecimal(reader.GetValue(total_salarioColumnIndex)), 9);
					if(!reader.IsDBNull(total_descuentoColumnIndex))
						record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(total_bonificacionesColumnIndex))
						record.TOTAL_BONIFICACIONES = Math.Round(Convert.ToDecimal(reader.GetValue(total_bonificacionesColumnIndex)), 9);
					if(!reader.IsDBNull(total_cobrarColumnIndex))
						record.TOTAL_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(total_cobrarColumnIndex)), 9);
					if(!reader.IsDBNull(total_aportes_empresaColumnIndex))
						record.TOTAL_APORTES_EMPRESA = Math.Round(Convert.ToDecimal(reader.GetValue(total_aportes_empresaColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDAS_NOMBRE = Convert.ToString(reader.GetValue(monedas_nombreColumnIndex));
					record.MONEDAS_SIMBOLO = Convert.ToString(reader.GetValue(monedas_simboloColumnIndex));
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(planilla_salario_idColumnIndex))
						record.PLANILLA_SALARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_salario_idColumnIndex)), 9);
					record.PLANILLA_SALARIO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_salario_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_nro_comprobanteColumnIndex))
						record.CASO_ASOCIADO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_asociado_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_caso_idColumnIndex))
						record.ORDEN_PAGO_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_caso_estadoColumnIndex))
						record.ORDEN_PAGO_CASO_ESTADO = Convert.ToString(reader.GetValue(orden_pago_caso_estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_LIQ_INFO_COMPRow[])(recordList.ToArray(typeof(FUNCIONARIOS_LIQ_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> object.</returns>
		protected virtual FUNCIONARIOS_LIQ_INFO_COMPRow MapRow(DataRow row)
		{
			FUNCIONARIOS_LIQ_INFO_COMPRow mappedObject = new FUNCIONARIOS_LIQ_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "DIAS_TRABAJADOS"
			dataColumn = dataTable.Columns["DIAS_TRABAJADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_TRABAJADOS = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIOS_USUARIO"
			dataColumn = dataTable.Columns["USUARIOS_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIOS_USUARIO = (string)row[dataColumn];
			// Column "TOTAL_SALARIO"
			dataColumn = dataTable.Columns["TOTAL_SALARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_SALARIO = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_BONIFICACIONES"
			dataColumn = dataTable.Columns["TOTAL_BONIFICACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BONIFICACIONES = (decimal)row[dataColumn];
			// Column "TOTAL_COBRAR"
			dataColumn = dataTable.Columns["TOTAL_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COBRAR = (decimal)row[dataColumn];
			// Column "TOTAL_APORTES_EMPRESA"
			dataColumn = dataTable.Columns["TOTAL_APORTES_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_APORTES_EMPRESA = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDAS_NOMBRE"
			dataColumn = dataTable.Columns["MONEDAS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_NOMBRE = (string)row[dataColumn];
			// Column "MONEDAS_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDAS_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PLANILLA_SALARIO_ID"
			dataColumn = dataTable.Columns["PLANILLA_SALARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_SALARIO_ID = (decimal)row[dataColumn];
			// Column "PLANILLA_SALARIO_DET_ID"
			dataColumn = dataTable.Columns["PLANILLA_SALARIO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_SALARIO_DET_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CASO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_CASO_ESTADO"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CASO_ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_LIQ_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_LIQ_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIAS_TRABAJADOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIOS_USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_SALARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_BONIFICACIONES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COBRAR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_APORTES_EMPRESA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PLANILLA_SALARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PLANILLA_SALARIO_DET_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
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

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DIAS_TRABAJADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIOS_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_SALARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BONIFICACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_APORTES_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDAS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDAS_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PLANILLA_SALARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PLANILLA_SALARIO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_CASO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_LIQ_INFO_COMPCollection_Base class
}  // End of namespace
