// <fileinfo name="USUARIOSCollection_Base.cs">
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
	/// The base class for <see cref="USUARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="USUARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string EXTERNOColumnName = "EXTERNO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string SESIONColumnName = "SESION";
		public const string FECHA_CAMBIO_PASSColumnName = "FECHA_CAMBIO_PASS";
		public const string VIDA_PASSColumnName = "VIDA_PASS";
		public const string FECHA_CADU_PASSColumnName = "FECHA_CADU_PASS";
		public const string ULTIMO_LOGINColumnName = "ULTIMO_LOGIN";
		public const string ESTADOColumnName = "ESTADO";
		public const string SUCURSAL_ACTIVA_IDColumnName = "SUCURSAL_ACTIVA_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string SUPERVISORColumnName = "SUPERVISOR";
		public const string EMAILColumnName = "EMAIL";
		public const string REQUERIR_CAMBIO_CONTRASENHAColumnName = "REQUERIR_CAMBIO_CONTRASENHA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public USUARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>USUARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="USUARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="USUARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public USUARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			USUARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public USUARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.USUARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="USUARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="USUARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual USUARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			USUARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public USUARIOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS</c> foreign key.
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
		/// return records by the <c>FK_CASOS</c> foreign key.
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
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USUARIO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public USUARIOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
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
		/// return records by the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
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
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public USUARIOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_USUARIO_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_SUCURSAL_ACTIVA</c> foreign key.
		/// </summary>
		/// <param name="sucursal_activa_id">The <c>SUCURSAL_ACTIVA_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetBySUCURSAL_ACTIVA_ID(decimal sucursal_activa_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ACTIVA_IDCommand(sucursal_activa_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_SUCURSAL_ACTIVA</c> foreign key.
		/// </summary>
		/// <param name="sucursal_activa_id">The <c>SUCURSAL_ACTIVA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ACTIVA_IDAsDataTable(decimal sucursal_activa_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ACTIVA_IDCommand(sucursal_activa_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USUARIO_SUCURSAL_ACTIVA</c> foreign key.
		/// </summary>
		/// <param name="sucursal_activa_id">The <c>SUCURSAL_ACTIVA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_ACTIVA_IDCommand(decimal sucursal_activa_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ACTIVA_ID=" + _db.CreateSqlParameterName("SUCURSAL_ACTIVA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ACTIVA_ID", sucursal_activa_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public USUARIOSRow[] GetBySUPERVISOR(decimal supervisor)
		{
			return GetBySUPERVISOR(supervisor, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOSRow"/> objects 
		/// by the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <param name="supervisorNull">true if the method ignores the supervisor
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		public virtual USUARIOSRow[] GetBySUPERVISOR(decimal supervisor, bool supervisorNull)
		{
			return MapRecords(CreateGetBySUPERVISORCommand(supervisor, supervisorNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUPERVISORAsDataTable(decimal supervisor)
		{
			return GetBySUPERVISORAsDataTable(supervisor, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <param name="supervisorNull">true if the method ignores the supervisor
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUPERVISORAsDataTable(decimal supervisor, bool supervisorNull)
		{
			return MapRecordsToDataTable(CreateGetBySUPERVISORCommand(supervisor, supervisorNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <param name="supervisorNull">true if the method ignores the supervisor
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUPERVISORCommand(decimal supervisor, bool supervisorNull)
		{
			string whereSql = "";
			if(supervisorNull)
				whereSql += "SUPERVISOR IS NULL";
			else
				whereSql += "SUPERVISOR=" + _db.CreateSqlParameterName("SUPERVISOR");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!supervisorNull)
				AddParameter(cmd, "SUPERVISOR", supervisor);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(USUARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.USUARIOS (" +
				"ID, " +
				"CASO_ID, " +
				"USUARIO, " +
				"NOMBRE, " +
				"APELLIDO, " +
				"EXTERNO, " +
				"ENTIDAD_ID, " +
				"SESION, " +
				"FECHA_CAMBIO_PASS, " +
				"VIDA_PASS, " +
				"FECHA_CADU_PASS, " +
				"ULTIMO_LOGIN, " +
				"ESTADO, " +
				"SUCURSAL_ACTIVA_ID, " +
				"PERSONA_ID, " +
				"FUNCIONARIO_ID, " +
				"SUPERVISOR, " +
				"EMAIL, " +
				"REQUERIR_CAMBIO_CONTRASENHA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("APELLIDO") + ", " +
				_db.CreateSqlParameterName("EXTERNO") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("SESION") + ", " +
				_db.CreateSqlParameterName("FECHA_CAMBIO_PASS") + ", " +
				_db.CreateSqlParameterName("VIDA_PASS") + ", " +
				_db.CreateSqlParameterName("FECHA_CADU_PASS") + ", " +
				_db.CreateSqlParameterName("ULTIMO_LOGIN") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ACTIVA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("SUPERVISOR") + ", " +
				_db.CreateSqlParameterName("EMAIL") + ", " +
				_db.CreateSqlParameterName("REQUERIR_CAMBIO_CONTRASENHA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "USUARIO", value.USUARIO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "EXTERNO", value.EXTERNO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "SESION",
				value.IsSESIONNull ? DBNull.Value : (object)value.SESION);
			AddParameter(cmd, "FECHA_CAMBIO_PASS",
				value.IsFECHA_CAMBIO_PASSNull ? DBNull.Value : (object)value.FECHA_CAMBIO_PASS);
			AddParameter(cmd, "VIDA_PASS", value.VIDA_PASS);
			AddParameter(cmd, "FECHA_CADU_PASS", value.FECHA_CADU_PASS);
			AddParameter(cmd, "ULTIMO_LOGIN",
				value.IsULTIMO_LOGINNull ? DBNull.Value : (object)value.ULTIMO_LOGIN);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "SUCURSAL_ACTIVA_ID", value.SUCURSAL_ACTIVA_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "SUPERVISOR",
				value.IsSUPERVISORNull ? DBNull.Value : (object)value.SUPERVISOR);
			AddParameter(cmd, "EMAIL", value.EMAIL);
			AddParameter(cmd, "REQUERIR_CAMBIO_CONTRASENHA", value.REQUERIR_CAMBIO_CONTRASENHA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(USUARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.USUARIOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"USUARIO=" + _db.CreateSqlParameterName("USUARIO") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"APELLIDO=" + _db.CreateSqlParameterName("APELLIDO") + ", " +
				"EXTERNO=" + _db.CreateSqlParameterName("EXTERNO") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"SESION=" + _db.CreateSqlParameterName("SESION") + ", " +
				"FECHA_CAMBIO_PASS=" + _db.CreateSqlParameterName("FECHA_CAMBIO_PASS") + ", " +
				"VIDA_PASS=" + _db.CreateSqlParameterName("VIDA_PASS") + ", " +
				"FECHA_CADU_PASS=" + _db.CreateSqlParameterName("FECHA_CADU_PASS") + ", " +
				"ULTIMO_LOGIN=" + _db.CreateSqlParameterName("ULTIMO_LOGIN") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"SUCURSAL_ACTIVA_ID=" + _db.CreateSqlParameterName("SUCURSAL_ACTIVA_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"SUPERVISOR=" + _db.CreateSqlParameterName("SUPERVISOR") + ", " +
				"EMAIL=" + _db.CreateSqlParameterName("EMAIL") + ", " +
				"REQUERIR_CAMBIO_CONTRASENHA=" + _db.CreateSqlParameterName("REQUERIR_CAMBIO_CONTRASENHA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "USUARIO", value.USUARIO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "EXTERNO", value.EXTERNO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "SESION",
				value.IsSESIONNull ? DBNull.Value : (object)value.SESION);
			AddParameter(cmd, "FECHA_CAMBIO_PASS",
				value.IsFECHA_CAMBIO_PASSNull ? DBNull.Value : (object)value.FECHA_CAMBIO_PASS);
			AddParameter(cmd, "VIDA_PASS", value.VIDA_PASS);
			AddParameter(cmd, "FECHA_CADU_PASS", value.FECHA_CADU_PASS);
			AddParameter(cmd, "ULTIMO_LOGIN",
				value.IsULTIMO_LOGINNull ? DBNull.Value : (object)value.ULTIMO_LOGIN);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "SUCURSAL_ACTIVA_ID", value.SUCURSAL_ACTIVA_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "SUPERVISOR",
				value.IsSUPERVISORNull ? DBNull.Value : (object)value.SUPERVISOR);
			AddParameter(cmd, "EMAIL", value.EMAIL);
			AddParameter(cmd, "REQUERIR_CAMBIO_CONTRASENHA", value.REQUERIR_CAMBIO_CONTRASENHA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>USUARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>USUARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(USUARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>USUARIOS</c> table using
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
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_CASOS</c> foreign key.
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
		/// delete records using the <c>FK_CASOS</c> foreign key.
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
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USUARIO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
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
		/// delete records using the <c>FK_USUARIO_FUNCIONARIO</c> foreign key.
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
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_USUARIO_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_SUCURSAL_ACTIVA</c> foreign key.
		/// </summary>
		/// <param name="sucursal_activa_id">The <c>SUCURSAL_ACTIVA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ACTIVA_ID(decimal sucursal_activa_id)
		{
			return CreateDeleteBySUCURSAL_ACTIVA_IDCommand(sucursal_activa_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USUARIO_SUCURSAL_ACTIVA</c> foreign key.
		/// </summary>
		/// <param name="sucursal_activa_id">The <c>SUCURSAL_ACTIVA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_ACTIVA_IDCommand(decimal sucursal_activa_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ACTIVA_ID=" + _db.CreateSqlParameterName("SUCURSAL_ACTIVA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ACTIVA_ID", sucursal_activa_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUPERVISOR(decimal supervisor)
		{
			return DeleteBySUPERVISOR(supervisor, false);
		}

		/// <summary>
		/// Deletes records from the <c>USUARIOS</c> table using the 
		/// <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <param name="supervisorNull">true if the method ignores the supervisor
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUPERVISOR(decimal supervisor, bool supervisorNull)
		{
			return CreateDeleteBySUPERVISORCommand(supervisor, supervisorNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USUARIO_SUPERVISOR</c> foreign key.
		/// </summary>
		/// <param name="supervisor">The <c>SUPERVISOR</c> column value.</param>
		/// <param name="supervisorNull">true if the method ignores the supervisor
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUPERVISORCommand(decimal supervisor, bool supervisorNull)
		{
			string whereSql = "";
			if(supervisorNull)
				whereSql += "SUPERVISOR IS NULL";
			else
				whereSql += "SUPERVISOR=" + _db.CreateSqlParameterName("SUPERVISOR");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!supervisorNull)
				AddParameter(cmd, "SUPERVISOR", supervisor);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>USUARIOS</c> records that match the specified criteria.
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
		/// to delete <c>USUARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.USUARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>USUARIOS</c> table.
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
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		protected USUARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		protected USUARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="USUARIOSRow"/> objects.</returns>
		protected virtual USUARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int externoColumnIndex = reader.GetOrdinal("EXTERNO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int sesionColumnIndex = reader.GetOrdinal("SESION");
			int fecha_cambio_passColumnIndex = reader.GetOrdinal("FECHA_CAMBIO_PASS");
			int vida_passColumnIndex = reader.GetOrdinal("VIDA_PASS");
			int fecha_cadu_passColumnIndex = reader.GetOrdinal("FECHA_CADU_PASS");
			int ultimo_loginColumnIndex = reader.GetOrdinal("ULTIMO_LOGIN");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int sucursal_activa_idColumnIndex = reader.GetOrdinal("SUCURSAL_ACTIVA_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int supervisorColumnIndex = reader.GetOrdinal("SUPERVISOR");
			int emailColumnIndex = reader.GetOrdinal("EMAIL");
			int requerir_cambio_contrasenhaColumnIndex = reader.GetOrdinal("REQUERIR_CAMBIO_CONTRASENHA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					USUARIOSRow record = new USUARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.APELLIDO = Convert.ToString(reader.GetValue(apellidoColumnIndex));
					if(!reader.IsDBNull(externoColumnIndex))
						record.EXTERNO = Convert.ToString(reader.GetValue(externoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(sesionColumnIndex))
						record.SESION = Math.Round(Convert.ToDecimal(reader.GetValue(sesionColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_cambio_passColumnIndex))
						record.FECHA_CAMBIO_PASS = Convert.ToDateTime(reader.GetValue(fecha_cambio_passColumnIndex));
					record.VIDA_PASS = Math.Round(Convert.ToDecimal(reader.GetValue(vida_passColumnIndex)), 9);
					record.FECHA_CADU_PASS = Convert.ToDateTime(reader.GetValue(fecha_cadu_passColumnIndex));
					if(!reader.IsDBNull(ultimo_loginColumnIndex))
						record.ULTIMO_LOGIN = Convert.ToDateTime(reader.GetValue(ultimo_loginColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.SUCURSAL_ACTIVA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_activa_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(supervisorColumnIndex))
						record.SUPERVISOR = Math.Round(Convert.ToDecimal(reader.GetValue(supervisorColumnIndex)), 9);
					record.EMAIL = Convert.ToString(reader.GetValue(emailColumnIndex));
					record.REQUERIR_CAMBIO_CONTRASENHA = Convert.ToString(reader.GetValue(requerir_cambio_contrasenhaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (USUARIOSRow[])(recordList.ToArray(typeof(USUARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="USUARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="USUARIOSRow"/> object.</returns>
		protected virtual USUARIOSRow MapRow(DataRow row)
		{
			USUARIOSRow mappedObject = new USUARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "APELLIDO"
			dataColumn = dataTable.Columns["APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APELLIDO = (string)row[dataColumn];
			// Column "EXTERNO"
			dataColumn = dataTable.Columns["EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXTERNO = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "SESION"
			dataColumn = dataTable.Columns["SESION"];
			if(!row.IsNull(dataColumn))
				mappedObject.SESION = (decimal)row[dataColumn];
			// Column "FECHA_CAMBIO_PASS"
			dataColumn = dataTable.Columns["FECHA_CAMBIO_PASS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CAMBIO_PASS = (System.DateTime)row[dataColumn];
			// Column "VIDA_PASS"
			dataColumn = dataTable.Columns["VIDA_PASS"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIDA_PASS = (decimal)row[dataColumn];
			// Column "FECHA_CADU_PASS"
			dataColumn = dataTable.Columns["FECHA_CADU_PASS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CADU_PASS = (System.DateTime)row[dataColumn];
			// Column "ULTIMO_LOGIN"
			dataColumn = dataTable.Columns["ULTIMO_LOGIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ULTIMO_LOGIN = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "SUCURSAL_ACTIVA_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ACTIVA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ACTIVA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "SUPERVISOR"
			dataColumn = dataTable.Columns["SUPERVISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUPERVISOR = (decimal)row[dataColumn];
			// Column "EMAIL"
			dataColumn = dataTable.Columns["EMAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL = (string)row[dataColumn];
			// Column "REQUERIR_CAMBIO_CONTRASENHA"
			dataColumn = dataTable.Columns["REQUERIR_CAMBIO_CONTRASENHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.REQUERIR_CAMBIO_CONTRASENHA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "USUARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EXTERNO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SESION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CAMBIO_PASS", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VIDA_PASS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CADU_PASS", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ULTIMO_LOGIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ACTIVA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUPERVISOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EMAIL", typeof(string));
			dataColumn.MaxLength = 255;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REQUERIR_CAMBIO_CONTRASENHA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SESION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CAMBIO_PASS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VIDA_PASS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CADU_PASS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ULTIMO_LOGIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUCURSAL_ACTIVA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUPERVISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REQUERIR_CAMBIO_CONTRASENHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of USUARIOSCollection_Base class
}  // End of namespace
