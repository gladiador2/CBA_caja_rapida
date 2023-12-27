// <fileinfo name="VENDEDOR_CLIENTE_FAMILIARow_Base.cs">
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
	/// The base class for <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> that 
	/// represents a record in the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="VENDEDOR_CLIENTE_FAMILIARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VENDEDOR_CLIENTE_FAMILIARow_Base
	{
		private decimal _funcionario_id;
		private decimal _persona_id;
		private decimal _articulo_familia_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="VENDEDOR_CLIENTE_FAMILIARow_Base"/> class.
		/// </summary>
		public VENDEDOR_CLIENTE_FAMILIARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(VENDEDOR_CLIENTE_FAMILIARow_Base original)
		{
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get { return _articulo_familia_id; }
			set { _articulo_familia_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(ARTICULO_FAMILIA_ID);
			return dynStr.ToString();
		}
	} // End of VENDEDOR_CLIENTE_FAMILIARow_Base class
} // End of namespace
