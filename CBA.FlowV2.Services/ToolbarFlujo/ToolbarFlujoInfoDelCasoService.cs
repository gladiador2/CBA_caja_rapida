using System;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;
 

namespace CBA.FlowV2.Services.ToolbarFlujo
{
    public class ToolbarFlujoInfoDelCasoService
    {
        #region ObtenerInfoDelCaso
        public DataTable GetTransicionesDelCaso(decimal caso_id)
        {
            return OperacionesService.GetOperacionesInfoCompletaStatic(OperacionesService.CasoId_NombreCol + " = " + caso_id, OperacionesService.Fecha_NombreCol + ", " + OperacionesService.Id_NombreCol);
        }
        #endregion ObtenerInfoDelCaso
    }
}

