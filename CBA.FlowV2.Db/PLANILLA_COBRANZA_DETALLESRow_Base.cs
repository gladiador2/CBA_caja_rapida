// <fileinfo name="PLANILLA_COBRANZA_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBRANZA_DETALLESRow"/> that 
	/// represents a record in the <c>PLANILLA_COBRANZA_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_COBRANZA_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBRANZA_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _planilla_cobranza_id;
		private decimal _persona_id;
		private string _direccion_cobro;
		private decimal _moneda_id;
		private decimal _monto_cuota;
		private decimal _moneda_cobrado_id;
		private bool _moneda_cobrado_idNull = true;
		private decimal _cotizacion_cobrada;
		private bool _cotizacion_cobradaNull = true;
		private decimal _monto_cobrado;
		private bool _monto_cobradoNull = true;
		private string _cobrado;
		private decimal _caso_pago_id;
		private bool _caso_pago_idNull = true;
		private string _observacion;
		private decimal _ctacte_recibo_impreso_id;
		private bool _ctacte_recibo_impreso_idNull = true;
		private decimal _ctacte_recibo_entregado_id;
		private bool _ctacte_recibo_entregado_idNull = true;
		private decimal _monto_mora;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZA_DETALLESRow_Base"/> class.
		/// </summary>
		public PLANILLA_COBRANZA_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_COBRANZA_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_COBRANZA_ID != original.PLANILLA_COBRANZA_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.DIRECCION_COBRO != original.DIRECCION_COBRO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONTO_CUOTA != original.MONTO_CUOTA) return true;
			if (this.IsMONEDA_COBRADO_IDNull != original.IsMONEDA_COBRADO_IDNull) return true;
			if (!this.IsMONEDA_COBRADO_IDNull && !original.IsMONEDA_COBRADO_IDNull)
				if (this.MONEDA_COBRADO_ID != original.MONEDA_COBRADO_ID) return true;
			if (this.IsCOTIZACION_COBRADANull != original.IsCOTIZACION_COBRADANull) return true;
			if (!this.IsCOTIZACION_COBRADANull && !original.IsCOTIZACION_COBRADANull)
				if (this.COTIZACION_COBRADA != original.COTIZACION_COBRADA) return true;
			if (this.IsMONTO_COBRADONull != original.IsMONTO_COBRADONull) return true;
			if (!this.IsMONTO_COBRADONull && !original.IsMONTO_COBRADONull)
				if (this.MONTO_COBRADO != original.MONTO_COBRADO) return true;
			if (this.COBRADO != original.COBRADO) return true;
			if (this.IsCASO_PAGO_IDNull != original.IsCASO_PAGO_IDNull) return true;
			if (!this.IsCASO_PAGO_IDNull && !original.IsCASO_PAGO_IDNull)
				if (this.CASO_PAGO_ID != original.CASO_PAGO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_RECIBO_IMPRESO_IDNull != original.IsCTACTE_RECIBO_IMPRESO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_IMPRESO_IDNull && !original.IsCTACTE_RECIBO_IMPRESO_IDNull)
				if (this.CTACTE_RECIBO_IMPRESO_ID != original.CTACTE_RECIBO_IMPRESO_ID) return true;
			if (this.IsCTACTE_RECIBO_ENTREGADO_IDNull != original.IsCTACTE_RECIBO_ENTREGADO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_ENTREGADO_IDNull && !original.IsCTACTE_RECIBO_ENTREGADO_IDNull)
				if (this.CTACTE_RECIBO_ENTREGADO_ID != original.CTACTE_RECIBO_ENTREGADO_ID) return true;
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
		/// Gets or sets the <c>PLANILLA_COBRANZA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_COBRANZA_ID</c> column value.</value>
		public decimal PLANILLA_COBRANZA_ID
		{
			get { return _planilla_cobranza_id; }
			set { _planilla_cobranza_id = value; }
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
		/// Gets or sets the <c>DIRECCION_COBRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_COBRO</c> column value.</value>
		public string DIRECCION_COBRO
		{
			get { return _direccion_cobro; }
			set { _direccion_cobro = value; }
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
		/// Gets or sets the <c>MONTO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CUOTA</c> column value.</value>
		public decimal MONTO_CUOTA
		{
			get { return _monto_cuota; }
			set { _monto_cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRADO_ID</c> column value.</value>
		public decimal MONEDA_COBRADO_ID
		{
			get
			{
				if(IsMONEDA_COBRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cobrado_id;
			}
			set
			{
				_moneda_cobrado_idNull = false;
				_moneda_cobrado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COBRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COBRADO_IDNull
		{
			get { return _moneda_cobrado_idNull; }
			set { _moneda_cobrado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_COBRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_COBRADA</c> column value.</value>
		public decimal COTIZACION_COBRADA
		{
			get
			{
				if(IsCOTIZACION_COBRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_cobrada;
			}
			set
			{
				_cotizacion_cobradaNull = false;
				_cotizacion_cobrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_COBRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_COBRADANull
		{
			get { return _cotizacion_cobradaNull; }
			set { _cotizacion_cobradaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COBRADO</c> column value.</value>
		public decimal MONTO_COBRADO
		{
			get
			{
				if(IsMONTO_COBRADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_cobrado;
			}
			set
			{
				_monto_cobradoNull = false;
				_monto_cobrado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COBRADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COBRADONull
		{
			get { return _monto_cobradoNull; }
			set { _monto_cobradoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COBRADO</c> column value.</value>
		public string COBRADO
		{
			get { return _cobrado; }
			set { _cobrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO_ID</c> column value.</value>
		public decimal CASO_PAGO_ID
		{
			get
			{
				if(IsCASO_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_pago_id;
			}
			set
			{
				_caso_pago_idNull = false;
				_caso_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_PAGO_IDNull
		{
			get { return _caso_pago_idNull; }
			set { _caso_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</value>
		public decimal CTACTE_RECIBO_IMPRESO_ID
		{
			get
			{
				if(IsCTACTE_RECIBO_IMPRESO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recibo_impreso_id;
			}
			set
			{
				_ctacte_recibo_impreso_idNull = false;
				_ctacte_recibo_impreso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECIBO_IMPRESO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECIBO_IMPRESO_IDNull
		{
			get { return _ctacte_recibo_impreso_idNull; }
			set { _ctacte_recibo_impreso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</value>
		public decimal CTACTE_RECIBO_ENTREGADO_ID
		{
			get
			{
				if(IsCTACTE_RECIBO_ENTREGADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recibo_entregado_id;
			}
			set
			{
				_ctacte_recibo_entregado_idNull = false;
				_ctacte_recibo_entregado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECIBO_ENTREGADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECIBO_ENTREGADO_IDNull
		{
			get { return _ctacte_recibo_entregado_idNull; }
			set { _ctacte_recibo_entregado_idNull = value; }
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
			dynStr.Append("@CBA@PLANILLA_COBRANZA_ID=");
			dynStr.Append(PLANILLA_COBRANZA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@DIRECCION_COBRO=");
			dynStr.Append(DIRECCION_COBRO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONTO_CUOTA=");
			dynStr.Append(MONTO_CUOTA);
			dynStr.Append("@CBA@MONEDA_COBRADO_ID=");
			dynStr.Append(IsMONEDA_COBRADO_IDNull ? (object)"<NULL>" : MONEDA_COBRADO_ID);
			dynStr.Append("@CBA@COTIZACION_COBRADA=");
			dynStr.Append(IsCOTIZACION_COBRADANull ? (object)"<NULL>" : COTIZACION_COBRADA);
			dynStr.Append("@CBA@MONTO_COBRADO=");
			dynStr.Append(IsMONTO_COBRADONull ? (object)"<NULL>" : MONTO_COBRADO);
			dynStr.Append("@CBA@COBRADO=");
			dynStr.Append(COBRADO);
			dynStr.Append("@CBA@CASO_PAGO_ID=");
			dynStr.Append(IsCASO_PAGO_IDNull ? (object)"<NULL>" : CASO_PAGO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_RECIBO_IMPRESO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_IMPRESO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_IMPRESO_ID);
			dynStr.Append("@CBA@CTACTE_RECIBO_ENTREGADO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_ENTREGADO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_ENTREGADO_ID);
			dynStr.Append("@CBA@MONTO_MORA=");
			dynStr.Append(MONTO_MORA);
			return dynStr.ToString();
		}
	} // End of PLANILLA_COBRANZA_DETALLESRow_Base class
} // End of namespace
