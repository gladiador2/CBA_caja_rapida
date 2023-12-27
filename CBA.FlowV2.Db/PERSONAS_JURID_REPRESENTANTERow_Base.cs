// <fileinfo name="PERSONAS_JURID_REPRESENTANTERow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_JURID_REPRESENTANTERow"/> that 
	/// represents a record in the <c>PERSONAS_JURID_REPRESENTANTE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_JURID_REPRESENTANTERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_JURID_REPRESENTANTERow_Base
	{
		private decimal _persona_id;
		private decimal _persona_id_representante;
		private decimal _id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_JURID_REPRESENTANTERow_Base"/> class.
		/// </summary>
		public PERSONAS_JURID_REPRESENTANTERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_JURID_REPRESENTANTERow_Base original)
		{
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_ID_REPRESENTANTE != original.PERSONA_ID_REPRESENTANTE) return true;
			if (this.ID != original.ID) return true;
			
			return false;
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
		/// Gets or sets the <c>PERSONA_ID_REPRESENTANTE</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID_REPRESENTANTE</c> column value.</value>
		public decimal PERSONA_ID_REPRESENTANTE
		{
			get { return _persona_id_representante; }
			set { _persona_id_representante = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_ID_REPRESENTANTE=");
			dynStr.Append(PERSONA_ID_REPRESENTANTE);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			return dynStr.ToString();
		}
	} // End of PERSONAS_JURID_REPRESENTANTERow_Base class
} // End of namespace
