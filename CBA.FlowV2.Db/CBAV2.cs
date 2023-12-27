#define ORACLE_DATA_ACCESS
// <fileinfo name="CBAV2.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			You can update this source code manually. If the file
//			already exists it will not be rewritten by the generator.
//		</remarks>
//		<generator rewritefile="False" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;
using System.Data;
//using para configuraciones
using CBA.FlowV2.Db.Config;

namespace CBA.FlowV2.Db
{
    /// <summary>
    /// Represents a connection to the <c>CBAV2</c> database.
    /// </summary>
    /// <remarks>
    /// If the <c>CBAV2</c> goes out of scope, the connection to the 
    /// database is not closed automatically. Therefore, you must explicitly close the 
    /// connection by calling the <c>Close</c> or <c>Dispose</c> method.
    /// </remarks>
    /// <example>
    /// using(CBAV2 db = new CBAV2())
    /// {
    ///		ABOGADOSRow[] rows = db.ABOGADOSTable.GetAll();
    /// }
    /// </example>
    public class CBAV2 : CBAV2_Base
    {



        /// <summary>
        /// Initializes a new instance of the <see cref="CBAV2"/> class.
        /// </summary>
        /// 
        public CBAV2()
        {
            // EMPTY
        }
        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns>An <see cref="System.Data.IDbConnection"/> object.</returns>
        protected override IDbConnection CreateConnection()
        {
#if ODBC
		            return new System.Data.Odbc.OdbcConnection("INSERT ODBC CONNECTION STRING");
#elif ORACLE_CLIENT
		            return new System.Data.OracleClient.OracleConnection(
			            "Password=copernicus;User ID=trc;Data Source=cbav2");
#elif ORACLE_DATA_ACCESS
            this.configuracionesDB = new ConfiguracionesDB();
            string oradb = this.configuracionesDB.getCadenaDeConexion();
            return new Oracle.ManagedDataAccess.Client.OracleConnection(oradb);
#else
		            return new System.Data.OleDb.OleDbConnection(
			            "Provider=OraOLEDB.Oracle.1;Password=copernicus;Persist Security I" +
			            "nfo=True;User ID=trc;Data Source=CONSEJO");
#endif
        }

#if ORACLE_CLIENT
		/// <summary>
		/// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		protected internal override IDataReader ExecuteReader(IDbCommand command)
		{
			if(CommandType.StoredProcedure == command.CommandType 
					&& !command.Parameters.Contains(CreateCollectionParameterName("o_cursor")))
			{
				IDbDataParameter parameter = AddParameter(command, "o_cursor", DbType.Object, null);
				parameter.Direction = ParameterDirection.Output;
				((System.Data.OracleClient.OracleParameter)parameter).OracleType = System.Data.OracleClient.OracleType.Cursor;
			}
			return base.ExecuteReader(command);
		}
#endif

#if ORACLE_DATA_ACCESS
        /// <summary>
        /// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
        protected internal override IDataReader ExecuteReader(IDbCommand command)
        {
            if (CommandType.StoredProcedure == command.CommandType
                    && !command.Parameters.Contains(CreateCollectionParameterName("o_cursor")))
            {
                IDbDataParameter parameter = AddParameter(command, "o_cursor", DbType.Object, null);
                parameter.Direction = ParameterDirection.Output;
                ((Oracle.ManagedDataAccess.Client.OracleParameter)parameter).OracleDbType =
                    Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor;
                //System.Data.OracleClient.OracleType.Cursor;
            }
            return base.ExecuteReader(command);
        }
#endif
        /// <summary>
        /// Creates a DataTable object for the specified command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected internal DataTable CreateDataTable(IDbCommand command)
        {
            DataTable dataTable = new DataTable();
#if ODBC
			new System.Data.Odbc.OdbcDataAdapter((System.Data.Odbc.OdbcCommand)command).Fill(dataTable);
#elif ORACLE_CLIENT
			new System.Data.OracleClient.OracleDataAdapter((System.Data.OracleClient.OracleCommand)command).Fill(dataTable);
#elif ORACLE_DATA_ACCESS
            new Oracle.ManagedDataAccess.Client.OracleDataAdapter((Oracle.ManagedDataAccess.Client.OracleCommand)command).Fill(dataTable);
#else
			new System.Data.OleDb.OleDbDataAdapter((System.Data.OleDb.OleDbCommand)command).Fill(dataTable);
#endif
            return dataTable;
        }

        /// <summary>
        /// Returns a SQL statement parameter name that is specific for the data provider.
        /// For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
        /// </summary>
        /// <param name="paramName">The data provider neutral SQL parameter name.</param>
        /// <returns>The SQL statement parameter name.</returns>
        protected internal override string CreateSqlParameterName(string paramName)
        {
#if ODBC
			return "?";
#elif ORACLE_CLIENT
			return ":" + paramName;
#elif ORACLE_DATA_ACCESS
            return ":" + paramName;
#else
			return "?";
#endif
        }

