// <fileinfo name="TAREAS_PROGRAMADAS_RESULTADOSRow_Base.cs">
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
	/// The base class for <see cref="TAREAS_PROGRAMADAS_RESULTADOSRow"/> that 
	/// represents a record in the <c>TAREAS_PROGRAMADAS_RESULTADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TAREAS_PROGRAMADAS_RESULTADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TAREAS_PROGRAMADAS_RESULTADOSRow_Base
	{
		private decimal _id;
		private decimal _tarea_programada_id;
		private System.DateTime _fecha;
		private string _exito;
		private string _mensaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_PROGRAMADAS_RESULTADOSRow_Base"/> class.
		/// </summary>
		public TAREAS_PROGRAMADAS_RESULTADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TAREAS_PROGRAMADAS_RESULTADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TAREA_PROGRAMADA_ID != original.TAREA_PROGRAMADA_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.EXITO != original.EXITO) return true;
			if (this.MENSAJE != original.MENSAJE) return true;
			
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
		/// Gets or sets the <c>TAREA_PROGRAMADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TAREA_PROGRAMADA_ID</c> column value.</value>
		public decimal TAREA_PROGRAMADA_ID
		{
			get { return _tarea_programada_id; }
			set { _tarea_programada_id = value; }
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
		/// Gets or sets the <c>EXITO</c> column value.
		/// </summary>
		/// <value>The <c>EXITO</c> column value.</value>
		public string EXITO
		{
			get { return _exito; }
			set { _exito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MENSAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MENSAJE</c> column value.</value>
		public string MENSAJE
		{
			get { return _mensaje; }
			set { _mensaje = value; }
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
			dynStr.Append("@CBA@TAREA_PROGRAMADA_ID=");
			dynStr.Append(TAREA_PROGRAMADA_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@EXITO=");
			dynStr.Append(EXITO);
			dynStr.Append("@CBA@MENSAJE=");
			dynStr.Append(MENSAJE);
			return dynStr.ToString();
		}
	} // End of TAREAS_PROGRAMADAS_RESULTADOSRow_Base class
} // End of namespace
