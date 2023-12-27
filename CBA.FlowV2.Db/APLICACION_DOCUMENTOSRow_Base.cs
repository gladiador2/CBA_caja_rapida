// <fileinfo name="APLICACION_DOCUMENTOSRow_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMENTOSRow"/> that 
	/// represents a record in the <c>APLICACION_DOCUMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="APLICACION_DOCUMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMENTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _persona_documentos_id;
		private decimal _sucursal_id;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _usuario_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private decimal _total_valores;
		private decimal _total_documentos;
		private decimal _persona_valores_id;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _autonumeracion_recibo_id;
		private bool _autonumeracion_recibo_idNull = true;
		private decimal _ctacte_recibo_id;
		private bool _ctacte_recibo_idNull = true;
		private string _nro_recibo_manual;
		private string _consolidacion_deuda;
		private decimal _nc_deposito_id;
		private bool _nc_deposito_idNull = true;
		private decimal _nc_autonumeracion_id;
		private bool _nc_autonumeracion_idNull = true;
		private string _nc_nro_comprobante;
		private decimal _nc_ctacte_caja_sucursal_id;
		private bool _nc_ctacte_caja_sucursal_idNull = true;
		private decimal _fc_deposito_id;
		private bool _fc_deposito_idNull = true;
		private decimal _fc_autonumeracion_id;
		private bool _fc_autonumeracion_idNull = true;
		private string _fc_nro_comprobante;
		private decimal _fc_ctacte_caja_sucursal_id;
		private bool _fc_ctacte_caja_sucursal_idNull = true;
		private decimal _fc_caso_id;
		private bool _fc_caso_idNull = true;
		private decimal _monto_nueva_cuota;
		private bool _monto_nueva_cuotaNull = true;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private string _observacion;
		private string _nro_comprobante_externo;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOSRow_Base"/> class.
		/// </summary>
		public APLICACION_DOCUMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(APLICACION_DOCUMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.PERSONA_DOCUMENTOS_ID != original.PERSONA_DOCUMENTOS_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.TOTAL_VALORES != original.TOTAL_VALORES) return true;
			if (this.TOTAL_DOCUMENTOS != original.TOTAL_DOCUMENTOS) return true;
			if (this.PERSONA_VALORES_ID != original.PERSONA_VALORES_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsAUTONUMERACION_RECIBO_IDNull != original.IsAUTONUMERACION_RECIBO_IDNull) return true;
			if (!this.IsAUTONUMERACION_RECIBO_IDNull && !original.IsAUTONUMERACION_RECIBO_IDNull)
				if (this.AUTONUMERACION_RECIBO_ID != original.AUTONUMERACION_RECIBO_ID) return true;
			if (this.IsCTACTE_RECIBO_IDNull != original.IsCTACTE_RECIBO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_IDNull && !original.IsCTACTE_RECIBO_IDNull)
				if (this.CTACTE_RECIBO_ID != original.CTACTE_RECIBO_ID) return true;
			if (this.NRO_RECIBO_MANUAL != original.NRO_RECIBO_MANUAL) return true;
			if (this.CONSOLIDACION_DEUDA != original.CONSOLIDACION_DEUDA) return true;
			if (this.IsNC_DEPOSITO_IDNull != original.IsNC_DEPOSITO_IDNull) return true;
			if (!this.IsNC_DEPOSITO_IDNull && !original.IsNC_DEPOSITO_IDNull)
				if (this.NC_DEPOSITO_ID != original.NC_DEPOSITO_ID) return true;
			if (this.IsNC_AUTONUMERACION_IDNull != original.IsNC_AUTONUMERACION_IDNull) return true;
			if (!this.IsNC_AUTONUMERACION_IDNull && !original.IsNC_AUTONUMERACION_IDNull)
				if (this.NC_AUTONUMERACION_ID != original.NC_AUTONUMERACION_ID) return true;
			if (this.NC_NRO_COMPROBANTE != original.NC_NRO_COMPROBANTE) return true;
			if (this.IsNC_CTACTE_CAJA_SUCURSAL_IDNull != original.IsNC_CTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsNC_CTACTE_CAJA_SUCURSAL_IDNull && !original.IsNC_CTACTE_CAJA_SUCURSAL_IDNull)
				if (this.NC_CTACTE_CAJA_SUCURSAL_ID != original.NC_CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsFC_DEPOSITO_IDNull != original.IsFC_DEPOSITO_IDNull) return true;
			if (!this.IsFC_DEPOSITO_IDNull && !original.IsFC_DEPOSITO_IDNull)
				if (this.FC_DEPOSITO_ID != original.FC_DEPOSITO_ID) return true;
			if (this.IsFC_AUTONUMERACION_IDNull != original.IsFC_AUTONUMERACION_IDNull) return true;
			if (!this.IsFC_AUTONUMERACION_IDNull && !original.IsFC_AUTONUMERACION_IDNull)
				if (this.FC_AUTONUMERACION_ID != original.FC_AUTONUMERACION_ID) return true;
			if (this.FC_NRO_COMPROBANTE != original.FC_NRO_COMPROBANTE) return true;
			if (this.IsFC_CTACTE_CAJA_SUCURSAL_IDNull != original.IsFC_CTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsFC_CTACTE_CAJA_SUCURSAL_IDNull && !original.IsFC_CTACTE_CAJA_SUCURSAL_IDNull)
				if (this.FC_CTACTE_CAJA_SUCURSAL_ID != original.FC_CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsFC_CASO_IDNull != original.IsFC_CASO_IDNull) return true;
			if (!this.IsFC_CASO_IDNull && !original.IsFC_CASO_IDNull)
				if (this.FC_CASO_ID != original.FC_CASO_ID) return true;
			if (this.IsMONTO_NUEVA_CUOTANull != original.IsMONTO_NUEVA_CUOTANull) return true;
			if (!this.IsMONTO_NUEVA_CUOTANull && !original.IsMONTO_NUEVA_CUOTANull)
				if (this.MONTO_NUEVA_CUOTA != original.MONTO_NUEVA_CUOTA) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NRO_COMPROBANTE_EXTERNO != original.NRO_COMPROBANTE_EXTERNO) return true;
			
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
		/// Gets or sets the <c>PERSONA_DOCUMENTOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_DOCUMENTOS_ID</c> column value.</value>
		public decimal PERSONA_DOCUMENTOS_ID
		{
			get { return _persona_documentos_id; }
			set { _persona_documentos_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>TOTAL_VALORES</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_VALORES</c> column value.</value>
		public decimal TOTAL_VALORES
		{
			get { return _total_valores; }
			set { _total_valores = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DOCUMENTOS</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_DOCUMENTOS</c> column value.</value>
		public decimal TOTAL_DOCUMENTOS
		{
			get { return _total_documentos; }
			set { _total_documentos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_VALORES_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_VALORES_ID</c> column value.</value>
		public decimal PERSONA_VALORES_ID
		{
			get { return _persona_valores_id; }
			set { _persona_valores_id = value; }
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
		/// Gets or sets the <c>NRO_RECIBO_MANUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_RECIBO_MANUAL</c> column value.</value>
		public string NRO_RECIBO_MANUAL
		{
			get { return _nro_recibo_manual; }
			set { _nro_recibo_manual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSOLIDACION_DEUDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSOLIDACION_DEUDA</c> column value.</value>
		public string CONSOLIDACION_DEUDA
		{
			get { return _consolidacion_deuda; }
			set { _consolidacion_deuda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_DEPOSITO_ID</c> column value.</value>
		public decimal NC_DEPOSITO_ID
		{
			get
			{
				if(IsNC_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_deposito_id;
			}
			set
			{
				_nc_deposito_idNull = false;
				_nc_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_DEPOSITO_IDNull
		{
			get { return _nc_deposito_idNull; }
			set { _nc_deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_AUTONUMERACION_ID</c> column value.</value>
		public decimal NC_AUTONUMERACION_ID
		{
			get
			{
				if(IsNC_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_autonumeracion_id;
			}
			set
			{
				_nc_autonumeracion_idNull = false;
				_nc_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_AUTONUMERACION_IDNull
		{
			get { return _nc_autonumeracion_idNull; }
			set { _nc_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_NRO_COMPROBANTE</c> column value.</value>
		public string NC_NRO_COMPROBANTE
		{
			get { return _nc_nro_comprobante; }
			set { _nc_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal NC_CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsNC_CTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_ctacte_caja_sucursal_id;
			}
			set
			{
				_nc_ctacte_caja_sucursal_idNull = false;
				_nc_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_CTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _nc_ctacte_caja_sucursal_idNull; }
			set { _nc_ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_DEPOSITO_ID</c> column value.</value>
		public decimal FC_DEPOSITO_ID
		{
			get
			{
				if(IsFC_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_deposito_id;
			}
			set
			{
				_fc_deposito_idNull = false;
				_fc_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_DEPOSITO_IDNull
		{
			get { return _fc_deposito_idNull; }
			set { _fc_deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_AUTONUMERACION_ID</c> column value.</value>
		public decimal FC_AUTONUMERACION_ID
		{
			get
			{
				if(IsFC_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_autonumeracion_id;
			}
			set
			{
				_fc_autonumeracion_idNull = false;
				_fc_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_AUTONUMERACION_IDNull
		{
			get { return _fc_autonumeracion_idNull; }
			set { _fc_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_NRO_COMPROBANTE</c> column value.</value>
		public string FC_NRO_COMPROBANTE
		{
			get { return _fc_nro_comprobante; }
			set { _fc_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal FC_CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsFC_CTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_ctacte_caja_sucursal_id;
			}
			set
			{
				_fc_ctacte_caja_sucursal_idNull = false;
				_fc_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _fc_ctacte_caja_sucursal_idNull; }
			set { _fc_ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CASO_ID</c> column value.</value>
		public decimal FC_CASO_ID
		{
			get
			{
				if(IsFC_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_caso_id;
			}
			set
			{
				_fc_caso_idNull = false;
				_fc_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CASO_IDNull
		{
			get { return _fc_caso_idNull; }
			set { _fc_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_NUEVA_CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_NUEVA_CUOTA</c> column value.</value>
		public decimal MONTO_NUEVA_CUOTA
		{
			get
			{
				if(IsMONTO_NUEVA_CUOTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_nueva_cuota;
			}
			set
			{
				_monto_nueva_cuotaNull = false;
				_monto_nueva_cuota = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_NUEVA_CUOTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_NUEVA_CUOTANull
		{
			get { return _monto_nueva_cuotaNull; }
			set { _monto_nueva_cuotaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
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
			dynStr.Append("@CBA@PERSONA_DOCUMENTOS_ID=");
			dynStr.Append(PERSONA_DOCUMENTOS_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TOTAL_VALORES=");
			dynStr.Append(TOTAL_VALORES);
			dynStr.Append("@CBA@TOTAL_DOCUMENTOS=");
			dynStr.Append(TOTAL_DOCUMENTOS);
			dynStr.Append("@CBA@PERSONA_VALORES_ID=");
			dynStr.Append(PERSONA_VALORES_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_RECIBO_ID=");
			dynStr.Append(IsAUTONUMERACION_RECIBO_IDNull ? (object)"<NULL>" : AUTONUMERACION_RECIBO_ID);
			dynStr.Append("@CBA@CTACTE_RECIBO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_ID);
			dynStr.Append("@CBA@NRO_RECIBO_MANUAL=");
			dynStr.Append(NRO_RECIBO_MANUAL);
			dynStr.Append("@CBA@CONSOLIDACION_DEUDA=");
			dynStr.Append(CONSOLIDACION_DEUDA);
			dynStr.Append("@CBA@NC_DEPOSITO_ID=");
			dynStr.Append(IsNC_DEPOSITO_IDNull ? (object)"<NULL>" : NC_DEPOSITO_ID);
			dynStr.Append("@CBA@NC_AUTONUMERACION_ID=");
			dynStr.Append(IsNC_AUTONUMERACION_IDNull ? (object)"<NULL>" : NC_AUTONUMERACION_ID);
			dynStr.Append("@CBA@NC_NRO_COMPROBANTE=");
			dynStr.Append(NC_NRO_COMPROBANTE);
			dynStr.Append("@CBA@NC_CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsNC_CTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : NC_CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@FC_DEPOSITO_ID=");
			dynStr.Append(IsFC_DEPOSITO_IDNull ? (object)"<NULL>" : FC_DEPOSITO_ID);
			dynStr.Append("@CBA@FC_AUTONUMERACION_ID=");
			dynStr.Append(IsFC_AUTONUMERACION_IDNull ? (object)"<NULL>" : FC_AUTONUMERACION_ID);
			dynStr.Append("@CBA@FC_NRO_COMPROBANTE=");
			dynStr.Append(FC_NRO_COMPROBANTE);
			dynStr.Append("@CBA@FC_CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsFC_CTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : FC_CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@FC_CASO_ID=");
			dynStr.Append(IsFC_CASO_IDNull ? (object)"<NULL>" : FC_CASO_ID);
			dynStr.Append("@CBA@MONTO_NUEVA_CUOTA=");
			dynStr.Append(IsMONTO_NUEVA_CUOTANull ? (object)"<NULL>" : MONTO_NUEVA_CUOTA);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE_EXTERNO=");
			dynStr.Append(NRO_COMPROBANTE_EXTERNO);
			return dynStr.ToString();
		}
	} // End of APLICACION_DOCUMENTOSRow_Base class
} // End of namespace
