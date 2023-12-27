// <fileinfo name="PROMOTORES_CLIENTESRow_Base.cs">
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
	/// The base class for <see cref="PROMOTORES_CLIENTESRow"/> that 
	/// represents a record in the <c>PROMOTORES_CLIENTES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PROMOTORES_CLIENTESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROMOTORES_CLIENTESRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private decimal _persona_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROMOTORES_CLIENTESRow_Base"/> class.
		/// </summary>
		public PROMOTORES_CLIENTESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PROMOTORES_CLIENTESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of PROMOTORES_CLIENTESRow_Base class
} // End of namespace
