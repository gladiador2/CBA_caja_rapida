// <fileinfo name="ANTICIPOS_FACT_PROV_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_FACT_PROV_INFO_COMPRow"/> that 
	/// represents a record in the <c>ANTICIPOS_FACT_PROV_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ANTICIPOS_FACT_PROV_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_FACT_PROV_INFO_COMPRow_Base
	{
		private decimal _anticipo_proveedor_id;
		private decimal _factura_proveedor_id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _factura_caso;
		private string _proveedor_nombre;
		private string _factura_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_FACT_PROV_INFO_COMPRow_Base"/> class.
		/// </summary>
		public ANTICIPOS_FACT_PROV_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ANTICIPOS_FACT_PROV_INFO_COMPRow_Base original)
		{
			if (this.ANTICIPO_PROVEEDOR_ID != original.ANTICIPO_PROVEEDOR_ID) return true;
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.FACTURA_CASO != original.FACTURA_CASO) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.FACTURA_COMPROBANTE != original.FACTURA_COMPROBANTE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</value>
		public decimal ANTICIPO_PROVEEDOR_ID
		{
			get { return _anticipo_proveedor_id; }
			set { _anticipo_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_ID
		{
			get { return _factura_proveedor_id; }
			set { _factura_proveedor_id = value; }
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
		/// Gets or sets the <c>FACTURA_CASO</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_CASO</c> column value.</value>
		public decimal FACTURA_CASO
		{
			get { return _factura_caso; }
			set { _factura_caso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE</c> column value.</value>
		public string PROVEEDOR_NOMBRE
		{
			get { return _proveedor_nombre; }
			set { _proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_COMPROBANTE</c> column value.</value>
		public string FACTURA_COMPROBANTE
		{
			get { return _factura_comprobante; }
			set { _factura_comprobante = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ANTICIPO_PROVEEDOR_ID=");
			dynStr.Append(ANTICIPO_PROVEEDOR_ID);
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@FACTURA_CASO=");
			dynStr.Append(FACTURA_CASO);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@FACTURA_COMPROBANTE=");
			dynStr.Append(FACTURA_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of ANTICIPOS_FACT_PROV_INFO_COMPRow_Base class
} // End of namespace
