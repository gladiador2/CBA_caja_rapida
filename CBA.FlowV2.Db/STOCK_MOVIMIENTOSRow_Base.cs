// <fileinfo name="STOCK_MOVIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="STOCK_MOVIMIENTOSRow"/> that 
	/// represents a record in the <c>STOCK_MOVIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_MOVIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_MOVIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _deposito_id;
		private decimal _articulo_id;
		private string _tipo_movimiento;
		private decimal _cantidad;
		private System.DateTime _fecha_movimiento;
		private decimal _usuario_id;
		private decimal _lote_id;
		private decimal _existencia;
		private bool _existenciaNull = true;
		private decimal _costo;
		private decimal _costo_moneda_id;
		private decimal _costo_cotizacion_moneda;
		private System.DateTime _fecha_formulario;
		private decimal _costo_origen;
		private decimal _costo_moneda_origen_id;
		private decimal _costo_cotizacion_moneda_origen;
		private string _estado;
		private decimal _sucursal_id;
		private decimal _impuesto_id;
		private decimal _registro_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_MOVIMIENTOSRow_Base"/> class.
		/// </summary>
		public STOCK_MOVIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_MOVIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsEXISTENCIANull != original.IsEXISTENCIANull) return true;
			if (!this.IsEXISTENCIANull && !original.IsEXISTENCIANull)
				if (this.EXISTENCIA != original.EXISTENCIA) return true;
			if (this.COSTO != original.COSTO) return true;
			if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.COSTO_COTIZACION_MONEDA != original.COSTO_COTIZACION_MONEDA) return true;
			if (this.FECHA_FORMULARIO != original.FECHA_FORMULARIO) return true;
			if (this.COSTO_ORIGEN != original.COSTO_ORIGEN) return true;
			if (this.COSTO_MONEDA_ORIGEN_ID != original.COSTO_MONEDA_ORIGEN_ID) return true;
			if (this.COSTO_COTIZACION_MONEDA_ORIGEN != original.COSTO_COTIZACION_MONEDA_ORIGEN) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MOVIMIENTO</c> column value.</value>
		public System.DateTime FECHA_MOVIMIENTO
		{
			get { return _fecha_movimiento; }
			set { _fecha_movimiento = value; }
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
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTENCIA</c> column value.</value>
		public decimal EXISTENCIA
		{
			get
			{
				if(IsEXISTENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _existencia;
			}
			set
			{
				_existenciaNull = false;
				_existencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EXISTENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEXISTENCIANull
		{
			get { return _existenciaNull; }
			set { _existenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get { return _costo; }
			set { _costo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ID
		{
			get { return _costo_moneda_id; }
			set { _costo_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION_MONEDA</c> column value.</value>
		public decimal COSTO_COTIZACION_MONEDA
		{
			get { return _costo_cotizacion_moneda; }
			set { _costo_cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMULARIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMULARIO</c> column value.</value>
		public System.DateTime FECHA_FORMULARIO
		{
			get { return _fecha_formulario; }
			set { _fecha_formulario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_ORIGEN</c> column value.</value>
		public decimal COSTO_ORIGEN
		{
			get { return _costo_origen; }
			set { _costo_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ORIGEN_ID
		{
			get { return _costo_moneda_origen_id; }
			set { _costo_moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COSTO_COTIZACION_MONEDA_ORIGEN
		{
			get { return _costo_cotizacion_moneda_origen; }
			set { _costo_cotizacion_moneda_origen = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
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
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(IsEXISTENCIANull ? (object)"<NULL>" : EXISTENCIA);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(COSTO);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_COTIZACION_MONEDA=");
			dynStr.Append(COSTO_COTIZACION_MONEDA);
			dynStr.Append("@CBA@FECHA_FORMULARIO=");
			dynStr.Append(FECHA_FORMULARIO);
			dynStr.Append("@CBA@COSTO_ORIGEN=");
			dynStr.Append(COSTO_ORIGEN);
			dynStr.Append("@CBA@COSTO_MONEDA_ORIGEN_ID=");
			dynStr.Append(COSTO_MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COSTO_COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COSTO_COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			return dynStr.ToString();
		}
	} // End of STOCK_MOVIMIENTOSRow_Base class
} // End of namespace
