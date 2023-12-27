
using System;

using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace CBA.FlowV2.Services.Base
{
    public class ListViewUtil
    {
        public const int AjustarAnchoPorItem = -1;
        public const int AjustarAnchoPorCabecera = -2;

        #region GetIndiceDeColumna
        /// <summary>
        /// Gets the indice de columna.
        /// </summary>
        /// <param name="lista">The lista.</param>
        /// <param name="nombre">The nombre.</param>
        /// <returns></returns>
        public static int GetIndiceDeColumna(System.Windows.Forms.ListView lista, string nombre)
        {
            for (int i = 0; i < lista.Columns.Count; i++)
            {
                if (lista.Columns[i].Name.ToUpper() == nombre.ToUpper()) return i;
                if (lista.Columns[i].Text.ToUpper() == nombre.ToUpper()) return i;
            }

            return Definiciones.Error.Valor.IntPositivo;
        }
        #endregion GetIndiceDeColumna
        /*
        public static void ConfigurarListView(ListView lista, TablaInfo tabla)
        {
            ConfigurarListView(lista, tabla, false);
        }
        
        public static void ConfigurarListView(ListView lista, TablaInfo tabla, bool crear_columnas)
        {
            if (crear_columnas)
            {
                foreach (ColumnaInfo ci in tabla.Columnas)
                    lista.Columns.Add(ci.Nombre, (int)ci.Ancho, (HorizontalAlignment)ci.Alineacion);
            }

            #region Configuracion de columnas
            int auxInt = 0;
            foreach (ColumnHeader ch in lista.Columns)
            {
                ch.Visible = false;
                ch.Name = ch.Text;
            }
            int index = 0;
            foreach (ColumnaInfo ci in tabla.Columnas)
            {
                auxInt = ListViewUtil.GetIndiceDeColumna(lista, ci.Nombre);
                lista.Columns[auxInt].Visible = ci.Visible;
                lista.Columns[auxInt].Text = ci.Titulo;
                lista.Columns[auxInt].Width = (int)ci.Ancho;
                lista.Columns[auxInt].DisplayIndex = index++;
                lista.Columns[auxInt].TextAlign = (HorizontalAlignment)ci.Alineacion;
                if (ci.Es(TipoColumna.Control))
                    lista.Columns[auxInt].Type = ListViewColumnType.Control;
            }
            #endregion Configuracion de columnas
        }
        */
        #region Variables globales
        private System.Collections.Hashtable columnas;
        #endregion Variables globales

        #region GetDataTable
        public static DataTable GetDataTable(ListView lv)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < lv.Columns.Count; i++)
                dt.Columns.Add(lv.Columns[i].Name, typeof(string));

            foreach (ListViewItem lvi in lv.Items)
            {
                DataRow dr = dt.Rows.Add();
                for (int i = 0; i < lvi.SubItems.Count; i++)
                    dr[i] = lvi.SubItems[i].Text;
            }
            return dt;
        }
        #endregion GetDataTable

        #region Constructores
        public ListViewUtil()
        {
            columnas = null;
        }
        #endregion Constructores

        #region Inicializar
        public void Inicializar(System.Windows.Forms.ListView lv)
        {
            columnas = new System.Collections.Hashtable();

            //Se obtiene el indice de cada columna segun su nombre
            //y se cargan los datos al Hashtable columnas
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                columnas.Add(lv.Columns[i].Name.ToUpper(), GetIndiceDeColumna(lv, lv.Columns[i].Name));
            }
        }
        #endregion Inicializar
        /*
        #region ListViewFormato
        public void ListViewFormato(System.Windows.Forms.ListView lv, System.Windows.Forms.ListViewItemFormattingEventArgs e, string[] campos, string formato)
        {
            string[] formato_por_columna = new string[campos.Length];
            for (int i = 0; i < campos.Length; i++)
            {
                formato_por_columna[i] = formato;
            }

            ListViewFormato(lv, e, campos, formato_por_columna);
        }

        /// <summary>
        /// Lists the view formato.
        /// </summary>
        /// <param name="lv">The lv.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"/> instance containing the event data.</param>
        /// <param name="campos">The campos.</param>
        /// <param name="formato">The formato.</param>
        public void ListViewFormato(Gizmox.WebGUI.Forms.ListView lv, Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs e, string[] campos, string[] formato)
        {
            ListViewFormato(lv, e, campos, formato, true);
        }

        public void ListViewFormato(Gizmox.WebGUI.Forms.ListView lv, Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs e, string[] campos, string[] formato, bool alinearDerecha)
        {
            if (columnas == null) Inicializar(lv);

            decimal decimalAux;
            DateTime dateAux;

            for (int i = 0; i < campos.Length; i++)
            {
                //En algunos casos el array es mas
                //largo que la cantidad de campos indicada
                //por lo que se saltean los subindices vacios
                if (campos[i] == null || campos[i].Length <= 0) continue;

                if (e.SubItemIndex == (int)columnas[campos[i].ToUpper()])
                {
                    if (e.Value.Length > 0)
                    {
                        if (decimal.TryParse(e.Value, out decimalAux))
                            e.Value = decimalAux.ToString(formato[i]);
                        else if (DateTime.TryParse(e.Value, out dateAux))
                            e.Value = dateAux.ToString(formato[i]);
                    }
                    if (alinearDerecha)
                    {
                        lv.Columns[(int)columnas[campos[i].ToUpper()]].TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
                    }
                }

            }
        }
        #endregion ListViewFormato
        */
        #region myListViewColumnSorter
        public class DummyProvider : IFormatProvider
        {
            // Normally, GetFormat returns an object of the requested type
            // (usually itself) if it is able; otherwise, it returns Nothing. 
            public object GetFormat(Type argType)
            {
                // Here, GetFormat displays the name of argType, after removing 
                // the namespace information. GetFormat always returns null.
                string argStr = argType.ToString();
                if (argStr == "")
                    argStr = "Empty";
                argStr = argStr.Substring(argStr.LastIndexOf('.') + 1);

                Console.Write("{0,-20}", argStr);
                return null;
            }
        }

        public class myListViewColumnSorter : System.Collections.IComparer
        {
            public enum SortType : int
            {
                Text,
                Number,
                DateTime
            }

            private SortType m_typeToSort = SortType.Text; // default= text
            public SortType TypeToSort
            {
                get { return m_typeToSort; }
                set { m_typeToSort = value; }
            }

            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public myListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                DummyProvider provider = new DummyProvider();
                int compareResult = 0;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                if (m_typeToSort == SortType.Text)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                }
                else if (m_typeToSort == SortType.Number)
                {
                    try
                    {
                        string txt1 = listviewX.SubItems[ColumnToSort].Text;
                        if (txt1.Length <= 0)
                            txt1 = "0";

                        string txt2 = listviewY.SubItems[ColumnToSort].Text;
                        if (txt2.Length <= 0)
                            txt2 = "0";

                        if (Convert.ToDecimal(txt1) > Convert.ToDecimal(txt2))
                            compareResult = 1;
                        else if (Convert.ToDecimal(txt1) < Convert.ToDecimal(txt2))
                            compareResult = -1;
                        else
                            compareResult = 0;
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine(E.Message);
                    }
                }
                else if (m_typeToSort == SortType.DateTime)
                {
                    try
                    {
                        if (listviewX.SubItems[ColumnToSort].Text != "")
                        {
                            if (Convert.ToDateTime(listviewX.SubItems[ColumnToSort].Text, provider) > Convert.ToDateTime(listviewY.SubItems[ColumnToSort].Text, provider))
                            {
                                compareResult = 1;
                            }
                            else if (Convert.ToDateTime(listviewX.SubItems[ColumnToSort].Text, provider) < Convert.ToDateTime(listviewY.SubItems[ColumnToSort].Text, provider))
                            {
                                compareResult = -1;
                            }
                            else
                            {
                                compareResult = 0;
                            }
                        }
                        else
                        {
                            compareResult = 0;
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }

            #region IComparable Members

            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
        #endregion myListViewColumnSorter
    }
}
