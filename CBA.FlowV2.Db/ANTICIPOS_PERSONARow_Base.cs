// <fileinfo name="ANTICIPOS_PERSONARow_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_PERSONARow"/> that 
	/// represents a record in the <c>ANTICIPOS_PERSONA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ANTICIPOS_PERSONARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_PERSONARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private System.DateTime _fecha;
		private decimal _funcionario_cobrador_id;
		private decimal _autonumeracion_recibo_id;
		private bool _autonumeracion_recibo_idNull = true;
		private decimal _ctacte_recibo_id;
		private bool _ctacte_recibo_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private decimal _saldo_por_aplicar;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_PERSONARow_Base"/> class.
		/// </summary>
		public ANTICIPOS_PERSONARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ANTICIPOS_PERSONARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.FUNCIONARIO_COBRADOR_ID != original.FUNCIONARIO_COBRADOR_ID) return true;
			if (this.IsAUTONUMERACION_RECIBO_IDNull != original.IsAUTONUMERACION_RECIBO_IDNull) return true;
			if (!this.IsAUTONUMERACION_RECIBO_IDNull && !original.IsAUTONUMERACION_RECIBO_IDNull)
				if (this.AUTONUMERACION_RECIBO_ID != original.AUTONUMERACION_RECIBO_ID) return true;
			if (this.IsCTACTE_RECIBO_IDNull != original.IsCTACTE_RECIBO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_IDNull && !original.IsCTACTE_RECIBO_IDNull)
				if (this.CTACTE_RECIBO_ID != original.CTACTE_RECIBO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.SALDO_POR_APLICAR != original.SALDO_POR_APLICAR) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_COBRADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</value>
		public decimal FUNCIONARIO_COBRADOR_ID
		{
			get { return _funcionario_cobrador_id; }
			set { _funcionario_cobrador_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_RECIBO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_RECIBO_ID</c> column value.</value>
		public decimal AUTONUMERACION_RECIBO_ID
		{
			get
			{
				if(IsAUTONUMERACION_RECIBO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_recibo_id;
			}
			set
			{
				_autonumeracion_recibo_idNull = false;
				_autonumeracion_recibo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_RECIBO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_RECIBO_IDNull
		{
			get { return _autonumeracion_recibo_idNull; }
			set { _autonumeracion_recibo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_ID</c> column value.</value>
		public decimal CTACTE_RECIBO_ID
		{
			get
			{
				if(IsCTACTE_RECIBO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recibo_id;
			}
			set
			{
				_ctacte_recibo_idNull = false;
				_ctacte_recibo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECIBO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECIBO_IDNull
		{
			get { return _ctacte_recibo_idNull; }
			set { _ctacte_recibo_idNull = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_POR_APLICAR</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_POR_APLICAR</c> column value.</value>
		public decimal SALDO_POR_APLICAR
		{
			get { return _saldo_por_aplicar; }
			set { _saldo_por_aplicar = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FUNCIONARIO_COBRADOR_ID=");
			dynStr.Append(FUNCIONARIO_COBRADOR_ID);
			dynStr.Append("@CBA@AUTONUMERACION_RECIBO_ID=");
			dynStr.Append(IsAUTONUMERACION_RECIBO_IDNull ? (object)"<NULL>" : AUTONUMERACION_RECIBO_ID);
			dynStr.Append("@CBA@CTACTE_RECIBO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@SALDO_POR_APLICAR=");
			dynStr.Append(SALDO_POR_APLICAR);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			return dynStr.ToString();
		}
	} // End of ANTICIPOS_PERSONARow_Base class
} // End of namespace
