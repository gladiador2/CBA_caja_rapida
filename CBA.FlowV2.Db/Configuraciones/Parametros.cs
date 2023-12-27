using System;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Web;


namespace CBA.FlowV2.Db.Config
{
    public class Aplicacion
    {
        [Serializable()]
        public class Configuracion
        {
            [Serializable()]
            public class Parametro
            {
                private string _protocolo;
                private string _host;
                private string _puerto;
                private string _server;
                private string _servicename;
                private string _usuario;
                private string _contrasenha;
                private string _tnsnames;
                private string _servername;

                #region Accesors
                public string protocolo
                {
                    get { return _protocolo; }
                    set { _protocolo = value; }
                }

                public string host
                {
                    get { return _host; }
                    set { _host = value; }
                }

                public string puerto
                {
                    get { return _puerto; }
                    set { _puerto = value; }
                }

                public string server
                {
                    get { return _server; }
                    set { _server = value; }
                }

                public string servicename
                {
                    get { return _servicename; }
                    set { _servicename = value; }
                }

                public string usuario
                {
                    get { return _usuario; }
                    set { _usuario = value; }
                }

                public string contrasenha
                {
                    get { return _contrasenha; }
                    set { _contrasenha = value; }
                }
                public string servername
                {
                    get { return _servername; }
                    set { _servername = value; }
                }
                public string tnsnames
                {
                    get { return _tnsnames; }
                    set { _tnsnames = value; }
                }
                #endregion Accesor
            }

            public Parametro Parametros;

            public Configuracion()
            {
                Parametros = new Parametro();
            }
        }

        public Configuracion Configuraciones;

        /// <summary>
        /// Initializes a new instance of the <see cref="Aplicacion"/> class.
        /// </summary>
        public Aplicacion()
        {
            /*
            string strRutaAbsoluta =  HttpContext.Current.Server.MapPath("~/") + "bin\\Configuraciones\\Configuracion.xml";
            string textoPlano;
            StreamReader streamReader;

            //Se obtiene el stream
            streamReader = new StreamReader(strRutaAbsoluta);
            */
           string textoPlano = "<Configuracion>\r\n  <Parametros>\r\n    <protocolo>tcp</protocolo>\r\n    <host>10.10.3.93</host>\r\n    <puerto>1521</puerto>\r\n    <server>DEDICATED</server>\r\n    <servicename>mdjdev</servicename>\r\n    <tnsnames>MDJDEV</tnsnames>\r\n    <usuario>trc</usuario>\r\n    <contrasenha>copernicus.JH385</contrasenha>\r\n  </Parametros>\r\n</Configuracion>"; //streamReader.ReadToEnd();

            //Se convierte el texto plano a un stream
            byte[] byteArray = Encoding.ASCII.GetBytes(textoPlano);
            MemoryStream stream = new MemoryStream(byteArray);

            //Se inicializa la configuracion con el stream creado del texto plano
            XmlSerializer Configuracion = new XmlSerializer(typeof(Configuracion));
            Configuraciones = (Configuracion)Configuracion.Deserialize(stream);
        }
    }
}