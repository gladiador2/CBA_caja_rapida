// <fileinfo name="REMISIONESRow_Base.cs">
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
	/// The base class for <see cref="REMISIONESRow"/> that 
	/// represents a record in the <c>REMISIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REMISIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REMISIONESRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private System.DateTime _fecha;
		private System.DateTime _fecha_inicio_traslado;
		private bool _fecha_inicio_trasladoNull = true;
		private System.DateTime _fecha_fin_traslado;
		private bool _fecha_fin_trasladoNull = true;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private decimal _nro_comprobante_secuencia;
		private bool _nro_comprobante_secuenciaNull = true;
		private string _nro_comprobante_externo;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private string _vehiculo_marca;
		private string _vehiculo_matricula;
		private decimal _funcionario_chofer_id;
		private bool _funcionario_chofer_idNull = true;
		private string _chofer_nombre;
		private string _chofer_nro_documento;
		private decimal _funcionario_acompanhante1_id;
		private bool _funcionario_acompanhante1_idNull = true;
		private decimal _funcionario_acompanhante2_id;
		private bool _funcionario_acompanhante2_idNull = true;
		private decimal _proveedor_entrega_id;
		private bool _proveedor_entrega_idNull = true;
		private string _direccion_destino;
		private decimal _departamento_destino_id;
		private bool _departamento_destino_idNull = true;
		private decimal _ciudad_destino_id;
		private bool _ciudad_destino_idNull = true;
		private decimal _barrio_destino_id;
		private bool _barrio_destino_idNull = true;
		private decimal _latitud_destino;
		private bool _latitud_destinoNull = true;
		private decimal _longitud_destino;
		private bool _longitud_destinoNull = true;
		private string _direccion_origen;
		private decimal _departamento_origen_id;
		private bool _departamento_origen_idNull = true;
		private decimal _ciudad_origen_id;
		private bool _ciudad_origen_idNull = true;
		private decimal _barrio_origen_id;
		private bool _barrio_origen_idNull = true;
		private decimal _latitud_origen;
		private bool _latitud_origenNull = true;
		private decimal _longitud_origen;
		private bool _longitud_origenNull = true;
		private string _obseracion;
		private string _obseracion_entrega;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _estado;
		private string _impreso;

		/// <summary>
		/// Initializes a new instance of the <see cref="REMISIONESRow_Base"/> class.
		/// </summary>
		public REMISIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REMISIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsFECHA_INICIO_TRASLADONull != original.IsFECHA_INICIO_TRASLADONull) return true;
			if (!this.IsFECHA_INICIO_TRASLADONull && !original.IsFECHA_INICIO_TRASLADONull)
				if (this.FECHA_INICIO_TRASLADO != original.FECHA_INICIO_TRASLADO) return true;
			if (this.IsFECHA_FIN_TRASLADONull != original.IsFECHA_FIN_TRASLADONull) return true;
			if (!this.IsFECHA_FIN_TRASLADONull && !original.IsFECHA_FIN_TRASLADONull)
				if (this.FECHA_FIN_TRASLADO != original.FECHA_FIN_TRASLADO) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsNRO_COMPROBANTE_SECUENCIANull != original.IsNRO_COMPROBANTE_SECUENCIANull) return true;
			if (!this.IsNRO_COMPROBANTE_SECUENCIANull && !original.IsNRO_COMPROBANTE_SECUENCIANull)
				if (this.NRO_COMPROBANTE_SECUENCIA != original.NRO_COMPROBANTE_SECUENCIA) return true;
			if (this.NRO_COMPROBANTE_EXTERNO != original.NRO_COMPROBANTE_EXTERNO) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.VEHICULO_MARCA != original.VEHICULO_MARCA) return true;
			if (this.VEHICULO_MATRICULA != original.VEHICULO_MATRICULA) return true;
			if (this.IsFUNCIONARIO_CHOFER_IDNull != original.IsFUNCIONARIO_CHOFER_IDNull) return true;
			if (!this.IsFUNCIONARIO_CHOFER_IDNull && !original.IsFUNCIONARIO_CHOFER_IDNull)
				if (this.FUNCIONARIO_CHOFER_ID != original.FUNCIONARIO_CHOFER_ID) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.CHOFER_NRO_DOCUMENTO != original.CHOFER_NRO_DOCUMENTO) return true;
			if (this.IsFUNCIONARIO_ACOMPANHANTE1_IDNull != original.IsFUNCIONARIO_ACOMPANHANTE1_IDNull) return true;
			if (!this.IsFUNCIONARIO_ACOMPANHANTE1_IDNull && !original.IsFUNCIONARIO_ACOMPANHANTE1_IDNull)
				if (this.FUNCIONARIO_ACOMPANHANTE1_ID != original.FUNCIONARIO_ACOMPANHANTE1_ID) return true;
			if (this.IsFUNCIONARIO_ACOMPANHANTE2_IDNull != original.IsFUNCIONARIO_ACOMPANHANTE2_IDNull) return true;
			if (!this.IsFUNCIONARIO_ACOMPANHANTE2_IDNull && !original.IsFUNCIONARIO_ACOMPANHANTE2_IDNull)
				if (this.FUNCIONARIO_ACOMPANHANTE2_ID != original.FUNCIONARIO_ACOMPANHANTE2_ID) return true;
			if (this.IsPROVEEDOR_ENTREGA_IDNull != original.IsPROVEEDOR_ENTREGA_IDNull) return true;
			if (!this.IsPROVEEDOR_ENTREGA_IDNull && !original.IsPROVEEDOR_ENTREGA_IDNull)
				if (this.PROVEEDOR_ENTREGA_ID != original.PROVEEDOR_ENTREGA_ID) return true;
			if (this.DIRECCION_DESTINO != original.DIRECCION_DESTINO) return true;
			if (this.IsDEPARTAMENTO_DESTINO_IDNull != original.IsDEPARTAMENTO_DESTINO_IDNull) return true;
			if (!this.IsDEPARTAMENTO_DESTINO_IDNull && !original.IsDEPARTAMENTO_DESTINO_IDNull)
				if (this.DEPARTAMENTO_DESTINO_ID != original.DEPARTAMENTO_DESTINO_ID) return true;
			if (this.IsCIUDAD_DESTINO_IDNull != original.IsCIUDAD_DESTINO_IDNull) return true;
			if (!this.IsCIUDAD_DESTINO_IDNull && !original.IsCIUDAD_DESTINO_IDNull)
				if (this.CIUDAD_DESTINO_ID != original.CIUDAD_DESTINO_ID) return true;
			if (this.IsBARRIO_DESTINO_IDNull != original.IsBARRIO_DESTINO_IDNull) return true;
			if (!this.IsBARRIO_DESTINO_IDNull && !original.IsBARRIO_DESTINO_IDNull)
				if (this.BARRIO_DESTINO_ID != original.BARRIO_DESTINO_ID) return true;
			if (this.IsLATITUD_DESTINONull != original.IsLATITUD_DESTINONull) return true;
			if (!this.IsLATITUD_DESTINONull && !original.IsLATITUD_DESTINONull)
				if (this.LATITUD_DESTINO != original.LATITUD_DESTINO) return true;
			if (this.IsLONGITUD_DESTINONull != original.IsLONGITUD_DESTINONull) return true;
			if (!this.IsLONGITUD_DESTINONull && !original.IsLONGITUD_DESTINONull)
				if (this.LONGITUD_DESTINO != original.LONGITUD_DESTINO) return true;
			if (this.DIRECCION_ORIGEN != original.DIRECCION_ORIGEN) return true;
			if (this.IsDEPARTAMENTO_ORIGEN_IDNull != original.IsDEPARTAMENTO_ORIGEN_IDNull) return true;
			if (!this.IsDEPARTAMENTO_ORIGEN_IDNull && !original.IsDEPARTAMENTO_ORIGEN_IDNull)
				if (this.DEPARTAMENTO_ORIGEN_ID != original.DEPARTAMENTO_ORIGEN_ID) return true;
			if (this.IsCIUDAD_ORIGEN_IDNull != original.IsCIUDAD_ORIGEN_IDNull) return true;
			if (!this.IsCIUDAD_ORIGEN_IDNull && !original.IsCIUDAD_ORIGEN_IDNull)
				if (this.CIUDAD_ORIGEN_ID != original.CIUDAD_ORIGEN_ID) return true;
			if (this.IsBARRIO_ORIGEN_IDNull != original.IsBARRIO_ORIGEN_IDNull) return true;
			if (!this.IsBARRIO_ORIGEN_IDNull && !original.IsBARRIO_ORIGEN_IDNull)
				if (this.BARRIO_ORIGEN_ID != original.BARRIO_ORIGEN_ID) return true;
			if (this.IsLATITUD_ORIGENNull != original.IsLATITUD_ORIGENNull) return true;
			if (!this.IsLATITUD_ORIGENNull && !original.IsLATITUD_ORIGENNull)
				if (this.LATITUD_ORIGEN != original.LATITUD_ORIGEN) return true;
			if (this.IsLONGITUD_ORIGENNull != original.IsLONGITUD_ORIGENNull) return true;
			if (!this.IsLONGITUD_ORIGENNull && !original.IsLONGITUD_ORIGENNull)
				if (this.LONGITUD_ORIGEN != original.LONGITUD_ORIGEN) return true;
			if (this.OBSERACION != original.OBSERACION) return true;
			if (this.OBSERACION_ENTREGA != original.OBSERACION_ENTREGA) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
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
		/// Gets or sets the <c>FECHA_INICIO_TRASLADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO_TRASLADO</c> column value.</value>
		public System.DateTime FECHA_INICIO_TRASLADO
		{
			get
			{
				if(IsFECHA_INICIO_TRASLADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio_traslado;
			}
			set
			{
				_fecha_inicio_trasladoNull = false;
				_fecha_inicio_traslado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO_TRASLADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIO_TRASLADONull
		{
			get { return _fecha_inicio_trasladoNull; }
			set { _fecha_inicio_trasladoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN_TRASLADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN_TRASLADO</c> column value.</value>
		public System.DateTime FECHA_FIN_TRASLADO
		{
			get
			{
				if(IsFECHA_FIN_TRASLADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin_traslado;
			}
			set
			{
				_fecha_fin_trasladoNull = false;
				_fecha_fin_traslado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN_TRASLADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FIN_TRASLADONull
		{
			get { return _fecha_fin_trasladoNull; }
			set { _fecha_fin_trasladoNull = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE_SECUENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_SECUENCIA</c> column value.</value>
		public decimal NRO_COMPROBANTE_SECUENCIA
		{
			get
			{
				if(IsNRO_COMPROBANTE_SECUENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_comprobante_secuencia;
			}
			set
			{
				_nro_comprobante_secuenciaNull = false;
				_nro_comprobante_secuencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_COMPROBANTE_SECUENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_COMPROBANTE_SECUENCIANull
		{
			get { return _nro_comprobante_secuenciaNull; }
			set { _nro_comprobante_secuenciaNull = value; }
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
		/// Gets or sets the <c>VEHICULO_MARCA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_MARCA</c> column value.</value>
		public string VEHICULO_MARCA
		{
			get { return _vehiculo_marca; }
			set { _vehiculo_marca = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VEHICULO_MATRICULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_MATRICULA</c> column value.</value>
		public string VEHICULO_MATRICULA
		{
			get { return _vehiculo_matricula; }
			set { _vehiculo_matricula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CHOFER_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CHOFER_ID</c> column value.</value>
		public decimal FUNCIONARIO_CHOFER_ID
		{
			get
			{
				if(IsFUNCIONARIO_CHOFER_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_chofer_id;
			}
			set
			{
				_funcionario_chofer_idNull = false;
				_funcionario_chofer_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_CHOFER_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_CHOFER_IDNull
		{
			get { return _funcionario_chofer_idNull; }
			set { _funcionario_chofer_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_NOMBRE</c> column value.</value>
		public string CHOFER_NOMBRE
		{
			get { return _chofer_nombre; }
			set { _chofer_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_NRO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_NRO_DOCUMENTO</c> column value.</value>
		public string CHOFER_NRO_DOCUMENTO
		{
			get { return _chofer_nro_documento; }
			set { _chofer_nro_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ACOMPANHANTE1_ID</c> column value.</value>
		public decimal FUNCIONARIO_ACOMPANHANTE1_ID
		{
			get
			{
				if(IsFUNCIONARIO_ACOMPANHANTE1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_acompanhante1_id;
			}
			set
			{
				_funcionario_acompanhante1_idNull = false;
				_funcionario_acompanhante1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ACOMPANHANTE1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ACOMPANHANTE1_IDNull
		{
			get { return _funcionario_acompanhante1_idNull; }
			set { _funcionario_acompanhante1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ACOMPANHANTE2_ID</c> column value.</value>
		public decimal FUNCIONARIO_ACOMPANHANTE2_ID
		{
			get
			{
				if(IsFUNCIONARIO_ACOMPANHANTE2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_acompanhante2_id;
			}
			set
			{
				_funcionario_acompanhante2_idNull = false;
				_funcionario_acompanhante2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ACOMPANHANTE2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ACOMPANHANTE2_IDNull
		{
			get { return _funcionario_acompanhante2_idNull; }
			set { _funcionario_acompanhante2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ENTREGA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ENTREGA_ID</c> column value.</value>
		public decimal PROVEEDOR_ENTREGA_ID
		{
			get
			{
				if(IsPROVEEDOR_ENTREGA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_entrega_id;
			}
			set
			{
				_proveedor_entrega_idNull = false;
				_proveedor_entrega_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ENTREGA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_ENTREGA_IDNull
		{
			get { return _proveedor_entrega_idNull; }
			set { _proveedor_entrega_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_DESTINO</c> column value.</value>
		public string DIRECCION_DESTINO
		{
			get { return _direccion_destino; }
			set { _direccion_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_DESTINO_ID</c> column value.</value>
		public decimal DEPARTAMENTO_DESTINO_ID
		{
			get
			{
				if(IsDEPARTAMENTO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_destino_id;
			}
			set
			{
				_departamento_destino_idNull = false;
				_departamento_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_DESTINO_IDNull
		{
			get { return _departamento_destino_idNull; }
			set { _departamento_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_DESTINO_ID</c> column value.</value>
		public decimal CIUDAD_DESTINO_ID
		{
			get
			{
				if(IsCIUDAD_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_destino_id;
			}
			set
			{
				_ciudad_destino_idNull = false;
				_ciudad_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_DESTINO_IDNull
		{
			get { return _ciudad_destino_idNull; }
			set { _ciudad_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_DESTINO_ID</c> column value.</value>
		public decimal BARRIO_DESTINO_ID
		{
			get
			{
				if(IsBARRIO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_destino_id;
			}
			set
			{
				_barrio_destino_idNull = false;
				_barrio_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_DESTINO_IDNull
		{
			get { return _barrio_destino_idNull; }
			set { _barrio_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD_DESTINO</c> column value.</value>
		public decimal LATITUD_DESTINO
		{
			get
			{
				if(IsLATITUD_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud_destino;
			}
			set
			{
				_latitud_destinoNull = false;
				_latitud_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD_DESTINONull
		{
			get { return _latitud_destinoNull; }
			set { _latitud_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD_DESTINO</c> column value.</value>
		public decimal LONGITUD_DESTINO
		{
			get
			{
				if(IsLONGITUD_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud_destino;
			}
			set
			{
				_longitud_destinoNull = false;
				_longitud_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD_DESTINONull
		{
			get { return _longitud_destinoNull; }
			set { _longitud_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_ORIGEN</c> column value.</value>
		public string DIRECCION_ORIGEN
		{
			get { return _direccion_origen; }
			set { _direccion_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_ORIGEN_ID</c> column value.</value>
		public decimal DEPARTAMENTO_ORIGEN_ID
		{
			get
			{
				if(IsDEPARTAMENTO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_origen_id;
			}
			set
			{
				_departamento_origen_idNull = false;
				_departamento_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_ORIGEN_IDNull
		{
			get { return _departamento_origen_idNull; }
			set { _departamento_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_ORIGEN_ID</c> column value.</value>
		public decimal CIUDAD_ORIGEN_ID
		{
			get
			{
				if(IsCIUDAD_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_origen_id;
			}
			set
			{
				_ciudad_origen_idNull = false;
				_ciudad_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_ORIGEN_IDNull
		{
			get { return _ciudad_origen_idNull; }
			set { _ciudad_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_ORIGEN_ID</c> column value.</value>
		public decimal BARRIO_ORIGEN_ID
		{
			get
			{
				if(IsBARRIO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_origen_id;
			}
			set
			{
				_barrio_origen_idNull = false;
				_barrio_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_ORIGEN_IDNull
		{
			get { return _barrio_origen_idNull; }
			set { _barrio_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD_ORIGEN</c> column value.</value>
		public decimal LATITUD_ORIGEN
		{
			get
			{
				if(IsLATITUD_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud_origen;
			}
			set
			{
				_latitud_origenNull = false;
				_latitud_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD_ORIGENNull
		{
			get { return _latitud_origenNull; }
			set { _latitud_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD_ORIGEN</c> column value.</value>
		public decimal LONGITUD_ORIGEN
		{
			get
			{
				if(IsLONGITUD_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud_origen;
			}
			set
			{
				_longitud_origenNull = false;
				_longitud_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD_ORIGENNull
		{
			get { return _longitud_origenNull; }
			set { _longitud_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERACION</c> column value.</value>
		public string OBSERACION
		{
			get { return _obseracion; }
			set { _obseracion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERACION_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERACION_ENTREGA</c> column value.</value>
		public string OBSERACION_ENTREGA
		{
			get { return _obseracion_entrega; }
			set { _obseracion_entrega = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
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
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FECHA_INICIO_TRASLADO=");
			dynStr.Append(IsFECHA_INICIO_TRASLADONull ? (object)"<NULL>" : FECHA_INICIO_TRASLADO);
			dynStr.Append("@CBA@FECHA_FIN_TRASLADO=");
			dynStr.Append(IsFECHA_FIN_TRASLADONull ? (object)"<NULL>" : FECHA_FIN_TRASLADO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NRO_COMPROBANTE_SECUENCIA=");
			dynStr.Append(IsNRO_COMPROBANTE_SECUENCIANull ? (object)"<NULL>" : NRO_COMPROBANTE_SECUENCIA);
			dynStr.Append("@CBA@NRO_COMPROBANTE_EXTERNO=");
			dynStr.Append(NRO_COMPROBANTE_EXTERNO);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@VEHICULO_MARCA=");
			dynStr.Append(VEHICULO_MARCA);
			dynStr.Append("@CBA@VEHICULO_MATRICULA=");
			dynStr.Append(VEHICULO_MATRICULA);
			dynStr.Append("@CBA@FUNCIONARIO_CHOFER_ID=");
			dynStr.Append(IsFUNCIONARIO_CHOFER_IDNull ? (object)"<NULL>" : FUNCIONARIO_CHOFER_ID);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@CHOFER_NRO_DOCUMENTO=");
			dynStr.Append(CHOFER_NRO_DOCUMENTO);
			dynStr.Append("@CBA@FUNCIONARIO_ACOMPANHANTE1_ID=");
			dynStr.Append(IsFUNCIONARIO_ACOMPANHANTE1_IDNull ? (object)"<NULL>" : FUNCIONARIO_ACOMPANHANTE1_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ACOMPANHANTE2_ID=");
			dynStr.Append(IsFUNCIONARIO_ACOMPANHANTE2_IDNull ? (object)"<NULL>" : FUNCIONARIO_ACOMPANHANTE2_ID);
			dynStr.Append("@CBA@PROVEEDOR_ENTREGA_ID=");
			dynStr.Append(IsPROVEEDOR_ENTREGA_IDNull ? (object)"<NULL>" : PROVEEDOR_ENTREGA_ID);
			dynStr.Append("@CBA@DIRECCION_DESTINO=");
			dynStr.Append(DIRECCION_DESTINO);
			dynStr.Append("@CBA@DEPARTAMENTO_DESTINO_ID=");
			dynStr.Append(IsDEPARTAMENTO_DESTINO_IDNull ? (object)"<NULL>" : DEPARTAMENTO_DESTINO_ID);
			dynStr.Append("@CBA@CIUDAD_DESTINO_ID=");
			dynStr.Append(IsCIUDAD_DESTINO_IDNull ? (object)"<NULL>" : CIUDAD_DESTINO_ID);
			dynStr.Append("@CBA@BARRIO_DESTINO_ID=");
			dynStr.Append(IsBARRIO_DESTINO_IDNull ? (object)"<NULL>" : BARRIO_DESTINO_ID);
			dynStr.Append("@CBA@LATITUD_DESTINO=");
			dynStr.Append(IsLATITUD_DESTINONull ? (object)"<NULL>" : LATITUD_DESTINO);
			dynStr.Append("@CBA@LONGITUD_DESTINO=");
			dynStr.Append(IsLONGITUD_DESTINONull ? (object)"<NULL>" : LONGITUD_DESTINO);
			dynStr.Append("@CBA@DIRECCION_ORIGEN=");
			dynStr.Append(DIRECCION_ORIGEN);
			dynStr.Append("@CBA@DEPARTAMENTO_ORIGEN_ID=");
			dynStr.Append(IsDEPARTAMENTO_ORIGEN_IDNull ? (object)"<NULL>" : DEPARTAMENTO_ORIGEN_ID);
			dynStr.Append("@CBA@CIUDAD_ORIGEN_ID=");
			dynStr.Append(IsCIUDAD_ORIGEN_IDNull ? (object)"<NULL>" : CIUDAD_ORIGEN_ID);
			dynStr.Append("@CBA@BARRIO_ORIGEN_ID=");
			dynStr.Append(IsBARRIO_ORIGEN_IDNull ? (object)"<NULL>" : BARRIO_ORIGEN_ID);
			dynStr.Append("@CBA@LATITUD_ORIGEN=");
			dynStr.Append(IsLATITUD_ORIGENNull ? (object)"<NULL>" : LATITUD_ORIGEN);
			dynStr.Append("@CBA@LONGITUD_ORIGEN=");
			dynStr.Append(IsLONGITUD_ORIGENNull ? (object)"<NULL>" : LONGITUD_ORIGEN);
			dynStr.Append("@CBA@OBSERACION=");
			dynStr.Append(OBSERACION);
			dynStr.Append("@CBA@OBSERACION_ENTREGA=");
			dynStr.Append(OBSERACION_ENTREGA);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			return dynStr.ToString();
		}
	} // End of REMISIONESRow_Base class
} // End of namespace
