// <fileinfo name="REPARTOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="REPARTOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REPARTOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_FECHA_CREACIONColumnName = "CASO_FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string CASO_USUARIO_NOMBREColumnName = "CASO_USUARIO_NOMBRE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_NOMBREColumnName = "DEPOSITO_NOMBRE";
		public const string DEPOSITO_ABREVIATURAColumnName = "DEPOSITO_ABREVIATURA";
		public const string FECHAColumnName = "FECHA";
		public const string FUNCIONARIO_CHOFER_IDColumnName = "FUNCIONARIO_CHOFER_ID";
		public const string FUNCIONARIO_CHOFER_NOMBRE_COMPColumnName = "FUNCIONARIO_CHOFER_NOMBRE_COMP";
		public const string FUNCIONARIO_ACOMPANHANTE_1ColumnName = "FUNCIONARIO_ACOMPANHANTE_1";
		public const string FUNCIONARIO_ACOMP1_NOMBRE_COMPColumnName = "FUNCIONARIO_ACOMP1_NOMBRE_COMP";
		public const string FUNCIONARIO_ACOMPANHANTE_2ColumnName = "FUNCIONARIO_ACOMPANHANTE_2";
		public const string FUNCIONARIO_ACOMP2_NOMBRE_COMPColumnName = "FUNCIONARIO_ACOMP2_NOMBRE_COMP";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string FECHA_REGRESOColumnName = "FECHA_REGRESO";
		public const string KILOMETRAJE_SALIDAColumnName = "KILOMETRAJE_SALIDA";
		public const string KILOMETRAJE_REGRESOColumnName = "KILOMETRAJE_REGRESO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string MARCAColumnName = "MARCA";
		public const string MODELOColumnName = "MODELO";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string NOMBREColumnName = "NOMBRE";
		public const string MATRICULAColumnName = "MATRICULA";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string CTACTE_CAJA_SUC_IDColumnName = "CTACTE_CAJA_SUC_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REPARTOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REPARTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual REPARTOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REPARTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REPARTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REPARTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REPARTOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REPARTOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REPARTOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		public REPARTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual REPARTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REPARTOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		protected REPARTOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		protected REPARTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REPARTOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual REPARTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int caso_fecha_creacionColumnIndex = reader.GetOrdinal("CASO_FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int caso_usuario_nombreColumnIndex = reader.GetOrdinal("CASO_USUARIO_NOMBRE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_NOMBRE");
			int deposito_abreviaturaColumnIndex = reader.GetOrdinal("DEPOSITO_ABREVIATURA");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int funcionario_chofer_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_ID");
			int funcionario_chofer_nombre_compColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_NOMBRE_COMP");
			int funcionario_acompanhante_1ColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE_1");
			int funcionario_acomp1_nombre_compColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMP1_NOMBRE_COMP");
			int funcionario_acompanhante_2ColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE_2");
			int funcionario_acomp2_nombre_compColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMP2_NOMBRE_COMP");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int fecha_regresoColumnIndex = reader.GetOrdinal("FECHA_REGRESO");
			int kilometraje_salidaColumnIndex = reader.GetOrdinal("KILOMETRAJE_SALIDA");
			int kilometraje_regresoColumnIndex = reader.GetOrdinal("KILOMETRAJE_REGRESO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int marcaColumnIndex = reader.GetOrdinal("MARCA");
			int modeloColumnIndex = reader.GetOrdinal("MODELO");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int matriculaColumnIndex = reader.GetOrdinal("MATRICULA");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int ctacte_caja_suc_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REPARTOS_INFO_COMPLETARow record = new REPARTOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.CASO_FECHA_CREACION = Convert.ToDateTime(reader.GetValue(caso_fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_creacion_idColumnIndex))
						record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_usuario_nombreColumnIndex))
						record.CASO_USUARIO_NOMBRE = Convert.ToString(reader.GetValue(caso_usuario_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(deposito_nombreColumnIndex));
					record.DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(deposito_abreviaturaColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(funcionario_chofer_idColumnIndex))
						record.FUNCIONARIO_CHOFER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_chofer_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_chofer_nombre_compColumnIndex))
						record.FUNCIONARIO_CHOFER_NOMBRE_COMP = Convert.ToString(reader.GetValue(funcionario_chofer_nombre_compColumnIndex));
					if(!reader.IsDBNull(funcionario_acompanhante_1ColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE_1 = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante_1ColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_acomp1_nombre_compColumnIndex))
						record.FUNCIONARIO_ACOMP1_NOMBRE_COMP = Convert.ToString(reader.GetValue(funcionario_acomp1_nombre_compColumnIndex));
					if(!reader.IsDBNull(funcionario_acompanhante_2ColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE_2 = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante_2ColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_acomp2_nombre_compColumnIndex))
						record.FUNCIONARIO_ACOMP2_NOMBRE_COMP = Convert.ToString(reader.GetValue(funcionario_acomp2_nombre_compColumnIndex));
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(fecha_regresoColumnIndex))
						record.FECHA_REGRESO = Convert.ToDateTime(reader.GetValue(fecha_regresoColumnIndex));
					if(!reader.IsDBNull(kilometraje_salidaColumnIndex))
						record.KILOMETRAJE_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_salidaColumnIndex)), 9);
					if(!reader.IsDBNull(kilometraje_regresoColumnIndex))
						record.KILOMETRAJE_REGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_regresoColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(marcaColumnIndex))
						record.MARCA = Convert.ToString(reader.GetValue(marcaColumnIndex));
					if(!reader.IsDBNull(modeloColumnIndex))
						record.MODELO = Convert.ToString(reader.GetValue(modeloColumnIndex));
					if(!reader.IsDBNull(abreviaturaColumnIndex))
						record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(matriculaColumnIndex))
						record.MATRICULA = Convert.ToString(reader.GetValue(matriculaColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_suc_idColumnIndex))
						record.CTACTE_CAJA_SUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_suc_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REPARTOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(REPARTOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REPARTOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REPARTOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual REPARTOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			REPARTOS_INFO_COMPLETARow mappedObject = new REPARTOS_INFO_COMPLETARow();
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
			// Column "CASO_FECHA_CREACION"
			dataColumn = dataTable.Columns["CASO_FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "CASO_USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["CASO_USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_USUARIO_NOMBRE = (string)row[dataColumn];
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
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_NOMBRE_COMP"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_NOMBRE_COMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_NOMBRE_COMP = (string)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE_1"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE_1 = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ACOMP1_NOMBRE_COMP"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMP1_NOMBRE_COMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMP1_NOMBRE_COMP = (string)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE_2"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE_2 = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ACOMP2_NOMBRE_COMP"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMP2_NOMBRE_COMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMP2_NOMBRE_COMP = (string)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "FECHA_REGRESO"
			dataColumn = dataTable.Columns["FECHA_REGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_REGRESO = (System.DateTime)row[dataColumn];
			// Column "KILOMETRAJE_SALIDA"
			dataColumn = dataTable.Columns["KILOMETRAJE_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_SALIDA = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_REGRESO"
			dataColumn = dataTable.Columns["KILOMETRAJE_REGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_REGRESO = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "MARCA"
			dataColumn = dataTable.Columns["MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA = (string)row[dataColumn];
			// Column "MODELO"
			dataColumn = dataTable.Columns["MODELO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODELO = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "MATRICULA"
			dataColumn = dataTable.Columns["MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MATRICULA = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REPARTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REPARTOS_INFO_COMPLETA";
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
			dataColumn = dataTable.Columns.Add("CASO_FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_NOMBRE_COMP", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE_1", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMP1_NOMBRE_COMP", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE_2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMP2_NOMBRE_COMP", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_REGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_SALIDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_REGRESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MODELO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MATRICULA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_ID", typeof(decimal));
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

				case "CASO_FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_USUARIO_NOMBRE":
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

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_CHOFER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CHOFER_NOMBRE_COMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ACOMP1_NOMBRE_COMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ACOMP2_NOMBRE_COMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_REGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "KILOMETRAJE_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_REGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MODELO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_SUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REPARTOS_INFO_COMPLETACollection_Base class
}  // End of namespace
