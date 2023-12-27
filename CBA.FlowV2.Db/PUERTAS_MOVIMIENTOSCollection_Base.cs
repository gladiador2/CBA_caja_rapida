// <fileinfo name="PUERTAS_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="PUERTAS_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PUERTAS_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PUERTAS_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string BASCULA_IDColumnName = "BASCULA_ID";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_TRACTOColumnName = "CHAPA_TRACTO";
		public const string NUMERO_COMPROBANTEColumnName = "NUMERO_COMPROBANTE";
		public const string IMPORTACION_TERRESTREColumnName = "IMPORTACION_TERRESTRE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string ESTADO_CONTENEDORColumnName = "ESTADO_CONTENEDOR";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string FECHAColumnName = "FECHA";
		public const string MOVIMIENTOColumnName = "MOVIMIENTO";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string NOTA_REMISIONColumnName = "NOTA_REMISION";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string INTERCAMBIO_EQUIPOS_IDColumnName = "INTERCAMBIO_EQUIPOS_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_CONFIRMACION_IDColumnName = "USUARIO_CONFIRMACION_ID";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string BOOKING_BLColumnName = "BOOKING_BL";
		public const string NRO_AUTORIZACIONColumnName = "NRO_AUTORIZACION";
		public const string EQUIPO_AUTORIZADO_DET_IDColumnName = "EQUIPO_AUTORIZADO_DET_ID";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string CODIGO_AUTORIZACIONColumnName = "CODIGO_AUTORIZACION";
		public const string SET_POINTColumnName = "SET_POINT";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string CONTENDOR_CLASEColumnName = "CONTENDOR_CLASE";
		public const string CLIENTE_EXTERNOColumnName = "CLIENTE_EXTERNO";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string DANADOColumnName = "DANADO";
		public const string DANO_INFORMADOColumnName = "DANO_INFORMADO";
		public const string RECHAZADOColumnName = "RECHAZADO";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string TEMPERATURAColumnName = "TEMPERATURA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PUERTAS_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PUERTAS_MOVIMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PUERTAS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PUERTAS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PUERTAS_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PUERTAS_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PUERTAS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PUERTAS_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PUERTAS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PUERTAS_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByBASCULA_ID(decimal bascula_id)
		{
			return GetByBASCULA_ID(bascula_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <param name="bascula_idNull">true if the method ignores the bascula_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByBASCULA_ID(decimal bascula_id, bool bascula_idNull)
		{
			return MapRecords(CreateGetByBASCULA_IDCommand(bascula_id, bascula_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBASCULA_IDAsDataTable(decimal bascula_id)
		{
			return GetByBASCULA_IDAsDataTable(bascula_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <param name="bascula_idNull">true if the method ignores the bascula_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBASCULA_IDAsDataTable(decimal bascula_id, bool bascula_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBASCULA_IDCommand(bascula_id, bascula_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <param name="bascula_idNull">true if the method ignores the bascula_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBASCULA_IDCommand(decimal bascula_id, bool bascula_idNull)
		{
			string whereSql = "";
			if(bascula_idNull)
				whereSql += "BASCULA_ID IS NULL";
			else
				whereSql += "BASCULA_ID=" + _db.CreateSqlParameterName("BASCULA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!bascula_idNull)
				AddParameter(cmd, "BASCULA_ID", bascula_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByEQUIPO_AUTORIZADO_DET_ID(decimal equipo_autorizado_det_id)
		{
			return GetByEQUIPO_AUTORIZADO_DET_ID(equipo_autorizado_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <param name="equipo_autorizado_det_idNull">true if the method ignores the equipo_autorizado_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByEQUIPO_AUTORIZADO_DET_ID(decimal equipo_autorizado_det_id, bool equipo_autorizado_det_idNull)
		{
			return MapRecords(CreateGetByEQUIPO_AUTORIZADO_DET_IDCommand(equipo_autorizado_det_id, equipo_autorizado_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEQUIPO_AUTORIZADO_DET_IDAsDataTable(decimal equipo_autorizado_det_id)
		{
			return GetByEQUIPO_AUTORIZADO_DET_IDAsDataTable(equipo_autorizado_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <param name="equipo_autorizado_det_idNull">true if the method ignores the equipo_autorizado_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEQUIPO_AUTORIZADO_DET_IDAsDataTable(decimal equipo_autorizado_det_id, bool equipo_autorizado_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEQUIPO_AUTORIZADO_DET_IDCommand(equipo_autorizado_det_id, equipo_autorizado_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <param name="equipo_autorizado_det_idNull">true if the method ignores the equipo_autorizado_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEQUIPO_AUTORIZADO_DET_IDCommand(decimal equipo_autorizado_det_id, bool equipo_autorizado_det_idNull)
		{
			string whereSql = "";
			if(equipo_autorizado_det_idNull)
				whereSql += "EQUIPO_AUTORIZADO_DET_ID IS NULL";
			else
				whereSql += "EQUIPO_AUTORIZADO_DET_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!equipo_autorizado_det_idNull)
				AddParameter(cmd, "EQUIPO_AUTORIZADO_DET_ID", equipo_autorizado_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByINTERCAMBIO_EQUIPOS_ID(decimal intercambio_equipos_id)
		{
			return GetByINTERCAMBIO_EQUIPOS_ID(intercambio_equipos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <param name="intercambio_equipos_idNull">true if the method ignores the intercambio_equipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByINTERCAMBIO_EQUIPOS_ID(decimal intercambio_equipos_id, bool intercambio_equipos_idNull)
		{
			return MapRecords(CreateGetByINTERCAMBIO_EQUIPOS_IDCommand(intercambio_equipos_id, intercambio_equipos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINTERCAMBIO_EQUIPOS_IDAsDataTable(decimal intercambio_equipos_id)
		{
			return GetByINTERCAMBIO_EQUIPOS_IDAsDataTable(intercambio_equipos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <param name="intercambio_equipos_idNull">true if the method ignores the intercambio_equipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINTERCAMBIO_EQUIPOS_IDAsDataTable(decimal intercambio_equipos_id, bool intercambio_equipos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINTERCAMBIO_EQUIPOS_IDCommand(intercambio_equipos_id, intercambio_equipos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <param name="intercambio_equipos_idNull">true if the method ignores the intercambio_equipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINTERCAMBIO_EQUIPOS_IDCommand(decimal intercambio_equipos_id, bool intercambio_equipos_idNull)
		{
			string whereSql = "";
			if(intercambio_equipos_idNull)
				whereSql += "INTERCAMBIO_EQUIPOS_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPOS_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!intercambio_equipos_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPOS_ID", intercambio_equipos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByPUERTO_ID(decimal puerto_id)
		{
			return GetByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecords(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id)
		{
			return GetByPUERTO_IDAsDataTable(puerto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTO_IDCommand(decimal puerto_id, bool puerto_idNull)
		{
			string whereSql = "";
			if(puerto_idNull)
				whereSql += "PUERTO_ID IS NULL";
			else
				whereSql += "PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerto_idNull)
				AddParameter(cmd, "PUERTO_ID", puerto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByUSUARIO_CONFIRMACION_ID(decimal usuario_confirmacion_id)
		{
			return GetByUSUARIO_CONFIRMACION_ID(usuario_confirmacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <param name="usuario_confirmacion_idNull">true if the method ignores the usuario_confirmacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByUSUARIO_CONFIRMACION_ID(decimal usuario_confirmacion_id, bool usuario_confirmacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CONFIRMACION_IDCommand(usuario_confirmacion_id, usuario_confirmacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CONFIRMACION_IDAsDataTable(decimal usuario_confirmacion_id)
		{
			return GetByUSUARIO_CONFIRMACION_IDAsDataTable(usuario_confirmacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <param name="usuario_confirmacion_idNull">true if the method ignores the usuario_confirmacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CONFIRMACION_IDAsDataTable(decimal usuario_confirmacion_id, bool usuario_confirmacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CONFIRMACION_IDCommand(usuario_confirmacion_id, usuario_confirmacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <param name="usuario_confirmacion_idNull">true if the method ignores the usuario_confirmacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CONFIRMACION_IDCommand(decimal usuario_confirmacion_id, bool usuario_confirmacion_idNull)
		{
			string whereSql = "";
			if(usuario_confirmacion_idNull)
				whereSql += "USUARIO_CONFIRMACION_ID IS NULL";
			else
				whereSql += "USUARIO_CONFIRMACION_ID=" + _db.CreateSqlParameterName("USUARIO_CONFIRMACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_confirmacion_idNull)
				AddParameter(cmd, "USUARIO_CONFIRMACION_ID", usuario_confirmacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOSRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOSRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_IDAsDataTable(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PUERTAS_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(PUERTAS_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PUERTAS_MOVIMIENTOS (" +
				"ID, " +
				"BASCULA_ID, " +
				"TIPO_MOVIMIENTO, " +
				"CHAPA_CAMION, " +
				"CHAPA_TRACTO, " +
				"NUMERO_COMPROBANTE, " +
				"IMPORTACION_TERRESTRE, " +
				"OBSERVACIONES, " +
				"CONTENEDOR_ID, " +
				"ESTADO_CONTENEDOR, " +
				"TARA_CAMION, " +
				"CHOFER_DOCUMENTO, " +
				"CHOFER_NOMBRE, " +
				"FECHA, " +
				"MOVIMIENTO, " +
				"PESO_BRUTO, " +
				"NOTA_REMISION, " +
				"CONFIRMADO, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"PRECINTO_VENTILETE, " +
				"INTERCAMBIO_EQUIPOS_ID, " +
				"USUARIO_CREADOR_ID, " +
				"USUARIO_CONFIRMACION_ID, " +
				"FECHA_CONFIRMACION, " +
				"EIR_PISO, " +
				"EIR_FONDO, " +
				"EIR_TECHO, " +
				"EIR_PANEL_DERECHO, " +
				"EIR_PANEL_IZQUIERDO, " +
				"EIR_PUERTA, " +
				"TARA_CONTENEDOR, " +
				"PESO_NETO, " +
				"BOOKING_BL, " +
				"NRO_AUTORIZACION, " +
				"EQUIPO_AUTORIZADO_DET_ID, " +
				"EIR_REFRIGERADO, " +
				"CODIGO_AUTORIZACION, " +
				"SET_POINT, " +
				"PERSONA_ID, " +
				"PUERTO_ID, " +
				"CONTENDOR_CLASE, " +
				"CLIENTE_EXTERNO, " +
				"MERCADERIAS, " +
				"DANADO, " +
				"DANO_INFORMADO, " +
				"RECHAZADO, " +
				"CONOCIMIENTO, " +
				"TEMPERATURA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("BASCULA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHAPA_TRACTO") + ", " +
				_db.CreateSqlParameterName("NUMERO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("IMPORTACION_TERRESTRE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("TARA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("NOTA_REMISION") + ", " +
				_db.CreateSqlParameterName("CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("INTERCAMBIO_EQUIPOS_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CONFIRMACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				_db.CreateSqlParameterName("EIR_PISO") + ", " +
				_db.CreateSqlParameterName("EIR_FONDO") + ", " +
				_db.CreateSqlParameterName("EIR_TECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				_db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				_db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PESO_NETO") + ", " +
				_db.CreateSqlParameterName("BOOKING_BL") + ", " +
				_db.CreateSqlParameterName("NRO_AUTORIZACION") + ", " +
				_db.CreateSqlParameterName("EQUIPO_AUTORIZADO_DET_ID") + ", " +
				_db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				_db.CreateSqlParameterName("CODIGO_AUTORIZACION") + ", " +
				_db.CreateSqlParameterName("SET_POINT") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PUERTO_ID") + ", " +
				_db.CreateSqlParameterName("CONTENDOR_CLASE") + ", " +
				_db.CreateSqlParameterName("CLIENTE_EXTERNO") + ", " +
				_db.CreateSqlParameterName("MERCADERIAS") + ", " +
				_db.CreateSqlParameterName("DANADO") + ", " +
				_db.CreateSqlParameterName("DANO_INFORMADO") + ", " +
				_db.CreateSqlParameterName("RECHAZADO") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO") + ", " +
				_db.CreateSqlParameterName("TEMPERATURA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "BASCULA_ID",
				value.IsBASCULA_IDNull ? DBNull.Value : (object)value.BASCULA_ID);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_TRACTO", value.CHAPA_TRACTO);
			AddParameter(cmd, "NUMERO_COMPROBANTE", value.NUMERO_COMPROBANTE);
			AddParameter(cmd, "IMPORTACION_TERRESTRE", value.IMPORTACION_TERRESTRE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "MOVIMIENTO", value.MOVIMIENTO);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "NOTA_REMISION", value.NOTA_REMISION);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "INTERCAMBIO_EQUIPOS_ID",
				value.IsINTERCAMBIO_EQUIPOS_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPOS_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_CONFIRMACION_ID",
				value.IsUSUARIO_CONFIRMACION_IDNull ? DBNull.Value : (object)value.USUARIO_CONFIRMACION_ID);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "BOOKING_BL", value.BOOKING_BL);
			AddParameter(cmd, "NRO_AUTORIZACION", value.NRO_AUTORIZACION);
			AddParameter(cmd, "EQUIPO_AUTORIZADO_DET_ID",
				value.IsEQUIPO_AUTORIZADO_DET_IDNull ? DBNull.Value : (object)value.EQUIPO_AUTORIZADO_DET_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "CODIGO_AUTORIZACION", value.CODIGO_AUTORIZACION);
			AddParameter(cmd, "SET_POINT",
				value.IsSET_POINTNull ? DBNull.Value : (object)value.SET_POINT);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "CONTENDOR_CLASE", value.CONTENDOR_CLASE);
			AddParameter(cmd, "CLIENTE_EXTERNO", value.CLIENTE_EXTERNO);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			AddParameter(cmd, "RECHAZADO", value.RECHAZADO);
			AddParameter(cmd, "CONOCIMIENTO", value.CONOCIMIENTO);
			AddParameter(cmd, "TEMPERATURA",
				value.IsTEMPERATURANull ? DBNull.Value : (object)value.TEMPERATURA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PUERTAS_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PUERTAS_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.PUERTAS_MOVIMIENTOS SET " +
				"BASCULA_ID=" + _db.CreateSqlParameterName("BASCULA_ID") + ", " +
				"TIPO_MOVIMIENTO=" + _db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHAPA_TRACTO=" + _db.CreateSqlParameterName("CHAPA_TRACTO") + ", " +
				"NUMERO_COMPROBANTE=" + _db.CreateSqlParameterName("NUMERO_COMPROBANTE") + ", " +
				"IMPORTACION_TERRESTRE=" + _db.CreateSqlParameterName("IMPORTACION_TERRESTRE") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"ESTADO_CONTENEDOR=" + _db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				"TARA_CAMION=" + _db.CreateSqlParameterName("TARA_CAMION") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MOVIMIENTO=" + _db.CreateSqlParameterName("MOVIMIENTO") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"NOTA_REMISION=" + _db.CreateSqlParameterName("NOTA_REMISION") + ", " +
				"CONFIRMADO=" + _db.CreateSqlParameterName("CONFIRMADO") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"INTERCAMBIO_EQUIPOS_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPOS_ID") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"USUARIO_CONFIRMACION_ID=" + _db.CreateSqlParameterName("USUARIO_CONFIRMACION_ID") + ", " +
				"FECHA_CONFIRMACION=" + _db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				"EIR_PISO=" + _db.CreateSqlParameterName("EIR_PISO") + ", " +
				"EIR_FONDO=" + _db.CreateSqlParameterName("EIR_FONDO") + ", " +
				"EIR_TECHO=" + _db.CreateSqlParameterName("EIR_TECHO") + ", " +
				"EIR_PANEL_DERECHO=" + _db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				"EIR_PANEL_IZQUIERDO=" + _db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				"EIR_PUERTA=" + _db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				"TARA_CONTENEDOR=" + _db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				"PESO_NETO=" + _db.CreateSqlParameterName("PESO_NETO") + ", " +
				"BOOKING_BL=" + _db.CreateSqlParameterName("BOOKING_BL") + ", " +
				"NRO_AUTORIZACION=" + _db.CreateSqlParameterName("NRO_AUTORIZACION") + ", " +
				"EQUIPO_AUTORIZADO_DET_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_DET_ID") + ", " +
				"EIR_REFRIGERADO=" + _db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				"CODIGO_AUTORIZACION=" + _db.CreateSqlParameterName("CODIGO_AUTORIZACION") + ", " +
				"SET_POINT=" + _db.CreateSqlParameterName("SET_POINT") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID") + ", " +
				"CONTENDOR_CLASE=" + _db.CreateSqlParameterName("CONTENDOR_CLASE") + ", " +
				"CLIENTE_EXTERNO=" + _db.CreateSqlParameterName("CLIENTE_EXTERNO") + ", " +
				"MERCADERIAS=" + _db.CreateSqlParameterName("MERCADERIAS") + ", " +
				"DANADO=" + _db.CreateSqlParameterName("DANADO") + ", " +
				"DANO_INFORMADO=" + _db.CreateSqlParameterName("DANO_INFORMADO") + ", " +
				"RECHAZADO=" + _db.CreateSqlParameterName("RECHAZADO") + ", " +
				"CONOCIMIENTO=" + _db.CreateSqlParameterName("CONOCIMIENTO") + ", " +
				"TEMPERATURA=" + _db.CreateSqlParameterName("TEMPERATURA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "BASCULA_ID",
				value.IsBASCULA_IDNull ? DBNull.Value : (object)value.BASCULA_ID);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_TRACTO", value.CHAPA_TRACTO);
			AddParameter(cmd, "NUMERO_COMPROBANTE", value.NUMERO_COMPROBANTE);
			AddParameter(cmd, "IMPORTACION_TERRESTRE", value.IMPORTACION_TERRESTRE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "MOVIMIENTO", value.MOVIMIENTO);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "NOTA_REMISION", value.NOTA_REMISION);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "INTERCAMBIO_EQUIPOS_ID",
				value.IsINTERCAMBIO_EQUIPOS_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPOS_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_CONFIRMACION_ID",
				value.IsUSUARIO_CONFIRMACION_IDNull ? DBNull.Value : (object)value.USUARIO_CONFIRMACION_ID);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "BOOKING_BL", value.BOOKING_BL);
			AddParameter(cmd, "NRO_AUTORIZACION", value.NRO_AUTORIZACION);
			AddParameter(cmd, "EQUIPO_AUTORIZADO_DET_ID",
				value.IsEQUIPO_AUTORIZADO_DET_IDNull ? DBNull.Value : (object)value.EQUIPO_AUTORIZADO_DET_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "CODIGO_AUTORIZACION", value.CODIGO_AUTORIZACION);
			AddParameter(cmd, "SET_POINT",
				value.IsSET_POINTNull ? DBNull.Value : (object)value.SET_POINT);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "CONTENDOR_CLASE", value.CONTENDOR_CLASE);
			AddParameter(cmd, "CLIENTE_EXTERNO", value.CLIENTE_EXTERNO);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			AddParameter(cmd, "RECHAZADO", value.RECHAZADO);
			AddParameter(cmd, "CONOCIMIENTO", value.CONOCIMIENTO);
			AddParameter(cmd, "TEMPERATURA",
				value.IsTEMPERATURANull ? DBNull.Value : (object)value.TEMPERATURA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PUERTAS_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PUERTAS_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PUERTAS_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PUERTAS_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PUERTAS_MOVIMIENTOS</c> table using
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
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBASCULA_ID(decimal bascula_id)
		{
			return DeleteByBASCULA_ID(bascula_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <param name="bascula_idNull">true if the method ignores the bascula_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBASCULA_ID(decimal bascula_id, bool bascula_idNull)
		{
			return CreateDeleteByBASCULA_IDCommand(bascula_id, bascula_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_BASCULA_ID</c> foreign key.
		/// </summary>
		/// <param name="bascula_id">The <c>BASCULA_ID</c> column value.</param>
		/// <param name="bascula_idNull">true if the method ignores the bascula_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBASCULA_IDCommand(decimal bascula_id, bool bascula_idNull)
		{
			string whereSql = "";
			if(bascula_idNull)
				whereSql += "BASCULA_ID IS NULL";
			else
				whereSql += "BASCULA_ID=" + _db.CreateSqlParameterName("BASCULA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!bascula_idNull)
				AddParameter(cmd, "BASCULA_ID", bascula_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return CreateDeleteByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEQUIPO_AUTORIZADO_DET_ID(decimal equipo_autorizado_det_id)
		{
			return DeleteByEQUIPO_AUTORIZADO_DET_ID(equipo_autorizado_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <param name="equipo_autorizado_det_idNull">true if the method ignores the equipo_autorizado_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEQUIPO_AUTORIZADO_DET_ID(decimal equipo_autorizado_det_id, bool equipo_autorizado_det_idNull)
		{
			return CreateDeleteByEQUIPO_AUTORIZADO_DET_IDCommand(equipo_autorizado_det_id, equipo_autorizado_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_EQUI_AUT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_det_id">The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</param>
		/// <param name="equipo_autorizado_det_idNull">true if the method ignores the equipo_autorizado_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEQUIPO_AUTORIZADO_DET_IDCommand(decimal equipo_autorizado_det_id, bool equipo_autorizado_det_idNull)
		{
			string whereSql = "";
			if(equipo_autorizado_det_idNull)
				whereSql += "EQUIPO_AUTORIZADO_DET_ID IS NULL";
			else
				whereSql += "EQUIPO_AUTORIZADO_DET_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!equipo_autorizado_det_idNull)
				AddParameter(cmd, "EQUIPO_AUTORIZADO_DET_ID", equipo_autorizado_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPOS_ID(decimal intercambio_equipos_id)
		{
			return DeleteByINTERCAMBIO_EQUIPOS_ID(intercambio_equipos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <param name="intercambio_equipos_idNull">true if the method ignores the intercambio_equipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPOS_ID(decimal intercambio_equipos_id, bool intercambio_equipos_idNull)
		{
			return CreateDeleteByINTERCAMBIO_EQUIPOS_IDCommand(intercambio_equipos_id, intercambio_equipos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipos_id">The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</param>
		/// <param name="intercambio_equipos_idNull">true if the method ignores the intercambio_equipos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINTERCAMBIO_EQUIPOS_IDCommand(decimal intercambio_equipos_id, bool intercambio_equipos_idNull)
		{
			string whereSql = "";
			if(intercambio_equipos_idNull)
				whereSql += "INTERCAMBIO_EQUIPOS_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPOS_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!intercambio_equipos_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPOS_ID", intercambio_equipos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id)
		{
			return DeleteByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return CreateDeleteByPUERTO_IDCommand(puerto_id, puerto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTO_IDCommand(decimal puerto_id, bool puerto_idNull)
		{
			string whereSql = "";
			if(puerto_idNull)
				whereSql += "PUERTO_ID IS NULL";
			else
				whereSql += "PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerto_idNull)
				AddParameter(cmd, "PUERTO_ID", puerto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CONFIRMACION_ID(decimal usuario_confirmacion_id)
		{
			return DeleteByUSUARIO_CONFIRMACION_ID(usuario_confirmacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <param name="usuario_confirmacion_idNull">true if the method ignores the usuario_confirmacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CONFIRMACION_ID(decimal usuario_confirmacion_id, bool usuario_confirmacion_idNull)
		{
			return CreateDeleteByUSUARIO_CONFIRMACION_IDCommand(usuario_confirmacion_id, usuario_confirmacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_USR_CONF</c> foreign key.
		/// </summary>
		/// <param name="usuario_confirmacion_id">The <c>USUARIO_CONFIRMACION_ID</c> column value.</param>
		/// <param name="usuario_confirmacion_idNull">true if the method ignores the usuario_confirmacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CONFIRMACION_IDCommand(decimal usuario_confirmacion_id, bool usuario_confirmacion_idNull)
		{
			string whereSql = "";
			if(usuario_confirmacion_idNull)
				whereSql += "USUARIO_CONFIRMACION_ID IS NULL";
			else
				whereSql += "USUARIO_CONFIRMACION_ID=" + _db.CreateSqlParameterName("USUARIO_CONFIRMACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_confirmacion_idNull)
				AddParameter(cmd, "USUARIO_CONFIRMACION_ID", usuario_confirmacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return DeleteByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PUERTAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PUERTAS_MOV_USR_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PUERTAS_MOVIMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>PUERTAS_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PUERTAS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PUERTAS_MOVIMIENTOS</c> table.
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		protected PUERTAS_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		protected PUERTAS_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual PUERTAS_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int bascula_idColumnIndex = reader.GetOrdinal("BASCULA_ID");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_tractoColumnIndex = reader.GetOrdinal("CHAPA_TRACTO");
			int numero_comprobanteColumnIndex = reader.GetOrdinal("NUMERO_COMPROBANTE");
			int importacion_terrestreColumnIndex = reader.GetOrdinal("IMPORTACION_TERRESTRE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int estado_contenedorColumnIndex = reader.GetOrdinal("ESTADO_CONTENEDOR");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int movimientoColumnIndex = reader.GetOrdinal("MOVIMIENTO");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int nota_remisionColumnIndex = reader.GetOrdinal("NOTA_REMISION");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int intercambio_equipos_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPOS_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_confirmacion_idColumnIndex = reader.GetOrdinal("USUARIO_CONFIRMACION_ID");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int booking_blColumnIndex = reader.GetOrdinal("BOOKING_BL");
			int nro_autorizacionColumnIndex = reader.GetOrdinal("NRO_AUTORIZACION");
			int equipo_autorizado_det_idColumnIndex = reader.GetOrdinal("EQUIPO_AUTORIZADO_DET_ID");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int codigo_autorizacionColumnIndex = reader.GetOrdinal("CODIGO_AUTORIZACION");
			int set_pointColumnIndex = reader.GetOrdinal("SET_POINT");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int contendor_claseColumnIndex = reader.GetOrdinal("CONTENDOR_CLASE");
			int cliente_externoColumnIndex = reader.GetOrdinal("CLIENTE_EXTERNO");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int dano_informadoColumnIndex = reader.GetOrdinal("DANO_INFORMADO");
			int rechazadoColumnIndex = reader.GetOrdinal("RECHAZADO");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int temperaturaColumnIndex = reader.GetOrdinal("TEMPERATURA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PUERTAS_MOVIMIENTOSRow record = new PUERTAS_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(bascula_idColumnIndex))
						record.BASCULA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(bascula_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_movimientoColumnIndex))
						record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_tractoColumnIndex))
						record.CHAPA_TRACTO = Convert.ToString(reader.GetValue(chapa_tractoColumnIndex));
					if(!reader.IsDBNull(numero_comprobanteColumnIndex))
						record.NUMERO_COMPROBANTE = Convert.ToString(reader.GetValue(numero_comprobanteColumnIndex));
					if(!reader.IsDBNull(importacion_terrestreColumnIndex))
						record.IMPORTACION_TERRESTRE = Convert.ToString(reader.GetValue(importacion_terrestreColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_contenedorColumnIndex))
						record.ESTADO_CONTENEDOR = Convert.ToString(reader.GetValue(estado_contenedorColumnIndex));
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(movimientoColumnIndex))
						record.MOVIMIENTO = Convert.ToString(reader.GetValue(movimientoColumnIndex));
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(nota_remisionColumnIndex))
						record.NOTA_REMISION = Convert.ToString(reader.GetValue(nota_remisionColumnIndex));
					record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
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
					if(!reader.IsDBNull(intercambio_equipos_idColumnIndex))
						record.INTERCAMBIO_EQUIPOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipos_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_confirmacion_idColumnIndex))
						record.USUARIO_CONFIRMACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_confirmacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
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
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(booking_blColumnIndex))
						record.BOOKING_BL = Convert.ToString(reader.GetValue(booking_blColumnIndex));
					if(!reader.IsDBNull(nro_autorizacionColumnIndex))
						record.NRO_AUTORIZACION = Convert.ToString(reader.GetValue(nro_autorizacionColumnIndex));
					if(!reader.IsDBNull(equipo_autorizado_det_idColumnIndex))
						record.EQUIPO_AUTORIZADO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(equipo_autorizado_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(eir_refrigeradoColumnIndex))
						record.EIR_REFRIGERADO = Convert.ToString(reader.GetValue(eir_refrigeradoColumnIndex));
					if(!reader.IsDBNull(codigo_autorizacionColumnIndex))
						record.CODIGO_AUTORIZACION = Convert.ToString(reader.GetValue(codigo_autorizacionColumnIndex));
					if(!reader.IsDBNull(set_pointColumnIndex))
						record.SET_POINT = Math.Round(Convert.ToDecimal(reader.GetValue(set_pointColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(contendor_claseColumnIndex))
						record.CONTENDOR_CLASE = Convert.ToString(reader.GetValue(contendor_claseColumnIndex));
					if(!reader.IsDBNull(cliente_externoColumnIndex))
						record.CLIENTE_EXTERNO = Convert.ToString(reader.GetValue(cliente_externoColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(dano_informadoColumnIndex))
						record.DANO_INFORMADO = Convert.ToString(reader.GetValue(dano_informadoColumnIndex));
					if(!reader.IsDBNull(rechazadoColumnIndex))
						record.RECHAZADO = Convert.ToString(reader.GetValue(rechazadoColumnIndex));
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(temperaturaColumnIndex))
						record.TEMPERATURA = Math.Round(Convert.ToDecimal(reader.GetValue(temperaturaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PUERTAS_MOVIMIENTOSRow[])(recordList.ToArray(typeof(PUERTAS_MOVIMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PUERTAS_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PUERTAS_MOVIMIENTOSRow"/> object.</returns>
		protected virtual PUERTAS_MOVIMIENTOSRow MapRow(DataRow row)
		{
			PUERTAS_MOVIMIENTOSRow mappedObject = new PUERTAS_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "BASCULA_ID"
			dataColumn = dataTable.Columns["BASCULA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BASCULA_ID = (decimal)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_TRACTO"
			dataColumn = dataTable.Columns["CHAPA_TRACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_TRACTO = (string)row[dataColumn];
			// Column "NUMERO_COMPROBANTE"
			dataColumn = dataTable.Columns["NUMERO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_COMPROBANTE = (string)row[dataColumn];
			// Column "IMPORTACION_TERRESTRE"
			dataColumn = dataTable.Columns["IMPORTACION_TERRESTRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_TERRESTRE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "ESTADO_CONTENEDOR"
			dataColumn = dataTable.Columns["ESTADO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CONTENEDOR = (string)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MOVIMIENTO"
			dataColumn = dataTable.Columns["MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO = (string)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "NOTA_REMISION"
			dataColumn = dataTable.Columns["NOTA_REMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_REMISION = (string)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
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
			// Column "INTERCAMBIO_EQUIPOS_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPOS_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CONFIRMACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CONFIRMACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CONFIRMACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
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
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "BOOKING_BL"
			dataColumn = dataTable.Columns["BOOKING_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING_BL = (string)row[dataColumn];
			// Column "NRO_AUTORIZACION"
			dataColumn = dataTable.Columns["NRO_AUTORIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_AUTORIZACION = (string)row[dataColumn];
			// Column "EQUIPO_AUTORIZADO_DET_ID"
			dataColumn = dataTable.Columns["EQUIPO_AUTORIZADO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EQUIPO_AUTORIZADO_DET_ID = (decimal)row[dataColumn];
			// Column "EIR_REFRIGERADO"
			dataColumn = dataTable.Columns["EIR_REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_REFRIGERADO = (string)row[dataColumn];
			// Column "CODIGO_AUTORIZACION"
			dataColumn = dataTable.Columns["CODIGO_AUTORIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_AUTORIZACION = (string)row[dataColumn];
			// Column "SET_POINT"
			dataColumn = dataTable.Columns["SET_POINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SET_POINT = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "CONTENDOR_CLASE"
			dataColumn = dataTable.Columns["CONTENDOR_CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENDOR_CLASE = (string)row[dataColumn];
			// Column "CLIENTE_EXTERNO"
			dataColumn = dataTable.Columns["CLIENTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE_EXTERNO = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			// Column "DANO_INFORMADO"
			dataColumn = dataTable.Columns["DANO_INFORMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANO_INFORMADO = (string)row[dataColumn];
			// Column "RECHAZADO"
			dataColumn = dataTable.Columns["RECHAZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECHAZADO = (string)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
			// Column "TEMPERATURA"
			dataColumn = dataTable.Columns["TEMPERATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPERATURA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PUERTAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PUERTAS_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BASCULA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CHAPA_TRACTO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("NUMERO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("IMPORTACION_TERRESTRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOTA_REMISION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 25;
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
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CONFIRMACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
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
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BOOKING_BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("NRO_AUTORIZACION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("EQUIPO_AUTORIZADO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("CODIGO_AUTORIZACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SET_POINT", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTENDOR_CLASE", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CLIENTE_EXTERNO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DANO_INFORMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("RECHAZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TEMPERATURA", typeof(decimal));
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

				case "BASCULA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_TRACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTACION_TERRESTRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_REMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "INTERCAMBIO_EQUIPOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CONFIRMACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
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

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOOKING_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_AUTORIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EQUIPO_AUTORIZADO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EIR_REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_AUTORIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SET_POINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENDOR_CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLIENTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DANO_INFORMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RECHAZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEMPERATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PUERTAS_MOVIMIENTOSCollection_Base class
}  // End of namespace
