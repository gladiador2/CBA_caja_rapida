// <fileinfo name="PLANILLA_COBRANZA_VALORESRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBRANZA_VALORESRow"/> that 
	/// represents a record in the <c>PLANILLA_COBRANZA_VALORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_COBRANZA_VALORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBRANZA_VALORESRow_Base
	{
		private decimal _id;
		private decimal _planilla_cobranza_id;
		private decimal _caso_id;
		private decimal _monto_utilizar;
		private string _estado;
		private decimal _moneda_id;
		private decimal _cotizacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZA_VALORESRow_Base"/> class.
		/// </summary>
		public PLANILLA_COBRANZA_VALORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_COBRANZA_VALORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_COBRANZA_ID != original.PLANILLA_COBRANZA_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.MONTO_UTILIZAR != original.MONTO_UTILIZAR) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>PLANILLA_COBRANZA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_COBRANZA_ID</c> column value.</value>
		public decimal PLANILLA_COBRANZA_ID
		{
			get { return _planilla_cobranza_id; }
			set { _planilla_cobranza_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_UTILIZAR</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_UTILIZAR</c> column value.</value>
		public decimal MONTO_UTILIZAR
		{
			get { return _monto_utilizar; }
			set { _monto_utilizar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
			dynStr.Append("@CBA@PLANILLA_COBRANZA_ID=");
			dynStr.Append(PLANILLA_COBRANZA_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@MONTO_UTILIZAR=");
			dynStr.Append(MONTO_UTILIZAR);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			return dynStr.ToString();
		}
	} // End of PLANILLA_COBRANZA_VALORESRow_Base class
} // End of namespace
