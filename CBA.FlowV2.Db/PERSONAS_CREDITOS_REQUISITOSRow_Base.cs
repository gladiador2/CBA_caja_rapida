// <fileinfo name="PERSONAS_CREDITOS_REQUISITOSRow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_CREDITOS_REQUISITOSRow"/> that 
	/// represents a record in the <c>PERSONAS_CREDITOS_REQUISITOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_CREDITOS_REQUISITOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_CREDITOS_REQUISITOSRow_Base
	{
		private decimal _pers_niveles_credito_det_id;
		private decimal _persona_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_CREDITOS_REQUISITOSRow_Base"/> class.
		/// </summary>
		public PERSONAS_CREDITOS_REQUISITOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_CREDITOS_REQUISITOSRow_Base original)
		{
			if (this.PERS_NIVELES_CREDITO_DET_ID != original.PERS_NIVELES_CREDITO_DET_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PERS_NIVELES_CREDITO_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERS_NIVELES_CREDITO_DET_ID</c> column value.</value>
		public decimal PERS_NIVELES_CREDITO_DET_ID
		{
			get { return _pers_niveles_credito_det_id; }
			set { _pers_niveles_credito_det_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERS_NIVELES_CREDITO_DET_ID=");
			dynStr.Append(PERS_NIVELES_CREDITO_DET_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of PERSONAS_CREDITOS_REQUISITOSRow_Base class
} // End of namespace
