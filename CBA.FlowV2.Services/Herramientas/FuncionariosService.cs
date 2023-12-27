#region Using
using System;
using System.Collections;
using System.Data;
using System.Net;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.RecursosHumanos;
using CBA.FlowV2.Services.Sesion;

#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class FuncionariosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region PuedePercibirAdelanto
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static bool PuedePercibirAdelanto(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.COBRA_ANTICIPO == Definiciones.SiNo.Si;
            }
        }
        #endregion PuedePercibirAdelanto

        #region MontoMaximoAdelanto
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal MontoMaximoAdelanto(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.MONTO_ANTICIPO;
            }
        }
        #endregion MontoMaximoAdelanto

        #region GetSalarioBase

        /// <summary>
        /// Gets the salario base.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetSalarioBase(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                if (funcionario.COBRA_SALARIO_MINIMO == Definiciones.SiNo.Si)
                    return VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.SalarioMinimoMonto);
                else
                    return funcionario.SALARIO;
            }
        }
        #endregion GetSalarioBase
        
        #region GetTipoSalario
        public static int GetTipoSalario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return (int)funcionario.SALARIO_TIPO;
            }
        }
        #endregion GetTipoSalario

        #region GetNombre
        /// <summary>
        /// Gets the nombre.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static string GetNombre(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow row = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(funcionario_id);
                return row.NOMBRE + " " + row.APELLIDO;
            }
        }
        #endregion GetNombre

        #region GetSalarioComplementario

        /// <summary>
        /// Gets the salario complementario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetSalarioComplementario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.SALARIO_COMPLEMENTARIO;
            }
        }
        #endregion GetSalariocomplementario

        #region GetSalarioExtraordinario
        /// <summary>
        /// Gets the salario extraordinario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetSalarioExtraordinario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.SALARIO_EXTRA;
            }
        }
        #endregion GetSalarioExtraordinario

        #region GetMonedaSalario


        /// <summary>
        /// Gets the moneda salario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetMonedaSalario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.MONEDA_ID;
            }
        }
        #endregion GetMonedaSalario

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal funcionario_id, SessionService sesion)
        {
            FUNCIONARIOSRow row = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(funcionario_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetSucursal
        public static decimal GetSucursal(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow row = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(funcionario_id);
                return row.IsSUCURSAL_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.SUCURSAL_ID;
            }
        }
        #endregion GetSucursal

        #region EsCobrador
        public static bool EsCobrador(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.ES_COBRADOR == Definiciones.SiNo.Si;
            }
        }
        #endregion EsCobrador

        #region EsCobradorExterno
        public static bool EsCobradorExterno(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.ES_COBRADOR_EXTERNO == Definiciones.SiNo.Si;
            }
        }
        #endregion EsCobradorExterno

        #region EsVendedor
        /// <summary>
        /// Eses the vendedor.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static bool EsVendedor(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.ES_VENDEDOR == Definiciones.SiNo.Si;
            }
        }
        #endregion EsVendedor

        #region GetFuncionariosDataTable
        
        [Obsolete("utilizar métodos estáticos")]
        /// <summary>
        /// Gets the funcionarios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public DataTable GetFuncionariosDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;

                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                return sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(where, orden);
            }
        }

        /// <summary>
        /// Gets the funcionarios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;

                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                return sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(where, orden);
            }
        }

        public DataTable GetFuncionariosDataTableNinguno(string clausulas, string orden, bool soloActivos, bool Ninguno)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;
                DataTable table;
                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                table = sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(where, orden);
                if (Ninguno) { 
                    DataRow row = table.NewRow();
                        row[FuncionariosService.Id_NombreCol] = Definiciones.IdNull;
                        row[FuncionariosService.Nombre_NombreCol] = "Ninguno";
                        row[FuncionariosService.Apellido_NombreCol] = string.Empty;
                        row[FuncionariosService.Persona_IdNombreCol] = Definiciones.Error.Valor.EnteroPositivo;
                        row[FuncionariosService.EntidadId_NombreCol] = sesion.Entidad.ID;
                        row[FuncionariosService.EsCobrador_NombreCol] = "N";
                        row[FuncionariosService.EsVendedor_NombreCol] = "N";
                        row[FuncionariosService.EsPromotor_NombreCol] = "N";
                        row[FuncionariosService.Depositero_NombreCol] = "S";
                        row[FuncionariosService.EsChofer_NombreCol] = "S";
                        row[FuncionariosService.Estado_NombreCol] = "A";
                        row[FuncionariosService.IngresoAprobado_NombreCol] = "S";
                        row[FuncionariosService.EsCobradorExterno_NombreCol] = "N";

                        table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }

        /// <summary>
        /// Gets the funcionarios data table with an user-specific order clause.
        /// </summary>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los clientes activos.</param>
        /// <returns></returns>
        [Obsolete("Utilizar métodos estáticos")]
        public DataTable GetFuncionariosDataTable(string orden, bool soloActivos)
        {
            return this.GetFuncionariosDataTable(string.Empty, orden, soloActivos);
        }
        public static DataTable GetFuncionariosDataTable2(string orden, bool soloActivos)
        {
            return GetFuncionariosDataTable2(string.Empty, orden, soloActivos);
        }

        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the funcionarios data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetFuncionariosDataTable()
        {
            return this.GetFuncionariosDataTable(string.Empty, Nombre_NombreCol + "||' '||" + Apellido_NombreCol, false);
        }

        /// <summary>
        /// Gets the funcionarios data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFuncionariosDataTable2()
        {
            return FuncionariosService.GetFuncionariosDataTable2(string.Empty, Nombre_NombreCol + "||' '||" + Apellido_NombreCol, false);
        }
        #endregion GetFuncionariosDataTable

        #region GetFuncionariosInfoCompleta
        public static DataTable GetFuncionariosInfoCompleta(string clausulas, string orden, bool soloActivos)
        { 
            return GetFuncionariosInfoCompleta(clausulas, orden, soloActivos, false);
        }

        /// <summary>
        /// Gets the funcionarios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosInfoCompleta(string clausulas, string orden, bool soloActivos, bool busqueda_flexible)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;

                if (busqueda_flexible)
                    sesion.db.IniciarBusquedaFlexible();

                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                DataTable dt = sesion.Db.FUNCIONARIOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);

                if(busqueda_flexible)
                    sesion.db.FinalizarBusquedaFlexible();

                return dt;
            }
        }

        /// <summary>
        /// Gets the funcionarios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosInfoCompleta(string clausulas, bool soloActivos)
        {
            return FuncionariosService.GetFuncionariosInfoCompleta(clausulas, VistaNombreCompleto_NombreCol, soloActivos, false);
        }

        /// <summary>
        /// Gets the funcionarios info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFuncionariosInfoCompleta()
        {
            return FuncionariosService.GetFuncionariosInfoCompleta(string.Empty, VistaNombreCompleto_NombreCol, false, false);
        }
        #endregion GetFuncionariosInfoCompleta

        #region GetFuncionariosInfoCompletaFiltrado
        public static DataTable GetFuncionariosInfoCompletaFiltrado(string pTexto)
        {
            return GetFuncionariosInfoCompletaFiltrado(pTexto, string.Empty, false);
        }

        public static DataTable GetFuncionariosInfoCompletaFiltradoPorSucursal(string p_texto, decimal sucursal_id, string funcion)
        {
            string and = (string.IsNullOrEmpty(p_texto.Trim()))?string.Empty:"AND";
            string condicion_adicional = string.Format(" {0} {1} = {2}", and, SucursalId_NombreCol, sucursal_id);

            switch (funcion)
            {
                case Definiciones.TipoFuncionarioComision.Cobrador:
                    condicion_adicional += string.Format(" and {0} = '{1}'",EsCobrador_NombreCol, Definiciones.SiNo.Si);
                    break;
                case Definiciones.TipoFuncionarioComision.Vendedor:
                    condicion_adicional += string.Format(" and {0} = '{1}'",EsVendedor_NombreCol, Definiciones.SiNo.Si);
                break;
            }

            return GetFuncionariosInfoCompletaFiltrado(p_texto, condicion_adicional, false);
            
        }

        public static DataTable GetFuncionariosInfoCompletaFiltrado(string p_texto, string condicion_adicional)
        { 
            return GetFuncionariosInfoCompletaFiltrado(p_texto, condicion_adicional, false);
        }

        public static DataTable GetFuncionariosInfoCompletaFiltrado(string p_texto, string condicion_adicional, bool busqueda_flexible)
        {
            return GetFuncionariosInfoCompletaFiltrado(p_texto, condicion_adicional, busqueda_flexible, true);
        }

        public static DataTable GetFuncionariosInfoCompletaFiltrado(string p_texto, string condicion_adicional, bool busqueda_flexible, bool solo_activos)
        {
            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            if (p_texto.Trim().Length < cantidadMinimaCaracteres)
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");

            string txt = p_texto.Replace(' ', '%').ToUpper();
            string clausulas = "(" +
                               "     upper(" + VistaNombreCompleto_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + Ruc_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + Codigo_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + NumeroDocumento_NombreCol + ") like '%" + txt + "%'" +
                               ") ";
            if(!condicion_adicional.Equals(string.Empty))
                clausulas += " and "  + condicion_adicional;

            return FuncionariosService.GetFuncionariosInfoCompleta(clausulas, solo_activos);
        }
        #endregion GetFuncionariosInfoCompletaFiltrado

        #region GetFuncionario
        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the funcionario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetFuncionario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(Id_NombreCol + " = " + funcionario_id, string.Empty);
                return tabla;
            }
        }
        
        /// <summary>
        /// Gets the funcionario.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static DataTable GetFuncionario2(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(Id_NombreCol + " = " + funcionario_id, string.Empty);
                return tabla;
            }
        }


        /// <summary>
        /// Gets the funcionario row.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static FUNCIONARIOSRow GetFuncionarioRow(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = FuncionariosService.Id_NombreCol + " = " + funcionario_id.ToString();
                return sesion.Db.FUNCIONARIOSCollection.GetRow(clausula);
            }
        }

        public static DataTable GetFuncionarioPorMarcacionesId(decimal marcaciones_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.FUNCIONARIOSCollection.GetAsDataTable(MarcacionesId_NombreCol + " = " + marcaciones_id, string.Empty);
                return tabla;
            }
        }

        #endregion GetFuncionario

        #region GetUsuarioId
        /// <summary>
        /// Gets the usuario identifier.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static decimal GetUsuarioId(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal usuarioId = Definiciones.Error.Valor.EnteroPositivo;

                FUNCIONARIOSRow row = sesion.db.FUNCIONARIOSCollection.GetByPrimaryKey(funcionario_id);
                DataTable dtUsuarios = UsuariosService.GetUsuarios(UsuariosService.PersonaId_NombreCol + " = " + row.PERSONA_ID, string.Empty);

                if (dtUsuarios.Rows.Count > 0)
                    usuarioId = (decimal)dtUsuarios.Rows[0][UsuariosService.Id_NombreCol];

                return usuarioId;
            }
        }
        #endregion GetUsuarioId

        #region GetCargos
        /// <summary>
        /// Gets the cargos.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetCargos(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCargosFuncionario = sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.GetAsDataTable("funcionario_id = " + funcionario_id, string.Empty);
                DataTable dtCargos = sesion.Db.EMPRESA_CARGOSCollection.GetAllAsDataTable();
                DataSet ds = new DataSet();
                DataRelation relCargo;

                ds.Tables.Add(dtCargosFuncionario);
                ds.Tables.Add(dtCargos);

                relCargo = new DataRelation("relCargo", dtCargos.Columns["ID"], dtCargosFuncionario.Columns["EMPRESA_CARGO_ID"]);
                ds.Relations.Add(relCargo);

                dtCargosFuncionario.Columns.Add("cargo_nombre", typeof(String));
                dtCargosFuncionario.Columns.Add("departamento_nombre", typeof(String));
                foreach (DataRow dr in dtCargosFuncionario.Rows)
                {
                    dr["cargo_nombre"] = dr.GetParentRow("relCargo")["nombre"];
                    dr["departamento_nombre"] = dr.GetParentRow("relCargo")["empresa_departamento_id"];
                }

                return dtCargosFuncionario;
            }
        }
        #endregion GetCargos

       

        

        #region GetVendedoresInfoCompleta
        /// <summary>
        /// Gets the vendedores info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVendedoresInfoCompleta()
        {
            string where = FuncionariosService.EsVendedor_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            return GetFuncionariosInfoCompleta(where, false);
        }

        public static DataTable GetVendedoresInfoCompleta(bool soloActivos)
        {
            string where;
            if (soloActivos)
                where = FuncionariosService.EsVendedor_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " + FuncionariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            else
                where = FuncionariosService.EsVendedor_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            return GetFuncionariosInfoCompleta(where, false);
        }

        public static DataTable GetVendedoresInfoCompleta(bool soloActivos, string filtro)
        {
            string where;
            if (soloActivos)
                where = FuncionariosService.EsVendedor_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " + FuncionariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            else
                where = FuncionariosService.EsVendedor_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";

            where = "     Upper(" + FuncionariosService.Codigo_NombreCol + ") like '%" + filtro.ToUpper()   + "%'" +
                    " or  Upper(" + FuncionariosService.Nombre_NombreCol + ") like '%" + filtro.ToUpper()   + "%'" +
                    " or  Upper(" + FuncionariosService.Apellido_NombreCol + ") like '%" + filtro.ToUpper() + "%'" +
                    " or  Upper(" + FuncionariosService.NumeroDocumento_NombreCol + ") like '%" + filtro.ToUpper() + "%'"; 


            return GetFuncionariosInfoCompleta(where, false);
        }

        /// <summary>
        /// Gets the vendedores info completa.
        /// </summary>
        /// <param name="cliente_id">The cliente_id.</param>
        /// <returns></returns>
        public static DataTable GetVendedoresHabitualesInfoCompleta(decimal cliente_id)
        {
            PersonasService persona = new PersonasService();
            string strFuncionariosId = string.Empty;

            decimal funcionario_id = PersonasService.GetVendedorHabitual(cliente_id);

            //Se agrega al funcionario global
            strFuncionariosId = funcionario_id.ToString();

            //Se agregan los vendedores por familia
            if (funcionario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                DataTable dtVendedorFamiliaCliente = VendedorClienteFamiliaService.GetVendedorClienteFamiliaInfoCompleta(cliente_id);
                

                for (int i = 0; i < dtVendedorFamiliaCliente.Rows.Count; i++) 
                {
                    if (strFuncionariosId.Length > 0) strFuncionariosId += ", ";
                    strFuncionariosId += dtVendedorFamiliaCliente.Rows[i][VendedorClienteFamiliaService.FuncionarioId_NombreCol];
                }
            }

            return GetFuncionariosInfoCompleta(FuncionariosService.Id_NombreCol + " in (" + strFuncionariosId + ")", false); 
        }
        #endregion GetVendedoresInfoCompleta

        #region GetChoferesInfoCompleta
        /// <summary>
        /// Gets the choferes information completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChoferesInfoCompleta()
        {
            string clausulas = FuncionariosService.EsChofer_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            return FuncionariosService.GetFuncionariosInfoCompleta(clausulas, FuncionariosService.VistaNombreCompleto_NombreCol, false);
        }
        #endregion GetChoferesInfoCompleta

        #region GetCobradoresInfoCompleta
        public static DataTable GetCobradoresInfoCompleta()
        {
            string where = EsCobrador_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            return GetFuncionariosInfoCompleta(where, false);
        }
        public static DataTable GetCobradoresInternosYExternosInfoCompleta()
        {
            string where = EsCobrador_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            where += " or " + EsCobradorExterno_NombreCol + " = '" + Definiciones.SiNo.Si + "' ";
            return GetFuncionariosInfoCompleta(where, false);
        }

        public static DataTable GetCobradoresInfoCompleta(decimal cliente_id)
        {
            PersonasService persona = new PersonasService();
            decimal funcionario_id = persona.GetCobradorHabitual(cliente_id);
            
            return GetFuncionariosInfoCompleta(Id_NombreCol + " = " + funcionario_id, false);
        }
        #endregion GetCobradoresInfoCompleta

        #region GetFuncionarioPorCodigo
        public static decimal GetFuncionarioIdPorCodigo(string codigo)
        {
            string clausulas = "upper(" + FuncionariosService.Codigo_NombreCol + ") = '" + codigo.ToUpper() + "'";
            DataTable dtFuncionario = FuncionariosService.GetFuncionariosDataTable2(clausulas, string.Empty, false);
            if (dtFuncionario.Rows.Count <= 0)
                return Definiciones.Error.Valor.EnteroPositivo;
            else
                return (decimal)dtFuncionario.Rows[0][FuncionariosService.Id_NombreCol];
        }
        #endregion GetFuncionarioPorCodigo

        #region GetFuncionarioIdPorNroDocumento
        public static decimal GetFuncionarioIdPorNroDocumento(string nro_documento)
        {
            string clausulas = FuncionariosService.NumeroDocumento_NombreCol + " = '" + nro_documento + "'";
            DataTable dtFuncionario = FuncionariosService.GetFuncionariosDataTable2(clausulas, string.Empty, false);
            if (dtFuncionario.Rows.Count <= 0)
                return Definiciones.Error.Valor.EnteroPositivo;
            else    
                return (decimal)dtFuncionario.Rows[0][FuncionariosService.Id_NombreCol];
        }
        #endregion GetFuncionarioIdPorNroDocumento

        #region Guardar
        public static decimal Guardar(Hashtable campos, bool insertar_nuevo)
        {
            UsuariosService usuario = new UsuariosService();
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FUNCIONARIOSRow funcionario = new FUNCIONARIOSRow();
                    String valorAnterior = string.Empty;
                    Decimal dAux;
                    String sAux;

                    if (insertar_nuevo)
                    {
                        funcionario.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_sqc");
                        funcionario.ENTIDAD_ID = sesion.Entidad.ID;
                        funcionario.PERSONA_ID = (decimal)campos[Persona_IdNombreCol];
                        funcionario.INGRESO_APROBADO = Definiciones.SiNo.No;

                        funcionario.ES_COBRADOR = Definiciones.SiNo.No;
                        funcionario.ES_VENDEDOR = Definiciones.SiNo.No;
                        funcionario.ES_PROMOTOR = Definiciones.SiNo.No;
                        funcionario.ES_CHOFER = Definiciones.SiNo.No;
                        funcionario.DEPOSITERO = Definiciones.SiNo.No;
                        funcionario.ES_COBRADOR_EXTERNO = Definiciones.SiNo.No;


                        if (campos.Contains(EsCobrador_NombreCol))
                            funcionario.ES_COBRADOR = (string)campos[EsCobrador_NombreCol];
                        else
                            funcionario.ES_COBRADOR = Definiciones.SiNo.No;

                        if (campos.Contains(CodigoTalonario_NombreCol))
                            funcionario.CODIGO_TALONARIO = campos[CodigoTalonario_NombreCol].ToString();

                        if (campos.Contains(EsVendedor_NombreCol))
                            funcionario.ES_VENDEDOR = (string)campos[EsVendedor_NombreCol];
                        else
                            funcionario.ES_VENDEDOR = Definiciones.SiNo.No;

                        if (campos.Contains(EsPromotor_NombreCol))
                            funcionario.ES_PROMOTOR = (string)campos[EsPromotor_NombreCol];
                        else
                            funcionario.ES_PROMOTOR = Definiciones.SiNo.No;

                        if (campos.Contains(EsChofer_NombreCol))
                            funcionario.ES_CHOFER = (string)campos[EsChofer_NombreCol];
                        else
                            funcionario.ES_CHOFER = Definiciones.SiNo.No;

                        if (campos.Contains(Depositero_NombreCol))
                            funcionario.DEPOSITERO = (string)campos[Depositero_NombreCol];
                        else
                            funcionario.DEPOSITERO = Definiciones.SiNo.No;

                        if (campos.Contains(EsCobradorExterno_NombreCol))
                            funcionario.ES_COBRADOR_EXTERNO = (string)campos[EsCobradorExterno_NombreCol];
                        else
                            funcionario.ES_COBRADOR_EXTERNO = Definiciones.SiNo.No;

                        #region Control de Codigo
                        if (campos.Contains(Codigo_NombreCol))
                        {
                            funcionario.CODIGO = (string)campos[Codigo_NombreCol];
                        }
                        else
                        {
                            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorTabla2(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, string.Empty, AutonumeracionesService.Id_NombreCol);
                            if (dtAutonumeracion.Rows.Count > 0)
                                funcionario.CODIGO = AutonumeracionesService.GetSiguienteNumero2((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                            else
                                throw new Exception("No existe una autonumeración para los códigos de funcionarios.");
                        }
                        DataTable dtCodigo = FuncionariosService.GetFuncionariosInfoCompleta(FuncionariosService.Codigo_NombreCol + " = '" + funcionario.CODIGO + "'", true);
                        if (dtCodigo.Rows.Count > 0)
                            throw new Exception("Ya existe el Código");
                        #endregion Control de Codigo

                        funcionario.DESCUENTOS_BASICO = (string)campos[DescuentoBasico_NombreCol];
                        funcionario.DESCUENTOS_COMPLEMENTARIO = (string)campos[DescuentoComplementario_NombreCol];
                        funcionario.DESCUENTOS_EXTRA = (string)campos[DescuentoExtra_NombreCol];

                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        ActualizarDatosFuncionarios(ref funcionario, sesion);
                        GuardarDatosLaborales(ref funcionario, campos);

                        sesion.Db.FUNCIONARIOSCollection.Insert(funcionario);
                        usuario.SetUsuariosPorPersona(funcionario, sesion);
                        sesion.Db.CommitTransaction();
                        return funcionario.ID;
                    }

                    funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                    valorAnterior = funcionario.ToString();
                    GuardarDatosLaborales(ref funcionario, campos);

                    funcionario.NOMBRE = (string)campos[Nombre_NombreCol];
                    funcionario.APELLIDO = (string)campos[Apellido_NombreCol];
                    funcionario.APODO = (string)campos[Apodo_NombreCol];
                    funcionario.NUMERO_DOCUMENTO = ((string)campos[NumeroDocumento_NombreCol]).Trim();
                    funcionario.RUC = ((string)campos[Ruc_NombreCol]).Trim();
                    funcionario.GENERO = (string)campos[Genero_NombreCol];
                    funcionario.GRUPO_SANGUINEO = (string)campos[GrupoSanguineo_NombreCol];
                    funcionario.MOTIVO_SALIDA = (string)campos[MotivoSalida_NombreCol];

                    if(campos.Contains(CentroCostoId_NombreCol))
                        funcionario.CENTRO_COSTO_ID = (decimal)campos[CentroCostoId_NombreCol];
                    else
                        funcionario.IsCENTRO_COSTO_IDNull = true;

                    funcionario.CALLE1 = (string)campos[Calle1_NombreCol];
                    funcionario.CODIGO_POSTAL1 = (string)campos[CodigoPostal1_NombreCol];
                    funcionario.CALLE2 = (string)campos[Calle2_NombreCol];
                    funcionario.CODIGO_POSTAL2 = (string)campos[CodigoPostal2_NombreCol];

                    funcionario.TELEFONO1 = (string)campos[Telefono1_NombreCol];
                    funcionario.TELEFONO2 = (string)campos[Telefono2_NombreCol];
                    funcionario.TELEFONO3 = (string)campos[Telefono3_NombreCol];
                    funcionario.TELEFONO4 = (string)campos[Telefono4_NombreCol];
                    funcionario.EMAIL1 = (string)campos[Email1_NombreCol];
                    funcionario.EMAIL2 = (string)campos[Email2_NombreCol];
                    funcionario.EMAIL3 = (string)campos[Email3_NombreCol];

                    funcionario.CALLE_FAMILIAR_CONTACTO = (string)campos[CalleFamiliarContacto_NombreCol];
                    funcionario.COD_POST_FAMILIAR_CONTACTO = (string)campos[CodPostFamiliarContacto_NombreCol];

                    funcionario.NOMBRE_FAMILIAR_CONTACTO = (string)campos[NombreFamiliarContacto_NombreCol];
                    funcionario.RELACION_FAMILIAR_CONTACTO = (string)campos[RelacionFamiliarContacto_NombreCol];
                    funcionario.TELEFONO_FAMILIAR_CONTACTO = (string)campos[TelefonoFamiliarContacto_NombreCol];

                    if (campos.Contains(CanalVentaId_NombreCol))
                        funcionario.CANAL_VENTA_ID = (decimal)campos[CanalVentaId_NombreCol];
                    else
                        funcionario.IsCANAL_VENTA_IDNull = true;

                    if (campos.Contains(CodigoTalonario_NombreCol))
                        funcionario.CODIGO_TALONARIO = campos[CodigoTalonario_NombreCol].ToString();

                    if (campos[Estado_NombreCol].ToString().Length > 0 && !funcionario.ESTADO.Equals((string)campos[Estado_NombreCol]))
                    {
                        funcionario.ESTADO = (string)campos[Estado_NombreCol];
                        ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID);
                    }
                    else
                    {
                        funcionario.ESTADO = Definiciones.Estado.Activo;
                    }
                    Predicate<string> EsSi = (sino) => sino.Equals(Definiciones.SiNo.Si);
                    if (campos.Contains(EsCobrador_NombreCol))
                    {
                        if (!funcionario.ES_COBRADOR.Equals((string)campos[EsCobrador_NombreCol]) && !EsSi((string)campos[EsCobrador_NombreCol]))
                            ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.Cobrador);
                        funcionario.ES_COBRADOR = (string)campos[EsCobrador_NombreCol];
                    }
                    if (campos.Contains(EsVendedor_NombreCol))
                    {
                        if (!funcionario.ES_VENDEDOR.Equals((string)campos[EsVendedor_NombreCol]) && !EsSi((string)campos[EsVendedor_NombreCol]))
                            ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.Vendedor);
                        funcionario.ES_VENDEDOR = (string)campos[EsVendedor_NombreCol];
                    }
                    if (campos.Contains(EsVendedor_NombreCol))
                    {
                        if (!funcionario.ES_COBRADOR_EXTERNO.Equals((string)campos[EsCobradorExterno_NombreCol]) && !EsSi((string)campos[EsCobradorExterno_NombreCol]))
                            ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.CobradorExterno);
                        funcionario.ES_COBRADOR_EXTERNO = (string)campos[EsCobradorExterno_NombreCol];
                    }
                    if (campos.Contains(PaisNacionalidadId_NombreCol))
                    {
                        dAux = (decimal)campos[PaisNacionalidadId_NombreCol];
                        if (funcionario.IsPAIS_NACIONALIDAD_IDNull || funcionario.PAIS_NACIONALIDAD_ID != dAux)
                        {
                            if (PaisesService.EstaActivo(dAux))
                                funcionario.PAIS_NACIONALIDAD_ID = dAux;
                            else
                                throw new System.ArgumentException("La nacionalidad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsPAIS_NACIONALIDAD_IDNull = true;
                    }

                    sAux = (string)campos[TratamientoId_NombreCol];
                    if (funcionario.TRATAMIENTO_ID != sAux)
                    {
                        if (TratamientosService.EstaActivo(sAux)) funcionario.TRATAMIENTO_ID = sAux;
                        else throw new System.ArgumentException("El tratamiento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                    sAux = (string)campos[TipoDocumentoId_NombreCol];
                    if (funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID != sAux)
                    {
                        if (TiposDocumentosIdentidadService.EstaActivo(sAux)) funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID = sAux;
                        else throw new System.ArgumentException("El tipo de documento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    sAux = (string)campos[ProfesionId_NombreCol];
                    if (funcionario.PROFESION_ID != sAux)
                    {
                        if (ProfesionesService.EstaActivo(sAux))
                            funcionario.PROFESION_ID = sAux;
                        else
                            throw new System.ArgumentException("La profesión seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }

                    if (campos.Contains(Nacimiento_NombreCol))
                        funcionario.NACIMIENTO = DateTime.Parse((string)campos[Nacimiento_NombreCol]);
                    else
                        funcionario.IsNACIMIENTONull = true;

                    if (campos.Contains(EsPromotor_NombreCol))
                        funcionario.ES_PROMOTOR = (string)campos[EsPromotor_NombreCol];
                    if (campos.Contains(EsChofer_NombreCol))
                        funcionario.ES_CHOFER = (string)campos[EsChofer_NombreCol];
                    if (campos.Contains(Depositero_NombreCol))
                        funcionario.DEPOSITERO = (string)campos[Depositero_NombreCol];

                    if (campos.Contains(FechaContratacion_NombreCol))
                        funcionario.FECHA_CONTRATACION = DateTime.Parse((string)campos[FechaContratacion_NombreCol]);
                    else
                        funcionario.IsFECHA_CONTRATACIONNull = true;

                    if (campos.Contains(FechaSalida_NombreCol))
                        funcionario.FECHA_SALIDA = DateTime.Parse((string)campos[FuncionariosService.FechaSalida_NombreCol]);
                    else
                        funcionario.IsFECHA_SALIDANull = true;

                    if (campos.Contains(EstadoDocumentacionId_NombreCol))
                    {
                        dAux = (decimal)campos[EstadoDocumentacionId_NombreCol];
                        if (funcionario.IsESTADO_DOCUMENTACION_IDNull || funcionario.ESTADO_DOCUMENTACION_ID != dAux)
                        {
                            if (EstadosDocumentacionService.EstaActivo(dAux))
                                funcionario.ESTADO_DOCUMENTACION_ID = dAux;
                            else
                                throw new System.ArgumentException("El estado de la documentación seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsESTADO_DOCUMENTACION_IDNull = true;
                    }


                    if (funcionario.INGRESO_APROBADO != (string)campos[IngresoAprobado_NombreCol])
                    {
                        if ((string)campos[IngresoAprobado_NombreCol] == Definiciones.SiNo.Si)
                        {//Se aprobo el ingreso
                            funcionario.FECHA_APROBACION = DateTime.Now;
                            funcionario.USUARIO_APROBACION_ID = sesion.Usuario.ID;
                            funcionario.INGRESO_APROBADO = (string)campos[IngresoAprobado_NombreCol];
                        }
                        else
                        {
                            throw new ArgumentException("No puede desaprobarse el ingreso de un funcionario aprobado previamente.");
                        }
                    }

                    if (campos.Contains(PaisResidenciaId_NombreCol))
                    {
                        dAux = (decimal)campos[PaisResidenciaId_NombreCol];
                        if (funcionario.IsPAIS_RESIDENCIA_IDNull || funcionario.PAIS_RESIDENCIA_ID != dAux)
                        {
                            if (PaisesService.EstaActivo(dAux))
                                funcionario.PAIS_RESIDENCIA_ID = dAux;
                            else
                                throw new System.ArgumentException("El país de residencia seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsPAIS_RESIDENCIA_IDNull = true;
                    }

                    if (campos.Contains(Departamento1Id_NombreCol))
                    {
                        dAux = (decimal)campos[Departamento1Id_NombreCol];
                        if (funcionario.IsDEPARTAMENTO1_IDNull || funcionario.DEPARTAMENTO1_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux))
                                funcionario.DEPARTAMENTO1_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsDEPARTAMENTO1_IDNull = true;
                    }

                    if (campos.Contains(Ciudad1Id_NombreCol))
                    {
                        dAux = (decimal)campos[Ciudad1Id_NombreCol];
                        if (funcionario.IsCIUDAD1_IDNull || funcionario.CIUDAD1_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux))
                                funcionario.CIUDAD1_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad principal seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsCIUDAD1_IDNull = true;
                    }

                    if (campos.Contains(Barrio1Id_NombreCol))
                    {
                        dAux = (decimal)campos[Barrio1Id_NombreCol];
                        if (funcionario.IsBARRIO1_IDNull || funcionario.BARRIO1_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux))
                                funcionario.BARRIO1_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsBARRIO1_IDNull = true;
                    }


                    if (campos.Contains(Departamento2Id_NombreCol))
                    {
                        dAux = (decimal)campos[Departamento2Id_NombreCol];
                        if (funcionario.IsDEPARTAMENTO2_IDNull || funcionario.DEPARTAMENTO2_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux))
                                funcionario.DEPARTAMENTO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsDEPARTAMENTO2_IDNull = true;
                    }

                    if (campos.Contains(Ciudad2Id_NombreCol))
                    {
                        dAux = (decimal)campos[Ciudad2Id_NombreCol];
                        if (funcionario.IsCIUDAD2_IDNull || funcionario.CIUDAD2_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux))
                                funcionario.CIUDAD2_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad secundaria seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsCIUDAD2_IDNull = true;
                    }

                    if (campos.Contains(Barrio2Id_NombreCol))
                    {
                        dAux = (decimal)campos[Barrio2Id_NombreCol];
                        if (funcionario.IsBARRIO2_IDNull || funcionario.BARRIO2_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux))
                                funcionario.BARRIO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsBARRIO2_IDNull = true;
                    }


                    if (campos.Contains(FuncionariosService.Latitud1_NombreCol) || campos.Contains(FuncionariosService.Longitud1_NombreCol))
                    {
                        if (!(campos.Contains(FuncionariosService.Latitud1_NombreCol) && campos.Contains(FuncionariosService.Longitud1_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        funcionario.LATITUD1 = (decimal)campos[FuncionariosService.Latitud1_NombreCol];
                        funcionario.LONGITUD1 = (decimal)campos[FuncionariosService.Longitud1_NombreCol];
                    }
                    else
                    {
                        funcionario.IsLATITUD1Null = true;
                        funcionario.IsLONGITUD1Null = true;
                    }

                    if (campos.Contains(FuncionariosService.Latitud2_NombreCol) || campos.Contains(FuncionariosService.Longitud2_NombreCol))
                    {
                        if (!(campos.Contains(FuncionariosService.Latitud2_NombreCol) && campos.Contains(FuncionariosService.Longitud2_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        funcionario.LATITUD2 = (decimal)campos[FuncionariosService.Latitud2_NombreCol];
                        funcionario.LONGITUD2 = (decimal)campos[FuncionariosService.Longitud2_NombreCol];
                    }
                    else
                    {
                        funcionario.IsLATITUD2Null = true;
                        funcionario.IsLONGITUD2Null = true;
                    }

                    if (campos.Contains(FuncionariosService.LatitudFamiliarContacto_NombreCol) || campos.Contains(FuncionariosService.LongitudFamiliarContacto_NombreCol))
                    {
                        if (!(campos.Contains(FuncionariosService.LatitudFamiliarContacto_NombreCol) && campos.Contains(FuncionariosService.LongitudFamiliarContacto_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        funcionario.LATITUD_FAMILIAR_CONTACTO = (decimal)campos[FuncionariosService.LatitudFamiliarContacto_NombreCol];
                        funcionario.LONGITUD_FAMILIAR_CONTACTO = (decimal)campos[FuncionariosService.LongitudFamiliarContacto_NombreCol];
                    }
                    else
                    {
                        funcionario.IsLATITUD_FAMILIAR_CONTACTONull = true;
                        funcionario.IsLONGITUD_FAMILIAR_CONTACTONull = true;
                    }

                    if (campos.Contains(DepartamentoFamiliarContId_NombreCol))
                    {
                        dAux = (decimal)campos[DepartamentoFamiliarContId_NombreCol];
                        if (funcionario.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull || funcionario.DEPARTAMENTO_FAMILIAR_CONT_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux)) funcionario.DEPARTAMENTO_FAMILIAR_CONT_ID = dAux;
                            else throw new System.ArgumentException("El departamento del contacto familiar seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull = true;
                    }

                    if (campos.Contains(CiudadFamiliarContactoId_NombreCol))
                    {
                        dAux = (decimal)campos[CiudadFamiliarContactoId_NombreCol];
                        if (funcionario.IsCIUDAD_FAMILIAR_CONTACTO_IDNull || funcionario.CIUDAD_FAMILIAR_CONTACTO_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux)) funcionario.CIUDAD_FAMILIAR_CONTACTO_ID = dAux;
                            else throw new System.ArgumentException("La ciudad del contacto familiar seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsCIUDAD_FAMILIAR_CONTACTO_IDNull = true;
                    }

                    if (campos.Contains(BarrioFamiliarContactoId_NombreCol))
                    {
                        dAux = (decimal)campos[BarrioFamiliarContactoId_NombreCol];
                        if (funcionario.IsBARRIO_FAMILIAR_CONTACTO_IDNull || funcionario.BARRIO_FAMILIAR_CONTACTO_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux)) funcionario.BARRIO_FAMILIAR_CONTACTO_ID = dAux;
                            else throw new System.ArgumentException("El barrio del contacto familiar seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        funcionario.IsBARRIO_FAMILIAR_CONTACTO_IDNull = true;
                    }

                    funcionario.DESCUENTOS_BASICO = (string)campos[DescuentoBasico_NombreCol];
                    funcionario.DESCUENTOS_COMPLEMENTARIO = (string)campos[DescuentoComplementario_NombreCol];
                    funcionario.DESCUENTOS_EXTRA = (string)campos[DescuentoExtra_NombreCol];

                    sesion.Db.FUNCIONARIOSCollection.Update(funcionario);


                    LogCambiosService.LogDeRegistro(Nombre_Tabla, funcionario.ID, valorAnterior, funcionario.ToString(), sesion);
                    //Actualizamos los datos de la persona
                    ActualizarPersona(funcionario, sesion);
                    usuario.SetUsuariosPorPersona(funcionario, sesion);
                    sesion.Db.CommitTransaction();
                    return funcionario.ID;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            if (exp.Message.IndexOf("UK_FUNCIONARIOS_COD_ENTIDAD") >= 0)
                                throw new System.ArgumentException("Ya Existe un Funcionario con el mismo Código.", exp);
                            else
                                throw new System.ArgumentException("Error de unicidad.", exp);
                        default:
                            throw;
                    }
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Modificar
        public static decimal Modificar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                return Modificar(campos, sesion);
            }
        }

        public static decimal Modificar(Hashtable campos, SessionService sesion)
        {
            UsuariosService usuario = new UsuariosService();
            
            try
            {
                FUNCIONARIOSRow funcionario = new FUNCIONARIOSRow();
                String valorAnterior = string.Empty;
                Decimal dAux;
                String sAux;

                if (!campos.Contains(FuncionariosService.Id_NombreCol))
                    throw new Exception("Debe indicar la id del funcionario para modificar sus datos.");

                funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(FuncionariosService.Id_NombreCol + " = " + campos[FuncionariosService.Id_NombreCol].ToString());
                valorAnterior = funcionario.ToString();

                // Booleanos obligatorios
                if (campos.Contains(FuncionariosService.IngresoAprobado_NombreCol))
                    funcionario.INGRESO_APROBADO = campos[FuncionariosService.IngresoAprobado_NombreCol].ToString();

                if (campos.Contains(FuncionariosService.EsCobrador_NombreCol))
                {
                    if (!funcionario.ES_COBRADOR.Equals((string)campos[FuncionariosService.EsCobrador_NombreCol]) && ((string)campos[FuncionariosService.EsCobrador_NombreCol]).Equals(Definiciones.SiNo.No))
                        ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.Cobrador);
                    funcionario.ES_COBRADOR = campos[FuncionariosService.EsCobrador_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.EsVendedor_NombreCol))
                {
                    if (!funcionario.ES_VENDEDOR.Equals((string)campos[FuncionariosService.EsVendedor_NombreCol]) && ((string)campos[FuncionariosService.EsVendedor_NombreCol]).Equals(Definiciones.SiNo.No))
                        ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.Vendedor);
                    funcionario.ES_VENDEDOR = campos[FuncionariosService.EsVendedor_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.EsPromotor_NombreCol))
                    funcionario.ES_PROMOTOR = campos[FuncionariosService.EsPromotor_NombreCol].ToString();

                if (campos.Contains(FuncionariosService.EsChofer_NombreCol))
                    funcionario.ES_CHOFER = campos[FuncionariosService.EsChofer_NombreCol].ToString();

                if (campos.Contains(FuncionariosService.Depositero_NombreCol))
                    funcionario.DEPOSITERO = campos[FuncionariosService.Depositero_NombreCol].ToString();

                if (campos.Contains(FuncionariosService.EsCobradorExterno_NombreCol))
                {
                    if (!funcionario.ES_COBRADOR_EXTERNO.Equals((string)campos[EsCobradorExterno_NombreCol]) && ((string)campos[EsCobradorExterno_NombreCol]).Equals(Definiciones.SiNo.No))
                        ZonasFuncionariosService.DesrelacionarFuncionario(funcionario.ID, Definiciones.TipoFuncionarioComision.CobradorExterno);
                    funcionario.ES_COBRADOR_EXTERNO = campos[FuncionariosService.EsCobradorExterno_NombreCol].ToString();
                }

                // Codigo
                if (campos.Contains(FuncionariosService.Codigo_NombreCol))
                    funcionario.CODIGO = (string)campos[FuncionariosService.Codigo_NombreCol];

                if (campos.Contains(FuncionariosService.CanalVentaId_NombreCol))
                    funcionario.CANAL_VENTA_ID = (decimal)campos[FuncionariosService.CanalVentaId_NombreCol];
                else
                    funcionario.IsCANAL_VENTA_IDNull = true;

                DataTable dtCodigo = FuncionariosService.GetFuncionariosInfoCompleta(FuncionariosService.Codigo_NombreCol + " = '" + funcionario.CODIGO + "'", true);
                if (dtCodigo.Rows.Count > 0 && !dtCodigo.Rows[0][FuncionariosService.Id_NombreCol].Equals(funcionario.ID))
                    throw new Exception("Ya existe el código.");
                
                // Se guardan los datos laborales
                if (campos.Contains(FuncionariosService.SucursalId_NombreCol))
                {
                    if (campos[FuncionariosService.SucursalId_NombreCol].Equals(DBNull.Value))
                        funcionario.IsSUCURSAL_IDNull = true;
                    else
                        funcionario.SUCURSAL_ID = (decimal)campos[FuncionariosService.SucursalId_NombreCol];
                }

                if (campos.Contains(FuncionariosService.TipoSalario_NombreCol))
                {
                    if (campos[FuncionariosService.TipoSalario_NombreCol].Equals(DBNull.Value))
                        funcionario.IsSALARIO_TIPONull = true;
                    else
                        funcionario.SALARIO_TIPO = int.Parse(campos[FuncionariosService.TipoSalario_NombreCol].ToString());
                }

                if (campos.Contains(FuncionariosService.CobraSalarioMinimo_NombreCol))
                {
                    if (campos[FuncionariosService.CobraSalarioMinimo_NombreCol].Equals(DBNull.Value))
                        funcionario.COBRA_SALARIO_MINIMO = Definiciones.SiNo.No;    
                    else
                        funcionario.COBRA_SALARIO_MINIMO = campos[FuncionariosService.CobraSalarioMinimo_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.Salario_NombreCol))
                {
                    if (campos[FuncionariosService.Salario_NombreCol].Equals(DBNull.Value))
                        funcionario.IsSALARIONull = true;
                    else
                        funcionario.SALARIO = decimal.Parse(campos[FuncionariosService.Salario_NombreCol].ToString());
                }

                if (campos.Contains(FuncionariosService.CobraAnticipo_NombreCol))
                {
                    if (campos[FuncionariosService.CobraAnticipo_NombreCol].Equals(DBNull.Value))
                        funcionario.COBRA_ANTICIPO = Definiciones.SiNo.No;
                    else
                        funcionario.COBRA_ANTICIPO = campos[FuncionariosService.CobraAnticipo_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.AnticipoMonto_NombreCol))
                {
                    if (campos[FuncionariosService.AnticipoMonto_NombreCol].Equals(DBNull.Value))
                        funcionario.IsMONTO_ANTICIPONull = true;
                    else
                        funcionario.MONTO_ANTICIPO = decimal.Parse(campos[FuncionariosService.AnticipoMonto_NombreCol].ToString());
                }

                if (campos.Contains(FuncionariosService.CobraBonificacion_NombreCol))
                {
                    if (campos[FuncionariosService.AnticipoMonto_NombreCol].Equals(DBNull.Value))
                        funcionario.COBRA_BONIFICACION = Definiciones.SiNo.No;
                    else
                        funcionario.COBRA_BONIFICACION = campos[FuncionariosService.CobraBonificacion_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.MontoBonificacion_NombreCol))
                {
                    if (campos[FuncionariosService.MontoBonificacion_NombreCol].Equals(DBNull.Value))
                        funcionario.MONTO_BONIFICACION = decimal.Parse(campos[FuncionariosService.MontoBonificacion_NombreCol].ToString());
                    else
                        funcionario.MONTO_BONIFICACION = decimal.Parse(campos[FuncionariosService.MontoBonificacion_NombreCol].ToString());
                }

                if (campos.Contains(SalarioComplementario_NombreCol))
                {
                    if (campos[FuncionariosService.SalarioComplementario_NombreCol].Equals(DBNull.Value))                    
                        funcionario.IsSALARIO_COMPLEMENTARIONull = true;
                    else
                        funcionario.SALARIO_COMPLEMENTARIO = decimal.Parse(campos[FuncionariosService.SalarioComplementario_NombreCol].ToString());                        
                }

                if (campos.Contains(FuncionariosService.SalarioExtra_NombreCol))
                {
                    if (campos[FuncionariosService.SalarioExtra_NombreCol].Equals(DBNull.Value))                    
                        funcionario.IsSALARIO_EXTRANull = true;
                    else
                        funcionario.SALARIO_EXTRA = decimal.Parse(campos[FuncionariosService.SalarioExtra_NombreCol].ToString());
                }

                if (campos.Contains(FuncionariosService.MonedaId_NombreCol))
                {
                    if (campos[FuncionariosService.MonedaId_NombreCol].Equals(DBNull.Value))                    
                        funcionario.IsMONEDA_IDNull = true;
                    else
                        funcionario.MONEDA_ID = decimal.Parse(campos[FuncionariosService.MonedaId_NombreCol].ToString());
                }

                if (campos.Contains(FuncionariosService.Ctacte_NombreCol))
                {
                    if (campos[FuncionariosService.Ctacte_NombreCol].Equals(DBNull.Value))                    
                        funcionario.CTACTE = string.Empty;
                    else
                        funcionario.CTACTE = campos[FuncionariosService.Ctacte_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.MarcacionesId_NombreCol))
                {
                    if (campos[FuncionariosService.MarcacionesId_NombreCol].Equals(DBNull.Value))                    
                        funcionario.IsMARCACIONES_IDNull = true;
                    else
                        funcionario.MARCACIONES_ID = decimal.Parse(campos[FuncionariosService.MarcacionesId_NombreCol].ToString());
                }

                // Resto de los campos
                if (campos.Contains(FuncionariosService.Nombre_NombreCol))                
                    funcionario.NOMBRE = (string)campos[FuncionariosService.Nombre_NombreCol];

                if (campos.Contains(FuncionariosService.Apellido_NombreCol))
                {
                    if (campos[FuncionariosService.Apellido_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.APELLIDO = string.Empty;
                    else
                        funcionario.APELLIDO = (string)campos[Apellido_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Apodo_NombreCol))
                {
                    if (campos[FuncionariosService.Apodo_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.APODO = string.Empty;
                    else
                        funcionario.APODO = (string)campos[FuncionariosService.Apodo_NombreCol];
                }

                if (campos.Contains(FuncionariosService.NumeroDocumento_NombreCol))
                {
                    if (campos[FuncionariosService.NumeroDocumento_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.NUMERO_DOCUMENTO = string.Empty;
                    else
                        funcionario.NUMERO_DOCUMENTO = ((string)campos[NumeroDocumento_NombreCol]).Trim();
                }

                if (campos.Contains(FuncionariosService.Ruc_NombreCol))
                {
                    if (campos[FuncionariosService.Ruc_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.RUC = string.Empty;
                    else
                        funcionario.RUC = ((string)campos[FuncionariosService.Ruc_NombreCol]).Trim();
                }

                if (campos.Contains(FuncionariosService.Genero_NombreCol))
                {
                    if (campos[FuncionariosService.Genero_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.GENERO = string.Empty;
                    else
                        funcionario.GENERO = (string)campos[FuncionariosService.Genero_NombreCol];                        
                }

                if (campos.Contains(FuncionariosService.GrupoSanguineo_NombreCol))
                {
                    if (campos[FuncionariosService.GrupoSanguineo_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.GRUPO_SANGUINEO = string.Empty;
                    else
                        funcionario.GRUPO_SANGUINEO = (string)campos[FuncionariosService.GrupoSanguineo_NombreCol];
                }

                if (campos.Contains(FuncionariosService.MotivoSalida_NombreCol))
                {
                    if (campos[FuncionariosService.MotivoSalida_NombreCol].Equals(DBNull.Value))                                        
                        funcionario.MOTIVO_SALIDA = string.Empty;
                    else
                        funcionario.MOTIVO_SALIDA = (string)campos[FuncionariosService.MotivoSalida_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CentroCostoId_NombreCol) && !Interprete.EsNullODBNull(campos[FuncionariosService.CentroCostoId_NombreCol]))
                    funcionario.CENTRO_COSTO_ID = (decimal)campos[FuncionariosService.CentroCostoId_NombreCol];
                else
                    funcionario.IsCENTRO_COSTO_IDNull = true;

                if (campos.Contains(FuncionariosService.Calle1_NombreCol))
                {
                    if (campos[FuncionariosService.Calle1_NombreCol].Equals(DBNull.Value))
                        funcionario.CALLE1 = string.Empty;
                    else
                        funcionario.CALLE1 = (string)campos[FuncionariosService.Calle1_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CodigoPostal1_NombreCol))
                {
                    if (campos[FuncionariosService.CodigoPostal1_NombreCol].Equals(DBNull.Value))
                        funcionario.CODIGO_POSTAL1 = string.Empty;
                    else
                        funcionario.CODIGO_POSTAL1 = (string)campos[FuncionariosService.CodigoPostal1_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Calle2_NombreCol))
                {
                    if (campos[FuncionariosService.Calle2_NombreCol].Equals(DBNull.Value))
                        funcionario.CALLE2 = string.Empty;
                    else
                        funcionario.CALLE2 = (string)campos[FuncionariosService.Calle2_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CodigoPostal2_NombreCol))
                {
                    if (campos[FuncionariosService.CodigoPostal2_NombreCol].Equals(DBNull.Value))
                        funcionario.CODIGO_POSTAL2 = string.Empty;
                    else
                        funcionario.CODIGO_POSTAL2 = (string)campos[FuncionariosService.CodigoPostal2_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Telefono1_NombreCol))
                {
                    if (campos[FuncionariosService.Telefono1_NombreCol].Equals(DBNull.Value))
                        funcionario.TELEFONO1 = string.Empty;
                    else
                        funcionario.TELEFONO1 = (string)campos[FuncionariosService.Telefono1_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Telefono2_NombreCol))
                {
                    if (campos[FuncionariosService.Telefono2_NombreCol].Equals(DBNull.Value))
                        funcionario.TELEFONO2 = string.Empty;
                    else
                        funcionario.TELEFONO2 = (string)campos[FuncionariosService.Telefono2_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Telefono3_NombreCol))
                {
                    if (campos[FuncionariosService.Telefono3_NombreCol].Equals(DBNull.Value))
                        funcionario.TELEFONO3 = string.Empty;
                    else
                        funcionario.TELEFONO3 = (string)campos[FuncionariosService.Telefono3_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Telefono4_NombreCol))
                {
                    if (campos[FuncionariosService.Telefono4_NombreCol].Equals(DBNull.Value))
                        funcionario.TELEFONO4 = string.Empty;
                    else
                        funcionario.TELEFONO4 = (string)campos[FuncionariosService.Telefono4_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Email1_NombreCol))
                {
                    if (campos[FuncionariosService.Email1_NombreCol].Equals(DBNull.Value))
                        funcionario.EMAIL1 = string.Empty;
                    else
                        funcionario.EMAIL1 = (string)campos[FuncionariosService.Email1_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Email2_NombreCol))
                {
                    if (campos[FuncionariosService.Email2_NombreCol].Equals(DBNull.Value))
                        funcionario.EMAIL2 = string.Empty;
                    else
                        funcionario.EMAIL2 = (string)campos[FuncionariosService.Email2_NombreCol];
                }

                if (campos.Contains(FuncionariosService.Email3_NombreCol))
                {
                    if (campos[FuncionariosService.Email3_NombreCol].Equals(DBNull.Value))
                        funcionario.EMAIL3 = string.Empty;
                    else
                        funcionario.EMAIL3 = (string)campos[FuncionariosService.Email3_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CalleFamiliarContacto_NombreCol))
                {
                    if (campos[FuncionariosService.CalleFamiliarContacto_NombreCol].Equals(DBNull.Value))
                        funcionario.CALLE_FAMILIAR_CONTACTO = string.Empty;
                    else
                        funcionario.CALLE_FAMILIAR_CONTACTO = (string)campos[FuncionariosService.CalleFamiliarContacto_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CodPostFamiliarContacto_NombreCol))
                {
                    if (campos[FuncionariosService.CodPostFamiliarContacto_NombreCol].Equals(DBNull.Value))
                        funcionario.COD_POST_FAMILIAR_CONTACTO = string.Empty;
                    else
                        funcionario.COD_POST_FAMILIAR_CONTACTO = (string)campos[FuncionariosService.CodPostFamiliarContacto_NombreCol];
                }

                if (campos.Contains(FuncionariosService.NombreFamiliarContacto_NombreCol))
                {
                    if (campos[FuncionariosService.NombreFamiliarContacto_NombreCol].Equals(DBNull.Value))
                        funcionario.NOMBRE_FAMILIAR_CONTACTO = string.Empty;
                    else
                        funcionario.NOMBRE_FAMILIAR_CONTACTO = (string)campos[FuncionariosService.NombreFamiliarContacto_NombreCol];
                }

                if (campos.Contains(FuncionariosService.RelacionFamiliarContacto_NombreCol))
                {
                    if (campos[FuncionariosService.RelacionFamiliarContacto_NombreCol].Equals(DBNull.Value))
                        funcionario.RELACION_FAMILIAR_CONTACTO = string.Empty;
                    else
                        funcionario.RELACION_FAMILIAR_CONTACTO = (string)campos[FuncionariosService.RelacionFamiliarContacto_NombreCol];
                }

                if (campos.Contains(FuncionariosService.TelefonoFamiliarContacto_NombreCol))
                {
                    if (campos[FuncionariosService.TelefonoFamiliarContacto_NombreCol].Equals(DBNull.Value))
                        funcionario.TELEFONO_FAMILIAR_CONTACTO = string.Empty;
                    else
                        funcionario.TELEFONO_FAMILIAR_CONTACTO = (string)campos[FuncionariosService.TelefonoFamiliarContacto_NombreCol];
                }

                if (campos.Contains(FuncionariosService.CodigoTalonario_NombreCol))
                {
                    if (campos[FuncionariosService.CodigoTalonario_NombreCol].Equals(DBNull.Value))
                        funcionario.CODIGO_TALONARIO = string.Empty;
                    else
                        funcionario.CODIGO_TALONARIO = campos[FuncionariosService.CodigoTalonario_NombreCol].ToString();
                }

                if (campos.Contains(FuncionariosService.PaisNacionalidadId_NombreCol))
                {
                    if (campos[FuncionariosService.PaisNacionalidadId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsPAIS_NACIONALIDAD_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.PaisNacionalidadId_NombreCol];
                        if (funcionario.IsPAIS_NACIONALIDAD_IDNull || funcionario.PAIS_NACIONALIDAD_ID != dAux)
                        {
                            if (PaisesService.EstaActivo(dAux))
                                funcionario.PAIS_NACIONALIDAD_ID = dAux;
                            else
                                throw new System.ArgumentException("La nacionalidad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                }

                if (campos.Contains(FuncionariosService.TratamientoId_NombreCol))
                {
                    if (campos[FuncionariosService.TratamientoId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.TRATAMIENTO_ID = string.Empty;
                    }
                    else
                    {
                        sAux = (string)campos[FuncionariosService.TratamientoId_NombreCol];
                        if (funcionario.TRATAMIENTO_ID.Equals(string.Empty) || funcionario.TRATAMIENTO_ID != sAux)
                        {
                            if (TratamientosService.EstaActivo(sAux))
                                funcionario.TRATAMIENTO_ID = sAux;
                            else
                                throw new System.ArgumentException("El tratamiento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                }

                if (campos.Contains(FuncionariosService.TipoDocumentoId_NombreCol))
                {
                    if (campos[FuncionariosService.TipoDocumentoId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID = string.Empty;
                    }
                    else
                    {
                        sAux = (string)campos[FuncionariosService.TipoDocumentoId_NombreCol];
                        if (funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID.Equals(string.Empty) || funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID != sAux)
                        {
                            if (TiposDocumentosIdentidadService.EstaActivo(sAux))
                                funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID = sAux;
                            else
                                throw new System.ArgumentException("El tipo de documento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                }

                if (campos.Contains(FuncionariosService.ProfesionId_NombreCol))
                {
                    if (campos[FuncionariosService.ProfesionId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.PROFESION_ID = string.Empty;
                    }
                    else
                    {
                        sAux = (string)campos[FuncionariosService.ProfesionId_NombreCol];
                        if (funcionario.PROFESION_ID.Equals(string.Empty) || funcionario.PROFESION_ID != sAux)
                            if (ProfesionesService.EstaActivo(sAux))
                                funcionario.PROFESION_ID = sAux;
                            else
                                throw new System.ArgumentException("La profesión seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Nacimiento_NombreCol))
                {
                    if (campos[FuncionariosService.Nacimiento_NombreCol].Equals(DBNull.Value))
                        funcionario.IsNACIMIENTONull = true;
                    else
                        funcionario.NACIMIENTO = DateTime.Parse((string)campos[FuncionariosService.Nacimiento_NombreCol]);
                }

                if (campos.Contains(FuncionariosService.FechaContratacion_NombreCol))
                {
                    if (campos[FuncionariosService.FechaContratacion_NombreCol].Equals(DBNull.Value))
                        funcionario.IsFECHA_CONTRATACIONNull = true;
                    else
                        funcionario.FECHA_CONTRATACION = DateTime.Parse((string)campos[FuncionariosService.FechaContratacion_NombreCol]);
                }

                if (campos.Contains(FuncionariosService.FechaSalida_NombreCol))
                {
                    if (campos[FuncionariosService.FechaSalida_NombreCol].Equals(DBNull.Value))
                        funcionario.IsFECHA_SALIDANull = true;
                    else
                        funcionario.FECHA_SALIDA = DateTime.Parse((string)campos[FuncionariosService.FechaSalida_NombreCol]);
                }
                

                if (campos.Contains(FuncionariosService.EstadoDocumentacionId_NombreCol))
                {
                    if (campos[FuncionariosService.EstadoDocumentacionId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsESTADO_DOCUMENTACION_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.EstadoDocumentacionId_NombreCol];
                        if (funcionario.IsESTADO_DOCUMENTACION_IDNull || funcionario.ESTADO_DOCUMENTACION_ID != dAux)
                            if (EstadosDocumentacionService.EstaActivo(dAux))
                                funcionario.ESTADO_DOCUMENTACION_ID = dAux;
                            else
                                throw new System.ArgumentException("El estado de la documentación seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Estado_NombreCol))
                    funcionario.ESTADO = (string)campos[FuncionariosService.Estado_NombreCol];

                if (campos.Contains(FuncionariosService.PaisResidenciaId_NombreCol))
                {
                    if (campos[FuncionariosService.PaisResidenciaId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsPAIS_RESIDENCIA_IDNull = true; 
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.PaisResidenciaId_NombreCol];
                        if (funcionario.IsPAIS_RESIDENCIA_IDNull || funcionario.PAIS_RESIDENCIA_ID != dAux)
                            if (PaisesService.EstaActivo(dAux))
                                funcionario.PAIS_RESIDENCIA_ID = dAux;
                            else
                                throw new System.ArgumentException("El país de residencia seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Departamento1Id_NombreCol))
                {
                    if (campos[FuncionariosService.Departamento1Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsDEPARTAMENTO1_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Departamento1Id_NombreCol];
                        if (funcionario.IsDEPARTAMENTO1_IDNull || funcionario.DEPARTAMENTO1_ID != dAux)
                            if (DepartamentosService.EstaActivo(dAux))
                                funcionario.DEPARTAMENTO1_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Ciudad1Id_NombreCol))
                {
                    if (campos[FuncionariosService.Ciudad1Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsCIUDAD1_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Ciudad1Id_NombreCol];
                        if (funcionario.IsCIUDAD1_IDNull || funcionario.CIUDAD1_ID != dAux)
                            if (CiudadesService.EstaActivo(dAux))
                                funcionario.CIUDAD1_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad principal seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Barrio1Id_NombreCol))
                {
                    if (campos[FuncionariosService.Barrio1Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsBARRIO1_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Barrio1Id_NombreCol];
                        if (funcionario.IsBARRIO1_IDNull || funcionario.BARRIO1_ID != dAux)
                            if (BarriosService.EstaActivo(dAux))
                                funcionario.BARRIO1_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Departamento2Id_NombreCol))
                {
                    if (campos[FuncionariosService.Departamento2Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsDEPARTAMENTO2_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Departamento2Id_NombreCol];
                        if (funcionario.IsDEPARTAMENTO2_IDNull || funcionario.DEPARTAMENTO2_ID != dAux)
                            if (DepartamentosService.EstaActivo(dAux))
                                funcionario.DEPARTAMENTO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Ciudad2Id_NombreCol))
                {
                    if (campos[FuncionariosService.Ciudad2Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsCIUDAD2_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Ciudad2Id_NombreCol];
                        if (funcionario.IsCIUDAD2_IDNull || funcionario.CIUDAD2_ID != dAux)
                            if (CiudadesService.EstaActivo(dAux))
                                funcionario.CIUDAD2_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad secundaria seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.Barrio2Id_NombreCol))
                {
                    if (campos[FuncionariosService.Barrio2Id_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsBARRIO2_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.Barrio2Id_NombreCol];
                        if (funcionario.IsBARRIO2_IDNull || funcionario.BARRIO2_ID != dAux)
                            if (BarriosService.EstaActivo(dAux))
                                funcionario.BARRIO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                }

                if (campos.Contains(FuncionariosService.DepartamentoFamiliarContId_NombreCol))
                {
                    if (campos[FuncionariosService.DepartamentoFamiliarContId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.DepartamentoFamiliarContId_NombreCol];
                        if (funcionario.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull || funcionario.DEPARTAMENTO_FAMILIAR_CONT_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux)) funcionario.DEPARTAMENTO_FAMILIAR_CONT_ID = dAux;
                            else throw new System.ArgumentException("El departamento del contacto familiar seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                }

                if (campos.Contains(FuncionariosService.CiudadFamiliarContactoId_NombreCol))
                {
                    if (campos[FuncionariosService.CiudadFamiliarContactoId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsCIUDAD_FAMILIAR_CONTACTO_IDNull = true;                    
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.CiudadFamiliarContactoId_NombreCol];
                        if (funcionario.IsCIUDAD_FAMILIAR_CONTACTO_IDNull || funcionario.CIUDAD_FAMILIAR_CONTACTO_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux)) funcionario.CIUDAD_FAMILIAR_CONTACTO_ID = dAux;
                            else throw new System.ArgumentException("La ciudad del contacto familiar seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                }

                if (campos.Contains(FuncionariosService.BarrioFamiliarContactoId_NombreCol))
                {
                    if (campos[FuncionariosService.BarrioFamiliarContactoId_NombreCol].Equals(DBNull.Value))
                    {
                        funcionario.IsBARRIO_FAMILIAR_CONTACTO_IDNull = true;
                    }
                    else
                    {
                        dAux = (decimal)campos[FuncionariosService.BarrioFamiliarContactoId_NombreCol];
                        if (funcionario.IsBARRIO_FAMILIAR_CONTACTO_IDNull || funcionario.BARRIO_FAMILIAR_CONTACTO_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux)) funcionario.BARRIO_FAMILIAR_CONTACTO_ID = dAux;
                            else throw new System.ArgumentException("El barrio del contacto familiar seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                }

                sesion.Db.FUNCIONARIOSCollection.Update(funcionario);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, funcionario.ID, valorAnterior, funcionario.ToString(), sesion);
                //Actualizamos los datos de la persona
                ActualizarPersona(funcionario, sesion);
                usuario.SetUsuariosPorPersona(funcionario, sesion);
                return funcionario.ID;
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        if (exp.Message.IndexOf("UK_FUNCIONARIOS_COD_ENTIDAD") >= 0)
                            throw new System.ArgumentException("Ya Existe un Funcionario con el mismo Código.", exp);
                        else
                            throw new System.ArgumentException("Error de unicidad.", exp);
                    default:
                        throw;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion Modificar

        #region ActualizarDatosFuncionarios
        /// <summary>
        /// Actualizars the datos funcionarios.
        /// </summary>
        /// <param name="funcionario">The funcionario.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        private static void ActualizarDatosFuncionarios(ref FUNCIONARIOSRow funcionario, SessionService sesion)
        {
            try
            {
                String valorAnterior = "";
                PERSONASRow persona = new PERSONASRow();
                string clausula = PersonasService.Id_NombreCol + " = " + funcionario.PERSONA_ID;
                persona = sesion.Db.PERSONASCollection.GetRow(clausula);
                //Se comprueba de que exista la persona
                if (persona == null)
                    return;

                valorAnterior = funcionario.ToString();
                funcionario.PERSONA_ID = persona.ID;
                funcionario.ENTIDAD_ID = persona.ENTIDAD_ID;
                funcionario.RUC = persona.RUC;
                funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID = persona.TIPO_DOCUMENTO_IDENTIDAD_ID;
                funcionario.NUMERO_DOCUMENTO = persona.NUMERO_DOCUMENTO;
                funcionario.TRATAMIENTO_ID = persona.TRATAMIENTO_ID;
                funcionario.NOMBRE = persona.NOMBRE;
                funcionario.APELLIDO = persona.APELLIDO;
                funcionario.GENERO = persona.GENERO;
                funcionario.GRUPO_SANGUINEO = persona.GRUPO_SANGUINEO;
                funcionario.PROFESION_ID = persona.PROFESION_ID;
                funcionario.CALLE1 = persona.CALLE1;
                funcionario.CALLE2 = persona.CALLE2;
                funcionario.CODIGO_POSTAL1 = persona.CODIGO_POSTAL1;
                funcionario.CODIGO_POSTAL2 = persona.CODIGO_POSTAL2;
                funcionario.TELEFONO1 = persona.TELEFONO1;
                funcionario.TELEFONO2 = persona.TELEFONO2;
                funcionario.TELEFONO3 = persona.TELEFONO3;
                funcionario.TELEFONO4 = persona.TELEFONO4;
                funcionario.EMAIL1 = persona.EMAIL1;
                funcionario.EMAIL2 = persona.EMAIL2;
                funcionario.EMAIL3 = persona.EMAIL3;
                funcionario.ESTADO = persona.ESTADO;

                if (!persona.IsNACIMIENTONull)
                    funcionario.NACIMIENTO = persona.NACIMIENTO;

                if (!persona.IsPAIS_NACIONALIDAD_IDNull)
                    funcionario.PAIS_NACIONALIDAD_ID = persona.PAIS_NACIONALIDAD_ID;

                if (!persona.IsPAIS_RESIDENCIA_IDNull)
                    funcionario.PAIS_RESIDENCIA_ID = persona.PAIS_RESIDENCIA_ID;

                if (!persona.IsDEPARTAMENTO1_IDNull)
                    funcionario.DEPARTAMENTO1_ID = persona.DEPARTAMENTO1_ID;

                if (!persona.IsDEPARTAMENTO2_IDNull)
                    funcionario.DEPARTAMENTO2_ID = persona.DEPARTAMENTO2_ID;

                if (!persona.IsCIUDAD1_IDNull)
                    funcionario.CIUDAD1_ID = persona.CIUDAD1_ID;

                if (!persona.IsCIUDAD2_IDNull)
                    funcionario.CIUDAD2_ID = persona.CIUDAD2_ID;

                if (!persona.IsBARRIO1_IDNull)
                    funcionario.BARRIO1_ID = persona.BARRIO1_ID;

                if (!persona.IsBARRIO2_IDNull)
                    funcionario.BARRIO2_ID = persona.BARRIO2_ID;
            }

            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarDatosFuncionarios

        #region ActualizarPersona
        /// <summary>
        /// Actualizars the persona.
        /// </summary>
        /// <param name="funcionario">The funcionario.</param>
        /// <param name="sesion">The sesion.</param>
        private static void ActualizarPersona(FUNCIONARIOSRow funcionario, SessionService sesion)
        {
            try
            {
                String valorAnterior = "";
                PERSONASRow persona = new PERSONASRow();
                string clausula = PersonasService.Id_NombreCol + " = " + funcionario.PERSONA_ID;
                persona = sesion.Db.PERSONASCollection.GetRow(clausula);
                //Se comprueba de que exista la persona
                if (persona != null)
                {
                    valorAnterior = persona.ToString();
                    persona.ENTIDAD_ID = funcionario.ENTIDAD_ID;
                    persona.RUC = funcionario.RUC;
                    persona.TIPO_DOCUMENTO_IDENTIDAD_ID = funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID;
                    persona.NUMERO_DOCUMENTO = funcionario.NUMERO_DOCUMENTO;
                    persona.TRATAMIENTO_ID = funcionario.TRATAMIENTO_ID;
                    persona.NOMBRE = funcionario.NOMBRE;
                    persona.APELLIDO = funcionario.APELLIDO;
                    persona.GENERO = funcionario.GENERO;
                    persona.GRUPO_SANGUINEO = funcionario.GRUPO_SANGUINEO;
                    if (!funcionario.IsNACIMIENTONull)
                        persona.NACIMIENTO = funcionario.NACIMIENTO;

                    if (!funcionario.IsPAIS_NACIONALIDAD_IDNull)
                        persona.PAIS_NACIONALIDAD_ID = funcionario.PAIS_NACIONALIDAD_ID;

                    if (!funcionario.IsPAIS_RESIDENCIA_IDNull)
                        persona.PAIS_RESIDENCIA_ID = funcionario.PAIS_RESIDENCIA_ID;

                    persona.PROFESION_ID = funcionario.PROFESION_ID;

                    if (!funcionario.IsDEPARTAMENTO1_IDNull)
                        persona.DEPARTAMENTO1_ID = funcionario.DEPARTAMENTO1_ID;

                    if (!funcionario.IsDEPARTAMENTO2_IDNull)
                        persona.DEPARTAMENTO2_ID = funcionario.DEPARTAMENTO2_ID;

                    if (!funcionario.IsCIUDAD1_IDNull)
                        persona.CIUDAD1_ID = funcionario.CIUDAD1_ID;

                    if (!funcionario.IsCIUDAD2_IDNull)
                        persona.CIUDAD2_ID = funcionario.CIUDAD2_ID;

                    if (!funcionario.IsBARRIO1_IDNull)
                        persona.BARRIO1_ID = funcionario.BARRIO1_ID;

                    if (!funcionario.IsBARRIO2_IDNull)
                        persona.BARRIO2_ID = funcionario.BARRIO2_ID;

                    if(!funcionario.IsLATITUD1Null)
                        persona.LATITUD1 = funcionario.LATITUD1;
                    persona.IsLATITUD1Null = funcionario.IsLATITUD1Null;
                    if(!funcionario.IsLONGITUD1Null)
                        persona.LONGITUD1 = funcionario.LONGITUD1;
                    persona.IsLONGITUD1Null = funcionario.IsLONGITUD1Null;
                    if(!funcionario.IsLATITUD2Null)
                        persona.LATITUD2 = funcionario.LATITUD2;
                    persona.IsLATITUD2Null = funcionario.IsLATITUD2Null;
                    if(!funcionario.IsLONGITUD2Null)
                        persona.LONGITUD2 = funcionario.LONGITUD2;
                    persona.IsLONGITUD2Null = funcionario.IsLONGITUD2Null;

                    sesion.Db.PERSONASCollection.Update(persona);
                    LogCambiosService.LogDeRegistro(PersonasService.Nombre_Tabla, persona.ID, valorAnterior, persona.ToString(), sesion);
                }
            }

            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarPersona

        #region GuardarDatosLaborales
        private static void GuardarDatosLaborales(ref FUNCIONARIOSRow row, System.Collections.Hashtable campos) 
        {
            if (campos.Contains(SucursalId_NombreCol))
                row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());

            if (campos.Contains(TipoSalario_NombreCol))
                row.SALARIO_TIPO = int.Parse(campos[TipoSalario_NombreCol].ToString());

            if (campos.Contains(CobraSalarioMinimo_NombreCol))
                row.COBRA_SALARIO_MINIMO = campos[CobraSalarioMinimo_NombreCol].ToString();

            if (campos.Contains(Salario_NombreCol))
                row.SALARIO= decimal.Parse(campos[Salario_NombreCol].ToString());

            if (campos.Contains(CobraAnticipo_NombreCol))
                row.COBRA_ANTICIPO = campos[CobraAnticipo_NombreCol].ToString();

            if (campos.Contains(AnticipoMonto_NombreCol))
                row.MONTO_ANTICIPO = decimal.Parse(campos[AnticipoMonto_NombreCol].ToString());

            if (campos.Contains(CobraBonificacion_NombreCol))
                row.COBRA_BONIFICACION= campos[CobraBonificacion_NombreCol].ToString();

            if (campos.Contains(MontoBonificacion_NombreCol))
                row.MONTO_BONIFICACION = decimal.Parse(campos[MontoBonificacion_NombreCol].ToString());

            if(campos.Contains(SalarioComplementario_NombreCol))
                row.SALARIO_COMPLEMENTARIO = decimal.Parse(campos[SalarioComplementario_NombreCol].ToString());

            if (campos.Contains(SalarioExtra_NombreCol))
                row.SALARIO_EXTRA = decimal.Parse(campos[SalarioExtra_NombreCol].ToString());

            if (campos.Contains(MonedaId_NombreCol))
                row.MONEDA_ID= decimal.Parse(campos[MonedaId_NombreCol].ToString());

            if (campos.Contains(Ctacte_NombreCol))
                row.CTACTE = campos[Ctacte_NombreCol].ToString();

            if (campos.Contains(MarcacionesId_NombreCol))
                row.MARCACIONES_ID = decimal.Parse(campos[MarcacionesId_NombreCol].ToString());
        }
        #endregion GuardarDatosLaborales

        #region EsFuncionario
        public static bool Esfuncionario(decimal idpersona)
        {
            using (SessionService sesion = new SessionService())
            {
                    return sesion.Db.FUNCIONARIOSCollection.GetByPERSONA_IDAsDataTable(idpersona).Rows.Count > 0;
            }
        }
        #endregion EsFuncionario

        #region GetFuncionarioId
        public static decimal GetFuncionarioId(decimal idpersona)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    FUNCIONARIOSRow[] row = sesion.Db.FUNCIONARIOSCollection.GetByPERSONA_ID(idpersona);

                    if (row.Length == 1)
                    {
                        return row[0].ID;
                    }
                    else
                    {
                        return Definiciones.Error.Valor.EnteroPositivo;
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }

            }
        }
        #endregion GetFuncionarioId

        #region CrearFuncionario
        /// <summary>
        /// Crears the funcionario.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <param name="codigo">The codigo.</param>
        /// <param name="grupo_sanguineo">The grupo_sanguineo.</param>
        /// <param name="es_cobrador">if set to <c>true</c> [es_cobrador].</param>
        /// <param name="es_vendedor">if set to <c>true</c> [es_vendedor].</param>
        /// <param name="es_promotor">if set to <c>true</c> [es_promotor].</param>
        /// <param name="es_chofer">if set to <c>true</c> [es_chofer].</param>
        /// <param name="es_depositero">if set to <c>true</c> [es_depositero].</param>
        /// <param name="ingreso_aprobado">if set to <c>true</c> [ingreso_aprobado].</param>
        /// <param name="familiar_contacto_nombre">The familiar_contacto_nombre.</param>
        /// <param name="familiar_contacto_relacion">The familiar_contacto_relacion.</param>
        /// <param name="familiar_contacto_telefono">The familiar_contacto_telefono.</param>
        /// <param name="moneda_salario_id">The moneda_salario_id.</param>
        /// <param name="salario_minimo">if set to <c>true</c> [salario_minimo].</param>
        /// <param name="salario1">The salario1.</param>
        /// <param name="salario2">The salario2.</param>
        /// <param name="salario3">The salario3.</param>
        /// <param name="monto_bonificacion">The monto_bonificacion.</param>
        /// <param name="monto_anticipo_permitido">The monto_anticipo_permitido.</param>
        /// <param name="nro_cuenta_bancaria">The nro_cuenta_bancaria.</param>
        /// <param name="codigo_marcacion_id">The codigo_marcacion_id.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Persona no encontrada.</exception>
        public static decimal CrearFuncionario(decimal persona_id, decimal sucursal_id, string codigo, string grupo_sanguineo, bool es_cobrador, bool es_vendedor, bool es_promotor, bool es_chofer, bool es_depositero, bool es_cobrador_externo, bool ingreso_aprobado, decimal canal_venta_id, string familiar_contacto_nombre, string familiar_contacto_relacion, string familiar_contacto_telefono, decimal moneda_salario_id, bool salario_minimo, decimal salario1, decimal salario2, decimal salario3, decimal monto_bonificacion, decimal monto_anticipo_permitido, string nro_cuenta_bancaria, decimal codigo_marcacion_id)
        {
            try
            {
                decimal idCreado = Definiciones.Error.Valor.EnteroPositivo;
                Hashtable campos = new Hashtable();
                DataTable dtPersona = PersonasService.GetPersonasDataTable(PersonasService.Id_NombreCol + " = " + persona_id, string.Empty);

                if (dtPersona.Rows.Count <= 0)
                    throw new Exception("Persona no encontrada.");

                campos.Add(FuncionariosService.Persona_IdNombreCol, persona_id);
                campos.Add(FuncionariosService.TratamientoId_NombreCol, dtPersona.Rows[0][PersonasService.TratamientoId_NombreCol]);
                campos.Add(FuncionariosService.Nombre_NombreCol, dtPersona.Rows[0][PersonasService.Nombre_NombreCol]);
                campos.Add(FuncionariosService.Apellido_NombreCol, dtPersona.Rows[0][PersonasService.Apellido_NombreCol]);
                campos.Add(FuncionariosService.Apodo_NombreCol, string.Empty);
                campos.Add(FuncionariosService.TipoDocumentoId_NombreCol, dtPersona.Rows[0][PersonasService.TipoDocumentoIdentidadId_NombreCol]);
                campos.Add(FuncionariosService.NumeroDocumento_NombreCol, dtPersona.Rows[0][PersonasService.NumeroDocumento_NombreCol]);
                campos.Add(FuncionariosService.Ruc_NombreCol, dtPersona.Rows[0][PersonasService.Ruc_NombreCol]);
                campos.Add(FuncionariosService.ProfesionId_NombreCol, dtPersona.Rows[0][PersonasService.ProfesionId_NombreCol]);
                campos.Add(FuncionariosService.GrupoSanguineo_NombreCol, grupo_sanguineo);
                campos.Add(FuncionariosService.Nacimiento_NombreCol, dtPersona.Rows[0][PersonasService.Nacimiento_NombreCol]);
                campos.Add(FuncionariosService.PaisNacionalidadId_NombreCol, dtPersona.Rows[0][PersonasService.PaisNacionalidadId_NombreCol]);
                if (codigo.Length > 0) campos.Add(FuncionariosService.Codigo_NombreCol, codigo);
                campos.Add(FuncionariosService.Genero_NombreCol, dtPersona.Rows[0][PersonasService.Genero_NombreCol]);
                campos.Add(FuncionariosService.EsCobrador_NombreCol, es_cobrador ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.EsVendedor_NombreCol, es_vendedor ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.EsPromotor_NombreCol, es_promotor ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.EsChofer_NombreCol, es_chofer ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.Depositero_NombreCol, es_depositero ? Definiciones.SiNo.Si : Definiciones.SiNo.No);

                campos.Add(FuncionariosService.MotivoSalida_NombreCol, string.Empty);
                campos.Add(FuncionariosService.IngresoAprobado_NombreCol, ingreso_aprobado ? Definiciones.SiNo.Si : Definiciones.SiNo.No);

                campos.Add(FuncionariosService.EstadoDocumentacionId_NombreCol, Definiciones.EstadosDocumentacion.EnOrden);
                campos.Add(FuncionariosService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(FuncionariosService.PaisResidenciaId_NombreCol, dtPersona.Rows[0][PersonasService.PaisResidenciaId_NombreCol]);
                campos.Add(FuncionariosService.Departamento1Id_NombreCol, dtPersona.Rows[0][PersonasService.Departamento1Id_NombreCol]);
                campos.Add(FuncionariosService.Ciudad1Id_NombreCol, dtPersona.Rows[0][PersonasService.Ciudad1Id_NombreCol]);
                campos.Add(FuncionariosService.Barrio1Id_NombreCol, dtPersona.Rows[0][PersonasService.Barrio1Id_NombreCol]);
                campos.Add(FuncionariosService.Calle1_NombreCol, dtPersona.Rows[0][PersonasService.Calle1_NombreCol]);
                campos.Add(FuncionariosService.CodigoPostal1_NombreCol, dtPersona.Rows[0][PersonasService.CodigoPostal1_NombreCol]);
                campos.Add(FuncionariosService.Telefono1_NombreCol, dtPersona.Rows[0][PersonasService.Telefono1_NombreCol]);
                campos.Add(FuncionariosService.Telefono2_NombreCol, dtPersona.Rows[0][PersonasService.Telefono2_NombreCol]);
                campos.Add(FuncionariosService.Telefono3_NombreCol, dtPersona.Rows[0][PersonasService.Telefono3_NombreCol]);
                campos.Add(FuncionariosService.Telefono4_NombreCol, dtPersona.Rows[0][PersonasService.Telefono4_NombreCol]);
                campos.Add(FuncionariosService.Email1_NombreCol, dtPersona.Rows[0][PersonasService.Email1_NombreCol]);
                campos.Add(FuncionariosService.Email2_NombreCol, dtPersona.Rows[0][PersonasService.Email2_NombreCol]);
                campos.Add(FuncionariosService.Email3_NombreCol, dtPersona.Rows[0][PersonasService.Email3_NombreCol]);
                campos.Add(FuncionariosService.NombreFamiliarContacto_NombreCol, familiar_contacto_nombre);
                campos.Add(FuncionariosService.RelacionFamiliarContacto_NombreCol, familiar_contacto_relacion);
                campos.Add(FuncionariosService.TelefonoFamiliarContacto_NombreCol, familiar_contacto_telefono);
                campos.Add(FuncionariosService.SucursalId_NombreCol, sucursal_id);
                campos.Add(FuncionariosService.TipoSalario_NombreCol, Definiciones.TipoSalario.Mensual);
                campos.Add(FuncionariosService.CobraSalarioMinimo_NombreCol, salario_minimo ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.Salario_NombreCol, salario1);
                campos.Add(FuncionariosService.SalarioComplementario_NombreCol, salario2);
                campos.Add(FuncionariosService.SalarioExtra_NombreCol, salario3);
                campos.Add(FuncionariosService.CobraAnticipo_NombreCol, monto_anticipo_permitido > 0 ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.AnticipoMonto_NombreCol, monto_anticipo_permitido);
                campos.Add(FuncionariosService.CobraBonificacion_NombreCol, monto_bonificacion > 0 ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(FuncionariosService.MontoBonificacion_NombreCol, monto_bonificacion);
                campos.Add(FuncionariosService.MonedaId_NombreCol, moneda_salario_id);
                campos.Add(FuncionariosService.Ctacte_NombreCol, nro_cuenta_bancaria);
                campos.Add(FuncionariosService.MarcacionesId_NombreCol, codigo_marcacion_id);
                campos.Add(FuncionariosService.DescuentoBasico_NombreCol, Definiciones.SiNo.Si);
                campos.Add(FuncionariosService.DescuentoComplementario_NombreCol, Definiciones.SiNo.Si);
                campos.Add(FuncionariosService.DescuentoExtra_NombreCol, Definiciones.SiNo.Si);

                if (canal_venta_id != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(FuncionariosService.CanalVentaId_NombreCol, canal_venta_id);

                if (es_vendedor)
                {
                    decimal centroCostoId = SucursalesService.GetCentroCosto(sucursal_id);
                    if (centroCostoId != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(FuncionariosService.CentroCostoId_NombreCol, centroCostoId);
                }

                idCreado = FuncionariosService.Guardar(campos, true);
                return idCreado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion CrearFuncionario

        #region ModificarDatosFuncionario (webservice)
        public static bool ModificarDatosFuncionario(decimal funcionario_id, Hashtable campos)
        {
            bool exito = true;
            if (!Modificar(campos).Equals(funcionario_id))
                exito = false;

            return exito;
        }
        #endregion EditarFuncionario

        #region EstaEnHorarioLaboral
        /// <summary>
        /// Verificar si el acceso esta en horario laboral
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static bool EstaEnHorarioLaboral(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TimeSpan entradaAntesMargen = new TimeSpan();
                TimeSpan entrada = new TimeSpan();
                TimeSpan entradaDespuesMargen = new TimeSpan();
                TimeSpan salidaAntesMargen = new TimeSpan();
                TimeSpan salida = new TimeSpan();
                TimeSpan salidaDespuesMargen = new TimeSpan();
                TimeSpan horaAcceso;
                int calificacion = Definiciones.CalificacionMarcaciones.Indefinido;

                // Contiene todos los turnos que corresponden al id_funcionario en la hora actual
                DataTable dtTurnos = MarcacionesService.GetTurnos(funcionario_id, DateTime.Now);
                horaAcceso = DateTime.Now.TimeOfDay;

                //buscar a que turno corresponde y un estado
                foreach (DataRow row in dtTurnos.Rows)
                {
                    entradaAntesMargen = (DateTime.Parse(row[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).AddMinutes((-1) * double.Parse(row[HorariosService.VistaHorariosComplMinAntesEntrada_NombreCol].ToString()))).TimeOfDay;
                    entrada = DateTime.Parse(row[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).TimeOfDay;
                    entradaDespuesMargen = (DateTime.Parse(row[HorariosService.VistaHorariosComplHoraInicio_NombreCol].ToString()).AddMinutes(double.Parse(row[HorariosService.VistaHorariosComplMinDespuesEntrada_NombreCol].ToString()))).TimeOfDay;
                    salidaAntesMargen = (DateTime.Parse(row[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).AddMinutes((-1) * double.Parse(row[HorariosService.VistaHorariosComplMinAntesSalida_NombreCol].ToString()))).TimeOfDay;
                    salida = DateTime.Parse(row[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).TimeOfDay;
                    salidaDespuesMargen = (DateTime.Parse(row[HorariosService.VistaHorariosComplHoraFin_NombreCol].ToString()).AddMinutes(double.Parse(row[HorariosService.VistaHorariosComplMinDespuesSalida_NombreCol].ToString()))).TimeOfDay;

                    if (horaAcceso >= entradaAntesMargen && horaAcceso <= entrada) calificacion = Definiciones.CalificacionMarcaciones.ATiempo;
                    else if (horaAcceso >= entrada && horaAcceso <= entradaDespuesMargen) calificacion = Definiciones.CalificacionMarcaciones.EnMargen;
                    else if (horaAcceso >= entradaDespuesMargen && horaAcceso <= salidaAntesMargen) calificacion = Definiciones.CalificacionMarcaciones.ADestiempo;
                    else if (horaAcceso >= salidaAntesMargen && horaAcceso <= salida) calificacion = Definiciones.CalificacionMarcaciones.EnMargen;
                    else if (horaAcceso >= salida && horaAcceso <= salidaDespuesMargen) calificacion = Definiciones.CalificacionMarcaciones.ATiempo;

                    if (!calificacion.Equals(Definiciones.CalificacionMarcaciones.Indefinido)) break;
                }

                return !calificacion.Equals(Definiciones.CalificacionMarcaciones.Indefinido);
            }
        }
        #endregion EstaEnHorarioLaboral

        #region AplicarDescuentoBasico
        public static bool AplicarDescuentoBasico(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.DESCUENTOS_BASICO == Definiciones.SiNo.Si;
            }
        }
        #endregion AplicarDescuentoBasico

        #region AplicarDescuentoComplementario
        public static bool AplicarDescuentoComplementario(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.DESCUENTOS_COMPLEMENTARIO == Definiciones.SiNo.Si;
            }
        }
        #endregion AplicarDescuentoComplementario

        #region AplicarDescuentoExtra
        public static bool AplicarDescuentoExtra(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOSRow funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(Id_NombreCol + " = " + funcionario_id);
                return funcionario.DESCUENTOS_EXTRA == Definiciones.SiNo.Si;
            }
        }
        #endregion AplicarDescuentoExtra

        #region Accessors
        public static string Nombre_Tabla
        { get { return "FUNCIONARIOS"; } }
        public static string Nombre_Vista
        { get { return "FUNCIONARIOS_INFO_COMPLETA"; } }
        public static string Apellido_NombreCol
        { get { return FUNCIONARIOSCollection.APELLIDOColumnName; } }
        public static string Apodo_NombreCol
        { get { return FUNCIONARIOSCollection.APODOColumnName; } }
        public static string BarrioFamiliarContactoId_NombreCol
        { get { return FUNCIONARIOSCollection.BARRIO_FAMILIAR_CONTACTO_IDColumnName; } }
        public static string Barrio1Id_NombreCol
        { get { return FUNCIONARIOSCollection.BARRIO1_IDColumnName; } }
        public static string Barrio2Id_NombreCol
        { get { return FUNCIONARIOSCollection.BARRIO2_IDColumnName; } }
        public static string CalleFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.CALLE_FAMILIAR_CONTACTOColumnName; } }
        public static string Calle1_NombreCol
        { get { return FUNCIONARIOSCollection.CALLE1ColumnName; } }
        public static string Calle2_NombreCol
        { get { return FUNCIONARIOSCollection.CALLE2ColumnName; } }
        public static string CanalVentaId_NombreCol
        { get { return FUNCIONARIOSCollection.CANAL_VENTA_IDColumnName; } }
        public static string CentroCostoId_NombreCol
        { get { return FUNCIONARIOSCollection.CENTRO_COSTO_IDColumnName; } }
        public static string CiudadFamiliarContactoId_NombreCol
        { get { return FUNCIONARIOSCollection.CIUDAD_FAMILIAR_CONTACTO_IDColumnName; } }
        public static string Ciudad1Id_NombreCol
        { get { return FUNCIONARIOSCollection.CIUDAD1_IDColumnName; } }
        public static string Ciudad2Id_NombreCol
        { get { return FUNCIONARIOSCollection.CIUDAD2_IDColumnName; } }
        public static string CodPostFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.COD_POST_FAMILIAR_CONTACTOColumnName; } }
        public static string CodigoPostal1_NombreCol
        { get { return FUNCIONARIOSCollection.CODIGO_POSTAL1ColumnName; } }
        public static string CodigoPostal2_NombreCol
        { get { return FUNCIONARIOSCollection.CODIGO_POSTAL2ColumnName; } }
        public static string Codigo_NombreCol
        { get { return FUNCIONARIOSCollection.CODIGOColumnName; } }
        public static string DepartamentoFamiliarContId_NombreCol
        { get { return FUNCIONARIOSCollection.DEPARTAMENTO_FAMILIAR_CONT_IDColumnName; } }
        public static string Departamento1Id_NombreCol
        { get { return FUNCIONARIOSCollection.DEPARTAMENTO1_IDColumnName; } }
        public static string Departamento2Id_NombreCol
        { get { return FUNCIONARIOSCollection.DEPARTAMENTO2_IDColumnName; } }
        public static string DescuentoBasico_NombreCol
        { get { return FUNCIONARIOSCollection.DESCUENTOS_BASICOColumnName; } }
        public static string DescuentoComplementario_NombreCol
        { get { return FUNCIONARIOSCollection.DESCUENTOS_COMPLEMENTARIOColumnName; } }
        public static string DescuentoExtra_NombreCol
        { get { return FUNCIONARIOSCollection.DESCUENTOS_EXTRAColumnName; } }
        public static string Email1_NombreCol
        { get { return FUNCIONARIOSCollection.EMAIL1ColumnName; } }
        public static string Email2_NombreCol
        { get { return FUNCIONARIOSCollection.EMAIL2ColumnName; } }
        public static string Email3_NombreCol
        { get { return FUNCIONARIOSCollection.EMAIL3ColumnName; } }
        public static string EntidadId_NombreCol
        { get { return FUNCIONARIOSCollection.ENTIDAD_IDColumnName; } }
        public static string EsCobrador_NombreCol
        { get { return FUNCIONARIOSCollection.ES_COBRADORColumnName; } }
        public static string EsVendedor_NombreCol
        { get { return FUNCIONARIOSCollection.ES_VENDEDORColumnName; } }
        public static string EsPromotor_NombreCol
        { get { return FUNCIONARIOSCollection.ES_PROMOTORColumnName; } }
        public static string EstadoCivilId_NombreCol
        { get { return FUNCIONARIOSCollection.ESTADO_CIVIL_IDColumnName; } }
        public static string EstadoDocumentacionId_NombreCol
        { get { return FUNCIONARIOSCollection.ESTADO_DOCUMENTACION_IDColumnName; } }
        public static string Estado_NombreCol
        { get { return FUNCIONARIOSCollection.ESTADOColumnName; } }
        public static string FechaAprobacion_NombreCol
        { get { return FUNCIONARIOSCollection.FECHA_APROBACIONColumnName; } }
        public static string FechaContratacion_NombreCol
        { get { return FUNCIONARIOSCollection.FECHA_CONTRATACIONColumnName; } }
        public static string FechaSalida_NombreCol
        { get { return FUNCIONARIOSCollection.FECHA_SALIDAColumnName; } }
        public static string Genero_NombreCol
        { get { return FUNCIONARIOSCollection.GENEROColumnName; } }
        public static string GrupoSanguineo_NombreCol
        { get { return FUNCIONARIOSCollection.GRUPO_SANGUINEOColumnName; } }
        public static string Id_NombreCol
        { get { return FUNCIONARIOSCollection.IDColumnName; } }
        public static string IngresoAprobado_NombreCol
        { get { return FUNCIONARIOSCollection.INGRESO_APROBADOColumnName; } }
        public static string LatitudFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.LATITUD_FAMILIAR_CONTACTOColumnName; } }
        public static string Latitud1_NombreCol
        { get { return FUNCIONARIOSCollection.LATITUD1ColumnName; } }
        public static string Latitud2_NombreCol
        { get { return FUNCIONARIOSCollection.LATITUD2ColumnName; } }
        
        public static string LongitudFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.LONGITUD_FAMILIAR_CONTACTOColumnName; } }

        public static string CodigoTalonario_NombreCol
        { get { return FUNCIONARIOSCollection.CODIGO_TALONARIOColumnName; } }

        public static string Longitud1_NombreCol
        { get { return FUNCIONARIOSCollection.LONGITUD1ColumnName; } }
        public static string Longitud2_NombreCol
        { get { return FUNCIONARIOSCollection.LONGITUD2ColumnName; } }
        public static string MarcacionesId_NombreCol
        { get { return FUNCIONARIOSCollection.MARCACIONES_IDColumnName; } }
        public static string MotivoSalida_NombreCol
        { get { return FUNCIONARIOSCollection.MOTIVO_SALIDAColumnName; } }
        public static string Nacimiento_NombreCol
        { get { return FUNCIONARIOSCollection.NACIMIENTOColumnName; } }
        public static string NombreFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.NOMBRE_FAMILIAR_CONTACTOColumnName; } }
        public static string Nombre_NombreCol
        { get { return FUNCIONARIOSCollection.NOMBREColumnName; } }
        public static string NumeroDocumento_NombreCol
        { get { return FUNCIONARIOSCollection.NUMERO_DOCUMENTOColumnName; } }
        public static string PaisNacionalidadId_NombreCol
        { get { return FUNCIONARIOSCollection.PAIS_NACIONALIDAD_IDColumnName; } }
        public static string PaisResidenciaId_NombreCol
        { get { return FUNCIONARIOSCollection.PAIS_RESIDENCIA_IDColumnName; } }
        public static string ProfesionId_NombreCol
        { get { return FUNCIONARIOSCollection.PROFESION_IDColumnName; } }
        public static string RelacionFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.RELACION_FAMILIAR_CONTACTOColumnName; } }
        public static string Ruc_NombreCol
        { get { return FUNCIONARIOSCollection.RUCColumnName; } }
        public static string TelefonoFamiliarContacto_NombreCol
        { get { return FUNCIONARIOSCollection.TELEFONO_FAMILIAR_CONTACTOColumnName; } }
        public static string Telefono1_NombreCol
        { get { return FUNCIONARIOSCollection.TELEFONO1ColumnName; } }
        public static string Telefono2_NombreCol
        { get { return FUNCIONARIOSCollection.TELEFONO2ColumnName; } }
        public static string Telefono3_NombreCol
        { get { return FUNCIONARIOSCollection.TELEFONO3ColumnName; } }
        public static string Telefono4_NombreCol
        { get { return FUNCIONARIOSCollection.TELEFONO4ColumnName; } }
        public static string TipoDocumentoId_NombreCol
        { get { return FUNCIONARIOSCollection.TIPO_DOCUMENTO_IDENTIDAD_IDColumnName; } }
        public static string TratamientoId_NombreCol
        { get { return FUNCIONARIOSCollection.TRATAMIENTO_IDColumnName; } }
        public static string UsuarioAprobacionId_NombreCol
        { get { return FUNCIONARIOSCollection.USUARIO_APROBACION_IDColumnName; } }
        public static string EsChofer_NombreCol
        { get { return FUNCIONARIOSCollection.ES_CHOFERColumnName; } }
        public static string Depositero_NombreCol
        { get { return FUNCIONARIOSCollection.DEPOSITEROColumnName; } }
        public static string EsCobradorExterno_NombreCol
        { get { return FUNCIONARIOSCollection.ES_COBRADOR_EXTERNOColumnName; } }
       
        public static string Persona_IdNombreCol
        { get { return FUNCIONARIOSCollection.PERSONA_IDColumnName; } }
        public static string VistaEntidadNombre_NombreCol
        { get { return FUNCIONARIOS_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; } }
        public static string VistaNombreCompleto_NombreCol
        { get { return FUNCIONARIOS_INFO_COMPLETACollection.NOMBRE_COMPLETOColumnName; } }
       
        //agregados para el modulo de RRHH
        //en la tabla
        public static string SucursalId_NombreCol
        { get { return FUNCIONARIOSCollection.SUCURSAL_IDColumnName; } }
        public static string IngresoSeguro_NombreCol
        { get { return FUNCIONARIOSCollection.INGRESO_SEGUROColumnName; } }
        public static string TipoSalario_NombreCol
        { get { return FUNCIONARIOSCollection.SALARIO_TIPOColumnName; } }
        public static string CobraSalarioMinimo_NombreCol
        { get { return FUNCIONARIOSCollection.COBRA_SALARIO_MINIMOColumnName; } }
        public static string Salario_NombreCol
        { get { return FUNCIONARIOSCollection.SALARIOColumnName; } }
        public static string SalarioComplementario_NombreCol
        { get { return FUNCIONARIOSCollection.SALARIO_COMPLEMENTARIOColumnName; } }
        public static string SalarioExtra_NombreCol
        { get { return FUNCIONARIOSCollection.SALARIO_EXTRAColumnName; } }
        public static string CobraAnticipo_NombreCol
        { get { return FUNCIONARIOSCollection.COBRA_ANTICIPOColumnName; } }
        public static string AnticipoMonto_NombreCol
        { get { return FUNCIONARIOSCollection.MONTO_ANTICIPOColumnName; } }
        public static string CobraBonificacion_NombreCol
        { get { return FUNCIONARIOSCollection.COBRA_BONIFICACIONColumnName; } }
        public static string MontoBonificacion_NombreCol
        { get { return FUNCIONARIOSCollection.MONTO_BONIFICACIONColumnName; } }
        public static string MonedaId_NombreCol
        { get { return FUNCIONARIOSCollection.MONEDA_IDColumnName; } }
        public static string Ctacte_NombreCol
        { get { return FUNCIONARIOSCollection.CTACTEColumnName; } }
        
        //en la vista
        public static string VistaSucursalNombre_NombreCol
        { get { return FUNCIONARIOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; } }
        public static string VistaMonedaNombre_NombreCol
        { get { return FUNCIONARIOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; } }
        public static string VistaCanalVentaNombre_NombreCol
        { get { return FUNCIONARIOS_INFO_COMPLETACollection.CANAL_VENTA_NOMBREColumnName; } }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static FuncionariosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new FuncionariosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected FUNCIONARIOSRow row;
        protected FUNCIONARIOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Apellido { get { return ClaseCBABase.GetStringHelper(row.APELLIDO); } set { row.APELLIDO = value; } }
        public string Apodo { get { return ClaseCBABase.GetStringHelper(row.APODO); } set { row.APODO = value; } }
        public decimal? CanalVentaId { get { if (row.IsCANAL_VENTA_IDNull) return null; else return row.CANAL_VENTA_ID; } set { if (value.HasValue) row.CANAL_VENTA_ID = value.Value; else row.IsCANAL_VENTA_IDNull = true; } }
        public string Codigo { get { return ClaseCBABase.GetStringHelper(row.CODIGO); } set { row.CODIGO = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string Email1 { get { return ClaseCBABase.GetStringHelper(row.EMAIL1); } set { row.EMAIL1 = value; } }
        public string Email2 { get { return ClaseCBABase.GetStringHelper(row.EMAIL2); } set { row.EMAIL2 = value; } }
        public string Email3 { get { return ClaseCBABase.GetStringHelper(row.EMAIL3); } set { row.EMAIL3 = value; } }
        public string EsPromotor { get { return row.ES_PROMOTOR; } set { row.ES_PROMOTOR = value; } }
        public string esVendedor { get { return row.ES_VENDEDOR; } set { row.ES_VENDEDOR = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string NumeroDocumento { get { return ClaseCBABase.GetStringHelper(row.NUMERO_DOCUMENTO); } set { row.NUMERO_DOCUMENTO = value; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId);
                return this._persona;
            }
        }

        private CanalesVentaService _canalVenta;
        public CanalesVentaService CanalVenta
        {
            get
            {
                if (this._canalVenta == null)
                    this._canalVenta = new CanalesVentaService(this.CanalVentaId.Value);
                return this._canalVenta;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId.Value);
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.FUNCIONARIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FUNCIONARIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public FuncionariosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FuncionariosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FuncionariosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public FuncionariosService(EdiCBA.Funcionario edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = FuncionariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            #region persona
            if (!string.IsNullOrEmpty(edi.persona_uuid))
                this._persona = PersonasService.GetPorUUID(edi.persona_uuid, sesion);
            if (this._persona == null && edi.persona != null)
                this._persona = new PersonasService(edi.persona, almacenar_localmente, sesion);
            if (this._persona == null)
                throw new Exception("No se encontró el UUID " + edi.persona_uuid + " ni se definieron los datos del objeto.");

            if (!this.Persona.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Persona.Id.HasValue)
                this.PersonaId = this.Persona.Id.Value;
            #endregion persona

            this.Apellido = this.Persona.Nombre;
            this.Apodo = edi.apodo;
            this.Codigo = edi.codigo;
            this.Nombre = this.Persona.Nombre;
            this.SucursalId = null;
        }
        #endregion Constructores
		
		#region ResetearPropiedadesExtendidas
        private void ResetearPropiedadesExtendidas()
        {
            this._canalVenta = null;
            this._persona = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Funcionario()
            {
                apodo = this.Apodo,
                codigo = this.Codigo,
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = this.GetOrCreateUUID(sesion);
            }
            return e;
        }
        #endregion ToEDI
		#endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
