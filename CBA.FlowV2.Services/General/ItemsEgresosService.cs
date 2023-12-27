using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.General
{
    public abstract class ItemsEgresosService
    {
        //public static void AgregarItemsParaCategoria(decimal categoriaId, SessionService sesion)
        //{
        //    GANA_CATEGORIASRow cat = sesion.Db.GANA_CATEGORIASCollection.GetByPrimaryKey(categoriaId);

        //    if (cat.TIPO_CAT == Definiciones.TiposCategorias.Hacienda)
        //    {
        //        GANA_ITEMS_EGRESOSRow itemPorCabeza = new GANA_ITEMS_EGRESOSRow();
        //        itemPorCabeza.AFECTA_STOCK = "N";
        //        itemPorCabeza.CAT_ID = categoriaId;
        //        itemPorCabeza.DESCRIPCION = cat.NOMBRE;
        //        itemPorCabeza.TIPO_ITEM_ID = Definiciones.RubrosEgresosIDs.AnimalesPorCabeza;
        //        itemPorCabeza.GANADERA_ID = sesion.Ganadera_Id;
        //        sesion.Db.GANA_ITEMS_EGRESOSCollection.Insert(itemPorCabeza);

        //        GANA_ITEMS_EGRESOSRow itemPorKilo = new GANA_ITEMS_EGRESOSRow();
        //        itemPorKilo.AFECTA_STOCK = "N";
        //        itemPorKilo.CAT_ID = categoriaId;
        //        itemPorKilo.DESCRIPCION = cat.NOMBRE;
        //        itemPorKilo.TIPO_ITEM_ID = Definiciones.RubrosEgresosIDs.AnimalesPorKilo;
        //        itemPorKilo.GANADERA_ID = sesion.Ganadera_Id;
        //        sesion.Db.GANA_ITEMS_EGRESOSCollection.Insert(itemPorKilo);
        //    }
        //}

        //public static void ActualizarItemsParaCategoria(decimal categoriaId, SessionService sesion)
        //{
        //    GANA_CATEGORIASRow cat = sesion.Db.GANA_CATEGORIASCollection.GetByPrimaryKey(categoriaId);

        //    GANA_ITEMS_EGRESOSRow[] items = sesion.Db.GANA_ITEMS_EGRESOSCollection.GetByCAT_ID(categoriaId);

        //    foreach (GANA_ITEMS_EGRESOSRow item in items)
        //    {
        //        item.DESCRIPCION = cat.NOMBRE;
        //        sesion.Db.GANA_ITEMS_EGRESOSCollection.Update(item);
        //    }
        //}

        //public static void EliminarItemsParaCategoria(decimal categoriaId, SessionService sesion)
        //{
        //    GANA_CATEGORIASRow cat = sesion.Db.GANA_CATEGORIASCollection.GetByPrimaryKey(categoriaId);

        //    GANA_ITEMS_EGRESOSRow[] items = sesion.Db.GANA_ITEMS_EGRESOSCollection.GetByCAT_ID(categoriaId);

        //    foreach (GANA_ITEMS_EGRESOSRow item in items)
        //    {
        //        try
        //        {
        //            sesion.Db.GANA_ITEMS_EGRESOSCollection.Delete(item);
        //        }
        //        catch (Oracle.ManagedDataAccess.Client.OracleException)
        //        {
        //        }
        //    }
        //}
    }
}
