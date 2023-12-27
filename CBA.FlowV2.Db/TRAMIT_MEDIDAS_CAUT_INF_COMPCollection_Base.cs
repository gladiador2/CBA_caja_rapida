// <fileinfo name="TRAMIT_MEDIDAS_CAUT_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_MEDIDAS_CAUT_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEXTO_PREDEFINIDO_ID_TIPOColumnName = "TEXTO_PREDEFINIDO_ID_TIPO";
		public const string TIPO_TEXTO_PREDEF_NOMBRE_TIPOColumnName = "TIPO_TEXTO_PREDEF_NOMBRE_TIPO";
		public const string TEXTO_PREDEF_TIPOColumnName = "TEXTO_PREDEF_TIPO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TRAMITE_IDColumnName = "TRAMITE_ID";
		public const string TRAMITE_TIPO_IDColumnName = "TRAMITE_TIPO_ID";
		public const string TRAMITE_TIPO_NOMBREColumnName = "TRAMITE_TIPO_NOMBRE";
		public const string TITULOColumnName = "TITULO";
		public const string FECHA_OTORGAMIENTOColumnName = "FECHA_OTORGAMIENTO";
		public const string FECHA_INSCRIPCIONColumnName = "FECHA_INSCRIPCION";
		public const string MONTO_EMBARGADOColumnName = "MONTO_EMBARGADO";
		public const string NRO_CUENTA_BANCARIAColumnName = "NRO_CUENTA_BANCARIA";
		public const string ENTIDADColumnName = "ENTIDAD";
		public const string CUENTAColumnName = "CUENTA";
		public const string TEXTO_PREDEFINIDO_ID_BIENColumnName = "TEXTO_PREDEFINIDO_ID_BIEN";
		public const string TIPO_TEXTO_PREDEF_NOMBRE_BIENColumnName = "TIPO_TEXTO_PREDEF_NOMBRE_BIEN";
		public const string TEXTO_PREDEF_BIENColumnName = "TEXTO_PREDEF_BIEN";
		public const string DATOS_DEL_BIENColumnName = "DATOS_DEL_BIEN";
		public const string OTROS_EMBARGOS_BIENColumnName = "OTROS_EMBARGOS_BIEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAMIT_MEDIDAS_CAUT_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAMIT_MEDIDAS_CAUT_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		public virtual TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAMIT_MEDIDAS_CAUT_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAMIT_MEDIDAS_CAUT_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAMIT_MEDIDAS_CAUT_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		public TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		public virtual TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAMIT_MEDIDAS_CAUT_INF_COMP";
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
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		protected TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		protected TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> objects.</returns>
		protected virtual TRAMIT_MEDIDAS_CAUT_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int texto_predefinido_id_tipoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID_TIPO");
			int tipo_texto_predef_nombre_tipoColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEF_NOMBRE_TIPO");
			int texto_predef_tipoColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_TIPO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int tramite_idColumnIndex = reader.GetOrdinal("TRAMITE_ID");
			int tramite_tipo_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ID");
			int tramite_tipo_nombreColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_NOMBRE");
			int tituloColumnIndex = reader.GetOrdinal("TITULO");
			int fecha_otorgamientoColumnIndex = reader.GetOrdinal("FECHA_OTORGAMIENTO");
			int fecha_inscripcionColumnIndex = reader.GetOrdinal("FECHA_INSCRIPCION");
			int monto_embargadoColumnIndex = reader.GetOrdinal("MONTO_EMBARGADO");
			int nro_cuenta_bancariaColumnIndex = reader.GetOrdinal("NRO_CUENTA_BANCARIA");
			int entidadColumnIndex = reader.GetOrdinal("ENTIDAD");
			int cuentaColumnIndex = reader.GetOrdinal("CUENTA");
			int texto_predefinido_id_bienColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID_BIEN");
			int tipo_texto_predef_nombre_bienColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEF_NOMBRE_BIEN");
			int texto_predef_bienColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_BIEN");
			int datos_del_bienColumnIndex = reader.GetOrdinal("DATOS_DEL_BIEN");
			int otros_embargos_bienColumnIndex = reader.GetOrdinal("OTROS_EMBARGOS_BIEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAMIT_MEDIDAS_CAUT_INF_COMPRow record = new TRAMIT_MEDIDAS_CAUT_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TEXTO_PREDEFINIDO_ID_TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_id_tipoColumnIndex)), 9);
					record.TIPO_TEXTO_PREDEF_NOMBRE_TIPO = Convert.ToString(reader.GetValue(tipo_texto_predef_nombre_tipoColumnIndex));
					record.TEXTO_PREDEF_TIPO = Convert.ToString(reader.GetValue(texto_predef_tipoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.TRAMITE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_idColumnIndex)), 9);
					record.TRAMITE_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_idColumnIndex)), 9);
					record.TRAMITE_TIPO_NOMBRE = Convert.ToString(reader.GetValue(tramite_tipo_nombreColumnIndex));
					if(!reader.IsDBNull(tituloColumnIndex))
						record.TITULO = Convert.ToString(reader.GetValue(tituloColumnIndex));
					if(!reader.IsDBNull(fecha_otorgamientoColumnIndex))
						record.FECHA_OTORGAMIENTO = Convert.ToDateTime(reader.GetValue(fecha_otorgamientoColumnIndex));
					record.FECHA_INSCRIPCION = Convert.ToDateTime(reader.GetValue(fecha_inscripcionColumnIndex));
					if(!reader.IsDBNull(monto_embargadoColumnIndex))
						record.MONTO_EMBARGADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_embargadoColumnIndex)), 9);
					if(!reader.IsDBNull(nro_cuenta_bancariaColumnIndex))
						record.NRO_CUENTA_BANCARIA = Convert.ToString(reader.GetValue(nro_cuenta_bancariaColumnIndex));
					if(!reader.IsDBNull(entidadColumnIndex))
						record.ENTIDAD = Convert.ToString(reader.GetValue(entidadColumnIndex));
					if(!reader.IsDBNull(cuentaColumnIndex))
						record.CUENTA = Convert.ToString(reader.GetValue(cuentaColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_id_bienColumnIndex))
						record.TEXTO_PREDEFINIDO_ID_BIEN = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_id_bienColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_texto_predef_nombre_bienColumnIndex))
						record.TIPO_TEXTO_PREDEF_NOMBRE_BIEN = Convert.ToString(reader.GetValue(tipo_texto_predef_nombre_bienColumnIndex));
					if(!reader.IsDBNull(texto_predef_bienColumnIndex))
						record.TEXTO_PREDEF_BIEN = Convert.ToString(reader.GetValue(texto_predef_bienColumnIndex));
					if(!reader.IsDBNull(datos_del_bienColumnIndex))
						record.DATOS_DEL_BIEN = Convert.ToString(reader.GetValue(datos_del_bienColumnIndex));
					if(!reader.IsDBNull(otros_embargos_bienColumnIndex))
						record.OTROS_EMBARGOS_BIEN = Convert.ToString(reader.GetValue(otros_embargos_bienColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAMIT_MEDIDAS_CAUT_INF_COMPRow[])(recordList.ToArray(typeof(TRAMIT_MEDIDAS_CAUT_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> object.</returns>
		protected virtual TRAMIT_MEDIDAS_CAUT_INF_COMPRow MapRow(DataRow row)
		{
			TRAMIT_MEDIDAS_CAUT_INF_COMPRow mappedObject = new TRAMIT_MEDIDAS_CAUT_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID_TIPO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID_TIPO = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEF_NOMBRE_TIPO"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEF_NOMBRE_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEF_NOMBRE_TIPO = (string)row[dataColumn];
			// Column "TEXTO_PREDEF_TIPO"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_TIPO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TRAMITE_ID"
			dataColumn = dataTable.Columns["TRAMITE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_ID"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_NOMBRE"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_NOMBRE = (string)row[dataColumn];
			// Column "TITULO"
			dataColumn = dataTable.Columns["TITULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULO = (string)row[dataColumn];
			// Column "FECHA_OTORGAMIENTO"
			dataColumn = dataTable.Columns["FECHA_OTORGAMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_OTORGAMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INSCRIPCION"
			dataColumn = dataTable.Columns["FECHA_INSCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSCRIPCION = (System.DateTime)row[dataColumn];
			// Column "MONTO_EMBARGADO"
			dataColumn = dataTable.Columns["MONTO_EMBARGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EMBARGADO = (decimal)row[dataColumn];
			// Column "NRO_CUENTA_BANCARIA"
			dataColumn = dataTable.Columns["NRO_CUENTA_BANCARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CUENTA_BANCARIA = (string)row[dataColumn];
			// Column "ENTIDAD"
			dataColumn = dataTable.Columns["ENTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD = (string)row[dataColumn];
			// Column "CUENTA"
			dataColumn = dataTable.Columns["CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID_BIEN"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID_BIEN = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEF_NOMBRE_BIEN"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEF_NOMBRE_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEF_NOMBRE_BIEN = (string)row[dataColumn];
			// Column "TEXTO_PREDEF_BIEN"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_BIEN = (string)row[dataColumn];
			// Column "DATOS_DEL_BIEN"
			dataColumn = dataTable.Columns["DATOS_DEL_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DATOS_DEL_BIEN = (string)row[dataColumn];
			// Column "OTROS_EMBARGOS_BIEN"
			dataColumn = dataTable.Columns["OTROS_EMBARGOS_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.OTROS_EMBARGOS_BIEN = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAMIT_MEDIDAS_CAUT_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAMIT_MEDIDAS_CAUT_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID_TIPO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEF_NOMBRE_TIPO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_TIPO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TITULO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_OTORGAMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSCRIPCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_EMBARGADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_CUENTA_BANCARIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID_BIEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEF_NOMBRE_BIEN", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_BIEN", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DATOS_DEL_BIEN", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OTROS_EMBARGOS_BIEN", typeof(string));
			dataColumn.MaxLength = 500;
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

				case "TEXTO_PREDEFINIDO_ID_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEF_NOMBRE_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEF_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRAMITE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITE_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITE_TIPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TITULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_OTORGAMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INSCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_EMBARGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CUENTA_BANCARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEF_NOMBRE_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEF_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DATOS_DEL_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OTROS_EMBARGOS_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAMIT_MEDIDAS_CAUT_INF_COMPCollection_Base class
}  // End of namespace
