// <fileinfo name="CTACTE_PAGOS_PERSONARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERSONARow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PERSONA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PERSONARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERSONARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _ctacte_recibo_id;
		private bool _ctacte_recibo_idNull = true;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private System.DateTime _fecha;
		private decimal _usuario_carga_id;
		private decimal _funcionario_cobrador_id;
		private decimal _moneda_total_vuelto_id;
		private decimal _cotizacion_moneda_total_vuelto;
		private decimal _monto_total_vuelto;
		private string _vuelto_convertido_a_anticipo;
		private decimal _caso_anticipo_id;
		private bool _caso_anticipo_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private string _pago_confirmado;
		private decimal _fc_cliente1_comprobante_id;
		private bool _fc_cliente1_comprobante_idNull = true;
		private decimal _fc_cliente1_comp_auton_id;
		private bool _fc_cliente1_comp_auton_idNull = true;
		private decimal _fc_cliente2_comprobante_id;
		private bool _fc_cliente2_comprobante_idNull = true;
		private decimal _fc_cliente2_comp_auton_id;
		private bool _fc_cliente2_comp_auton_idNull = true;
		private System.DateTime _fecha_confirmacion;
		private bool _fecha_confirmacionNull = true;
		private string _recibo_emitir_por_documentos;
		private decimal _autonumeracion_recibo_id;
		private bool _autonumeracion_recibo_idNull = true;
		private decimal _autonumeracion_anticipo_id;
		private bool _autonumeracion_anticipo_idNull = true;
		private string _ctacte_recibo_numero;
		private decimal _funcionario_cobrador_exter_id;
		private bool _funcionario_cobrador_exter_idNull = true;
		private string _estado;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERSONARow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PERSONARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PERSONARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCTACTE_RECIBO_IDNull != original.IsCTACTE_RECIBO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_IDNull && !original.IsCTACTE_RECIBO_IDNull)
				if (this.CTACTE_RECIBO_ID != original.CTACTE_RECIBO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.USUARIO_CARGA_ID != original.USUARIO_CARGA_ID) return true;
			if (this.FUNCIONARIO_COBRADOR_ID != original.FUNCIONARIO_COBRADOR_ID) return true;
			if (this.MONEDA_TOTAL_VUELTO_ID != original.MONEDA_TOTAL_VUELTO_ID) return true;
			if (this.COTIZACION_MONEDA_TOTAL_VUELTO != original.COTIZACION_MONEDA_TOTAL_VUELTO) return true;
			if (this.MONTO_TOTAL_VUELTO != original.MONTO_TOTAL_VUELTO) return true;
			if (this.VUELTO_CONVERTIDO_A_ANTICIPO != original.VUELTO_CONVERTIDO_A_ANTICIPO) return true;
			if (this.IsCASO_ANTICIPO_IDNull != original.IsCASO_ANTICIPO_IDNull) return true;
			if (!this.IsCASO_ANTICIPO_IDNull && !original.IsCASO_ANTICIPO_IDNull)
				if (this.CASO_ANTICIPO_ID != original.CASO_ANTICIPO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.PAGO_CONFIRMADO != original.PAGO_CONFIRMADO) return true;
			if (this.IsFC_CLIENTE1_COMPROBANTE_IDNull != original.IsFC_CLIENTE1_COMPROBANTE_IDNull) return true;
			if (!this.IsFC_CLIENTE1_COMPROBANTE_IDNull && !original.IsFC_CLIENTE1_COMPROBANTE_IDNull)
				if (this.FC_CLIENTE1_COMPROBANTE_ID != original.FC_CLIENTE1_COMPROBANTE_ID) return true;
			if (this.IsFC_CLIENTE1_COMP_AUTON_IDNull != original.IsFC_CLIENTE1_COMP_AUTON_IDNull) return true;
			if (!this.IsFC_CLIENTE1_COMP_AUTON_IDNull && !original.IsFC_CLIENTE1_COMP_AUTON_IDNull)
				if (this.FC_CLIENTE1_COMP_AUTON_ID != original.FC_CLIENTE1_COMP_AUTON_ID) return true;
			if (this.IsFC_CLIENTE2_COMPROBANTE_IDNull != original.IsFC_CLIENTE2_COMPROBANTE_IDNull) return true;
			if (!this.IsFC_CLIENTE2_COMPROBANTE_IDNull && !original.IsFC_CLIENTE2_COMPROBANTE_IDNull)
				if (this.FC_CLIENTE2_COMPROBANTE_ID != original.FC_CLIENTE2_COMPROBANTE_ID) return true;
			if (this.IsFC_CLIENTE2_COMP_AUTON_IDNull != original.IsFC_CLIENTE2_COMP_AUTON_IDNull) return true;
			if (!this.IsFC_CLIENTE2_COMP_AUTON_IDNull && !original.IsFC_CLIENTE2_COMP_AUTON_IDNull)
				if (this.FC_CLIENTE2_COMP_AUTON_ID != original.FC_CLIENTE2_COMP_AUTON_ID) return true;
			if (this.IsFECHA_CONFIRMACIONNull != original.IsFECHA_CONFIRMACIONNull) return true;
			if (!this.IsFECHA_CONFIRMACIONNull && !original.IsFECHA_CONFIRMACIONNull)
				if (this.FECHA_CONFIRMACION != original.FECHA_CONFIRMACION) return true;
			if (this.RECIBO_EMITIR_POR_DOCUMENTOS != original.RECIBO_EMITIR_POR_DOCUMENTOS) return true;
			if (this.IsAUTONUMERACION_RECIBO_IDNull != original.IsAUTONUMERACION_RECIBO_IDNull) return true;
			if (!this.IsAUTONUMERACION_RECIBO_IDNull && !original.IsAUTONUMERACION_RECIBO_IDNull)
				if (this.AUTONUMERACION_RECIBO_ID != original.AUTONUMERACION_RECIBO_ID) return true;
			if (this.IsAUTONUMERACION_ANTICIPO_IDNull != original.IsAUTONUMERACION_ANTICIPO_IDNull) return true;
			if (!this.IsAUTONUMERACION_ANTICIPO_IDNull && !original.IsAUTONUMERACION_ANTICIPO_IDNull)
				if (this.AUTONUMERACION_ANTICIPO_ID != original.AUTONUMERACION_ANTICIPO_ID) return true;
			if (this.CTACTE_RECIBO_NUMERO != original.CTACTE_RECIBO_NUMERO) return true;
			if (this.IsFUNCIONARIO_COBRADOR_EXTER_IDNull != original.IsFUNCIONARIO_COBRADOR_EXTER_IDNull) return true;
			if (!this.IsFUNCIONARIO_COBRADOR_EXTER_IDNull && !original.IsFUNCIONARIO_COBRADOR_EXTER_IDNull)
				if (this.FUNCIONARIO_COBRADOR_EXTER_ID != original.FUNCIONARIO_COBRADOR_EXTER_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
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
		/// Gets or sets the <c>USUARIO_CARGA_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CARGA_ID</c> column value.</value>
		public decimal USUARIO_CARGA_ID
		{
			get { return _usuario_carga_id; }
			set { _usuario_carga_id = value; }
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
		/// Gets or sets the <c>MONEDA_TOTAL_VUELTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_TOTAL_VUELTO_ID</c> column value.</value>
		public decimal MONEDA_TOTAL_VUELTO_ID
		{
			get { return _moneda_total_vuelto_id; }
			set { _moneda_total_vuelto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_TOTAL_VUELTO</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_TOTAL_VUELTO</c> column value.</value>
		public decimal COTIZACION_MONEDA_TOTAL_VUELTO
		{
			get { return _cotizacion_moneda_total_vuelto; }
			set { _cotizacion_moneda_total_vuelto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL_VUELTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_VUELTO</c> column value.</value>
		public decimal MONTO_TOTAL_VUELTO
		{
			get { return _monto_total_vuelto; }
			set { _monto_total_vuelto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VUELTO_CONVERTIDO_A_ANTICIPO</c> column value.
		/// </summary>
		/// <value>The <c>VUELTO_CONVERTIDO_A_ANTICIPO</c> column value.</value>
		public string VUELTO_CONVERTIDO_A_ANTICIPO
		{
			get { return _vuelto_convertido_a_anticipo; }
			set { _vuelto_convertido_a_anticipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ANTICIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ANTICIPO_ID</c> column value.</value>
		public decimal CASO_ANTICIPO_ID
		{
			get
			{
				if(IsCASO_ANTICIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_anticipo_id;
			}
			set
			{
				_caso_anticipo_idNull = false;
				_caso_anticipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ANTICIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ANTICIPO_IDNull
		{
			get { return _caso_anticipo_idNull; }
			set { _caso_anticipo_idNull = value; }
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
		/// Gets or sets the <c>PAGO_CONFIRMADO</c> column value.
		/// </summary>
		/// <value>The <c>PAGO_CONFIRMADO</c> column value.</value>
		public string PAGO_CONFIRMADO
		{
			get { return _pago_confirmado; }
			set { _pago_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CLIENTE1_COMPROBANTE_ID</c> column value.</value>
		public decimal FC_CLIENTE1_COMPROBANTE_ID
		{
			get
			{
				if(IsFC_CLIENTE1_COMPROBANTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_cliente1_comprobante_id;
			}
			set
			{
				_fc_cliente1_comprobante_idNull = false;
				_fc_cliente1_comprobante_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CLIENTE1_COMPROBANTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CLIENTE1_COMPROBANTE_IDNull
		{
			get { return _fc_cliente1_comprobante_idNull; }
			set { _fc_cliente1_comprobante_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CLIENTE1_COMP_AUTON_ID</c> column value.</value>
		public decimal FC_CLIENTE1_COMP_AUTON_ID
		{
			get
			{
				if(IsFC_CLIENTE1_COMP_AUTON_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_cliente1_comp_auton_id;
			}
			set
			{
				_fc_cliente1_comp_auton_idNull = false;
				_fc_cliente1_comp_auton_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CLIENTE1_COMP_AUTON_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CLIENTE1_COMP_AUTON_IDNull
		{
			get { return _fc_cliente1_comp_auton_idNull; }
			set { _fc_cliente1_comp_auton_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CLIENTE2_COMPROBANTE_ID</c> column value.</value>
		public decimal FC_CLIENTE2_COMPROBANTE_ID
		{
			get
			{
				if(IsFC_CLIENTE2_COMPROBANTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_cliente2_comprobante_id;
			}
			set
			{
				_fc_cliente2_comprobante_idNull = false;
				_fc_cliente2_comprobante_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CLIENTE2_COMPROBANTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CLIENTE2_COMPROBANTE_IDNull
		{
			get { return _fc_cliente2_comprobante_idNull; }
			set { _fc_cliente2_comprobante_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CLIENTE2_COMP_AUTON_ID</c> column value.</value>
		public decimal FC_CLIENTE2_COMP_AUTON_ID
		{
			get
			{
				if(IsFC_CLIENTE2_COMP_AUTON_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_cliente2_comp_auton_id;
			}
			set
			{
				_fc_cliente2_comp_auton_idNull = false;
				_fc_cliente2_comp_auton_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CLIENTE2_COMP_AUTON_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CLIENTE2_COMP_AUTON_IDNull
		{
			get { return _fc_cliente2_comp_auton_idNull; }
			set { _fc_cliente2_comp_auton_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CONFIRMACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CONFIRMACION</c> column value.</value>
		public System.DateTime FECHA_CONFIRMACION
		{
			get
			{
				if(IsFECHA_CONFIRMACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_confirmacion;
			}
			set
			{
				_fecha_confirmacionNull = false;
				_fecha_confirmacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CONFIRMACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CONFIRMACIONNull
		{
			get { return _fecha_confirmacionNull; }
			set { _fecha_confirmacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_EMITIR_POR_DOCUMENTOS</c> column value.
		/// </summary>
		/// <value>The <c>RECIBO_EMITIR_POR_DOCUMENTOS</c> column value.</value>
		public string RECIBO_EMITIR_POR_DOCUMENTOS
		{
			get { return _recibo_emitir_por_documentos; }
			set { _recibo_emitir_por_documentos = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_ANTICIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ANTICIPO_ID</c> column value.</value>
		public decimal AUTONUMERACION_ANTICIPO_ID
		{
			get
			{
				if(IsAUTONUMERACION_ANTICIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_anticipo_id;
			}
			set
			{
				_autonumeracion_anticipo_idNull = false;
				_autonumeracion_anticipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ANTICIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_ANTICIPO_IDNull
		{
			get { return _autonumeracion_anticipo_idNull; }
			set { _autonumeracion_anticipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_NUMERO</c> column value.</value>
		public string CTACTE_RECIBO_NUMERO
		{
			get { return _ctacte_recibo_numero; }
			set { _ctacte_recibo_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_COBRADOR_EXTER_ID</c> column value.</value>
		public decimal FUNCIONARIO_COBRADOR_EXTER_ID
		{
			get
			{
				if(IsFUNCIONARIO_COBRADOR_EXTER_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_cobrador_exter_id;
			}
			set
			{
				_funcionario_cobrador_exter_idNull = false;
				_funcionario_cobrador_exter_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_COBRADOR_EXTER_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_COBRADOR_EXTER_IDNull
		{
			get { return _funcionario_cobrador_exter_idNull; }
			set { _funcionario_cobrador_exter_idNull = value; }
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
			dynStr.Append("@CBA@CTACTE_RECIBO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@USUARIO_CARGA_ID=");
			dynStr.Append(USUARIO_CARGA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_COBRADOR_ID=");
			dynStr.Append(FUNCIONARIO_COBRADOR_ID);
			dynStr.Append("@CBA@MONEDA_TOTAL_VUELTO_ID=");
			dynStr.Append(MONEDA_TOTAL_VUELTO_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_TOTAL_VUELTO=");
			dynStr.Append(COTIZACION_MONEDA_TOTAL_VUELTO);
			dynStr.Append("@CBA@MONTO_TOTAL_VUELTO=");
			dynStr.Append(MONTO_TOTAL_VUELTO);
			dynStr.Append("@CBA@VUELTO_CONVERTIDO_A_ANTICIPO=");
			dynStr.Append(VUELTO_CONVERTIDO_A_ANTICIPO);
			dynStr.Append("@CBA@CASO_ANTICIPO_ID=");
			dynStr.Append(IsCASO_ANTICIPO_IDNull ? (object)"<NULL>" : CASO_ANTICIPO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@PAGO_CONFIRMADO=");
			dynStr.Append(PAGO_CONFIRMADO);
			dynStr.Append("@CBA@FC_CLIENTE1_COMPROBANTE_ID=");
			dynStr.Append(IsFC_CLIENTE1_COMPROBANTE_IDNull ? (object)"<NULL>" : FC_CLIENTE1_COMPROBANTE_ID);
			dynStr.Append("@CBA@FC_CLIENTE1_COMP_AUTON_ID=");
			dynStr.Append(IsFC_CLIENTE1_COMP_AUTON_IDNull ? (object)"<NULL>" : FC_CLIENTE1_COMP_AUTON_ID);
			dynStr.Append("@CBA@FC_CLIENTE2_COMPROBANTE_ID=");
			dynStr.Append(IsFC_CLIENTE2_COMPROBANTE_IDNull ? (object)"<NULL>" : FC_CLIENTE2_COMPROBANTE_ID);
			dynStr.Append("@CBA@FC_CLIENTE2_COMP_AUTON_ID=");
			dynStr.Append(IsFC_CLIENTE2_COMP_AUTON_IDNull ? (object)"<NULL>" : FC_CLIENTE2_COMP_AUTON_ID);
			dynStr.Append("@CBA@FECHA_CONFIRMACION=");
			dynStr.Append(IsFECHA_CONFIRMACIONNull ? (object)"<NULL>" : FECHA_CONFIRMACION);
			dynStr.Append("@CBA@RECIBO_EMITIR_POR_DOCUMENTOS=");
			dynStr.Append(RECIBO_EMITIR_POR_DOCUMENTOS);
			dynStr.Append("@CBA@AUTONUMERACION_RECIBO_ID=");
			dynStr.Append(IsAUTONUMERACION_RECIBO_IDNull ? (object)"<NULL>" : AUTONUMERACION_RECIBO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ANTICIPO_ID=");
			dynStr.Append(IsAUTONUMERACION_ANTICIPO_IDNull ? (object)"<NULL>" : AUTONUMERACION_ANTICIPO_ID);
			dynStr.Append("@CBA@CTACTE_RECIBO_NUMERO=");
			dynStr.Append(CTACTE_RECIBO_NUMERO);
			dynStr.Append("@CBA@FUNCIONARIO_COBRADOR_EXTER_ID=");
			dynStr.Append(IsFUNCIONARIO_COBRADOR_EXTER_IDNull ? (object)"<NULL>" : FUNCIONARIO_COBRADOR_EXTER_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PERSONARow_Base class
} // End of namespace
