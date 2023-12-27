// <fileinfo name="USUARIOS_SUCURSALESRow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_SUCURSALESRow"/> that 
	/// represents a record in the <c>USUARIOS_SUCURSALES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_SUCURSALESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_SUCURSALESRow_Base
	{
		private decimal _usuario_id;
		private decimal _sucursal_id;
		private decimal _region_id;
		private bool _region_idNull = true;
		private decimal _id;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_SUCURSALESRow_Base"/> class.
		/// </summary>
		public USUARIOS_SUCURSALESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_SUCURSALESRow_Base original)
		{
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.ID != original.ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			return dynStr.ToString();
		}
	} // End of USUARIOS_SUCURSALESRow_Base class
} // End of namespace
