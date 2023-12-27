using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Collections;


namespace CBA.FlowV2.Db.Usuarios
{
    public class Logueo
    {
        #region Variables privadas
        private CBAV2 _db;
        private string _nombreUsuario;
        private string _contrasena;
        private string _IPCliente;

        private string _sesion;
        private string _id;
        private string _rol;
        private string _entidadID;
        private string _sucursalId;
        #endregion Variables privadas

        #region Accessors

        public string sesion
        {
            set { this._sesion = value; }
            get { return this._sesion; }
        }
        public string id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string rol
        {
            get { return this._rol; }
            set { this._rol = value; }
        }
        public string entidadID
        {
            get { return this._entidadID; }
            set { this._entidadID = value; }
        }
        public string sucursalId
        {
            get { return this._sucursalId; }
            set { this._sucursalId = value; }
        }
      
        private string nombreUsuario
        {
            get
            {
                return this._nombreUsuario;
            }
            set
            {
                this._nombreUsuario = value;
            }
        }
        private string contrasena
        {
            get
            {
                return this._contrasena;
            }
            set
            {
                this._contrasena = value;
            }
        }

        private string IPCliente
        {
            get
            {
                return this._IPCliente;
            }
            set
            {
                this._IPCliente = value;
            }
        }


        private CBAV2 db
        {
            set { this._db = value; }
            get { return this._db; }
        }
    
        #endregion

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="Logueo"/> class.
        /// </summary>
        /// <param name="nombre_usuario">el nombre de usuario.</param>
        /// <param name="contrasena">la contrasena.</param>
        public Logueo(string nombre_usuario, string contrasena, string ip_cliente)
        {
            this.db = new CBAV2();

            this.nombreUsuario = nombre_usuario;
            this.contrasena = contrasena;
            this.IPCliente = ip_cliente;
        }
        #endregion Constructores

        #region Ejecutar
        /// <summary>
        /// Ejecuta el procedimiento que loguea al sistema
        /// hcaniza feb-2011
        /// </summary>
        /// <param name="sesion_id">The sesion_id.</param>
        /// <returns></returns>
        public Hashtable Ejecutar()
        {
            try
            {
                string procedimientoAlamacenado = "trc.LOGUEO.PROCESO";

                OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, this.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;                              

                #region parametros de entrada
                cmd.Parameters.Add(new OracleParameter("USUARIO", OracleDbType.Varchar2, 50));
                cmd.Parameters["USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("CLAVE", OracleDbType.Varchar2, 50));
                cmd.Parameters["CLAVE"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("IP", OracleDbType.Varchar2, 50));
                cmd.Parameters["IP"].Direction = ParameterDirection.Input;

                #endregion

                #region parametros de salida
                cmd.Parameters.Add(new OracleParameter("SESION", OracleDbType.Int32, 30));
                cmd.Parameters["SESION"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("ID", OracleDbType.Int32, 30));
                cmd.Parameters["ID"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("ENTIDAD_ID", OracleDbType.Int32, 30));
                cmd.Parameters["ENTIDAD_ID"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("SUCURSAL_ID", OracleDbType.Int32, 30));
                cmd.Parameters["SUCURSAL_ID"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("CAMBIO", OracleDbType.Varchar2, 5));
                cmd.Parameters["CAMBIO"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("MENSAJE", OracleDbType.Varchar2, 300));
                cmd.Parameters["MENSAJE"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new OracleParameter("EXITO", OracleDbType.Varchar2, 300));
                cmd.Parameters["EXITO"].Direction = ParameterDirection.Output;
                #endregion

                #region carga parametros de entrada
                cmd.Parameters["USUARIO"].Value = this.nombreUsuario;
                cmd.Parameters["CLAVE"].Value = this.contrasena;
                cmd.Parameters["IP"].Value = this.IPCliente;
                #endregion

                // Ejecutamos el procedimiento almacenado
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                #region cargar parametros de salida
                this.sesion = cmd.Parameters["SESION"].Value.ToString();
                this.id = cmd.Parameters["ID"].Value.ToString();
                this.entidadID = cmd.Parameters["ENTIDAD_ID"].Value.ToString();
                this.sucursalId = cmd.Parameters["SUCURSAL_ID"].Value.ToString();
                #endregion

                Hashtable retorno = new Hashtable(3);

                if (Convert.IsDBNull(cmd.Parameters["CAMBIO"].Value))
                    retorno.Add("CAMBIO", string.Empty);
                else
                    retorno.Add("CAMBIO", (cmd.Parameters["CAMBIO"].Value).ToString());

                
                if(Convert.IsDBNull(cmd.Parameters["MENSAJE"].Value))
                    retorno.Add("MENSAJE",string.Empty);
                else
                    retorno.Add("MENSAJE", (cmd.Parameters["MENSAJE"].Value).ToString());

                
                if (Convert.IsDBNull(cmd.Parameters["EXITO"].Value))
                    retorno.Add("EXITO", string.Empty);
                else
                    retorno.Add("EXITO",(cmd.Parameters["EXITO"].Value).ToString());
                
                return retorno;
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }


        #endregion
    }
}
