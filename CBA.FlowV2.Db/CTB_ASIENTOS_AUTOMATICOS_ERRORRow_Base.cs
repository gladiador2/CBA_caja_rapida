// <fileinfo name="CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTOMATICOS_ERRORRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_AUTOMATICOS_ERROR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_AUTOMATICOS_ERRORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base
	{
		private decimal _id;
		private decimal _ctb_asiento_automatico_id;
		private decimal _ctb_cuenta_id;
		private bool _ctb_cuenta_idNull = true;
		private decimal _debe;
		private bool _debeNull = true;
		private decimal _haber;
		private bool _haberNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _debe_origen;
		private bool _debe_origenNull = true;
		private decimal _haber_origen;
		private bool _haber_origenNull = true;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private decimal _cotizacion_moneda_origen;
		private bool _cotizacion_moneda_origenNull = true;
		private string _observacion_sistema;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _motivo_error;
		private string _revisado;
		private decimal _usuario_revisado_id;
		private bool _usuario_revisado_idNull = true;
		private System.DateTime _fecha_revisado;
		private bool _fecha_revisadoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTO_AUTOMATICO_ID != original.CTB_ASIENTO_AUTOMATICO_ID) return true;
			if (this.IsCTB_CUENTA_IDNull != original.IsCTB_CUENTA_IDNull) return true;
			if (!this.IsCTB_CUENTA_IDNull && !original.IsCTB_CUENTA_IDNull)
				if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.IsDEBENull != original.IsDEBENull) return true;
			if (!this.IsDEBENull && !original.IsDEBENull)
				if (this.DEBE != original.DEBE) return true;
			if (this.IsHABERNull != original.IsHABERNull) return true;
			if (!this.IsHABERNull && !original.IsHABERNull)
				if (this.HABER != original.HABER) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.IsDEBE_ORIGENNull != original.IsDEBE_ORIGENNull) return true;
			if (!this.IsDEBE_ORIGENNull && !original.IsDEBE_ORIGENNull)
				if (this.DEBE_ORIGEN != original.DEBE_ORIGEN) return true;
			if (this.IsHABER_ORIGENNull != original.IsHABER_ORIGENNull) return true;
			if (!this.IsHABER_ORIGENNull && !original.IsHABER_ORIGENNull)
				if (this.HABER_ORIGEN != original.HABER_ORIGEN) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.IsCOTIZACION_MONEDA_ORIGENNull != original.IsCOTIZACION_MONEDA_ORIGENNull) return true;
			if (!this.IsCOTIZACION_MONEDA_ORIGENNull && !original.IsCOTIZACION_MONEDA_ORIGENNull)
				if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.OBSERVACION_SISTEMA != original.OBSERVACION_SISTEMA) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.MOTIVO_ERROR != original.MOTIVO_ERROR) return true;
			if (this.REVISADO != original.REVISADO) return true;
			if (this.IsUSUARIO_REVISADO_IDNull != original.IsUSUARIO_REVISADO_IDNull) return true;
			if (!this.IsUSUARIO_REVISADO_IDNull && !original.IsUSUARIO_REVISADO_IDNull)
				if (this.USUARIO_REVISADO_ID != original.USUARIO_REVISADO_ID) return true;
			if (this.IsFECHA_REVISADONull != original.IsFECHA_REVISADONull) return true;
			if (!this.IsFECHA_REVISADONull && !original.IsFECHA_REVISADONull)
				if (this.FECHA_REVISADO != original.FECHA_REVISADO) return true;
			
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
		/// Gets or sets the <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</value>
		public decimal CTB_ASIENTO_AUTOMATICO_ID
		{
			get { return _ctb_asiento_automatico_id; }
			set { _ctb_asiento_automatico_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get
			{
				if(IsCTB_CUENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_id;
			}
			set
			{
				_ctb_cuenta_idNull = false;
				_ctb_cuenta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_IDNull
		{
			get { return _ctb_cuenta_idNull; }
			set { _ctb_cuenta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBE</c> column value.</value>
		public decimal DEBE
		{
			get
			{
				if(IsDEBENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debe;
			}
			set
			{
				_debeNull = false;
				_debe = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBENull
		{
			get { return _debeNull; }
			set { _debeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HABER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HABER</c> column value.</value>
		public decimal HABER
		{
			get
			{
				if(IsHABERNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _haber;
			}
			set
			{
				_haberNull = false;
				_haber = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HABER"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHABERNull
		{
			get { return _haberNull; }
			set { _haberNull = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get
			{
				if(IsCOTIZACION_MONEDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda;
			}
			set
			{
				_cotizacion_monedaNull = false;
				_cotizacion_moneda = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDANull
		{
			get { return _cotizacion_monedaNull; }
			set { _cotizacion_monedaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBE_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBE_ORIGEN</c> column value.</value>
		public decimal DEBE_ORIGEN
		{
			get
			{
				if(IsDEBE_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debe_origen;
			}
			set
			{
				_debe_origenNull = false;
				_debe_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBE_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBE_ORIGENNull
		{
			get { return _debe_origenNull; }
			set { _debe_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HABER_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HABER_ORIGEN</c> column value.</value>
		public decimal HABER_ORIGEN
		{
			get
			{
				if(IsHABER_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _haber_origen;
			}
			set
			{
				_haber_origenNull = false;
				_haber_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HABER_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHABER_ORIGENNull
		{
			get { return _haber_origenNull; }
			set { _haber_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get
			{
				if(IsMONEDA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_origen_id;
			}
			set
			{
				_moneda_origen_idNull = false;
				_moneda_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ORIGEN_IDNull
		{
			get { return _moneda_origen_idNull; }
			set { _moneda_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get
			{
				if(IsCOTIZACION_MONEDA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda_origen;
			}
			set
			{
				_cotizacion_moneda_origenNull = false;
				_cotizacion_moneda_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDA_ORIGENNull
		{
			get { return _cotizacion_moneda_origenNull; }
			set { _cotizacion_moneda_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_SISTEMA</c> column value.</value>
		public string OBSERVACION_SISTEMA
		{
			get { return _observacion_sistema; }
			set { _observacion_sistema = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ERROR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_ERROR</c> column value.</value>
		public string MOTIVO_ERROR
		{
			get { return _motivo_error; }
			set { _motivo_error = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REVISADO</c> column value.
		/// </summary>
		/// <value>The <c>REVISADO</c> column value.</value>
		public string REVISADO
		{
			get { return _revisado; }
			set { _revisado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_REVISADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_REVISADO_ID</c> column value.</value>
		public decimal USUARIO_REVISADO_ID
		{
			get
			{
				if(IsUSUARIO_REVISADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_revisado_id;
			}
			set
			{
				_usuario_revisado_idNull = false;
				_usuario_revisado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_REVISADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_REVISADO_IDNull
		{
			get { return _usuario_revisado_idNull; }
			set { _usuario_revisado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_REVISADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_REVISADO</c> column value.</value>
		public System.DateTime FECHA_REVISADO
		{
			get
			{
				if(IsFECHA_REVISADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_revisado;
			}
			set
			{
				_fecha_revisadoNull = false;
				_fecha_revisado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_REVISADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_REVISADONull
		{
			get { return _fecha_revisadoNull; }
			set { _fecha_revisadoNull = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTO_AUTOMATICO_ID=");
			dynStr.Append(CTB_ASIENTO_AUTOMATICO_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(IsCTB_CUENTA_IDNull ? (object)"<NULL>" : CTB_CUENTA_ID);
			dynStr.Append("@CBA@DEBE=");
			dynStr.Append(IsDEBENull ? (object)"<NULL>" : DEBE);
			dynStr.Append("@CBA@HABER=");
			dynStr.Append(IsHABERNull ? (object)"<NULL>" : HABER);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@DEBE_ORIGEN=");
			dynStr.Append(IsDEBE_ORIGENNull ? (object)"<NULL>" : DEBE_ORIGEN);
			dynStr.Append("@CBA@HABER_ORIGEN=");
			dynStr.Append(IsHABER_ORIGENNull ? (object)"<NULL>" : HABER_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(IsCOTIZACION_MONEDA_ORIGENNull ? (object)"<NULL>" : COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@OBSERVACION_SISTEMA=");
			dynStr.Append(OBSERVACION_SISTEMA);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@MOTIVO_ERROR=");
			dynStr.Append(MOTIVO_ERROR);
			dynStr.Append("@CBA@REVISADO=");
			dynStr.Append(REVISADO);
			dynStr.Append("@CBA@USUARIO_REVISADO_ID=");
			dynStr.Append(IsUSUARIO_REVISADO_IDNull ? (object)"<NULL>" : USUARIO_REVISADO_ID);
			dynStr.Append("@CBA@FECHA_REVISADO=");
			dynStr.Append(IsFECHA_REVISADONull ? (object)"<NULL>" : FECHA_REVISADO);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_AUTOMATICOS_ERRORRow_Base class
} // End of namespace
