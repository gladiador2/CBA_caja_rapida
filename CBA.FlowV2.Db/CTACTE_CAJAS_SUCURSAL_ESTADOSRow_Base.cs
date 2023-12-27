// <fileinfo name="CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_SUCURSAL_ESTADOSRow"/> that 
	/// represents a record in the <c>CTACTE_CAJAS_SUCURSAL_ESTADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJAS_SUCURSAL_ESTADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base
	{
		private string _nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base original)
		{
			if (this.NOMBRE != original.NOMBRE) return true;
			
			return false;
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJAS_SUCURSAL_ESTADOSRow_Base class
} // End of namespace
