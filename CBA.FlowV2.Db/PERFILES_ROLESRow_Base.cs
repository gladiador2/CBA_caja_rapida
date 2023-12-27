// <fileinfo name="PERFILES_ROLESRow_Base.cs">
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
	/// The base class for <see cref="PERFILES_ROLESRow"/> that 
	/// represents a record in the <c>PERFILES_ROLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERFILES_ROLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERFILES_ROLESRow_Base
	{
		private decimal _perfil_id;
		private decimal _rol_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERFILES_ROLESRow_Base"/> class.
		/// </summary>
		public PERFILES_ROLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERFILES_ROLESRow_Base original)
		{
			if (this.PERFIL_ID != original.PERFIL_ID) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public decimal PERFIL_ID
		{
			get { return _perfil_id; }
			set { _perfil_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(PERFIL_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			return dynStr.ToString();
		}
	} // End of PERFILES_ROLESRow_Base class
} // End of namespace
