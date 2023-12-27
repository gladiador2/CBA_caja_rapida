// <fileinfo name="ORDENES_COMPRA_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ORDENES_COMPRA_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ORDENES_COMPRA_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_COMPRA_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_COMPRA_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private System.DateTime _caso_fecha_creacion;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _proveedor_id;
		private string _proveedor_razon_social;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private System.DateTime _fecha_pedido;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion_timbrado;
		private string _nro_comprobante;
		private string _hora_pedido;
		private string _observacion;
		private string _funcionario;
		private decimal _total_orden_compra;
		private bool _total_orden_compraNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_COMPRA_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ORDENES_COMPRA_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_COMPRA_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_FECHA_CREACION != original.CASO_FECHA_CREACION) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.FECHA_PEDIDO != original.FECHA_PEDIDO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.HORA_PEDIDO != original.HORA_PEDIDO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FUNCIONARIO != original.FUNCIONARIO) return true;
			if (this.IsTOTAL_ORDEN_COMPRANull != original.IsTOTAL_ORDEN_COMPRANull) return true;
			if (!this.IsTOTAL_ORDEN_COMPRANull && !original.IsTOTAL_ORDEN_COMPRANull)
				if (this.TOTAL_ORDEN_COMPRA != original.TOTAL_ORDEN_COMPRA) return true;
			
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
		/// Gets or sets the <c>CASO_FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FECHA_CREACION</c> column value.</value>
		public System.DateTime CASO_FECHA_CREACION
		{
			get { return _caso_fecha_creacion; }
			set { _caso_fecha_creacion = value; }
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RAZON_SOCIAL</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_NOMBRE</c> column value.</value>
		public string DEPOSITO_NOMBRE
		{
			get { return _deposito_nombre; }
			set { _deposito_nombre = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PEDIDO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_PEDIDO</c> column value.</value>
		public System.DateTime FECHA_PEDIDO
		{
			get { return _fecha_pedido; }
			set { _fecha_pedido = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_TIMBRADO</c> column value.</value>
		public string AUTONUMERACION_TIMBRADO
		{
			get { return _autonumeracion_timbrado; }
			set { _autonumeracion_timbrado = value; }
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
		/// Gets or sets the <c>HORA_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORA_PEDIDO</c> column value.</value>
		public string HORA_PEDIDO
		{
			get { return _hora_pedido; }
			set { _hora_pedido = value; }
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
		/// Gets or sets the <c>FUNCIONARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO</c> column value.</value>
		public string FUNCIONARIO
		{
			get { return _funcionario; }
			set { _funcionario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_ORDEN_COMPRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_ORDEN_COMPRA</c> column value.</value>
		public decimal TOTAL_ORDEN_COMPRA
		{
			get
			{
				if(IsTOTAL_ORDEN_COMPRANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_orden_compra;
			}
			set
			{
				_total_orden_compraNull = false;
				_total_orden_compra = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_ORDEN_COMPRA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_ORDEN_COMPRANull
		{
			get { return _total_orden_compraNull; }
			set { _total_orden_compraNull = value; }
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
			dynStr.Append("@CBA@CASO_FECHA_CREACION=");
			dynStr.Append(CASO_FECHA_CREACION);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@FECHA_PEDIDO=");
			dynStr.Append(FECHA_PEDIDO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@HORA_PEDIDO=");
			dynStr.Append(HORA_PEDIDO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FUNCIONARIO=");
			dynStr.Append(FUNCIONARIO);
			dynStr.Append("@CBA@TOTAL_ORDEN_COMPRA=");
			dynStr.Append(IsTOTAL_ORDEN_COMPRANull ? (object)"<NULL>" : TOTAL_ORDEN_COMPRA);
			return dynStr.ToString();
		}
	} // End of ORDENES_COMPRA_INFO_COMPLETARow_Base class
} // End of namespace
