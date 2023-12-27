using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Data;
using CBA.FlowV2.Services.Articulos;
using System.Globalization;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RegimenComisionesService
    {
        #region ObtenerPorcentaje
        decimal ObtenerPorcentaje(decimal articuloId,decimal subGrupoId,decimal grupoId,decimal familiaId, DateTime Fecha, decimal FuncionarioId, decimal personaId, decimal ListaPreciosId, decimal Cantidad, decimal Descuento)
        {

            string orden = ArticuloId_NombreCol;
            orden += "," + SubgrupoId_NombreCol;
            orden += "," + GrupoId_NombreCol;
            orden += "," + FamiliaId_NombreCol;
            orden += ","+DescuentoMaximo_NombreCol;
            orden += "," + PersonaId_NombreCol;
            if(!FuncionarioId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                orden += ", " + FuncionarioId_NombreCol;
            orden += ", " + ListaPreciosId_NombreCol;
            orden += "," + Id_NombreCol + " desc";
            
            string clausulas = string.Format("({0} is null or {0} = {1} )", ArticuloId_NombreCol, articuloId);
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", SubgrupoId_NombreCol, subGrupoId);
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", GrupoId_NombreCol, grupoId);
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", FamiliaId_NombreCol, familiaId);
            clausulas += string.Format(" and ({0} is null or {0} <= to_date('{1}','dd/mm/yyyy') )", FechaDesde_NombreCol, Fecha.ToShortDateString());
            clausulas += string.Format(" and ({0} is null or {0} >= to_date('{1}','dd/mm/yyyy') )", FechaHasta_NombreCol, Fecha.ToShortDateString());
            clausulas += string.Format(" and ({0} is null or {0} <= {1} )", CantidadMinima_NombreCol, Cantidad.ToString(CultureInfo.InvariantCulture));
            clausulas += string.Format(" and ({0} is null or {0} >= {1} )", DescuentoMaximo_NombreCol, Descuento.ToString(CultureInfo.InvariantCulture));
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", FuncionarioId_NombreCol, FuncionarioId);
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", PersonaId_NombreCol, personaId);
            clausulas += string.Format(" and ({0} is null or {0} = {1} )", ListaPreciosId_NombreCol, ListaPreciosId);
            clausulas += string.Format(" and {0} = {1} ", Estado_NombreCol, "'"+Definiciones.Estado.Activo+"'");

            
            DataTable tabla = GetRegimenComisiones(clausulas, orden, true);
            if (tabla.Rows.Count > 0)
            {
                return (decimal)tabla.Rows[0][PorcentajeComision_NombreCol];
            }
            return Definiciones.Error.Valor.EnteroPositivo;
        }

        public decimal ObtenerPorcentaje(decimal ArticuloId, DateTime Fecha, decimal FuncionarioId,decimal personaId, decimal ListaPreciosId, decimal Cantidad, decimal Descuento, bool articulo_no_perteneciente_a_lista_de_precios) 
        {
            if (articulo_no_perteneciente_a_lista_de_precios)
                return Definiciones.Error.Valor.EnteroPositivo;

            ARTICULOSRow row = ArticulosService.GetArticuloRowPorID(ArticuloId);

            //buscar por articulo
            string clausulas = ArticuloId_NombreCol + " = " + ArticuloId.ToString();
            decimal porcentaje =  ObtenerPorcentaje(row.ID,row.SUBGRUPO_ID,row.GRUPO_ID,row.FAMILIA_ID, Fecha, FuncionarioId, personaId, ListaPreciosId, Cantidad, Descuento);
            if (porcentaje != Definiciones.Error.Valor.EnteroPositivo) return porcentaje;


            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion

        #region GetRegimenComisiones
        public DataTable GetRegimenComisionesPorID(string vIdRegimenComisiones)
        {
            return GetRegimenComisiones(RegimenComisionesService.Id_NombreCol + " = " + vIdRegimenComisiones, string.Empty, false);
        }

        public DataTable GetRegimenComisiones(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = clausulas;
                if (soloActivos)
                {
                    if (!string.IsNullOrEmpty(where)) where += " and ";
                    where += RegimenComisionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                }
                return sesion.Db.REGIMEN_COMISIONESCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetRegimenComisiones

        #region GetRegimenComisionesInfoCompleta
        /// <summary>
        /// Gets the Regimen Comisiones info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetRegimenComisionesInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = clausulas;
                if (soloActivos)
                {
                    if (string.IsNullOrEmpty(where)) where += " and ";
                    where += RegimenComisionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                }
                return sesion.Db.REGIMEN_COMISIONES_INFO_COMPCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetRegimenComisionesInfoCompleta

        #region Guardar articulo
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    REGIMEN_COMISIONESRow row = new REGIMEN_COMISIONESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("REGIMEN_COMISIONES_SQC");
                    }
                    else
                    {
                        row = sesion.Db.REGIMEN_COMISIONESCollection.GetByPrimaryKey((decimal)campos[RegimenComisionesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(RegimenComisionesService.ArticuloId_NombreCol))
                        row.ARTICULO_ID = (decimal)campos[RegimenComisionesService.ArticuloId_NombreCol];
                    else
                        row.IsARTICULO_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.FamiliaId_NombreCol))
                        row.FAMILIA_ID = (decimal)campos[RegimenComisionesService.FamiliaId_NombreCol];
                    else
                        row.IsFAMILIA_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.GrupoId_NombreCol))
                        row.GRUPO_ID = (decimal)campos[RegimenComisionesService.GrupoId_NombreCol];
                    else
                        row.IsGRUPO_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.SubgrupoId_NombreCol))
                        row.SUBGRUPO_ID = (decimal)campos[RegimenComisionesService.SubgrupoId_NombreCol];
                    else
                        row.IsSUBGRUPO_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.FuncionarioId_NombreCol))
                        row.FUNCIONARIO_ID = (decimal)campos[RegimenComisionesService.FuncionarioId_NombreCol];
                    else
                        row.IsFUNCIONARIO_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[RegimenComisionesService.PersonaId_NombreCol];
                    else
                        row.IsPERSONA_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.ListaPreciosId_NombreCol))
                        row.LISTA_PRECIOS_ID = (decimal)campos[RegimenComisionesService.ListaPreciosId_NombreCol];
                    else
                        row.IsLISTA_PRECIOS_IDNull = true;

                    if (campos.Contains(RegimenComisionesService.CantidadMinima_NombreCol))
                        row.CANTIDAD_MINIMA = (decimal)campos[RegimenComisionesService.CantidadMinima_NombreCol];
                    else
                        row.IsCANTIDAD_MINIMANull = true;

                    if (campos.Contains(RegimenComisionesService.DescuentoMaximo_NombreCol))
                        row.DESCUENTO_MAXIMO = (decimal)campos[RegimenComisionesService.DescuentoMaximo_NombreCol];
                    else
                        row.IsDESCUENTO_MAXIMONull = true;

                    if (campos.Contains(RegimenComisionesService.FechaDesde_NombreCol))
                        row.FECHA_DESDE = (DateTime)campos[RegimenComisionesService.FechaDesde_NombreCol];
                    else
                        row.IsFECHA_DESDENull = true;

                    if (campos.Contains(RegimenComisionesService.FechaHasta_NombreCol))
                        row.FECHA_HASTA = (DateTime)campos[RegimenComisionesService.FechaHasta_NombreCol];
                    else
                        row.IsFECHA_HASTANull = true;

                    row.PORCENTAJE_COMISION = (decimal)campos[RegimenComisionesService.PorcentajeComision_NombreCol];
                    row.ESTADO = (string)campos[RegimenComisionesService.Estado_NombreCol];                   

                    if (insertarNuevo) sesion.Db.REGIMEN_COMISIONESCollection.Insert(row);
                    else sesion.Db.REGIMEN_COMISIONESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar articulo

        #region Accessors
        public static string Nombre_Tabla
        { get { return "REGIMEN_COMISIONES"; } }

        public static string Id_NombreCol
        { get { return REGIMEN_COMISIONESCollection.IDColumnName; } }
        public static string ArticuloId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.ARTICULO_IDColumnName; } }
        public static string CantidadMinima_NombreCol
        { get { return REGIMEN_COMISIONESCollection.CANTIDAD_MINIMAColumnName; } }
        public static string DescuentoMaximo_NombreCol
        { get { return REGIMEN_COMISIONESCollection.DESCUENTO_MAXIMOColumnName; } }
        public static string Estado_NombreCol
        { get { return REGIMEN_COMISIONESCollection.ESTADOColumnName; } }
        public static string FamiliaId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.FAMILIA_IDColumnName; } }
        public static string FechaDesde_NombreCol
        { get { return REGIMEN_COMISIONESCollection.FECHA_DESDEColumnName; } }
        public static string FechaHasta_NombreCol
        { get { return REGIMEN_COMISIONESCollection.FECHA_HASTAColumnName; } }
        public static string FuncionarioId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.FUNCIONARIO_IDColumnName; } }
        public static string PersonaId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.PERSONA_IDColumnName; } }

        public static string GrupoId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.GRUPO_IDColumnName; } }
        public static string ListaPreciosId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.LISTA_PRECIOS_IDColumnName; } }
        public static string PorcentajeComision_NombreCol
        { get { return REGIMEN_COMISIONESCollection.PORCENTAJE_COMISIONColumnName; } }
        public static string SubgrupoId_NombreCol
        { get { return REGIMEN_COMISIONESCollection.SUBGRUPO_IDColumnName; } }

        public static string VistaArticulo_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.ARTICULOColumnName; } }
        public static string VistaFamilia_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.FAMILIAColumnName; } }
        public static string VistaGrupo_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.GRUPOColumnName; } }
        public static string VistaListaPrecios_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.LISTA_PRECIOSColumnName; } }
        public static string VistaSubGrupo_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.SUBGRUPOColumnName; } }
        public static string VistaFuncionario_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.FUNCIONARIOColumnName; } }
        public static string VistaPersonaNombre_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.PERSONA_NOMBREColumnName; } }
        public static string VistaPersonaCodigo_NombreCol
        { get { return REGIMEN_COMISIONES_INFO_COMPCollection.PERSONA_CODIGOColumnName; } }
        #endregion Accessors  
    
    }
}
