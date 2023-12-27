// <fileinfo name="CTACTE_PAGARES_DOCUMENTOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARES_DOCUMENTOSRow"/> that 
	/// represents a record in the <c>CTACTE_PAGARES_DOCUMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGARES_DOCUMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARES_DOCUMENTOSRow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagare_id;
		private decimal _ctacte_persona_id;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto_origen;
		private decimal _monto_destino;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARES_DOCUMENTOSRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGARES_DOCUMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGARES_DOCUMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGARE_ID != original.CTACTE_PAGARE_ID) return true;
			if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			
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
		/// Gets or sets the <c>CTACTE_PAGARE_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_ID
		{
			get { return _ctacte_pagare_id; }
			set { _ctacte_pagare_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get { return _ctacte_persona_id; }
			set { _ctacte_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get { return _monto_destino; }
			set { _monto_destino = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGARE_ID=");
			dynStr.Append(CTACTE_PAGARE_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGARES_DOCUMENTOSRow_Base class
} // End of namespace
