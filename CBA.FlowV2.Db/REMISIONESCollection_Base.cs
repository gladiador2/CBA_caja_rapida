// <fileinfo name="REMISIONESCollection_Base.cs">
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
	/// The base class for <see cref="REMISIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REMISIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REMISIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FECHA_INICIO_TRASLADOColumnName = "FECHA_INICIO_TRASLADO";
		public const string FECHA_FIN_TRASLADOColumnName = "FECHA_FIN_TRASLADO";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NRO_COMPROBANTE_SECUENCIAColumnName = "NRO_COMPROBANTE_SECUENCIA";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string VEHICULO_MARCAColumnName = "VEHICULO_MARCA";
		public const string VEHICULO_MATRICULAColumnName = "VEHICULO_MATRICULA";
		public const string FUNCIONARIO_CHOFER_IDColumnName = "FUNCIONARIO_CHOFER_ID";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_NRO_DOCUMENTOColumnName = "CHOFER_NRO_DOCUMENTO";
		public const string FUNCIONARIO_ACOMPANHANTE1_IDColumnName = "FUNCIONARIO_ACOMPANHANTE1_ID";
		public const string FUNCIONARIO_ACOMPANHANTE2_IDColumnName = "FUNCIONARIO_ACOMPANHANTE2_ID";
		public const string PROVEEDOR_ENTREGA_IDColumnName = "PROVEEDOR_ENTREGA_ID";
		public const string DIRECCION_DESTINOColumnName = "DIRECCION_DESTINO";
		public const string DEPARTAMENTO_DESTINO_IDColumnName = "DEPARTAMENTO_DESTINO_ID";
		public const string CIUDAD_DESTINO_IDColumnName = "CIUDAD_DESTINO_ID";
		public const string BARRIO_DESTINO_IDColumnName = "BARRIO_DESTINO_ID";
		public const string LATITUD_DESTINOColumnName = "LATITUD_DESTINO";
		public const string LONGITUD_DESTINOColumnName = "LONGITUD_DESTINO";
		public const string DIRECCION_ORIGENColumnName = "DIRECCION_ORIGEN";
		public const string DEPARTAMENTO_ORIGEN_IDColumnName = "DEPARTAMENTO_ORIGEN_ID";
		public const string CIUDAD_ORIGEN_IDColumnName = "CIUDAD_ORIGEN_ID";
		public const string BARRIO_ORIGEN_IDColumnName = "BARRIO_ORIGEN_ID";
		public const string LATITUD_ORIGENColumnName = "LATITUD_ORIGEN";
		public const string LONGITUD_ORIGENColumnName = "LONGITUD_ORIGEN";
		public const string OBSERACIONColumnName = "OBSERACION";
		public const string OBSERACION_ENTREGAColumnName = "OBSERACION_ENTREGA";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string IMPRESOColumnName = "IMPRESO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REMISIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REMISIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REMISIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REMISIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REMISIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REMISIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REMISIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REMISIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REMISIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByBARRIO_DESTINO_ID(decimal barrio_destino_id)
		{
			return GetByBARRIO_DESTINO_ID(barrio_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <param name="barrio_destino_idNull">true if the method ignores the barrio_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByBARRIO_DESTINO_ID(decimal barrio_destino_id, bool barrio_destino_idNull)
		{
			return MapRecords(CreateGetByBARRIO_DESTINO_IDCommand(barrio_destino_id, barrio_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_DESTINO_IDAsDataTable(decimal barrio_destino_id)
		{
			return GetByBARRIO_DESTINO_IDAsDataTable(barrio_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <param name="barrio_destino_idNull">true if the method ignores the barrio_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO_DESTINO_IDAsDataTable(decimal barrio_destino_id, bool barrio_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO_DESTINO_IDCommand(barrio_destino_id, barrio_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <param name="barrio_destino_idNull">true if the method ignores the barrio_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO_DESTINO_IDCommand(decimal barrio_destino_id, bool barrio_destino_idNull)
		{
			string whereSql = "";
			if(barrio_destino_idNull)
				whereSql += "BARRIO_DESTINO_ID IS NULL";
			else
				whereSql += "BARRIO_DESTINO_ID=" + _db.CreateSqlParameterName("BARRIO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio_destino_idNull)
				AddParameter(cmd, "BARRIO_DESTINO_ID", barrio_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByBARRIO_ORIGEN_ID(decimal barrio_origen_id)
		{
			return GetByBARRIO_ORIGEN_ID(barrio_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <param name="barrio_origen_idNull">true if the method ignores the barrio_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByBARRIO_ORIGEN_ID(decimal barrio_origen_id, bool barrio_origen_idNull)
		{
			return MapRecords(CreateGetByBARRIO_ORIGEN_IDCommand(barrio_origen_id, barrio_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_ORIGEN_IDAsDataTable(decimal barrio_origen_id)
		{
			return GetByBARRIO_ORIGEN_IDAsDataTable(barrio_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <param name="barrio_origen_idNull">true if the method ignores the barrio_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO_ORIGEN_IDAsDataTable(decimal barrio_origen_id, bool barrio_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO_ORIGEN_IDCommand(barrio_origen_id, barrio_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <param name="barrio_origen_idNull">true if the method ignores the barrio_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO_ORIGEN_IDCommand(decimal barrio_origen_id, bool barrio_origen_idNull)
		{
			string whereSql = "";
			if(barrio_origen_idNull)
				whereSql += "BARRIO_ORIGEN_ID IS NULL";
			else
				whereSql += "BARRIO_ORIGEN_ID=" + _db.CreateSqlParameterName("BARRIO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio_origen_idNull)
				AddParameter(cmd, "BARRIO_ORIGEN_ID", barrio_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByCIUDAD_DESTINO_ID(decimal ciudad_destino_id)
		{
			return GetByCIUDAD_DESTINO_ID(ciudad_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <param name="ciudad_destino_idNull">true if the method ignores the ciudad_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByCIUDAD_DESTINO_ID(decimal ciudad_destino_id, bool ciudad_destino_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_DESTINO_IDCommand(ciudad_destino_id, ciudad_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_DESTINO_IDAsDataTable(decimal ciudad_destino_id)
		{
			return GetByCIUDAD_DESTINO_IDAsDataTable(ciudad_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <param name="ciudad_destino_idNull">true if the method ignores the ciudad_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_DESTINO_IDAsDataTable(decimal ciudad_destino_id, bool ciudad_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_DESTINO_IDCommand(ciudad_destino_id, ciudad_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <param name="ciudad_destino_idNull">true if the method ignores the ciudad_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_DESTINO_IDCommand(decimal ciudad_destino_id, bool ciudad_destino_idNull)
		{
			string whereSql = "";
			if(ciudad_destino_idNull)
				whereSql += "CIUDAD_DESTINO_ID IS NULL";
			else
				whereSql += "CIUDAD_DESTINO_ID=" + _db.CreateSqlParameterName("CIUDAD_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_destino_idNull)
				AddParameter(cmd, "CIUDAD_DESTINO_ID", ciudad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByCIUDAD_ORIGEN_ID(decimal ciudad_origen_id)
		{
			return GetByCIUDAD_ORIGEN_ID(ciudad_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <param name="ciudad_origen_idNull">true if the method ignores the ciudad_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByCIUDAD_ORIGEN_ID(decimal ciudad_origen_id, bool ciudad_origen_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_ORIGEN_IDCommand(ciudad_origen_id, ciudad_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_ORIGEN_IDAsDataTable(decimal ciudad_origen_id)
		{
			return GetByCIUDAD_ORIGEN_IDAsDataTable(ciudad_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <param name="ciudad_origen_idNull">true if the method ignores the ciudad_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_ORIGEN_IDAsDataTable(decimal ciudad_origen_id, bool ciudad_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_ORIGEN_IDCommand(ciudad_origen_id, ciudad_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <param name="ciudad_origen_idNull">true if the method ignores the ciudad_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_ORIGEN_IDCommand(decimal ciudad_origen_id, bool ciudad_origen_idNull)
		{
			string whereSql = "";
			if(ciudad_origen_idNull)
				whereSql += "CIUDAD_ORIGEN_ID IS NULL";
			else
				whereSql += "CIUDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("CIUDAD_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_origen_idNull)
				AddParameter(cmd, "CIUDAD_ORIGEN_ID", ciudad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByDEPARTAMENTO_DESTINO_ID(decimal departamento_destino_id)
		{
			return GetByDEPARTAMENTO_DESTINO_ID(departamento_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <param name="departamento_destino_idNull">true if the method ignores the departamento_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByDEPARTAMENTO_DESTINO_ID(decimal departamento_destino_id, bool departamento_destino_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_DESTINO_IDCommand(departamento_destino_id, departamento_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_DESTINO_IDAsDataTable(decimal departamento_destino_id)
		{
			return GetByDEPARTAMENTO_DESTINO_IDAsDataTable(departamento_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <param name="departamento_destino_idNull">true if the method ignores the departamento_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_DESTINO_IDAsDataTable(decimal departamento_destino_id, bool departamento_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_DESTINO_IDCommand(departamento_destino_id, departamento_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <param name="departamento_destino_idNull">true if the method ignores the departamento_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_DESTINO_IDCommand(decimal departamento_destino_id, bool departamento_destino_idNull)
		{
			string whereSql = "";
			if(departamento_destino_idNull)
				whereSql += "DEPARTAMENTO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_destino_idNull)
				AddParameter(cmd, "DEPARTAMENTO_DESTINO_ID", departamento_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByDEPARTAMENTO_ORIGEN_ID(decimal departamento_origen_id)
		{
			return GetByDEPARTAMENTO_ORIGEN_ID(departamento_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <param name="departamento_origen_idNull">true if the method ignores the departamento_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByDEPARTAMENTO_ORIGEN_ID(decimal departamento_origen_id, bool departamento_origen_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_ORIGEN_IDCommand(departamento_origen_id, departamento_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_ORIGEN_IDAsDataTable(decimal departamento_origen_id)
		{
			return GetByDEPARTAMENTO_ORIGEN_IDAsDataTable(departamento_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <param name="departamento_origen_idNull">true if the method ignores the departamento_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_ORIGEN_IDAsDataTable(decimal departamento_origen_id, bool departamento_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_ORIGEN_IDCommand(departamento_origen_id, departamento_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <param name="departamento_origen_idNull">true if the method ignores the departamento_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_ORIGEN_IDCommand(decimal departamento_origen_id, bool departamento_origen_idNull)
		{
			string whereSql = "";
			if(departamento_origen_idNull)
				whereSql += "DEPARTAMENTO_ORIGEN_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ORIGEN_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_origen_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ORIGEN_ID", departamento_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByFUNCIONARIO_ACOMPANHANTE1_ID(decimal funcionario_acompanhante1_id)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE1_ID(funcionario_acompanhante1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante1_idNull">true if the method ignores the funcionario_acompanhante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByFUNCIONARIO_ACOMPANHANTE1_ID(decimal funcionario_acompanhante1_id, bool funcionario_acompanhante1_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ACOMPANHANTE1_IDCommand(funcionario_acompanhante1_id, funcionario_acompanhante1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ACOMPANHANTE1_IDAsDataTable(decimal funcionario_acompanhante1_id)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE1_IDAsDataTable(funcionario_acompanhante1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante1_idNull">true if the method ignores the funcionario_acompanhante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ACOMPANHANTE1_IDAsDataTable(decimal funcionario_acompanhante1_id, bool funcionario_acompanhante1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ACOMPANHANTE1_IDCommand(funcionario_acompanhante1_id, funcionario_acompanhante1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante1_idNull">true if the method ignores the funcionario_acompanhante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ACOMPANHANTE1_IDCommand(decimal funcionario_acompanhante1_id, bool funcionario_acompanhante1_idNull)
		{
			string whereSql = "";
			if(funcionario_acompanhante1_idNull)
				whereSql += "FUNCIONARIO_ACOMPANHANTE1_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE1_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_acompanhante1_idNull)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE1_ID", funcionario_acompanhante1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByFUNCIONARIO_ACOMPANHANTE2_ID(decimal funcionario_acompanhante2_id)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE2_ID(funcionario_acompanhante2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante2_idNull">true if the method ignores the funcionario_acompanhante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByFUNCIONARIO_ACOMPANHANTE2_ID(decimal funcionario_acompanhante2_id, bool funcionario_acompanhante2_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ACOMPANHANTE2_IDCommand(funcionario_acompanhante2_id, funcionario_acompanhante2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ACOMPANHANTE2_IDAsDataTable(decimal funcionario_acompanhante2_id)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE2_IDAsDataTable(funcionario_acompanhante2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante2_idNull">true if the method ignores the funcionario_acompanhante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ACOMPANHANTE2_IDAsDataTable(decimal funcionario_acompanhante2_id, bool funcionario_acompanhante2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ACOMPANHANTE2_IDCommand(funcionario_acompanhante2_id, funcionario_acompanhante2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante2_idNull">true if the method ignores the funcionario_acompanhante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ACOMPANHANTE2_IDCommand(decimal funcionario_acompanhante2_id, bool funcionario_acompanhante2_idNull)
		{
			string whereSql = "";
			if(funcionario_acompanhante2_idNull)
				whereSql += "FUNCIONARIO_ACOMPANHANTE2_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE2_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_acompanhante2_idNull)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE2_ID", funcionario_acompanhante2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_IDAsDataTable(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
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
		/// return records by the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
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
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_REMISIONES_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByPROVEEDOR_ENTREGA_ID(decimal proveedor_entrega_id)
		{
			return GetByPROVEEDOR_ENTREGA_ID(proveedor_entrega_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <param name="proveedor_entrega_idNull">true if the method ignores the proveedor_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByPROVEEDOR_ENTREGA_ID(decimal proveedor_entrega_id, bool proveedor_entrega_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_ENTREGA_IDCommand(proveedor_entrega_id, proveedor_entrega_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_ENTREGA_IDAsDataTable(decimal proveedor_entrega_id)
		{
			return GetByPROVEEDOR_ENTREGA_IDAsDataTable(proveedor_entrega_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <param name="proveedor_entrega_idNull">true if the method ignores the proveedor_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_ENTREGA_IDAsDataTable(decimal proveedor_entrega_id, bool proveedor_entrega_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_ENTREGA_IDCommand(proveedor_entrega_id, proveedor_entrega_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <param name="proveedor_entrega_idNull">true if the method ignores the proveedor_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_ENTREGA_IDCommand(decimal proveedor_entrega_id, bool proveedor_entrega_idNull)
		{
			string whereSql = "";
			if(proveedor_entrega_idNull)
				whereSql += "PROVEEDOR_ENTREGA_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ENTREGA_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ENTREGA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_entrega_idNull)
				AddParameter(cmd, "PROVEEDOR_ENTREGA_ID", proveedor_entrega_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public REMISIONESRow[] GetByVEHICULO_ID(decimal vehiculo_id)
		{
			return GetByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REMISIONESRow"/> objects 
		/// by the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		public virtual REMISIONESRow[] GetByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecords(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id)
		{
			return GetByVEHICULO_IDAsDataTable(vehiculo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REMISIONESRow"/> object to be inserted.</param>
		public virtual void Insert(REMISIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REMISIONES (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"PERSONA_ID, " +
				"FUNCIONARIO_ID, " +
				"FECHA, " +
				"FECHA_INICIO_TRASLADO, " +
				"FECHA_FIN_TRASLADO, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"NRO_COMPROBANTE_SECUENCIA, " +
				"NRO_COMPROBANTE_EXTERNO, " +
				"VEHICULO_ID, " +
				"VEHICULO_MARCA, " +
				"VEHICULO_MATRICULA, " +
				"FUNCIONARIO_CHOFER_ID, " +
				"CHOFER_NOMBRE, " +
				"CHOFER_NRO_DOCUMENTO, " +
				"FUNCIONARIO_ACOMPANHANTE1_ID, " +
				"FUNCIONARIO_ACOMPANHANTE2_ID, " +
				"PROVEEDOR_ENTREGA_ID, " +
				"DIRECCION_DESTINO, " +
				"DEPARTAMENTO_DESTINO_ID, " +
				"CIUDAD_DESTINO_ID, " +
				"BARRIO_DESTINO_ID, " +
				"LATITUD_DESTINO, " +
				"LONGITUD_DESTINO, " +
				"DIRECCION_ORIGEN, " +
				"DEPARTAMENTO_ORIGEN_ID, " +
				"CIUDAD_ORIGEN_ID, " +
				"BARRIO_ORIGEN_ID, " +
				"LATITUD_ORIGEN, " +
				"LONGITUD_ORIGEN, " +
				"OBSERACION, " +
				"OBSERACION_ENTREGA, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"ESTADO, " +
				"IMPRESO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO_TRASLADO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN_TRASLADO") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_SECUENCIA") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ", " +
				_db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("VEHICULO_MARCA") + ", " +
				_db.CreateSqlParameterName("VEHICULO_MATRICULA") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CHOFER_NRO_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE1_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE2_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ENTREGA_ID") + ", " +
				_db.CreateSqlParameterName("DIRECCION_DESTINO") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("LATITUD_DESTINO") + ", " +
				_db.CreateSqlParameterName("LONGITUD_DESTINO") + ", " +
				_db.CreateSqlParameterName("DIRECCION_ORIGEN") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("LATITUD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("LONGITUD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("OBSERACION") + ", " +
				_db.CreateSqlParameterName("OBSERACION_ENTREGA") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("IMPRESO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FECHA_INICIO_TRASLADO",
				value.IsFECHA_INICIO_TRASLADONull ? DBNull.Value : (object)value.FECHA_INICIO_TRASLADO);
			AddParameter(cmd, "FECHA_FIN_TRASLADO",
				value.IsFECHA_FIN_TRASLADONull ? DBNull.Value : (object)value.FECHA_FIN_TRASLADO);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NRO_COMPROBANTE_SECUENCIA",
				value.IsNRO_COMPROBANTE_SECUENCIANull ? DBNull.Value : (object)value.NRO_COMPROBANTE_SECUENCIA);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "VEHICULO_MARCA", value.VEHICULO_MARCA);
			AddParameter(cmd, "VEHICULO_MATRICULA", value.VEHICULO_MATRICULA);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_NRO_DOCUMENTO", value.CHOFER_NRO_DOCUMENTO);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE1_ID",
				value.IsFUNCIONARIO_ACOMPANHANTE1_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE1_ID);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE2_ID",
				value.IsFUNCIONARIO_ACOMPANHANTE2_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE2_ID);
			AddParameter(cmd, "PROVEEDOR_ENTREGA_ID",
				value.IsPROVEEDOR_ENTREGA_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ENTREGA_ID);
			AddParameter(cmd, "DIRECCION_DESTINO", value.DIRECCION_DESTINO);
			AddParameter(cmd, "DEPARTAMENTO_DESTINO_ID",
				value.IsDEPARTAMENTO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_DESTINO_ID);
			AddParameter(cmd, "CIUDAD_DESTINO_ID",
				value.IsCIUDAD_DESTINO_IDNull ? DBNull.Value : (object)value.CIUDAD_DESTINO_ID);
			AddParameter(cmd, "BARRIO_DESTINO_ID",
				value.IsBARRIO_DESTINO_IDNull ? DBNull.Value : (object)value.BARRIO_DESTINO_ID);
			AddParameter(cmd, "LATITUD_DESTINO",
				value.IsLATITUD_DESTINONull ? DBNull.Value : (object)value.LATITUD_DESTINO);
			AddParameter(cmd, "LONGITUD_DESTINO",
				value.IsLONGITUD_DESTINONull ? DBNull.Value : (object)value.LONGITUD_DESTINO);
			AddParameter(cmd, "DIRECCION_ORIGEN", value.DIRECCION_ORIGEN);
			AddParameter(cmd, "DEPARTAMENTO_ORIGEN_ID",
				value.IsDEPARTAMENTO_ORIGEN_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ORIGEN_ID);
			AddParameter(cmd, "CIUDAD_ORIGEN_ID",
				value.IsCIUDAD_ORIGEN_IDNull ? DBNull.Value : (object)value.CIUDAD_ORIGEN_ID);
			AddParameter(cmd, "BARRIO_ORIGEN_ID",
				value.IsBARRIO_ORIGEN_IDNull ? DBNull.Value : (object)value.BARRIO_ORIGEN_ID);
			AddParameter(cmd, "LATITUD_ORIGEN",
				value.IsLATITUD_ORIGENNull ? DBNull.Value : (object)value.LATITUD_ORIGEN);
			AddParameter(cmd, "LONGITUD_ORIGEN",
				value.IsLONGITUD_ORIGENNull ? DBNull.Value : (object)value.LONGITUD_ORIGEN);
			AddParameter(cmd, "OBSERACION", value.OBSERACION);
			AddParameter(cmd, "OBSERACION_ENTREGA", value.OBSERACION_ENTREGA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REMISIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REMISIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.REMISIONES SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"FECHA_INICIO_TRASLADO=" + _db.CreateSqlParameterName("FECHA_INICIO_TRASLADO") + ", " +
				"FECHA_FIN_TRASLADO=" + _db.CreateSqlParameterName("FECHA_FIN_TRASLADO") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"NRO_COMPROBANTE_SECUENCIA=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_SECUENCIA") + ", " +
				"NRO_COMPROBANTE_EXTERNO=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_EXTERNO") + ", " +
				"VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				"VEHICULO_MARCA=" + _db.CreateSqlParameterName("VEHICULO_MARCA") + ", " +
				"VEHICULO_MATRICULA=" + _db.CreateSqlParameterName("VEHICULO_MATRICULA") + ", " +
				"FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"CHOFER_NRO_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_NRO_DOCUMENTO") + ", " +
				"FUNCIONARIO_ACOMPANHANTE1_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE1_ID") + ", " +
				"FUNCIONARIO_ACOMPANHANTE2_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE2_ID") + ", " +
				"PROVEEDOR_ENTREGA_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ENTREGA_ID") + ", " +
				"DIRECCION_DESTINO=" + _db.CreateSqlParameterName("DIRECCION_DESTINO") + ", " +
				"DEPARTAMENTO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_DESTINO_ID") + ", " +
				"CIUDAD_DESTINO_ID=" + _db.CreateSqlParameterName("CIUDAD_DESTINO_ID") + ", " +
				"BARRIO_DESTINO_ID=" + _db.CreateSqlParameterName("BARRIO_DESTINO_ID") + ", " +
				"LATITUD_DESTINO=" + _db.CreateSqlParameterName("LATITUD_DESTINO") + ", " +
				"LONGITUD_DESTINO=" + _db.CreateSqlParameterName("LONGITUD_DESTINO") + ", " +
				"DIRECCION_ORIGEN=" + _db.CreateSqlParameterName("DIRECCION_ORIGEN") + ", " +
				"DEPARTAMENTO_ORIGEN_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ORIGEN_ID") + ", " +
				"CIUDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("CIUDAD_ORIGEN_ID") + ", " +
				"BARRIO_ORIGEN_ID=" + _db.CreateSqlParameterName("BARRIO_ORIGEN_ID") + ", " +
				"LATITUD_ORIGEN=" + _db.CreateSqlParameterName("LATITUD_ORIGEN") + ", " +
				"LONGITUD_ORIGEN=" + _db.CreateSqlParameterName("LONGITUD_ORIGEN") + ", " +
				"OBSERACION=" + _db.CreateSqlParameterName("OBSERACION") + ", " +
				"OBSERACION_ENTREGA=" + _db.CreateSqlParameterName("OBSERACION_ENTREGA") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"IMPRESO=" + _db.CreateSqlParameterName("IMPRESO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FECHA_INICIO_TRASLADO",
				value.IsFECHA_INICIO_TRASLADONull ? DBNull.Value : (object)value.FECHA_INICIO_TRASLADO);
			AddParameter(cmd, "FECHA_FIN_TRASLADO",
				value.IsFECHA_FIN_TRASLADONull ? DBNull.Value : (object)value.FECHA_FIN_TRASLADO);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NRO_COMPROBANTE_SECUENCIA",
				value.IsNRO_COMPROBANTE_SECUENCIANull ? DBNull.Value : (object)value.NRO_COMPROBANTE_SECUENCIA);
			AddParameter(cmd, "NRO_COMPROBANTE_EXTERNO", value.NRO_COMPROBANTE_EXTERNO);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "VEHICULO_MARCA", value.VEHICULO_MARCA);
			AddParameter(cmd, "VEHICULO_MATRICULA", value.VEHICULO_MATRICULA);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_NRO_DOCUMENTO", value.CHOFER_NRO_DOCUMENTO);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE1_ID",
				value.IsFUNCIONARIO_ACOMPANHANTE1_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE1_ID);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE2_ID",
				value.IsFUNCIONARIO_ACOMPANHANTE2_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE2_ID);
			AddParameter(cmd, "PROVEEDOR_ENTREGA_ID",
				value.IsPROVEEDOR_ENTREGA_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ENTREGA_ID);
			AddParameter(cmd, "DIRECCION_DESTINO", value.DIRECCION_DESTINO);
			AddParameter(cmd, "DEPARTAMENTO_DESTINO_ID",
				value.IsDEPARTAMENTO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_DESTINO_ID);
			AddParameter(cmd, "CIUDAD_DESTINO_ID",
				value.IsCIUDAD_DESTINO_IDNull ? DBNull.Value : (object)value.CIUDAD_DESTINO_ID);
			AddParameter(cmd, "BARRIO_DESTINO_ID",
				value.IsBARRIO_DESTINO_IDNull ? DBNull.Value : (object)value.BARRIO_DESTINO_ID);
			AddParameter(cmd, "LATITUD_DESTINO",
				value.IsLATITUD_DESTINONull ? DBNull.Value : (object)value.LATITUD_DESTINO);
			AddParameter(cmd, "LONGITUD_DESTINO",
				value.IsLONGITUD_DESTINONull ? DBNull.Value : (object)value.LONGITUD_DESTINO);
			AddParameter(cmd, "DIRECCION_ORIGEN", value.DIRECCION_ORIGEN);
			AddParameter(cmd, "DEPARTAMENTO_ORIGEN_ID",
				value.IsDEPARTAMENTO_ORIGEN_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ORIGEN_ID);
			AddParameter(cmd, "CIUDAD_ORIGEN_ID",
				value.IsCIUDAD_ORIGEN_IDNull ? DBNull.Value : (object)value.CIUDAD_ORIGEN_ID);
			AddParameter(cmd, "BARRIO_ORIGEN_ID",
				value.IsBARRIO_ORIGEN_IDNull ? DBNull.Value : (object)value.BARRIO_ORIGEN_ID);
			AddParameter(cmd, "LATITUD_ORIGEN",
				value.IsLATITUD_ORIGENNull ? DBNull.Value : (object)value.LATITUD_ORIGEN);
			AddParameter(cmd, "LONGITUD_ORIGEN",
				value.IsLONGITUD_ORIGENNull ? DBNull.Value : (object)value.LONGITUD_ORIGEN);
			AddParameter(cmd, "OBSERACION", value.OBSERACION);
			AddParameter(cmd, "OBSERACION_ENTREGA", value.OBSERACION_ENTREGA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REMISIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REMISIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REMISIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REMISIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REMISIONES</c> table using
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
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_AUTONUMERACION</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_DESTINO_ID(decimal barrio_destino_id)
		{
			return DeleteByBARRIO_DESTINO_ID(barrio_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <param name="barrio_destino_idNull">true if the method ignores the barrio_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_DESTINO_ID(decimal barrio_destino_id, bool barrio_destino_idNull)
		{
			return CreateDeleteByBARRIO_DESTINO_IDCommand(barrio_destino_id, barrio_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_BARRIO_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="barrio_destino_id">The <c>BARRIO_DESTINO_ID</c> column value.</param>
		/// <param name="barrio_destino_idNull">true if the method ignores the barrio_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO_DESTINO_IDCommand(decimal barrio_destino_id, bool barrio_destino_idNull)
		{
			string whereSql = "";
			if(barrio_destino_idNull)
				whereSql += "BARRIO_DESTINO_ID IS NULL";
			else
				whereSql += "BARRIO_DESTINO_ID=" + _db.CreateSqlParameterName("BARRIO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio_destino_idNull)
				AddParameter(cmd, "BARRIO_DESTINO_ID", barrio_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ORIGEN_ID(decimal barrio_origen_id)
		{
			return DeleteByBARRIO_ORIGEN_ID(barrio_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <param name="barrio_origen_idNull">true if the method ignores the barrio_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ORIGEN_ID(decimal barrio_origen_id, bool barrio_origen_idNull)
		{
			return CreateDeleteByBARRIO_ORIGEN_IDCommand(barrio_origen_id, barrio_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_BARRIO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="barrio_origen_id">The <c>BARRIO_ORIGEN_ID</c> column value.</param>
		/// <param name="barrio_origen_idNull">true if the method ignores the barrio_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO_ORIGEN_IDCommand(decimal barrio_origen_id, bool barrio_origen_idNull)
		{
			string whereSql = "";
			if(barrio_origen_idNull)
				whereSql += "BARRIO_ORIGEN_ID IS NULL";
			else
				whereSql += "BARRIO_ORIGEN_ID=" + _db.CreateSqlParameterName("BARRIO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio_origen_idNull)
				AddParameter(cmd, "BARRIO_ORIGEN_ID", barrio_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_DESTINO_ID(decimal ciudad_destino_id)
		{
			return DeleteByCIUDAD_DESTINO_ID(ciudad_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <param name="ciudad_destino_idNull">true if the method ignores the ciudad_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_DESTINO_ID(decimal ciudad_destino_id, bool ciudad_destino_idNull)
		{
			return CreateDeleteByCIUDAD_DESTINO_IDCommand(ciudad_destino_id, ciudad_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_CIUDAD_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="ciudad_destino_id">The <c>CIUDAD_DESTINO_ID</c> column value.</param>
		/// <param name="ciudad_destino_idNull">true if the method ignores the ciudad_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_DESTINO_IDCommand(decimal ciudad_destino_id, bool ciudad_destino_idNull)
		{
			string whereSql = "";
			if(ciudad_destino_idNull)
				whereSql += "CIUDAD_DESTINO_ID IS NULL";
			else
				whereSql += "CIUDAD_DESTINO_ID=" + _db.CreateSqlParameterName("CIUDAD_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_destino_idNull)
				AddParameter(cmd, "CIUDAD_DESTINO_ID", ciudad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ORIGEN_ID(decimal ciudad_origen_id)
		{
			return DeleteByCIUDAD_ORIGEN_ID(ciudad_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <param name="ciudad_origen_idNull">true if the method ignores the ciudad_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ORIGEN_ID(decimal ciudad_origen_id, bool ciudad_origen_idNull)
		{
			return CreateDeleteByCIUDAD_ORIGEN_IDCommand(ciudad_origen_id, ciudad_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_CIUDAD_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="ciudad_origen_id">The <c>CIUDAD_ORIGEN_ID</c> column value.</param>
		/// <param name="ciudad_origen_idNull">true if the method ignores the ciudad_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_ORIGEN_IDCommand(decimal ciudad_origen_id, bool ciudad_origen_idNull)
		{
			string whereSql = "";
			if(ciudad_origen_idNull)
				whereSql += "CIUDAD_ORIGEN_ID IS NULL";
			else
				whereSql += "CIUDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("CIUDAD_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_origen_idNull)
				AddParameter(cmd, "CIUDAD_ORIGEN_ID", ciudad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_DESTINO_ID(decimal departamento_destino_id)
		{
			return DeleteByDEPARTAMENTO_DESTINO_ID(departamento_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <param name="departamento_destino_idNull">true if the method ignores the departamento_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_DESTINO_ID(decimal departamento_destino_id, bool departamento_destino_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_DESTINO_IDCommand(departamento_destino_id, departamento_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_DEPART_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="departamento_destino_id">The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</param>
		/// <param name="departamento_destino_idNull">true if the method ignores the departamento_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_DESTINO_IDCommand(decimal departamento_destino_id, bool departamento_destino_idNull)
		{
			string whereSql = "";
			if(departamento_destino_idNull)
				whereSql += "DEPARTAMENTO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_destino_idNull)
				AddParameter(cmd, "DEPARTAMENTO_DESTINO_ID", departamento_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ORIGEN_ID(decimal departamento_origen_id)
		{
			return DeleteByDEPARTAMENTO_ORIGEN_ID(departamento_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <param name="departamento_origen_idNull">true if the method ignores the departamento_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ORIGEN_ID(decimal departamento_origen_id, bool departamento_origen_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_ORIGEN_IDCommand(departamento_origen_id, departamento_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_DEPART_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="departamento_origen_id">The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</param>
		/// <param name="departamento_origen_idNull">true if the method ignores the departamento_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_ORIGEN_IDCommand(decimal departamento_origen_id, bool departamento_origen_idNull)
		{
			string whereSql = "";
			if(departamento_origen_idNull)
				whereSql += "DEPARTAMENTO_ORIGEN_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ORIGEN_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_origen_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ORIGEN_ID", departamento_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE1_ID(decimal funcionario_acompanhante1_id)
		{
			return DeleteByFUNCIONARIO_ACOMPANHANTE1_ID(funcionario_acompanhante1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante1_idNull">true if the method ignores the funcionario_acompanhante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE1_ID(decimal funcionario_acompanhante1_id, bool funcionario_acompanhante1_idNull)
		{
			return CreateDeleteByFUNCIONARIO_ACOMPANHANTE1_IDCommand(funcionario_acompanhante1_id, funcionario_acompanhante1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_FUNCION_ACOMP_1</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante1_id">The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante1_idNull">true if the method ignores the funcionario_acompanhante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ACOMPANHANTE1_IDCommand(decimal funcionario_acompanhante1_id, bool funcionario_acompanhante1_idNull)
		{
			string whereSql = "";
			if(funcionario_acompanhante1_idNull)
				whereSql += "FUNCIONARIO_ACOMPANHANTE1_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE1_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_acompanhante1_idNull)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE1_ID", funcionario_acompanhante1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE2_ID(decimal funcionario_acompanhante2_id)
		{
			return DeleteByFUNCIONARIO_ACOMPANHANTE2_ID(funcionario_acompanhante2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante2_idNull">true if the method ignores the funcionario_acompanhante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE2_ID(decimal funcionario_acompanhante2_id, bool funcionario_acompanhante2_idNull)
		{
			return CreateDeleteByFUNCIONARIO_ACOMPANHANTE2_IDCommand(funcionario_acompanhante2_id, funcionario_acompanhante2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_FUNCION_ACOMP_2</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante2_id">The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</param>
		/// <param name="funcionario_acompanhante2_idNull">true if the method ignores the funcionario_acompanhante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ACOMPANHANTE2_IDCommand(decimal funcionario_acompanhante2_id, bool funcionario_acompanhante2_idNull)
		{
			string whereSql = "";
			if(funcionario_acompanhante2_idNull)
				whereSql += "FUNCIONARIO_ACOMPANHANTE2_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE2_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_acompanhante2_idNull)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE2_ID", funcionario_acompanhante2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return DeleteByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_FUNCION_CHOFER</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
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
		/// delete records using the <c>FK_REMISIONES_FUNCIONARIO</c> foreign key.
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
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_REMISIONES_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ENTREGA_ID(decimal proveedor_entrega_id)
		{
			return DeleteByPROVEEDOR_ENTREGA_ID(proveedor_entrega_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <param name="proveedor_entrega_idNull">true if the method ignores the proveedor_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ENTREGA_ID(decimal proveedor_entrega_id, bool proveedor_entrega_idNull)
		{
			return CreateDeleteByPROVEEDOR_ENTREGA_IDCommand(proveedor_entrega_id, proveedor_entrega_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_PROVEED_ENTREGA</c> foreign key.
		/// </summary>
		/// <param name="proveedor_entrega_id">The <c>PROVEEDOR_ENTREGA_ID</c> column value.</param>
		/// <param name="proveedor_entrega_idNull">true if the method ignores the proveedor_entrega_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_ENTREGA_IDCommand(decimal proveedor_entrega_id, bool proveedor_entrega_idNull)
		{
			string whereSql = "";
			if(proveedor_entrega_idNull)
				whereSql += "PROVEEDOR_ENTREGA_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ENTREGA_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ENTREGA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_entrega_idNull)
				AddParameter(cmd, "PROVEEDOR_ENTREGA_ID", proveedor_entrega_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id)
		{
			return DeleteByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REMISIONES</c> table using the 
		/// <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return CreateDeleteByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REMISIONES_VEHICULO</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REMISIONES</c> records that match the specified criteria.
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
		/// to delete <c>REMISIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REMISIONES</c> table.
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
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		protected REMISIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		protected REMISIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REMISIONESRow"/> objects.</returns>
		protected virtual REMISIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int fecha_inicio_trasladoColumnIndex = reader.GetOrdinal("FECHA_INICIO_TRASLADO");
			int fecha_fin_trasladoColumnIndex = reader.GetOrdinal("FECHA_FIN_TRASLADO");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int nro_comprobante_secuenciaColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_SECUENCIA");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int vehiculo_marcaColumnIndex = reader.GetOrdinal("VEHICULO_MARCA");
			int vehiculo_matriculaColumnIndex = reader.GetOrdinal("VEHICULO_MATRICULA");
			int funcionario_chofer_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_ID");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_nro_documentoColumnIndex = reader.GetOrdinal("CHOFER_NRO_DOCUMENTO");
			int funcionario_acompanhante1_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE1_ID");
			int funcionario_acompanhante2_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE2_ID");
			int proveedor_entrega_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ENTREGA_ID");
			int direccion_destinoColumnIndex = reader.GetOrdinal("DIRECCION_DESTINO");
			int departamento_destino_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_DESTINO_ID");
			int ciudad_destino_idColumnIndex = reader.GetOrdinal("CIUDAD_DESTINO_ID");
			int barrio_destino_idColumnIndex = reader.GetOrdinal("BARRIO_DESTINO_ID");
			int latitud_destinoColumnIndex = reader.GetOrdinal("LATITUD_DESTINO");
			int longitud_destinoColumnIndex = reader.GetOrdinal("LONGITUD_DESTINO");
			int direccion_origenColumnIndex = reader.GetOrdinal("DIRECCION_ORIGEN");
			int departamento_origen_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ORIGEN_ID");
			int ciudad_origen_idColumnIndex = reader.GetOrdinal("CIUDAD_ORIGEN_ID");
			int barrio_origen_idColumnIndex = reader.GetOrdinal("BARRIO_ORIGEN_ID");
			int latitud_origenColumnIndex = reader.GetOrdinal("LATITUD_ORIGEN");
			int longitud_origenColumnIndex = reader.GetOrdinal("LONGITUD_ORIGEN");
			int obseracionColumnIndex = reader.GetOrdinal("OBSERACION");
			int obseracion_entregaColumnIndex = reader.GetOrdinal("OBSERACION_ENTREGA");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REMISIONESRow record = new REMISIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(fecha_inicio_trasladoColumnIndex))
						record.FECHA_INICIO_TRASLADO = Convert.ToDateTime(reader.GetValue(fecha_inicio_trasladoColumnIndex));
					if(!reader.IsDBNull(fecha_fin_trasladoColumnIndex))
						record.FECHA_FIN_TRASLADO = Convert.ToDateTime(reader.GetValue(fecha_fin_trasladoColumnIndex));
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_secuenciaColumnIndex))
						record.NRO_COMPROBANTE_SECUENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_comprobante_secuenciaColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(vehiculo_marcaColumnIndex))
						record.VEHICULO_MARCA = Convert.ToString(reader.GetValue(vehiculo_marcaColumnIndex));
					if(!reader.IsDBNull(vehiculo_matriculaColumnIndex))
						record.VEHICULO_MATRICULA = Convert.ToString(reader.GetValue(vehiculo_matriculaColumnIndex));
					if(!reader.IsDBNull(funcionario_chofer_idColumnIndex))
						record.FUNCIONARIO_CHOFER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_chofer_idColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_nro_documentoColumnIndex))
						record.CHOFER_NRO_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_nro_documentoColumnIndex));
					if(!reader.IsDBNull(funcionario_acompanhante1_idColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante1_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_acompanhante2_idColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante2_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_entrega_idColumnIndex))
						record.PROVEEDOR_ENTREGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_entrega_idColumnIndex)), 9);
					if(!reader.IsDBNull(direccion_destinoColumnIndex))
						record.DIRECCION_DESTINO = Convert.ToString(reader.GetValue(direccion_destinoColumnIndex));
					if(!reader.IsDBNull(departamento_destino_idColumnIndex))
						record.DEPARTAMENTO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_destino_idColumnIndex))
						record.CIUDAD_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_destino_idColumnIndex))
						record.BARRIO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(latitud_destinoColumnIndex))
						record.LATITUD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_destinoColumnIndex))
						record.LONGITUD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(direccion_origenColumnIndex))
						record.DIRECCION_ORIGEN = Convert.ToString(reader.GetValue(direccion_origenColumnIndex));
					if(!reader.IsDBNull(departamento_origen_idColumnIndex))
						record.DEPARTAMENTO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_origen_idColumnIndex))
						record.CIUDAD_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_origen_idColumnIndex))
						record.BARRIO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(latitud_origenColumnIndex))
						record.LATITUD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_origenColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_origenColumnIndex))
						record.LONGITUD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_origenColumnIndex)), 9);
					if(!reader.IsDBNull(obseracionColumnIndex))
						record.OBSERACION = Convert.ToString(reader.GetValue(obseracionColumnIndex));
					if(!reader.IsDBNull(obseracion_entregaColumnIndex))
						record.OBSERACION_ENTREGA = Convert.ToString(reader.GetValue(obseracion_entregaColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REMISIONESRow[])(recordList.ToArray(typeof(REMISIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REMISIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REMISIONESRow"/> object.</returns>
		protected virtual REMISIONESRow MapRow(DataRow row)
		{
			REMISIONESRow mappedObject = new REMISIONESRow();
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
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FECHA_INICIO_TRASLADO"
			dataColumn = dataTable.Columns["FECHA_INICIO_TRASLADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO_TRASLADO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN_TRASLADO"
			dataColumn = dataTable.Columns["FECHA_FIN_TRASLADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN_TRASLADO = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE_SECUENCIA"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_SECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_SECUENCIA = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "VEHICULO_MARCA"
			dataColumn = dataTable.Columns["VEHICULO_MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MARCA = (string)row[dataColumn];
			// Column "VEHICULO_MATRICULA"
			dataColumn = dataTable.Columns["VEHICULO_MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_MATRICULA = (string)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_ID = (decimal)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_NRO_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_NRO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NRO_DOCUMENTO = (string)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE1_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE1_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE2_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE2_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ENTREGA_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ENTREGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ENTREGA_ID = (decimal)row[dataColumn];
			// Column "DIRECCION_DESTINO"
			dataColumn = dataTable.Columns["DIRECCION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_DESTINO = (string)row[dataColumn];
			// Column "DEPARTAMENTO_DESTINO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["CIUDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_DESTINO_ID = (decimal)row[dataColumn];
			// Column "BARRIO_DESTINO_ID"
			dataColumn = dataTable.Columns["BARRIO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "LATITUD_DESTINO"
			dataColumn = dataTable.Columns["LATITUD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_DESTINO = (decimal)row[dataColumn];
			// Column "LONGITUD_DESTINO"
			dataColumn = dataTable.Columns["LONGITUD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_DESTINO = (decimal)row[dataColumn];
			// Column "DIRECCION_ORIGEN"
			dataColumn = dataTable.Columns["DIRECCION_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_ORIGEN = (string)row[dataColumn];
			// Column "DEPARTAMENTO_ORIGEN_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["CIUDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "BARRIO_ORIGEN_ID"
			dataColumn = dataTable.Columns["BARRIO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "LATITUD_ORIGEN"
			dataColumn = dataTable.Columns["LATITUD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_ORIGEN = (decimal)row[dataColumn];
			// Column "LONGITUD_ORIGEN"
			dataColumn = dataTable.Columns["LONGITUD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_ORIGEN = (decimal)row[dataColumn];
			// Column "OBSERACION"
			dataColumn = dataTable.Columns["OBSERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERACION = (string)row[dataColumn];
			// Column "OBSERACION_ENTREGA"
			dataColumn = dataTable.Columns["OBSERACION_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERACION_ENTREGA = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REMISIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO_TRASLADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN_TRASLADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_SECUENCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VEHICULO_MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VEHICULO_MATRICULA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CHOFER_NRO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ENTREGA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIRECCION_DESTINO", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LATITUD_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIRECCION_ORIGEN", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LATITUD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("OBSERACION_ENTREGA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INICIO_TRASLADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN_TRASLADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE_SECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VEHICULO_MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_CHOFER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NRO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ENTREGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LATITUD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LATITUD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERACION_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REMISIONESCollection_Base class
}  // End of namespace
