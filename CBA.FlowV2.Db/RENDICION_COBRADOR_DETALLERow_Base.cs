// <fileinfo name="RENDICION_COBRADOR_DETALLERow_Base.cs">
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
	/// The base class for <see cref="RENDICION_COBRADOR_DETALLERow"/> that 
	/// represents a record in the <c>RENDICION_COBRADOR_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RENDICION_COBRADOR_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RENDICION_COBRADOR_DETALLERow_Base
	{
		private decimal _id;
		private decimal _rendicion_cobrador_id;
		private decimal _recibo_id;
		private decimal _caso_pago;
		private bool _caso_pagoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_DETALLERow_Base"/> class.
		/// </summary>
		public RENDICION_COBRADOR_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RENDICION_COBRADOR_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RENDICION_COBRADOR_ID != original.RENDICION_COBRADOR_ID) return true;
			if (this.RECIBO_ID != original.RECIBO_ID) return true;
			if (this.IsCASO_PAGONull != original.IsCASO_PAGONull) return true;
			if (!this.IsCASO_PAGONull && !original.IsCASO_PAGONull)
				if (this.CASO_PAGO != original.CASO_PAGO) return true;
			
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
		/// Gets or sets the <c>RENDICION_COBRADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>RENDICION_COBRADOR_ID</c> column value.</value>
		public decimal RENDICION_COBRADOR_ID
		{
			get { return _rendicion_cobrador_id; }
			set { _rendicion_cobrador_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_ID</c> column value.
		/// </summary>
		/// <value>The <c>RECIBO_ID</c> column value.</value>
		public decimal RECIBO_ID
		{
			get { return _recibo_id; }
			set { _recibo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO</c> column value.</value>
		public decimal CASO_PAGO
		{
			get
			{
				if(IsCASO_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_pago;
			}
			set
			{
				_caso_pagoNull = false;
				_caso_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_PAGONull
		{
			get { return _caso_pagoNull; }
			set { _caso_pagoNull = value; }
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
			dynStr.Append("@CBA@RENDICION_COBRADOR_ID=");
			dynStr.Append(RENDICION_COBRADOR_ID);
			dynStr.Append("@CBA@RECIBO_ID=");
			dynStr.Append(RECIBO_ID);
			dynStr.Append("@CBA@CASO_PAGO=");
			dynStr.Append(IsCASO_PAGONull ? (object)"<NULL>" : CASO_PAGO);
			return dynStr.ToString();
		}
	} // End of RENDICION_COBRADOR_DETALLERow_Base class
} // End of namespace
