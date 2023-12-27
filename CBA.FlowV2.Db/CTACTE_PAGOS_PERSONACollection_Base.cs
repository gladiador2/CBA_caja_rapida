// <fileinfo name="CTACTE_PAGOS_PERSONACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERSONACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGOS_PERSONACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERSONACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_CARGA_IDColumnName = "USUARIO_CARGA_ID";
		public const string FUNCIONARIO_COBRADOR_IDColumnName = "FUNCIONARIO_COBRADOR_ID";
		public const string MONEDA_TOTAL_VUELTO_IDColumnName = "MONEDA_TOTAL_VUELTO_ID";
		public const string COTIZACION_MONEDA_TOTAL_VUELTOColumnName = "COTIZACION_MONEDA_TOTAL_VUELTO";
		public const string MONTO_TOTAL_VUELTOColumnName = "MONTO_TOTAL_VUELTO";
		public const string VUELTO_CONVERTIDO_A_ANTICIPOColumnName = "VUELTO_CONVERTIDO_A_ANTICIPO";
		public const string CASO_ANTICIPO_IDColumnName = "CASO_ANTICIPO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string PAGO_CONFIRMADOColumnName = "PAGO_CONFIRMADO";
		public const string FC_CLIENTE1_COMPROBANTE_IDColumnName = "FC_CLIENTE1_COMPROBANTE_ID";
		public const string FC_CLIENTE1_COMP_AUTON_IDColumnName = "FC_CLIENTE1_COMP_AUTON_ID";
		public const string FC_CLIENTE2_COMPROBANTE_IDColumnName = "FC_CLIENTE2_COMPROBANTE_ID";
		public const string FC_CLIENTE2_COMP_AUTON_IDColumnName = "FC_CLIENTE2_COMP_AUTON_ID";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string RECIBO_EMITIR_POR_DOCUMENTOSColumnName = "RECIBO_EMITIR_POR_DOCUMENTOS";
		public const string AUTONUMERACION_RECIBO_IDColumnName = "AUTONUMERACION_RECIBO_ID";
		public const string AUTONUMERACION_ANTICIPO_IDColumnName = "AUTONUMERACION_ANTICIPO_ID";
		public const string CTACTE_RECIBO_NUMEROColumnName = "CTACTE_RECIBO_NUMERO";
		public const string FUNCIONARIO_COBRADOR_EXTER_IDColumnName = "FUNCIONARIO_COBRADOR_EXTER_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERSONACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGOS_PERSONACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGOS_PERSONARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PERSONARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGOS_PERSONARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGOS_PERSONARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGOS_PERSONA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PAGOS_PERSONARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PERSONARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PAGOS_PERSONARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PAGOS_PERSONARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByFUNCIONARIO_COBRADOR_EXTER_ID(decimal funcionario_cobrador_exter_id)
		{
			return GetByFUNCIONARIO_COBRADOR_EXTER_ID(funcionario_cobrador_exter_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <param name="funcionario_cobrador_exter_idNull">true if the method ignores the funcionario_cobrador_exter_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFUNCIONARIO_COBRADOR_EXTER_ID(decimal funcionario_cobrador_exter_id, bool funcionario_cobrador_exter_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_COBRADOR_EXTER_IDCommand(funcionario_cobrador_exter_id, funcionario_cobrador_exter_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_COBRADOR_EXTER_IDAsDataTable(decimal funcionario_cobrador_exter_id)
		{
			return GetByFUNCIONARIO_COBRADOR_EXTER_IDAsDataTable(funcionario_cobrador_exter_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <param name="funcionario_cobrador_exter_idNull">true if the method ignores the funcionario_cobrador_exter_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_COBRADOR_EXTER_IDAsDataTable(decimal funcionario_cobrador_exter_id, bool funcionario_cobrador_exter_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_COBRADOR_EXTER_IDCommand(funcionario_cobrador_exter_id, funcionario_cobrador_exter_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <param name="funcionario_cobrador_exter_idNull">true if the method ignores the funcionario_cobrador_exter_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_COBRADOR_EXTER_IDCommand(decimal funcionario_cobrador_exter_id, bool funcionario_cobrador_exter_idNull)
		{
			string whereSql = "";
			if(funcionario_cobrador_exter_idNull)
				whereSql += "FUNCIONARIO_COBRADOR_EXTER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_COBRADOR_EXTER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_EXTER_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_cobrador_exter_idNull)
				AddParameter(cmd, "FUNCIONARIO_COBRADOR_EXTER_ID", funcionario_cobrador_exter_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByAUTONUMERACION_ANTICIPO_ID(decimal autonumeracion_anticipo_id)
		{
			return GetByAUTONUMERACION_ANTICIPO_ID(autonumeracion_anticipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <param name="autonumeracion_anticipo_idNull">true if the method ignores the autonumeracion_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByAUTONUMERACION_ANTICIPO_ID(decimal autonumeracion_anticipo_id, bool autonumeracion_anticipo_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_ANTICIPO_IDCommand(autonumeracion_anticipo_id, autonumeracion_anticipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_ANTICIPO_IDAsDataTable(decimal autonumeracion_anticipo_id)
		{
			return GetByAUTONUMERACION_ANTICIPO_IDAsDataTable(autonumeracion_anticipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <param name="autonumeracion_anticipo_idNull">true if the method ignores the autonumeracion_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_ANTICIPO_IDAsDataTable(decimal autonumeracion_anticipo_id, bool autonumeracion_anticipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_ANTICIPO_IDCommand(autonumeracion_anticipo_id, autonumeracion_anticipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <param name="autonumeracion_anticipo_idNull">true if the method ignores the autonumeracion_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_ANTICIPO_IDCommand(decimal autonumeracion_anticipo_id, bool autonumeracion_anticipo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_anticipo_idNull)
				whereSql += "AUTONUMERACION_ANTICIPO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ANTICIPO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ANTICIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_anticipo_idNull)
				AddParameter(cmd, "AUTONUMERACION_ANTICIPO_ID", autonumeracion_anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_IDAsDataTable(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_CASO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByCASO_ANTICIPO_ID(decimal caso_anticipo_id)
		{
			return GetByCASO_ANTICIPO_ID(caso_anticipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <param name="caso_anticipo_idNull">true if the method ignores the caso_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByCASO_ANTICIPO_ID(decimal caso_anticipo_id, bool caso_anticipo_idNull)
		{
			return MapRecords(CreateGetByCASO_ANTICIPO_IDCommand(caso_anticipo_id, caso_anticipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ANTICIPO_IDAsDataTable(decimal caso_anticipo_id)
		{
			return GetByCASO_ANTICIPO_IDAsDataTable(caso_anticipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <param name="caso_anticipo_idNull">true if the method ignores the caso_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ANTICIPO_IDAsDataTable(decimal caso_anticipo_id, bool caso_anticipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ANTICIPO_IDCommand(caso_anticipo_id, caso_anticipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <param name="caso_anticipo_idNull">true if the method ignores the caso_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ANTICIPO_IDCommand(decimal caso_anticipo_id, bool caso_anticipo_idNull)
		{
			string whereSql = "";
			if(caso_anticipo_idNull)
				whereSql += "CASO_ANTICIPO_ID IS NULL";
			else
				whereSql += "CASO_ANTICIPO_ID=" + _db.CreateSqlParameterName("CASO_ANTICIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_anticipo_idNull)
				AddParameter(cmd, "CASO_ANTICIPO_ID", caso_anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE1_COMP_AUTON_ID(decimal fc_cliente1_comp_auton_id)
		{
			return GetByFC_CLIENTE1_COMP_AUTON_ID(fc_cliente1_comp_auton_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente1_comp_auton_idNull">true if the method ignores the fc_cliente1_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE1_COMP_AUTON_ID(decimal fc_cliente1_comp_auton_id, bool fc_cliente1_comp_auton_idNull)
		{
			return MapRecords(CreateGetByFC_CLIENTE1_COMP_AUTON_IDCommand(fc_cliente1_comp_auton_id, fc_cliente1_comp_auton_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CLIENTE1_COMP_AUTON_IDAsDataTable(decimal fc_cliente1_comp_auton_id)
		{
			return GetByFC_CLIENTE1_COMP_AUTON_IDAsDataTable(fc_cliente1_comp_auton_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente1_comp_auton_idNull">true if the method ignores the fc_cliente1_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CLIENTE1_COMP_AUTON_IDAsDataTable(decimal fc_cliente1_comp_auton_id, bool fc_cliente1_comp_auton_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CLIENTE1_COMP_AUTON_IDCommand(fc_cliente1_comp_auton_id, fc_cliente1_comp_auton_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente1_comp_auton_idNull">true if the method ignores the fc_cliente1_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CLIENTE1_COMP_AUTON_IDCommand(decimal fc_cliente1_comp_auton_id, bool fc_cliente1_comp_auton_idNull)
		{
			string whereSql = "";
			if(fc_cliente1_comp_auton_idNull)
				whereSql += "FC_CLIENTE1_COMP_AUTON_ID IS NULL";
			else
				whereSql += "FC_CLIENTE1_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMP_AUTON_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_cliente1_comp_auton_idNull)
				AddParameter(cmd, "FC_CLIENTE1_COMP_AUTON_ID", fc_cliente1_comp_auton_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE1_COMPROBANTE_ID(decimal fc_cliente1_comprobante_id)
		{
			return GetByFC_CLIENTE1_COMPROBANTE_ID(fc_cliente1_comprobante_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente1_comprobante_idNull">true if the method ignores the fc_cliente1_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE1_COMPROBANTE_ID(decimal fc_cliente1_comprobante_id, bool fc_cliente1_comprobante_idNull)
		{
			return MapRecords(CreateGetByFC_CLIENTE1_COMPROBANTE_IDCommand(fc_cliente1_comprobante_id, fc_cliente1_comprobante_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CLIENTE1_COMPROBANTE_IDAsDataTable(decimal fc_cliente1_comprobante_id)
		{
			return GetByFC_CLIENTE1_COMPROBANTE_IDAsDataTable(fc_cliente1_comprobante_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente1_comprobante_idNull">true if the method ignores the fc_cliente1_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CLIENTE1_COMPROBANTE_IDAsDataTable(decimal fc_cliente1_comprobante_id, bool fc_cliente1_comprobante_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CLIENTE1_COMPROBANTE_IDCommand(fc_cliente1_comprobante_id, fc_cliente1_comprobante_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente1_comprobante_idNull">true if the method ignores the fc_cliente1_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CLIENTE1_COMPROBANTE_IDCommand(decimal fc_cliente1_comprobante_id, bool fc_cliente1_comprobante_idNull)
		{
			string whereSql = "";
			if(fc_cliente1_comprobante_idNull)
				whereSql += "FC_CLIENTE1_COMPROBANTE_ID IS NULL";
			else
				whereSql += "FC_CLIENTE1_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMPROBANTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_cliente1_comprobante_idNull)
				AddParameter(cmd, "FC_CLIENTE1_COMPROBANTE_ID", fc_cliente1_comprobante_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE2_COMP_AUTON_ID(decimal fc_cliente2_comp_auton_id)
		{
			return GetByFC_CLIENTE2_COMP_AUTON_ID(fc_cliente2_comp_auton_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente2_comp_auton_idNull">true if the method ignores the fc_cliente2_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE2_COMP_AUTON_ID(decimal fc_cliente2_comp_auton_id, bool fc_cliente2_comp_auton_idNull)
		{
			return MapRecords(CreateGetByFC_CLIENTE2_COMP_AUTON_IDCommand(fc_cliente2_comp_auton_id, fc_cliente2_comp_auton_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CLIENTE2_COMP_AUTON_IDAsDataTable(decimal fc_cliente2_comp_auton_id)
		{
			return GetByFC_CLIENTE2_COMP_AUTON_IDAsDataTable(fc_cliente2_comp_auton_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente2_comp_auton_idNull">true if the method ignores the fc_cliente2_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CLIENTE2_COMP_AUTON_IDAsDataTable(decimal fc_cliente2_comp_auton_id, bool fc_cliente2_comp_auton_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CLIENTE2_COMP_AUTON_IDCommand(fc_cliente2_comp_auton_id, fc_cliente2_comp_auton_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente2_comp_auton_idNull">true if the method ignores the fc_cliente2_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CLIENTE2_COMP_AUTON_IDCommand(decimal fc_cliente2_comp_auton_id, bool fc_cliente2_comp_auton_idNull)
		{
			string whereSql = "";
			if(fc_cliente2_comp_auton_idNull)
				whereSql += "FC_CLIENTE2_COMP_AUTON_ID IS NULL";
			else
				whereSql += "FC_CLIENTE2_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMP_AUTON_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_cliente2_comp_auton_idNull)
				AddParameter(cmd, "FC_CLIENTE2_COMP_AUTON_ID", fc_cliente2_comp_auton_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE2_COMPROBANTE_ID(decimal fc_cliente2_comprobante_id)
		{
			return GetByFC_CLIENTE2_COMPROBANTE_ID(fc_cliente2_comprobante_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente2_comprobante_idNull">true if the method ignores the fc_cliente2_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFC_CLIENTE2_COMPROBANTE_ID(decimal fc_cliente2_comprobante_id, bool fc_cliente2_comprobante_idNull)
		{
			return MapRecords(CreateGetByFC_CLIENTE2_COMPROBANTE_IDCommand(fc_cliente2_comprobante_id, fc_cliente2_comprobante_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_CLIENTE2_COMPROBANTE_IDAsDataTable(decimal fc_cliente2_comprobante_id)
		{
			return GetByFC_CLIENTE2_COMPROBANTE_IDAsDataTable(fc_cliente2_comprobante_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente2_comprobante_idNull">true if the method ignores the fc_cliente2_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_CLIENTE2_COMPROBANTE_IDAsDataTable(decimal fc_cliente2_comprobante_id, bool fc_cliente2_comprobante_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_CLIENTE2_COMPROBANTE_IDCommand(fc_cliente2_comprobante_id, fc_cliente2_comprobante_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente2_comprobante_idNull">true if the method ignores the fc_cliente2_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_CLIENTE2_COMPROBANTE_IDCommand(decimal fc_cliente2_comprobante_id, bool fc_cliente2_comprobante_idNull)
		{
			string whereSql = "";
			if(fc_cliente2_comprobante_idNull)
				whereSql += "FC_CLIENTE2_COMPROBANTE_ID IS NULL";
			else
				whereSql += "FC_CLIENTE2_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMPROBANTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_cliente2_comprobante_idNull)
				AddParameter(cmd, "FC_CLIENTE2_COMPROBANTE_ID", fc_cliente2_comprobante_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_COBRADOR_IDAsDataTable(decimal funcionario_cobrador_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_MONVUE</c> foreign key.
		/// </summary>
		/// <param name="moneda_total_vuelto_id">The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByMONEDA_TOTAL_VUELTO_ID(decimal moneda_total_vuelto_id)
		{
			return MapRecords(CreateGetByMONEDA_TOTAL_VUELTO_IDCommand(moneda_total_vuelto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_MONVUE</c> foreign key.
		/// </summary>
		/// <param name="moneda_total_vuelto_id">The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_TOTAL_VUELTO_IDAsDataTable(decimal moneda_total_vuelto_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_TOTAL_VUELTO_IDCommand(moneda_total_vuelto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_MONVUE</c> foreign key.
		/// </summary>
		/// <param name="moneda_total_vuelto_id">The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_TOTAL_VUELTO_IDCommand(decimal moneda_total_vuelto_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_TOTAL_VUELTO_ID=" + _db.CreateSqlParameterName("MONEDA_TOTAL_VUELTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_TOTAL_VUELTO_ID", moneda_total_vuelto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_PERS</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONARow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_IDAsDataTable(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_SUC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_USRCAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONARow[] GetByUSUARIO_CARGA_ID(decimal usuario_carga_id)
		{
			return MapRecords(CreateGetByUSUARIO_CARGA_IDCommand(usuario_carga_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERSONA_USRCAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CARGA_IDAsDataTable(decimal usuario_carga_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CARGA_IDCommand(usuario_carga_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERSONA_USRCAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CARGA_IDCommand(decimal usuario_carga_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CARGA_ID", usuario_carga_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONARow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PAGOS_PERSONARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PAGOS_PERSONA (" +
				"ID, " +
				"CASO_ID, " +
				"CTACTE_RECIBO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"FECHA, " +
				"USUARIO_CARGA_ID, " +
				"FUNCIONARIO_COBRADOR_ID, " +
				"MONEDA_TOTAL_VUELTO_ID, " +
				"COTIZACION_MONEDA_TOTAL_VUELTO, " +
				"MONTO_TOTAL_VUELTO, " +
				"VUELTO_CONVERTIDO_A_ANTICIPO, " +
				"CASO_ANTICIPO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"PAGO_CONFIRMADO, " +
				"FC_CLIENTE1_COMPROBANTE_ID, " +
				"FC_CLIENTE1_COMP_AUTON_ID, " +
				"FC_CLIENTE2_COMPROBANTE_ID, " +
				"FC_CLIENTE2_COMP_AUTON_ID, " +
				"FECHA_CONFIRMACION, " +
				"RECIBO_EMITIR_POR_DOCUMENTOS, " +
				"AUTONUMERACION_RECIBO_ID, " +
				"AUTONUMERACION_ANTICIPO_ID, " +
				"CTACTE_RECIBO_NUMERO, " +
				"FUNCIONARIO_COBRADOR_EXTER_ID, " +
				"ESTADO, " +
				"CASO_ASOCIADO_ID, " +
				"TEXTO_PREDEFINIDO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_CARGA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_TOTAL_VUELTO_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_TOTAL_VUELTO") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL_VUELTO") + ", " +
				_db.CreateSqlParameterName("VUELTO_CONVERTIDO_A_ANTICIPO") + ", " +
				_db.CreateSqlParameterName("CASO_ANTICIPO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("PAGO_CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("FC_CLIENTE1_COMPROBANTE_ID") + ", " +
				_db.CreateSqlParameterName("FC_CLIENTE1_COMP_AUTON_ID") + ", " +
				_db.CreateSqlParameterName("FC_CLIENTE2_COMPROBANTE_ID") + ", " +
				_db.CreateSqlParameterName("FC_CLIENTE2_COMP_AUTON_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				_db.CreateSqlParameterName("RECIBO_EMITIR_POR_DOCUMENTOS") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ANTICIPO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_NUMERO") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_EXTER_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_CARGA_ID", value.USUARIO_CARGA_ID);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "MONEDA_TOTAL_VUELTO_ID", value.MONEDA_TOTAL_VUELTO_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_TOTAL_VUELTO", value.COTIZACION_MONEDA_TOTAL_VUELTO);
			AddParameter(cmd, "MONTO_TOTAL_VUELTO", value.MONTO_TOTAL_VUELTO);
			AddParameter(cmd, "VUELTO_CONVERTIDO_A_ANTICIPO", value.VUELTO_CONVERTIDO_A_ANTICIPO);
			AddParameter(cmd, "CASO_ANTICIPO_ID",
				value.IsCASO_ANTICIPO_IDNull ? DBNull.Value : (object)value.CASO_ANTICIPO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "PAGO_CONFIRMADO", value.PAGO_CONFIRMADO);
			AddParameter(cmd, "FC_CLIENTE1_COMPROBANTE_ID",
				value.IsFC_CLIENTE1_COMPROBANTE_IDNull ? DBNull.Value : (object)value.FC_CLIENTE1_COMPROBANTE_ID);
			AddParameter(cmd, "FC_CLIENTE1_COMP_AUTON_ID",
				value.IsFC_CLIENTE1_COMP_AUTON_IDNull ? DBNull.Value : (object)value.FC_CLIENTE1_COMP_AUTON_ID);
			AddParameter(cmd, "FC_CLIENTE2_COMPROBANTE_ID",
				value.IsFC_CLIENTE2_COMPROBANTE_IDNull ? DBNull.Value : (object)value.FC_CLIENTE2_COMPROBANTE_ID);
			AddParameter(cmd, "FC_CLIENTE2_COMP_AUTON_ID",
				value.IsFC_CLIENTE2_COMP_AUTON_IDNull ? DBNull.Value : (object)value.FC_CLIENTE2_COMP_AUTON_ID);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "RECIBO_EMITIR_POR_DOCUMENTOS", value.RECIBO_EMITIR_POR_DOCUMENTOS);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "AUTONUMERACION_ANTICIPO_ID",
				value.IsAUTONUMERACION_ANTICIPO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ANTICIPO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_NUMERO", value.CTACTE_RECIBO_NUMERO);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_EXTER_ID",
				value.IsFUNCIONARIO_COBRADOR_EXTER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_COBRADOR_EXTER_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PAGOS_PERSONARow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PAGOS_PERSONA SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID") + ", " +
				"FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				"MONEDA_TOTAL_VUELTO_ID=" + _db.CreateSqlParameterName("MONEDA_TOTAL_VUELTO_ID") + ", " +
				"COTIZACION_MONEDA_TOTAL_VUELTO=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_TOTAL_VUELTO") + ", " +
				"MONTO_TOTAL_VUELTO=" + _db.CreateSqlParameterName("MONTO_TOTAL_VUELTO") + ", " +
				"VUELTO_CONVERTIDO_A_ANTICIPO=" + _db.CreateSqlParameterName("VUELTO_CONVERTIDO_A_ANTICIPO") + ", " +
				"CASO_ANTICIPO_ID=" + _db.CreateSqlParameterName("CASO_ANTICIPO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"PAGO_CONFIRMADO=" + _db.CreateSqlParameterName("PAGO_CONFIRMADO") + ", " +
				"FC_CLIENTE1_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMPROBANTE_ID") + ", " +
				"FC_CLIENTE1_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMP_AUTON_ID") + ", " +
				"FC_CLIENTE2_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMPROBANTE_ID") + ", " +
				"FC_CLIENTE2_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMP_AUTON_ID") + ", " +
				"FECHA_CONFIRMACION=" + _db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				"RECIBO_EMITIR_POR_DOCUMENTOS=" + _db.CreateSqlParameterName("RECIBO_EMITIR_POR_DOCUMENTOS") + ", " +
				"AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				"AUTONUMERACION_ANTICIPO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ANTICIPO_ID") + ", " +
				"CTACTE_RECIBO_NUMERO=" + _db.CreateSqlParameterName("CTACTE_RECIBO_NUMERO") + ", " +
				"FUNCIONARIO_COBRADOR_EXTER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_EXTER_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_CARGA_ID", value.USUARIO_CARGA_ID);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "MONEDA_TOTAL_VUELTO_ID", value.MONEDA_TOTAL_VUELTO_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_TOTAL_VUELTO", value.COTIZACION_MONEDA_TOTAL_VUELTO);
			AddParameter(cmd, "MONTO_TOTAL_VUELTO", value.MONTO_TOTAL_VUELTO);
			AddParameter(cmd, "VUELTO_CONVERTIDO_A_ANTICIPO", value.VUELTO_CONVERTIDO_A_ANTICIPO);
			AddParameter(cmd, "CASO_ANTICIPO_ID",
				value.IsCASO_ANTICIPO_IDNull ? DBNull.Value : (object)value.CASO_ANTICIPO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "PAGO_CONFIRMADO", value.PAGO_CONFIRMADO);
			AddParameter(cmd, "FC_CLIENTE1_COMPROBANTE_ID",
				value.IsFC_CLIENTE1_COMPROBANTE_IDNull ? DBNull.Value : (object)value.FC_CLIENTE1_COMPROBANTE_ID);
			AddParameter(cmd, "FC_CLIENTE1_COMP_AUTON_ID",
				value.IsFC_CLIENTE1_COMP_AUTON_IDNull ? DBNull.Value : (object)value.FC_CLIENTE1_COMP_AUTON_ID);
			AddParameter(cmd, "FC_CLIENTE2_COMPROBANTE_ID",
				value.IsFC_CLIENTE2_COMPROBANTE_IDNull ? DBNull.Value : (object)value.FC_CLIENTE2_COMPROBANTE_ID);
			AddParameter(cmd, "FC_CLIENTE2_COMP_AUTON_ID",
				value.IsFC_CLIENTE2_COMP_AUTON_IDNull ? DBNull.Value : (object)value.FC_CLIENTE2_COMP_AUTON_ID);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "RECIBO_EMITIR_POR_DOCUMENTOS", value.RECIBO_EMITIR_POR_DOCUMENTOS);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "AUTONUMERACION_ANTICIPO_ID",
				value.IsAUTONUMERACION_ANTICIPO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ANTICIPO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_NUMERO", value.CTACTE_RECIBO_NUMERO);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_EXTER_ID",
				value.IsFUNCIONARIO_COBRADOR_EXTER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_COBRADOR_EXTER_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PERSONA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PERSONA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PAGOS_PERSONARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PAGOS_PERSONA</c> table using
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_P_TEX_PRE_ID</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PER_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_COBRADOR_EXTER_ID(decimal funcionario_cobrador_exter_id)
		{
			return DeleteByFUNCIONARIO_COBRADOR_EXTER_ID(funcionario_cobrador_exter_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <param name="funcionario_cobrador_exter_idNull">true if the method ignores the funcionario_cobrador_exter_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_COBRADOR_EXTER_ID(decimal funcionario_cobrador_exter_id, bool funcionario_cobrador_exter_idNull)
		{
			return CreateDeleteByFUNCIONARIO_COBRADOR_EXTER_IDCommand(funcionario_cobrador_exter_id, funcionario_cobrador_exter_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PER_FUNCOB_EXT</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_exter_id">The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</param>
		/// <param name="funcionario_cobrador_exter_idNull">true if the method ignores the funcionario_cobrador_exter_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_COBRADOR_EXTER_IDCommand(decimal funcionario_cobrador_exter_id, bool funcionario_cobrador_exter_idNull)
		{
			string whereSql = "";
			if(funcionario_cobrador_exter_idNull)
				whereSql += "FUNCIONARIO_COBRADOR_EXTER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_COBRADOR_EXTER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_EXTER_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_cobrador_exter_idNull)
				AddParameter(cmd, "FUNCIONARIO_COBRADOR_EXTER_ID", funcionario_cobrador_exter_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ANTICIPO_ID(decimal autonumeracion_anticipo_id)
		{
			return DeleteByAUTONUMERACION_ANTICIPO_ID(autonumeracion_anticipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <param name="autonumeracion_anticipo_idNull">true if the method ignores the autonumeracion_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ANTICIPO_ID(decimal autonumeracion_anticipo_id, bool autonumeracion_anticipo_idNull)
		{
			return CreateDeleteByAUTONUMERACION_ANTICIPO_IDCommand(autonumeracion_anticipo_id, autonumeracion_anticipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_AUT_ANT</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_anticipo_id">The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</param>
		/// <param name="autonumeracion_anticipo_idNull">true if the method ignores the autonumeracion_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_ANTICIPO_IDCommand(decimal autonumeracion_anticipo_id, bool autonumeracion_anticipo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_anticipo_idNull)
				whereSql += "AUTONUMERACION_ANTICIPO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ANTICIPO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ANTICIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_anticipo_idNull)
				AddParameter(cmd, "AUTONUMERACION_ANTICIPO_ID", autonumeracion_anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return DeleteByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_AUT_REC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_CASO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ANTICIPO_ID(decimal caso_anticipo_id)
		{
			return DeleteByCASO_ANTICIPO_ID(caso_anticipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <param name="caso_anticipo_idNull">true if the method ignores the caso_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ANTICIPO_ID(decimal caso_anticipo_id, bool caso_anticipo_idNull)
		{
			return CreateDeleteByCASO_ANTICIPO_IDCommand(caso_anticipo_id, caso_anticipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_CASO_A</c> foreign key.
		/// </summary>
		/// <param name="caso_anticipo_id">The <c>CASO_ANTICIPO_ID</c> column value.</param>
		/// <param name="caso_anticipo_idNull">true if the method ignores the caso_anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ANTICIPO_IDCommand(decimal caso_anticipo_id, bool caso_anticipo_idNull)
		{
			string whereSql = "";
			if(caso_anticipo_idNull)
				whereSql += "CASO_ANTICIPO_ID IS NULL";
			else
				whereSql += "CASO_ANTICIPO_ID=" + _db.CreateSqlParameterName("CASO_ANTICIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_anticipo_idNull)
				AddParameter(cmd, "CASO_ANTICIPO_ID", caso_anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE1_COMP_AUTON_ID(decimal fc_cliente1_comp_auton_id)
		{
			return DeleteByFC_CLIENTE1_COMP_AUTON_ID(fc_cliente1_comp_auton_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente1_comp_auton_idNull">true if the method ignores the fc_cliente1_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE1_COMP_AUTON_ID(decimal fc_cliente1_comp_auton_id, bool fc_cliente1_comp_auton_idNull)
		{
			return CreateDeleteByFC_CLIENTE1_COMP_AUTON_IDCommand(fc_cliente1_comp_auton_id, fc_cliente1_comp_auton_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_FC1_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comp_auton_id">The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente1_comp_auton_idNull">true if the method ignores the fc_cliente1_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CLIENTE1_COMP_AUTON_IDCommand(decimal fc_cliente1_comp_auton_id, bool fc_cliente1_comp_auton_idNull)
		{
			string whereSql = "";
			if(fc_cliente1_comp_auton_idNull)
				whereSql += "FC_CLIENTE1_COMP_AUTON_ID IS NULL";
			else
				whereSql += "FC_CLIENTE1_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMP_AUTON_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_cliente1_comp_auton_idNull)
				AddParameter(cmd, "FC_CLIENTE1_COMP_AUTON_ID", fc_cliente1_comp_auton_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE1_COMPROBANTE_ID(decimal fc_cliente1_comprobante_id)
		{
			return DeleteByFC_CLIENTE1_COMPROBANTE_ID(fc_cliente1_comprobante_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente1_comprobante_idNull">true if the method ignores the fc_cliente1_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE1_COMPROBANTE_ID(decimal fc_cliente1_comprobante_id, bool fc_cliente1_comprobante_idNull)
		{
			return CreateDeleteByFC_CLIENTE1_COMPROBANTE_IDCommand(fc_cliente1_comprobante_id, fc_cliente1_comprobante_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_FC1_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente1_comprobante_id">The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente1_comprobante_idNull">true if the method ignores the fc_cliente1_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CLIENTE1_COMPROBANTE_IDCommand(decimal fc_cliente1_comprobante_id, bool fc_cliente1_comprobante_idNull)
		{
			string whereSql = "";
			if(fc_cliente1_comprobante_idNull)
				whereSql += "FC_CLIENTE1_COMPROBANTE_ID IS NULL";
			else
				whereSql += "FC_CLIENTE1_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE1_COMPROBANTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_cliente1_comprobante_idNull)
				AddParameter(cmd, "FC_CLIENTE1_COMPROBANTE_ID", fc_cliente1_comprobante_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE2_COMP_AUTON_ID(decimal fc_cliente2_comp_auton_id)
		{
			return DeleteByFC_CLIENTE2_COMP_AUTON_ID(fc_cliente2_comp_auton_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente2_comp_auton_idNull">true if the method ignores the fc_cliente2_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE2_COMP_AUTON_ID(decimal fc_cliente2_comp_auton_id, bool fc_cliente2_comp_auton_idNull)
		{
			return CreateDeleteByFC_CLIENTE2_COMP_AUTON_IDCommand(fc_cliente2_comp_auton_id, fc_cliente2_comp_auton_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_FC2_AU</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comp_auton_id">The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</param>
		/// <param name="fc_cliente2_comp_auton_idNull">true if the method ignores the fc_cliente2_comp_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CLIENTE2_COMP_AUTON_IDCommand(decimal fc_cliente2_comp_auton_id, bool fc_cliente2_comp_auton_idNull)
		{
			string whereSql = "";
			if(fc_cliente2_comp_auton_idNull)
				whereSql += "FC_CLIENTE2_COMP_AUTON_ID IS NULL";
			else
				whereSql += "FC_CLIENTE2_COMP_AUTON_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMP_AUTON_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_cliente2_comp_auton_idNull)
				AddParameter(cmd, "FC_CLIENTE2_COMP_AUTON_ID", fc_cliente2_comp_auton_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE2_COMPROBANTE_ID(decimal fc_cliente2_comprobante_id)
		{
			return DeleteByFC_CLIENTE2_COMPROBANTE_ID(fc_cliente2_comprobante_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente2_comprobante_idNull">true if the method ignores the fc_cliente2_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_CLIENTE2_COMPROBANTE_ID(decimal fc_cliente2_comprobante_id, bool fc_cliente2_comprobante_idNull)
		{
			return CreateDeleteByFC_CLIENTE2_COMPROBANTE_IDCommand(fc_cliente2_comprobante_id, fc_cliente2_comprobante_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_FC2_ID</c> foreign key.
		/// </summary>
		/// <param name="fc_cliente2_comprobante_id">The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</param>
		/// <param name="fc_cliente2_comprobante_idNull">true if the method ignores the fc_cliente2_comprobante_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_CLIENTE2_COMPROBANTE_IDCommand(decimal fc_cliente2_comprobante_id, bool fc_cliente2_comprobante_idNull)
		{
			string whereSql = "";
			if(fc_cliente2_comprobante_idNull)
				whereSql += "FC_CLIENTE2_COMPROBANTE_ID IS NULL";
			else
				whereSql += "FC_CLIENTE2_COMPROBANTE_ID=" + _db.CreateSqlParameterName("FC_CLIENTE2_COMPROBANTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_cliente2_comprobante_idNull)
				AddParameter(cmd, "FC_CLIENTE2_COMPROBANTE_ID", fc_cliente2_comprobante_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_MONVUE</c> foreign key.
		/// </summary>
		/// <param name="moneda_total_vuelto_id">The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_TOTAL_VUELTO_ID(decimal moneda_total_vuelto_id)
		{
			return CreateDeleteByMONEDA_TOTAL_VUELTO_IDCommand(moneda_total_vuelto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_MONVUE</c> foreign key.
		/// </summary>
		/// <param name="moneda_total_vuelto_id">The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_TOTAL_VUELTO_IDCommand(decimal moneda_total_vuelto_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_TOTAL_VUELTO_ID=" + _db.CreateSqlParameterName("MONEDA_TOTAL_VUELTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_TOTAL_VUELTO_ID", moneda_total_vuelto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_PERS</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return DeleteByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return CreateDeleteByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_SUC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERSONA_USRCAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CARGA_ID(decimal usuario_carga_id)
		{
			return CreateDeleteByUSUARIO_CARGA_IDCommand(usuario_carga_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERSONA_USRCAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CARGA_IDCommand(decimal usuario_carga_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CARGA_ID", usuario_carga_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PAGOS_PERSONA</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PAGOS_PERSONA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PAGOS_PERSONA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PAGOS_PERSONA</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONARow"/> objects.</returns>
		protected virtual CTACTE_PAGOS_PERSONARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_carga_idColumnIndex = reader.GetOrdinal("USUARIO_CARGA_ID");
			int funcionario_cobrador_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_ID");
			int moneda_total_vuelto_idColumnIndex = reader.GetOrdinal("MONEDA_TOTAL_VUELTO_ID");
			int cotizacion_moneda_total_vueltoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_TOTAL_VUELTO");
			int monto_total_vueltoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_VUELTO");
			int vuelto_convertido_a_anticipoColumnIndex = reader.GetOrdinal("VUELTO_CONVERTIDO_A_ANTICIPO");
			int caso_anticipo_idColumnIndex = reader.GetOrdinal("CASO_ANTICIPO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int pago_confirmadoColumnIndex = reader.GetOrdinal("PAGO_CONFIRMADO");
			int fc_cliente1_comprobante_idColumnIndex = reader.GetOrdinal("FC_CLIENTE1_COMPROBANTE_ID");
			int fc_cliente1_comp_auton_idColumnIndex = reader.GetOrdinal("FC_CLIENTE1_COMP_AUTON_ID");
			int fc_cliente2_comprobante_idColumnIndex = reader.GetOrdinal("FC_CLIENTE2_COMPROBANTE_ID");
			int fc_cliente2_comp_auton_idColumnIndex = reader.GetOrdinal("FC_CLIENTE2_COMP_AUTON_ID");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int recibo_emitir_por_documentosColumnIndex = reader.GetOrdinal("RECIBO_EMITIR_POR_DOCUMENTOS");
			int autonumeracion_recibo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_ID");
			int autonumeracion_anticipo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ANTICIPO_ID");
			int ctacte_recibo_numeroColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_NUMERO");
			int funcionario_cobrador_exter_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_EXTER_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGOS_PERSONARow record = new CTACTE_PAGOS_PERSONARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_CARGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_carga_idColumnIndex)), 9);
					record.FUNCIONARIO_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_idColumnIndex)), 9);
					record.MONEDA_TOTAL_VUELTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_total_vuelto_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_TOTAL_VUELTO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_total_vueltoColumnIndex)), 9);
					record.MONTO_TOTAL_VUELTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_vueltoColumnIndex)), 9);
					record.VUELTO_CONVERTIDO_A_ANTICIPO = Convert.ToString(reader.GetValue(vuelto_convertido_a_anticipoColumnIndex));
					if(!reader.IsDBNull(caso_anticipo_idColumnIndex))
						record.CASO_ANTICIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_anticipo_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.PAGO_CONFIRMADO = Convert.ToString(reader.GetValue(pago_confirmadoColumnIndex));
					if(!reader.IsDBNull(fc_cliente1_comprobante_idColumnIndex))
						record.FC_CLIENTE1_COMPROBANTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente1_comprobante_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente1_comp_auton_idColumnIndex))
						record.FC_CLIENTE1_COMP_AUTON_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente1_comp_auton_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente2_comprobante_idColumnIndex))
						record.FC_CLIENTE2_COMPROBANTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente2_comprobante_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente2_comp_auton_idColumnIndex))
						record.FC_CLIENTE2_COMP_AUTON_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente2_comp_auton_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
					record.RECIBO_EMITIR_POR_DOCUMENTOS = Convert.ToString(reader.GetValue(recibo_emitir_por_documentosColumnIndex));
					if(!reader.IsDBNull(autonumeracion_recibo_idColumnIndex))
						record.AUTONUMERACION_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_anticipo_idColumnIndex))
						record.AUTONUMERACION_ANTICIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_anticipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_numeroColumnIndex))
						record.CTACTE_RECIBO_NUMERO = Convert.ToString(reader.GetValue(ctacte_recibo_numeroColumnIndex));
					if(!reader.IsDBNull(funcionario_cobrador_exter_idColumnIndex))
						record.FUNCIONARIO_COBRADOR_EXTER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_exter_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGOS_PERSONARow[])(recordList.ToArray(typeof(CTACTE_PAGOS_PERSONARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGOS_PERSONARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGOS_PERSONARow"/> object.</returns>
		protected virtual CTACTE_PAGOS_PERSONARow MapRow(DataRow row)
		{
			CTACTE_PAGOS_PERSONARow mappedObject = new CTACTE_PAGOS_PERSONARow();
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
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CARGA_ID"
			dataColumn = dataTable.Columns["USUARIO_CARGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CARGA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_TOTAL_VUELTO_ID"
			dataColumn = dataTable.Columns["MONEDA_TOTAL_VUELTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_TOTAL_VUELTO_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_TOTAL_VUELTO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_TOTAL_VUELTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_TOTAL_VUELTO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_VUELTO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_VUELTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_VUELTO = (decimal)row[dataColumn];
			// Column "VUELTO_CONVERTIDO_A_ANTICIPO"
			dataColumn = dataTable.Columns["VUELTO_CONVERTIDO_A_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VUELTO_CONVERTIDO_A_ANTICIPO = (string)row[dataColumn];
			// Column "CASO_ANTICIPO_ID"
			dataColumn = dataTable.Columns["CASO_ANTICIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ANTICIPO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "PAGO_CONFIRMADO"
			dataColumn = dataTable.Columns["PAGO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONFIRMADO = (string)row[dataColumn];
			// Column "FC_CLIENTE1_COMPROBANTE_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE1_COMPROBANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE1_COMPROBANTE_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE1_COMP_AUTON_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE1_COMP_AUTON_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE1_COMP_AUTON_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE2_COMPROBANTE_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE2_COMPROBANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE2_COMPROBANTE_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE2_COMP_AUTON_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE2_COMP_AUTON_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE2_COMP_AUTON_ID = (decimal)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
			// Column "RECIBO_EMITIR_POR_DOCUMENTOS"
			dataColumn = dataTable.Columns["RECIBO_EMITIR_POR_DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_EMITIR_POR_DOCUMENTOS = (string)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ANTICIPO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ANTICIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ANTICIPO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_NUMERO"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_NUMERO = (string)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_EXTER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_EXTER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_EXTER_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGOS_PERSONA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CARGA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_TOTAL_VUELTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_TOTAL_VUELTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_VUELTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VUELTO_CONVERTIDO_A_ANTICIPO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ANTICIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAGO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FC_CLIENTE1_COMPROBANTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_CLIENTE1_COMP_AUTON_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_CLIENTE2_COMPROBANTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_CLIENTE2_COMP_AUTON_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("RECIBO_EMITIR_POR_DOCUMENTOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ANTICIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_EXTER_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
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

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CARGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_TOTAL_VUELTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_TOTAL_VUELTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_VUELTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VUELTO_CONVERTIDO_A_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ANTICIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAGO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FC_CLIENTE1_COMPROBANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE1_COMP_AUTON_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE2_COMPROBANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE2_COMP_AUTON_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "RECIBO_EMITIR_POR_DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUTONUMERACION_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ANTICIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_COBRADOR_EXTER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGOS_PERSONACollection_Base class
}  // End of namespace
