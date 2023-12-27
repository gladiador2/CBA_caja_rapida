// <fileinfo name="NUMEROSRow_Base.cs">
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
	/// The base class for <see cref="NUMEROSRow"/> that 
	/// represents a record in the <c>NUMEROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NUMEROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NUMEROSRow_Base
	{
		private decimal _codnumero;
		private string _descripcionnumero;

		/// <summary>
		/// Initializes a new instance of the <see cref="NUMEROSRow_Base"/> class.
		/// </summary>
		public NUMEROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NUMEROSRow_Base original)
		{
			if (this.CODNUMERO != original.CODNUMERO) return true;
			if (this.DESCRIPCIONNUMERO != original.DESCRIPCIONNUMERO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>CODNUMERO</c> column value.
		/// </summary>
		/// <value>The <c>CODNUMERO</c> column value.</value>
		public decimal CODNUMERO
		{
			get { return _codnumero; }
			set { _codnumero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCIONNUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCIONNUMERO</c> column value.</value>
		public string DESCRIPCIONNUMERO
		{
			get { return _descripcionnumero; }
			set { _descripcionnumero = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CODNUMERO=");
			dynStr.Append(CODNUMERO);
			dynStr.Append("@CBA@DESCRIPCIONNUMERO=");
			dynStr.Append(DESCRIPCIONNUMERO);
			return dynStr.ToString();
		}
	} // End of NUMEROSRow_Base class
} // End of namespace
