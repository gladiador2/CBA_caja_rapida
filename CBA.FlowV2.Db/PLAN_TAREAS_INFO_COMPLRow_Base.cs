// <fileinfo name="PLAN_TAREAS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLAN_TAREAS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PLAN_TAREAS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLAN_TAREAS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLAN_TAREAS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _tarea_id;
		private string _tiene_frecuencia;
		private decimal _frecuencia_dias;
		private bool _frecuencia_diasNull = true;
		private string _todas_secciones;
		private string _todas_personas;
		private string _estado;
		private System.DateTime _fecha_inicio;
		private string _descripcion_tarea;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLAN_TAREAS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PLAN_TAREAS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLAN_TAREAS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TAREA_ID != original.TAREA_ID) return true;
			if (this.TIENE_FRECUENCIA != original.TIENE_FRECUENCIA) return true;
			if (this.IsFRECUENCIA_DIASNull != original.IsFRECUENCIA_DIASNull) return true;
			if (!this.IsFRECUENCIA_DIASNull && !original.IsFRECUENCIA_DIASNull)
				if (this.FRECUENCIA_DIAS != original.FRECUENCIA_DIAS) return true;
			if (this.TODAS_SECCIONES != original.TODAS_SECCIONES) return true;
			if (this.TODAS_PERSONAS != original.TODAS_PERSONAS) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.DESCRIPCION_TAREA != original.DESCRIPCION_TAREA) return true;
			
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
		/// Gets or sets the <c>TAREA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TAREA_ID</c> column value.</value>
		public decimal TAREA_ID
		{
			get { return _tarea_id; }
			set { _tarea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIENE_FRECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>TIENE_FRECUENCIA</c> column value.</value>
		public string TIENE_FRECUENCIA
		{
			get { return _tiene_frecuencia; }
			set { _tiene_frecuencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FRECUENCIA_DIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FRECUENCIA_DIAS</c> column value.</value>
		public decimal FRECUENCIA_DIAS
		{
			get
			{
				if(IsFRECUENCIA_DIASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _frecuencia_dias;
			}
			set
			{
				_frecuencia_diasNull = false;
				_frecuencia_dias = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FRECUENCIA_DIAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFRECUENCIA_DIASNull
		{
			get { return _frecuencia_diasNull; }
			set { _frecuencia_diasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TODAS_SECCIONES</c> column value.
		/// </summary>
		/// <value>The <c>TODAS_SECCIONES</c> column value.</value>
		public string TODAS_SECCIONES
		{
			get { return _todas_secciones; }
			set { _todas_secciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TODAS_PERSONAS</c> column value.
		/// </summary>
		/// <value>The <c>TODAS_PERSONAS</c> column value.</value>
		public string TODAS_PERSONAS
		{
			get { return _todas_personas; }
			set { _todas_personas = value; }
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
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_TAREA</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION_TAREA</c> column value.</value>
		public string DESCRIPCION_TAREA
		{
			get { return _descripcion_tarea; }
			set { _descripcion_tarea = value; }
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
			dynStr.Append("@CBA@TAREA_ID=");
			dynStr.Append(TAREA_ID);
			dynStr.Append("@CBA@TIENE_FRECUENCIA=");
			dynStr.Append(TIENE_FRECUENCIA);
			dynStr.Append("@CBA@FRECUENCIA_DIAS=");
			dynStr.Append(IsFRECUENCIA_DIASNull ? (object)"<NULL>" : FRECUENCIA_DIAS);
			dynStr.Append("@CBA@TODAS_SECCIONES=");
			dynStr.Append(TODAS_SECCIONES);
			dynStr.Append("@CBA@TODAS_PERSONAS=");
			dynStr.Append(TODAS_PERSONAS);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@DESCRIPCION_TAREA=");
			dynStr.Append(DESCRIPCION_TAREA);
			return dynStr.ToString();
		}
	} // End of PLAN_TAREAS_INFO_COMPLRow_Base class
} // End of namespace
