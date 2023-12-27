// <fileinfo name="CTACTE_PERSONAS_CIERRE_DETRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONAS_CIERRE_DETRow"/> that 
	/// represents a record in the <c>CTACTE_PERSONAS_CIERRE_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PERSONAS_CIERRE_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONAS_CIERRE_DETRow_Base
	{
		private decimal _id;
		private decimal _ctacte_persona_cierre_id;
		private decimal _persona_id;
		private decimal _credito;
		private decimal _debito;
		private decimal _fecha_formato_numero;
		private decimal _saldo_vencido;
		private decimal _saldo_a_vencer;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONAS_CIERRE_DETRow_Base"/> class.
		/// </summary>
		public CTACTE_PERSONAS_CIERRE_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PERSONAS_CIERRE_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PERSONA_CIERRE_ID != original.CTACTE_PERSONA_CIERRE_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.FECHA_FORMATO_NUMERO != original.FECHA_FORMATO_NUMERO) return true;
			if (this.SALDO_VENCIDO != original.SALDO_VENCIDO) return true;
			if (this.SALDO_A_VENCER != original.SALDO_A_VENCER) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>CTACTE_PERSONA_CIERRE_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_CIERRE_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_CIERRE_ID
		{
			get { return _ctacte_persona_cierre_id; }
			set { _ctacte_persona_cierre_id = value; }
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
		/// Gets or sets the <c>CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO</c> column value.</value>
		public decimal CREDITO
		{
			get { return _credito; }
			set { _credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBITO</c> column value.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get { return _debito; }
			set { _debito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMATO_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMATO_NUMERO</c> column value.</value>
		public decimal FECHA_FORMATO_NUMERO
		{
			get { return _fecha_formato_numero; }
			set { _fecha_formato_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_VENCIDO</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_VENCIDO</c> column value.</value>
		public decimal SALDO_VENCIDO
		{
			get { return _saldo_vencido; }
			set { _saldo_vencido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_A_VENCER</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_A_VENCER</c> column value.</value>
		public decimal SALDO_A_VENCER
		{
			get { return _saldo_a_vencer; }
			set { _saldo_a_vencer = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_CIERRE_ID=");
			dynStr.Append(CTACTE_PERSONA_CIERRE_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			dynStr.Append("@CBA@SALDO_VENCIDO=");
			dynStr.Append(SALDO_VENCIDO);
			dynStr.Append("@CBA@SALDO_A_VENCER=");
			dynStr.Append(SALDO_A_VENCER);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PERSONAS_CIERRE_DETRow_Base class
} // End of namespace
