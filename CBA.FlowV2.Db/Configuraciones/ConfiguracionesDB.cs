
namespace CBA.FlowV2.Db.Config
{
    public class ConfiguracionesDB
    {
        private string _cadenaDeConexion;

        private string cadenaDeConexion
        {
            get { return this._cadenaDeConexion; }
            set { this._cadenaDeConexion = value; }
        }

        public ConfiguracionesDB()
        {
            cadenaDeConexion = "Data Source=(DESCRIPTION="
                              + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.protocolo
                              + ")(HOST=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.host
                              + ")(PORT=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.puerto
                              + ")))"
                              + "(CONNECT_DATA=(SERVER=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.server
                              + ")(SERVICE_NAME=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.servicename + ")));"
                              + "User Id=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.usuario
                              + ";Password=" + CBA.FlowV2.Db.Config.Singleton.Objeto.objetoAplicacion.Configuraciones.Parametros.contrasenha + ";";
        }

        public string getCadenaDeConexion()
        {
            return cadenaDeConexion;
        }

    }

    sealed public class Singleton
    {
        public static readonly Singleton Objeto = new Singleton();
        public CBA.FlowV2.Db.Config.Aplicacion objetoAplicacion;

        private Singleton()
        {
            objetoAplicacion = new Aplicacion();
        }
    }

}
