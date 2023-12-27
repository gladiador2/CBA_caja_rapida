// <fileinfo name="FUNCIONARIOSCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string TRATAMIENTO_IDColumnName = "TRATAMIENTO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string APODOColumnName = "APODO";
		public const string GENEROColumnName = "GENERO";
		public const string RUCColumnName = "RUC";
		public const string NACIMIENTOColumnName = "NACIMIENTO";
		public const string TIPO_DOCUMENTO_IDENTIDAD_IDColumnName = "TIPO_DOCUMENTO_IDENTIDAD_ID";
		public const string NUMERO_DOCUMENTOColumnName = "NUMERO_DOCUMENTO";
		public const string PAIS_NACIONALIDAD_IDColumnName = "PAIS_NACIONALIDAD_ID";
		public const string PAIS_RESIDENCIA_IDColumnName = "PAIS_RESIDENCIA_ID";
		public const string PROFESION_IDColumnName = "PROFESION_ID";
		public const string DEPARTAMENTO1_IDColumnName = "DEPARTAMENTO1_ID";
		public const string CIUDAD1_IDColumnName = "CIUDAD1_ID";
		public const string BARRIO1_IDColumnName = "BARRIO1_ID";
		public const string CALLE1ColumnName = "CALLE1";
		public const string CODIGO_POSTAL1ColumnName = "CODIGO_POSTAL1";
		public const string LATITUD1ColumnName = "LATITUD1";
		public const string LONGITUD1ColumnName = "LONGITUD1";
		public const string DEPARTAMENTO2_IDColumnName = "DEPARTAMENTO2_ID";
		public const string ES_VENDEDORColumnName = "ES_VENDEDOR";
		public const string ES_COBRADORColumnName = "ES_COBRADOR";
		public const string CIUDAD2_IDColumnName = "CIUDAD2_ID";
		public const string BARRIO2_IDColumnName = "BARRIO2_ID";
		public const string CALLE2ColumnName = "CALLE2";
		public const string CODIGO_POSTAL2ColumnName = "CODIGO_POSTAL2";
		public const string LATITUD2ColumnName = "LATITUD2";
		public const string LONGITUD2ColumnName = "LONGITUD2";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string TELEFONO4ColumnName = "TELEFONO4";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string EMAIL3ColumnName = "EMAIL3";
		public const string FECHA_CONTRATACIONColumnName = "FECHA_CONTRATACION";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string MOTIVO_SALIDAColumnName = "MOTIVO_SALIDA";
		public const string ESTADO_CIVIL_IDColumnName = "ESTADO_CIVIL_ID";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string NOMBRE_FAMILIAR_CONTACTOColumnName = "NOMBRE_FAMILIAR_CONTACTO";
		public const string RELACION_FAMILIAR_CONTACTOColumnName = "RELACION_FAMILIAR_CONTACTO";
		public const string TELEFONO_FAMILIAR_CONTACTOColumnName = "TELEFONO_FAMILIAR_CONTACTO";
		public const string DEPARTAMENTO_FAMILIAR_CONT_IDColumnName = "DEPARTAMENTO_FAMILIAR_CONT_ID";
		public const string CIUDAD_FAMILIAR_CONTACTO_IDColumnName = "CIUDAD_FAMILIAR_CONTACTO_ID";
		public const string BARRIO_FAMILIAR_CONTACTO_IDColumnName = "BARRIO_FAMILIAR_CONTACTO_ID";
		public const string CALLE_FAMILIAR_CONTACTOColumnName = "CALLE_FAMILIAR_CONTACTO";
		public const string COD_POST_FAMILIAR_CONTACTOColumnName = "COD_POST_FAMILIAR_CONTACTO";
		public const string LATITUD_FAMILIAR_CONTACTOColumnName = "LATITUD_FAMILIAR_CONTACTO";
		public const string LONGITUD_FAMILIAR_CONTACTOColumnName = "LONGITUD_FAMILIAR_CONTACTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string INGRESO_SEGUROColumnName = "INGRESO_SEGURO";
		public const string SALARIO_TIPOColumnName = "SALARIO_TIPO";
		public const string COBRA_SALARIO_MINIMOColumnName = "COBRA_SALARIO_MINIMO";
		public const string SALARIOColumnName = "SALARIO";
		public const string SALARIO_COMPLEMENTARIOColumnName = "SALARIO_COMPLEMENTARIO";
		public const string SALARIO_EXTRAColumnName = "SALARIO_EXTRA";
		public const string COBRA_ANTICIPOColumnName = "COBRA_ANTICIPO";
		public const string MONTO_ANTICIPOColumnName = "MONTO_ANTICIPO";
		public const string COBRA_BONIFICACIONColumnName = "COBRA_BONIFICACION";
		public const string MONTO_BONIFICACIONColumnName = "MONTO_BONIFICACION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string CTACTEColumnName = "CTACTE";
		public const string GRUPO_SANGUINEOColumnName = "GRUPO_SANGUINEO";
		public const string ES_PROMOTORColumnName = "ES_PROMOTOR";
		public const string MARCACIONES_IDColumnName = "MARCACIONES_ID";
		public const string ES_CHOFERColumnName = "ES_CHOFER";
		public const string DEPOSITEROColumnName = "DEPOSITERO";
		public const string ES_COBRADOR_EXTERNOColumnName = "ES_COBRADOR_EXTERNO";
		public const string CODIGO_TALONARIOColumnName = "CODIGO_TALONARIO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string DESCUENTOS_BASICOColumnName = "DESCUENTOS_BASICO";
		public const string DESCUENTOS_COMPLEMENTARIOColumnName = "DESCUENTOS_COMPLEMENTARIO";
		public const string DESCUENTOS_EXTRAColumnName = "DESCUENTOS_EXTRA";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FUNCIONARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FUNCIONARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FUNCIONARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByBARRIO_FAMILIAR_CONTACTO_ID(decimal barrio_familiar_contacto_id)
		{
			return GetByBARRIO_FAMILIAR_CONTACTO_ID(barrio_familiar_contacto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="barrio_familiar_contacto_idNull">true if the method ignores the barrio_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByBARRIO_FAMILIAR_CONTACTO_ID(decimal barrio_familiar_contacto_id, bool barrio_familiar_contacto_idNull)
		{
			return MapRecords(CreateGetByBARRIO_FAMILIAR_CONTACTO_IDCommand(barrio_familiar_contacto_id, barrio_familiar_contacto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_FAMILIAR_CONTACTO_IDAsDataTable(decimal barrio_familiar_contacto_id)
		{
			return GetByBARRIO_FAMILIAR_CONTACTO_IDAsDataTable(barrio_familiar_contacto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="barrio_familiar_contacto_idNull">true if the method ignores the barrio_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO_FAMILIAR_CONTACTO_IDAsDataTable(decimal barrio_familiar_contacto_id, bool barrio_familiar_contacto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO_FAMILIAR_CONTACTO_IDCommand(barrio_familiar_contacto_id, barrio_familiar_contacto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="barrio_familiar_contacto_idNull">true if the method ignores the barrio_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO_FAMILIAR_CONTACTO_IDCommand(decimal barrio_familiar_contacto_id, bool barrio_familiar_contacto_idNull)
		{
			string whereSql = "";
			if(barrio_familiar_contacto_idNull)
				whereSql += "BARRIO_FAMILIAR_CONTACTO_ID IS NULL";
			else
				whereSql += "BARRIO_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("BARRIO_FAMILIAR_CONTACTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio_familiar_contacto_idNull)
				AddParameter(cmd, "BARRIO_FAMILIAR_CONTACTO_ID", barrio_familiar_contacto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByBARRIO1_ID(decimal barrio1_id)
		{
			return GetByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecords(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id)
		{
			return GetByBARRIO1_IDAsDataTable(barrio1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByBARRIO2_ID(decimal barrio2_id)
		{
			return GetByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecords(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id)
		{
			return GetByBARRIO2_IDAsDataTable(barrio2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByCIUDAD_FAMILIAR_CONTACTO_ID(decimal ciudad_familiar_contacto_id)
		{
			return GetByCIUDAD_FAMILIAR_CONTACTO_ID(ciudad_familiar_contacto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="ciudad_familiar_contacto_idNull">true if the method ignores the ciudad_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByCIUDAD_FAMILIAR_CONTACTO_ID(decimal ciudad_familiar_contacto_id, bool ciudad_familiar_contacto_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_FAMILIAR_CONTACTO_IDCommand(ciudad_familiar_contacto_id, ciudad_familiar_contacto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_FAMILIAR_CONTACTO_IDAsDataTable(decimal ciudad_familiar_contacto_id)
		{
			return GetByCIUDAD_FAMILIAR_CONTACTO_IDAsDataTable(ciudad_familiar_contacto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="ciudad_familiar_contacto_idNull">true if the method ignores the ciudad_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_FAMILIAR_CONTACTO_IDAsDataTable(decimal ciudad_familiar_contacto_id, bool ciudad_familiar_contacto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_FAMILIAR_CONTACTO_IDCommand(ciudad_familiar_contacto_id, ciudad_familiar_contacto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="ciudad_familiar_contacto_idNull">true if the method ignores the ciudad_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_FAMILIAR_CONTACTO_IDCommand(decimal ciudad_familiar_contacto_id, bool ciudad_familiar_contacto_idNull)
		{
			string whereSql = "";
			if(ciudad_familiar_contacto_idNull)
				whereSql += "CIUDAD_FAMILIAR_CONTACTO_ID IS NULL";
			else
				whereSql += "CIUDAD_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("CIUDAD_FAMILIAR_CONTACTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_familiar_contacto_idNull)
				AddParameter(cmd, "CIUDAD_FAMILIAR_CONTACTO_ID", ciudad_familiar_contacto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByCIUDAD1_ID(decimal ciudad1_id)
		{
			return GetByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecords(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id)
		{
			return GetByCIUDAD1_IDAsDataTable(ciudad1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByCIUDAD2_ID(decimal ciudad2_id)
		{
			return GetByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecords(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id)
		{
			return GetByCIUDAD2_IDAsDataTable(ciudad2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByDEPARTAMENTO_FAMILIAR_CONT_ID(decimal departamento_familiar_cont_id)
		{
			return GetByDEPARTAMENTO_FAMILIAR_CONT_ID(departamento_familiar_cont_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <param name="departamento_familiar_cont_idNull">true if the method ignores the departamento_familiar_cont_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByDEPARTAMENTO_FAMILIAR_CONT_ID(decimal departamento_familiar_cont_id, bool departamento_familiar_cont_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_FAMILIAR_CONT_IDCommand(departamento_familiar_cont_id, departamento_familiar_cont_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_FAMILIAR_CONT_IDAsDataTable(decimal departamento_familiar_cont_id)
		{
			return GetByDEPARTAMENTO_FAMILIAR_CONT_IDAsDataTable(departamento_familiar_cont_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <param name="departamento_familiar_cont_idNull">true if the method ignores the departamento_familiar_cont_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_FAMILIAR_CONT_IDAsDataTable(decimal departamento_familiar_cont_id, bool departamento_familiar_cont_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_FAMILIAR_CONT_IDCommand(departamento_familiar_cont_id, departamento_familiar_cont_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <param name="departamento_familiar_cont_idNull">true if the method ignores the departamento_familiar_cont_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_FAMILIAR_CONT_IDCommand(decimal departamento_familiar_cont_id, bool departamento_familiar_cont_idNull)
		{
			string whereSql = "";
			if(departamento_familiar_cont_idNull)
				whereSql += "DEPARTAMENTO_FAMILIAR_CONT_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_FAMILIAR_CONT_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_FAMILIAR_CONT_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_familiar_cont_idNull)
				AddParameter(cmd, "DEPARTAMENTO_FAMILIAR_CONT_ID", departamento_familiar_cont_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_IDAsDataTable(departamento1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_IDAsDataTable(departamento2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_ENTIDAD</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByESTADO_CIVIL_ID(string estado_civil_id)
		{
			return MapRecords(CreateGetByESTADO_CIVIL_IDCommand(estado_civil_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_CIVIL_IDAsDataTable(string estado_civil_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_CIVIL_IDCommand(estado_civil_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_CIVIL_IDCommand(string estado_civil_id)
		{
			string whereSql = "";
			if(null == estado_civil_id)
				whereSql += "ESTADO_CIVIL_ID IS NULL";
			else
				whereSql += "ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_civil_id)
				AddParameter(cmd, "ESTADO_CIVIL_ID", estado_civil_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecords(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_IDAsDataTable(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id)
		{
			return GetByPAIS_NACIONALIDAD_ID(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return MapRecords(CreateGetByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_NACIONALIDAD_IDAsDataTable(decimal pais_nacionalidad_id)
		{
			return GetByPAIS_NACIONALIDAD_IDAsDataTable(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_NACIONALIDAD_IDAsDataTable(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_NACIONALIDAD_IDCommand(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			string whereSql = "";
			if(pais_nacionalidad_idNull)
				whereSql += "PAIS_NACIONALIDAD_ID IS NULL";
			else
				whereSql += "PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pais_nacionalidad_idNull)
				AddParameter(cmd, "PAIS_NACIONALIDAD_ID", pais_nacionalidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByPAIS_RESIDENCIA_ID(decimal pais_residencia_id)
		{
			return GetByPAIS_RESIDENCIA_ID(pais_residencia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByPAIS_RESIDENCIA_ID(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return MapRecords(CreateGetByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_RESIDENCIA_IDAsDataTable(decimal pais_residencia_id)
		{
			return GetByPAIS_RESIDENCIA_IDAsDataTable(pais_residencia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_RESIDENCIA_IDAsDataTable(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_RESIDENCIA_IDCommand(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			string whereSql = "";
			if(pais_residencia_idNull)
				whereSql += "PAIS_RESIDENCIA_ID IS NULL";
			else
				whereSql += "PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pais_residencia_idNull)
				AddParameter(cmd, "PAIS_RESIDENCIA_ID", pais_residencia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByPROFESION_ID(string profesion_id)
		{
			return MapRecords(CreateGetByPROFESION_IDCommand(profesion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROFESION_IDAsDataTable(string profesion_id)
		{
			return MapRecordsToDataTable(CreateGetByPROFESION_IDCommand(profesion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROFESION_IDCommand(string profesion_id)
		{
			string whereSql = "";
			if(null == profesion_id)
				whereSql += "PROFESION_ID IS NULL";
			else
				whereSql += "PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != profesion_id)
				AddParameter(cmd, "PROFESION_ID", profesion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByTIPO_DOCUMENTO_IDENTIDAD_ID(string tipo_documento_identidad_id)
		{
			return MapRecords(CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_DOCUMENTO_IDENTIDAD_IDAsDataTable(string tipo_documento_identidad_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(string tipo_documento_identidad_id)
		{
			string whereSql = "";
			if(null == tipo_documento_identidad_id)
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID IS NULL";
			else
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tipo_documento_identidad_id)
				AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", tipo_documento_identidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByTRATAMIENTO_ID(string tratamiento_id)
		{
			return MapRecords(CreateGetByTRATAMIENTO_IDCommand(tratamiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRATAMIENTO_IDAsDataTable(string tratamiento_id)
		{
			return MapRecordsToDataTable(CreateGetByTRATAMIENTO_IDCommand(tratamiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRATAMIENTO_IDCommand(string tratamiento_id)
		{
			string whereSql = "";
			if(null == tratamiento_id)
				whereSql += "TRATAMIENTO_ID IS NULL";
			else
				whereSql += "TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tratamiento_id)
				AddParameter(cmd, "TRATAMIENTO_ID", tratamiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public FUNCIONARIOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		public virtual FUNCIONARIOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(FUNCIONARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FUNCIONARIOS (" +
				"ID, " +
				"CODIGO, " +
				"ENTIDAD_ID, " +
				"TRATAMIENTO_ID, " +
				"NOMBRE, " +
				"APELLIDO, " +
				"APODO, " +
				"GENERO, " +
				"RUC, " +
				"NACIMIENTO, " +
				"TIPO_DOCUMENTO_IDENTIDAD_ID, " +
				"NUMERO_DOCUMENTO, " +
				"PAIS_NACIONALIDAD_ID, " +
				"PAIS_RESIDENCIA_ID, " +
				"PROFESION_ID, " +
				"DEPARTAMENTO1_ID, " +
				"CIUDAD1_ID, " +
				"BARRIO1_ID, " +
				"CALLE1, " +
				"CODIGO_POSTAL1, " +
				"LATITUD1, " +
				"LONGITUD1, " +
				"DEPARTAMENTO2_ID, " +
				"ES_VENDEDOR, " +
				"ES_COBRADOR, " +
				"CIUDAD2_ID, " +
				"BARRIO2_ID, " +
				"CALLE2, " +
				"CODIGO_POSTAL2, " +
				"LATITUD2, " +
				"LONGITUD2, " +
				"TELEFONO1, " +
				"TELEFONO2, " +
				"TELEFONO3, " +
				"TELEFONO4, " +
				"EMAIL1, " +
				"EMAIL2, " +
				"EMAIL3, " +
				"FECHA_CONTRATACION, " +
				"FECHA_SALIDA, " +
				"MOTIVO_SALIDA, " +
				"ESTADO_CIVIL_ID, " +
				"ESTADO_DOCUMENTACION_ID, " +
				"NOMBRE_FAMILIAR_CONTACTO, " +
				"RELACION_FAMILIAR_CONTACTO, " +
				"TELEFONO_FAMILIAR_CONTACTO, " +
				"DEPARTAMENTO_FAMILIAR_CONT_ID, " +
				"CIUDAD_FAMILIAR_CONTACTO_ID, " +
				"BARRIO_FAMILIAR_CONTACTO_ID, " +
				"CALLE_FAMILIAR_CONTACTO, " +
				"COD_POST_FAMILIAR_CONTACTO, " +
				"LATITUD_FAMILIAR_CONTACTO, " +
				"LONGITUD_FAMILIAR_CONTACTO, " +
				"ESTADO, " +
				"INGRESO_APROBADO, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"PERSONA_ID, " +
				"SUCURSAL_ID, " +
				"INGRESO_SEGURO, " +
				"SALARIO_TIPO, " +
				"COBRA_SALARIO_MINIMO, " +
				"SALARIO, " +
				"SALARIO_COMPLEMENTARIO, " +
				"SALARIO_EXTRA, " +
				"COBRA_ANTICIPO, " +
				"MONTO_ANTICIPO, " +
				"COBRA_BONIFICACION, " +
				"MONTO_BONIFICACION, " +
				"MONEDA_ID, " +
				"CTACTE, " +
				"GRUPO_SANGUINEO, " +
				"ES_PROMOTOR, " +
				"MARCACIONES_ID, " +
				"ES_CHOFER, " +
				"DEPOSITERO, " +
				"ES_COBRADOR_EXTERNO, " +
				"CODIGO_TALONARIO, " +
				"CENTRO_COSTO_ID, " +
				"DESCUENTOS_BASICO, " +
				"DESCUENTOS_COMPLEMENTARIO, " +
				"DESCUENTOS_EXTRA, " +
				"CANAL_VENTA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("TRATAMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("APELLIDO") + ", " +
				_db.CreateSqlParameterName("APODO") + ", " +
				_db.CreateSqlParameterName("GENERO") + ", " +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("NACIMIENTO") + ", " +
				_db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PAIS_RESIDENCIA_ID") + ", " +
				_db.CreateSqlParameterName("PROFESION_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				_db.CreateSqlParameterName("CALLE1") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				_db.CreateSqlParameterName("LATITUD1") + ", " +
				_db.CreateSqlParameterName("LONGITUD1") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				_db.CreateSqlParameterName("ES_VENDEDOR") + ", " +
				_db.CreateSqlParameterName("ES_COBRADOR") + ", " +
				_db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				_db.CreateSqlParameterName("CALLE2") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				_db.CreateSqlParameterName("LATITUD2") + ", " +
				_db.CreateSqlParameterName("LONGITUD2") + ", " +
				_db.CreateSqlParameterName("TELEFONO1") + ", " +
				_db.CreateSqlParameterName("TELEFONO2") + ", " +
				_db.CreateSqlParameterName("TELEFONO3") + ", " +
				_db.CreateSqlParameterName("TELEFONO4") + ", " +
				_db.CreateSqlParameterName("EMAIL1") + ", " +
				_db.CreateSqlParameterName("EMAIL2") + ", " +
				_db.CreateSqlParameterName("EMAIL3") + ", " +
				_db.CreateSqlParameterName("FECHA_CONTRATACION") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				_db.CreateSqlParameterName("MOTIVO_SALIDA") + ", " +
				_db.CreateSqlParameterName("ESTADO_CIVIL_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("RELACION_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("TELEFONO_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_FAMILIAR_CONT_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_FAMILIAR_CONTACTO_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_FAMILIAR_CONTACTO_ID") + ", " +
				_db.CreateSqlParameterName("CALLE_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("COD_POST_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("LATITUD_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("LONGITUD_FAMILIAR_CONTACTO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("INGRESO_SEGURO") + ", " +
				_db.CreateSqlParameterName("SALARIO_TIPO") + ", " +
				_db.CreateSqlParameterName("COBRA_SALARIO_MINIMO") + ", " +
				_db.CreateSqlParameterName("SALARIO") + ", " +
				_db.CreateSqlParameterName("SALARIO_COMPLEMENTARIO") + ", " +
				_db.CreateSqlParameterName("SALARIO_EXTRA") + ", " +
				_db.CreateSqlParameterName("COBRA_ANTICIPO") + ", " +
				_db.CreateSqlParameterName("MONTO_ANTICIPO") + ", " +
				_db.CreateSqlParameterName("COBRA_BONIFICACION") + ", " +
				_db.CreateSqlParameterName("MONTO_BONIFICACION") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE") + ", " +
				_db.CreateSqlParameterName("GRUPO_SANGUINEO") + ", " +
				_db.CreateSqlParameterName("ES_PROMOTOR") + ", " +
				_db.CreateSqlParameterName("MARCACIONES_ID") + ", " +
				_db.CreateSqlParameterName("ES_CHOFER") + ", " +
				_db.CreateSqlParameterName("DEPOSITERO") + ", " +
				_db.CreateSqlParameterName("ES_COBRADOR_EXTERNO") + ", " +
				_db.CreateSqlParameterName("CODIGO_TALONARIO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTOS_BASICO") + ", " +
				_db.CreateSqlParameterName("DESCUENTOS_COMPLEMENTARIO") + ", " +
				_db.CreateSqlParameterName("DESCUENTOS_EXTRA") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "TRATAMIENTO_ID", value.TRATAMIENTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "APODO", value.APODO);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "NACIMIENTO",
				value.IsNACIMIENTONull ? DBNull.Value : (object)value.NACIMIENTO);
			AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", value.TIPO_DOCUMENTO_IDENTIDAD_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "PAIS_NACIONALIDAD_ID",
				value.IsPAIS_NACIONALIDAD_IDNull ? DBNull.Value : (object)value.PAIS_NACIONALIDAD_ID);
			AddParameter(cmd, "PAIS_RESIDENCIA_ID",
				value.IsPAIS_RESIDENCIA_IDNull ? DBNull.Value : (object)value.PAIS_RESIDENCIA_ID);
			AddParameter(cmd, "PROFESION_ID", value.PROFESION_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "ES_VENDEDOR", value.ES_VENDEDOR);
			AddParameter(cmd, "ES_COBRADOR", value.ES_COBRADOR);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "FECHA_CONTRATACION",
				value.IsFECHA_CONTRATACIONNull ? DBNull.Value : (object)value.FECHA_CONTRATACION);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "MOTIVO_SALIDA", value.MOTIVO_SALIDA);
			AddParameter(cmd, "ESTADO_CIVIL_ID", value.ESTADO_CIVIL_ID);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "NOMBRE_FAMILIAR_CONTACTO", value.NOMBRE_FAMILIAR_CONTACTO);
			AddParameter(cmd, "RELACION_FAMILIAR_CONTACTO", value.RELACION_FAMILIAR_CONTACTO);
			AddParameter(cmd, "TELEFONO_FAMILIAR_CONTACTO", value.TELEFONO_FAMILIAR_CONTACTO);
			AddParameter(cmd, "DEPARTAMENTO_FAMILIAR_CONT_ID",
				value.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_FAMILIAR_CONT_ID);
			AddParameter(cmd, "CIUDAD_FAMILIAR_CONTACTO_ID",
				value.IsCIUDAD_FAMILIAR_CONTACTO_IDNull ? DBNull.Value : (object)value.CIUDAD_FAMILIAR_CONTACTO_ID);
			AddParameter(cmd, "BARRIO_FAMILIAR_CONTACTO_ID",
				value.IsBARRIO_FAMILIAR_CONTACTO_IDNull ? DBNull.Value : (object)value.BARRIO_FAMILIAR_CONTACTO_ID);
			AddParameter(cmd, "CALLE_FAMILIAR_CONTACTO", value.CALLE_FAMILIAR_CONTACTO);
			AddParameter(cmd, "COD_POST_FAMILIAR_CONTACTO", value.COD_POST_FAMILIAR_CONTACTO);
			AddParameter(cmd, "LATITUD_FAMILIAR_CONTACTO",
				value.IsLATITUD_FAMILIAR_CONTACTONull ? DBNull.Value : (object)value.LATITUD_FAMILIAR_CONTACTO);
			AddParameter(cmd, "LONGITUD_FAMILIAR_CONTACTO",
				value.IsLONGITUD_FAMILIAR_CONTACTONull ? DBNull.Value : (object)value.LONGITUD_FAMILIAR_CONTACTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "INGRESO_SEGURO",
				value.IsINGRESO_SEGURONull ? DBNull.Value : (object)value.INGRESO_SEGURO);
			AddParameter(cmd, "SALARIO_TIPO",
				value.IsSALARIO_TIPONull ? DBNull.Value : (object)value.SALARIO_TIPO);
			AddParameter(cmd, "COBRA_SALARIO_MINIMO", value.COBRA_SALARIO_MINIMO);
			AddParameter(cmd, "SALARIO",
				value.IsSALARIONull ? DBNull.Value : (object)value.SALARIO);
			AddParameter(cmd, "SALARIO_COMPLEMENTARIO",
				value.IsSALARIO_COMPLEMENTARIONull ? DBNull.Value : (object)value.SALARIO_COMPLEMENTARIO);
			AddParameter(cmd, "SALARIO_EXTRA",
				value.IsSALARIO_EXTRANull ? DBNull.Value : (object)value.SALARIO_EXTRA);
			AddParameter(cmd, "COBRA_ANTICIPO", value.COBRA_ANTICIPO);
			AddParameter(cmd, "MONTO_ANTICIPO",
				value.IsMONTO_ANTICIPONull ? DBNull.Value : (object)value.MONTO_ANTICIPO);
			AddParameter(cmd, "COBRA_BONIFICACION", value.COBRA_BONIFICACION);
			AddParameter(cmd, "MONTO_BONIFICACION",
				value.IsMONTO_BONIFICACIONNull ? DBNull.Value : (object)value.MONTO_BONIFICACION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "CTACTE", value.CTACTE);
			AddParameter(cmd, "GRUPO_SANGUINEO", value.GRUPO_SANGUINEO);
			AddParameter(cmd, "ES_PROMOTOR", value.ES_PROMOTOR);
			AddParameter(cmd, "MARCACIONES_ID",
				value.IsMARCACIONES_IDNull ? DBNull.Value : (object)value.MARCACIONES_ID);
			AddParameter(cmd, "ES_CHOFER", value.ES_CHOFER);
			AddParameter(cmd, "DEPOSITERO", value.DEPOSITERO);
			AddParameter(cmd, "ES_COBRADOR_EXTERNO", value.ES_COBRADOR_EXTERNO);
			AddParameter(cmd, "CODIGO_TALONARIO", value.CODIGO_TALONARIO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "DESCUENTOS_BASICO", value.DESCUENTOS_BASICO);
			AddParameter(cmd, "DESCUENTOS_COMPLEMENTARIO", value.DESCUENTOS_COMPLEMENTARIO);
			AddParameter(cmd, "DESCUENTOS_EXTRA", value.DESCUENTOS_EXTRA);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FUNCIONARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.FUNCIONARIOS SET " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"APELLIDO=" + _db.CreateSqlParameterName("APELLIDO") + ", " +
				"APODO=" + _db.CreateSqlParameterName("APODO") + ", " +
				"GENERO=" + _db.CreateSqlParameterName("GENERO") + ", " +
				"RUC=" + _db.CreateSqlParameterName("RUC") + ", " +
				"NACIMIENTO=" + _db.CreateSqlParameterName("NACIMIENTO") + ", " +
				"TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID") + ", " +
				"NUMERO_DOCUMENTO=" + _db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				"PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID") + ", " +
				"PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID") + ", " +
				"PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID") + ", " +
				"DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				"CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				"BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				"CALLE1=" + _db.CreateSqlParameterName("CALLE1") + ", " +
				"CODIGO_POSTAL1=" + _db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				"LATITUD1=" + _db.CreateSqlParameterName("LATITUD1") + ", " +
				"LONGITUD1=" + _db.CreateSqlParameterName("LONGITUD1") + ", " +
				"DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				"ES_VENDEDOR=" + _db.CreateSqlParameterName("ES_VENDEDOR") + ", " +
				"ES_COBRADOR=" + _db.CreateSqlParameterName("ES_COBRADOR") + ", " +
				"CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				"BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				"CALLE2=" + _db.CreateSqlParameterName("CALLE2") + ", " +
				"CODIGO_POSTAL2=" + _db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				"LATITUD2=" + _db.CreateSqlParameterName("LATITUD2") + ", " +
				"LONGITUD2=" + _db.CreateSqlParameterName("LONGITUD2") + ", " +
				"TELEFONO1=" + _db.CreateSqlParameterName("TELEFONO1") + ", " +
				"TELEFONO2=" + _db.CreateSqlParameterName("TELEFONO2") + ", " +
				"TELEFONO3=" + _db.CreateSqlParameterName("TELEFONO3") + ", " +
				"TELEFONO4=" + _db.CreateSqlParameterName("TELEFONO4") + ", " +
				"EMAIL1=" + _db.CreateSqlParameterName("EMAIL1") + ", " +
				"EMAIL2=" + _db.CreateSqlParameterName("EMAIL2") + ", " +
				"EMAIL3=" + _db.CreateSqlParameterName("EMAIL3") + ", " +
				"FECHA_CONTRATACION=" + _db.CreateSqlParameterName("FECHA_CONTRATACION") + ", " +
				"FECHA_SALIDA=" + _db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				"MOTIVO_SALIDA=" + _db.CreateSqlParameterName("MOTIVO_SALIDA") + ", " +
				"ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID") + ", " +
				"ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				"NOMBRE_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("NOMBRE_FAMILIAR_CONTACTO") + ", " +
				"RELACION_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("RELACION_FAMILIAR_CONTACTO") + ", " +
				"TELEFONO_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("TELEFONO_FAMILIAR_CONTACTO") + ", " +
				"DEPARTAMENTO_FAMILIAR_CONT_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_FAMILIAR_CONT_ID") + ", " +
				"CIUDAD_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("CIUDAD_FAMILIAR_CONTACTO_ID") + ", " +
				"BARRIO_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("BARRIO_FAMILIAR_CONTACTO_ID") + ", " +
				"CALLE_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("CALLE_FAMILIAR_CONTACTO") + ", " +
				"COD_POST_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("COD_POST_FAMILIAR_CONTACTO") + ", " +
				"LATITUD_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("LATITUD_FAMILIAR_CONTACTO") + ", " +
				"LONGITUD_FAMILIAR_CONTACTO=" + _db.CreateSqlParameterName("LONGITUD_FAMILIAR_CONTACTO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"INGRESO_APROBADO=" + _db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"INGRESO_SEGURO=" + _db.CreateSqlParameterName("INGRESO_SEGURO") + ", " +
				"SALARIO_TIPO=" + _db.CreateSqlParameterName("SALARIO_TIPO") + ", " +
				"COBRA_SALARIO_MINIMO=" + _db.CreateSqlParameterName("COBRA_SALARIO_MINIMO") + ", " +
				"SALARIO=" + _db.CreateSqlParameterName("SALARIO") + ", " +
				"SALARIO_COMPLEMENTARIO=" + _db.CreateSqlParameterName("SALARIO_COMPLEMENTARIO") + ", " +
				"SALARIO_EXTRA=" + _db.CreateSqlParameterName("SALARIO_EXTRA") + ", " +
				"COBRA_ANTICIPO=" + _db.CreateSqlParameterName("COBRA_ANTICIPO") + ", " +
				"MONTO_ANTICIPO=" + _db.CreateSqlParameterName("MONTO_ANTICIPO") + ", " +
				"COBRA_BONIFICACION=" + _db.CreateSqlParameterName("COBRA_BONIFICACION") + ", " +
				"MONTO_BONIFICACION=" + _db.CreateSqlParameterName("MONTO_BONIFICACION") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"CTACTE=" + _db.CreateSqlParameterName("CTACTE") + ", " +
				"GRUPO_SANGUINEO=" + _db.CreateSqlParameterName("GRUPO_SANGUINEO") + ", " +
				"ES_PROMOTOR=" + _db.CreateSqlParameterName("ES_PROMOTOR") + ", " +
				"MARCACIONES_ID=" + _db.CreateSqlParameterName("MARCACIONES_ID") + ", " +
				"ES_CHOFER=" + _db.CreateSqlParameterName("ES_CHOFER") + ", " +
				"DEPOSITERO=" + _db.CreateSqlParameterName("DEPOSITERO") + ", " +
				"ES_COBRADOR_EXTERNO=" + _db.CreateSqlParameterName("ES_COBRADOR_EXTERNO") + ", " +
				"CODIGO_TALONARIO=" + _db.CreateSqlParameterName("CODIGO_TALONARIO") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"DESCUENTOS_BASICO=" + _db.CreateSqlParameterName("DESCUENTOS_BASICO") + ", " +
				"DESCUENTOS_COMPLEMENTARIO=" + _db.CreateSqlParameterName("DESCUENTOS_COMPLEMENTARIO") + ", " +
				"DESCUENTOS_EXTRA=" + _db.CreateSqlParameterName("DESCUENTOS_EXTRA") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "TRATAMIENTO_ID", value.TRATAMIENTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "APODO", value.APODO);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "NACIMIENTO",
				value.IsNACIMIENTONull ? DBNull.Value : (object)value.NACIMIENTO);
			AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", value.TIPO_DOCUMENTO_IDENTIDAD_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "PAIS_NACIONALIDAD_ID",
				value.IsPAIS_NACIONALIDAD_IDNull ? DBNull.Value : (object)value.PAIS_NACIONALIDAD_ID);
			AddParameter(cmd, "PAIS_RESIDENCIA_ID",
				value.IsPAIS_RESIDENCIA_IDNull ? DBNull.Value : (object)value.PAIS_RESIDENCIA_ID);
			AddParameter(cmd, "PROFESION_ID", value.PROFESION_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "ES_VENDEDOR", value.ES_VENDEDOR);
			AddParameter(cmd, "ES_COBRADOR", value.ES_COBRADOR);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "FECHA_CONTRATACION",
				value.IsFECHA_CONTRATACIONNull ? DBNull.Value : (object)value.FECHA_CONTRATACION);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "MOTIVO_SALIDA", value.MOTIVO_SALIDA);
			AddParameter(cmd, "ESTADO_CIVIL_ID", value.ESTADO_CIVIL_ID);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "NOMBRE_FAMILIAR_CONTACTO", value.NOMBRE_FAMILIAR_CONTACTO);
			AddParameter(cmd, "RELACION_FAMILIAR_CONTACTO", value.RELACION_FAMILIAR_CONTACTO);
			AddParameter(cmd, "TELEFONO_FAMILIAR_CONTACTO", value.TELEFONO_FAMILIAR_CONTACTO);
			AddParameter(cmd, "DEPARTAMENTO_FAMILIAR_CONT_ID",
				value.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_FAMILIAR_CONT_ID);
			AddParameter(cmd, "CIUDAD_FAMILIAR_CONTACTO_ID",
				value.IsCIUDAD_FAMILIAR_CONTACTO_IDNull ? DBNull.Value : (object)value.CIUDAD_FAMILIAR_CONTACTO_ID);
			AddParameter(cmd, "BARRIO_FAMILIAR_CONTACTO_ID",
				value.IsBARRIO_FAMILIAR_CONTACTO_IDNull ? DBNull.Value : (object)value.BARRIO_FAMILIAR_CONTACTO_ID);
			AddParameter(cmd, "CALLE_FAMILIAR_CONTACTO", value.CALLE_FAMILIAR_CONTACTO);
			AddParameter(cmd, "COD_POST_FAMILIAR_CONTACTO", value.COD_POST_FAMILIAR_CONTACTO);
			AddParameter(cmd, "LATITUD_FAMILIAR_CONTACTO",
				value.IsLATITUD_FAMILIAR_CONTACTONull ? DBNull.Value : (object)value.LATITUD_FAMILIAR_CONTACTO);
			AddParameter(cmd, "LONGITUD_FAMILIAR_CONTACTO",
				value.IsLONGITUD_FAMILIAR_CONTACTONull ? DBNull.Value : (object)value.LONGITUD_FAMILIAR_CONTACTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "INGRESO_SEGURO",
				value.IsINGRESO_SEGURONull ? DBNull.Value : (object)value.INGRESO_SEGURO);
			AddParameter(cmd, "SALARIO_TIPO",
				value.IsSALARIO_TIPONull ? DBNull.Value : (object)value.SALARIO_TIPO);
			AddParameter(cmd, "COBRA_SALARIO_MINIMO", value.COBRA_SALARIO_MINIMO);
			AddParameter(cmd, "SALARIO",
				value.IsSALARIONull ? DBNull.Value : (object)value.SALARIO);
			AddParameter(cmd, "SALARIO_COMPLEMENTARIO",
				value.IsSALARIO_COMPLEMENTARIONull ? DBNull.Value : (object)value.SALARIO_COMPLEMENTARIO);
			AddParameter(cmd, "SALARIO_EXTRA",
				value.IsSALARIO_EXTRANull ? DBNull.Value : (object)value.SALARIO_EXTRA);
			AddParameter(cmd, "COBRA_ANTICIPO", value.COBRA_ANTICIPO);
			AddParameter(cmd, "MONTO_ANTICIPO",
				value.IsMONTO_ANTICIPONull ? DBNull.Value : (object)value.MONTO_ANTICIPO);
			AddParameter(cmd, "COBRA_BONIFICACION", value.COBRA_BONIFICACION);
			AddParameter(cmd, "MONTO_BONIFICACION",
				value.IsMONTO_BONIFICACIONNull ? DBNull.Value : (object)value.MONTO_BONIFICACION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "CTACTE", value.CTACTE);
			AddParameter(cmd, "GRUPO_SANGUINEO", value.GRUPO_SANGUINEO);
			AddParameter(cmd, "ES_PROMOTOR", value.ES_PROMOTOR);
			AddParameter(cmd, "MARCACIONES_ID",
				value.IsMARCACIONES_IDNull ? DBNull.Value : (object)value.MARCACIONES_ID);
			AddParameter(cmd, "ES_CHOFER", value.ES_CHOFER);
			AddParameter(cmd, "DEPOSITERO", value.DEPOSITERO);
			AddParameter(cmd, "ES_COBRADOR_EXTERNO", value.ES_COBRADOR_EXTERNO);
			AddParameter(cmd, "CODIGO_TALONARIO", value.CODIGO_TALONARIO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "DESCUENTOS_BASICO", value.DESCUENTOS_BASICO);
			AddParameter(cmd, "DESCUENTOS_COMPLEMENTARIO", value.DESCUENTOS_COMPLEMENTARIO);
			AddParameter(cmd, "DESCUENTOS_EXTRA", value.DESCUENTOS_EXTRA);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FUNCIONARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FUNCIONARIOS</c> table using
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
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_FAMILIAR_CONTACTO_ID(decimal barrio_familiar_contacto_id)
		{
			return DeleteByBARRIO_FAMILIAR_CONTACTO_ID(barrio_familiar_contacto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="barrio_familiar_contacto_idNull">true if the method ignores the barrio_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_FAMILIAR_CONTACTO_ID(decimal barrio_familiar_contacto_id, bool barrio_familiar_contacto_idNull)
		{
			return CreateDeleteByBARRIO_FAMILIAR_CONTACTO_IDCommand(barrio_familiar_contacto_id, barrio_familiar_contacto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_B_FAM</c> foreign key.
		/// </summary>
		/// <param name="barrio_familiar_contacto_id">The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="barrio_familiar_contacto_idNull">true if the method ignores the barrio_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO_FAMILIAR_CONTACTO_IDCommand(decimal barrio_familiar_contacto_id, bool barrio_familiar_contacto_idNull)
		{
			string whereSql = "";
			if(barrio_familiar_contacto_idNull)
				whereSql += "BARRIO_FAMILIAR_CONTACTO_ID IS NULL";
			else
				whereSql += "BARRIO_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("BARRIO_FAMILIAR_CONTACTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio_familiar_contacto_idNull)
				AddParameter(cmd, "BARRIO_FAMILIAR_CONTACTO_ID", barrio_familiar_contacto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id)
		{
			return DeleteByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return CreateDeleteByBARRIO1_IDCommand(barrio1_id, barrio1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id)
		{
			return DeleteByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return CreateDeleteByBARRIO2_IDCommand(barrio2_id, barrio2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_FAMILIAR_CONTACTO_ID(decimal ciudad_familiar_contacto_id)
		{
			return DeleteByCIUDAD_FAMILIAR_CONTACTO_ID(ciudad_familiar_contacto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="ciudad_familiar_contacto_idNull">true if the method ignores the ciudad_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_FAMILIAR_CONTACTO_ID(decimal ciudad_familiar_contacto_id, bool ciudad_familiar_contacto_idNull)
		{
			return CreateDeleteByCIUDAD_FAMILIAR_CONTACTO_IDCommand(ciudad_familiar_contacto_id, ciudad_familiar_contacto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_C_FAM</c> foreign key.
		/// </summary>
		/// <param name="ciudad_familiar_contacto_id">The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</param>
		/// <param name="ciudad_familiar_contacto_idNull">true if the method ignores the ciudad_familiar_contacto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_FAMILIAR_CONTACTO_IDCommand(decimal ciudad_familiar_contacto_id, bool ciudad_familiar_contacto_idNull)
		{
			string whereSql = "";
			if(ciudad_familiar_contacto_idNull)
				whereSql += "CIUDAD_FAMILIAR_CONTACTO_ID IS NULL";
			else
				whereSql += "CIUDAD_FAMILIAR_CONTACTO_ID=" + _db.CreateSqlParameterName("CIUDAD_FAMILIAR_CONTACTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_familiar_contacto_idNull)
				AddParameter(cmd, "CIUDAD_FAMILIAR_CONTACTO_ID", ciudad_familiar_contacto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return CreateDeleteByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id)
		{
			return DeleteByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return CreateDeleteByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id)
		{
			return DeleteByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return CreateDeleteByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_FAMILIAR_CONT_ID(decimal departamento_familiar_cont_id)
		{
			return DeleteByDEPARTAMENTO_FAMILIAR_CONT_ID(departamento_familiar_cont_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <param name="departamento_familiar_cont_idNull">true if the method ignores the departamento_familiar_cont_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_FAMILIAR_CONT_ID(decimal departamento_familiar_cont_id, bool departamento_familiar_cont_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_FAMILIAR_CONT_IDCommand(departamento_familiar_cont_id, departamento_familiar_cont_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_DEP_FAM</c> foreign key.
		/// </summary>
		/// <param name="departamento_familiar_cont_id">The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</param>
		/// <param name="departamento_familiar_cont_idNull">true if the method ignores the departamento_familiar_cont_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_FAMILIAR_CONT_IDCommand(decimal departamento_familiar_cont_id, bool departamento_familiar_cont_idNull)
		{
			string whereSql = "";
			if(departamento_familiar_cont_idNull)
				whereSql += "DEPARTAMENTO_FAMILIAR_CONT_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_FAMILIAR_CONT_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_FAMILIAR_CONT_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_familiar_cont_idNull)
				AddParameter(cmd, "DEPARTAMENTO_FAMILIAR_CONT_ID", departamento_familiar_cont_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return DeleteByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return CreateDeleteByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return DeleteByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return CreateDeleteByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_ENTIDAD</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_CIVIL_ID(string estado_civil_id)
		{
			return CreateDeleteByESTADO_CIVIL_IDCommand(estado_civil_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_CIVIL_IDCommand(string estado_civil_id)
		{
			string whereSql = "";
			if(null == estado_civil_id)
				whereSql += "ESTADO_CIVIL_ID IS NULL";
			else
				whereSql += "ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_civil_id)
				AddParameter(cmd, "ESTADO_CIVIL_ID", estado_civil_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return DeleteByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return CreateDeleteByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_ESTADOS_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id)
		{
			return DeleteByPAIS_NACIONALIDAD_ID(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return CreateDeleteByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_PAIS_NAC</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_NACIONALIDAD_IDCommand(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			string whereSql = "";
			if(pais_nacionalidad_idNull)
				whereSql += "PAIS_NACIONALIDAD_ID IS NULL";
			else
				whereSql += "PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pais_nacionalidad_idNull)
				AddParameter(cmd, "PAIS_NACIONALIDAD_ID", pais_nacionalidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_RESIDENCIA_ID(decimal pais_residencia_id)
		{
			return DeleteByPAIS_RESIDENCIA_ID(pais_residencia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_RESIDENCIA_ID(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return CreateDeleteByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_PAIS_RESID</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_RESIDENCIA_IDCommand(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			string whereSql = "";
			if(pais_residencia_idNull)
				whereSql += "PAIS_RESIDENCIA_ID IS NULL";
			else
				whereSql += "PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pais_residencia_idNull)
				AddParameter(cmd, "PAIS_RESIDENCIA_ID", pais_residencia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROFESION_ID(string profesion_id)
		{
			return CreateDeleteByPROFESION_IDCommand(profesion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROFESION_IDCommand(string profesion_id)
		{
			string whereSql = "";
			if(null == profesion_id)
				whereSql += "PROFESION_ID IS NULL";
			else
				whereSql += "PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != profesion_id)
				AddParameter(cmd, "PROFESION_ID", profesion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DOCUMENTO_IDENTIDAD_ID(string tipo_documento_identidad_id)
		{
			return CreateDeleteByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(string tipo_documento_identidad_id)
		{
			string whereSql = "";
			if(null == tipo_documento_identidad_id)
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID IS NULL";
			else
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tipo_documento_identidad_id)
				AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", tipo_documento_identidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRATAMIENTO_ID(string tratamiento_id)
		{
			return CreateDeleteByTRATAMIENTO_IDCommand(tratamiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRATAMIENTO_IDCommand(string tratamiento_id)
		{
			string whereSql = "";
			if(null == tratamiento_id)
				whereSql += "TRATAMIENTO_ID IS NULL";
			else
				whereSql += "TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tratamiento_id)
				AddParameter(cmd, "TRATAMIENTO_ID", tratamiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS</c> table using the 
		/// <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FUNCIONARIOS</c> records that match the specified criteria.
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
		/// to delete <c>FUNCIONARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FUNCIONARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FUNCIONARIOS</c> table.
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
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		protected FUNCIONARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		protected FUNCIONARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOSRow"/> objects.</returns>
		protected virtual FUNCIONARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int tratamiento_idColumnIndex = reader.GetOrdinal("TRATAMIENTO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int apodoColumnIndex = reader.GetOrdinal("APODO");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int nacimientoColumnIndex = reader.GetOrdinal("NACIMIENTO");
			int tipo_documento_identidad_idColumnIndex = reader.GetOrdinal("TIPO_DOCUMENTO_IDENTIDAD_ID");
			int numero_documentoColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO");
			int pais_nacionalidad_idColumnIndex = reader.GetOrdinal("PAIS_NACIONALIDAD_ID");
			int pais_residencia_idColumnIndex = reader.GetOrdinal("PAIS_RESIDENCIA_ID");
			int profesion_idColumnIndex = reader.GetOrdinal("PROFESION_ID");
			int departamento1_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ID");
			int ciudad1_idColumnIndex = reader.GetOrdinal("CIUDAD1_ID");
			int barrio1_idColumnIndex = reader.GetOrdinal("BARRIO1_ID");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");
			int codigo_postal1ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL1");
			int latitud1ColumnIndex = reader.GetOrdinal("LATITUD1");
			int longitud1ColumnIndex = reader.GetOrdinal("LONGITUD1");
			int departamento2_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ID");
			int es_vendedorColumnIndex = reader.GetOrdinal("ES_VENDEDOR");
			int es_cobradorColumnIndex = reader.GetOrdinal("ES_COBRADOR");
			int ciudad2_idColumnIndex = reader.GetOrdinal("CIUDAD2_ID");
			int barrio2_idColumnIndex = reader.GetOrdinal("BARRIO2_ID");
			int calle2ColumnIndex = reader.GetOrdinal("CALLE2");
			int codigo_postal2ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL2");
			int latitud2ColumnIndex = reader.GetOrdinal("LATITUD2");
			int longitud2ColumnIndex = reader.GetOrdinal("LONGITUD2");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int telefono4ColumnIndex = reader.GetOrdinal("TELEFONO4");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int email3ColumnIndex = reader.GetOrdinal("EMAIL3");
			int fecha_contratacionColumnIndex = reader.GetOrdinal("FECHA_CONTRATACION");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int motivo_salidaColumnIndex = reader.GetOrdinal("MOTIVO_SALIDA");
			int estado_civil_idColumnIndex = reader.GetOrdinal("ESTADO_CIVIL_ID");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int nombre_familiar_contactoColumnIndex = reader.GetOrdinal("NOMBRE_FAMILIAR_CONTACTO");
			int relacion_familiar_contactoColumnIndex = reader.GetOrdinal("RELACION_FAMILIAR_CONTACTO");
			int telefono_familiar_contactoColumnIndex = reader.GetOrdinal("TELEFONO_FAMILIAR_CONTACTO");
			int departamento_familiar_cont_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_FAMILIAR_CONT_ID");
			int ciudad_familiar_contacto_idColumnIndex = reader.GetOrdinal("CIUDAD_FAMILIAR_CONTACTO_ID");
			int barrio_familiar_contacto_idColumnIndex = reader.GetOrdinal("BARRIO_FAMILIAR_CONTACTO_ID");
			int calle_familiar_contactoColumnIndex = reader.GetOrdinal("CALLE_FAMILIAR_CONTACTO");
			int cod_post_familiar_contactoColumnIndex = reader.GetOrdinal("COD_POST_FAMILIAR_CONTACTO");
			int latitud_familiar_contactoColumnIndex = reader.GetOrdinal("LATITUD_FAMILIAR_CONTACTO");
			int longitud_familiar_contactoColumnIndex = reader.GetOrdinal("LONGITUD_FAMILIAR_CONTACTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int ingreso_seguroColumnIndex = reader.GetOrdinal("INGRESO_SEGURO");
			int salario_tipoColumnIndex = reader.GetOrdinal("SALARIO_TIPO");
			int cobra_salario_minimoColumnIndex = reader.GetOrdinal("COBRA_SALARIO_MINIMO");
			int salarioColumnIndex = reader.GetOrdinal("SALARIO");
			int salario_complementarioColumnIndex = reader.GetOrdinal("SALARIO_COMPLEMENTARIO");
			int salario_extraColumnIndex = reader.GetOrdinal("SALARIO_EXTRA");
			int cobra_anticipoColumnIndex = reader.GetOrdinal("COBRA_ANTICIPO");
			int monto_anticipoColumnIndex = reader.GetOrdinal("MONTO_ANTICIPO");
			int cobra_bonificacionColumnIndex = reader.GetOrdinal("COBRA_BONIFICACION");
			int monto_bonificacionColumnIndex = reader.GetOrdinal("MONTO_BONIFICACION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int ctacteColumnIndex = reader.GetOrdinal("CTACTE");
			int grupo_sanguineoColumnIndex = reader.GetOrdinal("GRUPO_SANGUINEO");
			int es_promotorColumnIndex = reader.GetOrdinal("ES_PROMOTOR");
			int marcaciones_idColumnIndex = reader.GetOrdinal("MARCACIONES_ID");
			int es_choferColumnIndex = reader.GetOrdinal("ES_CHOFER");
			int depositeroColumnIndex = reader.GetOrdinal("DEPOSITERO");
			int es_cobrador_externoColumnIndex = reader.GetOrdinal("ES_COBRADOR_EXTERNO");
			int codigo_talonarioColumnIndex = reader.GetOrdinal("CODIGO_TALONARIO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int descuentos_basicoColumnIndex = reader.GetOrdinal("DESCUENTOS_BASICO");
			int descuentos_complementarioColumnIndex = reader.GetOrdinal("DESCUENTOS_COMPLEMENTARIO");
			int descuentos_extraColumnIndex = reader.GetOrdinal("DESCUENTOS_EXTRA");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOSRow record = new FUNCIONARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(tratamiento_idColumnIndex))
						record.TRATAMIENTO_ID = Convert.ToString(reader.GetValue(tratamiento_idColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(apellidoColumnIndex))
						record.APELLIDO = Convert.ToString(reader.GetValue(apellidoColumnIndex));
					if(!reader.IsDBNull(apodoColumnIndex))
						record.APODO = Convert.ToString(reader.GetValue(apodoColumnIndex));
					if(!reader.IsDBNull(generoColumnIndex))
						record.GENERO = Convert.ToString(reader.GetValue(generoColumnIndex));
					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(nacimientoColumnIndex))
						record.NACIMIENTO = Convert.ToDateTime(reader.GetValue(nacimientoColumnIndex));
					if(!reader.IsDBNull(tipo_documento_identidad_idColumnIndex))
						record.TIPO_DOCUMENTO_IDENTIDAD_ID = Convert.ToString(reader.GetValue(tipo_documento_identidad_idColumnIndex));
					if(!reader.IsDBNull(numero_documentoColumnIndex))
						record.NUMERO_DOCUMENTO = Convert.ToString(reader.GetValue(numero_documentoColumnIndex));
					if(!reader.IsDBNull(pais_nacionalidad_idColumnIndex))
						record.PAIS_NACIONALIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_nacionalidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_residencia_idColumnIndex))
						record.PAIS_RESIDENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_residencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(profesion_idColumnIndex))
						record.PROFESION_ID = Convert.ToString(reader.GetValue(profesion_idColumnIndex));
					if(!reader.IsDBNull(departamento1_idColumnIndex))
						record.DEPARTAMENTO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento1_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad1_idColumnIndex))
						record.CIUDAD1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad1_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio1_idColumnIndex))
						record.BARRIO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio1_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle1ColumnIndex))
						record.CALLE1 = Convert.ToString(reader.GetValue(calle1ColumnIndex));
					if(!reader.IsDBNull(codigo_postal1ColumnIndex))
						record.CODIGO_POSTAL1 = Convert.ToString(reader.GetValue(codigo_postal1ColumnIndex));
					if(!reader.IsDBNull(latitud1ColumnIndex))
						record.LATITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud1ColumnIndex))
						record.LONGITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(departamento2_idColumnIndex))
						record.DEPARTAMENTO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento2_idColumnIndex)), 9);
					record.ES_VENDEDOR = Convert.ToString(reader.GetValue(es_vendedorColumnIndex));
					record.ES_COBRADOR = Convert.ToString(reader.GetValue(es_cobradorColumnIndex));
					if(!reader.IsDBNull(ciudad2_idColumnIndex))
						record.CIUDAD2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad2_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio2_idColumnIndex))
						record.BARRIO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio2_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle2ColumnIndex))
						record.CALLE2 = Convert.ToString(reader.GetValue(calle2ColumnIndex));
					if(!reader.IsDBNull(codigo_postal2ColumnIndex))
						record.CODIGO_POSTAL2 = Convert.ToString(reader.GetValue(codigo_postal2ColumnIndex));
					if(!reader.IsDBNull(latitud2ColumnIndex))
						record.LATITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud2ColumnIndex))
						record.LONGITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(telefono1ColumnIndex))
						record.TELEFONO1 = Convert.ToString(reader.GetValue(telefono1ColumnIndex));
					if(!reader.IsDBNull(telefono2ColumnIndex))
						record.TELEFONO2 = Convert.ToString(reader.GetValue(telefono2ColumnIndex));
					if(!reader.IsDBNull(telefono3ColumnIndex))
						record.TELEFONO3 = Convert.ToString(reader.GetValue(telefono3ColumnIndex));
					if(!reader.IsDBNull(telefono4ColumnIndex))
						record.TELEFONO4 = Convert.ToString(reader.GetValue(telefono4ColumnIndex));
					if(!reader.IsDBNull(email1ColumnIndex))
						record.EMAIL1 = Convert.ToString(reader.GetValue(email1ColumnIndex));
					if(!reader.IsDBNull(email2ColumnIndex))
						record.EMAIL2 = Convert.ToString(reader.GetValue(email2ColumnIndex));
					if(!reader.IsDBNull(email3ColumnIndex))
						record.EMAIL3 = Convert.ToString(reader.GetValue(email3ColumnIndex));
					if(!reader.IsDBNull(fecha_contratacionColumnIndex))
						record.FECHA_CONTRATACION = Convert.ToDateTime(reader.GetValue(fecha_contratacionColumnIndex));
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(motivo_salidaColumnIndex))
						record.MOTIVO_SALIDA = Convert.ToString(reader.GetValue(motivo_salidaColumnIndex));
					if(!reader.IsDBNull(estado_civil_idColumnIndex))
						record.ESTADO_CIVIL_ID = Convert.ToString(reader.GetValue(estado_civil_idColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_familiar_contactoColumnIndex))
						record.NOMBRE_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(nombre_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(relacion_familiar_contactoColumnIndex))
						record.RELACION_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(relacion_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(telefono_familiar_contactoColumnIndex))
						record.TELEFONO_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(telefono_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(departamento_familiar_cont_idColumnIndex))
						record.DEPARTAMENTO_FAMILIAR_CONT_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_familiar_cont_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_familiar_contacto_idColumnIndex))
						record.CIUDAD_FAMILIAR_CONTACTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_familiar_contacto_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_familiar_contacto_idColumnIndex))
						record.BARRIO_FAMILIAR_CONTACTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_familiar_contacto_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle_familiar_contactoColumnIndex))
						record.CALLE_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(calle_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(cod_post_familiar_contactoColumnIndex))
						record.COD_POST_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(cod_post_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(latitud_familiar_contactoColumnIndex))
						record.LATITUD_FAMILIAR_CONTACTO = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_familiar_contactoColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_familiar_contactoColumnIndex))
						record.LONGITUD_FAMILIAR_CONTACTO = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_familiar_contactoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_seguroColumnIndex))
						record.INGRESO_SEGURO = Convert.ToDateTime(reader.GetValue(ingreso_seguroColumnIndex));
					if(!reader.IsDBNull(salario_tipoColumnIndex))
						record.SALARIO_TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(salario_tipoColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_salario_minimoColumnIndex))
						record.COBRA_SALARIO_MINIMO = Convert.ToString(reader.GetValue(cobra_salario_minimoColumnIndex));
					if(!reader.IsDBNull(salarioColumnIndex))
						record.SALARIO = Math.Round(Convert.ToDecimal(reader.GetValue(salarioColumnIndex)), 9);
					if(!reader.IsDBNull(salario_complementarioColumnIndex))
						record.SALARIO_COMPLEMENTARIO = Math.Round(Convert.ToDecimal(reader.GetValue(salario_complementarioColumnIndex)), 9);
					if(!reader.IsDBNull(salario_extraColumnIndex))
						record.SALARIO_EXTRA = Math.Round(Convert.ToDecimal(reader.GetValue(salario_extraColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_anticipoColumnIndex))
						record.COBRA_ANTICIPO = Convert.ToString(reader.GetValue(cobra_anticipoColumnIndex));
					if(!reader.IsDBNull(monto_anticipoColumnIndex))
						record.MONTO_ANTICIPO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_anticipoColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_bonificacionColumnIndex))
						record.COBRA_BONIFICACION = Convert.ToString(reader.GetValue(cobra_bonificacionColumnIndex));
					if(!reader.IsDBNull(monto_bonificacionColumnIndex))
						record.MONTO_BONIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bonificacionColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacteColumnIndex))
						record.CTACTE = Convert.ToString(reader.GetValue(ctacteColumnIndex));
					if(!reader.IsDBNull(grupo_sanguineoColumnIndex))
						record.GRUPO_SANGUINEO = Convert.ToString(reader.GetValue(grupo_sanguineoColumnIndex));
					record.ES_PROMOTOR = Convert.ToString(reader.GetValue(es_promotorColumnIndex));
					if(!reader.IsDBNull(marcaciones_idColumnIndex))
						record.MARCACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marcaciones_idColumnIndex)), 9);
					record.ES_CHOFER = Convert.ToString(reader.GetValue(es_choferColumnIndex));
					record.DEPOSITERO = Convert.ToString(reader.GetValue(depositeroColumnIndex));
					record.ES_COBRADOR_EXTERNO = Convert.ToString(reader.GetValue(es_cobrador_externoColumnIndex));
					if(!reader.IsDBNull(codigo_talonarioColumnIndex))
						record.CODIGO_TALONARIO = Convert.ToString(reader.GetValue(codigo_talonarioColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuentos_basicoColumnIndex))
						record.DESCUENTOS_BASICO = Convert.ToString(reader.GetValue(descuentos_basicoColumnIndex));
					if(!reader.IsDBNull(descuentos_complementarioColumnIndex))
						record.DESCUENTOS_COMPLEMENTARIO = Convert.ToString(reader.GetValue(descuentos_complementarioColumnIndex));
					if(!reader.IsDBNull(descuentos_extraColumnIndex))
						record.DESCUENTOS_EXTRA = Convert.ToString(reader.GetValue(descuentos_extraColumnIndex));
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOSRow[])(recordList.ToArray(typeof(FUNCIONARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOSRow"/> object.</returns>
		protected virtual FUNCIONARIOSRow MapRow(DataRow row)
		{
			FUNCIONARIOSRow mappedObject = new FUNCIONARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "TRATAMIENTO_ID"
			dataColumn = dataTable.Columns["TRATAMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRATAMIENTO_ID = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "APELLIDO"
			dataColumn = dataTable.Columns["APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APELLIDO = (string)row[dataColumn];
			// Column "APODO"
			dataColumn = dataTable.Columns["APODO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APODO = (string)row[dataColumn];
			// Column "GENERO"
			dataColumn = dataTable.Columns["GENERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERO = (string)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "NACIMIENTO"
			dataColumn = dataTable.Columns["NACIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NACIMIENTO = (System.DateTime)row[dataColumn];
			// Column "TIPO_DOCUMENTO_IDENTIDAD_ID"
			dataColumn = dataTable.Columns["TIPO_DOCUMENTO_IDENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DOCUMENTO_IDENTIDAD_ID = (string)row[dataColumn];
			// Column "NUMERO_DOCUMENTO"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO = (string)row[dataColumn];
			// Column "PAIS_NACIONALIDAD_ID"
			dataColumn = dataTable.Columns["PAIS_NACIONALIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NACIONALIDAD_ID = (decimal)row[dataColumn];
			// Column "PAIS_RESIDENCIA_ID"
			dataColumn = dataTable.Columns["PAIS_RESIDENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_RESIDENCIA_ID = (decimal)row[dataColumn];
			// Column "PROFESION_ID"
			dataColumn = dataTable.Columns["PROFESION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROFESION_ID = (string)row[dataColumn];
			// Column "DEPARTAMENTO1_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ID = (decimal)row[dataColumn];
			// Column "CIUDAD1_ID"
			dataColumn = dataTable.Columns["CIUDAD1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ID = (decimal)row[dataColumn];
			// Column "BARRIO1_ID"
			dataColumn = dataTable.Columns["BARRIO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ID = (decimal)row[dataColumn];
			// Column "CALLE1"
			dataColumn = dataTable.Columns["CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE1 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL1"
			dataColumn = dataTable.Columns["CODIGO_POSTAL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL1 = (string)row[dataColumn];
			// Column "LATITUD1"
			dataColumn = dataTable.Columns["LATITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD1 = (decimal)row[dataColumn];
			// Column "LONGITUD1"
			dataColumn = dataTable.Columns["LONGITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD1 = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO2_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_ID = (decimal)row[dataColumn];
			// Column "ES_VENDEDOR"
			dataColumn = dataTable.Columns["ES_VENDEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_VENDEDOR = (string)row[dataColumn];
			// Column "ES_COBRADOR"
			dataColumn = dataTable.Columns["ES_COBRADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COBRADOR = (string)row[dataColumn];
			// Column "CIUDAD2_ID"
			dataColumn = dataTable.Columns["CIUDAD2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ID = (decimal)row[dataColumn];
			// Column "BARRIO2_ID"
			dataColumn = dataTable.Columns["BARRIO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ID = (decimal)row[dataColumn];
			// Column "CALLE2"
			dataColumn = dataTable.Columns["CALLE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE2 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL2"
			dataColumn = dataTable.Columns["CODIGO_POSTAL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL2 = (string)row[dataColumn];
			// Column "LATITUD2"
			dataColumn = dataTable.Columns["LATITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD2 = (decimal)row[dataColumn];
			// Column "LONGITUD2"
			dataColumn = dataTable.Columns["LONGITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD2 = (decimal)row[dataColumn];
			// Column "TELEFONO1"
			dataColumn = dataTable.Columns["TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO1 = (string)row[dataColumn];
			// Column "TELEFONO2"
			dataColumn = dataTable.Columns["TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO2 = (string)row[dataColumn];
			// Column "TELEFONO3"
			dataColumn = dataTable.Columns["TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO3 = (string)row[dataColumn];
			// Column "TELEFONO4"
			dataColumn = dataTable.Columns["TELEFONO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO4 = (string)row[dataColumn];
			// Column "EMAIL1"
			dataColumn = dataTable.Columns["EMAIL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL1 = (string)row[dataColumn];
			// Column "EMAIL2"
			dataColumn = dataTable.Columns["EMAIL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL2 = (string)row[dataColumn];
			// Column "EMAIL3"
			dataColumn = dataTable.Columns["EMAIL3"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL3 = (string)row[dataColumn];
			// Column "FECHA_CONTRATACION"
			dataColumn = dataTable.Columns["FECHA_CONTRATACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONTRATACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_SALIDA"
			dataColumn = dataTable.Columns["MOTIVO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_SALIDA = (string)row[dataColumn];
			// Column "ESTADO_CIVIL_ID"
			dataColumn = dataTable.Columns["ESTADO_CIVIL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CIVIL_ID = (string)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["NOMBRE_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "RELACION_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["RELACION_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELACION_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "TELEFONO_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["TELEFONO_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "DEPARTAMENTO_FAMILIAR_CONT_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_FAMILIAR_CONT_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_FAMILIAR_CONT_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_FAMILIAR_CONTACTO_ID"
			dataColumn = dataTable.Columns["CIUDAD_FAMILIAR_CONTACTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_FAMILIAR_CONTACTO_ID = (decimal)row[dataColumn];
			// Column "BARRIO_FAMILIAR_CONTACTO_ID"
			dataColumn = dataTable.Columns["BARRIO_FAMILIAR_CONTACTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_FAMILIAR_CONTACTO_ID = (decimal)row[dataColumn];
			// Column "CALLE_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["CALLE_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "COD_POST_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["COD_POST_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COD_POST_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "LATITUD_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["LATITUD_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_FAMILIAR_CONTACTO = (decimal)row[dataColumn];
			// Column "LONGITUD_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["LONGITUD_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_FAMILIAR_CONTACTO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "INGRESO_APROBADO"
			dataColumn = dataTable.Columns["INGRESO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "INGRESO_SEGURO"
			dataColumn = dataTable.Columns["INGRESO_SEGURO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_SEGURO = (System.DateTime)row[dataColumn];
			// Column "SALARIO_TIPO"
			dataColumn = dataTable.Columns["SALARIO_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_TIPO = (decimal)row[dataColumn];
			// Column "COBRA_SALARIO_MINIMO"
			dataColumn = dataTable.Columns["COBRA_SALARIO_MINIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_SALARIO_MINIMO = (string)row[dataColumn];
			// Column "SALARIO"
			dataColumn = dataTable.Columns["SALARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO = (decimal)row[dataColumn];
			// Column "SALARIO_COMPLEMENTARIO"
			dataColumn = dataTable.Columns["SALARIO_COMPLEMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_COMPLEMENTARIO = (decimal)row[dataColumn];
			// Column "SALARIO_EXTRA"
			dataColumn = dataTable.Columns["SALARIO_EXTRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_EXTRA = (decimal)row[dataColumn];
			// Column "COBRA_ANTICIPO"
			dataColumn = dataTable.Columns["COBRA_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_ANTICIPO = (string)row[dataColumn];
			// Column "MONTO_ANTICIPO"
			dataColumn = dataTable.Columns["MONTO_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ANTICIPO = (decimal)row[dataColumn];
			// Column "COBRA_BONIFICACION"
			dataColumn = dataTable.Columns["COBRA_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_BONIFICACION = (string)row[dataColumn];
			// Column "MONTO_BONIFICACION"
			dataColumn = dataTable.Columns["MONTO_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BONIFICACION = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "CTACTE"
			dataColumn = dataTable.Columns["CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE = (string)row[dataColumn];
			// Column "GRUPO_SANGUINEO"
			dataColumn = dataTable.Columns["GRUPO_SANGUINEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_SANGUINEO = (string)row[dataColumn];
			// Column "ES_PROMOTOR"
			dataColumn = dataTable.Columns["ES_PROMOTOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_PROMOTOR = (string)row[dataColumn];
			// Column "MARCACIONES_ID"
			dataColumn = dataTable.Columns["MARCACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCACIONES_ID = (decimal)row[dataColumn];
			// Column "ES_CHOFER"
			dataColumn = dataTable.Columns["ES_CHOFER"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CHOFER = (string)row[dataColumn];
			// Column "DEPOSITERO"
			dataColumn = dataTable.Columns["DEPOSITERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITERO = (string)row[dataColumn];
			// Column "ES_COBRADOR_EXTERNO"
			dataColumn = dataTable.Columns["ES_COBRADOR_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COBRADOR_EXTERNO = (string)row[dataColumn];
			// Column "CODIGO_TALONARIO"
			dataColumn = dataTable.Columns["CODIGO_TALONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_TALONARIO = (string)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTOS_BASICO"
			dataColumn = dataTable.Columns["DESCUENTOS_BASICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_BASICO = (string)row[dataColumn];
			// Column "DESCUENTOS_COMPLEMENTARIO"
			dataColumn = dataTable.Columns["DESCUENTOS_COMPLEMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_COMPLEMENTARIO = (string)row[dataColumn];
			// Column "DESCUENTOS_EXTRA"
			dataColumn = dataTable.Columns["DESCUENTOS_EXTRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_EXTRA = (string)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRATAMIENTO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("APODO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("NACIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TIPO_DOCUMENTO_IDENTIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PAIS_NACIONALIDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAIS_RESIDENCIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROFESION_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL1", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_VENDEDOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_COBRADOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_CONTRATACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MOTIVO_SALIDA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ESTADO_CIVIL_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOMBRE_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("RELACION_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TELEFONO_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_FAMILIAR_CONT_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_FAMILIAR_CONTACTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_FAMILIAR_CONTACTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("COD_POST_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD_FAMILIAR_CONTACTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD_FAMILIAR_CONTACTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INGRESO_SEGURO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("SALARIO_TIPO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRA_SALARIO_MINIMO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("SALARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SALARIO_COMPLEMENTARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SALARIO_EXTRA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRA_ANTICIPO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MONTO_ANTICIPO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRA_BONIFICACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MONTO_BONIFICACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("GRUPO_SANGUINEO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("ES_PROMOTOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MARCACIONES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_CHOFER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_COBRADOR_EXTERNO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO_TALONARIO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTOS_BASICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DESCUENTOS_COMPLEMENTARIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DESCUENTOS_EXTRA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
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

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRATAMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APODO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NACIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_DOCUMENTO_IDENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_NACIONALIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_RESIDENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROFESION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_VENDEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COBRADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CIUDAD2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CONTRATACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_CIVIL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RELACION_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO_FAMILIAR_CONT_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_FAMILIAR_CONTACTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_FAMILIAR_CONTACTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COD_POST_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_SEGURO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SALARIO_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_SALARIO_MINIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALARIO_COMPLEMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALARIO_EXTRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_SANGUINEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_PROMOTOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MARCACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_CHOFER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEPOSITERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COBRADOR_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO_TALONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTOS_BASICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTOS_COMPLEMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTOS_EXTRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOSCollection_Base class
}  // End of namespace
