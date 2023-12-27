using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Base
{
    
    public abstract class TriggerBase <F> 
    {
        public virtual void BeforeInsert(ref F fila_nueva, SessionService sesion)
        {
            throw new Exception("Falta implementar el disparador BeforeInsert");
        }

        public virtual void AfterInsert(F fila_nueva, SessionService sesion)
        {
            throw new Exception("Falta implementar el disparador AfterInsert");
        }


        public virtual void BeforeUpdate(ref F fila_nueva, F fila_vieja, SessionService sesion) 
        {
            throw new Exception("Falta implementar el disparador BeforeUpdate");
        }


        public virtual void AfterUpdate(F fila_nueva, F fila_vieja, SessionService sesion)
        {
            throw new Exception("Falta implementar el disparador AfterUpdate");
        }



    }
}
