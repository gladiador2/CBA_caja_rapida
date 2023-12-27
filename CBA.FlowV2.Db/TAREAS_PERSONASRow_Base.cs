// <fileinfo name="TAREAS_PERSONASRow_Base.cs">
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
	/// The base class for <see cref="TAREAS_PERSONASRow"/> that 
	/// represents a record in the <c>TAREAS_PERSONAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TAREAS_PERSONASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TAREAS_PERSONASRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _seccion_id;
		private bool _seccion_idNull = true;
		private decimal _tarea_id;
		private string _frecuencia;
		private System.DateTime _fecha;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_PERSONASRow_Base"/> class.
		/// </summary>
		public TAREAS_PERSONASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TAREAS_PERSONASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsSECCION_IDNull != original.IsSECCION_IDNull) return true;
			if (!this.IsSECCION_IDNull && !original.IsSECCION_IDNull)
				if (this.SECCION_ID != original.SECCION_ID) return true;
			if (this.TAREA_ID != original.TAREA_ID) return true;
			if (this.FRECUENCIA != original.FRECUENCIA) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SECCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SECCION_ID</c> column value.</value>
		public decimal SECCION_ID
		{
			get
			{
				if(IsSECCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _seccion_id;
			}
			set
			{
				_seccion_idNull = false;
				_seccion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SECCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSECCION_IDNull
		{
			get { return _seccion_idNull; }
			set { _seccion_idNull = value; }
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
		/// Gets or sets the <c>FRECUENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FRECUENCIA</c> column value.</value>
		public string FRECUENCIA
		{
			get { return _frecuencia; }
			set { _frecuencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@SECCION_ID=");
			dynStr.Append(IsSECCION_IDNull ? (object)"<NULL>" : SECCION_ID);
			dynStr.Append("@CBA@TAREA_ID=");
			dynStr.Append(TAREA_ID);
			dynStr.Append("@CBA@FRECUENCIA=");
			dynStr.Append(FRECUENCIA);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of TAREAS_PERSONASRow_Base class
} // End of namespace
