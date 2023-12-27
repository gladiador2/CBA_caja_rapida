// <fileinfo name="ADJUNTOSCollection_Base.cs">
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
	/// The base class for <see cref="ADJUNTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ADJUNTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ADJUNTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBRE_ARCHIVOColumnName = "NOMBRE_ARCHIVO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string EXTENSIONColumnName = "EXTENSION";
		public const string TIPO_MIMEColumnName = "TIPO_MIME";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_ULTIMA_EDICION_IDColumnName = "USUARIO_ULTIMA_EDICION_ID";
		public const string FECHA_ULTIMA_EDICIONColumnName = "FECHA_ULTIMA_EDICION";
		public const string USUARIO_BORRADO_IDColumnName = "USUARIO_BORRADO_ID";
		public const string FECHA_BORRADOColumnName = "FECHA_BORRADO";
		public const string MOTIVO_BORRADOColumnName = "MOTIVO_BORRADO";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string REGISTROColumnName = "REGISTRO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string TIPO_ADJUNTO_IDColumnName = "TIPO_ADJUNTO_ID";
		public const string TIPO_PRIVACIDADColumnName = "TIPO_PRIVACIDAD";
		public const string ESTADOColumnName = "ESTADO";
		public const string CLIO_UUIDColumnName = "CLIO_UUID";
		public const string GRUPOColumnName = "GRUPO";
		public const string PRINCIPALColumnName = "PRINCIPAL";
		public const string PATH_TEMPORALColumnName = "PATH_TEMPORAL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ADJUNTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ADJUNTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ADJUNTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ADJUNTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ADJUNTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ADJUNTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public ADJUNTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ADJUNTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ADJUNTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ADJUNTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ADJUNTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ADJUNTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public ADJUNTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_TIPOS_ADJUNTOS</c> foreign key.
		/// </summary>
		/// <param name="tipo_adjunto_id">The <c>TIPO_ADJUNTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByTIPO_ADJUNTO_ID(decimal tipo_adjunto_id)
		{
			return MapRecords(CreateGetByTIPO_ADJUNTO_IDCommand(tipo_adjunto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_TIPOS_ADJUNTOS</c> foreign key.
		/// </summary>
		/// <param name="tipo_adjunto_id">The <c>TIPO_ADJUNTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_ADJUNTO_IDAsDataTable(decimal tipo_adjunto_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_ADJUNTO_IDCommand(tipo_adjunto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_TIPOS_ADJUNTOS</c> foreign key.
		/// </summary>
		/// <param name="tipo_adjunto_id">The <c>TIPO_ADJUNTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_ADJUNTO_IDCommand(decimal tipo_adjunto_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ADJUNTO_ID=" + _db.CreateSqlParameterName("TIPO_ADJUNTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ADJUNTO_ID", tipo_adjunto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public ADJUNTOSRow[] GetByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id)
		{
			return GetByUSUARIO_ULTIMA_EDICION_ID(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(decimal usuario_ultima_edicion_id)
		{
			return GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			string whereSql = "";
			if(usuario_ultima_edicion_idNull)
				whereSql += "USUARIO_ULTIMA_EDICION_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_ultima_edicion_idNull)
				AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID", usuario_ultima_edicion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public ADJUNTOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_IDAsDataTable(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADJUNTOSRow"/> objects 
		/// by the <c>FK_ADJUNTOS_USUARIO_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		public virtual ADJUNTOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADJUNTOS_USUARIO_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADJUNTOS_USUARIO_CREACION</c> foreign key.
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
		/// Adds a new record into the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADJUNTOSRow"/> object to be inserted.</param>
		public virtual void Insert(ADJUNTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ADJUNTOS (" +
				"ID, " +
				"NOMBRE_ARCHIVO, " +
				"DESCRIPCION, " +
				"EXTENSION, " +
				"TIPO_MIME, " +
				"USUARIO_ID, " +
				"FECHA, " +
				"USUARIO_ULTIMA_EDICION_ID, " +
				"FECHA_ULTIMA_EDICION, " +
				"USUARIO_BORRADO_ID, " +
				"FECHA_BORRADO, " +
				"MOTIVO_BORRADO, " +
				"TABLA_ID, " +
				"REGISTRO, " +
				"CASO_ID, " +
				"TIPO_ADJUNTO_ID, " +
				"TIPO_PRIVACIDAD, " +
				"ESTADO, " +
				"CLIO_UUID, " +
				"GRUPO, " +
				"PRINCIPAL, " +
				"PATH_TEMPORAL" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE_ARCHIVO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("EXTENSION") + ", " +
				_db.CreateSqlParameterName("TIPO_MIME") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMA_EDICION") + ", " +
				_db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				_db.CreateSqlParameterName("MOTIVO_BORRADO") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ADJUNTO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_PRIVACIDAD") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CLIO_UUID") + ", " +
				_db.CreateSqlParameterName("GRUPO") + ", " +
				_db.CreateSqlParameterName("PRINCIPAL") + ", " +
				_db.CreateSqlParameterName("PATH_TEMPORAL") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE_ARCHIVO", value.NOMBRE_ARCHIVO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "EXTENSION", value.EXTENSION);
			AddParameter(cmd, "TIPO_MIME", value.TIPO_MIME);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID",
				value.IsUSUARIO_ULTIMA_EDICION_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMA_EDICION_ID);
			AddParameter(cmd, "FECHA_ULTIMA_EDICION",
				value.IsFECHA_ULTIMA_EDICIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EDICION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "MOTIVO_BORRADO", value.MOTIVO_BORRADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "REGISTRO",
				value.IsREGISTRONull ? DBNull.Value : (object)value.REGISTRO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "TIPO_ADJUNTO_ID", value.TIPO_ADJUNTO_ID);
			AddParameter(cmd, "TIPO_PRIVACIDAD", value.TIPO_PRIVACIDAD);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CLIO_UUID", value.CLIO_UUID);
			AddParameter(cmd, "GRUPO", value.GRUPO);
			AddParameter(cmd, "PRINCIPAL", value.PRINCIPAL);
			AddParameter(cmd, "PATH_TEMPORAL", value.PATH_TEMPORAL);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADJUNTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ADJUNTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ADJUNTOS SET " +
				"NOMBRE_ARCHIVO=" + _db.CreateSqlParameterName("NOMBRE_ARCHIVO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"EXTENSION=" + _db.CreateSqlParameterName("EXTENSION") + ", " +
				"TIPO_MIME=" + _db.CreateSqlParameterName("TIPO_MIME") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID") + ", " +
				"FECHA_ULTIMA_EDICION=" + _db.CreateSqlParameterName("FECHA_ULTIMA_EDICION") + ", " +
				"USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				"FECHA_BORRADO=" + _db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				"MOTIVO_BORRADO=" + _db.CreateSqlParameterName("MOTIVO_BORRADO") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"REGISTRO=" + _db.CreateSqlParameterName("REGISTRO") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"TIPO_ADJUNTO_ID=" + _db.CreateSqlParameterName("TIPO_ADJUNTO_ID") + ", " +
				"TIPO_PRIVACIDAD=" + _db.CreateSqlParameterName("TIPO_PRIVACIDAD") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CLIO_UUID=" + _db.CreateSqlParameterName("CLIO_UUID") + ", " +
				"GRUPO=" + _db.CreateSqlParameterName("GRUPO") + ", " +
				"PRINCIPAL=" + _db.CreateSqlParameterName("PRINCIPAL") + ", " +
				"PATH_TEMPORAL=" + _db.CreateSqlParameterName("PATH_TEMPORAL") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE_ARCHIVO", value.NOMBRE_ARCHIVO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "EXTENSION", value.EXTENSION);
			AddParameter(cmd, "TIPO_MIME", value.TIPO_MIME);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID",
				value.IsUSUARIO_ULTIMA_EDICION_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMA_EDICION_ID);
			AddParameter(cmd, "FECHA_ULTIMA_EDICION",
				value.IsFECHA_ULTIMA_EDICIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EDICION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "MOTIVO_BORRADO", value.MOTIVO_BORRADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "REGISTRO",
				value.IsREGISTRONull ? DBNull.Value : (object)value.REGISTRO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "TIPO_ADJUNTO_ID", value.TIPO_ADJUNTO_ID);
			AddParameter(cmd, "TIPO_PRIVACIDAD", value.TIPO_PRIVACIDAD);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CLIO_UUID", value.CLIO_UUID);
			AddParameter(cmd, "GRUPO", value.GRUPO);
			AddParameter(cmd, "PRINCIPAL", value.PRINCIPAL);
			AddParameter(cmd, "PATH_TEMPORAL", value.PATH_TEMPORAL);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ADJUNTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ADJUNTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADJUNTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ADJUNTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ADJUNTOS</c> table using
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
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_TIPOS_ADJUNTOS</c> foreign key.
		/// </summary>
		/// <param name="tipo_adjunto_id">The <c>TIPO_ADJUNTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ADJUNTO_ID(decimal tipo_adjunto_id)
		{
			return CreateDeleteByTIPO_ADJUNTO_IDCommand(tipo_adjunto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_TIPOS_ADJUNTOS</c> foreign key.
		/// </summary>
		/// <param name="tipo_adjunto_id">The <c>TIPO_ADJUNTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_ADJUNTO_IDCommand(decimal tipo_adjunto_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ADJUNTO_ID=" + _db.CreateSqlParameterName("TIPO_ADJUNTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ADJUNTO_ID", tipo_adjunto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id)
		{
			return DeleteByUSUARIO_ULTIMA_EDICION_ID(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return CreateDeleteByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_USR_ULT_EDICION</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ULTIMA_EDICION_IDCommand(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			string whereSql = "";
			if(usuario_ultima_edicion_idNull)
				whereSql += "USUARIO_ULTIMA_EDICION_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_ultima_edicion_idNull)
				AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID", usuario_ultima_edicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return DeleteByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return CreateDeleteByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_USUARIO_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADJUNTOS</c> table using the 
		/// <c>FK_ADJUNTOS_USUARIO_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADJUNTOS_USUARIO_CREACION</c> foreign key.
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
		/// Deletes <c>ADJUNTOS</c> records that match the specified criteria.
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
		/// to delete <c>ADJUNTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ADJUNTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ADJUNTOS</c> table.
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
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		protected ADJUNTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		protected ADJUNTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ADJUNTOSRow"/> objects.</returns>
		protected virtual ADJUNTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombre_archivoColumnIndex = reader.GetOrdinal("NOMBRE_ARCHIVO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int extensionColumnIndex = reader.GetOrdinal("EXTENSION");
			int tipo_mimeColumnIndex = reader.GetOrdinal("TIPO_MIME");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_ultima_edicion_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMA_EDICION_ID");
			int fecha_ultima_edicionColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_EDICION");
			int usuario_borrado_idColumnIndex = reader.GetOrdinal("USUARIO_BORRADO_ID");
			int fecha_borradoColumnIndex = reader.GetOrdinal("FECHA_BORRADO");
			int motivo_borradoColumnIndex = reader.GetOrdinal("MOTIVO_BORRADO");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int registroColumnIndex = reader.GetOrdinal("REGISTRO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int tipo_adjunto_idColumnIndex = reader.GetOrdinal("TIPO_ADJUNTO_ID");
			int tipo_privacidadColumnIndex = reader.GetOrdinal("TIPO_PRIVACIDAD");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int clio_uuidColumnIndex = reader.GetOrdinal("CLIO_UUID");
			int grupoColumnIndex = reader.GetOrdinal("GRUPO");
			int principalColumnIndex = reader.GetOrdinal("PRINCIPAL");
			int path_temporalColumnIndex = reader.GetOrdinal("PATH_TEMPORAL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ADJUNTOSRow record = new ADJUNTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_archivoColumnIndex))
						record.NOMBRE_ARCHIVO = Convert.ToString(reader.GetValue(nombre_archivoColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(extensionColumnIndex))
						record.EXTENSION = Convert.ToString(reader.GetValue(extensionColumnIndex));
					if(!reader.IsDBNull(tipo_mimeColumnIndex))
						record.TIPO_MIME = Convert.ToString(reader.GetValue(tipo_mimeColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(usuario_ultima_edicion_idColumnIndex))
						record.USUARIO_ULTIMA_EDICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultima_edicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultima_edicionColumnIndex))
						record.FECHA_ULTIMA_EDICION = Convert.ToDateTime(reader.GetValue(fecha_ultima_edicionColumnIndex));
					if(!reader.IsDBNull(usuario_borrado_idColumnIndex))
						record.USUARIO_BORRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_borrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_borradoColumnIndex))
						record.FECHA_BORRADO = Convert.ToDateTime(reader.GetValue(fecha_borradoColumnIndex));
					if(!reader.IsDBNull(motivo_borradoColumnIndex))
						record.MOTIVO_BORRADO = Convert.ToString(reader.GetValue(motivo_borradoColumnIndex));
					record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					if(!reader.IsDBNull(registroColumnIndex))
						record.REGISTRO = Math.Round(Convert.ToDecimal(reader.GetValue(registroColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.TIPO_ADJUNTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_adjunto_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_privacidadColumnIndex))
						record.TIPO_PRIVACIDAD = Convert.ToString(reader.GetValue(tipo_privacidadColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(clio_uuidColumnIndex))
						record.CLIO_UUID = Convert.ToString(reader.GetValue(clio_uuidColumnIndex));
					if(!reader.IsDBNull(grupoColumnIndex))
						record.GRUPO = Convert.ToString(reader.GetValue(grupoColumnIndex));
					record.PRINCIPAL = Convert.ToString(reader.GetValue(principalColumnIndex));
					if(!reader.IsDBNull(path_temporalColumnIndex))
						record.PATH_TEMPORAL = Convert.ToString(reader.GetValue(path_temporalColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ADJUNTOSRow[])(recordList.ToArray(typeof(ADJUNTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ADJUNTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ADJUNTOSRow"/> object.</returns>
		protected virtual ADJUNTOSRow MapRow(DataRow row)
		{
			ADJUNTOSRow mappedObject = new ADJUNTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE_ARCHIVO"
			dataColumn = dataTable.Columns["NOMBRE_ARCHIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_ARCHIVO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "EXTENSION"
			dataColumn = dataTable.Columns["EXTENSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXTENSION = (string)row[dataColumn];
			// Column "TIPO_MIME"
			dataColumn = dataTable.Columns["TIPO_MIME"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MIME = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ULTIMA_EDICION_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMA_EDICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMA_EDICION_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMA_EDICION"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_EDICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_EDICION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_BORRADO_ID"
			dataColumn = dataTable.Columns["USUARIO_BORRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BORRADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_BORRADO"
			dataColumn = dataTable.Columns["FECHA_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BORRADO = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_BORRADO"
			dataColumn = dataTable.Columns["MOTIVO_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_BORRADO = (string)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "REGISTRO"
			dataColumn = dataTable.Columns["REGISTRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "TIPO_ADJUNTO_ID"
			dataColumn = dataTable.Columns["TIPO_ADJUNTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ADJUNTO_ID = (decimal)row[dataColumn];
			// Column "TIPO_PRIVACIDAD"
			dataColumn = dataTable.Columns["TIPO_PRIVACIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_PRIVACIDAD = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CLIO_UUID"
			dataColumn = dataTable.Columns["CLIO_UUID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIO_UUID = (string)row[dataColumn];
			// Column "GRUPO"
			dataColumn = dataTable.Columns["GRUPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO = (string)row[dataColumn];
			// Column "PRINCIPAL"
			dataColumn = dataTable.Columns["PRINCIPAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRINCIPAL = (string)row[dataColumn];
			// Column "PATH_TEMPORAL"
			dataColumn = dataTable.Columns["PATH_TEMPORAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PATH_TEMPORAL = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ADJUNTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ADJUNTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_ARCHIVO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("EXTENSION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TIPO_MIME", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMA_EDICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_EDICION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_BORRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_BORRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MOTIVO_BORRADO", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGISTRO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_ADJUNTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_PRIVACIDAD", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CLIO_UUID", typeof(string));
			dataColumn.MaxLength = 128;
			dataColumn = dataTable.Columns.Add("GRUPO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PRINCIPAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PATH_TEMPORAL", typeof(string));
			dataColumn.MaxLength = 150;
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

				case "NOMBRE_ARCHIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXTENSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_MIME":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ULTIMA_EDICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMA_EDICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_BORRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ADJUNTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_PRIVACIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CLIO_UUID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRINCIPAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PATH_TEMPORAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ADJUNTOSCollection_Base class
}  // End of namespace
