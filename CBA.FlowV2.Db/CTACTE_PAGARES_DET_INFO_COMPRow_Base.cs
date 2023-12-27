// <fileinfo name="CTACTE_PAGARES_DET_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARES_DET_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_PAGARES_DET_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGARES_DET_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARES_DET_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagare_id;
		private decimal _numero_pagare;
		private System.DateTime _fecha_vencimiento;
		private decimal _monto_total;
		private decimal _monto_saldo;
		private bool _monto_saldoNull = true;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private string _nro_comprobante;
		private decimal _cantidad_pagares;
		private decimal _persona_id;
		private string _ctacte_pagares_deudor;
		private string _ctacte_pagares_documento;
		private decimal _ctacte_pagares_sucursal;
		private string _ctacte_pagares_estado;
		private decimal _custodia_valores_det_id;
		private bool _custodia_valores_det_idNull = true;
		private decimal _descuento_documento_det_id;
		private bool _descuento_documento_det_idNull = true;
		private string _juego_pagares_aprobado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARES_DET_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGARES_DET_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGARES_DET_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGARE_ID != original.CTACTE_PAGARE_ID) return true;
			if (this.NUMERO_PAGARE != original.NUMERO_PAGARE) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.IsMONTO_SALDONull != original.IsMONTO_SALDONull) return true;
			if (!this.IsMONTO_SALDONull && !original.IsMONTO_SALDONull)
				if (this.MONTO_SALDO != original.MONTO_SALDO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.CANTIDAD_PAGARES != original.CANTIDAD_PAGARES) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.CTACTE_PAGARES_DEUDOR != original.CTACTE_PAGARES_DEUDOR) return true;
			if (this.CTACTE_PAGARES_DOCUMENTO != original.CTACTE_PAGARES_DOCUMENTO) return true;
			if (this.CTACTE_PAGARES_SUCURSAL != original.CTACTE_PAGARES_SUCURSAL) return true;
			if (this.CTACTE_PAGARES_ESTADO != original.CTACTE_PAGARES_ESTADO) return true;
			if (this.IsCUSTODIA_VALORES_DET_IDNull != original.IsCUSTODIA_VALORES_DET_IDNull) return true;
			if (!this.IsCUSTODIA_VALORES_DET_IDNull && !original.IsCUSTODIA_VALORES_DET_IDNull)
				if (this.CUSTODIA_VALORES_DET_ID != original.CUSTODIA_VALORES_DET_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTO_DET_IDNull != original.IsDESCUENTO_DOCUMENTO_DET_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTO_DET_IDNull && !original.IsDESCUENTO_DOCUMENTO_DET_IDNull)
				if (this.DESCUENTO_DOCUMENTO_DET_ID != original.DESCUENTO_DOCUMENTO_DET_ID) return true;
			if (this.JUEGO_PAGARES_APROBADO != original.JUEGO_PAGARES_APROBADO) return true;
			
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
		/// Gets or sets the <c>CTACTE_PAGARE_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_ID
		{
			get { return _ctacte_pagare_id; }
			set { _ctacte_pagare_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_PAGARE</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_PAGARE</c> column value.</value>
		public decimal NUMERO_PAGARE
		{
			get { return _numero_pagare; }
			set { _numero_pagare = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_SALDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_SALDO</c> column value.</value>
		public decimal MONTO_SALDO
		{
			get
			{
				if(IsMONTO_SALDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_saldo;
			}
			set
			{
				_monto_saldoNull = false;
				_monto_saldo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_SALDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_SALDONull
		{
			get { return _monto_saldoNull; }
			set { _monto_saldoNull = value; }
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
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_PAGARES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_PAGARES</c> column value.</value>
		public decimal CANTIDAD_PAGARES
		{
			get { return _cantidad_pagares; }
			set { _cantidad_pagares = value; }
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
		/// Gets or sets the <c>CTACTE_PAGARES_DEUDOR</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARES_DEUDOR</c> column value.</value>
		public string CTACTE_PAGARES_DEUDOR
		{
			get { return _ctacte_pagares_deudor; }
			set { _ctacte_pagares_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARES_DOCUMENTO</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARES_DOCUMENTO</c> column value.</value>
		public string CTACTE_PAGARES_DOCUMENTO
		{
			get { return _ctacte_pagares_documento; }
			set { _ctacte_pagares_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARES_SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARES_SUCURSAL</c> column value.</value>
		public decimal CTACTE_PAGARES_SUCURSAL
		{
			get { return _ctacte_pagares_sucursal; }
			set { _ctacte_pagares_sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARES_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARES_ESTADO</c> column value.</value>
		public string CTACTE_PAGARES_ESTADO
		{
			get { return _ctacte_pagares_estado; }
			set { _ctacte_pagares_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALORES_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALORES_DET_ID</c> column value.</value>
		public decimal CUSTODIA_VALORES_DET_ID
		{
			get
			{
				if(IsCUSTODIA_VALORES_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _custodia_valores_det_id;
			}
			set
			{
				_custodia_valores_det_idNull = false;
				_custodia_valores_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUSTODIA_VALORES_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUSTODIA_VALORES_DET_IDNull
		{
			get { return _custodia_valores_det_idNull; }
			set { _custodia_valores_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_DET_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documento_det_id;
			}
			set
			{
				_descuento_documento_det_idNull = false;
				_descuento_documento_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTO_DET_IDNull
		{
			get { return _descuento_documento_det_idNull; }
			set { _descuento_documento_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>JUEGO_PAGARES_APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>JUEGO_PAGARES_APROBADO</c> column value.</value>
		public string JUEGO_PAGARES_APROBADO
		{
			get { return _juego_pagares_aprobado; }
			set { _juego_pagares_aprobado = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGARE_ID=");
			dynStr.Append(CTACTE_PAGARE_ID);
			dynStr.Append("@CBA@NUMERO_PAGARE=");
			dynStr.Append(NUMERO_PAGARE);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@MONTO_SALDO=");
			dynStr.Append(IsMONTO_SALDONull ? (object)"<NULL>" : MONTO_SALDO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CANTIDAD_PAGARES=");
			dynStr.Append(CANTIDAD_PAGARES);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGARES_DEUDOR=");
			dynStr.Append(CTACTE_PAGARES_DEUDOR);
			dynStr.Append("@CBA@CTACTE_PAGARES_DOCUMENTO=");
			dynStr.Append(CTACTE_PAGARES_DOCUMENTO);
			dynStr.Append("@CBA@CTACTE_PAGARES_SUCURSAL=");
			dynStr.Append(CTACTE_PAGARES_SUCURSAL);
			dynStr.Append("@CBA@CTACTE_PAGARES_ESTADO=");
			dynStr.Append(CTACTE_PAGARES_ESTADO);
			dynStr.Append("@CBA@CUSTODIA_VALORES_DET_ID=");
			dynStr.Append(IsCUSTODIA_VALORES_DET_IDNull ? (object)"<NULL>" : CUSTODIA_VALORES_DET_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_DET_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTO_DET_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTO_DET_ID);
			dynStr.Append("@CBA@JUEGO_PAGARES_APROBADO=");
			dynStr.Append(JUEGO_PAGARES_APROBADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGARES_DET_INFO_COMPRow_Base class
} // End of namespace
