// <fileinfo name="MENSAJES_SISTEMA_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="MENSAJES_SISTEMA_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MENSAJES_SISTEMA_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MENSAJES_SISTEMA_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_MENSAJEColumnName = "TIPO_MENSAJE";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string ROL_IDColumnName = "ROL_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string TEXTOColumnName = "TEXTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string ROL_DESCIPCIONColumnName = "ROL_DESCIPCION";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string SOBRE_ARTICULO_IDColumnName = "SOBRE_ARTICULO_ID";
		public const string SOBRE_ARTICULO_CODIGOColumnName = "SOBRE_ARTICULO_CODIGO";
		public const string SOBRE_PERSONA_IDColumnName = "SOBRE_PERSONA_ID";
		public const string SOBRE_PERSONA_NOMBREColumnName = "SOBRE_PERSONA_NOMBRE";
		public const string SOBRE_PROVEEDOR_IDColumnName = "SOBRE_PROVEEDOR_ID";
		public const string SOBRE_PROVEEDOR_NOMBREColumnName = "SOBRE_PROVEEDOR_NOMBRE";
		public const string SOBRE_FUNCIONARIO_IDColumnName = "SOBRE_FUNCIONARIO_ID";
		public const string SOBRE_FUNCIONARIO_NOMBREColumnName = "SOBRE_FUNCIONARIO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MENSAJES_SISTEMA_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MENSAJES_SISTEMA_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MENSAJES_SISTEMA_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		public virtual MENSAJES_SISTEMA_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MENSAJES_SISTEMA_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MENSAJES_SISTEMA_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MENSAJES_SISTEMA_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MENSAJES_SISTEMA_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		public MENSAJES_SISTEMA_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		public virtual MENSAJES_SISTEMA_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MENSAJES_SISTEMA_INFO_COMPL";
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		protected MENSAJES_SISTEMA_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		protected MENSAJES_SISTEMA_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> objects.</returns>
		protected virtual MENSAJES_SISTEMA_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_mensajeColumnIndex = reader.GetOrdinal("TIPO_MENSAJE");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int textoColumnIndex = reader.GetOrdinal("TEXTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int rol_descipcionColumnIndex = reader.GetOrdinal("ROL_DESCIPCION");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int sobre_articulo_idColumnIndex = reader.GetOrdinal("SOBRE_ARTICULO_ID");
			int sobre_articulo_codigoColumnIndex = reader.GetOrdinal("SOBRE_ARTICULO_CODIGO");
			int sobre_persona_idColumnIndex = reader.GetOrdinal("SOBRE_PERSONA_ID");
			int sobre_persona_nombreColumnIndex = reader.GetOrdinal("SOBRE_PERSONA_NOMBRE");
			int sobre_proveedor_idColumnIndex = reader.GetOrdinal("SOBRE_PROVEEDOR_ID");
			int sobre_proveedor_nombreColumnIndex = reader.GetOrdinal("SOBRE_PROVEEDOR_NOMBRE");
			int sobre_funcionario_idColumnIndex = reader.GetOrdinal("SOBRE_FUNCIONARIO_ID");
			int sobre_funcionario_nombreColumnIndex = reader.GetOrdinal("SOBRE_FUNCIONARIO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MENSAJES_SISTEMA_INFO_COMPLRow record = new MENSAJES_SISTEMA_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_MENSAJE = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_mensajeColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(entidad_idColumnIndex))
						record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(rol_idColumnIndex))
						record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);
					record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.TEXTO = Convert.ToString(reader.GetValue(textoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					if(!reader.IsDBNull(rol_descipcionColumnIndex))
						record.ROL_DESCIPCION = Convert.ToString(reader.GetValue(rol_descipcionColumnIndex));
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					if(!reader.IsDBNull(sobre_articulo_idColumnIndex))
						record.SOBRE_ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_articulo_codigoColumnIndex))
						record.SOBRE_ARTICULO_CODIGO = Convert.ToString(reader.GetValue(sobre_articulo_codigoColumnIndex));
					if(!reader.IsDBNull(sobre_persona_idColumnIndex))
						record.SOBRE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_persona_nombreColumnIndex))
						record.SOBRE_PERSONA_NOMBRE = Convert.ToString(reader.GetValue(sobre_persona_nombreColumnIndex));
					if(!reader.IsDBNull(sobre_proveedor_idColumnIndex))
						record.SOBRE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_proveedor_nombreColumnIndex))
						record.SOBRE_PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(sobre_proveedor_nombreColumnIndex));
					if(!reader.IsDBNull(sobre_funcionario_idColumnIndex))
						record.SOBRE_FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sobre_funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(sobre_funcionario_nombreColumnIndex))
						record.SOBRE_FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(sobre_funcionario_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MENSAJES_SISTEMA_INFO_COMPLRow[])(recordList.ToArray(typeof(MENSAJES_SISTEMA_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> object.</returns>
		protected virtual MENSAJES_SISTEMA_INFO_COMPLRow MapRow(DataRow row)
		{
			MENSAJES_SISTEMA_INFO_COMPLRow mappedObject = new MENSAJES_SISTEMA_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_MENSAJE"
			dataColumn = dataTable.Columns["TIPO_MENSAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MENSAJE = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "TEXTO"
			dataColumn = dataTable.Columns["TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "ROL_DESCIPCION"
			dataColumn = dataTable.Columns["ROL_DESCIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_DESCIPCION = (string)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "SOBRE_ARTICULO_ID"
			dataColumn = dataTable.Columns["SOBRE_ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_ARTICULO_ID = (decimal)row[dataColumn];
			// Column "SOBRE_ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["SOBRE_ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "SOBRE_PERSONA_ID"
			dataColumn = dataTable.Columns["SOBRE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "SOBRE_PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["SOBRE_PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "SOBRE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["SOBRE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SOBRE_PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["SOBRE_PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "SOBRE_FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["SOBRE_FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "SOBRE_FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["SOBRE_FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOBRE_FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MENSAJES_SISTEMA_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MENSAJES_SISTEMA_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MENSAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 154;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ROL_DESCIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOBRE_FUNCIONARIO_NOMBRE", typeof(string));
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

				case "TIPO_MENSAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ROL_DESCIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SOBRE_ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SOBRE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SOBRE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SOBRE_FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOBRE_FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MENSAJES_SISTEMA_INFO_COMPLCollection_Base class
}  // End of namespace
