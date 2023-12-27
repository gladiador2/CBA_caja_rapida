using CBA.FlowV2.Db;
using System.Collections;
using CBA.FlowV2.Services.Sesion;
using System;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    class ArticulosCreadosDevolucionService
    {
        public static string GenerarCodigo(decimal articulo_id, decimal tipo_nc)
        {
            string prefijo = string.Empty;
            decimal nroSecuencia = SiguienteNumero(articulo_id, tipo_nc);
            string codigoEmpresa = ArticulosService.GetArticuloRowPorID(articulo_id).CODIGO_EMPRESA;
            using (SessionService sesion = new SessionService())
            {
                prefijo = TipoNotaCreditoService.GetPrefijo(tipo_nc);
            }
            return string.Format("{0}{1}.{2}", prefijo, codigoEmpresa, nroSecuencia);

        }


        public static decimal Guardar(Hashtable campos, bool nuevo)
        {
            ARTICULOS_CREADOS_DEVOLUCIONRow articuloCreado = Mapear(campos);
            return Guardar(articuloCreado, nuevo);
        }

        private static decimal Guardar(ARTICULOS_CREADOS_DEVOLUCIONRow articuloCreado, bool nuevo)
        {
            ARTICULOS_CREADOS_DEVOLUCIONRow articuloViejo;
            using (SessionService sesion = new SessionService())
            {
                String valorAnterior = string.Empty;
                if (nuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    articuloCreado.ID = sesion.Db.GetSiguienteSecuencia(Secuencia);
                }
                else
                {
                    articuloViejo = sesion.Db.ARTICULOS_CREADOS_DEVOLUCIONCollection.GetByPrimaryKey(articuloCreado.ID);
                    valorAnterior = articuloCreado.ToString();
                }
                try
                {
                    sesion.Db.BeginTransaction();
                    if (nuevo)
                    {
                        sesion.Db.ARTICULOS_CREADOS_DEVOLUCIONCollection.Insert(articuloCreado);
                    }
                    else
                    {
                        sesion.Db.ARTICULOS_CREADOS_DEVOLUCIONCollection.Update(articuloCreado);
                    }

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, articuloCreado.ID
                        , valorAnterior, articuloCreado.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }

            return articuloCreado.ID;
        }

        private static decimal SiguienteNumero(decimal articulo_id, decimal tipo_nc)
        {
            ARTICULOS_CREADOS_DEVOLUCIONRow registro;
            using (SessionService sesion = new SessionService())
            {
                string where = string.Format("{0} = {1} AND {2} = {3}"
                    , ArticulosCreadosDevolucionService.ArticuloId_NombreCol
                    , articulo_id
                    , ArticulosCreadosDevolucionService.TipoNotaCreditoId_NombreCol
                    , tipo_nc);


                registro = sesion.Db.ARTICULOS_CREADOS_DEVOLUCIONCollection.GetRow(where);
                if (null == registro)
                {
                    registro = CrearRegistro(articulo_id, tipo_nc);
                }
                registro.SECUENCIA++;
                Guardar(registro, false);
                return registro.SECUENCIA;
            }

        }

        private static ARTICULOS_CREADOS_DEVOLUCIONRow Mapear(Hashtable campos)
        {
            ARTICULOS_CREADOS_DEVOLUCIONRow articuloCreado = new ARTICULOS_CREADOS_DEVOLUCIONRow();
            articuloCreado.SECUENCIA = (decimal)campos[Secuencia_NombreCol];
            articuloCreado.TIPO_NOTA_CREDITO_ID = (decimal)campos[TipoNotaCreditoId_NombreCol];
            articuloCreado.ARTICULO_ID = (decimal)campos[ArticuloId_NombreCol];
            if (campos.Contains(Id_NombreCol))
                articuloCreado.ID = (decimal)campos[Id_NombreCol];
            return articuloCreado;
        }

        private static ARTICULOS_CREADOS_DEVOLUCIONRow CrearRegistro(decimal articulo_id, decimal tipo_nc)
        {
            Hashtable campos = new Hashtable();
            campos.Add(ArticuloId_NombreCol, articulo_id);
            campos.Add(TipoNotaCreditoId_NombreCol, tipo_nc);
            campos.Add(Secuencia_NombreCol, 0M);
            decimal id = Guardar(campos, true);
            using (SessionService sesion = new SessionService())
                return sesion.Db.ARTICULOS_CREADOS_DEVOLUCIONCollection.GetByPrimaryKey(id);
        }

        #region accesors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_CREADOS_DEVOLUCION"; }
        }

        public static string Secuencia
        {
            get { return "ARTICULOS_CREADOS_DEV_SQC"; }
        }

        public static string Id_NombreCol
        {
            get { return ARTICULOS_CREADOS_DEVOLUCIONCollection.IDColumnName; }
        }

        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_CREADOS_DEVOLUCIONCollection.ARTICULO_IDColumnName; }
        }

        public static string Secuencia_NombreCol
        {
            get { return ARTICULOS_CREADOS_DEVOLUCIONCollection.SECUENCIAColumnName; }
        }

        public static string TipoNotaCreditoId_NombreCol
        {
            get { return ARTICULOS_CREADOS_DEVOLUCIONCollection.TIPO_NOTA_CREDITO_IDColumnName; }
        }

        #endregion accesors
    }
}
