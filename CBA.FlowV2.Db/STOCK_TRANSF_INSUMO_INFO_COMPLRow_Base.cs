// <fileinfo name="STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSF_INSUMO_INFO_COMPLRow"/> that 
	/// represents a record in the <c>STOCK_TRANSF_INSUMO_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_TRANSF_INSUMO_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _caso_estado_id;
		private string _caso_usuario_creacion;
		private decimal _sucursal_origen_id;
		private string _sucursal_origen;
		private string _sucursal_origen_abr;
		private decimal _deposito_origen_id;
		private string _deposito_origen;
		private string _deposito_origen_abr;
		private System.DateTime _fecha;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private string _vehiculo;
		private string _vehiculo_marca;
		private string _vehiculo_matricula;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _comprobante;
		private string _es_caso_original;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _costo_transferencia;
		private bool _costo_transferenciaNull = true;
		private decimal _costo_asociado;
		private bool _costo_asociadoNull = true;
		private decimal _total_costo;
		private bool _total_costoNull = true;
		private decimal _funcionario_chofer_id;
		private bool _funcionario_chofer_idNull = true;
		private decimal _acompanante1_id;
		private bool _acompanante1_idNull = true;
		private decimal _acompanante2_id;
		private bool _acompanante2_idNull = true;
		private decimal _acompanante3_id;
		private bool _acompanante3_idNull = true;
		private string _remision_externa;
		private decimal _remision_autonumeracion_id;
		private bool _remision_autonumeracion_idNull = true;
		private string _observacion;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _codigo;
		private string _razon_social;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto;
		private string _chofer_nombre;
		private string _impreso;
		private string _calle1;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_USUARIO_CREACION != original.CASO_USUARIO_CREACION) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_ORIGEN != original.SUCURSAL_ORIGEN) return true;
			if (this.SUCURSAL_ORIGEN_ABR != original.SUCURSAL_ORIGEN_ABR) return true;
			if (this.DEPOSITO_ORIGEN_ID != original.DEPOSITO_ORIGEN_ID) return true;
			if (this.DEPOSITO_ORIGEN != original.DEPOSITO_ORIGEN) return true;
			if (this.DEPOSITO_ORIGEN_ABR != original.DEPOSITO_ORIGEN_ABR) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.VEHICULO != original.VEHICULO) return true;
			if (this.VEHICULO_MARCA != original.VEHICULO_MARCA) return true;
			if (this.VEHICULO_MATRICULA != original.VEHICULO_MATRICULA) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.COMPROBANTE != original.COMPROBANTE) return true;
			if (this.ES_CASO_ORIGINAL != original.ES_CASO_ORIGINAL) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA != original.MONEDA) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsCOSTO_TRANSFERENCIANull != original.IsCOSTO_TRANSFERENCIANull) return true;
			if (!this.IsCOSTO_TRANSFERENCIANull && !original.IsCOSTO_TRANSFERENCIANull)
				if (this.COSTO_TRANSFERENCIA != original.COSTO_TRANSFERENCIA) return true;
			if (this.IsCOSTO_ASOCIADONull != original.IsCOSTO_ASOCIADONull) return true;
			if (!this.IsCOSTO_ASOCIADONull && !original.IsCOSTO_ASOCIADONull)
				if (this.COSTO_ASOCIADO != original.COSTO_ASOCIADO) return true;
			if (this.IsTOTAL_COSTONull != original.IsTOTAL_COSTONull) return true;
			if (!this.IsTOTAL_COSTONull && !original.IsTOTAL_COSTONull)
				if (this.TOTAL_COSTO != original.TOTAL_COSTO) return true;
			if (this.IsFUNCIONARIO_CHOFER_IDNull != original.IsFUNCIONARIO_CHOFER_IDNull) return true;
			if (!this.IsFUNCIONARIO_CHOFER_IDNull && !original.IsFUNCIONARIO_CHOFER_IDNull)
				if (this.FUNCIONARIO_CHOFER_ID != original.FUNCIONARIO_CHOFER_ID) return true;
			if (this.IsACOMPANANTE1_IDNull != original.IsACOMPANANTE1_IDNull) return true;
			if (!this.IsACOMPANANTE1_IDNull && !original.IsACOMPANANTE1_IDNull)
				if (this.ACOMPANANTE1_ID != original.ACOMPANANTE1_ID) return true;
			if (this.IsACOMPANANTE2_IDNull != original.IsACOMPANANTE2_IDNull) return true;
			if (!this.IsACOMPANANTE2_IDNull && !original.IsACOMPANANTE2_IDNull)
				if (this.ACOMPANANTE2_ID != original.ACOMPANANTE2_ID) return true;
			if (this.IsACOMPANANTE3_IDNull != original.IsACOMPANANTE3_IDNull) return true;
			if (!this.IsACOMPANANTE3_IDNull && !original.IsACOMPANANTE3_IDNull)
				if (this.ACOMPANANTE3_ID != original.ACOMPANANTE3_ID) return true;
			if (this.REMISION_EXTERNA != original.REMISION_EXTERNA) return true;
			if (this.IsREMISION_AUTONUMERACION_IDNull != original.IsREMISION_AUTONUMERACION_IDNull) return true;
			if (!this.IsREMISION_AUTONUMERACION_IDNull && !original.IsREMISION_AUTONUMERACION_IDNull)
				if (this.REMISION_AUTONUMERACION_ID != original.REMISION_AUTONUMERACION_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			if (this.CALLE1 != original.CALLE1) return true;
			
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
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_USUARIO_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_USUARIO_CREACION</c> column value.</value>
		public string CASO_USUARIO_CREACION
		{
			get { return _caso_usuario_creacion; }
			set { _caso_usuario_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN</c> column value.</value>
		public string SUCURSAL_ORIGEN
		{
			get { return _sucursal_origen; }
			set { _sucursal_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ABR</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ABR</c> column value.</value>
		public string SUCURSAL_ORIGEN_ABR
		{
			get { return _sucursal_origen_abr; }
			set { _sucursal_origen_abr = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ORIGEN_ID</c> column value.</value>
		public decimal DEPOSITO_ORIGEN_ID
		{
			get { return _deposito_origen_id; }
			set { _deposito_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ORIGEN</c> column value.</value>
		public string DEPOSITO_ORIGEN
		{
			get { return _deposito_origen; }
			set { _deposito_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ORIGEN_ABR</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ORIGEN_ABR</c> column value.</value>
		public string DEPOSITO_ORIGEN_ABR
		{
			get { return _deposito_origen_abr; }
			set { _deposito_origen_abr = value; }
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
		/// Gets or sets the <c>VEHICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO</c> column value.</value>
		public string VEHICULO
		{
			get { return _vehiculo; }
			set { _vehiculo = value; }
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
		/// Gets or sets the <c>COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMPROBANTE</c> column value.</value>
		public string COMPROBANTE
		{
			get { return _comprobante; }
			set { _comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CASO_ORIGINAL</c> column value.
		/// </summary>
		/// <value>The <c>ES_CASO_ORIGINAL</c> column value.</value>
		public string ES_CASO_ORIGINAL
		{
			get { return _es_caso_original; }
			set { _es_caso_original = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA</c> column value.</value>
		public string MONEDA
		{
			get { return _moneda; }
			set { _moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_TRANSFERENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_TRANSFERENCIA</c> column value.</value>
		public decimal COSTO_TRANSFERENCIA
		{
			get
			{
				if(IsCOSTO_TRANSFERENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_transferencia;
			}
			set
			{
				_costo_transferenciaNull = false;
				_costo_transferencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_TRANSFERENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_TRANSFERENCIANull
		{
			get { return _costo_transferenciaNull; }
			set { _costo_transferenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ASOCIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_ASOCIADO</c> column value.</value>
		public decimal COSTO_ASOCIADO
		{
			get
			{
				if(IsCOSTO_ASOCIADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_asociado;
			}
			set
			{
				_costo_asociadoNull = false;
				_costo_asociado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_ASOCIADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_ASOCIADONull
		{
			get { return _costo_asociadoNull; }
			set { _costo_asociadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COSTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_COSTO</c> column value.</value>
		public decimal TOTAL_COSTO
		{
			get
			{
				if(IsTOTAL_COSTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_costo;
			}
			set
			{
				_total_costoNull = false;
				_total_costo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_COSTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_COSTONull
		{
			get { return _total_costoNull; }
			set { _total_costoNull = value; }
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
		/// Gets or sets the <c>ACOMPANANTE1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACOMPANANTE1_ID</c> column value.</value>
		public decimal ACOMPANANTE1_ID
		{
			get
			{
				if(IsACOMPANANTE1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _acompanante1_id;
			}
			set
			{
				_acompanante1_idNull = false;
				_acompanante1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACOMPANANTE1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACOMPANANTE1_IDNull
		{
			get { return _acompanante1_idNull; }
			set { _acompanante1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACOMPANANTE2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACOMPANANTE2_ID</c> column value.</value>
		public decimal ACOMPANANTE2_ID
		{
			get
			{
				if(IsACOMPANANTE2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _acompanante2_id;
			}
			set
			{
				_acompanante2_idNull = false;
				_acompanante2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACOMPANANTE2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACOMPANANTE2_IDNull
		{
			get { return _acompanante2_idNull; }
			set { _acompanante2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACOMPANANTE3_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACOMPANANTE3_ID</c> column value.</value>
		public decimal ACOMPANANTE3_ID
		{
			get
			{
				if(IsACOMPANANTE3_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _acompanante3_id;
			}
			set
			{
				_acompanante3_idNull = false;
				_acompanante3_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACOMPANANTE3_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACOMPANANTE3_IDNull
		{
			get { return _acompanante3_idNull; }
			set { _acompanante3_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REMISION_EXTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REMISION_EXTERNA</c> column value.</value>
		public string REMISION_EXTERNA
		{
			get { return _remision_externa; }
			set { _remision_externa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REMISION_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REMISION_AUTONUMERACION_ID</c> column value.</value>
		public decimal REMISION_AUTONUMERACION_ID
		{
			get
			{
				if(IsREMISION_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _remision_autonumeracion_id;
			}
			set
			{
				_remision_autonumeracion_idNull = false;
				_remision_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REMISION_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREMISION_AUTONUMERACION_IDNull
		{
			get { return _remision_autonumeracion_idNull; }
			set { _remision_autonumeracion_idNull = value; }
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
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
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
		/// Gets or sets the <c>TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
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
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE1</c> column value.</value>
		public string CALLE1
		{
			get { return _calle1; }
			set { _calle1 = value; }
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
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_USUARIO_CREACION=");
			dynStr.Append(CASO_USUARIO_CREACION);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN=");
			dynStr.Append(SUCURSAL_ORIGEN);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ABR=");
			dynStr.Append(SUCURSAL_ORIGEN_ABR);
			dynStr.Append("@CBA@DEPOSITO_ORIGEN_ID=");
			dynStr.Append(DEPOSITO_ORIGEN_ID);
			dynStr.Append("@CBA@DEPOSITO_ORIGEN=");
			dynStr.Append(DEPOSITO_ORIGEN);
			dynStr.Append("@CBA@DEPOSITO_ORIGEN_ABR=");
			dynStr.Append(DEPOSITO_ORIGEN_ABR);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@VEHICULO=");
			dynStr.Append(VEHICULO);
			dynStr.Append("@CBA@VEHICULO_MARCA=");
			dynStr.Append(VEHICULO_MARCA);
			dynStr.Append("@CBA@VEHICULO_MATRICULA=");
			dynStr.Append(VEHICULO_MATRICULA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@COMPROBANTE=");
			dynStr.Append(COMPROBANTE);
			dynStr.Append("@CBA@ES_CASO_ORIGINAL=");
			dynStr.Append(ES_CASO_ORIGINAL);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA=");
			dynStr.Append(MONEDA);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@COSTO_TRANSFERENCIA=");
			dynStr.Append(IsCOSTO_TRANSFERENCIANull ? (object)"<NULL>" : COSTO_TRANSFERENCIA);
			dynStr.Append("@CBA@COSTO_ASOCIADO=");
			dynStr.Append(IsCOSTO_ASOCIADONull ? (object)"<NULL>" : COSTO_ASOCIADO);
			dynStr.Append("@CBA@TOTAL_COSTO=");
			dynStr.Append(IsTOTAL_COSTONull ? (object)"<NULL>" : TOTAL_COSTO);
			dynStr.Append("@CBA@FUNCIONARIO_CHOFER_ID=");
			dynStr.Append(IsFUNCIONARIO_CHOFER_IDNull ? (object)"<NULL>" : FUNCIONARIO_CHOFER_ID);
			dynStr.Append("@CBA@ACOMPANANTE1_ID=");
			dynStr.Append(IsACOMPANANTE1_IDNull ? (object)"<NULL>" : ACOMPANANTE1_ID);
			dynStr.Append("@CBA@ACOMPANANTE2_ID=");
			dynStr.Append(IsACOMPANANTE2_IDNull ? (object)"<NULL>" : ACOMPANANTE2_ID);
			dynStr.Append("@CBA@ACOMPANANTE3_ID=");
			dynStr.Append(IsACOMPANANTE3_IDNull ? (object)"<NULL>" : ACOMPANANTE3_ID);
			dynStr.Append("@CBA@REMISION_EXTERNA=");
			dynStr.Append(REMISION_EXTERNA);
			dynStr.Append("@CBA@REMISION_AUTONUMERACION_ID=");
			dynStr.Append(IsREMISION_AUTONUMERACION_IDNull ? (object)"<NULL>" : REMISION_AUTONUMERACION_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			dynStr.Append("@CBA@CALLE1=");
			dynStr.Append(CALLE1);
			return dynStr.ToString();
		}
	} // End of STOCK_TRANSF_INSUMO_INFO_COMPLRow_Base class
} // End of namespace
