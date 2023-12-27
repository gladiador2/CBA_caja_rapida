using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CBA.FlowV2.Services.Sesion
{
    public class FuncionalidadesService
    {
        SessionService sesion;

        public FuncionalidadesService(SessionService sesion)
        {
            this.sesion = sesion;
        }

        public DataTable GetFuncionalidades()
        {

            return null;
        }
    }
}
