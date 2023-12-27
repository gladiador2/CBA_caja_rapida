// <fileinfo name="PAGO_CONTRATISTAS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> that 
	/// represents a record in the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PAGO_CONTRATISTAS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PAGO_CONTRATISTAS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _pago_contratista_id;
		private System.DateTime _fecha_desde;
		private bool _fecha_desdeNull = true;
		private System.DateTime _fecha_hasta;
		private bool _fecha_hastaNull = true;
		private decimal _certificado_nro;
		private bool _certificado_nroNull = true;
		private string _certificado;
		private decimal _certificado_monto;
		private decimal _fondo_fijo;
		private decimal _fondo_fijo_pagado;
		private decimal _facturas_proveedor;
		private decimal _facturas_proveedor_pagado;
		private decimal _adelantos;
		private decimal _adelantos_pagados;
		private decimal _adelanto_inicial;
		private decimal _fondo_reparo;
		private decimal _total;
		private decimal _total_iva;
		private decimal _retencion;
		private decimal _total_pagar;
		private decimal _porcentaje_fondo_reparo;
		private bool _porcentaje_fondo_reparoNull = true;
		private decimal _caso_relacionado_id;
		private bool _caso_relacionado_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PAGO_CONTRATISTAS_DETALLESRow_Base"/> class.
		/// </summary>
		public PAGO_CONTRATISTAS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PAGO_CONTRATISTAS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PAGO_CONTRATISTA_ID != original.PAGO_CONTRATISTA_ID) return true;
			if (this.IsFECHA_DESDENull != original.IsFECHA_DESDENull) return true;
			if (!this.IsFECHA_DESDENull && !original.IsFECHA_DESDENull)
				if (this.FECHA_DESDE != original.FECHA_DESDE) return true;
			if (this.IsFECHA_HASTANull != original.IsFECHA_HASTANull) return true;
			if (!this.IsFECHA_HASTANull && !original.IsFECHA_HASTANull)
				if (this.FECHA_HASTA != original.FECHA_HASTA) return true;
			if (this.IsCERTIFICADO_NRONull != original.IsCERTIFICADO_NRONull) return true;
			if (!this.IsCERTIFICADO_NRONull && !original.IsCERTIFICADO_NRONull)
				if (this.CERTIFICADO_NRO != original.CERTIFICADO_NRO) return true;
			if (this.CERTIFICADO != original.CERTIFICADO) return true;
			if (this.CERTIFICADO_MONTO != original.CERTIFICADO_MONTO) return true;
			if (this.FONDO_FIJO != original.FONDO_FIJO) return true;
			if (this.FONDO_FIJO_PAGADO != original.FONDO_FIJO_PAGADO) return true;
			if (this.FACTURAS_PROVEEDOR != original.FACTURAS_PROVEEDOR) return true;
			if (this.FACTURAS_PROVEEDOR_PAGADO != original.FACTURAS_PROVEEDOR_PAGADO) return true;
			if (this.ADELANTOS != original.ADELANTOS) return true;
			if (this.ADELANTOS_PAGADOS != original.ADELANTOS_PAGADOS) return true;
			if (this.ADELANTO_INICIAL != original.ADELANTO_INICIAL) return true;
			if (this.FONDO_REPARO != original.FONDO_REPARO) return true;
			if (this.TOTAL != original.TOTAL) return true;
			if (this.TOTAL_IVA != original.TOTAL_IVA) return true;
			if (this.RETENCION != original.RETENCION) return true;
			if (this.TOTAL_PAGAR != original.TOTAL_PAGAR) return true;
			if (this.IsPORCENTAJE_FONDO_REPARONull != original.IsPORCENTAJE_FONDO_REPARONull) return true;
			if (!this.IsPORCENTAJE_FONDO_REPARONull && !original.IsPORCENTAJE_FONDO_REPARONull)
				if (this.PORCENTAJE_FONDO_REPARO != original.PORCENTAJE_FONDO_REPARO) return true;
			if (this.IsCASO_RELACIONADO_IDNull != original.IsCASO_RELACIONADO_IDNull) return true;
			if (!this.IsCASO_RELACIONADO_IDNull && !original.IsCASO_RELACIONADO_IDNull)
				if (this.CASO_RELACIONADO_ID != original.CASO_RELACIONADO_ID) return true;
			
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
		/// Gets or sets the <c>PAGO_CONTRATISTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAGO_CONTRATISTA_ID</c> column value.</value>
		public decimal PAGO_CONTRATISTA_ID
		{
			get { return _pago_contratista_id; }
			set { _pago_contratista_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESDE</c> column value.</value>
		public System.DateTime FECHA_DESDE
		{
			get
			{
				if(IsFECHA_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desde;
			}
			set
			{
				_fecha_desdeNull = false;
				_fecha_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESDENull
		{
			get { return _fecha_desdeNull; }
			set { _fecha_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HASTA</c> column value.</value>
		public System.DateTime FECHA_HASTA
		{
			get
			{
				if(IsFECHA_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hasta;
			}
			set
			{
				_fecha_hastaNull = false;
				_fecha_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HASTANull
		{
			get { return _fecha_hastaNull; }
			set { _fecha_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CERTIFICADO_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CERTIFICADO_NRO</c> column value.</value>
		public decimal CERTIFICADO_NRO
		{
			get
			{
				if(IsCERTIFICADO_NRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _certificado_nro;
			}
			set
			{
				_certificado_nroNull = false;
				_certificado_nro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CERTIFICADO_NRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCERTIFICADO_NRONull
		{
			get { return _certificado_nroNull; }
			set { _certificado_nroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CERTIFICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CERTIFICADO</c> column value.</value>
		public string CERTIFICADO
		{
			get { return _certificado; }
			set { _certificado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CERTIFICADO_MONTO</c> column value.
		/// </summary>
		/// <value>The <c>CERTIFICADO_MONTO</c> column value.</value>
		public decimal CERTIFICADO_MONTO
		{
			get { return _certificado_monto; }
			set { _certificado_monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_FIJO</c> column value.
		/// </summary>
		/// <value>The <c>FONDO_FIJO</c> column value.</value>
		public decimal FONDO_FIJO
		{
			get { return _fondo_fijo; }
			set { _fondo_fijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_FIJO_PAGADO</c> column value.
		/// </summary>
		/// <value>The <c>FONDO_FIJO_PAGADO</c> column value.</value>
		public decimal FONDO_FIJO_PAGADO
		{
			get { return _fondo_fijo_pagado; }
			set { _fondo_fijo_pagado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAS_PROVEEDOR</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAS_PROVEEDOR</c> column value.</value>
		public decimal FACTURAS_PROVEEDOR
		{
			get { return _facturas_proveedor; }
			set { _facturas_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAS_PROVEEDOR_PAGADO</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAS_PROVEEDOR_PAGADO</c> column value.</value>
		public decimal FACTURAS_PROVEEDOR_PAGADO
		{
			get { return _facturas_proveedor_pagado; }
			set { _facturas_proveedor_pagado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ADELANTOS</c> column value.
		/// </summary>
		/// <value>The <c>ADELANTOS</c> column value.</value>
		public decimal ADELANTOS
		{
			get { return _adelantos; }
			set { _adelantos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ADELANTOS_PAGADOS</c> column value.
		/// </summary>
		/// <value>The <c>ADELANTOS_PAGADOS</c> column value.</value>
		public decimal ADELANTOS_PAGADOS
		{
			get { return _adelantos_pagados; }
			set { _adelantos_pagados = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ADELANTO_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>ADELANTO_INICIAL</c> column value.</value>
		public decimal ADELANTO_INICIAL
		{
			get { return _adelanto_inicial; }
			set { _adelanto_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO_REPARO</c> column value.
		/// </summary>
		/// <value>The <c>FONDO_REPARO</c> column value.</value>
		public decimal FONDO_REPARO
		{
			get { return _fondo_reparo; }
			set { _fondo_reparo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get { return _total; }
			set { _total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IVA</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_IVA</c> column value.</value>
		public decimal TOTAL_IVA
		{
			get { return _total_iva; }
			set { _total_iva = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>RETENCION</c> column value.</value>
		public decimal RETENCION
		{
			get { return _retencion; }
			set { _retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_PAGAR</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_PAGAR</c> column value.</value>
		public decimal TOTAL_PAGAR
		{
			get { return _total_pagar; }
			set { _total_pagar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_FONDO_REPARO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_FONDO_REPARO</c> column value.</value>
		public decimal PORCENTAJE_FONDO_REPARO
		{
			get
			{
				if(IsPORCENTAJE_FONDO_REPARONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_fondo_reparo;
			}
			set
			{
				_porcentaje_fondo_reparoNull = false;
				_porcentaje_fondo_reparo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_FONDO_REPARO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_FONDO_REPARONull
		{
			get { return _porcentaje_fondo_reparoNull; }
			set { _porcentaje_fondo_reparoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELACIONADO_ID</c> column value.</value>
		public decimal CASO_RELACIONADO_ID
		{
			get
			{
				if(IsCASO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_relacionado_id;
			}
			set
			{
				_caso_relacionado_idNull = false;
				_caso_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_RELACIONADO_IDNull
		{
			get { return _caso_relacionado_idNull; }
			set { _caso_relacionado_idNull = value; }
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
			dynStr.Append("@CBA@PAGO_CONTRATISTA_ID=");
			dynStr.Append(PAGO_CONTRATISTA_ID);
			dynStr.Append("@CBA@FECHA_DESDE=");
			dynStr.Append(IsFECHA_DESDENull ? (object)"<NULL>" : FECHA_DESDE);
			dynStr.Append("@CBA@FECHA_HASTA=");
			dynStr.Append(IsFECHA_HASTANull ? (object)"<NULL>" : FECHA_HASTA);
			dynStr.Append("@CBA@CERTIFICADO_NRO=");
			dynStr.Append(IsCERTIFICADO_NRONull ? (object)"<NULL>" : CERTIFICADO_NRO);
			dynStr.Append("@CBA@CERTIFICADO=");
			dynStr.Append(CERTIFICADO);
			dynStr.Append("@CBA@CERTIFICADO_MONTO=");
			dynStr.Append(CERTIFICADO_MONTO);
			dynStr.Append("@CBA@FONDO_FIJO=");
			dynStr.Append(FONDO_FIJO);
			dynStr.Append("@CBA@FONDO_FIJO_PAGADO=");
			dynStr.Append(FONDO_FIJO_PAGADO);
			dynStr.Append("@CBA@FACTURAS_PROVEEDOR=");
			dynStr.Append(FACTURAS_PROVEEDOR);
			dynStr.Append("@CBA@FACTURAS_PROVEEDOR_PAGADO=");
			dynStr.Append(FACTURAS_PROVEEDOR_PAGADO);
			dynStr.Append("@CBA@ADELANTOS=");
			dynStr.Append(ADELANTOS);
			dynStr.Append("@CBA@ADELANTOS_PAGADOS=");
			dynStr.Append(ADELANTOS_PAGADOS);
			dynStr.Append("@CBA@ADELANTO_INICIAL=");
			dynStr.Append(ADELANTO_INICIAL);
			dynStr.Append("@CBA@FONDO_REPARO=");
			dynStr.Append(FONDO_REPARO);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(TOTAL);
			dynStr.Append("@CBA@TOTAL_IVA=");
			dynStr.Append(TOTAL_IVA);
			dynStr.Append("@CBA@RETENCION=");
			dynStr.Append(RETENCION);
			dynStr.Append("@CBA@TOTAL_PAGAR=");
			dynStr.Append(TOTAL_PAGAR);
			dynStr.Append("@CBA@PORCENTAJE_FONDO_REPARO=");
			dynStr.Append(IsPORCENTAJE_FONDO_REPARONull ? (object)"<NULL>" : PORCENTAJE_FONDO_REPARO);
			dynStr.Append("@CBA@CASO_RELACIONADO_ID=");
			dynStr.Append(IsCASO_RELACIONADO_IDNull ? (object)"<NULL>" : CASO_RELACIONADO_ID);
			return dynStr.ToString();
		}
	} // End of PAGO_CONTRATISTAS_DETALLESRow_Base class
} // End of namespace
