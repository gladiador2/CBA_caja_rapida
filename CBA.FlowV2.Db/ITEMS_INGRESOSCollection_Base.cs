// <fileinfo name="ITEMS_INGRESOSCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_HORAColumnName = "FECHA_HORA";
		public const string MIC_DTAColumnName = "MIC_DTA";
		public const string COMPROBANTEColumnName = "COMPROBANTE";
		public const string ORIGENColumnName = "ORIGEN";
		public const string FCL_LCLColumnName = "FCL_LCL";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string TIPO_CAMION_IDColumnName = "TIPO_CAMION_ID";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string TARA_CARRETAColumnName = "TARA_CARRETA";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string PESO_MANIFESTADOColumnName = "PESO_MANIFESTADO";
		public const string TOLERANCIAColumnName = "TOLERANCIA";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string DIFERENCIAColumnName = "DIFERENCIA";
		public const string VALOR_NETOColumnName = "VALOR_NETO";
		public const string VALOR_MONEDA_IDColumnName = "VALOR_MONEDA_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string SEMANAColumnName = "SEMANA";
		public const string NOTIFICADOColumnName = "NOTIFICADO";
		public const string OBSERVACION_NOTIFICACIONColumnName = "OBSERVACION_NOTIFICACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public virtual ITEMS_INGRESOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public ITEMS_INGRESOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public virtual ITEMS_INGRESOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_INGRESOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_INGRESOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_INGRESOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public ITEMS_INGRESOSRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public virtual ITEMS_INGRESOSRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
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
		/// return records by the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
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
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public ITEMS_INGRESOSRow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public virtual ITEMS_INGRESOSRow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return MapRecords(CreateGetByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSPORTADORA_PERSONA_IDAsDataTable(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_IDAsDataTable(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSPORTADORA_PERSONA_IDAsDataTable(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSPORTADORA_PERSONA_IDCommand(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			string whereSql = "";
			if(transportadora_persona_idNull)
				whereSql += "TRANSPORTADORA_PERSONA_ID IS NULL";
			else
				whereSql += "TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transportadora_persona_idNull)
				AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID", transportadora_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public ITEMS_INGRESOSRow[] GetByVALOR_MONEDA_ID(decimal valor_moneda_id)
		{
			return GetByVALOR_MONEDA_ID(valor_moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOSRow"/> objects 
		/// by the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		public virtual ITEMS_INGRESOSRow[] GetByVALOR_MONEDA_ID(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return MapRecords(CreateGetByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVALOR_MONEDA_IDAsDataTable(decimal valor_moneda_id)
		{
			return GetByVALOR_MONEDA_IDAsDataTable(valor_moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVALOR_MONEDA_IDAsDataTable(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVALOR_MONEDA_IDCommand(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			string whereSql = "";
			if(valor_moneda_idNull)
				whereSql += "VALOR_MONEDA_ID IS NULL";
			else
				whereSql += "VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!valor_moneda_idNull)
				AddParameter(cmd, "VALOR_MONEDA_ID", valor_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOSRow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_INGRESOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_INGRESOS (" +
				"ID, " +
				"FECHA_HORA, " +
				"MIC_DTA, " +
				"COMPROBANTE, " +
				"ORIGEN, " +
				"FCL_LCL, " +
				"TRANSPORTADORA_PERSONA_ID, " +
				"TRANSPORTADORA_NOMBRE, " +
				"CHAPA_CAMION, " +
				"CHAPA_CARRETA, " +
				"TIPO_CAMION_ID, " +
				"TARA_CAMION, " +
				"TARA_CARRETA, " +
				"CHOFER_NOMBRE, " +
				"CHOFER_DOCUMENTO, " +
				"PESO_MANIFESTADO, " +
				"TOLERANCIA, " +
				"PESO_BRUTO, " +
				"TARA_CONTENEDOR, " +
				"PESO_NETO, " +
				"DIFERENCIA, " +
				"VALOR_NETO, " +
				"VALOR_MONEDA_ID, " +
				"CONTENEDOR_ID, " +
				"CONFIRMADO, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"PRECINTO_VENTILETE, " +
				"OBSERVACIONES, " +
				"SEMANA, " +
				"NOTIFICADO, " +
				"OBSERVACION_NOTIFICACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_HORA") + ", " +
				_db.CreateSqlParameterName("MIC_DTA") + ", " +
				_db.CreateSqlParameterName("COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("ORIGEN") + ", " +
				_db.CreateSqlParameterName("FCL_LCL") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				_db.CreateSqlParameterName("TIPO_CAMION_ID") + ", " +
				_db.CreateSqlParameterName("TARA_CAMION") + ", " +
				_db.CreateSqlParameterName("TARA_CARRETA") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("PESO_MANIFESTADO") + ", " +
				_db.CreateSqlParameterName("TOLERANCIA") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PESO_NETO") + ", " +
				_db.CreateSqlParameterName("DIFERENCIA") + ", " +
				_db.CreateSqlParameterName("VALOR_NETO") + ", " +
				_db.CreateSqlParameterName("VALOR_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("SEMANA") + ", " +
				_db.CreateSqlParameterName("NOTIFICADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_NOTIFICACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_HORA",
				value.IsFECHA_HORANull ? DBNull.Value : (object)value.FECHA_HORA);
			AddParameter(cmd, "MIC_DTA", value.MIC_DTA);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "ORIGEN", value.ORIGEN);
			AddParameter(cmd, "FCL_LCL", value.FCL_LCL);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "TIPO_CAMION_ID",
				value.IsTIPO_CAMION_IDNull ? DBNull.Value : (object)value.TIPO_CAMION_ID);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "TARA_CARRETA",
				value.IsTARA_CARRETANull ? DBNull.Value : (object)value.TARA_CARRETA);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "PESO_MANIFESTADO",
				value.IsPESO_MANIFESTADONull ? DBNull.Value : (object)value.PESO_MANIFESTADO);
			AddParameter(cmd, "TOLERANCIA",
				value.IsTOLERANCIANull ? DBNull.Value : (object)value.TOLERANCIA);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "DIFERENCIA",
				value.IsDIFERENCIANull ? DBNull.Value : (object)value.DIFERENCIA);
			AddParameter(cmd, "VALOR_NETO",
				value.IsVALOR_NETONull ? DBNull.Value : (object)value.VALOR_NETO);
			AddParameter(cmd, "VALOR_MONEDA_ID",
				value.IsVALOR_MONEDA_IDNull ? DBNull.Value : (object)value.VALOR_MONEDA_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "NOTIFICADO", value.NOTIFICADO);
			AddParameter(cmd, "OBSERVACION_NOTIFICACION", value.OBSERVACION_NOTIFICACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_INGRESOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_INGRESOS SET " +
				"FECHA_HORA=" + _db.CreateSqlParameterName("FECHA_HORA") + ", " +
				"MIC_DTA=" + _db.CreateSqlParameterName("MIC_DTA") + ", " +
				"COMPROBANTE=" + _db.CreateSqlParameterName("COMPROBANTE") + ", " +
				"ORIGEN=" + _db.CreateSqlParameterName("ORIGEN") + ", " +
				"FCL_LCL=" + _db.CreateSqlParameterName("FCL_LCL") + ", " +
				"TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				"TRANSPORTADORA_NOMBRE=" + _db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHAPA_CARRETA=" + _db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				"TIPO_CAMION_ID=" + _db.CreateSqlParameterName("TIPO_CAMION_ID") + ", " +
				"TARA_CAMION=" + _db.CreateSqlParameterName("TARA_CAMION") + ", " +
				"TARA_CARRETA=" + _db.CreateSqlParameterName("TARA_CARRETA") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"PESO_MANIFESTADO=" + _db.CreateSqlParameterName("PESO_MANIFESTADO") + ", " +
				"TOLERANCIA=" + _db.CreateSqlParameterName("TOLERANCIA") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"TARA_CONTENEDOR=" + _db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				"PESO_NETO=" + _db.CreateSqlParameterName("PESO_NETO") + ", " +
				"DIFERENCIA=" + _db.CreateSqlParameterName("DIFERENCIA") + ", " +
				"VALOR_NETO=" + _db.CreateSqlParameterName("VALOR_NETO") + ", " +
				"VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"CONFIRMADO=" + _db.CreateSqlParameterName("CONFIRMADO") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"SEMANA=" + _db.CreateSqlParameterName("SEMANA") + ", " +
				"NOTIFICADO=" + _db.CreateSqlParameterName("NOTIFICADO") + ", " +
				"OBSERVACION_NOTIFICACION=" + _db.CreateSqlParameterName("OBSERVACION_NOTIFICACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_HORA",
				value.IsFECHA_HORANull ? DBNull.Value : (object)value.FECHA_HORA);
			AddParameter(cmd, "MIC_DTA", value.MIC_DTA);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "ORIGEN", value.ORIGEN);
			AddParameter(cmd, "FCL_LCL", value.FCL_LCL);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "TIPO_CAMION_ID",
				value.IsTIPO_CAMION_IDNull ? DBNull.Value : (object)value.TIPO_CAMION_ID);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "TARA_CARRETA",
				value.IsTARA_CARRETANull ? DBNull.Value : (object)value.TARA_CARRETA);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "PESO_MANIFESTADO",
				value.IsPESO_MANIFESTADONull ? DBNull.Value : (object)value.PESO_MANIFESTADO);
			AddParameter(cmd, "TOLERANCIA",
				value.IsTOLERANCIANull ? DBNull.Value : (object)value.TOLERANCIA);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "DIFERENCIA",
				value.IsDIFERENCIANull ? DBNull.Value : (object)value.DIFERENCIA);
			AddParameter(cmd, "VALOR_NETO",
				value.IsVALOR_NETONull ? DBNull.Value : (object)value.VALOR_NETO);
			AddParameter(cmd, "VALOR_MONEDA_ID",
				value.IsVALOR_MONEDA_IDNull ? DBNull.Value : (object)value.VALOR_MONEDA_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "NOTIFICADO", value.NOTIFICADO);
			AddParameter(cmd, "OBSERVACION_NOTIFICACION", value.OBSERVACION_NOTIFICACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_INGRESOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_INGRESOS</c> table using
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
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
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
		/// delete records using the <c>FK_ITEM_ING_CONTENEDOR_ID</c> foreign key.
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
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return DeleteByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return CreateDeleteByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEM_ING_TRANS_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSPORTADORA_PERSONA_IDCommand(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			string whereSql = "";
			if(transportadora_persona_idNull)
				whereSql += "TRANSPORTADORA_PERSONA_ID IS NULL";
			else
				whereSql += "TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transportadora_persona_idNull)
				AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID", transportadora_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVALOR_MONEDA_ID(decimal valor_moneda_id)
		{
			return DeleteByVALOR_MONEDA_ID(valor_moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS</c> table using the 
		/// <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVALOR_MONEDA_ID(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return CreateDeleteByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEM_ING_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVALOR_MONEDA_IDCommand(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			string whereSql = "";
			if(valor_moneda_idNull)
				whereSql += "VALOR_MONEDA_ID IS NULL";
			else
				whereSql += "VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!valor_moneda_idNull)
				AddParameter(cmd, "VALOR_MONEDA_ID", valor_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_INGRESOS</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_INGRESOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_INGRESOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_INGRESOS</c> table.
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
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		protected ITEMS_INGRESOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		protected ITEMS_INGRESOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOSRow"/> objects.</returns>
		protected virtual ITEMS_INGRESOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_horaColumnIndex = reader.GetOrdinal("FECHA_HORA");
			int mic_dtaColumnIndex = reader.GetOrdinal("MIC_DTA");
			int comprobanteColumnIndex = reader.GetOrdinal("COMPROBANTE");
			int origenColumnIndex = reader.GetOrdinal("ORIGEN");
			int fcl_lclColumnIndex = reader.GetOrdinal("FCL_LCL");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int tipo_camion_idColumnIndex = reader.GetOrdinal("TIPO_CAMION_ID");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int tara_carretaColumnIndex = reader.GetOrdinal("TARA_CARRETA");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int peso_manifestadoColumnIndex = reader.GetOrdinal("PESO_MANIFESTADO");
			int toleranciaColumnIndex = reader.GetOrdinal("TOLERANCIA");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int diferenciaColumnIndex = reader.GetOrdinal("DIFERENCIA");
			int valor_netoColumnIndex = reader.GetOrdinal("VALOR_NETO");
			int valor_moneda_idColumnIndex = reader.GetOrdinal("VALOR_MONEDA_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int notificadoColumnIndex = reader.GetOrdinal("NOTIFICADO");
			int observacion_notificacionColumnIndex = reader.GetOrdinal("OBSERVACION_NOTIFICACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESOSRow record = new ITEMS_INGRESOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_horaColumnIndex))
						record.FECHA_HORA = Convert.ToDateTime(reader.GetValue(fecha_horaColumnIndex));
					if(!reader.IsDBNull(mic_dtaColumnIndex))
						record.MIC_DTA = Convert.ToString(reader.GetValue(mic_dtaColumnIndex));
					if(!reader.IsDBNull(comprobanteColumnIndex))
						record.COMPROBANTE = Convert.ToString(reader.GetValue(comprobanteColumnIndex));
					if(!reader.IsDBNull(origenColumnIndex))
						record.ORIGEN = Convert.ToString(reader.GetValue(origenColumnIndex));
					if(!reader.IsDBNull(fcl_lclColumnIndex))
						record.FCL_LCL = Convert.ToString(reader.GetValue(fcl_lclColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(tipo_camion_idColumnIndex))
						record.TIPO_CAMION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_camion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(tara_carretaColumnIndex))
						record.TARA_CARRETA = Math.Round(Convert.ToDecimal(reader.GetValue(tara_carretaColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(peso_manifestadoColumnIndex))
						record.PESO_MANIFESTADO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_manifestadoColumnIndex)), 9);
					if(!reader.IsDBNull(toleranciaColumnIndex))
						record.TOLERANCIA = Math.Round(Convert.ToDecimal(reader.GetValue(toleranciaColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(diferenciaColumnIndex))
						record.DIFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(diferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(valor_netoColumnIndex))
						record.VALOR_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_netoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_moneda_idColumnIndex))
						record.VALOR_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(valor_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(confirmadoColumnIndex))
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
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(notificadoColumnIndex))
						record.NOTIFICADO = Convert.ToString(reader.GetValue(notificadoColumnIndex));
					if(!reader.IsDBNull(observacion_notificacionColumnIndex))
						record.OBSERVACION_NOTIFICACION = Convert.ToString(reader.GetValue(observacion_notificacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESOSRow[])(recordList.ToArray(typeof(ITEMS_INGRESOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESOSRow"/> object.</returns>
		protected virtual ITEMS_INGRESOSRow MapRow(DataRow row)
		{
			ITEMS_INGRESOSRow mappedObject = new ITEMS_INGRESOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_HORA"
			dataColumn = dataTable.Columns["FECHA_HORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HORA = (System.DateTime)row[dataColumn];
			// Column "MIC_DTA"
			dataColumn = dataTable.Columns["MIC_DTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MIC_DTA = (string)row[dataColumn];
			// Column "COMPROBANTE"
			dataColumn = dataTable.Columns["COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE = (string)row[dataColumn];
			// Column "ORIGEN"
			dataColumn = dataTable.Columns["ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORIGEN = (string)row[dataColumn];
			// Column "FCL_LCL"
			dataColumn = dataTable.Columns["FCL_LCL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FCL_LCL = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "TIPO_CAMION_ID"
			dataColumn = dataTable.Columns["TIPO_CAMION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_ID = (decimal)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "TARA_CARRETA"
			dataColumn = dataTable.Columns["TARA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CARRETA = (decimal)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "PESO_MANIFESTADO"
			dataColumn = dataTable.Columns["PESO_MANIFESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MANIFESTADO = (decimal)row[dataColumn];
			// Column "TOLERANCIA"
			dataColumn = dataTable.Columns["TOLERANCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOLERANCIA = (decimal)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "DIFERENCIA"
			dataColumn = dataTable.Columns["DIFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIFERENCIA = (decimal)row[dataColumn];
			// Column "VALOR_NETO"
			dataColumn = dataTable.Columns["VALOR_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_NETO = (decimal)row[dataColumn];
			// Column "VALOR_MONEDA_ID"
			dataColumn = dataTable.Columns["VALOR_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MONEDA_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
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
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "NOTIFICADO"
			dataColumn = dataTable.Columns["NOTIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTIFICADO = (string)row[dataColumn];
			// Column "OBSERVACION_NOTIFICACION"
			dataColumn = dataTable.Columns["OBSERVACION_NOTIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_NOTIFICACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_HORA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MIC_DTA", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("ORIGEN", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("FCL_LCL", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CARRETA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn = dataTable.Columns.Add("PESO_MANIFESTADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOLERANCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIFERENCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOTIFICADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACION_NOTIFICACION", typeof(string));
			dataColumn.MaxLength = 2000;
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

				case "FECHA_HORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MIC_DTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FCL_LCL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CAMION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_MANIFESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOLERANCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION_NOTIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESOSCollection_Base class
}  // End of namespace
