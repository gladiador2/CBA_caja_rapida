// <fileinfo name="NOMINA_CONTENED_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENED_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOMINA_CONTENED_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENED_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMINA_CONTENEDORES_IDColumnName = "NOMINA_CONTENEDORES_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENEDOR_LINEAColumnName = "CONTENEDOR_LINEA";
		public const string CONTENEDOR_TIPOColumnName = "CONTENEDOR_TIPO";
		public const string CONTENEDOR_CLASEColumnName = "CONTENEDOR_CLASE";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PUERTA_MOVIMIENTO_ENTREGA_IDColumnName = "PUERTA_MOVIMIENTO_ENTREGA_ID";
		public const string GIO_ENTREGA_NUMEROColumnName = "GIO_ENTREGA_NUMERO";
		public const string FECHA_ENTREGAColumnName = "FECHA_ENTREGA";
		public const string GIO_ENTREGA_CONFIRMADOColumnName = "GIO_ENTREGA_CONFIRMADO";
		public const string GIO_ENTREGA_PERSONA_IDColumnName = "GIO_ENTREGA_PERSONA_ID";
		public const string GIO_ENTREGA_PERSONA_NOMBREColumnName = "GIO_ENTREGA_PERSONA_NOMBRE";
		public const string PUERTA_MOVIMIENTO_DEVOLUC_IDColumnName = "PUERTA_MOVIMIENTO_DEVOLUC_ID";
		public const string GIO_DEVOLUCION_NUMEROColumnName = "GIO_DEVOLUCION_NUMERO";
		public const string FECHA_DEVOLUCIONColumnName = "FECHA_DEVOLUCION";
		public const string GIO_DEVOLUCION_CONFIRMADOColumnName = "GIO_DEVOLUCION_CONFIRMADO";
		public const string GIO_DEVOLUCION_PERSONA_IDColumnName = "GIO_DEVOLUCION_PERSONA_ID";
		public const string GIO_DEVOLUCION_PERSONA_NOMBREColumnName = "GIO_DEVOLUCION_PERSONA_NOMBRE";
		public const string GIO_DEVOLUCION_BOOKINGColumnName = "GIO_DEVOLUCION_BOOKING";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_CREADORColumnName = "USUARIO_CREADOR";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string USUARIO_MODIFICACIONColumnName = "USUARIO_MODIFICACION";
		public const string RECHAZADOColumnName = "RECHAZADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CONTENEDORES_OPERACIONES_IDColumnName = "CONTENEDORES_OPERACIONES_ID";
		public const string CONSOLIDACION_FECHAColumnName = "CONSOLIDACION_FECHA";
		public const string CONSOLIDACION_NROColumnName = "CONSOLIDACION_NRO";
		public const string CONSOLIDACION_PROCESADOColumnName = "CONSOLIDACION_PROCESADO";
		public const string CONSOLIDACION_CLIENTEColumnName = "CONSOLIDACION_CLIENTE";
		public const string PRE_EMBARQUE_CONTENEDOR_IDColumnName = "PRE_EMBARQUE_CONTENEDOR_ID";
		public const string ESTA_EN_PRE_EMBARQUEColumnName = "ESTA_EN_PRE_EMBARQUE";
		public const string INTERCAMBIO_EQUIPO_IDColumnName = "INTERCAMBIO_EQUIPO_ID";
		public const string INTERCAMBIO_BUQUEColumnName = "INTERCAMBIO_BUQUE";
		public const string INERCAMBIO_NUMEROColumnName = "INERCAMBIO_NUMERO";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";
		public const string PUERTO_DEVOLUCION_NOMBREColumnName = "PUERTO_DEVOLUCION_NOMBRE";
		public const string PUERTO_DEVOLUCION_ABREVIATURAColumnName = "PUERTO_DEVOLUCION_ABREVIATURA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENED_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOMINA_CONTENED_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOMINA_CONTENED_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual NOMINA_CONTENED_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOMINA_CONTENED_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOMINA_CONTENED_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOMINA_CONTENED_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOMINA_CONTENED_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		public NOMINA_CONTENED_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual NOMINA_CONTENED_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOMINA_CONTENED_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		protected NOMINA_CONTENED_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		protected NOMINA_CONTENED_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual NOMINA_CONTENED_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nomina_contenedores_idColumnIndex = reader.GetOrdinal("NOMINA_CONTENEDORES_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contenedor_lineaColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA");
			int contenedor_tipoColumnIndex = reader.GetOrdinal("CONTENEDOR_TIPO");
			int contenedor_claseColumnIndex = reader.GetOrdinal("CONTENEDOR_CLASE");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int puerta_movimiento_entrega_idColumnIndex = reader.GetOrdinal("PUERTA_MOVIMIENTO_ENTREGA_ID");
			int gio_entrega_numeroColumnIndex = reader.GetOrdinal("GIO_ENTREGA_NUMERO");
			int fecha_entregaColumnIndex = reader.GetOrdinal("FECHA_ENTREGA");
			int gio_entrega_confirmadoColumnIndex = reader.GetOrdinal("GIO_ENTREGA_CONFIRMADO");
			int gio_entrega_persona_idColumnIndex = reader.GetOrdinal("GIO_ENTREGA_PERSONA_ID");
			int gio_entrega_persona_nombreColumnIndex = reader.GetOrdinal("GIO_ENTREGA_PERSONA_NOMBRE");
			int puerta_movimiento_devoluc_idColumnIndex = reader.GetOrdinal("PUERTA_MOVIMIENTO_DEVOLUC_ID");
			int gio_devolucion_numeroColumnIndex = reader.GetOrdinal("GIO_DEVOLUCION_NUMERO");
			int fecha_devolucionColumnIndex = reader.GetOrdinal("FECHA_DEVOLUCION");
			int gio_devolucion_confirmadoColumnIndex = reader.GetOrdinal("GIO_DEVOLUCION_CONFIRMADO");
			int gio_devolucion_persona_idColumnIndex = reader.GetOrdinal("GIO_DEVOLUCION_PERSONA_ID");
			int gio_devolucion_persona_nombreColumnIndex = reader.GetOrdinal("GIO_DEVOLUCION_PERSONA_NOMBRE");
			int gio_devolucion_bookingColumnIndex = reader.GetOrdinal("GIO_DEVOLUCION_BOOKING");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_creadorColumnIndex = reader.GetOrdinal("USUARIO_CREADOR");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int usuario_modificacionColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION");
			int rechazadoColumnIndex = reader.GetOrdinal("RECHAZADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int contenedores_operaciones_idColumnIndex = reader.GetOrdinal("CONTENEDORES_OPERACIONES_ID");
			int consolidacion_fechaColumnIndex = reader.GetOrdinal("CONSOLIDACION_FECHA");
			int consolidacion_nroColumnIndex = reader.GetOrdinal("CONSOLIDACION_NRO");
			int consolidacion_procesadoColumnIndex = reader.GetOrdinal("CONSOLIDACION_PROCESADO");
			int consolidacion_clienteColumnIndex = reader.GetOrdinal("CONSOLIDACION_CLIENTE");
			int pre_embarque_contenedor_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_CONTENEDOR_ID");
			int esta_en_pre_embarqueColumnIndex = reader.GetOrdinal("ESTA_EN_PRE_EMBARQUE");
			int intercambio_equipo_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPO_ID");
			int intercambio_buqueColumnIndex = reader.GetOrdinal("INTERCAMBIO_BUQUE");
			int inercambio_numeroColumnIndex = reader.GetOrdinal("INERCAMBIO_NUMERO");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");
			int puerto_devolucion_nombreColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_NOMBRE");
			int puerto_devolucion_abreviaturaColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ABREVIATURA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOMINA_CONTENED_DET_INFO_COMPLRow record = new NOMINA_CONTENED_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nomina_contenedores_idColumnIndex))
						record.NOMINA_CONTENEDORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nomina_contenedores_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(contenedor_lineaColumnIndex))
						record.CONTENEDOR_LINEA = Convert.ToString(reader.GetValue(contenedor_lineaColumnIndex));
					if(!reader.IsDBNull(contenedor_tipoColumnIndex))
						record.CONTENEDOR_TIPO = Convert.ToString(reader.GetValue(contenedor_tipoColumnIndex));
					record.CONTENEDOR_CLASE = Convert.ToString(reader.GetValue(contenedor_claseColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(puerta_movimiento_entrega_idColumnIndex))
						record.PUERTA_MOVIMIENTO_ENTREGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerta_movimiento_entrega_idColumnIndex)), 9);
					if(!reader.IsDBNull(gio_entrega_numeroColumnIndex))
						record.GIO_ENTREGA_NUMERO = Convert.ToString(reader.GetValue(gio_entrega_numeroColumnIndex));
					if(!reader.IsDBNull(fecha_entregaColumnIndex))
						record.FECHA_ENTREGA = Convert.ToDateTime(reader.GetValue(fecha_entregaColumnIndex));
					if(!reader.IsDBNull(gio_entrega_confirmadoColumnIndex))
						record.GIO_ENTREGA_CONFIRMADO = Convert.ToString(reader.GetValue(gio_entrega_confirmadoColumnIndex));
					if(!reader.IsDBNull(gio_entrega_persona_idColumnIndex))
						record.GIO_ENTREGA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(gio_entrega_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(gio_entrega_persona_nombreColumnIndex))
						record.GIO_ENTREGA_PERSONA_NOMBRE = Convert.ToString(reader.GetValue(gio_entrega_persona_nombreColumnIndex));
					if(!reader.IsDBNull(puerta_movimiento_devoluc_idColumnIndex))
						record.PUERTA_MOVIMIENTO_DEVOLUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerta_movimiento_devoluc_idColumnIndex)), 9);
					if(!reader.IsDBNull(gio_devolucion_numeroColumnIndex))
						record.GIO_DEVOLUCION_NUMERO = Convert.ToString(reader.GetValue(gio_devolucion_numeroColumnIndex));
					if(!reader.IsDBNull(fecha_devolucionColumnIndex))
						record.FECHA_DEVOLUCION = Convert.ToDateTime(reader.GetValue(fecha_devolucionColumnIndex));
					if(!reader.IsDBNull(gio_devolucion_confirmadoColumnIndex))
						record.GIO_DEVOLUCION_CONFIRMADO = Convert.ToString(reader.GetValue(gio_devolucion_confirmadoColumnIndex));
					if(!reader.IsDBNull(gio_devolucion_persona_idColumnIndex))
						record.GIO_DEVOLUCION_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(gio_devolucion_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(gio_devolucion_persona_nombreColumnIndex))
						record.GIO_DEVOLUCION_PERSONA_NOMBRE = Convert.ToString(reader.GetValue(gio_devolucion_persona_nombreColumnIndex));
					if(!reader.IsDBNull(gio_devolucion_bookingColumnIndex))
						record.GIO_DEVOLUCION_BOOKING = Convert.ToString(reader.GetValue(gio_devolucion_bookingColumnIndex));
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creadorColumnIndex))
						record.USUARIO_CREADOR = Convert.ToString(reader.GetValue(usuario_creadorColumnIndex));
					if(!reader.IsDBNull(usuario_modificacion_idColumnIndex))
						record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_modificacionColumnIndex))
						record.USUARIO_MODIFICACION = Convert.ToString(reader.GetValue(usuario_modificacionColumnIndex));
					if(!reader.IsDBNull(rechazadoColumnIndex))
						record.RECHAZADO = Convert.ToString(reader.GetValue(rechazadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(contenedores_operaciones_idColumnIndex))
						record.CONTENEDORES_OPERACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedores_operaciones_idColumnIndex)), 9);
					if(!reader.IsDBNull(consolidacion_fechaColumnIndex))
						record.CONSOLIDACION_FECHA = Convert.ToDateTime(reader.GetValue(consolidacion_fechaColumnIndex));
					if(!reader.IsDBNull(consolidacion_nroColumnIndex))
						record.CONSOLIDACION_NRO = Convert.ToString(reader.GetValue(consolidacion_nroColumnIndex));
					if(!reader.IsDBNull(consolidacion_procesadoColumnIndex))
						record.CONSOLIDACION_PROCESADO = Convert.ToString(reader.GetValue(consolidacion_procesadoColumnIndex));
					if(!reader.IsDBNull(consolidacion_clienteColumnIndex))
						record.CONSOLIDACION_CLIENTE = Convert.ToString(reader.GetValue(consolidacion_clienteColumnIndex));
					if(!reader.IsDBNull(pre_embarque_contenedor_idColumnIndex))
						record.PRE_EMBARQUE_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(esta_en_pre_embarqueColumnIndex))
						record.ESTA_EN_PRE_EMBARQUE = Convert.ToString(reader.GetValue(esta_en_pre_embarqueColumnIndex));
					if(!reader.IsDBNull(intercambio_equipo_idColumnIndex))
						record.INTERCAMBIO_EQUIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(intercambio_buqueColumnIndex))
						record.INTERCAMBIO_BUQUE = Convert.ToString(reader.GetValue(intercambio_buqueColumnIndex));
					if(!reader.IsDBNull(inercambio_numeroColumnIndex))
						record.INERCAMBIO_NUMERO = Convert.ToString(reader.GetValue(inercambio_numeroColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_devolucion_nombreColumnIndex))
						record.PUERTO_DEVOLUCION_NOMBRE = Convert.ToString(reader.GetValue(puerto_devolucion_nombreColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_abreviaturaColumnIndex))
						record.PUERTO_DEVOLUCION_ABREVIATURA = Convert.ToString(reader.GetValue(puerto_devolucion_abreviaturaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOMINA_CONTENED_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(NOMINA_CONTENED_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual NOMINA_CONTENED_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			NOMINA_CONTENED_DET_INFO_COMPLRow mappedObject = new NOMINA_CONTENED_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMINA_CONTENEDORES_ID"
			dataColumn = dataTable.Columns["NOMINA_CONTENEDORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMINA_CONTENEDORES_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENEDOR_LINEA"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA = (string)row[dataColumn];
			// Column "CONTENEDOR_TIPO"
			dataColumn = dataTable.Columns["CONTENEDOR_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TIPO = (string)row[dataColumn];
			// Column "CONTENEDOR_CLASE"
			dataColumn = dataTable.Columns["CONTENEDOR_CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_CLASE = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PUERTA_MOVIMIENTO_ENTREGA_ID"
			dataColumn = dataTable.Columns["PUERTA_MOVIMIENTO_ENTREGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA_MOVIMIENTO_ENTREGA_ID = (decimal)row[dataColumn];
			// Column "GIO_ENTREGA_NUMERO"
			dataColumn = dataTable.Columns["GIO_ENTREGA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_ENTREGA_NUMERO = (string)row[dataColumn];
			// Column "FECHA_ENTREGA"
			dataColumn = dataTable.Columns["FECHA_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTREGA = (System.DateTime)row[dataColumn];
			// Column "GIO_ENTREGA_CONFIRMADO"
			dataColumn = dataTable.Columns["GIO_ENTREGA_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_ENTREGA_CONFIRMADO = (string)row[dataColumn];
			// Column "GIO_ENTREGA_PERSONA_ID"
			dataColumn = dataTable.Columns["GIO_ENTREGA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_ENTREGA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "GIO_ENTREGA_PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["GIO_ENTREGA_PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_ENTREGA_PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PUERTA_MOVIMIENTO_DEVOLUC_ID"
			dataColumn = dataTable.Columns["PUERTA_MOVIMIENTO_DEVOLUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA_MOVIMIENTO_DEVOLUC_ID = (decimal)row[dataColumn];
			// Column "GIO_DEVOLUCION_NUMERO"
			dataColumn = dataTable.Columns["GIO_DEVOLUCION_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_DEVOLUCION_NUMERO = (string)row[dataColumn];
			// Column "FECHA_DEVOLUCION"
			dataColumn = dataTable.Columns["FECHA_DEVOLUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DEVOLUCION = (System.DateTime)row[dataColumn];
			// Column "GIO_DEVOLUCION_CONFIRMADO"
			dataColumn = dataTable.Columns["GIO_DEVOLUCION_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_DEVOLUCION_CONFIRMADO = (string)row[dataColumn];
			// Column "GIO_DEVOLUCION_PERSONA_ID"
			dataColumn = dataTable.Columns["GIO_DEVOLUCION_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_DEVOLUCION_PERSONA_ID = (decimal)row[dataColumn];
			// Column "GIO_DEVOLUCION_PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["GIO_DEVOLUCION_PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_DEVOLUCION_PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "GIO_DEVOLUCION_BOOKING"
			dataColumn = dataTable.Columns["GIO_DEVOLUCION_BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIO_DEVOLUCION_BOOKING = (string)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR"
			dataColumn = dataTable.Columns["USUARIO_CREADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR = (string)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION = (string)row[dataColumn];
			// Column "RECHAZADO"
			dataColumn = dataTable.Columns["RECHAZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECHAZADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CONTENEDORES_OPERACIONES_ID"
			dataColumn = dataTable.Columns["CONTENEDORES_OPERACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDORES_OPERACIONES_ID = (decimal)row[dataColumn];
			// Column "CONSOLIDACION_FECHA"
			dataColumn = dataTable.Columns["CONSOLIDACION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_FECHA = (System.DateTime)row[dataColumn];
			// Column "CONSOLIDACION_NRO"
			dataColumn = dataTable.Columns["CONSOLIDACION_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_NRO = (string)row[dataColumn];
			// Column "CONSOLIDACION_PROCESADO"
			dataColumn = dataTable.Columns["CONSOLIDACION_PROCESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_PROCESADO = (string)row[dataColumn];
			// Column "CONSOLIDACION_CLIENTE"
			dataColumn = dataTable.Columns["CONSOLIDACION_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_CLIENTE = (string)row[dataColumn];
			// Column "PRE_EMBARQUE_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "ESTA_EN_PRE_EMBARQUE"
			dataColumn = dataTable.Columns["ESTA_EN_PRE_EMBARQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTA_EN_PRE_EMBARQUE = (string)row[dataColumn];
			// Column "INTERCAMBIO_EQUIPO_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPO_ID = (decimal)row[dataColumn];
			// Column "INTERCAMBIO_BUQUE"
			dataColumn = dataTable.Columns["INTERCAMBIO_BUQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_BUQUE = (string)row[dataColumn];
			// Column "INERCAMBIO_NUMERO"
			dataColumn = dataTable.Columns["INERCAMBIO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INERCAMBIO_NUMERO = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_NOMBRE = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ABREVIATURA"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ABREVIATURA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOMINA_CONTENED_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOMINA_CONTENED_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMINA_CONTENEDORES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TIPO", typeof(string));
			dataColumn.MaxLength = 56;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_CLASE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTA_MOVIMIENTO_ENTREGA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_ENTREGA_NUMERO", typeof(string));
			dataColumn.MaxLength = 51;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ENTREGA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_ENTREGA_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_ENTREGA_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_ENTREGA_PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTA_MOVIMIENTO_DEVOLUC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_DEVOLUCION_NUMERO", typeof(string));
			dataColumn.MaxLength = 51;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DEVOLUCION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_DEVOLUCION_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_DEVOLUCION_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_DEVOLUCION_PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIO_DEVOLUCION_BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECHAZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDORES_OPERACIONES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_NRO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_PROCESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_CLIENTE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTA_EN_PRE_EMBARQUE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_BUQUE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INERCAMBIO_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "NOMINA_CONTENEDORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_LINEA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTA_MOVIMIENTO_ENTREGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIO_ENTREGA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "GIO_ENTREGA_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GIO_ENTREGA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIO_ENTREGA_PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTA_MOVIMIENTO_DEVOLUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIO_DEVOLUCION_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_DEVOLUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "GIO_DEVOLUCION_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GIO_DEVOLUCION_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIO_DEVOLUCION_PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GIO_DEVOLUCION_BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECHAZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDORES_OPERACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSOLIDACION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONSOLIDACION_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSOLIDACION_PROCESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONSOLIDACION_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRE_EMBARQUE_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTA_EN_PRE_EMBARQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERCAMBIO_EQUIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERCAMBIO_BUQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INERCAMBIO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_DEVOLUCION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_DEVOLUCION_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOMINA_CONTENED_DET_INFO_COMPLCollection_Base class
}  // End of namespace
