// <fileinfo name="CONTENEDORES_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string MOVIMIENTO_IDColumnName = "MOVIMIENTO_ID";
		public const string ESTADO_FINALColumnName = "ESTADO_FINAL";
		public const string EN_PREDIOColumnName = "EN_PREDIO";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string BUQUEColumnName = "BUQUE";
		public const string BLColumnName = "BL";
		public const string BOOKINGColumnName = "BOOKING";
		public const string CLIENTEColumnName = "CLIENTE";
		public const string NRO_VIAJEColumnName = "NRO_VIAJE";
		public const string PUERTOColumnName = "PUERTO";
		public const string PESOColumnName = "PESO";
		public const string TARAColumnName = "TARA";
		public const string SETPOINTColumnName = "SETPOINT";
		public const string PAYLOADColumnName = "PAYLOAD";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CLASEColumnName = "CLASE";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string DANADOColumnName = "DANADO";
		public const string BLOQUEADOColumnName = "BLOQUEADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_MOVIMIENTOSCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CONTENEDORES_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		public CONTENEDORES_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CONTENEDORES_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTENEDORES_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTENEDORES_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTENEDORES_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CONT_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CONTENEDORES_MOVIMIENTOSRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDOR_IDCommand(contenedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONT_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDOR_IDCommand(decimal contenedor_id)
		{
			string whereSql = "";
			whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CONT_MOV_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CONTENEDORES_MOVIMIENTOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_MOV_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONT_MOV_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CONTENEDORES_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTENEDORES_MOVIMIENTOS (" +
				"ID, " +
				"FECHA_MOVIMIENTO, " +
				"FECHA_INSERCION, " +
				"TIPO_MOVIMIENTO, " +
				"MOVIMIENTO_ID, " +
				"ESTADO_FINAL, " +
				"EN_PREDIO, " +
				"ESTADO, " +
				"USUARIO_ID, " +
				"CONTENEDOR_ID, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"PRECINTO_VENTILETE, " +
				"BUQUE, " +
				"BL, " +
				"BOOKING, " +
				"CLIENTE, " +
				"NRO_VIAJE, " +
				"PUERTO, " +
				"PESO, " +
				"TARA, " +
				"SETPOINT, " +
				"PAYLOAD, " +
				"EIR_PISO, " +
				"EIR_FONDO, " +
				"EIR_TECHO, " +
				"EIR_PANEL_DERECHO, " +
				"EIR_PANEL_IZQUIERDO, " +
				"EIR_PUERTA, " +
				"EIR_REFRIGERADO, " +
				"OBSERVACIONES, " +
				"CLASE, " +
				"MERCADERIAS, " +
				"DANADO, " +
				"BLOQUEADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				_db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_FINAL") + ", " +
				_db.CreateSqlParameterName("EN_PREDIO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("BUQUE") + ", " +
				_db.CreateSqlParameterName("BL") + ", " +
				_db.CreateSqlParameterName("BOOKING") + ", " +
				_db.CreateSqlParameterName("CLIENTE") + ", " +
				_db.CreateSqlParameterName("NRO_VIAJE") + ", " +
				_db.CreateSqlParameterName("PUERTO") + ", " +
				_db.CreateSqlParameterName("PESO") + ", " +
				_db.CreateSqlParameterName("TARA") + ", " +
				_db.CreateSqlParameterName("SETPOINT") + ", " +
				_db.CreateSqlParameterName("PAYLOAD") + ", " +
				_db.CreateSqlParameterName("EIR_PISO") + ", " +
				_db.CreateSqlParameterName("EIR_FONDO") + ", " +
				_db.CreateSqlParameterName("EIR_TECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				_db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				_db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("CLASE") + ", " +
				_db.CreateSqlParameterName("MERCADERIAS") + ", " +
				_db.CreateSqlParameterName("DANADO") + ", " +
				_db.CreateSqlParameterName("BLOQUEADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_MOVIMIENTO", value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "MOVIMIENTO_ID",
				value.IsMOVIMIENTO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_ID);
			AddParameter(cmd, "ESTADO_FINAL", value.ESTADO_FINAL);
			AddParameter(cmd, "EN_PREDIO", value.EN_PREDIO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "CONTENEDOR_ID", value.CONTENEDOR_ID);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "BUQUE", value.BUQUE);
			AddParameter(cmd, "BL", value.BL);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CLIENTE", value.CLIENTE);
			AddParameter(cmd, "NRO_VIAJE", value.NRO_VIAJE);
			AddParameter(cmd, "PUERTO", value.PUERTO);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			AddParameter(cmd, "TARA",
				value.IsTARANull ? DBNull.Value : (object)value.TARA);
			AddParameter(cmd, "SETPOINT",
				value.IsSETPOINTNull ? DBNull.Value : (object)value.SETPOINT);
			AddParameter(cmd, "PAYLOAD",
				value.IsPAYLOADNull ? DBNull.Value : (object)value.PAYLOAD);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CLASE", value.CLASE);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTENEDORES_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTENEDORES_MOVIMIENTOS SET " +
				"FECHA_MOVIMIENTO=" + _db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				"FECHA_INSERCION=" + _db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				"TIPO_MOVIMIENTO=" + _db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				"MOVIMIENTO_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_ID") + ", " +
				"ESTADO_FINAL=" + _db.CreateSqlParameterName("ESTADO_FINAL") + ", " +
				"EN_PREDIO=" + _db.CreateSqlParameterName("EN_PREDIO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"BUQUE=" + _db.CreateSqlParameterName("BUQUE") + ", " +
				"BL=" + _db.CreateSqlParameterName("BL") + ", " +
				"BOOKING=" + _db.CreateSqlParameterName("BOOKING") + ", " +
				"CLIENTE=" + _db.CreateSqlParameterName("CLIENTE") + ", " +
				"NRO_VIAJE=" + _db.CreateSqlParameterName("NRO_VIAJE") + ", " +
				"PUERTO=" + _db.CreateSqlParameterName("PUERTO") + ", " +
				"PESO=" + _db.CreateSqlParameterName("PESO") + ", " +
				"TARA=" + _db.CreateSqlParameterName("TARA") + ", " +
				"SETPOINT=" + _db.CreateSqlParameterName("SETPOINT") + ", " +
				"PAYLOAD=" + _db.CreateSqlParameterName("PAYLOAD") + ", " +
				"EIR_PISO=" + _db.CreateSqlParameterName("EIR_PISO") + ", " +
				"EIR_FONDO=" + _db.CreateSqlParameterName("EIR_FONDO") + ", " +
				"EIR_TECHO=" + _db.CreateSqlParameterName("EIR_TECHO") + ", " +
				"EIR_PANEL_DERECHO=" + _db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				"EIR_PANEL_IZQUIERDO=" + _db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				"EIR_PUERTA=" + _db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				"EIR_REFRIGERADO=" + _db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"CLASE=" + _db.CreateSqlParameterName("CLASE") + ", " +
				"MERCADERIAS=" + _db.CreateSqlParameterName("MERCADERIAS") + ", " +
				"DANADO=" + _db.CreateSqlParameterName("DANADO") + ", " +
				"BLOQUEADO=" + _db.CreateSqlParameterName("BLOQUEADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_MOVIMIENTO", value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "MOVIMIENTO_ID",
				value.IsMOVIMIENTO_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_ID);
			AddParameter(cmd, "ESTADO_FINAL", value.ESTADO_FINAL);
			AddParameter(cmd, "EN_PREDIO", value.EN_PREDIO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "CONTENEDOR_ID", value.CONTENEDOR_ID);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "BUQUE", value.BUQUE);
			AddParameter(cmd, "BL", value.BL);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CLIENTE", value.CLIENTE);
			AddParameter(cmd, "NRO_VIAJE", value.NRO_VIAJE);
			AddParameter(cmd, "PUERTO", value.PUERTO);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			AddParameter(cmd, "TARA",
				value.IsTARANull ? DBNull.Value : (object)value.TARA);
			AddParameter(cmd, "SETPOINT",
				value.IsSETPOINTNull ? DBNull.Value : (object)value.SETPOINT);
			AddParameter(cmd, "PAYLOAD",
				value.IsPAYLOADNull ? DBNull.Value : (object)value.PAYLOAD);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CLASE", value.CLASE);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((decimal)row["ID"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTENEDORES_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTENEDORES_MOVIMIENTOS</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ID", id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CONT_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return CreateDeleteByCONTENEDOR_IDCommand(contenedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONT_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDOR_IDCommand(decimal contenedor_id)
		{
			string whereSql = "";
			whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CONT_MOV_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONT_MOV_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTENEDORES_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>CONTENEDORES_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTENEDORES_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		protected CONTENEDORES_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		protected CONTENEDORES_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual CONTENEDORES_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int movimiento_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_ID");
			int estado_finalColumnIndex = reader.GetOrdinal("ESTADO_FINAL");
			int en_predioColumnIndex = reader.GetOrdinal("EN_PREDIO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int buqueColumnIndex = reader.GetOrdinal("BUQUE");
			int blColumnIndex = reader.GetOrdinal("BL");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int clienteColumnIndex = reader.GetOrdinal("CLIENTE");
			int nro_viajeColumnIndex = reader.GetOrdinal("NRO_VIAJE");
			int puertoColumnIndex = reader.GetOrdinal("PUERTO");
			int pesoColumnIndex = reader.GetOrdinal("PESO");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int setpointColumnIndex = reader.GetOrdinal("SETPOINT");
			int payloadColumnIndex = reader.GetOrdinal("PAYLOAD");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int claseColumnIndex = reader.GetOrdinal("CLASE");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_MOVIMIENTOSRow record = new CONTENEDORES_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(movimiento_idColumnIndex))
						record.MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_idColumnIndex)), 9);
					record.ESTADO_FINAL = Convert.ToString(reader.GetValue(estado_finalColumnIndex));
					record.EN_PREDIO = Convert.ToString(reader.GetValue(en_predioColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(precinto_1ColumnIndex))
						record.PRECINTO_1 = Convert.ToString(reader.GetValue(precinto_1ColumnIndex));
					if(!reader.IsDBNull(precinto_2ColumnIndex))
						record.PRECINTO_2 = Convert.ToString(reader.GetValue(precinto_2ColumnIndex));
					if(!reader.IsDBNull(precinto_3ColumnIndex))
						record.PRECINTO_3 = Convert.ToString(reader.GetValue(precinto_3ColumnIndex));
					if(!reader.IsDBNull(precinto_4ColumnIndex))
						record.PRECINTO_4 = Convert.ToString(reader.GetValue(precinto_4ColumnIndex));
					if(!reader.IsDBNull(precinto_5ColumnIndex))
						record.PRECINTO_5 = Convert.ToString(reader.GetValue(precinto_5ColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(buqueColumnIndex))
						record.BUQUE = Convert.ToString(reader.GetValue(buqueColumnIndex));
					if(!reader.IsDBNull(blColumnIndex))
						record.BL = Convert.ToString(reader.GetValue(blColumnIndex));
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(clienteColumnIndex))
						record.CLIENTE = Convert.ToString(reader.GetValue(clienteColumnIndex));
					if(!reader.IsDBNull(nro_viajeColumnIndex))
						record.NRO_VIAJE = Convert.ToString(reader.GetValue(nro_viajeColumnIndex));
					if(!reader.IsDBNull(puertoColumnIndex))
						record.PUERTO = Convert.ToString(reader.GetValue(puertoColumnIndex));
					if(!reader.IsDBNull(pesoColumnIndex))
						record.PESO = Math.Round(Convert.ToDecimal(reader.GetValue(pesoColumnIndex)), 9);
					if(!reader.IsDBNull(taraColumnIndex))
						record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					if(!reader.IsDBNull(setpointColumnIndex))
						record.SETPOINT = Math.Round(Convert.ToDecimal(reader.GetValue(setpointColumnIndex)), 9);
					if(!reader.IsDBNull(payloadColumnIndex))
						record.PAYLOAD = Math.Round(Convert.ToDecimal(reader.GetValue(payloadColumnIndex)), 9);
					if(!reader.IsDBNull(eir_pisoColumnIndex))
						record.EIR_PISO = Convert.ToString(reader.GetValue(eir_pisoColumnIndex));
					if(!reader.IsDBNull(eir_fondoColumnIndex))
						record.EIR_FONDO = Convert.ToString(reader.GetValue(eir_fondoColumnIndex));
					if(!reader.IsDBNull(eir_techoColumnIndex))
						record.EIR_TECHO = Convert.ToString(reader.GetValue(eir_techoColumnIndex));
					if(!reader.IsDBNull(eir_panel_derechoColumnIndex))
						record.EIR_PANEL_DERECHO = Convert.ToString(reader.GetValue(eir_panel_derechoColumnIndex));
					if(!reader.IsDBNull(eir_panel_izquierdoColumnIndex))
						record.EIR_PANEL_IZQUIERDO = Convert.ToString(reader.GetValue(eir_panel_izquierdoColumnIndex));
					if(!reader.IsDBNull(eir_puertaColumnIndex))
						record.EIR_PUERTA = Convert.ToString(reader.GetValue(eir_puertaColumnIndex));
					if(!reader.IsDBNull(eir_refrigeradoColumnIndex))
						record.EIR_REFRIGERADO = Convert.ToString(reader.GetValue(eir_refrigeradoColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(claseColumnIndex))
						record.CLASE = Convert.ToString(reader.GetValue(claseColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(bloqueadoColumnIndex))
						record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_MOVIMIENTOSRow[])(recordList.ToArray(typeof(CONTENEDORES_MOVIMIENTOSRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_MOVIMIENTOSRow"/> object.</returns>
		protected virtual CONTENEDORES_MOVIMIENTOSRow MapRow(DataRow row)
		{
			CONTENEDORES_MOVIMIENTOSRow mappedObject = new CONTENEDORES_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_FINAL"
			dataColumn = dataTable.Columns["ESTADO_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_FINAL = (string)row[dataColumn];
			// Column "EN_PREDIO"
			dataColumn = dataTable.Columns["EN_PREDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_PREDIO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "PRECINTO_1"
			dataColumn = dataTable.Columns["PRECINTO_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1 = (string)row[dataColumn];
			// Column "PRECINTO_2"
			dataColumn = dataTable.Columns["PRECINTO_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2 = (string)row[dataColumn];
			// Column "PRECINTO_3"
			dataColumn = dataTable.Columns["PRECINTO_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3 = (string)row[dataColumn];
			// Column "PRECINTO_4"
			dataColumn = dataTable.Columns["PRECINTO_4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4 = (string)row[dataColumn];
			// Column "PRECINTO_5"
			dataColumn = dataTable.Columns["PRECINTO_5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5 = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "BUQUE"
			dataColumn = dataTable.Columns["BUQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE = (string)row[dataColumn];
			// Column "BL"
			dataColumn = dataTable.Columns["BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BL = (string)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "CLIENTE"
			dataColumn = dataTable.Columns["CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE = (string)row[dataColumn];
			// Column "NRO_VIAJE"
			dataColumn = dataTable.Columns["NRO_VIAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE = (string)row[dataColumn];
			// Column "PUERTO"
			dataColumn = dataTable.Columns["PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO = (string)row[dataColumn];
			// Column "PESO"
			dataColumn = dataTable.Columns["PESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO = (decimal)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "SETPOINT"
			dataColumn = dataTable.Columns["SETPOINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SETPOINT = (decimal)row[dataColumn];
			// Column "PAYLOAD"
			dataColumn = dataTable.Columns["PAYLOAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAYLOAD = (decimal)row[dataColumn];
			// Column "EIR_PISO"
			dataColumn = dataTable.Columns["EIR_PISO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PISO = (string)row[dataColumn];
			// Column "EIR_FONDO"
			dataColumn = dataTable.Columns["EIR_FONDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_FONDO = (string)row[dataColumn];
			// Column "EIR_TECHO"
			dataColumn = dataTable.Columns["EIR_TECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_TECHO = (string)row[dataColumn];
			// Column "EIR_PANEL_DERECHO"
			dataColumn = dataTable.Columns["EIR_PANEL_DERECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PANEL_DERECHO = (string)row[dataColumn];
			// Column "EIR_PANEL_IZQUIERDO"
			dataColumn = dataTable.Columns["EIR_PANEL_IZQUIERDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PANEL_IZQUIERDO = (string)row[dataColumn];
			// Column "EIR_PUERTA"
			dataColumn = dataTable.Columns["EIR_PUERTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PUERTA = (string)row[dataColumn];
			// Column "EIR_REFRIGERADO"
			dataColumn = dataTable.Columns["EIR_REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_REFRIGERADO = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CLASE"
			dataColumn = dataTable.Columns["CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASE = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_FINAL", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EN_PREDIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("BUQUE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CLIENTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NRO_VIAJE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PUERTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SETPOINT", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAYLOAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EIR_PISO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("EIR_FONDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("EIR_TECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("EIR_PANEL_DERECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("EIR_PANEL_IZQUIERDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("EIR_PUERTA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("CLASE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 12;
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

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EN_PREDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECINTO_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_VIAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SETPOINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAYLOAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EIR_PISO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_FONDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_TECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PANEL_DERECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PANEL_IZQUIERDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PUERTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_MOVIMIENTOSCollection_Base class
}  // End of namespace
