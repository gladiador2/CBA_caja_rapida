// <fileinfo name="PRESUPUESTOSRow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOSRow"/> that 
	/// represents a record in the <c>PRESUPUESTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_validez;
		private System.DateTime _fecha_entrega;
		private bool _fecha_entregaNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private string _observacion;
		private decimal _funcionario_id;
		private string _objeto;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;
		private decimal _texto_predefinido_tipo_id;
		private bool _texto_predefinido_tipo_idNull = true;
		private decimal _texto_predefinido_fuero_id;
		private bool _texto_predefinido_fuero_idNull = true;
		private decimal _tramites_tipos_id;
		private bool _tramites_tipos_idNull = true;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private decimal _persona_garante_1_id;
		private bool _persona_garante_1_idNull = true;
		private decimal _persona_garante_2_id;
		private bool _persona_garante_2_idNull = true;
		private decimal _persona_garante_3_id;
		private bool _persona_garante_3_idNull = true;
		private string _nro_comprobante_externo;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _articulo_monto;
		private bool _articulo_montoNull = true;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOSRow_Base"/> class.
		/// </summary>
		public PRESUPUESTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FECHA_VALIDEZ != original.FECHA_VALIDEZ) return true;
			if (this.IsFECHA_ENTREGANull != original.IsFECHA_ENTREGANull) return true;
			if (!this.IsFECHA_ENTREGANull && !original.IsFECHA_ENTREGANull)
				if (this.FECHA_ENTREGA != original.FECHA_ENTREGA) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.OBJETO != original.OBJETO) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_TIPO_IDNull != original.IsTEXTO_PREDEFINIDO_TIPO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_TIPO_IDNull && !original.IsTEXTO_PREDEFINIDO_TIPO_IDNull)
				if (this.TEXTO_PREDEFINIDO_TIPO_ID != original.TEXTO_PREDEFINIDO_TIPO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_FUERO_IDNull != original.IsTEXTO_PREDEFINIDO_FUERO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_FUERO_IDNull && !original.IsTEXTO_PREDEFINIDO_FUERO_IDNull)
				if (this.TEXTO_PREDEFINIDO_FUERO_ID != original.TEXTO_PREDEFINIDO_FUERO_ID) return true;
			if (this.IsTRAMITES_TIPOS_IDNull != original.IsTRAMITES_TIPOS_IDNull) return true;
			if (!this.IsTRAMITES_TIPOS_IDNull && !original.IsTRAMITES_TIPOS_IDNull)
				if (this.TRAMITES_TIPOS_ID != original.TRAMITES_TIPOS_ID) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.IsPERSONA_GARANTE_1_IDNull != original.IsPERSONA_GARANTE_1_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_1_IDNull && !original.IsPERSONA_GARANTE_1_IDNull)
				if (this.PERSONA_GARANTE_1_ID != original.PERSONA_GARANTE_1_ID) return true;
			if (this.IsPERSONA_GARANTE_2_IDNull != original.IsPERSONA_GARANTE_2_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_2_IDNull && !original.IsPERSONA_GARANTE_2_IDNull)
				if (this.PERSONA_GARANTE_2_ID != original.PERSONA_GARANTE_2_ID) return true;
			if (this.IsPERSONA_GARANTE_3_IDNull != original.IsPERSONA_GARANTE_3_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_3_IDNull && !original.IsPERSONA_GARANTE_3_IDNull)
				if (this.PERSONA_GARANTE_3_ID != original.PERSONA_GARANTE_3_ID) return true;
			if (this.NRO_COMPROBANTE_EXTERNO != original.NRO_COMPROBANTE_EXTERNO) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsARTICULO_MONTONull != original.IsARTICULO_MONTONull) return true;
			if (!this.IsARTICULO_MONTONull && !original.IsARTICULO_MONTONull)
				if (this.ARTICULO_MONTO != original.ARTICULO_MONTO) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VALIDEZ</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VALIDEZ</c> column value.</value>
		public System.DateTime FECHA_VALIDEZ
		{
			get { return _fecha_validez; }
			set { _fecha_validez = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ENTREGA</c> column value.</value>
		public System.DateTime FECHA_ENTREGA
		{
			get
			{
				if(IsFECHA_ENTREGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_entrega;
			}
			set
			{
				_fecha_entregaNull = false;
				_fecha_entrega = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ENTREGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ENTREGANull
		{
			get { return _fecha_entregaNull; }
			set { _fecha_entregaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBJETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBJETO</c> column value.</value>
		public string OBJETO
		{
			get { return _objeto; }
			set { _objeto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_TIPO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_TIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_tipo_id;
			}
			set
			{
				_texto_predefinido_tipo_idNull = false;
				_texto_predefinido_tipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_TIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_TIPO_IDNull
		{
			get { return _texto_predefinido_tipo_idNull; }
			set { _texto_predefinido_tipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_FUERO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_FUERO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_fuero_id;
			}
			set
			{
				_texto_predefinido_fuero_idNull = false;
				_texto_predefinido_fuero_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_FUERO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_FUERO_IDNull
		{
			get { return _texto_predefinido_fuero_idNull; }
			set { _texto_predefinido_fuero_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITES_TIPOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITES_TIPOS_ID</c> column value.</value>
		public decimal TRAMITES_TIPOS_ID
		{
			get
			{
				if(IsTRAMITES_TIPOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramites_tipos_id;
			}
			set
			{
				_tramites_tipos_idNull = false;
				_tramites_tipos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITES_TIPOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITES_TIPOS_IDNull
		{
			get { return _tramites_tipos_idNull; }
			set { _tramites_tipos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VEHICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_ID</c> column value.</value>
		public decimal VEHICULO_ID
		{
			get
			{
				if(IsVEHICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vehiculo_id;
			}
			set
			{
				_vehiculo_idNull = false;
				_vehiculo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VEHICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVEHICULO_IDNull
		{
			get { return _vehiculo_idNull; }
			set { _vehiculo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_1_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_1_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_1_id;
			}
			set
			{
				_persona_garante_1_idNull = false;
				_persona_garante_1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_1_IDNull
		{
			get { return _persona_garante_1_idNull; }
			set { _persona_garante_1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_2_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_2_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_2_id;
			}
			set
			{
				_persona_garante_2_idNull = false;
				_persona_garante_2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_2_IDNull
		{
			get { return _persona_garante_2_idNull; }
			set { _persona_garante_2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_3_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_3_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_3_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_3_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_3_id;
			}
			set
			{
				_persona_garante_3_idNull = false;
				_persona_garante_3_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_3_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_3_IDNull
		{
			get { return _persona_garante_3_idNull; }
			set { _persona_garante_3_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_EXTERNO</c> column value.</value>
		public string NRO_COMPROBANTE_EXTERNO
		{
			get { return _nro_comprobante_externo; }
			set { _nro_comprobante_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_MONTO</c> column value.</value>
		public decimal ARTICULO_MONTO
		{
			get
			{
				if(IsARTICULO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_monto;
			}
			set
			{
				_articulo_montoNull = false;
				_articulo_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_MONTONull
		{
			get { return _articulo_montoNull; }
			set { _articulo_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
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
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_VALIDEZ=");
			dynStr.Append(FECHA_VALIDEZ);
			dynStr.Append("@CBA@FECHA_ENTREGA=");
			dynStr.Append(IsFECHA_ENTREGANull ? (object)"<NULL>" : FECHA_ENTREGA);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@OBJETO=");
			dynStr.Append(OBJETO);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_TIPO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_TIPO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_TIPO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_FUERO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_FUERO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_FUERO_ID);
			dynStr.Append("@CBA@TRAMITES_TIPOS_ID=");
			dynStr.Append(IsTRAMITES_TIPOS_IDNull ? (object)"<NULL>" : TRAMITES_TIPOS_ID);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_1_ID=");
			dynStr.Append(IsPERSONA_GARANTE_1_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_1_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_2_ID=");
			dynStr.Append(IsPERSONA_GARANTE_2_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_2_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_3_ID=");
			dynStr.Append(IsPERSONA_GARANTE_3_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_3_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE_EXTERNO=");
			dynStr.Append(NRO_COMPROBANTE_EXTERNO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_MONTO=");
			dynStr.Append(IsARTICULO_MONTONull ? (object)"<NULL>" : ARTICULO_MONTO);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOSRow_Base class
} // End of namespace
