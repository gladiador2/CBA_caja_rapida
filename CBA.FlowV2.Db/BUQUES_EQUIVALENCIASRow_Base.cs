// <fileinfo name="BUQUES_EQUIVALENCIASRow_Base.cs">
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
	/// The base class for <see cref="BUQUES_EQUIVALENCIASRow"/> that 
	/// represents a record in the <c>BUQUES_EQUIVALENCIAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="BUQUES_EQUIVALENCIASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class BUQUES_EQUIVALENCIASRow_Base
	{
		private decimal _id;
		private decimal _buque_id;
		private decimal _linea_id;
		private string _equivalencia;

		/// <summary>
		/// Initializes a new instance of the <see cref="BUQUES_EQUIVALENCIASRow_Base"/> class.
		/// </summary>
		public BUQUES_EQUIVALENCIASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(BUQUES_EQUIVALENCIASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.BUQUE_ID != original.BUQUE_ID) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.EQUIVALENCIA != original.EQUIVALENCIA) return true;
			
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
		/// Gets or sets the <c>BUQUE_ID</c> column value.
		/// </summary>
		/// <value>The <c>BUQUE_ID</c> column value.</value>
		public decimal BUQUE_ID
		{
			get { return _buque_id; }
			set { _buque_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get { return _linea_id; }
			set { _linea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EQUIVALENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EQUIVALENCIA</c> column value.</value>
		public string EQUIVALENCIA
		{
			get { return _equivalencia; }
			set { _equivalencia = value; }
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
			dynStr.Append("@CBA@BUQUE_ID=");
			dynStr.Append(BUQUE_ID);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(LINEA_ID);
			dynStr.Append("@CBA@EQUIVALENCIA=");
			dynStr.Append(EQUIVALENCIA);
			return dynStr.ToString();
		}
	} // End of BUQUES_EQUIVALENCIASRow_Base class
} // End of namespace
