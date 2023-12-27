using System.Linq.Expressions;
using System;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
namespace CBA.FlowV2.Services.Base
{
    public abstract class ClaseCBABase
    {
        #region GetStringHelper
        public static string GetStringHelper(object o)
        {
            if (o == null || o == DBNull.Value)
                return string.Empty;
            else
                return (string)o;
        }
        #endregion GetStringHelper

        #region ExposeProperty
        /*
         Metodo obtenido de http://stackoverflow.com/questions/2820660/get-name-of-property-as-a-string
         */
        public static string ExposeProperty<T>(Expression<Func<T>> property)
        {
            var expression = GetMemberInfo(property);
            return expression.Member.Name;
        }
        #endregion ExposeProperty

        #region GetMemberInfo
        /*
         Metodo obtenido de http://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
         */
        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }
        #endregion GetMemberInfo

        #region clase Filtro
        public class Filtro
        {
            #region Propiedades
            public static string DataTable_ColumnaNombre = "__NOMBRE__";
            public static string DataTable_ColumnaValor = "__VALOR__";

            public string Columna = string.Empty;
            public string Comparacion = "="; //Ejemplo: < <= > >= = <>
            public bool Exacto = true;
            public string Nombre = string.Empty; //Descripcion para mostrar al usuario
            public bool OrderBy = false;
            public bool Resumir = false;
            public object Valor = string.Empty;
            #endregion Propiedades

            #region GetDataTable
            public static System.Data.DataTable GetDataTable(Filtro[] filtros)
            {
                return GetDataTable<Filtro>(filtros);
            }
            public static System.Data.DataTable GetDataTable<T>(T[] filtros) where T : Filtro
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add(DataTable_ColumnaNombre, typeof(string));
                dt.Columns.Add(DataTable_ColumnaValor, typeof(T));
                foreach (T f in filtros)
                    dt.Rows.Add(f.Nombre, f);

                return dt;
            }
            #endregion GetDataTable

            #region CloneObject
            public static List<Filtro> CloneObject(List<Filtro> lista)
            {
                if (lista == null) return null;
                System.Reflection.MethodInfo inst = lista.GetType().GetMethod("MemberwiseClone",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (inst != null)
                    return (List<Filtro>)inst.Invoke(lista, null);
                else
                    return null;
            }
            #endregion CloneObject

            #region ContieneFiltro
            public static bool ContieneFiltro(string columna, List<Filtro> lista)
            {
                return GetFiltro(columna, lista) == null;
            }
            #endregion ContieneFiltro

            #region GetFiltro
            public static Filtro GetFiltro(string columna, List<Filtro> lista)
            {
                //Retornar el filtro que coincide con la columna y que no es de ordenamiento
                return Array.Find(lista.ToArray(), delegate(Filtro filtro) { return filtro.Columna == columna && !filtro.OrderBy; });
            }

            public static Filtro[] GetFiltros(string columna, List<Filtro> lista)
            {
                //Retornar el filtro que coincide con la columna y que no es de ordenamiento
                return Array.FindAll(lista.ToArray(), delegate(Filtro filtro) { return filtro.Columna == columna && !filtro.OrderBy; });
            }
            #endregion GetFiltro

            public static Filtro[] FiltrosDisponibles { get { return new Filtro[0]; } }
            public virtual string[] ComparacionesDisponibles() { return new string[0]; }
            public override string ToString() { return string.Empty; }
        }
        #endregion clase Filtro

        #region Sesion
        protected SessionService sesion;
        public void IniciarUsingSesion(SessionService sesion)
        {
            if (this.sesion != null)
                throw new Exception("Ya estaba iniciado");
            this.sesion = sesion;
        }

