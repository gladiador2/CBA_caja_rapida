// <fileinfo name="CONOCIMIENTOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="CONOCIMIENTOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONOCIMIENTOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONOCIMIENTOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CONOCIMIENTO_IDColumnName = "CONOCIMIENTO_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string SET_POINTColumnName = "SET_POINT";
		public const string PESO_MANIFIESTOColumnName = "PESO_MANIFIESTO";
		public const string VACIAMIENTOColumnName = "VACIAMIENTO";
		public const string TRASLADOColumnName = "TRASLADO";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string SERVICIO_EXTERNOColumnName = "SERVICIO_EXTERNO";
		public const string FCL_LCLColumnName = "FCL_LCL";
		public const string OBSERVACIONES_CONCIMIENTOColumnName = "OBSERVACIONES_CONCIMIENTO";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string INGRESADOColumnName = "INGRESADO";
		public const string ESTADO_CONTENEDORColumnName = "ESTADO_CONTENEDOR";
		public const string CATEGORIA_IMO_IDColumnName = "CATEGORIA_IMO_ID";
		public const string LINEAS_IDColumnName = "LINEAS_ID";
		public const string CONOCIMIENTOS_CONTENIDO_IDColumnName = "CONOCIMIENTOS_CONTENIDO_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string PAYLOAD_EIRColumnName = "PAYLOAD_EIR";
		public const string TARA_EIRColumnName = "TARA_EIR";
		public const string HORA_EIRColumnName = "HORA_EIR";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string OBSERVACIONES_EIRColumnName = "OBSERVACIONES_EIR";
		public const string TEMPERATURA_EIRColumnName = "TEMPERATURA_EIR";
		public const string EDIColumnName = "EDI";
		public const string EDI_ANULADOColumnName = "EDI_ANULADO";
		public const string EDI_ARMADORColumnName = "EDI_ARMADOR";
		public const string PROCESADO_EIRColumnName = "PROCESADO_EIR";
		public const string INTERCAMBIO_EQUIPO_IDColumnName = "INTERCAMBIO_EQUIPO_ID";
		public const string PRECINTO_1_EIRColumnName = "PRECINTO_1_EIR";
		public const string PRECINTO_2_EIRColumnName = "PRECINTO_2_EIR";
		public const string PRECINTO_3_EIRColumnName = "PRECINTO_3_EIR";
		public const string PRECINTO_4_EIRColumnName = "PRECINTO_4_EIR";
		public const string PRECINTO_5_EIRColumnName = "PRECINTO_5_EIR";
		public const string PRECINTO_VENTILETE_EIRColumnName = "PRECINTO_VENTILETE_EIR";
		public const string DESCARTADOColumnName = "DESCARTADO";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string DANADOColumnName = "DANADO";
		public const string DANO_INFORMADOColumnName = "DANO_INFORMADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONOCIMIENTOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONOCIMIENTOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONOCIMIENTOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONOCIMIENTOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONOCIMIENTOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONOCIMIENTOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONOCIMIENTOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONOCIMIENTOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONOCIMIENTOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetByCONOCIMIENTOS_CONTENIDO_ID(decimal conocimientos_contenido_id)
		{
			return GetByCONOCIMIENTOS_CONTENIDO_ID(conocimientos_contenido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimientos_contenido_idNull">true if the method ignores the conocimientos_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByCONOCIMIENTOS_CONTENIDO_ID(decimal conocimientos_contenido_id, bool conocimientos_contenido_idNull)
		{
			return MapRecords(CreateGetByCONOCIMIENTOS_CONTENIDO_IDCommand(conocimientos_contenido_id, conocimientos_contenido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONOCIMIENTOS_CONTENIDO_IDAsDataTable(decimal conocimientos_contenido_id)
		{
			return GetByCONOCIMIENTOS_CONTENIDO_IDAsDataTable(conocimientos_contenido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimientos_contenido_idNull">true if the method ignores the conocimientos_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTOS_CONTENIDO_IDAsDataTable(decimal conocimientos_contenido_id, bool conocimientos_contenido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTOS_CONTENIDO_IDCommand(conocimientos_contenido_id, conocimientos_contenido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimientos_contenido_idNull">true if the method ignores the conocimientos_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTOS_CONTENIDO_IDCommand(decimal conocimientos_contenido_id, bool conocimientos_contenido_idNull)
		{
			string whereSql = "";
			if(conocimientos_contenido_idNull)
				whereSql += "CONOCIMIENTOS_CONTENIDO_ID IS NULL";
			else
				whereSql += "CONOCIMIENTOS_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conocimientos_contenido_idNull)
				AddParameter(cmd, "CONOCIMIENTOS_CONTENIDO_ID", conocimientos_contenido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_CONOCIMIENT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_id">The <c>CONOCIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByCONOCIMIENTO_ID(decimal conocimiento_id)
		{
			return MapRecords(CreateGetByCONOCIMIENTO_IDCommand(conocimiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_CONOCIMIENT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_id">The <c>CONOCIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTO_IDAsDataTable(decimal conocimiento_id)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTO_IDCommand(conocimiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CON_DETALLES_CONOCIMIENT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_id">The <c>CONOCIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTO_IDCommand(decimal conocimiento_id)
		{
			string whereSql = "";
			whereSql += "CONOCIMIENTO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONOCIMIENTO_ID", conocimiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
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
		/// return records by the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
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
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return MapRecords(CreateGetByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINTERCAMBIO_EQUIPO_IDAsDataTable(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_IDAsDataTable(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINTERCAMBIO_EQUIPO_IDAsDataTable(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINTERCAMBIO_EQUIPO_IDCommand(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			string whereSql = "";
			if(intercambio_equipo_idNull)
				whereSql += "INTERCAMBIO_EQUIPO_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!intercambio_equipo_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID", intercambio_equipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public CONOCIMIENTOS_DETALLESRow[] GetByPUERTO_ID(decimal puerto_id)
		{
			return GetByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects 
		/// by the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_DETALLESRow[] GetByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecords(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id)
		{
			return GetByPUERTO_IDAsDataTable(puerto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
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
		/// return records by the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
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
		/// Adds a new record into the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(CONOCIMIENTOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONOCIMIENTOS_DETALLES (" +
				"ID, " +
				"CONOCIMIENTO_ID, " +
				"CONTENEDOR_ID, " +
				"SET_POINT, " +
				"PESO_MANIFIESTO, " +
				"VACIAMIENTO, " +
				"TRASLADO, " +
				"DEPOSITO_ID, " +
				"SERVICIO_EXTERNO, " +
				"FCL_LCL, " +
				"OBSERVACIONES_CONCIMIENTO, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"INGRESADO, " +
				"ESTADO_CONTENEDOR, " +
				"CATEGORIA_IMO_ID, " +
				"LINEAS_ID, " +
				"CONOCIMIENTOS_CONTENIDO_ID, " +
				"CANTIDAD, " +
				"PAYLOAD_EIR, " +
				"TARA_EIR, " +
				"HORA_EIR, " +
				"PRECINTO_VENTILETE, " +
				"OBSERVACIONES_EIR, " +
				"TEMPERATURA_EIR, " +
				"EDI, " +
				"EDI_ANULADO, " +
				"EDI_ARMADOR, " +
				"PROCESADO_EIR, " +
				"INTERCAMBIO_EQUIPO_ID, " +
				"PRECINTO_1_EIR, " +
				"PRECINTO_2_EIR, " +
				"PRECINTO_3_EIR, " +
				"PRECINTO_4_EIR, " +
				"PRECINTO_5_EIR, " +
				"PRECINTO_VENTILETE_EIR, " +
				"DESCARTADO, " +
				"EIR_PISO, " +
				"EIR_FONDO, " +
				"EIR_TECHO, " +
				"EIR_PANEL_DERECHO, " +
				"EIR_PANEL_IZQUIERDO, " +
				"EIR_PUERTA, " +
				"PUERTO_ID, " +
				"EIR_REFRIGERADO, " +
				"DANADO, " +
				"DANO_INFORMADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("SET_POINT") + ", " +
				_db.CreateSqlParameterName("PESO_MANIFIESTO") + ", " +
				_db.CreateSqlParameterName("VACIAMIENTO") + ", " +
				_db.CreateSqlParameterName("TRASLADO") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("SERVICIO_EXTERNO") + ", " +
				_db.CreateSqlParameterName("FCL_LCL") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES_CONCIMIENTO") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("INGRESADO") + ", " +
				_db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("CATEGORIA_IMO_ID") + ", " +
				_db.CreateSqlParameterName("LINEAS_ID") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("PAYLOAD_EIR") + ", " +
				_db.CreateSqlParameterName("TARA_EIR") + ", " +
				_db.CreateSqlParameterName("HORA_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES_EIR") + ", " +
				_db.CreateSqlParameterName("TEMPERATURA_EIR") + ", " +
				_db.CreateSqlParameterName("EDI") + ", " +
				_db.CreateSqlParameterName("EDI_ANULADO") + ", " +
				_db.CreateSqlParameterName("EDI_ARMADOR") + ", " +
				_db.CreateSqlParameterName("PROCESADO_EIR") + ", " +
				_db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE_EIR") + ", " +
				_db.CreateSqlParameterName("DESCARTADO") + ", " +
				_db.CreateSqlParameterName("EIR_PISO") + ", " +
				_db.CreateSqlParameterName("EIR_FONDO") + ", " +
				_db.CreateSqlParameterName("EIR_TECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				_db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				_db.CreateSqlParameterName("PUERTO_ID") + ", " +
				_db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				_db.CreateSqlParameterName("DANADO") + ", " +
				_db.CreateSqlParameterName("DANO_INFORMADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CONOCIMIENTO_ID", value.CONOCIMIENTO_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "SET_POINT", value.SET_POINT);
			AddParameter(cmd, "PESO_MANIFIESTO",
				value.IsPESO_MANIFIESTONull ? DBNull.Value : (object)value.PESO_MANIFIESTO);
			AddParameter(cmd, "VACIAMIENTO", value.VACIAMIENTO);
			AddParameter(cmd, "TRASLADO", value.TRASLADO);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "SERVICIO_EXTERNO", value.SERVICIO_EXTERNO);
			AddParameter(cmd, "FCL_LCL", value.FCL_LCL);
			AddParameter(cmd, "OBSERVACIONES_CONCIMIENTO", value.OBSERVACIONES_CONCIMIENTO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "INGRESADO", value.INGRESADO);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "CATEGORIA_IMO_ID",
				value.IsCATEGORIA_IMO_IDNull ? DBNull.Value : (object)value.CATEGORIA_IMO_ID);
			AddParameter(cmd, "LINEAS_ID",
				value.IsLINEAS_IDNull ? DBNull.Value : (object)value.LINEAS_ID);
			AddParameter(cmd, "CONOCIMIENTOS_CONTENIDO_ID",
				value.IsCONOCIMIENTOS_CONTENIDO_IDNull ? DBNull.Value : (object)value.CONOCIMIENTOS_CONTENIDO_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PAYLOAD_EIR",
				value.IsPAYLOAD_EIRNull ? DBNull.Value : (object)value.PAYLOAD_EIR);
			AddParameter(cmd, "TARA_EIR",
				value.IsTARA_EIRNull ? DBNull.Value : (object)value.TARA_EIR);
			AddParameter(cmd, "HORA_EIR",
				value.IsHORA_EIRNull ? DBNull.Value : (object)value.HORA_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "OBSERVACIONES_EIR", value.OBSERVACIONES_EIR);
			AddParameter(cmd, "TEMPERATURA_EIR", value.TEMPERATURA_EIR);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "EDI_ANULADO", value.EDI_ANULADO);
			AddParameter(cmd, "EDI_ARMADOR", value.EDI_ARMADOR);
			AddParameter(cmd, "PROCESADO_EIR", value.PROCESADO_EIR);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PRECINTO_1_EIR", value.PRECINTO_1_EIR);
			AddParameter(cmd, "PRECINTO_2_EIR", value.PRECINTO_2_EIR);
			AddParameter(cmd, "PRECINTO_3_EIR", value.PRECINTO_3_EIR);
			AddParameter(cmd, "PRECINTO_4_EIR", value.PRECINTO_4_EIR);
			AddParameter(cmd, "PRECINTO_5_EIR", value.PRECINTO_5_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE_EIR", value.PRECINTO_VENTILETE_EIR);
			AddParameter(cmd, "DESCARTADO", value.DESCARTADO);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONOCIMIENTOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONOCIMIENTOS_DETALLES SET " +
				"CONOCIMIENTO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"SET_POINT=" + _db.CreateSqlParameterName("SET_POINT") + ", " +
				"PESO_MANIFIESTO=" + _db.CreateSqlParameterName("PESO_MANIFIESTO") + ", " +
				"VACIAMIENTO=" + _db.CreateSqlParameterName("VACIAMIENTO") + ", " +
				"TRASLADO=" + _db.CreateSqlParameterName("TRASLADO") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"SERVICIO_EXTERNO=" + _db.CreateSqlParameterName("SERVICIO_EXTERNO") + ", " +
				"FCL_LCL=" + _db.CreateSqlParameterName("FCL_LCL") + ", " +
				"OBSERVACIONES_CONCIMIENTO=" + _db.CreateSqlParameterName("OBSERVACIONES_CONCIMIENTO") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"INGRESADO=" + _db.CreateSqlParameterName("INGRESADO") + ", " +
				"ESTADO_CONTENEDOR=" + _db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				"CATEGORIA_IMO_ID=" + _db.CreateSqlParameterName("CATEGORIA_IMO_ID") + ", " +
				"LINEAS_ID=" + _db.CreateSqlParameterName("LINEAS_ID") + ", " +
				"CONOCIMIENTOS_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDO_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"PAYLOAD_EIR=" + _db.CreateSqlParameterName("PAYLOAD_EIR") + ", " +
				"TARA_EIR=" + _db.CreateSqlParameterName("TARA_EIR") + ", " +
				"HORA_EIR=" + _db.CreateSqlParameterName("HORA_EIR") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"OBSERVACIONES_EIR=" + _db.CreateSqlParameterName("OBSERVACIONES_EIR") + ", " +
				"TEMPERATURA_EIR=" + _db.CreateSqlParameterName("TEMPERATURA_EIR") + ", " +
				"EDI=" + _db.CreateSqlParameterName("EDI") + ", " +
				"EDI_ANULADO=" + _db.CreateSqlParameterName("EDI_ANULADO") + ", " +
				"EDI_ARMADOR=" + _db.CreateSqlParameterName("EDI_ARMADOR") + ", " +
				"PROCESADO_EIR=" + _db.CreateSqlParameterName("PROCESADO_EIR") + ", " +
				"INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				"PRECINTO_1_EIR=" + _db.CreateSqlParameterName("PRECINTO_1_EIR") + ", " +
				"PRECINTO_2_EIR=" + _db.CreateSqlParameterName("PRECINTO_2_EIR") + ", " +
				"PRECINTO_3_EIR=" + _db.CreateSqlParameterName("PRECINTO_3_EIR") + ", " +
				"PRECINTO_4_EIR=" + _db.CreateSqlParameterName("PRECINTO_4_EIR") + ", " +
				"PRECINTO_5_EIR=" + _db.CreateSqlParameterName("PRECINTO_5_EIR") + ", " +
				"PRECINTO_VENTILETE_EIR=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE_EIR") + ", " +
				"DESCARTADO=" + _db.CreateSqlParameterName("DESCARTADO") + ", " +
				"EIR_PISO=" + _db.CreateSqlParameterName("EIR_PISO") + ", " +
				"EIR_FONDO=" + _db.CreateSqlParameterName("EIR_FONDO") + ", " +
				"EIR_TECHO=" + _db.CreateSqlParameterName("EIR_TECHO") + ", " +
				"EIR_PANEL_DERECHO=" + _db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				"EIR_PANEL_IZQUIERDO=" + _db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				"EIR_PUERTA=" + _db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				"PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID") + ", " +
				"EIR_REFRIGERADO=" + _db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				"DANADO=" + _db.CreateSqlParameterName("DANADO") + ", " +
				"DANO_INFORMADO=" + _db.CreateSqlParameterName("DANO_INFORMADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONOCIMIENTO_ID", value.CONOCIMIENTO_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "SET_POINT", value.SET_POINT);
			AddParameter(cmd, "PESO_MANIFIESTO",
				value.IsPESO_MANIFIESTONull ? DBNull.Value : (object)value.PESO_MANIFIESTO);
			AddParameter(cmd, "VACIAMIENTO", value.VACIAMIENTO);
			AddParameter(cmd, "TRASLADO", value.TRASLADO);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "SERVICIO_EXTERNO", value.SERVICIO_EXTERNO);
			AddParameter(cmd, "FCL_LCL", value.FCL_LCL);
			AddParameter(cmd, "OBSERVACIONES_CONCIMIENTO", value.OBSERVACIONES_CONCIMIENTO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "INGRESADO", value.INGRESADO);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "CATEGORIA_IMO_ID",
				value.IsCATEGORIA_IMO_IDNull ? DBNull.Value : (object)value.CATEGORIA_IMO_ID);
			AddParameter(cmd, "LINEAS_ID",
				value.IsLINEAS_IDNull ? DBNull.Value : (object)value.LINEAS_ID);
			AddParameter(cmd, "CONOCIMIENTOS_CONTENIDO_ID",
				value.IsCONOCIMIENTOS_CONTENIDO_IDNull ? DBNull.Value : (object)value.CONOCIMIENTOS_CONTENIDO_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PAYLOAD_EIR",
				value.IsPAYLOAD_EIRNull ? DBNull.Value : (object)value.PAYLOAD_EIR);
			AddParameter(cmd, "TARA_EIR",
				value.IsTARA_EIRNull ? DBNull.Value : (object)value.TARA_EIR);
			AddParameter(cmd, "HORA_EIR",
				value.IsHORA_EIRNull ? DBNull.Value : (object)value.HORA_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "OBSERVACIONES_EIR", value.OBSERVACIONES_EIR);
			AddParameter(cmd, "TEMPERATURA_EIR", value.TEMPERATURA_EIR);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "EDI_ANULADO", value.EDI_ANULADO);
			AddParameter(cmd, "EDI_ARMADOR", value.EDI_ARMADOR);
			AddParameter(cmd, "PROCESADO_EIR", value.PROCESADO_EIR);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PRECINTO_1_EIR", value.PRECINTO_1_EIR);
			AddParameter(cmd, "PRECINTO_2_EIR", value.PRECINTO_2_EIR);
			AddParameter(cmd, "PRECINTO_3_EIR", value.PRECINTO_3_EIR);
			AddParameter(cmd, "PRECINTO_4_EIR", value.PRECINTO_4_EIR);
			AddParameter(cmd, "PRECINTO_5_EIR", value.PRECINTO_5_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE_EIR", value.PRECINTO_VENTILETE_EIR);
			AddParameter(cmd, "DESCARTADO", value.DESCARTADO);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONOCIMIENTOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONOCIMIENTOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONOCIMIENTOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONOCIMIENTOS_DETALLES</c> table using
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
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTOS_CONTENIDO_ID(decimal conocimientos_contenido_id)
		{
			return DeleteByCONOCIMIENTOS_CONTENIDO_ID(conocimientos_contenido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimientos_contenido_idNull">true if the method ignores the conocimientos_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTOS_CONTENIDO_ID(decimal conocimientos_contenido_id, bool conocimientos_contenido_idNull)
		{
			return CreateDeleteByCONOCIMIENTOS_CONTENIDO_IDCommand(conocimientos_contenido_id, conocimientos_contenido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CON_DETALLES_CON_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenido_id">The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</param>
		/// <param name="conocimientos_contenido_idNull">true if the method ignores the conocimientos_contenido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTOS_CONTENIDO_IDCommand(decimal conocimientos_contenido_id, bool conocimientos_contenido_idNull)
		{
			string whereSql = "";
			if(conocimientos_contenido_idNull)
				whereSql += "CONOCIMIENTOS_CONTENIDO_ID IS NULL";
			else
				whereSql += "CONOCIMIENTOS_CONTENIDO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conocimientos_contenido_idNull)
				AddParameter(cmd, "CONOCIMIENTOS_CONTENIDO_ID", conocimientos_contenido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_CONOCIMIENT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_id">The <c>CONOCIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_ID(decimal conocimiento_id)
		{
			return CreateDeleteByCONOCIMIENTO_IDCommand(conocimiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CON_DETALLES_CONOCIMIENT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_id">The <c>CONOCIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTO_IDCommand(decimal conocimiento_id)
		{
			string whereSql = "";
			whereSql += "CONOCIMIENTO_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONOCIMIENTO_ID", conocimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
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
		/// delete records using the <c>FK_CON_DETALLES_CONTENEDOR_ID</c> foreign key.
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
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CON_DETALLES_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return DeleteByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return CreateDeleteByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CON_DETALLES_INTER_EQUIP_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINTERCAMBIO_EQUIPO_IDCommand(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			string whereSql = "";
			if(intercambio_equipo_idNull)
				whereSql += "INTERCAMBIO_EQUIPO_ID IS NULL";
			else
				whereSql += "INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!intercambio_equipo_idNull)
				AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID", intercambio_equipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id)
		{
			return DeleteByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONOCIMIENTOS_DETALLES</c> table using the 
		/// <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
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
		/// delete records using the <c>FK_CON_DETALLES_PUERTO_ID</c> foreign key.
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
		/// Deletes <c>CONOCIMIENTOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>CONOCIMIENTOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONOCIMIENTOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONOCIMIENTOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		protected CONOCIMIENTOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		protected CONOCIMIENTOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_DETALLESRow"/> objects.</returns>
		protected virtual CONOCIMIENTOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int conocimiento_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int set_pointColumnIndex = reader.GetOrdinal("SET_POINT");
			int peso_manifiestoColumnIndex = reader.GetOrdinal("PESO_MANIFIESTO");
			int vaciamientoColumnIndex = reader.GetOrdinal("VACIAMIENTO");
			int trasladoColumnIndex = reader.GetOrdinal("TRASLADO");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int servicio_externoColumnIndex = reader.GetOrdinal("SERVICIO_EXTERNO");
			int fcl_lclColumnIndex = reader.GetOrdinal("FCL_LCL");
			int observaciones_concimientoColumnIndex = reader.GetOrdinal("OBSERVACIONES_CONCIMIENTO");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int ingresadoColumnIndex = reader.GetOrdinal("INGRESADO");
			int estado_contenedorColumnIndex = reader.GetOrdinal("ESTADO_CONTENEDOR");
			int categoria_imo_idColumnIndex = reader.GetOrdinal("CATEGORIA_IMO_ID");
			int lineas_idColumnIndex = reader.GetOrdinal("LINEAS_ID");
			int conocimientos_contenido_idColumnIndex = reader.GetOrdinal("CONOCIMIENTOS_CONTENIDO_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int payload_eirColumnIndex = reader.GetOrdinal("PAYLOAD_EIR");
			int tara_eirColumnIndex = reader.GetOrdinal("TARA_EIR");
			int hora_eirColumnIndex = reader.GetOrdinal("HORA_EIR");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int observaciones_eirColumnIndex = reader.GetOrdinal("OBSERVACIONES_EIR");
			int temperatura_eirColumnIndex = reader.GetOrdinal("TEMPERATURA_EIR");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int edi_anuladoColumnIndex = reader.GetOrdinal("EDI_ANULADO");
			int edi_armadorColumnIndex = reader.GetOrdinal("EDI_ARMADOR");
			int procesado_eirColumnIndex = reader.GetOrdinal("PROCESADO_EIR");
			int intercambio_equipo_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPO_ID");
			int precinto_1_eirColumnIndex = reader.GetOrdinal("PRECINTO_1_EIR");
			int precinto_2_eirColumnIndex = reader.GetOrdinal("PRECINTO_2_EIR");
			int precinto_3_eirColumnIndex = reader.GetOrdinal("PRECINTO_3_EIR");
			int precinto_4_eirColumnIndex = reader.GetOrdinal("PRECINTO_4_EIR");
			int precinto_5_eirColumnIndex = reader.GetOrdinal("PRECINTO_5_EIR");
			int precinto_ventilete_eirColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE_EIR");
			int descartadoColumnIndex = reader.GetOrdinal("DESCARTADO");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int dano_informadoColumnIndex = reader.GetOrdinal("DANO_INFORMADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONOCIMIENTOS_DETALLESRow record = new CONOCIMIENTOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CONOCIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(set_pointColumnIndex))
						record.SET_POINT = Convert.ToString(reader.GetValue(set_pointColumnIndex));
					if(!reader.IsDBNull(peso_manifiestoColumnIndex))
						record.PESO_MANIFIESTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_manifiestoColumnIndex)), 9);
					if(!reader.IsDBNull(vaciamientoColumnIndex))
						record.VACIAMIENTO = Convert.ToString(reader.GetValue(vaciamientoColumnIndex));
					if(!reader.IsDBNull(trasladoColumnIndex))
						record.TRASLADO = Convert.ToString(reader.GetValue(trasladoColumnIndex));
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(servicio_externoColumnIndex))
						record.SERVICIO_EXTERNO = Convert.ToString(reader.GetValue(servicio_externoColumnIndex));
					if(!reader.IsDBNull(fcl_lclColumnIndex))
						record.FCL_LCL = Convert.ToString(reader.GetValue(fcl_lclColumnIndex));
					if(!reader.IsDBNull(observaciones_concimientoColumnIndex))
						record.OBSERVACIONES_CONCIMIENTO = Convert.ToString(reader.GetValue(observaciones_concimientoColumnIndex));
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
					if(!reader.IsDBNull(ingresadoColumnIndex))
						record.INGRESADO = Convert.ToString(reader.GetValue(ingresadoColumnIndex));
					if(!reader.IsDBNull(estado_contenedorColumnIndex))
						record.ESTADO_CONTENEDOR = Convert.ToString(reader.GetValue(estado_contenedorColumnIndex));
					if(!reader.IsDBNull(categoria_imo_idColumnIndex))
						record.CATEGORIA_IMO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(categoria_imo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lineas_idColumnIndex))
						record.LINEAS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lineas_idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimientos_contenido_idColumnIndex))
						record.CONOCIMIENTOS_CONTENIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimientos_contenido_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(payload_eirColumnIndex))
						record.PAYLOAD_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(payload_eirColumnIndex)), 9);
					if(!reader.IsDBNull(tara_eirColumnIndex))
						record.TARA_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_eirColumnIndex)), 9);
					if(!reader.IsDBNull(hora_eirColumnIndex))
						record.HORA_EIR = Convert.ToDateTime(reader.GetValue(hora_eirColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(observaciones_eirColumnIndex))
						record.OBSERVACIONES_EIR = Convert.ToString(reader.GetValue(observaciones_eirColumnIndex));
					if(!reader.IsDBNull(temperatura_eirColumnIndex))
						record.TEMPERATURA_EIR = Convert.ToString(reader.GetValue(temperatura_eirColumnIndex));
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(edi_anuladoColumnIndex))
						record.EDI_ANULADO = Convert.ToString(reader.GetValue(edi_anuladoColumnIndex));
					if(!reader.IsDBNull(edi_armadorColumnIndex))
						record.EDI_ARMADOR = Convert.ToString(reader.GetValue(edi_armadorColumnIndex));
					if(!reader.IsDBNull(procesado_eirColumnIndex))
						record.PROCESADO_EIR = Convert.ToString(reader.GetValue(procesado_eirColumnIndex));
					if(!reader.IsDBNull(intercambio_equipo_idColumnIndex))
						record.INTERCAMBIO_EQUIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(precinto_1_eirColumnIndex))
						record.PRECINTO_1_EIR = Convert.ToString(reader.GetValue(precinto_1_eirColumnIndex));
					if(!reader.IsDBNull(precinto_2_eirColumnIndex))
						record.PRECINTO_2_EIR = Convert.ToString(reader.GetValue(precinto_2_eirColumnIndex));
					if(!reader.IsDBNull(precinto_3_eirColumnIndex))
						record.PRECINTO_3_EIR = Convert.ToString(reader.GetValue(precinto_3_eirColumnIndex));
					if(!reader.IsDBNull(precinto_4_eirColumnIndex))
						record.PRECINTO_4_EIR = Convert.ToString(reader.GetValue(precinto_4_eirColumnIndex));
					if(!reader.IsDBNull(precinto_5_eirColumnIndex))
						record.PRECINTO_5_EIR = Convert.ToString(reader.GetValue(precinto_5_eirColumnIndex));
					if(!reader.IsDBNull(precinto_ventilete_eirColumnIndex))
						record.PRECINTO_VENTILETE_EIR = Convert.ToString(reader.GetValue(precinto_ventilete_eirColumnIndex));
					if(!reader.IsDBNull(descartadoColumnIndex))
						record.DESCARTADO = Convert.ToString(reader.GetValue(descartadoColumnIndex));
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
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(eir_refrigeradoColumnIndex))
						record.EIR_REFRIGERADO = Convert.ToString(reader.GetValue(eir_refrigeradoColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(dano_informadoColumnIndex))
						record.DANO_INFORMADO = Convert.ToString(reader.GetValue(dano_informadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONOCIMIENTOS_DETALLESRow[])(recordList.ToArray(typeof(CONOCIMIENTOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONOCIMIENTOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONOCIMIENTOS_DETALLESRow"/> object.</returns>
		protected virtual CONOCIMIENTOS_DETALLESRow MapRow(DataRow row)
		{
			CONOCIMIENTOS_DETALLESRow mappedObject = new CONOCIMIENTOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "SET_POINT"
			dataColumn = dataTable.Columns["SET_POINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SET_POINT = (string)row[dataColumn];
			// Column "PESO_MANIFIESTO"
			dataColumn = dataTable.Columns["PESO_MANIFIESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MANIFIESTO = (decimal)row[dataColumn];
			// Column "VACIAMIENTO"
			dataColumn = dataTable.Columns["VACIAMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VACIAMIENTO = (string)row[dataColumn];
			// Column "TRASLADO"
			dataColumn = dataTable.Columns["TRASLADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRASLADO = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "SERVICIO_EXTERNO"
			dataColumn = dataTable.Columns["SERVICIO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SERVICIO_EXTERNO = (string)row[dataColumn];
			// Column "FCL_LCL"
			dataColumn = dataTable.Columns["FCL_LCL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FCL_LCL = (string)row[dataColumn];
			// Column "OBSERVACIONES_CONCIMIENTO"
			dataColumn = dataTable.Columns["OBSERVACIONES_CONCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES_CONCIMIENTO = (string)row[dataColumn];
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
			// Column "INGRESADO"
			dataColumn = dataTable.Columns["INGRESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESADO = (string)row[dataColumn];
			// Column "ESTADO_CONTENEDOR"
			dataColumn = dataTable.Columns["ESTADO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CONTENEDOR = (string)row[dataColumn];
			// Column "CATEGORIA_IMO_ID"
			dataColumn = dataTable.Columns["CATEGORIA_IMO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CATEGORIA_IMO_ID = (decimal)row[dataColumn];
			// Column "LINEAS_ID"
			dataColumn = dataTable.Columns["LINEAS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEAS_ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTOS_CONTENIDO_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTOS_CONTENIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTOS_CONTENIDO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "PAYLOAD_EIR"
			dataColumn = dataTable.Columns["PAYLOAD_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAYLOAD_EIR = (decimal)row[dataColumn];
			// Column "TARA_EIR"
			dataColumn = dataTable.Columns["TARA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_EIR = (decimal)row[dataColumn];
			// Column "HORA_EIR"
			dataColumn = dataTable.Columns["HORA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_EIR = (System.DateTime)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "OBSERVACIONES_EIR"
			dataColumn = dataTable.Columns["OBSERVACIONES_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES_EIR = (string)row[dataColumn];
			// Column "TEMPERATURA_EIR"
			dataColumn = dataTable.Columns["TEMPERATURA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPERATURA_EIR = (string)row[dataColumn];
			// Column "EDI"
			dataColumn = dataTable.Columns["EDI"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI = (string)row[dataColumn];
			// Column "EDI_ANULADO"
			dataColumn = dataTable.Columns["EDI_ANULADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_ANULADO = (string)row[dataColumn];
			// Column "EDI_ARMADOR"
			dataColumn = dataTable.Columns["EDI_ARMADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_ARMADOR = (string)row[dataColumn];
			// Column "PROCESADO_EIR"
			dataColumn = dataTable.Columns["PROCESADO_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO_EIR = (string)row[dataColumn];
			// Column "INTERCAMBIO_EQUIPO_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPO_ID = (decimal)row[dataColumn];
			// Column "PRECINTO_1_EIR"
			dataColumn = dataTable.Columns["PRECINTO_1_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1_EIR = (string)row[dataColumn];
			// Column "PRECINTO_2_EIR"
			dataColumn = dataTable.Columns["PRECINTO_2_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2_EIR = (string)row[dataColumn];
			// Column "PRECINTO_3_EIR"
			dataColumn = dataTable.Columns["PRECINTO_3_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3_EIR = (string)row[dataColumn];
			// Column "PRECINTO_4_EIR"
			dataColumn = dataTable.Columns["PRECINTO_4_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4_EIR = (string)row[dataColumn];
			// Column "PRECINTO_5_EIR"
			dataColumn = dataTable.Columns["PRECINTO_5_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5_EIR = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE_EIR"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE_EIR = (string)row[dataColumn];
			// Column "DESCARTADO"
			dataColumn = dataTable.Columns["DESCARTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCARTADO = (string)row[dataColumn];
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
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "EIR_REFRIGERADO"
			dataColumn = dataTable.Columns["EIR_REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_REFRIGERADO = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			// Column "DANO_INFORMADO"
			dataColumn = dataTable.Columns["DANO_INFORMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANO_INFORMADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONOCIMIENTOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONOCIMIENTOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SET_POINT", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PESO_MANIFIESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VACIAMIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TRASLADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SERVICIO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FCL_LCL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES_CONCIMIENTO", typeof(string));
			dataColumn.MaxLength = 400;
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
			dataColumn = dataTable.Columns.Add("INGRESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CATEGORIA_IMO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LINEAS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONOCIMIENTOS_CONTENIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAYLOAD_EIR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_EIR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("HORA_EIR", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES_EIR", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("TEMPERATURA_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("EDI_ANULADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("EDI_ARMADOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PROCESADO_EIR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECINTO_1_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_2_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_3_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_4_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_5_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("DESCARTADO", typeof(string));
			dataColumn.MaxLength = 1;
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
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DANO_INFORMADO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "CONOCIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SET_POINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_MANIFIESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VACIAMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TRASLADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SERVICIO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FCL_LCL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES_CONCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "INGRESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CATEGORIA_IMO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEAS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTOS_CONTENIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAYLOAD_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HORA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEMPERATURA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EDI":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDI_ANULADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDI_ARMADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROCESADO_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERCAMBIO_EQUIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECINTO_1_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCARTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EIR_REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DANO_INFORMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONOCIMIENTOS_DETALLESCollection_Base class
}  // End of namespace
