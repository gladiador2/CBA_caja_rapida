// <fileinfo name="DEPOSITO_PREP_ESTADO_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITO_PREP_ESTADO_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PEDIDO_CLIENTE_IDColumnName = "PEDIDO_CLIENTE_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FUNCIONARIO_PREPARACION_IDColumnName = "FUNCIONARIO_PREPARACION_ID";
		public const string DEPOSITO_ESTADOColumnName = "DEPOSITO_ESTADO";
		public const string FECHAColumnName = "FECHA";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string PUEDE_PROCESARColumnName = "PUEDE_PROCESAR";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_NOMBREColumnName = "ARTICULO_NOMBRE";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CLIENTEColumnName = "CLIENTE";
		public const string FUNCIONARIOColumnName = "FUNCIONARIO";
		public const string FUNCIONARIO_PREPARACIONColumnName = "FUNCIONARIO_PREPARACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DEPOSITO_PREP_ESTADO_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DEPOSITO_PREP_ESTADO_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		public virtual DEPOSITO_PREP_ESTADO_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DEPOSITO_PREP_ESTADO_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DEPOSITO_PREP_ESTADO_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DEPOSITO_PREP_ESTADO_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DEPOSITO_PREP_ESTADO_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		public DEPOSITO_PREP_ESTADO_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		public virtual DEPOSITO_PREP_ESTADO_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DEPOSITO_PREP_ESTADO_INFO_COMP";
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
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		protected DEPOSITO_PREP_ESTADO_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		protected DEPOSITO_PREP_ESTADO_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> objects.</returns>
		protected virtual DEPOSITO_PREP_ESTADO_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pedido_cliente_idColumnIndex = reader.GetOrdinal("PEDIDO_CLIENTE_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int funcionario_preparacion_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_PREPARACION_ID");
			int deposito_estadoColumnIndex = reader.GetOrdinal("DEPOSITO_ESTADO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int puede_procesarColumnIndex = reader.GetOrdinal("PUEDE_PROCESAR");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_NOMBRE");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int clienteColumnIndex = reader.GetOrdinal("CLIENTE");
			int funcionarioColumnIndex = reader.GetOrdinal("FUNCIONARIO");
			int funcionario_preparacionColumnIndex = reader.GetOrdinal("FUNCIONARIO_PREPARACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DEPOSITO_PREP_ESTADO_INFO_COMPRow record = new DEPOSITO_PREP_ESTADO_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PEDIDO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pedido_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_preparacion_idColumnIndex))
						record.FUNCIONARIO_PREPARACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_preparacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_estadoColumnIndex))
						record.DEPOSITO_ESTADO = Convert.ToString(reader.GetValue(deposito_estadoColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					record.PUEDE_PROCESAR = Convert.ToString(reader.GetValue(puede_procesarColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_nombreColumnIndex))
						record.ARTICULO_NOMBRE = Convert.ToString(reader.GetValue(articulo_nombreColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(clienteColumnIndex))
						record.CLIENTE = Convert.ToString(reader.GetValue(clienteColumnIndex));
					if(!reader.IsDBNull(funcionarioColumnIndex))
						record.FUNCIONARIO = Convert.ToString(reader.GetValue(funcionarioColumnIndex));
					if(!reader.IsDBNull(funcionario_preparacionColumnIndex))
						record.FUNCIONARIO_PREPARACION = Convert.ToString(reader.GetValue(funcionario_preparacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DEPOSITO_PREP_ESTADO_INFO_COMPRow[])(recordList.ToArray(typeof(DEPOSITO_PREP_ESTADO_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> object.</returns>
		protected virtual DEPOSITO_PREP_ESTADO_INFO_COMPRow MapRow(DataRow row)
		{
			DEPOSITO_PREP_ESTADO_INFO_COMPRow mappedObject = new DEPOSITO_PREP_ESTADO_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PEDIDO_CLIENTE_ID"
			dataColumn = dataTable.Columns["PEDIDO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PEDIDO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_PREPARACION_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_PREPARACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_PREPARACION_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ESTADO"
			dataColumn = dataTable.Columns["DEPOSITO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ESTADO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "PUEDE_PROCESAR"
			dataColumn = dataTable.Columns["PUEDE_PROCESAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUEDE_PROCESAR = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_NOMBRE = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CLIENTE"
			dataColumn = dataTable.Columns["CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE = (string)row[dataColumn];
			// Column "FUNCIONARIO"
			dataColumn = dataTable.Columns["FUNCIONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO = (string)row[dataColumn];
			// Column "FUNCIONARIO_PREPARACION"
			dataColumn = dataTable.Columns["FUNCIONARIO_PREPARACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_PREPARACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DEPOSITO_PREP_ESTADO_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DEPOSITO_PREP_ESTADO_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PEDIDO_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_PREPARACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ESTADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUEDE_PROCESAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLIENTE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_PREPARACION", typeof(string));
			dataColumn.MaxLength = 141;
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

				case "PEDIDO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_PREPARACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUEDE_PROCESAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_PREPARACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DEPOSITO_PREP_ESTADO_INFO_COMPCollection_Base class
}  // End of namespace
