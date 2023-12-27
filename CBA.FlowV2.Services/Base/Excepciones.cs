using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.FlowV2.Services.Base
{
    public class Excepciones
    {
        #region clase LoteSinCostoActivo
        public class LoteSinCostoActivo : Exception
        {
            //Dato del lote sin costo
            public decimal loteId;

            public LoteSinCostoActivo(string mensaje, decimal lote_id)
                : base(mensaje)
            {
                loteId = lote_id;
            }
        }
        #endregion clase LoteSinCostoActivo

        #region clase Excepcion
        public class Excepcion : Exception
        {
            public string Mensaje;
            public Exception excepcion;

            public Excepcion(string mensaje, Exception e)
            {
                this.Mensaje = mensaje;
                this.excepcion = e;
            }
        }
        #endregion clase Excepcion

        #region Propiedades
        public List<Excepcion> excepciones { get; private set; }
        public int Cantidad { get { return this.excepciones.Count; } }
        public bool ExistenErrores { get { return this.Cantidad > 0; } }
        #endregion Propiedades

        #region Constructor
        public Excepciones()
        {
            this.excepciones = new List<Excepcion>();
        }
        #endregion Constructor

        #region Agregar
        public void Agregar(string mensaje)
        {
            Agregar(mensaje, null);
        }

        public void Agregar(string mensaje, Exception e)
        {
            this.excepciones.Add(new Excepcion(mensaje, e));
        }

        public void Agregar(List<Excepcion> e)
        {
            for (int i = 0; i < e.Count; i++)
                this.excepciones.Add(new Excepcion(e[i].Mensaje, e[i].excepcion));
        }
        #endregion Agregar

        #region ToString
        public override string ToString()
        {
            string[] s = new string[this.Cantidad];
            for (int i = 0; i < this.Cantidad; i++)
                s[i] = this.excepciones[i].Mensaje;
            return string.Join(Environment.NewLine, s);
        }
        #endregion ToString
    }
}