        public void FinalizarUsingSesion()
        {
            if (this.sesion == null)
                throw new Exception("No estaba iniciado");
            this.sesion = null;
        }
        #endregion Sesion
    }

    public abstract class ClaseCBA<T> : ClaseCBABase where T : new()
    {
        #region Get
        public TBuscado Get<TBuscado>(decimal id) where TBuscado : ClaseCBABase
        {
            TBuscado objeto;

            //Instanciar usando una nueva sesion o reutilizando la del objeto
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    this.IniciarUsingSesion(sesion);
                    objeto = (TBuscado)Activator.CreateInstance(typeof(TBuscado), id, this.sesion);
                    this.FinalizarUsingSesion();
                }
            }
            else
            {
                objeto = (TBuscado)Activator.CreateInstance(typeof(TBuscado), id, this.sesion);
            }

            return objeto;
        }

        public TBuscado GetPrimero<TBuscado>(List<Filtro> filtro) where TBuscado : ClaseCBABase
        {
            return GetPrimero<TBuscado>(filtro.ToArray());
        }
        
        public TBuscado GetPrimero<TBuscado>(Filtro filtro) where TBuscado : ClaseCBABase
        {
            return GetPrimero<TBuscado>(new Filtro[] { filtro });
        }

        public TBuscado GetPrimero<TBuscado>(Filtro[] filtros) where TBuscado : ClaseCBABase
        {
            TBuscado[] objetos = GetFiltrado<TBuscado>(filtros);
            if (objetos.Length > 0)
                return objetos[0];
            else
                return default(TBuscado);
        }

        public TBuscado[] GetTodos<TBuscado>() where TBuscado : ClaseCBABase
        {
            return GetFiltrado<TBuscado>(new Filtro[] {});
        }

        public TBuscado[] GetFiltrado<TBuscado>(Filtro filtro) where TBuscado : ClaseCBABase
        {
            return GetFiltrado<TBuscado>(new Filtro[] { filtro });
        }

        public TBuscado[] GetFiltrado<TBuscado>(List<Filtro> filtro) where TBuscado : ClaseCBABase
        {
            return GetFiltrado<TBuscado>(filtro.ToArray());
        }

        public TBuscado[] GetFiltrado<TBuscado>(Filtro[] filtros) where TBuscado : ClaseCBABase
        {
            TBuscado[] objetos;

            //Instanciar usando una nueva sesion o reutilizando la del objeto
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    this.IniciarUsingSesion(sesion);
                    TBuscado claseBuscada = Activator.CreateInstance<TBuscado>();
                    claseBuscada.IniciarUsingSesion(this.sesion);
                    MethodInfo methodInfo = claseBuscada.GetType().GetMethod("Buscar", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(Filtro[]) }, null);
                    objetos = (TBuscado[])methodInfo.Invoke(claseBuscada, new object[] { filtros });
                    claseBuscada.FinalizarUsingSesion();
                    this.FinalizarUsingSesion();
                }
            }
            else
            {
                TBuscado claseBuscada = Activator.CreateInstance<TBuscado>();
                claseBuscada.IniciarUsingSesion(this.sesion);
                MethodInfo methodInfo = claseBuscada.GetType().GetMethod("Buscar", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(Filtro[]) }, null);
                objetos = (TBuscado[])methodInfo.Invoke(claseBuscada, new object[] { filtros });
                claseBuscada.FinalizarUsingSesion();
            }

            return objetos;
        }
        #endregion Get

        #region Guardar
        public decimal Guardar()
        {
            //Instanciar usando una nueva sesion o reutilizando la del objeto
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    try
                    {
                        sesion.BeginTransaction();
                        this.ResetearPropiedadesExtendidas();
                        this.IniciarUsingSesion(sesion);
                        decimal id = GuardarPrivado(this.sesion);
                        this.FinalizarUsingSesion();
                        sesion.CommitTransaction();
                        return id;
                    }
                    catch
                    {
                        this.FinalizarUsingSesion();
                        sesion.RollbackTransaction();
                        throw;
                    }
                }
            }
            else
            {
                this.ResetearPropiedadesExtendidas();
                return GuardarPrivado(this.sesion);
            }
        }
        #endregion Guardar

        #region Validar
        public void Validar()
        {
            //Instanciar usando una nueva sesion o reutilizando la del objeto
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    try
                    {
                        sesion.BeginTransaction();
                        this.IniciarUsingSesion(sesion);
                        ValidarPrivado(this.sesion);
                        this.FinalizarUsingSesion();
                        sesion.CommitTransaction();
                    }
                    catch
                    {
                        this.FinalizarUsingSesion();
                        sesion.RollbackTransaction();
                        throw;
                    }
                }
            }
            else
            {
                ValidarPrivado(this.sesion);
            }
        }
        #endregion Validar

        #region Instanciar
        public static T Instancia { get { return Activator.CreateInstance<T>(); } }
        #endregion Instanciar

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI()
        {
            using (SessionService sesion = new SessionService())
            {
                return this.ToEDI(0, sesion);
            }
        }
        #endregion ToEDI

        #region Metodos que deben ser implementados por las clases que heredan
        protected abstract decimal GuardarPrivado(SessionService sesion);
        protected abstract void ValidarPrivado(SessionService sesion);
        protected abstract T[] Buscar(ClaseCBABase.Filtro[] filtros);
        public abstract CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion);
        public abstract CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion);
        
        //Cada clase que hereda debe implementar el metodo poniendo a null las propiedades extendidas
        //de solo lectura que pueden cambiar y dependen de la sesion (como Casos)
        public abstract void ResetearPropiedadesExtendidas();
        #endregion Metodos que deben ser implementados por las clases que heredan
    }
}
