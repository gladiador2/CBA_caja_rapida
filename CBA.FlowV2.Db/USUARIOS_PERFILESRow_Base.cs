// <fileinfo name="USUARIOS_PERFILESRow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_PERFILESRow"/> that 
	/// represents a record in the <c>USUARIOS_PERFILES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_PERFILESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_PERFILESRow_Base
	{
		private decimal _usuario_id;
		private decimal _perfil_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_PERFILESRow_Base"/> class.
		/// </summary>
		public USUARIOS_PERFILESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_PERFILESRow_Base original)
		{
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.PERFIL_ID != original.PERFIL_ID) return true;
			
			return false;
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
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public decimal PERFIL_ID
		{
			get { return _perfil_id; }
			set { _perfil_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(PERFIL_ID);
			return dynStr.ToString();
		}
	} // End of USUARIOS_PERFILESRow_Base class
} // End of namespace
