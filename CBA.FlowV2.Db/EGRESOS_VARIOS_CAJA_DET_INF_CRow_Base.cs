// <fileinfo name="EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJA_DET_INF_CRow"/> that 
	/// represents a record in the <c>EGRESOS_VARIOS_CAJA_DET_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EGRESOS_VARIOS_CAJA_DET_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _involucrado_nombre;
		private decimal _ctacte_proveedor_id;
		private bool _ctacte_proveedor_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _caso_referido_id;
		private bool _caso_referido_idNull = true;
		private string _ctacte_observacion;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private string _moneda_origen_simbolo;
		private decimal _cotizacion_compra_origen;
		private bool _cotizacion_compra_origenNull = true;
		private decimal _monto_origen;
		private bool _monto_origenNull = true;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;
		private string _observacion;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base"/> class.
		/// </summary>
		public EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.INVOLUCRADO_NOMBRE != original.INVOLUCRADO_NOMBRE) return true;
			if (this.IsCTACTE_PROVEEDOR_IDNull != original.IsCTACTE_PROVEEDOR_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_IDNull && !original.IsCTACTE_PROVEEDOR_IDNull)
				if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCASO_REFERIDO_IDNull != original.IsCASO_REFERIDO_IDNull) return true;
			if (!this.IsCASO_REFERIDO_IDNull && !original.IsCASO_REFERIDO_IDNull)
				if (this.CASO_REFERIDO_ID != original.CASO_REFERIDO_ID) return true;
			if (this.CTACTE_OBSERVACION != original.CTACTE_OBSERVACION) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_ORIGEN_SIMBOLO != original.MONEDA_ORIGEN_SIMBOLO) return true;
			if (this.IsCOTIZACION_COMPRA_ORIGENNull != original.IsCOTIZACION_COMPRA_ORIGENNull) return true;
			if (!this.IsCOTIZACION_COMPRA_ORIGENNull && !original.IsCOTIZACION_COMPRA_ORIGENNull)
				if (this.COTIZACION_COMPRA_ORIGEN != original.COTIZACION_COMPRA_ORIGEN) return true;
			if (this.IsMONTO_ORIGENNull != original.IsMONTO_ORIGENNull) return true;
			if (!this.IsMONTO_ORIGENNull && !original.IsMONTO_ORIGENNull)
				if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.IsMONTO_DESTINONull != original.IsMONTO_DESTINONull) return true;
			if (!this.IsMONTO_DESTINONull && !original.IsMONTO_DESTINONull)
				if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_ID</c> column value.</value>
		public decimal EGRESO_VARIO_CAJA_ID
		{
			get
			{
				if(IsEGRESO_VARIO_CAJA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_caja_id;
			}
			set
			{
				_egreso_vario_caja_idNull = false;
				_egreso_vario_caja_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_CAJA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_CAJA_IDNull
		{
			get { return _egreso_vario_caja_idNull; }
			set { _egreso_vario_caja_idNull = value; }
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
		/// Gets or sets the <c>INVOLUCRADO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INVOLUCRADO_NOMBRE</c> column value.</value>
		public string INVOLUCRADO_NOMBRE
		{
			get { return _involucrado_nombre; }
			set { _involucrado_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_id;
			}
			set
			{
				_ctacte_proveedor_idNull = false;
				_ctacte_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_IDNull
		{
			get { return _ctacte_proveedor_idNull; }
			set { _ctacte_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_REFERIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_REFERIDO_ID</c> column value.</value>
		public decimal CASO_REFERIDO_ID
		{
			get
			{
				if(IsCASO_REFERIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_referido_id;
			}
			set
			{
				_caso_referido_idNull = false;
				_caso_referido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_REFERIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_REFERIDO_IDNull
		{
			get { return _caso_referido_idNull; }
			set { _caso_referido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_OBSERVACION</c> column value.</value>
		public string CTACTE_OBSERVACION
		{
			get { return _ctacte_observacion; }
			set { _ctacte_observacion = value; }
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
		/// Gets or sets the <c>MONEDA_ORIGEN_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_SIMBOLO</c> column value.</value>
		public string MONEDA_ORIGEN_SIMBOLO
		{
			get { return _moneda_origen_simbolo; }
			set { _moneda_origen_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_COMPRA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_COMPRA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_COMPRA_ORIGEN
		{
			get
			{
				if(IsCOTIZACION_COMPRA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_compra_origen;
			}
			set
			{
				_cotizacion_compra_origenNull = false;
				_cotizacion_compra_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_COMPRA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_COMPRA_ORIGENNull
		{
			get { return _cotizacion_compra_origenNull; }
			set { _cotizacion_compra_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get
			{
				if(IsMONTO_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_origen;
			}
			set
			{
				_monto_origenNull = false;
				_monto_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_ORIGENNull
		{
			get { return _monto_origenNull; }
			set { _monto_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get
			{
				if(IsMONTO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_destino;
			}
			set
			{
				_monto_destinoNull = false;
				_monto_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESTINONull
		{
			get { return _monto_destinoNull; }
			set { _monto_destinoNull = value; }
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@INVOLUCRADO_NOMBRE=");
			dynStr.Append(INVOLUCRADO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CASO_REFERIDO_ID=");
			dynStr.Append(IsCASO_REFERIDO_IDNull ? (object)"<NULL>" : CASO_REFERIDO_ID);
			dynStr.Append("@CBA@CTACTE_OBSERVACION=");
			dynStr.Append(CTACTE_OBSERVACION);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_SIMBOLO=");
			dynStr.Append(MONEDA_ORIGEN_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_COMPRA_ORIGEN=");
			dynStr.Append(IsCOTIZACION_COMPRA_ORIGENNull ? (object)"<NULL>" : COTIZACION_COMPRA_ORIGEN);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(IsMONTO_ORIGENNull ? (object)"<NULL>" : MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			return dynStr.ToString();
		}
	} // End of EGRESOS_VARIOS_CAJA_DET_INF_CRow_Base class
} // End of namespace
