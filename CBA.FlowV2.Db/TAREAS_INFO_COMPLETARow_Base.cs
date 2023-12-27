// <fileinfo name="TAREAS_INFO_COMPLETARow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="TAREAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>TAREAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TAREAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TAREAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _tipo_tarea_id;
		private string _descripcion;
		private string _estado;
		private string _descripcion_tipo_tarea;

		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public TAREAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TAREAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_TAREA_ID != original.TIPO_TAREA_ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.DESCRIPCION_TIPO_TAREA != original.DESCRIPCION_TIPO_TAREA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TAREA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TAREA_ID</c> column value.</value>
		public decimal TIPO_TAREA_ID
		{
			get { return _tipo_tarea_id; }
			set { _tipo_tarea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_TIPO_TAREA</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION_TIPO_TAREA</c> column value.</value>
		public string DESCRIPCION_TIPO_TAREA
		{
			get { return _descripcion_tipo_tarea; }
			set { _descripcion_tipo_tarea = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TIPO_TAREA_ID=");
			dynStr.Append(TIPO_TAREA_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@DESCRIPCION_TIPO_TAREA=");
			dynStr.Append(DESCRIPCION_TIPO_TAREA);
			return dynStr.ToString();
		}
	} // End of TAREAS_INFO_COMPLETARow_Base class
} // End of namespace
