// <fileinfo name="COTIZACIONES_MONEDARow_Base.cs">
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
	/// The base class for <see cref="COTIZACIONES_MONEDARow"/> that 
	/// represents a record in the <c>COTIZACIONES_MONEDA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COTIZACIONES_MONEDARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COTIZACIONES_MONEDARow_Base
	{
		private decimal _id;
		private decimal _orden;
		private bool _ordenNull = true;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private string _moneda;
		private string _simbolo;
		private decimal _pais_id;
		private string _pais;
		private decimal _entidad_id;
		private string _entidad;
		private decimal _compra;
		private decimal _venta;

		/// <summary>
		/// Initializes a new instance of the <see cref="COTIZACIONES_MONEDARow_Base"/> class.
		/// </summary>
		public COTIZACIONES_MONEDARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COTIZACIONES_MONEDARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA != original.MONEDA) return true;
			if (this.SIMBOLO != original.SIMBOLO) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.PAIS != original.PAIS) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTIDAD != original.ENTIDAD) return true;
			if (this.COMPRA != original.COMPRA) return true;
			if (this.VENTA != original.VENTA) return true;
			
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
		/// Gets or sets the <c>MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA</c> column value.</value>
		public string MONEDA
		{
			get { return _moneda; }
			set { _moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>SIMBOLO</c> column value.</value>
		public string SIMBOLO
		{
			get { return _simbolo; }
			set { _simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS</c> column value.
		/// </summary>
		/// <value>The <c>PAIS</c> column value.</value>
		public string PAIS
		{
			get { return _pais; }
			set { _pais = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD</c> column value.</value>
		public string ENTIDAD
		{
			get { return _entidad; }
			set { _entidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>COMPRA</c> column value.</value>
		public decimal COMPRA
		{
			get { return _compra; }
			set { _compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENTA</c> column value.
		/// </summary>
		/// <value>The <c>VENTA</c> column value.</value>
		public decimal VENTA
		{
			get { return _venta; }
			set { _venta = value; }
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
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA=");
			dynStr.Append(MONEDA);
			dynStr.Append("@CBA@SIMBOLO=");
			dynStr.Append(SIMBOLO);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@PAIS=");
			dynStr.Append(PAIS);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ENTIDAD=");
			dynStr.Append(ENTIDAD);
			dynStr.Append("@CBA@COMPRA=");
			dynStr.Append(COMPRA);
			dynStr.Append("@CBA@VENTA=");
			dynStr.Append(VENTA);
			return dynStr.ToString();
		}
	} // End of COTIZACIONES_MONEDARow_Base class
} // End of namespace
