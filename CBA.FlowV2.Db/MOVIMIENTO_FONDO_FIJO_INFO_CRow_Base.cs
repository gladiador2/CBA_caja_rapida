// <fileinfo name="MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="MOVIMIENTO_FONDO_FIJO_INFO_CRow"/> that 
	/// represents a record in the <c>MOVIMIENTO_FONDO_FIJO_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MOVIMIENTO_FONDO_FIJO_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private string _ctacte_fondo_fijo_nombre;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private System.DateTime _fecha;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private decimal _moneda_id;
		private string _moneda_simbolo;
		private decimal _moneda_cantidades_decimales;
		private decimal _cotizacion_moneda;
		private decimal _monto_total_ingreso;
		private string _observacion;
		private decimal _monto_total_egreso;
		private decimal _usuario_creacion_id;
		private string _estado;
		private decimal _anticipo_prov_utiliza_caso_id;
		private bool _anticipo_prov_utiliza_caso_idNull = true;
		private decimal _pago_contratista_detalle_id;
		private bool _pago_contratista_detalle_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base"/> class.
		/// </summary>
		public MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.CTACTE_FONDO_FIJO_NOMBRE != original.CTACTE_FONDO_FIJO_NOMBRE) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDADES_DECIMALES != original.MONEDA_CANTIDADES_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL_INGRESO != original.MONTO_TOTAL_INGRESO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MONTO_TOTAL_EGRESO != original.MONTO_TOTAL_EGRESO) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull != original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull) return true;
			if (!this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull && !original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
				if (this.ANTICIPO_PROV_UTILIZA_CASO_ID != original.ANTICIPO_PROV_UTILIZA_CASO_ID) return true;
			if (this.IsPAGO_CONTRATISTA_DETALLE_IDNull != original.IsPAGO_CONTRATISTA_DETALLE_IDNull) return true;
			if (!this.IsPAGO_CONTRATISTA_DETALLE_IDNull && !original.IsPAGO_CONTRATISTA_DETALLE_IDNull)
				if (this.PAGO_CONTRATISTA_DETALLE_ID != original.PAGO_CONTRATISTA_DETALLE_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.</value>
		public string CTACTE_FONDO_FIJO_NOMBRE
		{
			get { return _ctacte_fondo_fijo_nombre; }
			set { _ctacte_fondo_fijo_nombre = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDADES_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDADES_DECIMALES
		{
			get { return _moneda_cantidades_decimales; }
			set { _moneda_cantidades_decimales = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL_INGRESO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_INGRESO</c> column value.</value>
		public decimal MONTO_TOTAL_INGRESO
		{
			get { return _monto_total_ingreso; }
			set { _monto_total_ingreso = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL_EGRESO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_EGRESO</c> column value.</value>
		public decimal MONTO_TOTAL_EGRESO
		{
			get { return _monto_total_egreso; }
			set { _monto_total_egreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
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
		/// Gets or sets the <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.</value>
		public decimal ANTICIPO_PROV_UTILIZA_CASO_ID
		{
			get
			{
				if(IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_prov_utiliza_caso_id;
			}
			set
			{
				_anticipo_prov_utiliza_caso_idNull = false;
				_anticipo_prov_utiliza_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PROV_UTILIZA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PROV_UTILIZA_CASO_IDNull
		{
			get { return _anticipo_prov_utiliza_caso_idNull; }
			set { _anticipo_prov_utiliza_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</value>
		public decimal PAGO_CONTRATISTA_DETALLE_ID
		{
			get
			{
				if(IsPAGO_CONTRATISTA_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pago_contratista_detalle_id;
			}
			set
			{
				_pago_contratista_detalle_idNull = false;
				_pago_contratista_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAGO_CONTRATISTA_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAGO_CONTRATISTA_DETALLE_IDNull
		{
			get { return _pago_contratista_detalle_idNull; }
			set { _pago_contratista_detalle_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_NOMBRE=");
			dynStr.Append(CTACTE_FONDO_FIJO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDADES_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL_INGRESO=");
			dynStr.Append(MONTO_TOTAL_INGRESO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONTO_TOTAL_EGRESO=");
			dynStr.Append(MONTO_TOTAL_EGRESO);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ANTICIPO_PROV_UTILIZA_CASO_ID=");
			dynStr.Append(IsANTICIPO_PROV_UTILIZA_CASO_IDNull ? (object)"<NULL>" : ANTICIPO_PROV_UTILIZA_CASO_ID);
			dynStr.Append("@CBA@PAGO_CONTRATISTA_DETALLE_ID=");
			dynStr.Append(IsPAGO_CONTRATISTA_DETALLE_IDNull ? (object)"<NULL>" : PAGO_CONTRATISTA_DETALLE_ID);
			return dynStr.ToString();
		}
	} // End of MOVIMIENTO_FONDO_FIJO_INFO_CRow_Base class
} // End of namespace