        /// <summary>
        /// Creates a .Net data provider specific parameter name that is used to
        /// create a parameter object and add it to the parameter collection of
        /// <see cref="System.Data.IDbCommand"/>.
        /// </summary>
        /// <param name="baseParamName">The base name of the parameter.</param>
        /// <returns>The full data provider specific parameter name.</returns>
        protected override string CreateCollectionParameterName(string baseParamName)
        {
#if ODBC
			return "@" + baseParamName;
#elif ORACLE_CLIENT
			return baseParamName;
#elif ORACLE_DATA_ACCESS
            return baseParamName;
#else
			return "@" + baseParamName;
#endif
        }

        #region variables privadas
        private ConfiguracionesDB _configuracionesDB;
        #endregion

        #region Propiedades
        private ConfiguracionesDB configuracionesDB
        {
            get { return this._configuracionesDB; }
            set { this._configuracionesDB = value; }
        }
        #endregion


        /// <summary>
        /// Gets the siguiente secuencia.
        /// </summary>
        /// <param name="nombre_secuencia">The nombre_secuencia.</param>
        /// <returns></returns>
        public decimal GetSiguienteSecuencia(string nombre_secuencia)
        {
            DataTable seq = new DataTable();
            seq = EjecutarQuery("select " + nombre_secuencia + ".nextval seq from dual");
            return seq.Rows[0].Field<Decimal>(0);
        }

        /// <summary>
        /// Gets the sesion acutal del usuario.
        /// </summary>
        /// <param name="nombre_usuario">The nombre_usuario.</param>
        /// <returns></returns>
        public int GetSesionAcutalDelUsuario(string nombre_usuario)
        {
            DataTable seq = new DataTable();
            seq = EjecutarQuery("select nvl(sesion,-1) sesion from usuarios where upper(usuario) = '"+nombre_usuario.ToUpper()+"'");
            return int.Parse(seq.Rows[0][0].ToString());//.Field<int>(0);
        }

        /// <summary>
        /// Dado un DataTable origen, devuelve otro DataTable con filas unicas segun las columnas.
        /// </summary>
        /// <param name="columnasACopiar">The columnas A copiar.</param>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public DataTable ObtenerDistintos(string[] columnasACopiar, DataTable dt)
        {
            return dt.DefaultView.ToTable(true, columnasACopiar);
        }

        /// <summary>
        /// Cambiar la variable de sesion para que las comparaciones no
        /// distingan entre mayusculas, minusculas ni tildes.
        /// Baja la eficiencia, por lo que luego debe llamarse a FinalizarBusquedaFlexible()
        /// </summary>
        public void IniciarBusquedaFlexible()
        {
            EjecutarQuery("ALTER SESSION SET NLS_COMP=LINGUISTIC");
            EjecutarQuery("ALTER SESSION SET NLS_SORT=GENERIC_BASELETTER");
        }
        /// Cambiar la variable de sesion para que las comparaciones
        /// distingan entre mayusculas y minusculas ademas de diferenciar las tildes.
        /// Debe llamarse luego de haber utilizado IniciarBusquedaFlexible()
        public void FinalizarBusquedaFlexible()
        {
            EjecutarQuery("ALTER SESSION SET NLS_COMP=BINARY");
            EjecutarQuery("ALTER SESSION SET NLS_SORT=SPANISH");
        }

        public DataTable EjecutarQuery(string query)
        {
            IDbCommand cmd = CreateCommand(query);
            return CreateDataTable(cmd);
        }


        /// <summary>
        /// Obtener el conjunto de valores distintos que contiene la columna de
        /// la tabla, luego de aplicar el filtrado del where.
        /// </summary>
        /// <param name="tabla">The tabla.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public DataTable GetDistintos(string tabla, string columna, string where)
        {
            string query;
            
            if(where.Length > 0)
                query = "select distinct " + columna + " from " + tabla + " where " + where;
            else
                query = "select distinct " + columna + " from " + tabla;

            return EjecutarQuery(query);
        }

        public IDbCommand CrearComando(string sqlStr, bool procedimiento)
        {
            return this.CreateCommand(sqlStr, procedimiento);
        }
        /// <summary>
        /// Crea una clausula in(items[0], items[1], ... , items[n])
        /// a partir de un array de strings
        /// </summary>
        public static string CrearClausulaIn(string[] items, bool utilizarComillas)
        {
            if (utilizarComillas)
                return " in('" + string.Join("','", items) + "')";
            return " in(" + string.Join(", ", items) + ") ";
        }

    } // End of CBAV2 class
} // End of namespace

