// <fileinfo name="PRE_EMBARQUE_CONTENEDORCollection_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUE_CONTENEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRE_EMBARQUE_CONTENEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUE_CONTENEDORCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRE_EMBARQUE_DETALLE_IDColumnName = "PRE_EMBARQUE_DETALLE_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string TAMANOColumnName = "TAMANO";
		public const string CAPACIDADColumnName = "CAPACIDAD";
		public const string PESO_MAXIMOColumnName = "PESO_MAXIMO";
		public const string TIPOColumnName = "TIPO";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string AGENCIA_IDColumnName = "AGENCIA_ID";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string BOOKINGColumnName = "BOOKING";
		public const string CARTA_DE_FRIOColumnName = "CARTA_DE_FRIO";
		public const string SET_POINTColumnName = "SET_POINT";
		public const string IMO_IDColumnName = "IMO_ID";
		public const string PRECINTO1ColumnName = "PRECINTO1";
		public const string PRECINTO2ColumnName = "PRECINTO2";
		public const string PRECINTO3ColumnName = "PRECINTO3";
		public const string PRECINTO4ColumnName = "PRECINTO4";
		public const string PRECINTO5ColumnName = "PRECINTO5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string INTERCAMBIO_EQUIPO_IDColumnName = "INTERCAMBIO_EQUIPO_ID";
		public const string PAYLOAD_EIRColumnName = "PAYLOAD_EIR";
		public const string TARA_EIRColumnName = "TARA_EIR";
		public const string TEMPERATURA_EIRColumnName = "TEMPERATURA_EIR";
		public const string HORA_EIRColumnName = "HORA_EIR";
		public const string PROCESADO_EIRColumnName = "PROCESADO_EIR";
		public const string SALIDOColumnName = "SALIDO";
		public const string EDIColumnName = "EDI";
		public const string EDI_ANULADOColumnName = "EDI_ANULADO";
		public const string EDI_ARMADORColumnName = "EDI_ARMADOR";
		public const string PRECINTO_1_EIRColumnName = "PRECINTO_1_EIR";
		public const string PRECINTO_2_EIRColumnName = "PRECINTO_2_EIR";
		public const string PRECINTO_3_EIRColumnName = "PRECINTO_3_EIR";
		public const string PRECINTO_4_EIRColumnName = "PRECINTO_4_EIR";
		public const string PRECINTO_5_EIRColumnName = "PRECINTO_5_EIR";
		public const string PRECINTO_VENTILETE_EIRColumnName = "PRECINTO_VENTILETE_EIR";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string OBSERVACIONES_EIRColumnName = "OBSERVACIONES_EIR";
		public const string DESCARTADOColumnName = "DESCARTADO";
		public const string ESTADO_CONTENEDORColumnName = "ESTADO_CONTENEDOR";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string DESPACHO_FECHAColumnName = "DESPACHO_FECHA";
		public const string FACTURA_NUMEROColumnName = "FACTURA_NUMERO";
		public const string DESPACHO_NUMEROColumnName = "DESPACHO_NUMERO";
		public const string DANADOColumnName = "DANADO";
		public const string DANO_INFORMADOColumnName = "DANO_INFORMADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUE_CONTENEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRE_EMBARQUE_CONTENEDORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRE_EMBARQUE_CONTENEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRE_EMBARQUE_CONTENEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRE_EMBARQUE_CONTENEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PRE_EMBARQUE_CONTENEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PRE_EMBARQUE_CONTENEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetByAGENCIA_ID(decimal agencia_id)
		{
			return GetByAGENCIA_ID(agencia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByAGENCIA_ID(decimal agencia_id, bool agencia_idNull)
		{
			return MapRecords(CreateGetByAGENCIA_IDCommand(agencia_id, agencia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAGENCIA_IDAsDataTable(decimal agencia_id)
		{
			return GetByAGENCIA_IDAsDataTable(agencia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAGENCIA_IDAsDataTable(decimal agencia_id, bool agencia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAGENCIA_IDCommand(agencia_id, agencia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAGENCIA_IDCommand(decimal agencia_id, bool agencia_idNull)
		{
			string whereSql = "";
			if(agencia_idNull)
				whereSql += "AGENCIA_ID IS NULL";
			else
				whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!agencia_idNull)
				AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
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
		/// return records by the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <param name="intercambio_equipo_idNull">true if the method ignores the intercambio_equipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id, bool intercambio_equipo_idNull)
		{
			return MapRecords(CreateGetByINTERCAMBIO_EQUIPO_IDCommand(intercambio_equipo_id, intercambio_equipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINTERCAMBIO_EQUIPO_IDAsDataTable(decimal intercambio_equipo_id)
		{
			return GetByINTERCAMBIO_EQUIPO_IDAsDataTable(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
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
		/// return records by the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetByLINEA_ID(decimal linea_id)
		{
			return GetByLINEA_ID(linea_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByLINEA_ID(decimal linea_id, bool linea_idNull)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id, linea_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return GetByLINEA_IDAsDataTable(linea_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id, bool linea_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id, linea_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_IDCommand(decimal linea_id, bool linea_idNull)
		{
			string whereSql = "";
			if(linea_idNull)
				whereSql += "LINEA_ID IS NULL";
			else
				whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!linea_idNull)
				AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_PR_EM_DE_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_detalle_id">The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByPRE_EMBARQUE_DETALLE_ID(decimal pre_embarque_detalle_id)
		{
			return MapRecords(CreateGetByPRE_EMBARQUE_DETALLE_IDCommand(pre_embarque_detalle_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_PR_EM_DE_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_detalle_id">The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRE_EMBARQUE_DETALLE_IDAsDataTable(decimal pre_embarque_detalle_id)
		{
			return MapRecordsToDataTable(CreateGetByPRE_EMBARQUE_DETALLE_IDCommand(pre_embarque_detalle_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRE_EMBARQUE_CO_PR_EM_DE_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_detalle_id">The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRE_EMBARQUE_DETALLE_IDCommand(decimal pre_embarque_detalle_id)
		{
			string whereSql = "";
			whereSql += "PRE_EMBARQUE_DETALLE_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PRE_EMBARQUE_DETALLE_ID", pre_embarque_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public PRE_EMBARQUE_CONTENEDORRow[] GetByPUERTO_ID(decimal puerto_id)
		{
			return GetByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_CONTENEDORRow[] GetByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecords(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id)
		{
			return GetByPUERTO_IDAsDataTable(puerto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
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
		/// return records by the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
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
		/// Adds a new record into the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUE_CONTENEDORRow"/> object to be inserted.</param>
		public virtual void Insert(PRE_EMBARQUE_CONTENEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PRE_EMBARQUE_CONTENEDOR (" +
				"ID, " +
				"PRE_EMBARQUE_DETALLE_ID, " +
				"CONTENEDOR_ID, " +
				"TAMANO, " +
				"CAPACIDAD, " +
				"PESO_MAXIMO, " +
				"TIPO, " +
				"LINEA_ID, " +
				"AGENCIA_ID, " +
				"MERCADERIA, " +
				"CANTIDAD, " +
				"BOOKING, " +
				"CARTA_DE_FRIO, " +
				"SET_POINT, " +
				"IMO_ID, " +
				"PRECINTO1, " +
				"PRECINTO2, " +
				"PRECINTO3, " +
				"PRECINTO4, " +
				"PRECINTO5, " +
				"PRECINTO_VENTILETE, " +
				"INTERCAMBIO_EQUIPO_ID, " +
				"PAYLOAD_EIR, " +
				"TARA_EIR, " +
				"TEMPERATURA_EIR, " +
				"HORA_EIR, " +
				"PROCESADO_EIR, " +
				"SALIDO, " +
				"EDI, " +
				"EDI_ANULADO, " +
				"EDI_ARMADOR, " +
				"PRECINTO_1_EIR, " +
				"PRECINTO_2_EIR, " +
				"PRECINTO_3_EIR, " +
				"PRECINTO_4_EIR, " +
				"PRECINTO_5_EIR, " +
				"PRECINTO_VENTILETE_EIR, " +
				"EIR_PISO, " +
				"EIR_FONDO, " +
				"EIR_TECHO, " +
				"EIR_PANEL_DERECHO, " +
				"EIR_PANEL_IZQUIERDO, " +
				"EIR_PUERTA, " +
				"OBSERVACIONES_EIR, " +
				"DESCARTADO, " +
				"ESTADO_CONTENEDOR, " +
				"PUERTO_ID, " +
				"EIR_REFRIGERADO, " +
				"DESPACHO_FECHA, " +
				"FACTURA_NUMERO, " +
				"DESPACHO_NUMERO, " +
				"DANADO, " +
				"DANO_INFORMADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PRE_EMBARQUE_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("TAMANO") + ", " +
				_db.CreateSqlParameterName("CAPACIDAD") + ", " +
				_db.CreateSqlParameterName("PESO_MAXIMO") + ", " +
				_db.CreateSqlParameterName("TIPO") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				_db.CreateSqlParameterName("MERCADERIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("BOOKING") + ", " +
				_db.CreateSqlParameterName("CARTA_DE_FRIO") + ", " +
				_db.CreateSqlParameterName("SET_POINT") + ", " +
				_db.CreateSqlParameterName("IMO_ID") + ", " +
				_db.CreateSqlParameterName("PRECINTO1") + ", " +
				_db.CreateSqlParameterName("PRECINTO2") + ", " +
				_db.CreateSqlParameterName("PRECINTO3") + ", " +
				_db.CreateSqlParameterName("PRECINTO4") + ", " +
				_db.CreateSqlParameterName("PRECINTO5") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				_db.CreateSqlParameterName("PAYLOAD_EIR") + ", " +
				_db.CreateSqlParameterName("TARA_EIR") + ", " +
				_db.CreateSqlParameterName("TEMPERATURA_EIR") + ", " +
				_db.CreateSqlParameterName("HORA_EIR") + ", " +
				_db.CreateSqlParameterName("PROCESADO_EIR") + ", " +
				_db.CreateSqlParameterName("SALIDO") + ", " +
				_db.CreateSqlParameterName("EDI") + ", " +
				_db.CreateSqlParameterName("EDI_ANULADO") + ", " +
				_db.CreateSqlParameterName("EDI_ARMADOR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5_EIR") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE_EIR") + ", " +
				_db.CreateSqlParameterName("EIR_PISO") + ", " +
				_db.CreateSqlParameterName("EIR_FONDO") + ", " +
				_db.CreateSqlParameterName("EIR_TECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				_db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				_db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES_EIR") + ", " +
				_db.CreateSqlParameterName("DESCARTADO") + ", " +
				_db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PUERTO_ID") + ", " +
				_db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				_db.CreateSqlParameterName("DESPACHO_FECHA") + ", " +
				_db.CreateSqlParameterName("FACTURA_NUMERO") + ", " +
				_db.CreateSqlParameterName("DESPACHO_NUMERO") + ", " +
				_db.CreateSqlParameterName("DANADO") + ", " +
				_db.CreateSqlParameterName("DANO_INFORMADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PRE_EMBARQUE_DETALLE_ID", value.PRE_EMBARQUE_DETALLE_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "TAMANO",
				value.IsTAMANONull ? DBNull.Value : (object)value.TAMANO);
			AddParameter(cmd, "CAPACIDAD",
				value.IsCAPACIDADNull ? DBNull.Value : (object)value.CAPACIDAD);
			AddParameter(cmd, "PESO_MAXIMO",
				value.IsPESO_MAXIMONull ? DBNull.Value : (object)value.PESO_MAXIMO);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "LINEA_ID",
				value.IsLINEA_IDNull ? DBNull.Value : (object)value.LINEA_ID);
			AddParameter(cmd, "AGENCIA_ID",
				value.IsAGENCIA_IDNull ? DBNull.Value : (object)value.AGENCIA_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CARTA_DE_FRIO", value.CARTA_DE_FRIO);
			AddParameter(cmd, "SET_POINT", value.SET_POINT);
			AddParameter(cmd, "IMO_ID",
				value.IsIMO_IDNull ? DBNull.Value : (object)value.IMO_ID);
			AddParameter(cmd, "PRECINTO1", value.PRECINTO1);
			AddParameter(cmd, "PRECINTO2", value.PRECINTO2);
			AddParameter(cmd, "PRECINTO3", value.PRECINTO3);
			AddParameter(cmd, "PRECINTO4", value.PRECINTO4);
			AddParameter(cmd, "PRECINTO5", value.PRECINTO5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PAYLOAD_EIR",
				value.IsPAYLOAD_EIRNull ? DBNull.Value : (object)value.PAYLOAD_EIR);
			AddParameter(cmd, "TARA_EIR",
				value.IsTARA_EIRNull ? DBNull.Value : (object)value.TARA_EIR);
			AddParameter(cmd, "TEMPERATURA_EIR",
				value.IsTEMPERATURA_EIRNull ? DBNull.Value : (object)value.TEMPERATURA_EIR);
			AddParameter(cmd, "HORA_EIR",
				value.IsHORA_EIRNull ? DBNull.Value : (object)value.HORA_EIR);
			AddParameter(cmd, "PROCESADO_EIR", value.PROCESADO_EIR);
			AddParameter(cmd, "SALIDO", value.SALIDO);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "EDI_ANULADO", value.EDI_ANULADO);
			AddParameter(cmd, "EDI_ARMADOR", value.EDI_ARMADOR);
			AddParameter(cmd, "PRECINTO_1_EIR", value.PRECINTO_1_EIR);
			AddParameter(cmd, "PRECINTO_2_EIR", value.PRECINTO_2_EIR);
			AddParameter(cmd, "PRECINTO_3_EIR", value.PRECINTO_3_EIR);
			AddParameter(cmd, "PRECINTO_4_EIR", value.PRECINTO_4_EIR);
			AddParameter(cmd, "PRECINTO_5_EIR", value.PRECINTO_5_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE_EIR", value.PRECINTO_VENTILETE_EIR);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "OBSERVACIONES_EIR", value.OBSERVACIONES_EIR);
			AddParameter(cmd, "DESCARTADO", value.DESCARTADO);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "DESPACHO_FECHA",
				value.IsDESPACHO_FECHANull ? DBNull.Value : (object)value.DESPACHO_FECHA);
			AddParameter(cmd, "FACTURA_NUMERO", value.FACTURA_NUMERO);
			AddParameter(cmd, "DESPACHO_NUMERO", value.DESPACHO_NUMERO);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUE_CONTENEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PRE_EMBARQUE_CONTENEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.PRE_EMBARQUE_CONTENEDOR SET " +
				"PRE_EMBARQUE_DETALLE_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_DETALLE_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"TAMANO=" + _db.CreateSqlParameterName("TAMANO") + ", " +
				"CAPACIDAD=" + _db.CreateSqlParameterName("CAPACIDAD") + ", " +
				"PESO_MAXIMO=" + _db.CreateSqlParameterName("PESO_MAXIMO") + ", " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") + ", " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				"MERCADERIA=" + _db.CreateSqlParameterName("MERCADERIA") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"BOOKING=" + _db.CreateSqlParameterName("BOOKING") + ", " +
				"CARTA_DE_FRIO=" + _db.CreateSqlParameterName("CARTA_DE_FRIO") + ", " +
				"SET_POINT=" + _db.CreateSqlParameterName("SET_POINT") + ", " +
				"IMO_ID=" + _db.CreateSqlParameterName("IMO_ID") + ", " +
				"PRECINTO1=" + _db.CreateSqlParameterName("PRECINTO1") + ", " +
				"PRECINTO2=" + _db.CreateSqlParameterName("PRECINTO2") + ", " +
				"PRECINTO3=" + _db.CreateSqlParameterName("PRECINTO3") + ", " +
				"PRECINTO4=" + _db.CreateSqlParameterName("PRECINTO4") + ", " +
				"PRECINTO5=" + _db.CreateSqlParameterName("PRECINTO5") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"INTERCAMBIO_EQUIPO_ID=" + _db.CreateSqlParameterName("INTERCAMBIO_EQUIPO_ID") + ", " +
				"PAYLOAD_EIR=" + _db.CreateSqlParameterName("PAYLOAD_EIR") + ", " +
				"TARA_EIR=" + _db.CreateSqlParameterName("TARA_EIR") + ", " +
				"TEMPERATURA_EIR=" + _db.CreateSqlParameterName("TEMPERATURA_EIR") + ", " +
				"HORA_EIR=" + _db.CreateSqlParameterName("HORA_EIR") + ", " +
				"PROCESADO_EIR=" + _db.CreateSqlParameterName("PROCESADO_EIR") + ", " +
				"SALIDO=" + _db.CreateSqlParameterName("SALIDO") + ", " +
				"EDI=" + _db.CreateSqlParameterName("EDI") + ", " +
				"EDI_ANULADO=" + _db.CreateSqlParameterName("EDI_ANULADO") + ", " +
				"EDI_ARMADOR=" + _db.CreateSqlParameterName("EDI_ARMADOR") + ", " +
				"PRECINTO_1_EIR=" + _db.CreateSqlParameterName("PRECINTO_1_EIR") + ", " +
				"PRECINTO_2_EIR=" + _db.CreateSqlParameterName("PRECINTO_2_EIR") + ", " +
				"PRECINTO_3_EIR=" + _db.CreateSqlParameterName("PRECINTO_3_EIR") + ", " +
				"PRECINTO_4_EIR=" + _db.CreateSqlParameterName("PRECINTO_4_EIR") + ", " +
				"PRECINTO_5_EIR=" + _db.CreateSqlParameterName("PRECINTO_5_EIR") + ", " +
				"PRECINTO_VENTILETE_EIR=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE_EIR") + ", " +
				"EIR_PISO=" + _db.CreateSqlParameterName("EIR_PISO") + ", " +
				"EIR_FONDO=" + _db.CreateSqlParameterName("EIR_FONDO") + ", " +
				"EIR_TECHO=" + _db.CreateSqlParameterName("EIR_TECHO") + ", " +
				"EIR_PANEL_DERECHO=" + _db.CreateSqlParameterName("EIR_PANEL_DERECHO") + ", " +
				"EIR_PANEL_IZQUIERDO=" + _db.CreateSqlParameterName("EIR_PANEL_IZQUIERDO") + ", " +
				"EIR_PUERTA=" + _db.CreateSqlParameterName("EIR_PUERTA") + ", " +
				"OBSERVACIONES_EIR=" + _db.CreateSqlParameterName("OBSERVACIONES_EIR") + ", " +
				"DESCARTADO=" + _db.CreateSqlParameterName("DESCARTADO") + ", " +
				"ESTADO_CONTENEDOR=" + _db.CreateSqlParameterName("ESTADO_CONTENEDOR") + ", " +
				"PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID") + ", " +
				"EIR_REFRIGERADO=" + _db.CreateSqlParameterName("EIR_REFRIGERADO") + ", " +
				"DESPACHO_FECHA=" + _db.CreateSqlParameterName("DESPACHO_FECHA") + ", " +
				"FACTURA_NUMERO=" + _db.CreateSqlParameterName("FACTURA_NUMERO") + ", " +
				"DESPACHO_NUMERO=" + _db.CreateSqlParameterName("DESPACHO_NUMERO") + ", " +
				"DANADO=" + _db.CreateSqlParameterName("DANADO") + ", " +
				"DANO_INFORMADO=" + _db.CreateSqlParameterName("DANO_INFORMADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PRE_EMBARQUE_DETALLE_ID", value.PRE_EMBARQUE_DETALLE_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "TAMANO",
				value.IsTAMANONull ? DBNull.Value : (object)value.TAMANO);
			AddParameter(cmd, "CAPACIDAD",
				value.IsCAPACIDADNull ? DBNull.Value : (object)value.CAPACIDAD);
			AddParameter(cmd, "PESO_MAXIMO",
				value.IsPESO_MAXIMONull ? DBNull.Value : (object)value.PESO_MAXIMO);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "LINEA_ID",
				value.IsLINEA_IDNull ? DBNull.Value : (object)value.LINEA_ID);
			AddParameter(cmd, "AGENCIA_ID",
				value.IsAGENCIA_IDNull ? DBNull.Value : (object)value.AGENCIA_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CARTA_DE_FRIO", value.CARTA_DE_FRIO);
			AddParameter(cmd, "SET_POINT", value.SET_POINT);
			AddParameter(cmd, "IMO_ID",
				value.IsIMO_IDNull ? DBNull.Value : (object)value.IMO_ID);
			AddParameter(cmd, "PRECINTO1", value.PRECINTO1);
			AddParameter(cmd, "PRECINTO2", value.PRECINTO2);
			AddParameter(cmd, "PRECINTO3", value.PRECINTO3);
			AddParameter(cmd, "PRECINTO4", value.PRECINTO4);
			AddParameter(cmd, "PRECINTO5", value.PRECINTO5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "INTERCAMBIO_EQUIPO_ID",
				value.IsINTERCAMBIO_EQUIPO_IDNull ? DBNull.Value : (object)value.INTERCAMBIO_EQUIPO_ID);
			AddParameter(cmd, "PAYLOAD_EIR",
				value.IsPAYLOAD_EIRNull ? DBNull.Value : (object)value.PAYLOAD_EIR);
			AddParameter(cmd, "TARA_EIR",
				value.IsTARA_EIRNull ? DBNull.Value : (object)value.TARA_EIR);
			AddParameter(cmd, "TEMPERATURA_EIR",
				value.IsTEMPERATURA_EIRNull ? DBNull.Value : (object)value.TEMPERATURA_EIR);
			AddParameter(cmd, "HORA_EIR",
				value.IsHORA_EIRNull ? DBNull.Value : (object)value.HORA_EIR);
			AddParameter(cmd, "PROCESADO_EIR", value.PROCESADO_EIR);
			AddParameter(cmd, "SALIDO", value.SALIDO);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "EDI_ANULADO", value.EDI_ANULADO);
			AddParameter(cmd, "EDI_ARMADOR", value.EDI_ARMADOR);
			AddParameter(cmd, "PRECINTO_1_EIR", value.PRECINTO_1_EIR);
			AddParameter(cmd, "PRECINTO_2_EIR", value.PRECINTO_2_EIR);
			AddParameter(cmd, "PRECINTO_3_EIR", value.PRECINTO_3_EIR);
			AddParameter(cmd, "PRECINTO_4_EIR", value.PRECINTO_4_EIR);
			AddParameter(cmd, "PRECINTO_5_EIR", value.PRECINTO_5_EIR);
			AddParameter(cmd, "PRECINTO_VENTILETE_EIR", value.PRECINTO_VENTILETE_EIR);
			AddParameter(cmd, "EIR_PISO", value.EIR_PISO);
			AddParameter(cmd, "EIR_FONDO", value.EIR_FONDO);
			AddParameter(cmd, "EIR_TECHO", value.EIR_TECHO);
			AddParameter(cmd, "EIR_PANEL_DERECHO", value.EIR_PANEL_DERECHO);
			AddParameter(cmd, "EIR_PANEL_IZQUIERDO", value.EIR_PANEL_IZQUIERDO);
			AddParameter(cmd, "EIR_PUERTA", value.EIR_PUERTA);
			AddParameter(cmd, "OBSERVACIONES_EIR", value.OBSERVACIONES_EIR);
			AddParameter(cmd, "DESCARTADO", value.DESCARTADO);
			AddParameter(cmd, "ESTADO_CONTENEDOR", value.ESTADO_CONTENEDOR);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "EIR_REFRIGERADO", value.EIR_REFRIGERADO);
			AddParameter(cmd, "DESPACHO_FECHA",
				value.IsDESPACHO_FECHANull ? DBNull.Value : (object)value.DESPACHO_FECHA);
			AddParameter(cmd, "FACTURA_NUMERO", value.FACTURA_NUMERO);
			AddParameter(cmd, "DESPACHO_NUMERO", value.DESPACHO_NUMERO);
			AddParameter(cmd, "DANADO", value.DANADO);
			AddParameter(cmd, "DANO_INFORMADO", value.DANO_INFORMADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PRE_EMBARQUE_CONTENEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PRE_EMBARQUE_CONTENEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUE_CONTENEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PRE_EMBARQUE_CONTENEDORRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using
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
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAGENCIA_ID(decimal agencia_id)
		{
			return DeleteByAGENCIA_ID(agencia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAGENCIA_ID(decimal agencia_id, bool agencia_idNull)
		{
			return CreateDeleteByAGENCIA_IDCommand(agencia_id, agencia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAGENCIA_IDCommand(decimal agencia_id, bool agencia_idNull)
		{
			string whereSql = "";
			if(agencia_idNull)
				whereSql += "AGENCIA_ID IS NULL";
			else
				whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!agencia_idNull)
				AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_CONTENED_ID</c> foreign key.
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
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
		/// </summary>
		/// <param name="intercambio_equipo_id">The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINTERCAMBIO_EQUIPO_ID(decimal intercambio_equipo_id)
		{
			return DeleteByINTERCAMBIO_EQUIPO_ID(intercambio_equipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_INTER_EQ_ID</c> foreign key.
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
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return DeleteByLINEA_ID(linea_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id, bool linea_idNull)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id, linea_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_IDCommand(decimal linea_id, bool linea_idNull)
		{
			string whereSql = "";
			if(linea_idNull)
				whereSql += "LINEA_ID IS NULL";
			else
				whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!linea_idNull)
				AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_PR_EM_DE_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_detalle_id">The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRE_EMBARQUE_DETALLE_ID(decimal pre_embarque_detalle_id)
		{
			return CreateDeleteByPRE_EMBARQUE_DETALLE_IDCommand(pre_embarque_detalle_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_PR_EM_DE_ID</c> foreign key.
		/// </summary>
		/// <param name="pre_embarque_detalle_id">The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRE_EMBARQUE_DETALLE_IDCommand(decimal pre_embarque_detalle_id)
		{
			string whereSql = "";
			whereSql += "PRE_EMBARQUE_DETALLE_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PRE_EMBARQUE_DETALLE_ID", pre_embarque_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id)
		{
			return DeleteByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table using the 
		/// <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRE_EMBARQUE_CO_PUERTO_ID</c> foreign key.
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
		/// Deletes <c>PRE_EMBARQUE_CONTENEDOR</c> records that match the specified criteria.
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
		/// to delete <c>PRE_EMBARQUE_CONTENEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PRE_EMBARQUE_CONTENEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		protected PRE_EMBARQUE_CONTENEDORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		protected PRE_EMBARQUE_CONTENEDORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_CONTENEDORRow"/> objects.</returns>
		protected virtual PRE_EMBARQUE_CONTENEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pre_embarque_detalle_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_DETALLE_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int tamanoColumnIndex = reader.GetOrdinal("TAMANO");
			int capacidadColumnIndex = reader.GetOrdinal("CAPACIDAD");
			int peso_maximoColumnIndex = reader.GetOrdinal("PESO_MAXIMO");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int agencia_idColumnIndex = reader.GetOrdinal("AGENCIA_ID");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int carta_de_frioColumnIndex = reader.GetOrdinal("CARTA_DE_FRIO");
			int set_pointColumnIndex = reader.GetOrdinal("SET_POINT");
			int imo_idColumnIndex = reader.GetOrdinal("IMO_ID");
			int precinto1ColumnIndex = reader.GetOrdinal("PRECINTO1");
			int precinto2ColumnIndex = reader.GetOrdinal("PRECINTO2");
			int precinto3ColumnIndex = reader.GetOrdinal("PRECINTO3");
			int precinto4ColumnIndex = reader.GetOrdinal("PRECINTO4");
			int precinto5ColumnIndex = reader.GetOrdinal("PRECINTO5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int intercambio_equipo_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPO_ID");
			int payload_eirColumnIndex = reader.GetOrdinal("PAYLOAD_EIR");
			int tara_eirColumnIndex = reader.GetOrdinal("TARA_EIR");
			int temperatura_eirColumnIndex = reader.GetOrdinal("TEMPERATURA_EIR");
			int hora_eirColumnIndex = reader.GetOrdinal("HORA_EIR");
			int procesado_eirColumnIndex = reader.GetOrdinal("PROCESADO_EIR");
			int salidoColumnIndex = reader.GetOrdinal("SALIDO");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int edi_anuladoColumnIndex = reader.GetOrdinal("EDI_ANULADO");
			int edi_armadorColumnIndex = reader.GetOrdinal("EDI_ARMADOR");
			int precinto_1_eirColumnIndex = reader.GetOrdinal("PRECINTO_1_EIR");
			int precinto_2_eirColumnIndex = reader.GetOrdinal("PRECINTO_2_EIR");
			int precinto_3_eirColumnIndex = reader.GetOrdinal("PRECINTO_3_EIR");
			int precinto_4_eirColumnIndex = reader.GetOrdinal("PRECINTO_4_EIR");
			int precinto_5_eirColumnIndex = reader.GetOrdinal("PRECINTO_5_EIR");
			int precinto_ventilete_eirColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE_EIR");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int observaciones_eirColumnIndex = reader.GetOrdinal("OBSERVACIONES_EIR");
			int descartadoColumnIndex = reader.GetOrdinal("DESCARTADO");
			int estado_contenedorColumnIndex = reader.GetOrdinal("ESTADO_CONTENEDOR");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int despacho_fechaColumnIndex = reader.GetOrdinal("DESPACHO_FECHA");
			int factura_numeroColumnIndex = reader.GetOrdinal("FACTURA_NUMERO");
			int despacho_numeroColumnIndex = reader.GetOrdinal("DESPACHO_NUMERO");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int dano_informadoColumnIndex = reader.GetOrdinal("DANO_INFORMADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRE_EMBARQUE_CONTENEDORRow record = new PRE_EMBARQUE_CONTENEDORRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRE_EMBARQUE_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(tamanoColumnIndex))
						record.TAMANO = Math.Round(Convert.ToDecimal(reader.GetValue(tamanoColumnIndex)), 9);
					if(!reader.IsDBNull(capacidadColumnIndex))
						record.CAPACIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(capacidadColumnIndex)), 9);
					if(!reader.IsDBNull(peso_maximoColumnIndex))
						record.PESO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_maximoColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(linea_idColumnIndex))
						record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(agencia_idColumnIndex))
						record.AGENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(agencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(carta_de_frioColumnIndex))
						record.CARTA_DE_FRIO = Convert.ToString(reader.GetValue(carta_de_frioColumnIndex));
					if(!reader.IsDBNull(set_pointColumnIndex))
						record.SET_POINT = Convert.ToString(reader.GetValue(set_pointColumnIndex));
					if(!reader.IsDBNull(imo_idColumnIndex))
						record.IMO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(imo_idColumnIndex)), 9);
					if(!reader.IsDBNull(precinto1ColumnIndex))
						record.PRECINTO1 = Convert.ToString(reader.GetValue(precinto1ColumnIndex));
					if(!reader.IsDBNull(precinto2ColumnIndex))
						record.PRECINTO2 = Convert.ToString(reader.GetValue(precinto2ColumnIndex));
					if(!reader.IsDBNull(precinto3ColumnIndex))
						record.PRECINTO3 = Convert.ToString(reader.GetValue(precinto3ColumnIndex));
					if(!reader.IsDBNull(precinto4ColumnIndex))
						record.PRECINTO4 = Convert.ToString(reader.GetValue(precinto4ColumnIndex));
					if(!reader.IsDBNull(precinto5ColumnIndex))
						record.PRECINTO5 = Convert.ToString(reader.GetValue(precinto5ColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(intercambio_equipo_idColumnIndex))
						record.INTERCAMBIO_EQUIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(payload_eirColumnIndex))
						record.PAYLOAD_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(payload_eirColumnIndex)), 9);
					if(!reader.IsDBNull(tara_eirColumnIndex))
						record.TARA_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_eirColumnIndex)), 9);
					if(!reader.IsDBNull(temperatura_eirColumnIndex))
						record.TEMPERATURA_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(temperatura_eirColumnIndex)), 9);
					if(!reader.IsDBNull(hora_eirColumnIndex))
						record.HORA_EIR = Convert.ToDateTime(reader.GetValue(hora_eirColumnIndex));
					if(!reader.IsDBNull(procesado_eirColumnIndex))
						record.PROCESADO_EIR = Convert.ToString(reader.GetValue(procesado_eirColumnIndex));
					if(!reader.IsDBNull(salidoColumnIndex))
						record.SALIDO = Convert.ToString(reader.GetValue(salidoColumnIndex));
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(edi_anuladoColumnIndex))
						record.EDI_ANULADO = Convert.ToString(reader.GetValue(edi_anuladoColumnIndex));
					if(!reader.IsDBNull(edi_armadorColumnIndex))
						record.EDI_ARMADOR = Convert.ToString(reader.GetValue(edi_armadorColumnIndex));
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
					if(!reader.IsDBNull(observaciones_eirColumnIndex))
						record.OBSERVACIONES_EIR = Convert.ToString(reader.GetValue(observaciones_eirColumnIndex));
					if(!reader.IsDBNull(descartadoColumnIndex))
						record.DESCARTADO = Convert.ToString(reader.GetValue(descartadoColumnIndex));
					if(!reader.IsDBNull(estado_contenedorColumnIndex))
						record.ESTADO_CONTENEDOR = Convert.ToString(reader.GetValue(estado_contenedorColumnIndex));
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(eir_refrigeradoColumnIndex))
						record.EIR_REFRIGERADO = Convert.ToString(reader.GetValue(eir_refrigeradoColumnIndex));
					if(!reader.IsDBNull(despacho_fechaColumnIndex))
						record.DESPACHO_FECHA = Convert.ToDateTime(reader.GetValue(despacho_fechaColumnIndex));
					if(!reader.IsDBNull(factura_numeroColumnIndex))
						record.FACTURA_NUMERO = Convert.ToString(reader.GetValue(factura_numeroColumnIndex));
					if(!reader.IsDBNull(despacho_numeroColumnIndex))
						record.DESPACHO_NUMERO = Convert.ToString(reader.GetValue(despacho_numeroColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(dano_informadoColumnIndex))
						record.DANO_INFORMADO = Convert.ToString(reader.GetValue(dano_informadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRE_EMBARQUE_CONTENEDORRow[])(recordList.ToArray(typeof(PRE_EMBARQUE_CONTENEDORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRE_EMBARQUE_CONTENEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRE_EMBARQUE_CONTENEDORRow"/> object.</returns>
		protected virtual PRE_EMBARQUE_CONTENEDORRow MapRow(DataRow row)
		{
			PRE_EMBARQUE_CONTENEDORRow mappedObject = new PRE_EMBARQUE_CONTENEDORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRE_EMBARQUE_DETALLE_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "TAMANO"
			dataColumn = dataTable.Columns["TAMANO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TAMANO = (decimal)row[dataColumn];
			// Column "CAPACIDAD"
			dataColumn = dataTable.Columns["CAPACIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPACIDAD = (decimal)row[dataColumn];
			// Column "PESO_MAXIMO"
			dataColumn = dataTable.Columns["PESO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MAXIMO = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "AGENCIA_ID"
			dataColumn = dataTable.Columns["AGENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_ID = (decimal)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "CARTA_DE_FRIO"
			dataColumn = dataTable.Columns["CARTA_DE_FRIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CARTA_DE_FRIO = (string)row[dataColumn];
			// Column "SET_POINT"
			dataColumn = dataTable.Columns["SET_POINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SET_POINT = (string)row[dataColumn];
			// Column "IMO_ID"
			dataColumn = dataTable.Columns["IMO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMO_ID = (decimal)row[dataColumn];
			// Column "PRECINTO1"
			dataColumn = dataTable.Columns["PRECINTO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO1 = (string)row[dataColumn];
			// Column "PRECINTO2"
			dataColumn = dataTable.Columns["PRECINTO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO2 = (string)row[dataColumn];
			// Column "PRECINTO3"
			dataColumn = dataTable.Columns["PRECINTO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO3 = (string)row[dataColumn];
			// Column "PRECINTO4"
			dataColumn = dataTable.Columns["PRECINTO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO4 = (string)row[dataColumn];
			// Column "PRECINTO5"
			dataColumn = dataTable.Columns["PRECINTO5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO5 = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "INTERCAMBIO_EQUIPO_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPO_ID = (decimal)row[dataColumn];
			// Column "PAYLOAD_EIR"
			dataColumn = dataTable.Columns["PAYLOAD_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAYLOAD_EIR = (decimal)row[dataColumn];
			// Column "TARA_EIR"
			dataColumn = dataTable.Columns["TARA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_EIR = (decimal)row[dataColumn];
			// Column "TEMPERATURA_EIR"
			dataColumn = dataTable.Columns["TEMPERATURA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPERATURA_EIR = (decimal)row[dataColumn];
			// Column "HORA_EIR"
			dataColumn = dataTable.Columns["HORA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_EIR = (System.DateTime)row[dataColumn];
			// Column "PROCESADO_EIR"
			dataColumn = dataTable.Columns["PROCESADO_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO_EIR = (string)row[dataColumn];
			// Column "SALIDO"
			dataColumn = dataTable.Columns["SALIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALIDO = (string)row[dataColumn];
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
			// Column "OBSERVACIONES_EIR"
			dataColumn = dataTable.Columns["OBSERVACIONES_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES_EIR = (string)row[dataColumn];
			// Column "DESCARTADO"
			dataColumn = dataTable.Columns["DESCARTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCARTADO = (string)row[dataColumn];
			// Column "ESTADO_CONTENEDOR"
			dataColumn = dataTable.Columns["ESTADO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CONTENEDOR = (string)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "EIR_REFRIGERADO"
			dataColumn = dataTable.Columns["EIR_REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_REFRIGERADO = (string)row[dataColumn];
			// Column "DESPACHO_FECHA"
			dataColumn = dataTable.Columns["DESPACHO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_NUMERO"
			dataColumn = dataTable.Columns["FACTURA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_NUMERO = (string)row[dataColumn];
			// Column "DESPACHO_NUMERO"
			dataColumn = dataTable.Columns["DESPACHO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_NUMERO = (string)row[dataColumn];
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
		/// the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRE_EMBARQUE_CONTENEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TAMANO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CAPACIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_MAXIMO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AGENCIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CARTA_DE_FRIO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("SET_POINT", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("IMO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECINTO1", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO2", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO3", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO4", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO5", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAYLOAD_EIR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_EIR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEMPERATURA_EIR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("HORA_EIR", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PROCESADO_EIR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("SALIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("EDI_ANULADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("EDI_ARMADOR", typeof(string));
			dataColumn.MaxLength = 1;
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
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES_EIR", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("DESCARTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("DESPACHO_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FACTURA_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("DESPACHO_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "PRE_EMBARQUE_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TAMANO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPACIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AGENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CARTA_DE_FRIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SET_POINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECINTO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INTERCAMBIO_EQUIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAYLOAD_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEMPERATURA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HORA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PROCESADO_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "OBSERVACIONES_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCARTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EIR_REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO_NUMERO":
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
	} // End of PRE_EMBARQUE_CONTENEDORCollection_Base class
}  // End of namespace
