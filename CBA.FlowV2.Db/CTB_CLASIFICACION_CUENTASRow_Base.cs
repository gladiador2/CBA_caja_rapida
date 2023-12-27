// <fileinfo name="CTB_CLASIFICACION_CUENTASRow_Base.cs">
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
	/// The base class for <see cref="CTB_CLASIFICACION_CUENTASRow"/> that 
	/// represents a record in the <c>CTB_CLASIFICACION_CUENTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_CLASIFICACION_CUENTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CLASIFICACION_CUENTASRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _estado_resultados;
		private decimal _signo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CLASIFICACION_CUENTASRow_Base"/> class.
		/// </summary>
		public CTB_CLASIFICACION_CUENTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_CLASIFICACION_CUENTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ESTADO_RESULTADOS != original.ESTADO_RESULTADOS) return true;
			if (this.SIGNO != original.SIGNO) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_RESULTADOS</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_RESULTADOS</c> column value.</value>
		public string ESTADO_RESULTADOS
		{
			get { return _estado_resultados; }
			set { _estado_resultados = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SIGNO</c> column value.
		/// </summary>
		/// <value>The <c>SIGNO</c> column value.</value>
		public decimal SIGNO
		{
			get { return _signo; }
			set { _signo = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ESTADO_RESULTADOS=");
			dynStr.Append(ESTADO_RESULTADOS);
			dynStr.Append("@CBA@SIGNO=");
			dynStr.Append(SIGNO);
			return dynStr.ToString();
		}
	} // End of CTB_CLASIFICACION_CUENTASRow_Base class
} // End of namespace
