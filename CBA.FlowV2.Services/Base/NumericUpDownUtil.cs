using System;

using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Base
{
    public static class NumericUpDownUtil
    {
        #region FormatoPorMoneda
        /// <summary>
        /// Formatoes the por moneda.
        /// </summary>
        /// <param name="numeric">The numeric.</param>
        /// <param name="moneda">The moneda.</param>
        public static void FormatoPorMoneda(System.Windows.Forms.NumericUpDown numeric, decimal moneda)
        {
            numeric.DecimalPlaces = MonedasService.CantidadDecimalesStatic(moneda);

        }
        #endregion FormatoPorMoneda
    }
}
