// <fileinfo name="DESCUENTO_DOC_CLI_DET_VENCIMRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOC_CLI_DET_VENCIMRow"/> that 
	/// represents a record in the <c>DESCUENTO_DOC_CLI_DET_VENCIM</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTO_DOC_CLI_DET_VENCIMRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOC_CLI_DET_VENCIMRow_Base
	{
		private decimal _id;
		private decimal _descuento_documento_det_id;
		private System.DateTime _fecha_vencimiento;
		private decimal _monto;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOC_CLI_DET_VENCIMRow_Base"/> class.
		/// </summary>
		public DESCUENTO_DOC_CLI_DET_VENCIMRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTO_DOC_CLI_DET_VENCIMRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_DOCUMENTO_DET_ID != original.DESCUENTO_DOCUMENTO_DET_ID) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.MONTO != original.MONTO) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_DET_ID
		{
			get { return _descuento_documento_det_id; }
			set { _descuento_documento_det_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
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
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_DET_ID=");
			dynStr.Append(DESCUENTO_DOCUMENTO_DET_ID);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			return dynStr.ToString();
		}
	} // End of DESCUENTO_DOC_CLI_DET_VENCIMRow_Base class
} // End of namespace
