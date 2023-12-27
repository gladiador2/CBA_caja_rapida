// <fileinfo name="PLANILLA_PARA_COBRANZARow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PARA_COBRANZARow"/> that 
	/// represents a record in the <c>PLANILLA_PARA_COBRANZA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_PARA_COBRANZARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PARA_COBRANZARow_Base
	{
		private decimal _id;
		private decimal _ctacte_persona_id;
		private decimal _monto_cuota;
		private decimal _planilla_de_cobranza_id;
		private decimal _planilla_de_cobranza_det_id;
		private bool _planilla_de_cobranza_det_idNull = true;
		private decimal _cobrado;
		private decimal _monto_mora;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PARA_COBRANZARow_Base"/> class.
		/// </summary>
		public PLANILLA_PARA_COBRANZARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_PARA_COBRANZARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.MONTO_CUOTA != original.MONTO_CUOTA) return true;
			if (this.PLANILLA_DE_COBRANZA_ID != original.PLANILLA_DE_COBRANZA_ID) return true;
			if (this.IsPLANILLA_DE_COBRANZA_DET_IDNull != original.IsPLANILLA_DE_COBRANZA_DET_IDNull) return true;
			if (!this.IsPLANILLA_DE_COBRANZA_DET_IDNull && !original.IsPLANILLA_DE_COBRANZA_DET_IDNull)
				if (this.PLANILLA_DE_COBRANZA_DET_ID != original.PLANILLA_DE_COBRANZA_DET_ID) return true;
			if (this.COBRADO != original.COBRADO) return true;
			if (this.MONTO_MORA != original.MONTO_MORA) return true;
			
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
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get { return _ctacte_persona_id; }
			set { _ctacte_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CUOTA</c> column value.</value>
		public decimal MONTO_CUOTA
		{
			get { return _monto_cuota; }
			set { _monto_cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_DE_COBRANZA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</value>
		public decimal PLANILLA_DE_COBRANZA_ID
		{
			get { return _planilla_de_cobranza_id; }
			set { _planilla_de_cobranza_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</value>
		public decimal PLANILLA_DE_COBRANZA_DET_ID
		{
			get
			{
				if(IsPLANILLA_DE_COBRANZA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _planilla_de_cobranza_det_id;
			}
			set
			{
				_planilla_de_cobranza_det_idNull = false;
				_planilla_de_cobranza_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLANILLA_DE_COBRANZA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLANILLA_DE_COBRANZA_DET_IDNull
		{
			get { return _planilla_de_cobranza_det_idNull; }
			set { _planilla_de_cobranza_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>COBRADO</c> column value.</value>
		public decimal COBRADO
		{
			get { return _cobrado; }
			set { _cobrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_MORA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_MORA</c> column value.</value>
		public decimal MONTO_MORA
		{
			get { return _monto_mora; }
			set { _monto_mora = value; }
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
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@MONTO_CUOTA=");
			dynStr.Append(MONTO_CUOTA);
			dynStr.Append("@CBA@PLANILLA_DE_COBRANZA_ID=");
			dynStr.Append(PLANILLA_DE_COBRANZA_ID);
			dynStr.Append("@CBA@PLANILLA_DE_COBRANZA_DET_ID=");
			dynStr.Append(IsPLANILLA_DE_COBRANZA_DET_IDNull ? (object)"<NULL>" : PLANILLA_DE_COBRANZA_DET_ID);
			dynStr.Append("@CBA@COBRADO=");
			dynStr.Append(COBRADO);
			dynStr.Append("@CBA@MONTO_MORA=");
			dynStr.Append(MONTO_MORA);
			return dynStr.ToString();
		}
	} // End of PLANILLA_PARA_COBRANZARow_Base class
} // End of namespace
