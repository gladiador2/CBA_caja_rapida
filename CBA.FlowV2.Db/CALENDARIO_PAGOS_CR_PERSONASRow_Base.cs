// <fileinfo name="CALENDARIO_PAGOS_CR_PERSONASRow_Base.cs">
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
	/// The base class for <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> that 
	/// represents a record in the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CALENDARIO_PAGOS_CR_PERSONASRow_Base
	{
		private decimal _id;
		private decimal _credito_id;
		private System.DateTime _fecha_vencimiento;
		private decimal _monto_capital;
		private decimal _monto_interes_a_devengar;
		private decimal _numero_cuota;
		private string _estado;
		private decimal _monto_interes_devengados;
		private decimal _monto_interes_en_suspenso;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _monto_impuesto;
		private decimal _devengamiento_capital_a_cobrar;
		private decimal _devengamiento_interes_a_cobrar;
		private decimal _ctb_devengamiento_primero_id;
		private bool _ctb_devengamiento_primero_idNull = true;
		private string _cancelacion_anticipada;
		private decimal _monto_mora_manual;
		private bool _monto_mora_manualNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIO_PAGOS_CR_PERSONASRow_Base"/> class.
		/// </summary>
		public CALENDARIO_PAGOS_CR_PERSONASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CALENDARIO_PAGOS_CR_PERSONASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CREDITO_ID != original.CREDITO_ID) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.MONTO_CAPITAL != original.MONTO_CAPITAL) return true;
			if (this.MONTO_INTERES_A_DEVENGAR != original.MONTO_INTERES_A_DEVENGAR) return true;
			if (this.NUMERO_CUOTA != original.NUMERO_CUOTA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.MONTO_INTERES_DEVENGADOS != original.MONTO_INTERES_DEVENGADOS) return true;
			if (this.MONTO_INTERES_EN_SUSPENSO != original.MONTO_INTERES_EN_SUSPENSO) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.DEVENGAMIENTO_CAPITAL_A_COBRAR != original.DEVENGAMIENTO_CAPITAL_A_COBRAR) return true;
			if (this.DEVENGAMIENTO_INTERES_A_COBRAR != original.DEVENGAMIENTO_INTERES_A_COBRAR) return true;
			if (this.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull != original.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull) return true;
			if (!this.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull && !original.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull)
				if (this.CTB_DEVENGAMIENTO_PRIMERO_ID != original.CTB_DEVENGAMIENTO_PRIMERO_ID) return true;
			if (this.CANCELACION_ANTICIPADA != original.CANCELACION_ANTICIPADA) return true;
			if (this.IsMONTO_MORA_MANUALNull != original.IsMONTO_MORA_MANUALNull) return true;
			if (!this.IsMONTO_MORA_MANUALNull && !original.IsMONTO_MORA_MANUALNull)
				if (this.MONTO_MORA_MANUAL != original.MONTO_MORA_MANUAL) return true;
			
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
		/// Gets or sets the <c>CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO_ID</c> column value.</value>
		public decimal CREDITO_ID
		{
			get { return _credito_id; }
			set { _credito_id = value; }
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
		/// Gets or sets the <c>MONTO_CAPITAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL</c> column value.</value>
		public decimal MONTO_CAPITAL
		{
			get { return _monto_capital; }
			set { _monto_capital = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERES_A_DEVENGAR</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INTERES_A_DEVENGAR</c> column value.</value>
		public decimal MONTO_INTERES_A_DEVENGAR
		{
			get { return _monto_interes_a_devengar; }
			set { _monto_interes_a_devengar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUOTA</c> column value.</value>
		public decimal NUMERO_CUOTA
		{
			get { return _numero_cuota; }
			set { _numero_cuota = value; }
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
		/// Gets or sets the <c>MONTO_INTERES_DEVENGADOS</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INTERES_DEVENGADOS</c> column value.</value>
		public decimal MONTO_INTERES_DEVENGADOS
		{
			get { return _monto_interes_devengados; }
			set { _monto_interes_devengados = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERES_EN_SUSPENSO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INTERES_EN_SUSPENSO</c> column value.</value>
		public decimal MONTO_INTERES_EN_SUSPENSO
		{
			get { return _monto_interes_en_suspenso; }
			set { _monto_interes_en_suspenso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO</c> column value.</value>
		public decimal MONTO_IMPUESTO
		{
			get { return _monto_impuesto; }
			set { _monto_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVENGAMIENTO_CAPITAL_A_COBRAR</c> column value.
		/// </summary>
		/// <value>The <c>DEVENGAMIENTO_CAPITAL_A_COBRAR</c> column value.</value>
		public decimal DEVENGAMIENTO_CAPITAL_A_COBRAR
		{
			get { return _devengamiento_capital_a_cobrar; }
			set { _devengamiento_capital_a_cobrar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVENGAMIENTO_INTERES_A_COBRAR</c> column value.
		/// </summary>
		/// <value>The <c>DEVENGAMIENTO_INTERES_A_COBRAR</c> column value.</value>
		public decimal DEVENGAMIENTO_INTERES_A_COBRAR
		{
			get { return _devengamiento_interes_a_cobrar; }
			set { _devengamiento_interes_a_cobrar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</value>
		public decimal CTB_DEVENGAMIENTO_PRIMERO_ID
		{
			get
			{
				if(IsCTB_DEVENGAMIENTO_PRIMERO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_devengamiento_primero_id;
			}
			set
			{
				_ctb_devengamiento_primero_idNull = false;
				_ctb_devengamiento_primero_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_DEVENGAMIENTO_PRIMERO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_DEVENGAMIENTO_PRIMERO_IDNull
		{
			get { return _ctb_devengamiento_primero_idNull; }
			set { _ctb_devengamiento_primero_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANCELACION_ANTICIPADA</c> column value.
		/// </summary>
		/// <value>The <c>CANCELACION_ANTICIPADA</c> column value.</value>
		public string CANCELACION_ANTICIPADA
		{
			get { return _cancelacion_anticipada; }
			set { _cancelacion_anticipada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_MORA_MANUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_MORA_MANUAL</c> column value.</value>
		public decimal MONTO_MORA_MANUAL
		{
			get
			{
				if(IsMONTO_MORA_MANUALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_mora_manual;
			}
			set
			{
				_monto_mora_manualNull = false;
				_monto_mora_manual = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_MORA_MANUAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_MORA_MANUALNull
		{
			get { return _monto_mora_manualNull; }
			set { _monto_mora_manualNull = value; }
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
			dynStr.Append("@CBA@CREDITO_ID=");
			dynStr.Append(CREDITO_ID);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@MONTO_CAPITAL=");
			dynStr.Append(MONTO_CAPITAL);
			dynStr.Append("@CBA@MONTO_INTERES_A_DEVENGAR=");
			dynStr.Append(MONTO_INTERES_A_DEVENGAR);
			dynStr.Append("@CBA@NUMERO_CUOTA=");
			dynStr.Append(NUMERO_CUOTA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MONTO_INTERES_DEVENGADOS=");
			dynStr.Append(MONTO_INTERES_DEVENGADOS);
			dynStr.Append("@CBA@MONTO_INTERES_EN_SUSPENSO=");
			dynStr.Append(MONTO_INTERES_EN_SUSPENSO);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(MONTO_IMPUESTO);
			dynStr.Append("@CBA@DEVENGAMIENTO_CAPITAL_A_COBRAR=");
			dynStr.Append(DEVENGAMIENTO_CAPITAL_A_COBRAR);
			dynStr.Append("@CBA@DEVENGAMIENTO_INTERES_A_COBRAR=");
			dynStr.Append(DEVENGAMIENTO_INTERES_A_COBRAR);
			dynStr.Append("@CBA@CTB_DEVENGAMIENTO_PRIMERO_ID=");
			dynStr.Append(IsCTB_DEVENGAMIENTO_PRIMERO_IDNull ? (object)"<NULL>" : CTB_DEVENGAMIENTO_PRIMERO_ID);
			dynStr.Append("@CBA@CANCELACION_ANTICIPADA=");
			dynStr.Append(CANCELACION_ANTICIPADA);
			dynStr.Append("@CBA@MONTO_MORA_MANUAL=");
			dynStr.Append(IsMONTO_MORA_MANUALNull ? (object)"<NULL>" : MONTO_MORA_MANUAL);
			return dynStr.ToString();
		}
	} // End of CALENDARIO_PAGOS_CR_PERSONASRow_Base class
} // End of namespace
