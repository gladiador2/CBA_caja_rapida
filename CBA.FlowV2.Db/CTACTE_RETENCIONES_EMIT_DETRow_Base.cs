// <fileinfo name="CTACTE_RETENCIONES_EMIT_DETRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_RETENCIONES_EMIT_DETRow"/> that 
	/// represents a record in the <c>CTACTE_RETENCIONES_EMIT_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_RETENCIONES_EMIT_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RETENCIONES_EMIT_DETRow_Base
	{
		private decimal _id;
		private decimal _ctacte_retencion_emitida_id;
		private decimal _caso_id;
		private decimal _monto;
		private decimal _retencion_tipo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RETENCIONES_EMIT_DETRow_Base"/> class.
		/// </summary>
		public CTACTE_RETENCIONES_EMIT_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_RETENCIONES_EMIT_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_RETENCION_EMITIDA_ID != original.CTACTE_RETENCION_EMITIDA_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.RETENCION_TIPO_ID != original.RETENCION_TIPO_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_RETENCION_EMITIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_RETENCION_EMITIDA_ID</c> column value.</value>
		public decimal CTACTE_RETENCION_EMITIDA_ID
		{
			get { return _ctacte_retencion_emitida_id; }
			set { _ctacte_retencion_emitida_id = value; }
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>RETENCION_TIPO_ID</c> column value.</value>
		public decimal RETENCION_TIPO_ID
		{
			get { return _retencion_tipo_id; }
			set { _retencion_tipo_id = value; }
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
			dynStr.Append("@CBA@CTACTE_RETENCION_EMITIDA_ID=");
			dynStr.Append(CTACTE_RETENCION_EMITIDA_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@RETENCION_TIPO_ID=");
			dynStr.Append(RETENCION_TIPO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_RETENCIONES_EMIT_DETRow_Base class
} // End of namespace
