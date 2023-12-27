// <fileinfo name="CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJA_COMPOS_DET_INF_COMRow"/> that 
	/// represents a record in the <c>CTACTE_CAJA_COMPOS_DET_INF_COM</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJA_COMPOS_DET_INF_COMRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base
	{
		private decimal _id;
		private decimal _ctacte_caja_composicion_id;
		private decimal _monedas_denominaciones_id;
		private bool _monedas_denominaciones_idNull = true;
		private decimal _moneda_denominacion;
		private bool _moneda_denominacionNull = true;
		private string _moneda_demon_descrip;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _moneda_id;
		private decimal _monto;
		private bool _montoNull = true;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _grupo;
		private bool _grupoNull = true;
		private System.DateTime _fecha_sistema;
		private bool _fecha_sistemaNull = true;
		private System.DateTime _fecha_manual;
		private bool _fecha_manualNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto;
		private decimal _tipo_texto_predefinido_id;
		private bool _tipo_texto_predefinido_idNull = true;
		private decimal _saldo_caja;
		private bool _saldo_cajaNull = true;
		private string _comentario;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_CAJA_COMPOSICION_ID != original.CTACTE_CAJA_COMPOSICION_ID) return true;
			if (this.IsMONEDAS_DENOMINACIONES_IDNull != original.IsMONEDAS_DENOMINACIONES_IDNull) return true;
			if (!this.IsMONEDAS_DENOMINACIONES_IDNull && !original.IsMONEDAS_DENOMINACIONES_IDNull)
				if (this.MONEDAS_DENOMINACIONES_ID != original.MONEDAS_DENOMINACIONES_ID) return true;
			if (this.IsMONEDA_DENOMINACIONNull != original.IsMONEDA_DENOMINACIONNull) return true;
			if (!this.IsMONEDA_DENOMINACIONNull && !original.IsMONEDA_DENOMINACIONNull)
				if (this.MONEDA_DENOMINACION != original.MONEDA_DENOMINACION) return true;
			if (this.MONEDA_DEMON_DESCRIP != original.MONEDA_DEMON_DESCRIP) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsGRUPONull != original.IsGRUPONull) return true;
			if (!this.IsGRUPONull && !original.IsGRUPONull)
				if (this.GRUPO != original.GRUPO) return true;
			if (this.IsFECHA_SISTEMANull != original.IsFECHA_SISTEMANull) return true;
			if (!this.IsFECHA_SISTEMANull && !original.IsFECHA_SISTEMANull)
				if (this.FECHA_SISTEMA != original.FECHA_SISTEMA) return true;
			if (this.IsFECHA_MANUALNull != original.IsFECHA_MANUALNull) return true;
			if (!this.IsFECHA_MANUALNull && !original.IsFECHA_MANUALNull)
				if (this.FECHA_MANUAL != original.FECHA_MANUAL) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.IsTIPO_TEXTO_PREDEFINIDO_IDNull != original.IsTIPO_TEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTIPO_TEXTO_PREDEFINIDO_IDNull && !original.IsTIPO_TEXTO_PREDEFINIDO_IDNull)
				if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsSALDO_CAJANull != original.IsSALDO_CAJANull) return true;
			if (!this.IsSALDO_CAJANull && !original.IsSALDO_CAJANull)
				if (this.SALDO_CAJA != original.SALDO_CAJA) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			
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
		/// Gets or sets the <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</value>
		public decimal CTACTE_CAJA_COMPOSICION_ID
		{
			get { return _ctacte_caja_composicion_id; }
			set { _ctacte_caja_composicion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_DENOMINACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</value>
		public decimal MONEDAS_DENOMINACIONES_ID
		{
			get
			{
				if(IsMONEDAS_DENOMINACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monedas_denominaciones_id;
			}
			set
			{
				_monedas_denominaciones_idNull = false;
				_monedas_denominaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDAS_DENOMINACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDAS_DENOMINACIONES_IDNull
		{
			get { return _monedas_denominaciones_idNull; }
			set { _monedas_denominaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DENOMINACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DENOMINACION</c> column value.</value>
		public decimal MONEDA_DENOMINACION
		{
			get
			{
				if(IsMONEDA_DENOMINACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_denominacion;
			}
			set
			{
				_moneda_denominacionNull = false;
				_moneda_denominacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_DENOMINACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_DENOMINACIONNull
		{
			get { return _moneda_denominacionNull; }
			set { _moneda_denominacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DEMON_DESCRIP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DEMON_DESCRIP</c> column value.</value>
		public string MONEDA_DEMON_DESCRIP
		{
			get { return _moneda_demon_descrip; }
			set { _moneda_demon_descrip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO</c> column value.</value>
		public decimal GRUPO
		{
			get
			{
				if(IsGRUPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo;
			}
			set
			{
				_grupoNull = false;
				_grupo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPONull
		{
			get { return _grupoNull; }
			set { _grupoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SISTEMA</c> column value.</value>
		public System.DateTime FECHA_SISTEMA
		{
			get
			{
				if(IsFECHA_SISTEMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_sistema;
			}
			set
			{
				_fecha_sistemaNull = false;
				_fecha_sistema = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SISTEMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SISTEMANull
		{
			get { return _fecha_sistemaNull; }
			set { _fecha_sistemaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MANUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MANUAL</c> column value.</value>
		public System.DateTime FECHA_MANUAL
		{
			get
			{
				if(IsFECHA_MANUALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_manual;
			}
			set
			{
				_fecha_manualNull = false;
				_fecha_manual = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MANUAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MANUALNull
		{
			get { return _fecha_manualNull; }
			set { _fecha_manualNull = value; }
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
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTIPO_TEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_texto_predefinido_id;
			}
			set
			{
				_tipo_texto_predefinido_idNull = false;
				_tipo_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_TEXTO_PREDEFINIDO_IDNull
		{
			get { return _tipo_texto_predefinido_idNull; }
			set { _tipo_texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_CAJA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_CAJA</c> column value.</value>
		public decimal SALDO_CAJA
		{
			get
			{
				if(IsSALDO_CAJANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_caja;
			}
			set
			{
				_saldo_cajaNull = false;
				_saldo_caja = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_CAJA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_CAJANull
		{
			get { return _saldo_cajaNull; }
			set { _saldo_cajaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
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
			dynStr.Append("@CBA@CTACTE_CAJA_COMPOSICION_ID=");
			dynStr.Append(CTACTE_CAJA_COMPOSICION_ID);
			dynStr.Append("@CBA@MONEDAS_DENOMINACIONES_ID=");
			dynStr.Append(IsMONEDAS_DENOMINACIONES_IDNull ? (object)"<NULL>" : MONEDAS_DENOMINACIONES_ID);
			dynStr.Append("@CBA@MONEDA_DENOMINACION=");
			dynStr.Append(IsMONEDA_DENOMINACIONNull ? (object)"<NULL>" : MONEDA_DENOMINACION);
			dynStr.Append("@CBA@MONEDA_DEMON_DESCRIP=");
			dynStr.Append(MONEDA_DEMON_DESCRIP);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@GRUPO=");
			dynStr.Append(IsGRUPONull ? (object)"<NULL>" : GRUPO);
			dynStr.Append("@CBA@FECHA_SISTEMA=");
			dynStr.Append(IsFECHA_SISTEMANull ? (object)"<NULL>" : FECHA_SISTEMA);
			dynStr.Append("@CBA@FECHA_MANUAL=");
			dynStr.Append(IsFECHA_MANUALNull ? (object)"<NULL>" : FECHA_MANUAL);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTIPO_TEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TIPO_TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@SALDO_CAJA=");
			dynStr.Append(IsSALDO_CAJANull ? (object)"<NULL>" : SALDO_CAJA);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJA_COMPOS_DET_INF_COMRow_Base class
} // End of namespace
