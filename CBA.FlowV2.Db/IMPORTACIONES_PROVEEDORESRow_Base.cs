// <fileinfo name="IMPORTACIONES_PROVEEDORESRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_PROVEEDORESRow"/> that 
	/// represents a record in the <c>IMPORTACIONES_PROVEEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACIONES_PROVEEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_PROVEEDORESRow_Base
	{
		private decimal _importacion_id;
		private decimal _proveedor_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_PROVEEDORESRow_Base"/> class.
		/// </summary>
		public IMPORTACIONES_PROVEEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACIONES_PROVEEDORESRow_Base original)
		{
			if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get { return _importacion_id; }
			set { _importacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IMPORTACION_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			return dynStr.ToString();
		}
	} // End of IMPORTACIONES_PROVEEDORESRow_Base class
} // End of namespace
