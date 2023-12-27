// <fileinfo name="CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONAS_CALIDAD_PAGOSRow"/> that 
	/// represents a record in the <c>CTACTE_PERSONAS_CALIDAD_PAGOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PERSONAS_CALIDAD_PAGOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_nombre;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _caso_estado_id;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private decimal _cotizacion_moneda;
		private decimal _debito;
		private decimal _credito;
		private decimal _saldo;
		private bool _saldoNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _fecha_pago;
		private bool _fecha_pagoNull = true;
		private decimal _dias_atraso;
		private bool _dias_atrasoNull = true;
		private System.DateTime _fecha_otorgamiento;
		private bool _fecha_otorgamientoNull = true;
		private string _pagos_finalizados;
		private decimal _cantidad_vencimientos;
		private bool _cantidad_vencimientosNull = true;
		private string _a_sola_firma;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base"/> class.
		/// </summary>
		public CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.IsSALDONull != original.IsSALDONull) return true;
			if (!this.IsSALDONull && !original.IsSALDONull)
				if (this.SALDO != original.SALDO) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_PAGONull != original.IsFECHA_PAGONull) return true;
			if (!this.IsFECHA_PAGONull && !original.IsFECHA_PAGONull)
				if (this.FECHA_PAGO != original.FECHA_PAGO) return true;
			if (this.IsDIAS_ATRASONull != original.IsDIAS_ATRASONull) return true;
			if (!this.IsDIAS_ATRASONull && !original.IsDIAS_ATRASONull)
				if (this.DIAS_ATRASO != original.DIAS_ATRASO) return true;
			if (this.IsFECHA_OTORGAMIENTONull != original.IsFECHA_OTORGAMIENTONull) return true;
			if (!this.IsFECHA_OTORGAMIENTONull && !original.IsFECHA_OTORGAMIENTONull)
				if (this.FECHA_OTORGAMIENTO != original.FECHA_OTORGAMIENTO) return true;
			if (this.PAGOS_FINALIZADOS != original.PAGOS_FINALIZADOS) return true;
			if (this.IsCANTIDAD_VENCIMIENTOSNull != original.IsCANTIDAD_VENCIMIENTOSNull) return true;
			if (!this.IsCANTIDAD_VENCIMIENTOSNull && !original.IsCANTIDAD_VENCIMIENTOSNull)
				if (this.CANTIDAD_VENCIMIENTOS != original.CANTIDAD_VENCIMIENTOS) return true;
			if (this.A_SOLA_FIRMA != original.A_SOLA_FIRMA) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_NOMBRE</c> column value.</value>
		public string FLUJO_NOMBRE
		{
			get { return _flujo_nombre; }
			set { _flujo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_det_id;
			}
			set
			{
				_ctacte_pagare_det_idNull = false;
				_ctacte_pagare_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DET_IDNull
		{
			get { return _ctacte_pagare_det_idNull; }
			set { _ctacte_pagare_det_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
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
		/// Gets or sets the <c>DEBITO</c> column value.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get { return _debito; }
			set { _debito = value; }
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
		/// Gets or sets the <c>SALDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO</c> column value.</value>
		public decimal SALDO
		{
			get
			{
				if(IsSALDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo;
			}
			set
			{
				_saldoNull = false;
				_saldo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDONull
		{
			get { return _saldoNull; }
			set { _saldoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_PAGO</c> column value.</value>
		public System.DateTime FECHA_PAGO
		{
			get
			{
				if(IsFECHA_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_pago;
			}
			set
			{
				_fecha_pagoNull = false;
				_fecha_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_PAGONull
		{
			get { return _fecha_pagoNull; }
			set { _fecha_pagoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_ATRASO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_ATRASO</c> column value.</value>
		public decimal DIAS_ATRASO
		{
			get
			{
				if(IsDIAS_ATRASONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_atraso;
			}
			set
			{
				_dias_atrasoNull = false;
				_dias_atraso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_ATRASO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_ATRASONull
		{
			get { return _dias_atrasoNull; }
			set { _dias_atrasoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_OTORGAMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_OTORGAMIENTO</c> column value.</value>
		public System.DateTime FECHA_OTORGAMIENTO
		{
			get
			{
				if(IsFECHA_OTORGAMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_otorgamiento;
			}
			set
			{
				_fecha_otorgamientoNull = false;
				_fecha_otorgamiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_OTORGAMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_OTORGAMIENTONull
		{
			get { return _fecha_otorgamientoNull; }
			set { _fecha_otorgamientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGOS_FINALIZADOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAGOS_FINALIZADOS</c> column value.</value>
		public string PAGOS_FINALIZADOS
		{
			get { return _pagos_finalizados; }
			set { _pagos_finalizados = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_VENCIMIENTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_VENCIMIENTOS</c> column value.</value>
		public decimal CANTIDAD_VENCIMIENTOS
		{
			get
			{
				if(IsCANTIDAD_VENCIMIENTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_vencimientos;
			}
			set
			{
				_cantidad_vencimientosNull = false;
				_cantidad_vencimientos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_VENCIMIENTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_VENCIMIENTOSNull
		{
			get { return _cantidad_vencimientosNull; }
			set { _cantidad_vencimientosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_SOLA_FIRMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>A_SOLA_FIRMA</c> column value.</value>
		public string A_SOLA_FIRMA
		{
			get { return _a_sola_firma; }
			set { _a_sola_firma = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@SALDO=");
			dynStr.Append(IsSALDONull ? (object)"<NULL>" : SALDO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_PAGO=");
			dynStr.Append(IsFECHA_PAGONull ? (object)"<NULL>" : FECHA_PAGO);
			dynStr.Append("@CBA@DIAS_ATRASO=");
			dynStr.Append(IsDIAS_ATRASONull ? (object)"<NULL>" : DIAS_ATRASO);
			dynStr.Append("@CBA@FECHA_OTORGAMIENTO=");
			dynStr.Append(IsFECHA_OTORGAMIENTONull ? (object)"<NULL>" : FECHA_OTORGAMIENTO);
			dynStr.Append("@CBA@PAGOS_FINALIZADOS=");
			dynStr.Append(PAGOS_FINALIZADOS);
			dynStr.Append("@CBA@CANTIDAD_VENCIMIENTOS=");
			dynStr.Append(IsCANTIDAD_VENCIMIENTOSNull ? (object)"<NULL>" : CANTIDAD_VENCIMIENTOS);
			dynStr.Append("@CBA@A_SOLA_FIRMA=");
			dynStr.Append(A_SOLA_FIRMA);
			return dynStr.ToString();
		}
	} // End of CTACTE_PERSONAS_CALIDAD_PAGOSRow_Base class
} // End of namespace
