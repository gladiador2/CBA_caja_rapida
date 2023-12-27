// <fileinfo name="AUTONUMERACIONES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="AUTONUMERACIONES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="AUTONUMERACIONES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AUTONUMERACIONES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";
		public const string TIPO_AUTONUMERACION_IDColumnName = "TIPO_AUTONUMERACION_ID";
		public const string TIPO_AUTONUMERACION_NOMBREColumnName = "TIPO_AUTONUMERACION_NOMBRE";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string LIMITE_INFERIORColumnName = "LIMITE_INFERIOR";
		public const string LIMITE_SUPERIORColumnName = "LIMITE_SUPERIOR";
		public const string CANTIDAD_CARACTERESColumnName = "CANTIDAD_CARACTERES";
		public const string PREFIJOColumnName = "PREFIJO";
		public const string SUFIJOColumnName = "SUFIJO";
		public const string NUMERO_ACTUALColumnName = "NUMERO_ACTUAL";
		public const string NUMERO_TIMBRADOColumnName = "NUMERO_TIMBRADO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string VENCIMIENTOColumnName = "VENCIMIENTO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_AGOTO_NUMERACIONColumnName = "FECHA_AGOTO_NUMERACION";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string CTACTEColumnName = "CTACTE";
		public const string ESTADOColumnName = "ESTADO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string TIPO_GENERACIONColumnName = "TIPO_GENERACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_USO_EXCLUSIVOColumnName = "FUNCIONARIO_USO_EXCLUSIVO";
		public const string FUNCIONARIO_NOMBREColumnName = "FUNCIONARIO_NOMBRE";
		public const string FUNCIONARIO_CODIGOColumnName = "FUNCIONARIO_CODIGO";
		public const string IMPRIMIBLEColumnName = "IMPRIMIBLE";
		public const string AUTONUMERACION_SIGUIENTE_IDColumnName = "AUTONUMERACION_SIGUIENTE_ID";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string IMPRESION_DELTA_ALTURAColumnName = "IMPRESION_DELTA_ALTURA";
		public const string DETALLES_CANTIDAD_MAXIMAColumnName = "DETALLES_CANTIDAD_MAXIMA";
		public const string IMPRESION_DELTA_ANCHOColumnName = "IMPRESION_DELTA_ANCHO";
		public const string ELECTRONICOColumnName = "ELECTRONICO";
		public const string ARTICULOS_FAMILIA_IDColumnName = "ARTICULOS_FAMILIA_ID";
		public const string FAMILIAColumnName = "FAMILIA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="AUTONUMERACIONES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public AUTONUMERACIONES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>AUTONUMERACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		public virtual AUTONUMERACIONES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>AUTONUMERACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>AUTONUMERACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public AUTONUMERACIONES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			AUTONUMERACIONES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		public AUTONUMERACIONES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		public virtual AUTONUMERACIONES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.AUTONUMERACIONES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected AUTONUMERACIONES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected AUTONUMERACIONES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual AUTONUMERACIONES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");
			int tipo_autonumeracion_idColumnIndex = reader.GetOrdinal("TIPO_AUTONUMERACION_ID");
			int tipo_autonumeracion_nombreColumnIndex = reader.GetOrdinal("TIPO_AUTONUMERACION_NOMBRE");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int limite_inferiorColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR");
			int limite_superiorColumnIndex = reader.GetOrdinal("LIMITE_SUPERIOR");
			int cantidad_caracteresColumnIndex = reader.GetOrdinal("CANTIDAD_CARACTERES");
			int prefijoColumnIndex = reader.GetOrdinal("PREFIJO");
			int sufijoColumnIndex = reader.GetOrdinal("SUFIJO");
			int numero_actualColumnIndex = reader.GetOrdinal("NUMERO_ACTUAL");
			int numero_timbradoColumnIndex = reader.GetOrdinal("NUMERO_TIMBRADO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int vencimientoColumnIndex = reader.GetOrdinal("VENCIMIENTO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_agoto_numeracionColumnIndex = reader.GetOrdinal("FECHA_AGOTO_NUMERACION");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int ctacteColumnIndex = reader.GetOrdinal("CTACTE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int tipo_generacionColumnIndex = reader.GetOrdinal("TIPO_GENERACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_uso_exclusivoColumnIndex = reader.GetOrdinal("FUNCIONARIO_USO_EXCLUSIVO");
			int funcionario_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE");
			int funcionario_codigoColumnIndex = reader.GetOrdinal("FUNCIONARIO_CODIGO");
			int imprimibleColumnIndex = reader.GetOrdinal("IMPRIMIBLE");
			int autonumeracion_siguiente_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_SIGUIENTE_ID");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int impresion_delta_alturaColumnIndex = reader.GetOrdinal("IMPRESION_DELTA_ALTURA");
			int detalles_cantidad_maximaColumnIndex = reader.GetOrdinal("DETALLES_CANTIDAD_MAXIMA");
			int impresion_delta_anchoColumnIndex = reader.GetOrdinal("IMPRESION_DELTA_ANCHO");
			int electronicoColumnIndex = reader.GetOrdinal("ELECTRONICO");
			int articulos_familia_idColumnIndex = reader.GetOrdinal("ARTICULOS_FAMILIA_ID");
			int familiaColumnIndex = reader.GetOrdinal("FAMILIA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					AUTONUMERACIONES_INFO_COMPLETARow record = new AUTONUMERACIONES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));
					record.TIPO_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_autonumeracion_idColumnIndex)), 9);
					record.TIPO_AUTONUMERACION_NOMBRE = Convert.ToString(reader.GetValue(tipo_autonumeracion_nombreColumnIndex));
					if(!reader.IsDBNull(tabla_idColumnIndex))
						record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					record.LIMITE_INFERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferiorColumnIndex)), 9);
					record.LIMITE_SUPERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_superiorColumnIndex)), 9);
					record.CANTIDAD_CARACTERES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_caracteresColumnIndex)), 9);
					if(!reader.IsDBNull(prefijoColumnIndex))
						record.PREFIJO = Convert.ToString(reader.GetValue(prefijoColumnIndex));
					if(!reader.IsDBNull(sufijoColumnIndex))
						record.SUFIJO = Convert.ToString(reader.GetValue(sufijoColumnIndex));
					record.NUMERO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(numero_actualColumnIndex)), 9);
					if(!reader.IsDBNull(numero_timbradoColumnIndex))
						record.NUMERO_TIMBRADO = Convert.ToString(reader.GetValue(numero_timbradoColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(vencimientoColumnIndex))
						record.VENCIMIENTO = Convert.ToDateTime(reader.GetValue(vencimientoColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(fecha_agoto_numeracionColumnIndex))
						record.FECHA_AGOTO_NUMERACION = Convert.ToDateTime(reader.GetValue(fecha_agoto_numeracionColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_idColumnIndex))
						record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacteColumnIndex))
						record.CTACTE = Convert.ToString(reader.GetValue(ctacteColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					record.TIPO_GENERACION = Convert.ToString(reader.GetValue(tipo_generacionColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.FUNCIONARIO_USO_EXCLUSIVO = Convert.ToString(reader.GetValue(funcionario_uso_exclusivoColumnIndex));
					if(!reader.IsDBNull(funcionario_nombreColumnIndex))
						record.FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_codigoColumnIndex))
						record.FUNCIONARIO_CODIGO = Convert.ToString(reader.GetValue(funcionario_codigoColumnIndex));
					record.IMPRIMIBLE = Convert.ToString(reader.GetValue(imprimibleColumnIndex));
					if(!reader.IsDBNull(autonumeracion_siguiente_idColumnIndex))
						record.AUTONUMERACION_SIGUIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_siguiente_idColumnIndex)), 9);
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.IMPRESION_DELTA_ALTURA = Math.Round(Convert.ToDecimal(reader.GetValue(impresion_delta_alturaColumnIndex)), 9);
					if(!reader.IsDBNull(detalles_cantidad_maximaColumnIndex))
						record.DETALLES_CANTIDAD_MAXIMA = Math.Round(Convert.ToDecimal(reader.GetValue(detalles_cantidad_maximaColumnIndex)), 9);
					record.IMPRESION_DELTA_ANCHO = Math.Round(Convert.ToDecimal(reader.GetValue(impresion_delta_anchoColumnIndex)), 9);
					record.ELECTRONICO = Convert.ToString(reader.GetValue(electronicoColumnIndex));
					if(!reader.IsDBNull(articulos_familia_idColumnIndex))
						record.ARTICULOS_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(familiaColumnIndex))
						record.FAMILIA = Convert.ToString(reader.GetValue(familiaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AUTONUMERACIONES_INFO_COMPLETARow[])(recordList.ToArray(typeof(AUTONUMERACIONES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="AUTONUMERACIONES_INFO_COMPLETARow"/> object.</returns>
		protected virtual AUTONUMERACIONES_INFO_COMPLETARow MapRow(DataRow row)
		{
			AUTONUMERACIONES_INFO_COMPLETARow mappedObject = new AUTONUMERACIONES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "TIPO_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["TIPO_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "TIPO_AUTONUMERACION_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_AUTONUMERACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_AUTONUMERACION_NOMBRE = (string)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "LIMITE_INFERIOR"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR = (decimal)row[dataColumn];
			// Column "LIMITE_SUPERIOR"
			dataColumn = dataTable.Columns["LIMITE_SUPERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_SUPERIOR = (decimal)row[dataColumn];
			// Column "CANTIDAD_CARACTERES"
			dataColumn = dataTable.Columns["CANTIDAD_CARACTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CARACTERES = (decimal)row[dataColumn];
			// Column "PREFIJO"
			dataColumn = dataTable.Columns["PREFIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREFIJO = (string)row[dataColumn];
			// Column "SUFIJO"
			dataColumn = dataTable.Columns["SUFIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUFIJO = (string)row[dataColumn];
			// Column "NUMERO_ACTUAL"
			dataColumn = dataTable.Columns["NUMERO_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_ACTUAL = (decimal)row[dataColumn];
			// Column "NUMERO_TIMBRADO"
			dataColumn = dataTable.Columns["NUMERO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_TIMBRADO = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "VENCIMIENTO"
			dataColumn = dataTable.Columns["VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_AGOTO_NUMERACION"
			dataColumn = dataTable.Columns["FECHA_AGOTO_NUMERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_AGOTO_NUMERACION = (System.DateTime)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE"
			dataColumn = dataTable.Columns["CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_GENERACION"
			dataColumn = dataTable.Columns["TIPO_GENERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_GENERACION = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_USO_EXCLUSIVO"
			dataColumn = dataTable.Columns["FUNCIONARIO_USO_EXCLUSIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_USO_EXCLUSIVO = (string)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_CODIGO"
			dataColumn = dataTable.Columns["FUNCIONARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CODIGO = (string)row[dataColumn];
			// Column "IMPRIMIBLE"
			dataColumn = dataTable.Columns["IMPRIMIBLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRIMIBLE = (string)row[dataColumn];
			// Column "AUTONUMERACION_SIGUIENTE_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_SIGUIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_SIGUIENTE_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "IMPRESION_DELTA_ALTURA"
			dataColumn = dataTable.Columns["IMPRESION_DELTA_ALTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESION_DELTA_ALTURA = (decimal)row[dataColumn];
			// Column "DETALLES_CANTIDAD_MAXIMA"
			dataColumn = dataTable.Columns["DETALLES_CANTIDAD_MAXIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DETALLES_CANTIDAD_MAXIMA = (decimal)row[dataColumn];
			// Column "IMPRESION_DELTA_ANCHO"
			dataColumn = dataTable.Columns["IMPRESION_DELTA_ANCHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESION_DELTA_ANCHO = (decimal)row[dataColumn];
			// Column "ELECTRONICO"
			dataColumn = dataTable.Columns["ELECTRONICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ELECTRONICO = (string)row[dataColumn];
			// Column "ARTICULOS_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULOS_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "FAMILIA"
			dataColumn = dataTable.Columns["FAMILIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>AUTONUMERACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "AUTONUMERACIONES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_AUTONUMERACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LIMITE_SUPERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CARACTERES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PREFIJO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUFIJO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_AGOTO_NUMERACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_GENERACION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_USO_EXCLUSIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRIMIBLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_SIGUIENTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESION_DELTA_ALTURA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DETALLES_CANTIDAD_MAXIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESION_DELTA_ANCHO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ELECTRONICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA", typeof(string));
			dataColumn.MaxLength = 30;
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

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_AUTONUMERACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_INFERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_SUPERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CARACTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PREFIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUFIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_AGOTO_NUMERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_GENERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_USO_EXCLUSIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRIMIBLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUTONUMERACION_SIGUIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESION_DELTA_ALTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DETALLES_CANTIDAD_MAXIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESION_DELTA_ANCHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ELECTRONICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULOS_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of AUTONUMERACIONES_INFO_COMPLETACollection_Base class
}  // End of namespace
