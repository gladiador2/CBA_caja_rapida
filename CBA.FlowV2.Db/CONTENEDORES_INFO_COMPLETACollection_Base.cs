// <fileinfo name="CONTENEDORES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NUMEROColumnName = "NUMERO";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string LINEA_CODIGOColumnName = "LINEA_CODIGO";
		public const string LINEA_NOMBREColumnName = "LINEA_NOMBRE";
		public const string AGENCIA_IDColumnName = "AGENCIA_ID";
		public const string AGENCIA_CODIGOColumnName = "AGENCIA_CODIGO";
		public const string AGENCIA_NOMBREColumnName = "AGENCIA_NOMBRE";
		public const string TIPO_IDColumnName = "TIPO_ID";
		public const string CLASIFICACIONColumnName = "CLASIFICACION";
		public const string TAMANOColumnName = "TAMANO";
		public const string TIPO_DESCRIPCIONColumnName = "TIPO_DESCRIPCION";
		public const string TARAColumnName = "TARA";
		public const string CAPACIDADColumnName = "CAPACIDAD";
		public const string PESO_MAXIMOColumnName = "PESO_MAXIMO";
		public const string ESTADOColumnName = "ESTADO";
		public const string EN_PREDIOColumnName = "EN_PREDIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string CLASEColumnName = "CLASE";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string HABILITADO_HASTAColumnName = "HABILITADO_HASTA";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";
		public const string PUERTO_DEVOLUCION_NOMBREColumnName = "PUERTO_DEVOLUCION_NOMBRE";
		public const string USUARIO_CREADOR_NOMBREColumnName = "USUARIO_CREADOR_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		public virtual CONTENEDORES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		public CONTENEDORES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		public virtual CONTENEDORES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected CONTENEDORES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected CONTENEDORES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CONTENEDORES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int linea_codigoColumnIndex = reader.GetOrdinal("LINEA_CODIGO");
			int linea_nombreColumnIndex = reader.GetOrdinal("LINEA_NOMBRE");
			int agencia_idColumnIndex = reader.GetOrdinal("AGENCIA_ID");
			int agencia_codigoColumnIndex = reader.GetOrdinal("AGENCIA_CODIGO");
			int agencia_nombreColumnIndex = reader.GetOrdinal("AGENCIA_NOMBRE");
			int tipo_idColumnIndex = reader.GetOrdinal("TIPO_ID");
			int clasificacionColumnIndex = reader.GetOrdinal("CLASIFICACION");
			int tamanoColumnIndex = reader.GetOrdinal("TAMANO");
			int tipo_descripcionColumnIndex = reader.GetOrdinal("TIPO_DESCRIPCION");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int capacidadColumnIndex = reader.GetOrdinal("CAPACIDAD");
			int peso_maximoColumnIndex = reader.GetOrdinal("PESO_MAXIMO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int en_predioColumnIndex = reader.GetOrdinal("EN_PREDIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int claseColumnIndex = reader.GetOrdinal("CLASE");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int habilitado_hastaColumnIndex = reader.GetOrdinal("HABILITADO_HASTA");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");
			int puerto_devolucion_nombreColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_NOMBRE");
			int usuario_creador_nombreColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_INFO_COMPLETARow record = new CONTENEDORES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(linea_codigoColumnIndex))
						record.LINEA_CODIGO = Convert.ToString(reader.GetValue(linea_codigoColumnIndex));
					if(!reader.IsDBNull(linea_nombreColumnIndex))
						record.LINEA_NOMBRE = Convert.ToString(reader.GetValue(linea_nombreColumnIndex));
					record.AGENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(agencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(agencia_codigoColumnIndex))
						record.AGENCIA_CODIGO = Convert.ToString(reader.GetValue(agencia_codigoColumnIndex));
					if(!reader.IsDBNull(agencia_nombreColumnIndex))
						record.AGENCIA_NOMBRE = Convert.ToString(reader.GetValue(agencia_nombreColumnIndex));
					record.TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_idColumnIndex)), 9);
					record.CLASIFICACION = Convert.ToString(reader.GetValue(clasificacionColumnIndex));
					record.TAMANO = Math.Round(Convert.ToDecimal(reader.GetValue(tamanoColumnIndex)), 9);
					record.TIPO_DESCRIPCION = Convert.ToString(reader.GetValue(tipo_descripcionColumnIndex));
					record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					record.CAPACIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(capacidadColumnIndex)), 9);
					record.PESO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_maximoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.EN_PREDIO = Convert.ToString(reader.GetValue(en_predioColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.CLASE = Convert.ToString(reader.GetValue(claseColumnIndex));
					if(!reader.IsDBNull(bloqueadoColumnIndex))
						record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(habilitado_hastaColumnIndex))
						record.HABILITADO_HASTA = Convert.ToDateTime(reader.GetValue(habilitado_hastaColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_devolucion_nombreColumnIndex))
						record.PUERTO_DEVOLUCION_NOMBRE = Convert.ToString(reader.GetValue(puerto_devolucion_nombreColumnIndex));
					record.USUARIO_CREADOR_NOMBRE = Convert.ToString(reader.GetValue(usuario_creador_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_INFO_COMPLETARow[])(recordList.ToArray(typeof(CONTENEDORES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_INFO_COMPLETARow"/> object.</returns>
		protected virtual CONTENEDORES_INFO_COMPLETARow MapRow(DataRow row)
		{
			CONTENEDORES_INFO_COMPLETARow mappedObject = new CONTENEDORES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "LINEA_CODIGO"
			dataColumn = dataTable.Columns["LINEA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_CODIGO = (string)row[dataColumn];
			// Column "LINEA_NOMBRE"
			dataColumn = dataTable.Columns["LINEA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_NOMBRE = (string)row[dataColumn];
			// Column "AGENCIA_ID"
			dataColumn = dataTable.Columns["AGENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_ID = (decimal)row[dataColumn];
			// Column "AGENCIA_CODIGO"
			dataColumn = dataTable.Columns["AGENCIA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_CODIGO = (string)row[dataColumn];
			// Column "AGENCIA_NOMBRE"
			dataColumn = dataTable.Columns["AGENCIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_ID"
			dataColumn = dataTable.Columns["TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ID = (decimal)row[dataColumn];
			// Column "CLASIFICACION"
			dataColumn = dataTable.Columns["CLASIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASIFICACION = (string)row[dataColumn];
			// Column "TAMANO"
			dataColumn = dataTable.Columns["TAMANO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TAMANO = (decimal)row[dataColumn];
			// Column "TIPO_DESCRIPCION"
			dataColumn = dataTable.Columns["TIPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DESCRIPCION = (string)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "CAPACIDAD"
			dataColumn = dataTable.Columns["CAPACIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPACIDAD = (decimal)row[dataColumn];
			// Column "PESO_MAXIMO"
			dataColumn = dataTable.Columns["PESO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MAXIMO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "EN_PREDIO"
			dataColumn = dataTable.Columns["EN_PREDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_PREDIO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "CLASE"
			dataColumn = dataTable.Columns["CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASE = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "HABILITADO_HASTA"
			dataColumn = dataTable.Columns["HABILITADO_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABILITADO_HASTA = (System.DateTime)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_CREADOR_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_CODIGO", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENCIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENCIA_CODIGO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENCIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLASIFICACION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TAMANO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAPACIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_MAXIMO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EN_PREDIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLASE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HABILITADO_HASTA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AGENCIA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENCIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLASIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TAMANO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPACIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EN_PREDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "HABILITADO_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_DEVOLUCION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CREADOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_INFO_COMPLETACollection_Base class
}  // End of namespace
