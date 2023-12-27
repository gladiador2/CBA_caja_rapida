using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;




namespace CBA.FlowV2.Db.Usuarios
{
    public class CambiarContrasena
    {
        #region propiedades
        private CBAV2 _db;
        string _nombreUsuario;
        decimal _idUsuario;
        string _contrasenaActual;
        string _nuevaContrasena;
        string _nuevaContrasenaRepeticion;
        string _nombreEntidad;
        decimal _idSucursal;
        #endregion Variables privadas

        #region Accessors

        public string nombreUsuario
        {
            get { return this._nombreUsuario; }
            set { this._nombreUsuario = value; }
        }

        public CBAV2 db
        {
            get { return this._db; }
            set { this._db = value; }
        }
                public string contrasenaActual
                {
                    get
                    {
                        return _contrasenaActual;
                    }
                    set
                    {
                        this._contrasenaActual = value;
                    }
                }
                public string nuevaContrasena
                {
                    get
                    {
                        return _nuevaContrasena;
                    }
                    set
                    {
                        this._nuevaContrasena = value;
                    }
                }
                public string nuevaContrasenaRepeticion
                {
                    get
                    {
                        return _nuevaContrasenaRepeticion;
                    }
                    set
                    {
                        this._nuevaContrasenaRepeticion = value;
                    }
                }
                public string nombreEntidad
                {
                    get
                    {
                        return this._nombreEntidad;
                    }
                    set
                    {
                        this._nombreEntidad = value;
                    }

                }
                public decimal idUsuario
                {
                    get
                    {
                        return this._idUsuario;
                    }
                    set
                    {
                        this._idUsuario = value;
                    }
                }
                public decimal idSucursal
                {
                    get
                    {
                        return this._idSucursal;
                    }
                    set
                    {
                        this._idSucursal = value;
                    }
                }
        #endregion

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="CambiarContrasena"/> class.
        /// </summary>
        /// <param name="actual">La contrasena actual.</param>
        /// <param name="nueva">La nueva contrasena.</param>
        /// <param name="repeticion">La repeticion de la contrasena.</param>
        /// <param name="nombre_entidad">El nombre de la entidad.</param>
        /// <param name="id_sucursal">El id de la la sucursal.</param>
        public CambiarContrasena(string nombre_usuario, decimal id_usuario, string actual, string nueva, string repeticion, string nombre_entidad, decimal id_sucursal)
        {
            this.db = new CBAV2();

            this.idUsuario = id_usuario;
            this.nombreUsuario = nombre_usuario;
            this.contrasenaActual = actual;
            this.nuevaContrasena = nueva;
            this.nuevaContrasenaRepeticion = repeticion;

            if (!this.nuevaContrasena.Equals(this.nuevaContrasenaRepeticion))
                throw new Exception("La contraseña nueva y su repetición no coinciden.");

            this.nombreEntidad = nombre_entidad;
            this.idSucursal = id_sucursal;
        }
        #endregion Constructores
        
        #region Ejecutar
        /// <summary>
        /// Ejecuta el procedimiento que cambia la contrase;a
        /// hcaniza feb-2011
        /// </summary>
        /// <returns></returns>
        public string Ejecutar( )
        {
            try
            {   
              
                string procedimientoAlamacenado = "TRC.LOGUEO.CAMBIOPASS";

                OracleCommand cmd = new OracleCommand(procedimientoAlamacenado,this.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;                              

                #region Parametros ENTRANTES
                cmd.Parameters.Add(new OracleParameter("pNombreUsuario", OracleDbType.Varchar2, 50));
                cmd.Parameters["pNombreUsuario"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pUsuario", OracleDbType.Int32));
                cmd.Parameters["pUsuario"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pClaveAnterior", OracleDbType.Varchar2, 50));
                cmd.Parameters["pClaveAnterior"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("pClave", OracleDbType.Varchar2, 50));
                cmd.Parameters["pClave"].Direction = ParameterDirection.Input;

                #endregion

                #region Parametros SALIENTES
                cmd.Parameters.Add(new OracleParameter("resultado", OracleDbType.Varchar2, 5));
                cmd.Parameters["resultado"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("mensaje", OracleDbType.Varchar2, 300));
                cmd.Parameters["mensaje"].Direction = ParameterDirection.Output;
                #endregion

                #region Parametros VALORES
                cmd.Parameters["pNombreUsuario"].Value = this.nombreUsuario;
                cmd.Parameters["pUsuario"].Value = this.idUsuario;
                cmd.Parameters["pClaveAnterior"].Value = this.contrasenaActual;
                cmd.Parameters["pClave"].Value = this.nuevaContrasena;
               
                #endregion

                // Ejecutamos el procedimiento almacenado
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                string mensaje = !Convert.IsDBNull(cmd.Parameters["mensaje"].Value) ? (cmd.Parameters["mensaje"].Value).ToString() : string.Empty;
                string resultado = !Convert.IsDBNull(cmd.Parameters["resultado"].Value) ? (cmd.Parameters["resultado"].Value).ToString() : string.Empty;

                if(resultado == "N")
                    throw new Exception(mensaje);
                return mensaje;
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

      
        #endregion
    }
}



