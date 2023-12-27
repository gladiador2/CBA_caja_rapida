using System;
using System.Collections.Generic;

using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Casos
{
    public class TagCasoService
    {
        private decimal _vFlujoId;
        private decimal _vCasoId;
        private string _vEstadoId;

        public string estadoId
        {
            get { return this._vEstadoId; }
        }
        public decimal casoId
        {
            get 
            {
                if (!this._vCasoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    return this._vCasoId;
                else
                    throw new NullReferenceException("El id del caso no está definido.");
            }
        }
        public decimal flujoId
        {
            get { return this._vFlujoId; }
        }

        public TagCasoService(decimal flujo_id, decimal caso_id, string estado_id)
        {
            this._vFlujoId = flujo_id;
            this._vCasoId = caso_id;
            this._vEstadoId = estado_id;
        }
    }
}
