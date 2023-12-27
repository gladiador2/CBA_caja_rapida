

namespace CBA.FlowV2.Services
{
    public class ApplicationContext
    {
        private static ApplicationContext _instance;


        public static System.Collections.Hashtable Session = new System.Collections.Hashtable() ;

        private ApplicationContext()
        {

        }
       
        
        public static ApplicationContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationContext();
                }
                return _instance;
            }
        }

        
    }
}
