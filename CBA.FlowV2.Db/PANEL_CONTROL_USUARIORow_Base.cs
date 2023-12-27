// <fileinfo name="PANEL_CONTROL_USUARIORow_Base.cs">
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
	/// The base class for <see cref="PANEL_CONTROL_USUARIORow"/> that 
	/// represents a record in the <c>PANEL_CONTROL_USUARIO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PANEL_CONTROL_USUARIORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PANEL_CONTROL_USUARIORow_Base
	{
		private decimal _id;
		private decimal _panel_control_id;
		private decimal _usuario_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PANEL_CONTROL_USUARIORow_Base"/> class.
		/// </summary>
		public PANEL_CONTROL_USUARIORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PANEL_CONTROL_USUARIORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PANEL_CONTROL_ID != original.PANEL_CONTROL_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			
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
		/// Gets or sets the <c>PANEL_CONTROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>PANEL_CONTROL_ID</c> column value.</value>
		public decimal PANEL_CONTROL_ID
		{
			get { return _panel_control_id; }
			set { _panel_control_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
			dynStr.Append("@CBA@PANEL_CONTROL_ID=");
			dynStr.Append(PANEL_CONTROL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			return dynStr.ToString();
		}
	} // End of PANEL_CONTROL_USUARIORow_Base class
} // End of namespace
