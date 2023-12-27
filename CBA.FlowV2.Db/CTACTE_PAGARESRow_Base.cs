// <fileinfo name="CTACTE_PAGARESRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARESRow"/> that 
	/// represents a record in the <c>CTACTE_PAGARES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGARESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARESRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _usuario_id;
		private decimal _persona_id;
		private System.DateTime _fecha;
		private decimal _cantidad_pagares;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private string _nombre_deudor;
		private string _documento_deudor;
		private string _telefono_deudor;
		private string _direccion_deudor;
		private string _nombre_codeudor;
		private string _documento_codeudor;
		private string _telefono_codeudor;
		private string _direccion_codeudor;
		private string _nombre_beneficiario;
		private string _documento_beneficiario;
		private string _telefono_beneficiario;
		private string _direccion_beneficiario;
		private System.DateTime _fecha_emision;
		private System.DateTime _fecha_firma;
		private bool _fecha_firmaNull = true;
		private System.DateTime _fecha_anulado;
		private bool _fecha_anuladoNull = true;
		private decimal _usuario_anulado_id;
		private bool _usuario_anulado_idNull = true;
		private string _juego_pagares_aprobado;
		private string _estado;
		private string _garantia;
		private decimal _caso_garantia_id;
		private bool _caso_garantia_idNull = true;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARESRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGARESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGARESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.CANTIDAD_PAGARES != original.CANTIDAD_PAGARES) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.NOMBRE_DEUDOR != original.NOMBRE_DEUDOR) return true;
			if (this.DOCUMENTO_DEUDOR != original.DOCUMENTO_DEUDOR) return true;
			if (this.TELEFONO_DEUDOR != original.TELEFONO_DEUDOR) return true;
			if (this.DIRECCION_DEUDOR != original.DIRECCION_DEUDOR) return true;
			if (this.NOMBRE_CODEUDOR != original.NOMBRE_CODEUDOR) return true;
			if (this.DOCUMENTO_CODEUDOR != original.DOCUMENTO_CODEUDOR) return true;
			if (this.TELEFONO_CODEUDOR != original.TELEFONO_CODEUDOR) return true;
			if (this.DIRECCION_CODEUDOR != original.DIRECCION_CODEUDOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.DOCUMENTO_BENEFICIARIO != original.DOCUMENTO_BENEFICIARIO) return true;
			if (this.TELEFONO_BENEFICIARIO != original.TELEFONO_BENEFICIARIO) return true;
			if (this.DIRECCION_BENEFICIARIO != original.DIRECCION_BENEFICIARIO) return true;
			if (this.FECHA_EMISION != original.FECHA_EMISION) return true;
			if (this.IsFECHA_FIRMANull != original.IsFECHA_FIRMANull) return true;
			if (!this.IsFECHA_FIRMANull && !original.IsFECHA_FIRMANull)
				if (this.FECHA_FIRMA != original.FECHA_FIRMA) return true;
			if (this.IsFECHA_ANULADONull != original.IsFECHA_ANULADONull) return true;
			if (!this.IsFECHA_ANULADONull && !original.IsFECHA_ANULADONull)
				if (this.FECHA_ANULADO != original.FECHA_ANULADO) return true;
			if (this.IsUSUARIO_ANULADO_IDNull != original.IsUSUARIO_ANULADO_IDNull) return true;
			if (!this.IsUSUARIO_ANULADO_IDNull && !original.IsUSUARIO_ANULADO_IDNull)
				if (this.USUARIO_ANULADO_ID != original.USUARIO_ANULADO_ID) return true;
			if (this.JUEGO_PAGARES_APROBADO != original.JUEGO_PAGARES_APROBADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.GARANTIA != original.GARANTIA) return true;
			if (this.IsCASO_GARANTIA_IDNull != original.IsCASO_GARANTIA_IDNull) return true;
			if (!this.IsCASO_GARANTIA_IDNull && !original.IsCASO_GARANTIA_IDNull)
				if (this.CASO_GARANTIA_ID != original.CASO_GARANTIA_ID) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_PAGARES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_PAGARES</c> column value.</value>
		public decimal CANTIDAD_PAGARES
		{
			get { return _cantidad_pagares; }
			set { _cantidad_pagares = value; }
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
		/// Gets or sets the <c>NOMBRE_DEUDOR</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_DEUDOR</c> column value.</value>
		public string NOMBRE_DEUDOR
		{
			get { return _nombre_deudor; }
			set { _nombre_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOCUMENTO_DEUDOR</c> column value.
		/// </summary>
		/// <value>The <c>DOCUMENTO_DEUDOR</c> column value.</value>
		public string DOCUMENTO_DEUDOR
		{
			get { return _documento_deudor; }
			set { _documento_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_DEUDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_DEUDOR</c> column value.</value>
		public string TELEFONO_DEUDOR
		{
			get { return _telefono_deudor; }
			set { _telefono_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_DEUDOR</c> column value.
		/// </summary>
		/// <value>The <c>DIRECCION_DEUDOR</c> column value.</value>
		public string DIRECCION_DEUDOR
		{
			get { return _direccion_deudor; }
			set { _direccion_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_CODEUDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_CODEUDOR</c> column value.</value>
		public string NOMBRE_CODEUDOR
		{
			get { return _nombre_codeudor; }
			set { _nombre_codeudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOCUMENTO_CODEUDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DOCUMENTO_CODEUDOR</c> column value.</value>
		public string DOCUMENTO_CODEUDOR
		{
			get { return _documento_codeudor; }
			set { _documento_codeudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_CODEUDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_CODEUDOR</c> column value.</value>
		public string TELEFONO_CODEUDOR
		{
			get { return _telefono_codeudor; }
			set { _telefono_codeudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_CODEUDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_CODEUDOR</c> column value.</value>
		public string DIRECCION_CODEUDOR
		{
			get { return _direccion_codeudor; }
			set { _direccion_codeudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOCUMENTO_BENEFICIARIO</c> column value.
		/// </summary>
		/// <value>The <c>DOCUMENTO_BENEFICIARIO</c> column value.</value>
		public string DOCUMENTO_BENEFICIARIO
		{
			get { return _documento_beneficiario; }
			set { _documento_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_BENEFICIARIO</c> column value.
		/// </summary>
		/// <value>The <c>TELEFONO_BENEFICIARIO</c> column value.</value>
		public string TELEFONO_BENEFICIARIO
		{
			get { return _telefono_beneficiario; }
			set { _telefono_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_BENEFICIARIO</c> column value.
		/// </summary>
		/// <value>The <c>DIRECCION_BENEFICIARIO</c> column value.</value>
		public string DIRECCION_BENEFICIARIO
		{
			get { return _direccion_beneficiario; }
			set { _direccion_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_EMISION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_EMISION</c> column value.</value>
		public System.DateTime FECHA_EMISION
		{
			get { return _fecha_emision; }
			set { _fecha_emision = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIRMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIRMA</c> column value.</value>
		public System.DateTime FECHA_FIRMA
		{
			get
			{
				if(IsFECHA_FIRMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_firma;
			}
			set
			{
				_fecha_firmaNull = false;
				_fecha_firma = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIRMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FIRMANull
		{
			get { return _fecha_firmaNull; }
			set { _fecha_firmaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ANULADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ANULADO</c> column value.</value>
		public System.DateTime FECHA_ANULADO
		{
			get
			{
				if(IsFECHA_ANULADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_anulado;
			}
			set
			{
				_fecha_anuladoNull = false;
				_fecha_anulado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ANULADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ANULADONull
		{
			get { return _fecha_anuladoNull; }
			set { _fecha_anuladoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ANULADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ANULADO_ID</c> column value.</value>
		public decimal USUARIO_ANULADO_ID
		{
			get
			{
				if(IsUSUARIO_ANULADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_anulado_id;
			}
			set
			{
				_usuario_anulado_idNull = false;
				_usuario_anulado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ANULADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ANULADO_IDNull
		{
			get { return _usuario_anulado_idNull; }
			set { _usuario_anulado_idNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GARANTIA</c> column value.
		/// </summary>
		/// <value>The <c>GARANTIA</c> column value.</value>
		public string GARANTIA
		{
			get { return _garantia; }
			set { _garantia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_GARANTIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_GARANTIA_ID</c> column value.</value>
		public decimal CASO_GARANTIA_ID
		{
			get
			{
				if(IsCASO_GARANTIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_garantia_id;
			}
			set
			{
				_caso_garantia_idNull = false;
				_caso_garantia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_GARANTIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_GARANTIA_IDNull
		{
			get { return _caso_garantia_idNull; }
			set { _caso_garantia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CANTIDAD_PAGARES=");
			dynStr.Append(CANTIDAD_PAGARES);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@NOMBRE_DEUDOR=");
			dynStr.Append(NOMBRE_DEUDOR);
			dynStr.Append("@CBA@DOCUMENTO_DEUDOR=");
			dynStr.Append(DOCUMENTO_DEUDOR);
			dynStr.Append("@CBA@TELEFONO_DEUDOR=");
			dynStr.Append(TELEFONO_DEUDOR);
			dynStr.Append("@CBA@DIRECCION_DEUDOR=");
			dynStr.Append(DIRECCION_DEUDOR);
			dynStr.Append("@CBA@NOMBRE_CODEUDOR=");
			dynStr.Append(NOMBRE_CODEUDOR);
			dynStr.Append("@CBA@DOCUMENTO_CODEUDOR=");
			dynStr.Append(DOCUMENTO_CODEUDOR);
			dynStr.Append("@CBA@TELEFONO_CODEUDOR=");
			dynStr.Append(TELEFONO_CODEUDOR);
			dynStr.Append("@CBA@DIRECCION_CODEUDOR=");
			dynStr.Append(DIRECCION_CODEUDOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@DOCUMENTO_BENEFICIARIO=");
			dynStr.Append(DOCUMENTO_BENEFICIARIO);
			dynStr.Append("@CBA@TELEFONO_BENEFICIARIO=");
			dynStr.Append(TELEFONO_BENEFICIARIO);
			dynStr.Append("@CBA@DIRECCION_BENEFICIARIO=");
			dynStr.Append(DIRECCION_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_EMISION=");
			dynStr.Append(FECHA_EMISION);
			dynStr.Append("@CBA@FECHA_FIRMA=");
			dynStr.Append(IsFECHA_FIRMANull ? (object)"<NULL>" : FECHA_FIRMA);
			dynStr.Append("@CBA@FECHA_ANULADO=");
			dynStr.Append(IsFECHA_ANULADONull ? (object)"<NULL>" : FECHA_ANULADO);
			dynStr.Append("@CBA@USUARIO_ANULADO_ID=");
			dynStr.Append(IsUSUARIO_ANULADO_IDNull ? (object)"<NULL>" : USUARIO_ANULADO_ID);
			dynStr.Append("@CBA@JUEGO_PAGARES_APROBADO=");
			dynStr.Append(JUEGO_PAGARES_APROBADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@GARANTIA=");
			dynStr.Append(GARANTIA);
			dynStr.Append("@CBA@CASO_GARANTIA_ID=");
			dynStr.Append(IsCASO_GARANTIA_IDNull ? (object)"<NULL>" : CASO_GARANTIA_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGARESRow_Base class
} // End of namespace
