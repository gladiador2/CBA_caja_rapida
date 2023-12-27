// <fileinfo name="TIPOS_RETENCIONESRow_Base.cs">
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
	/// The base class for <see cref="TIPOS_RETENCIONESRow"/> that 
	/// represents a record in the <c>TIPOS_RETENCIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_RETENCIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_RETENCIONESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _porcentaje;
		private decimal _monto_minimo;
		private decimal _moneda_id;
		private decimal _tipo_monto_a_aplicar;
		private string _emitir_retencion;
		private decimal _ctacte_valor_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_RETENCIONESRow_Base"/> class.
		/// </summary>
		public TIPOS_RETENCIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_RETENCIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.MONTO_MINIMO != original.MONTO_MINIMO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.TIPO_MONTO_A_APLICAR != original.TIPO_MONTO_A_APLICAR) return true;
			if (this.EMITIR_RETENCION != original.EMITIR_RETENCION) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_MINIMO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_MINIMO</c> column value.</value>
		public decimal MONTO_MINIMO
		{
			get { return _monto_minimo; }
			set { _monto_minimo = value; }
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
		/// Gets or sets the <c>TIPO_MONTO_A_APLICAR</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_MONTO_A_APLICAR</c> column value.</value>
		public decimal TIPO_MONTO_A_APLICAR
		{
			get { return _tipo_monto_a_aplicar; }
			set { _tipo_monto_a_aplicar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMITIR_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>EMITIR_RETENCION</c> column value.</value>
		public string EMITIR_RETENCION
		{
			get { return _emitir_retencion; }
			set { _emitir_retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			dynStr.Append("@CBA@MONTO_MINIMO=");
			dynStr.Append(MONTO_MINIMO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@TIPO_MONTO_A_APLICAR=");
			dynStr.Append(TIPO_MONTO_A_APLICAR);
			dynStr.Append("@CBA@EMITIR_RETENCION=");
			dynStr.Append(EMITIR_RETENCION);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			return dynStr.ToString();
		}
	} // End of TIPOS_RETENCIONESRow_Base class
} // End of namespace
