// <fileinfo name="CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string ESTADOColumnName = "ESTADO";
		public const string CRED_COMISION_POS_DIAColumnName = "CRED_COMISION_POS_DIA";
		public const string DEB_COMISION_POS_DIAColumnName = "DEB_COMISION_POS_DIA";
		public const string CRED_COMISION_SOB_IMP_BRUTOColumnName = "CRED_COMISION_SOB_IMP_BRUTO";
		public const string DEB_COMISION_SOB_IMP_BRUTOColumnName = "DEB_COMISION_SOB_IMP_BRUTO";
		public const string CRED_LUNES_HORASColumnName = "CRED_LUNES_HORAS";
		public const string CRED_MARTES_HORASColumnName = "CRED_MARTES_HORAS";
		public const string CRED_MIERCOLES_HORASColumnName = "CRED_MIERCOLES_HORAS";
		public const string CRED_JUEVES_HORASColumnName = "CRED_JUEVES_HORAS";
		public const string CRED_VIERNES_HORASColumnName = "CRED_VIERNES_HORAS";
		public const string CRED_SABADO_HORASColumnName = "CRED_SABADO_HORAS";
		public const string CRED_DOMINGO_HORASColumnName = "CRED_DOMINGO_HORAS";
		public const string DEB_LUNES_HORASColumnName = "DEB_LUNES_HORAS";
		public const string DEB_MARTES_HORASColumnName = "DEB_MARTES_HORAS";
		public const string DEB_MIERCOLES_HORASColumnName = "DEB_MIERCOLES_HORAS";
		public const string DEB_JUEVES_HORASColumnName = "DEB_JUEVES_HORAS";
		public const string DEB_VIERNES_HORASColumnName = "DEB_VIERNES_HORAS";
		public const string DEB_SABADO_HORASColumnName = "DEB_SABADO_HORAS";
		public const string DEB_DOMINGO_HORASColumnName = "DEB_DOMINGO_HORAS";
		public const string CONTROLA_DIA_HABILColumnName = "CONTROLA_DIA_HABIL";
		public const string CONTROLA_FERIADO_BANCARIOColumnName = "CONTROLA_FERIADO_BANCARIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PROCESADORAS_TARJETA_ENTIDADRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		public CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PROCESADORAS_TARJETA_ENTIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETA_ENTIDADRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PROCESADORAS_TARJETA_ENTIDADRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PROCESADORAS_TARJETA_ENTIDAD (" +
				"ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"ESTADO, " +
				"CRED_COMISION_POS_DIA, " +
				"DEB_COMISION_POS_DIA, " +
				"CRED_COMISION_SOB_IMP_BRUTO, " +
				"DEB_COMISION_SOB_IMP_BRUTO, " +
				"CRED_LUNES_HORAS, " +
				"CRED_MARTES_HORAS, " +
				"CRED_MIERCOLES_HORAS, " +
				"CRED_JUEVES_HORAS, " +
				"CRED_VIERNES_HORAS, " +
				"CRED_SABADO_HORAS, " +
				"CRED_DOMINGO_HORAS, " +
				"DEB_LUNES_HORAS, " +
				"DEB_MARTES_HORAS, " +
				"DEB_MIERCOLES_HORAS, " +
				"DEB_JUEVES_HORAS, " +
				"DEB_VIERNES_HORAS, " +
				"DEB_SABADO_HORAS, " +
				"DEB_DOMINGO_HORAS, " +
				"CONTROLA_DIA_HABIL, " +
				"CONTROLA_FERIADO_BANCARIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CRED_COMISION_POS_DIA") + ", " +
				_db.CreateSqlParameterName("DEB_COMISION_POS_DIA") + ", " +
				_db.CreateSqlParameterName("CRED_COMISION_SOB_IMP_BRUTO") + ", " +
				_db.CreateSqlParameterName("DEB_COMISION_SOB_IMP_BRUTO") + ", " +
				_db.CreateSqlParameterName("CRED_LUNES_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_MARTES_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_MIERCOLES_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_JUEVES_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_VIERNES_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_SABADO_HORAS") + ", " +
				_db.CreateSqlParameterName("CRED_DOMINGO_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_LUNES_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_MARTES_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_MIERCOLES_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_JUEVES_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_VIERNES_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_SABADO_HORAS") + ", " +
				_db.CreateSqlParameterName("DEB_DOMINGO_HORAS") + ", " +
				_db.CreateSqlParameterName("CONTROLA_DIA_HABIL") + ", " +
				_db.CreateSqlParameterName("CONTROLA_FERIADO_BANCARIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CRED_COMISION_POS_DIA", value.CRED_COMISION_POS_DIA);
			AddParameter(cmd, "DEB_COMISION_POS_DIA", value.DEB_COMISION_POS_DIA);
			AddParameter(cmd, "CRED_COMISION_SOB_IMP_BRUTO", value.CRED_COMISION_SOB_IMP_BRUTO);
			AddParameter(cmd, "DEB_COMISION_SOB_IMP_BRUTO", value.DEB_COMISION_SOB_IMP_BRUTO);
			AddParameter(cmd, "CRED_LUNES_HORAS", value.CRED_LUNES_HORAS);
			AddParameter(cmd, "CRED_MARTES_HORAS", value.CRED_MARTES_HORAS);
			AddParameter(cmd, "CRED_MIERCOLES_HORAS", value.CRED_MIERCOLES_HORAS);
			AddParameter(cmd, "CRED_JUEVES_HORAS", value.CRED_JUEVES_HORAS);
			AddParameter(cmd, "CRED_VIERNES_HORAS", value.CRED_VIERNES_HORAS);
			AddParameter(cmd, "CRED_SABADO_HORAS", value.CRED_SABADO_HORAS);
			AddParameter(cmd, "CRED_DOMINGO_HORAS", value.CRED_DOMINGO_HORAS);
			AddParameter(cmd, "DEB_LUNES_HORAS", value.DEB_LUNES_HORAS);
			AddParameter(cmd, "DEB_MARTES_HORAS", value.DEB_MARTES_HORAS);
			AddParameter(cmd, "DEB_MIERCOLES_HORAS", value.DEB_MIERCOLES_HORAS);
			AddParameter(cmd, "DEB_JUEVES_HORAS", value.DEB_JUEVES_HORAS);
			AddParameter(cmd, "DEB_VIERNES_HORAS", value.DEB_VIERNES_HORAS);
			AddParameter(cmd, "DEB_SABADO_HORAS", value.DEB_SABADO_HORAS);
			AddParameter(cmd, "DEB_DOMINGO_HORAS", value.DEB_DOMINGO_HORAS);
			AddParameter(cmd, "CONTROLA_DIA_HABIL", value.CONTROLA_DIA_HABIL);
			AddParameter(cmd, "CONTROLA_FERIADO_BANCARIO", value.CONTROLA_FERIADO_BANCARIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PROCESADORAS_TARJETA_ENTIDADRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PROCESADORAS_TARJETA_ENTIDAD SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CRED_COMISION_POS_DIA=" + _db.CreateSqlParameterName("CRED_COMISION_POS_DIA") + ", " +
				"DEB_COMISION_POS_DIA=" + _db.CreateSqlParameterName("DEB_COMISION_POS_DIA") + ", " +
				"CRED_COMISION_SOB_IMP_BRUTO=" + _db.CreateSqlParameterName("CRED_COMISION_SOB_IMP_BRUTO") + ", " +
				"DEB_COMISION_SOB_IMP_BRUTO=" + _db.CreateSqlParameterName("DEB_COMISION_SOB_IMP_BRUTO") + ", " +
				"CRED_LUNES_HORAS=" + _db.CreateSqlParameterName("CRED_LUNES_HORAS") + ", " +
				"CRED_MARTES_HORAS=" + _db.CreateSqlParameterName("CRED_MARTES_HORAS") + ", " +
				"CRED_MIERCOLES_HORAS=" + _db.CreateSqlParameterName("CRED_MIERCOLES_HORAS") + ", " +
				"CRED_JUEVES_HORAS=" + _db.CreateSqlParameterName("CRED_JUEVES_HORAS") + ", " +
				"CRED_VIERNES_HORAS=" + _db.CreateSqlParameterName("CRED_VIERNES_HORAS") + ", " +
				"CRED_SABADO_HORAS=" + _db.CreateSqlParameterName("CRED_SABADO_HORAS") + ", " +
				"CRED_DOMINGO_HORAS=" + _db.CreateSqlParameterName("CRED_DOMINGO_HORAS") + ", " +
				"DEB_LUNES_HORAS=" + _db.CreateSqlParameterName("DEB_LUNES_HORAS") + ", " +
				"DEB_MARTES_HORAS=" + _db.CreateSqlParameterName("DEB_MARTES_HORAS") + ", " +
				"DEB_MIERCOLES_HORAS=" + _db.CreateSqlParameterName("DEB_MIERCOLES_HORAS") + ", " +
				"DEB_JUEVES_HORAS=" + _db.CreateSqlParameterName("DEB_JUEVES_HORAS") + ", " +
				"DEB_VIERNES_HORAS=" + _db.CreateSqlParameterName("DEB_VIERNES_HORAS") + ", " +
				"DEB_SABADO_HORAS=" + _db.CreateSqlParameterName("DEB_SABADO_HORAS") + ", " +
				"DEB_DOMINGO_HORAS=" + _db.CreateSqlParameterName("DEB_DOMINGO_HORAS") + ", " +
				"CONTROLA_DIA_HABIL=" + _db.CreateSqlParameterName("CONTROLA_DIA_HABIL") + ", " +
				"CONTROLA_FERIADO_BANCARIO=" + _db.CreateSqlParameterName("CONTROLA_FERIADO_BANCARIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CRED_COMISION_POS_DIA", value.CRED_COMISION_POS_DIA);
			AddParameter(cmd, "DEB_COMISION_POS_DIA", value.DEB_COMISION_POS_DIA);
			AddParameter(cmd, "CRED_COMISION_SOB_IMP_BRUTO", value.CRED_COMISION_SOB_IMP_BRUTO);
			AddParameter(cmd, "DEB_COMISION_SOB_IMP_BRUTO", value.DEB_COMISION_SOB_IMP_BRUTO);
			AddParameter(cmd, "CRED_LUNES_HORAS", value.CRED_LUNES_HORAS);
			AddParameter(cmd, "CRED_MARTES_HORAS", value.CRED_MARTES_HORAS);
			AddParameter(cmd, "CRED_MIERCOLES_HORAS", value.CRED_MIERCOLES_HORAS);
			AddParameter(cmd, "CRED_JUEVES_HORAS", value.CRED_JUEVES_HORAS);
			AddParameter(cmd, "CRED_VIERNES_HORAS", value.CRED_VIERNES_HORAS);
			AddParameter(cmd, "CRED_SABADO_HORAS", value.CRED_SABADO_HORAS);
			AddParameter(cmd, "CRED_DOMINGO_HORAS", value.CRED_DOMINGO_HORAS);
			AddParameter(cmd, "DEB_LUNES_HORAS", value.DEB_LUNES_HORAS);
			AddParameter(cmd, "DEB_MARTES_HORAS", value.DEB_MARTES_HORAS);
			AddParameter(cmd, "DEB_MIERCOLES_HORAS", value.DEB_MIERCOLES_HORAS);
			AddParameter(cmd, "DEB_JUEVES_HORAS", value.DEB_JUEVES_HORAS);
			AddParameter(cmd, "DEB_VIERNES_HORAS", value.DEB_VIERNES_HORAS);
			AddParameter(cmd, "DEB_SABADO_HORAS", value.DEB_SABADO_HORAS);
			AddParameter(cmd, "DEB_DOMINGO_HORAS", value.DEB_DOMINGO_HORAS);
			AddParameter(cmd, "CONTROLA_DIA_HABIL", value.CONTROLA_DIA_HABIL);
			AddParameter(cmd, "CONTROLA_FERIADO_BANCARIO", value.CONTROLA_FERIADO_BANCARIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PROCESADORAS_TARJETA_ENTIDADRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table using
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
		/// Deletes <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PROCESADORAS_TARJETA_ENTIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		protected CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		protected CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> objects.</returns>
		protected virtual CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int cred_comision_pos_diaColumnIndex = reader.GetOrdinal("CRED_COMISION_POS_DIA");
			int deb_comision_pos_diaColumnIndex = reader.GetOrdinal("DEB_COMISION_POS_DIA");
			int cred_comision_sob_imp_brutoColumnIndex = reader.GetOrdinal("CRED_COMISION_SOB_IMP_BRUTO");
			int deb_comision_sob_imp_brutoColumnIndex = reader.GetOrdinal("DEB_COMISION_SOB_IMP_BRUTO");
			int cred_lunes_horasColumnIndex = reader.GetOrdinal("CRED_LUNES_HORAS");
			int cred_martes_horasColumnIndex = reader.GetOrdinal("CRED_MARTES_HORAS");
			int cred_miercoles_horasColumnIndex = reader.GetOrdinal("CRED_MIERCOLES_HORAS");
			int cred_jueves_horasColumnIndex = reader.GetOrdinal("CRED_JUEVES_HORAS");
			int cred_viernes_horasColumnIndex = reader.GetOrdinal("CRED_VIERNES_HORAS");
			int cred_sabado_horasColumnIndex = reader.GetOrdinal("CRED_SABADO_HORAS");
			int cred_domingo_horasColumnIndex = reader.GetOrdinal("CRED_DOMINGO_HORAS");
			int deb_lunes_horasColumnIndex = reader.GetOrdinal("DEB_LUNES_HORAS");
			int deb_martes_horasColumnIndex = reader.GetOrdinal("DEB_MARTES_HORAS");
			int deb_miercoles_horasColumnIndex = reader.GetOrdinal("DEB_MIERCOLES_HORAS");
			int deb_jueves_horasColumnIndex = reader.GetOrdinal("DEB_JUEVES_HORAS");
			int deb_viernes_horasColumnIndex = reader.GetOrdinal("DEB_VIERNES_HORAS");
			int deb_sabado_horasColumnIndex = reader.GetOrdinal("DEB_SABADO_HORAS");
			int deb_domingo_horasColumnIndex = reader.GetOrdinal("DEB_DOMINGO_HORAS");
			int controla_dia_habilColumnIndex = reader.GetOrdinal("CONTROLA_DIA_HABIL");
			int controla_feriado_bancarioColumnIndex = reader.GetOrdinal("CONTROLA_FERIADO_BANCARIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PROCESADORAS_TARJETA_ENTIDADRow record = new CTACTE_PROCESADORAS_TARJETA_ENTIDADRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(cred_comision_pos_diaColumnIndex))
						record.CRED_COMISION_POS_DIA = Convert.ToString(reader.GetValue(cred_comision_pos_diaColumnIndex));
					if(!reader.IsDBNull(deb_comision_pos_diaColumnIndex))
						record.DEB_COMISION_POS_DIA = Convert.ToString(reader.GetValue(deb_comision_pos_diaColumnIndex));
					if(!reader.IsDBNull(cred_comision_sob_imp_brutoColumnIndex))
						record.CRED_COMISION_SOB_IMP_BRUTO = Convert.ToString(reader.GetValue(cred_comision_sob_imp_brutoColumnIndex));
					if(!reader.IsDBNull(deb_comision_sob_imp_brutoColumnIndex))
						record.DEB_COMISION_SOB_IMP_BRUTO = Convert.ToString(reader.GetValue(deb_comision_sob_imp_brutoColumnIndex));
					record.CRED_LUNES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_lunes_horasColumnIndex)), 9);
					record.CRED_MARTES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_martes_horasColumnIndex)), 9);
					record.CRED_MIERCOLES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_miercoles_horasColumnIndex)), 9);
					record.CRED_JUEVES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_jueves_horasColumnIndex)), 9);
					record.CRED_VIERNES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_viernes_horasColumnIndex)), 9);
					record.CRED_SABADO_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_sabado_horasColumnIndex)), 9);
					record.CRED_DOMINGO_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cred_domingo_horasColumnIndex)), 9);
					record.DEB_LUNES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_lunes_horasColumnIndex)), 9);
					record.DEB_MARTES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_martes_horasColumnIndex)), 9);
					record.DEB_MIERCOLES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_miercoles_horasColumnIndex)), 9);
					record.DEB_JUEVES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_jueves_horasColumnIndex)), 9);
					record.DEB_VIERNES_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_viernes_horasColumnIndex)), 9);
					record.DEB_SABADO_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_sabado_horasColumnIndex)), 9);
					record.DEB_DOMINGO_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(deb_domingo_horasColumnIndex)), 9);
					record.CONTROLA_DIA_HABIL = Convert.ToString(reader.GetValue(controla_dia_habilColumnIndex));
					if(!reader.IsDBNull(controla_feriado_bancarioColumnIndex))
						record.CONTROLA_FERIADO_BANCARIO = Convert.ToString(reader.GetValue(controla_feriado_bancarioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PROCESADORAS_TARJETA_ENTIDADRow[])(recordList.ToArray(typeof(CTACTE_PROCESADORAS_TARJETA_ENTIDADRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> object.</returns>
		protected virtual CTACTE_PROCESADORAS_TARJETA_ENTIDADRow MapRow(DataRow row)
		{
			CTACTE_PROCESADORAS_TARJETA_ENTIDADRow mappedObject = new CTACTE_PROCESADORAS_TARJETA_ENTIDADRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CRED_COMISION_POS_DIA"
			dataColumn = dataTable.Columns["CRED_COMISION_POS_DIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_COMISION_POS_DIA = (string)row[dataColumn];
			// Column "DEB_COMISION_POS_DIA"
			dataColumn = dataTable.Columns["DEB_COMISION_POS_DIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_COMISION_POS_DIA = (string)row[dataColumn];
			// Column "CRED_COMISION_SOB_IMP_BRUTO"
			dataColumn = dataTable.Columns["CRED_COMISION_SOB_IMP_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_COMISION_SOB_IMP_BRUTO = (string)row[dataColumn];
			// Column "DEB_COMISION_SOB_IMP_BRUTO"
			dataColumn = dataTable.Columns["DEB_COMISION_SOB_IMP_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_COMISION_SOB_IMP_BRUTO = (string)row[dataColumn];
			// Column "CRED_LUNES_HORAS"
			dataColumn = dataTable.Columns["CRED_LUNES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_LUNES_HORAS = (decimal)row[dataColumn];
			// Column "CRED_MARTES_HORAS"
			dataColumn = dataTable.Columns["CRED_MARTES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_MARTES_HORAS = (decimal)row[dataColumn];
			// Column "CRED_MIERCOLES_HORAS"
			dataColumn = dataTable.Columns["CRED_MIERCOLES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_MIERCOLES_HORAS = (decimal)row[dataColumn];
			// Column "CRED_JUEVES_HORAS"
			dataColumn = dataTable.Columns["CRED_JUEVES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_JUEVES_HORAS = (decimal)row[dataColumn];
			// Column "CRED_VIERNES_HORAS"
			dataColumn = dataTable.Columns["CRED_VIERNES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_VIERNES_HORAS = (decimal)row[dataColumn];
			// Column "CRED_SABADO_HORAS"
			dataColumn = dataTable.Columns["CRED_SABADO_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_SABADO_HORAS = (decimal)row[dataColumn];
			// Column "CRED_DOMINGO_HORAS"
			dataColumn = dataTable.Columns["CRED_DOMINGO_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRED_DOMINGO_HORAS = (decimal)row[dataColumn];
			// Column "DEB_LUNES_HORAS"
			dataColumn = dataTable.Columns["DEB_LUNES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_LUNES_HORAS = (decimal)row[dataColumn];
			// Column "DEB_MARTES_HORAS"
			dataColumn = dataTable.Columns["DEB_MARTES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_MARTES_HORAS = (decimal)row[dataColumn];
			// Column "DEB_MIERCOLES_HORAS"
			dataColumn = dataTable.Columns["DEB_MIERCOLES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_MIERCOLES_HORAS = (decimal)row[dataColumn];
			// Column "DEB_JUEVES_HORAS"
			dataColumn = dataTable.Columns["DEB_JUEVES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_JUEVES_HORAS = (decimal)row[dataColumn];
			// Column "DEB_VIERNES_HORAS"
			dataColumn = dataTable.Columns["DEB_VIERNES_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_VIERNES_HORAS = (decimal)row[dataColumn];
			// Column "DEB_SABADO_HORAS"
			dataColumn = dataTable.Columns["DEB_SABADO_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_SABADO_HORAS = (decimal)row[dataColumn];
			// Column "DEB_DOMINGO_HORAS"
			dataColumn = dataTable.Columns["DEB_DOMINGO_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEB_DOMINGO_HORAS = (decimal)row[dataColumn];
			// Column "CONTROLA_DIA_HABIL"
			dataColumn = dataTable.Columns["CONTROLA_DIA_HABIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLA_DIA_HABIL = (string)row[dataColumn];
			// Column "CONTROLA_FERIADO_BANCARIO"
			dataColumn = dataTable.Columns["CONTROLA_FERIADO_BANCARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLA_FERIADO_BANCARIO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PROCESADORAS_TARJETA_ENTIDAD";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_COMISION_POS_DIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DEB_COMISION_POS_DIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CRED_COMISION_SOB_IMP_BRUTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DEB_COMISION_SOB_IMP_BRUTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CRED_LUNES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_MARTES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_MIERCOLES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_JUEVES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_VIERNES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_SABADO_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRED_DOMINGO_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_LUNES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_MARTES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_MIERCOLES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_JUEVES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_VIERNES_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_SABADO_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEB_DOMINGO_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTROLA_DIA_HABIL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTROLA_FERIADO_BANCARIO", typeof(string));
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CRED_COMISION_POS_DIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEB_COMISION_POS_DIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CRED_COMISION_SOB_IMP_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEB_COMISION_SOB_IMP_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CRED_LUNES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_MARTES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_MIERCOLES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_JUEVES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_VIERNES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_SABADO_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CRED_DOMINGO_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_LUNES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_MARTES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_MIERCOLES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_JUEVES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_VIERNES_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_SABADO_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEB_DOMINGO_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTROLA_DIA_HABIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONTROLA_FERIADO_BANCARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base class
}  // End of namespace
