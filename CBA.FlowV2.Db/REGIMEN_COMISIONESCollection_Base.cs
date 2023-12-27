// <fileinfo name="REGIMEN_COMISIONESCollection_Base.cs">
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
	/// The base class for <see cref="REGIMEN_COMISIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REGIMEN_COMISIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REGIMEN_COMISIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string LISTA_PRECIOS_IDColumnName = "LISTA_PRECIOS_ID";
		public const string DESCUENTO_MAXIMOColumnName = "DESCUENTO_MAXIMO";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string FECHA_DESDEColumnName = "FECHA_DESDE";
		public const string FECHA_HASTAColumnName = "FECHA_HASTA";
		public const string PORCENTAJE_COMISIONColumnName = "PORCENTAJE_COMISION";
		public const string ESTADOColumnName = "ESTADO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REGIMEN_COMISIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REGIMEN_COMISIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REGIMEN_COMISIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REGIMEN_COMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REGIMEN_COMISIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REGIMEN_COMISIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REGIMEN_COMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REGIMEN_COMISIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REGIMEN_COMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REGIMEN_COMISIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REGIMEN_COMISIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByFAMILIA_ID(decimal familia_id)
		{
			return GetByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return MapRecords(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id)
		{
			return GetByFAMILIA_IDAsDataTable(familia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id, bool familia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByGRUPO_ID(decimal grupo_id)
		{
			return GetByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecords(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id)
		{
			return GetByGRUPO_IDAsDataTable(grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return GetByLISTA_PRECIOS_ID(lista_precios_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByLISTA_PRECIOS_ID(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIOS_IDAsDataTable(decimal lista_precios_id)
		{
			return GetByLISTA_PRECIOS_IDAsDataTable(lista_precios_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIOS_IDAsDataTable(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIOS_IDCommand(decimal lista_precios_id, bool lista_precios_idNull)
		{
			string whereSql = "";
			if(lista_precios_idNull)
				whereSql += "LISTA_PRECIOS_ID IS NULL";
			else
				whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precios_idNull)
				AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public REGIMEN_COMISIONESRow[] GetBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REGIMEN_COMISIONESRow"/> objects 
		/// by the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		public virtual REGIMEN_COMISIONESRow[] GetBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecords(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_IDAsDataTable(subgrupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REGIMEN_COMISIONESRow"/> object to be inserted.</param>
		public virtual void Insert(REGIMEN_COMISIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REGIMEN_COMISIONES (" +
				"ID, " +
				"FAMILIA_ID, " +
				"GRUPO_ID, " +
				"SUBGRUPO_ID, " +
				"ARTICULO_ID, " +
				"FUNCIONARIO_ID, " +
				"LISTA_PRECIOS_ID, " +
				"DESCUENTO_MAXIMO, " +
				"CANTIDAD_MINIMA, " +
				"FECHA_DESDE, " +
				"FECHA_HASTA, " +
				"PORCENTAJE_COMISION, " +
				"ESTADO, " +
				"PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIOS_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_MAXIMO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				_db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				_db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_COMISION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID",
				value.IsLISTA_PRECIOS_IDNull ? DBNull.Value : (object)value.LISTA_PRECIOS_ID);
			AddParameter(cmd, "DESCUENTO_MAXIMO",
				value.IsDESCUENTO_MAXIMONull ? DBNull.Value : (object)value.DESCUENTO_MAXIMO);
			AddParameter(cmd, "CANTIDAD_MINIMA",
				value.IsCANTIDAD_MINIMANull ? DBNull.Value : (object)value.CANTIDAD_MINIMA);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "PORCENTAJE_COMISION", value.PORCENTAJE_COMISION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REGIMEN_COMISIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REGIMEN_COMISIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.REGIMEN_COMISIONES SET " +
				"FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				"GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID") + ", " +
				"SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID") + ", " +
				"DESCUENTO_MAXIMO=" + _db.CreateSqlParameterName("DESCUENTO_MAXIMO") + ", " +
				"CANTIDAD_MINIMA=" + _db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				"FECHA_DESDE=" + _db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				"FECHA_HASTA=" + _db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				"PORCENTAJE_COMISION=" + _db.CreateSqlParameterName("PORCENTAJE_COMISION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID",
				value.IsLISTA_PRECIOS_IDNull ? DBNull.Value : (object)value.LISTA_PRECIOS_ID);
			AddParameter(cmd, "DESCUENTO_MAXIMO",
				value.IsDESCUENTO_MAXIMONull ? DBNull.Value : (object)value.DESCUENTO_MAXIMO);
			AddParameter(cmd, "CANTIDAD_MINIMA",
				value.IsCANTIDAD_MINIMANull ? DBNull.Value : (object)value.CANTIDAD_MINIMA);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "PORCENTAJE_COMISION", value.PORCENTAJE_COMISION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REGIMEN_COMISIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REGIMEN_COMISIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REGIMEN_COMISIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REGIMEN_COMISIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REGIMEN_COMISIONES</c> table using
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
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id)
		{
			return DeleteByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return CreateDeleteByFAMILIA_IDCommand(familia_id, familia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id)
		{
			return DeleteByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return CreateDeleteByGRUPO_IDCommand(grupo_id, grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return DeleteByLISTA_PRECIOS_ID(lista_precios_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_ID(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return CreateDeleteByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_LISTA_PRECIOS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIOS_IDCommand(decimal lista_precios_id, bool lista_precios_idNull)
		{
			string whereSql = "";
			if(lista_precios_idNull)
				whereSql += "LISTA_PRECIOS_ID IS NULL";
			else
				whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precios_idNull)
				AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_REGIMEN_COM_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return DeleteBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REGIMEN_COMISIONES</c> table using the 
		/// <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return CreateDeleteBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REGIMEN_COM_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REGIMEN_COMISIONES</c> records that match the specified criteria.
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
		/// to delete <c>REGIMEN_COMISIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REGIMEN_COMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REGIMEN_COMISIONES</c> table.
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
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		protected REGIMEN_COMISIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		protected REGIMEN_COMISIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REGIMEN_COMISIONESRow"/> objects.</returns>
		protected virtual REGIMEN_COMISIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int lista_precios_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ID");
			int descuento_maximoColumnIndex = reader.GetOrdinal("DESCUENTO_MAXIMO");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int fecha_desdeColumnIndex = reader.GetOrdinal("FECHA_DESDE");
			int fecha_hastaColumnIndex = reader.GetOrdinal("FECHA_HASTA");
			int porcentaje_comisionColumnIndex = reader.GetOrdinal("PORCENTAJE_COMISION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REGIMEN_COMISIONESRow record = new REGIMEN_COMISIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precios_idColumnIndex))
						record.LISTA_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_maximoColumnIndex))
						record.DESCUENTO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_maximoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desdeColumnIndex))
						record.FECHA_DESDE = Convert.ToDateTime(reader.GetValue(fecha_desdeColumnIndex));
					if(!reader.IsDBNull(fecha_hastaColumnIndex))
						record.FECHA_HASTA = Convert.ToDateTime(reader.GetValue(fecha_hastaColumnIndex));
					record.PORCENTAJE_COMISION = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_comisionColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REGIMEN_COMISIONESRow[])(recordList.ToArray(typeof(REGIMEN_COMISIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REGIMEN_COMISIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REGIMEN_COMISIONESRow"/> object.</returns>
		protected virtual REGIMEN_COMISIONESRow MapRow(DataRow row)
		{
			REGIMEN_COMISIONESRow mappedObject = new REGIMEN_COMISIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_MAXIMO"
			dataColumn = dataTable.Columns["DESCUENTO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAXIMO = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "FECHA_DESDE"
			dataColumn = dataTable.Columns["FECHA_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA"
			dataColumn = dataTable.Columns["FECHA_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA = (System.DateTime)row[dataColumn];
			// Column "PORCENTAJE_COMISION"
			dataColumn = dataTable.Columns["PORCENTAJE_COMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_COMISION = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REGIMEN_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REGIMEN_COMISIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAXIMO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESDE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_HASTA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_COMISION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
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

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PORCENTAJE_COMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REGIMEN_COMISIONESCollection_Base class
}  // End of namespace
