// <fileinfo name="ORDENES_SERVICIORow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIORow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIORow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _texto_predefinido_id;
		private string _titulo;
		private string _descripcion;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _caso_originario_id;
		private bool _caso_originario_idNull = true;
		private string _debe_facturar;
		private string _visto_bueno_funcionario;
		private string _visto_bueno_persona;
		private string _visto_bueno_gerencia;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _es_para_cliente;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private decimal _condicion_pago_id;
		private bool _condicion_pago_idNull = true;
		private string _anticipo_requerido;
		private string _anticipo_generar;
		private decimal _anticipo_monto;
		private bool _anticipo_montoNull = true;
		private string _aplicar_retencion;
		private string _factura_detallada;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIORow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsCASO_ORIGINARIO_IDNull != original.IsCASO_ORIGINARIO_IDNull) return true;
			if (!this.IsCASO_ORIGINARIO_IDNull && !original.IsCASO_ORIGINARIO_IDNull)
				if (this.CASO_ORIGINARIO_ID != original.CASO_ORIGINARIO_ID) return true;
			if (this.DEBE_FACTURAR != original.DEBE_FACTURAR) return true;
			if (this.VISTO_BUENO_FUNCIONARIO != original.VISTO_BUENO_FUNCIONARIO) return true;
			if (this.VISTO_BUENO_PERSONA != original.VISTO_BUENO_PERSONA) return true;
			if (this.VISTO_BUENO_GERENCIA != original.VISTO_BUENO_GERENCIA) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.ES_PARA_CLIENTE != original.ES_PARA_CLIENTE) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.IsCONDICION_PAGO_IDNull != original.IsCONDICION_PAGO_IDNull) return true;
			if (!this.IsCONDICION_PAGO_IDNull && !original.IsCONDICION_PAGO_IDNull)
				if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.ANTICIPO_REQUERIDO != original.ANTICIPO_REQUERIDO) return true;
			if (this.ANTICIPO_GENERAR != original.ANTICIPO_GENERAR) return true;
			if (this.IsANTICIPO_MONTONull != original.IsANTICIPO_MONTONull) return true;
			if (!this.IsANTICIPO_MONTONull && !original.IsANTICIPO_MONTONull)
				if (this.ANTICIPO_MONTO != original.ANTICIPO_MONTO) return true;
			if (this.APLICAR_RETENCION != original.APLICAR_RETENCION) return true;
			if (this.FACTURA_DETALLADA != original.FACTURA_DETALLADA) return true;
			
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULO</c> column value.</value>
		public string TITULO
		{
			get { return _titulo; }
			set { _titulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGINARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGINARIO_ID</c> column value.</value>
		public decimal CASO_ORIGINARIO_ID
		{
			get
			{
				if(IsCASO_ORIGINARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_originario_id;
			}
			set
			{
				_caso_originario_idNull = false;
				_caso_originario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGINARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGINARIO_IDNull
		{
			get { return _caso_originario_idNull; }
			set { _caso_originario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBE_FACTURAR</c> column value.
		/// </summary>
		/// <value>The <c>DEBE_FACTURAR</c> column value.</value>
		public string DEBE_FACTURAR
		{
			get { return _debe_facturar; }
			set { _debe_facturar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VISTO_BUENO_FUNCIONARIO</c> column value.
		/// </summary>
		/// <value>The <c>VISTO_BUENO_FUNCIONARIO</c> column value.</value>
		public string VISTO_BUENO_FUNCIONARIO
		{
			get { return _visto_bueno_funcionario; }
			set { _visto_bueno_funcionario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VISTO_BUENO_PERSONA</c> column value.
		/// </summary>
		/// <value>The <c>VISTO_BUENO_PERSONA</c> column value.</value>
		public string VISTO_BUENO_PERSONA
		{
			get { return _visto_bueno_persona; }
			set { _visto_bueno_persona = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VISTO_BUENO_GERENCIA</c> column value.
		/// </summary>
		/// <value>The <c>VISTO_BUENO_GERENCIA</c> column value.</value>
		public string VISTO_BUENO_GERENCIA
		{
			get { return _visto_bueno_gerencia; }
			set { _visto_bueno_gerencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
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
		/// Gets or sets the <c>ES_PARA_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>ES_PARA_CLIENTE</c> column value.</value>
		public string ES_PARA_CLIENTE
		{
			get { return _es_para_cliente; }
			set { _es_para_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get
			{
				if(IsCONDICION_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_pago_id;
			}
			set
			{
				_condicion_pago_idNull = false;
				_condicion_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_PAGO_IDNull
		{
			get { return _condicion_pago_idNull; }
			set { _condicion_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_REQUERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_REQUERIDO</c> column value.</value>
		public string ANTICIPO_REQUERIDO
		{
			get { return _anticipo_requerido; }
			set { _anticipo_requerido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_GENERAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_GENERAR</c> column value.</value>
		public string ANTICIPO_GENERAR
		{
			get { return _anticipo_generar; }
			set { _anticipo_generar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_MONTO</c> column value.</value>
		public decimal ANTICIPO_MONTO
		{
			get
			{
				if(IsANTICIPO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_monto;
			}
			set
			{
				_anticipo_montoNull = false;
				_anticipo_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_MONTONull
		{
			get { return _anticipo_montoNull; }
			set { _anticipo_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICAR_RETENCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICAR_RETENCION</c> column value.</value>
		public string APLICAR_RETENCION
		{
			get { return _aplicar_retencion; }
			set { _aplicar_retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_DETALLADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_DETALLADA</c> column value.</value>
		public string FACTURA_DETALLADA
		{
			get { return _factura_detallada; }
			set { _factura_detallada = value; }
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
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@CASO_ORIGINARIO_ID=");
			dynStr.Append(IsCASO_ORIGINARIO_IDNull ? (object)"<NULL>" : CASO_ORIGINARIO_ID);
			dynStr.Append("@CBA@DEBE_FACTURAR=");
			dynStr.Append(DEBE_FACTURAR);
			dynStr.Append("@CBA@VISTO_BUENO_FUNCIONARIO=");
			dynStr.Append(VISTO_BUENO_FUNCIONARIO);
			dynStr.Append("@CBA@VISTO_BUENO_PERSONA=");
			dynStr.Append(VISTO_BUENO_PERSONA);
			dynStr.Append("@CBA@VISTO_BUENO_GERENCIA=");
			dynStr.Append(VISTO_BUENO_GERENCIA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@ES_PARA_CLIENTE=");
			dynStr.Append(ES_PARA_CLIENTE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(IsCONDICION_PAGO_IDNull ? (object)"<NULL>" : CONDICION_PAGO_ID);
			dynStr.Append("@CBA@ANTICIPO_REQUERIDO=");
			dynStr.Append(ANTICIPO_REQUERIDO);
			dynStr.Append("@CBA@ANTICIPO_GENERAR=");
			dynStr.Append(ANTICIPO_GENERAR);
			dynStr.Append("@CBA@ANTICIPO_MONTO=");
			dynStr.Append(IsANTICIPO_MONTONull ? (object)"<NULL>" : ANTICIPO_MONTO);
			dynStr.Append("@CBA@APLICAR_RETENCION=");
			dynStr.Append(APLICAR_RETENCION);
			dynStr.Append("@CBA@FACTURA_DETALLADA=");
			dynStr.Append(FACTURA_DETALLADA);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIORow_Base class
} // End of namespace
