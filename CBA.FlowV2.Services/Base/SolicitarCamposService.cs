using CBA.FlowV2.Services.DetallesPersonalizados;

namespace CBA.FlowV2.Services.Base
{
    public class SolicitarCamposService
    {
        public abstract class Tipo : TiposDetallesPersonalizadosService.TipoDato
        {
            public const int FlujoId = 1000001;
            public const int TablaId = 1000002;
            public const int Autonumeracion = 1000003;
            public const int CtacteCajaSucursal = 1000004;
        }

        public class Campo
        {
            public int tipo;
            public string nombreInterno;
            public string columna;
            public string titulo;
            public bool obligatorio;
            public object control;
            public object valor { get; set; }

            /* 
             * Utilizados como lista enlazada para dar información de contexto
             * Ejemplo 1: si este campo es depósito, el campoAsociado1 sería sucursal. 
             *            El valor de campoAsociado1 puede ser usado como restricción o 
             *            inicialización para el campo actual
             * Ejemplo 2: si este campo es caja sucursal, campoAsociado1 sería sucursal
             *            y campoAsociado2 sería funcionario
            */
            public Campo campoAsociado1;
            public Campo campoAsociado2;

            public Campo()
            {
                this.nombreInterno = this.columna = this.titulo = string.Empty;
                this.obligatorio = true;
            }
        }
    }
}
