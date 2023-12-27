// <fileinfo name="FACTURA_ENVASES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="FACTURA_ENVASES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>FACTURA_ENVASES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURA_ENVASES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURA_ENVASES_INFO_COMPLETARow_Base
	{
		private string _nro_comprobante;
		private decimal _factura_nro_caso;
		private decimal _detalle_factura_id;
		private decimal _factura_envase_id;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _peso_factura;
		private bool _peso_facturaNull = true;
		private decimal _envase_id;
		private string _codigo;
		private string _nombre;
		private string _unidad_id;
		private string _pesable;
		private decimal _peso;
		private bool _pesoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURA_ENVASES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public FACTURA_ENVASES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURA_ENVASES_INFO_COMPLETARow_Base original)
		{
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FACTURA_NRO_CASO != original.FACTURA_NRO_CASO) return true;
			if (this.DETALLE_FACTURA_ID != original.DETALLE_FACTURA_ID) return true;
			if (this.FACTURA_ENVASE_ID != original.FACTURA_ENVASE_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsPESO_FACTURANull != original.IsPESO_FACTURANull) return true;
			if (!this.IsPESO_FACTURANull && !original.IsPESO_FACTURANull)
				if (this.PESO_FACTURA != original.PESO_FACTURA) return true;
			if (this.ENVASE_ID != original.ENVASE_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.PESABLE != original.PESABLE) return true;
			if (this.IsPESONull != original.IsPESONull) return true;
			if (!this.IsPESONull && !original.IsPESONull)
				if (this.PESO != original.PESO) return true;
			
			return false;
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
		/// Gets or sets the <c>FACTURA_NRO_CASO</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_NRO_CASO</c> column value.</value>
		public decimal FACTURA_NRO_CASO
		{
			get { return _factura_nro_caso; }
			set { _factura_nro_caso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DETALLE_FACTURA_ID</c> column value.
		/// </summary>
		/// <value>The <c>DETALLE_FACTURA_ID</c> column value.</value>
		public decimal DETALLE_FACTURA_ID
		{
			get { return _detalle_factura_id; }
			set { _detalle_factura_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_ENVASE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_ENVASE_ID</c> column value.</value>
		public decimal FACTURA_ENVASE_ID
		{
			get { return _factura_envase_id; }
			set { _factura_envase_id = value; }
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
		/// Gets or sets the <c>PESO_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_FACTURA</c> column value.</value>
		public decimal PESO_FACTURA
		{
			get
			{
				if(IsPESO_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_factura;
			}
			set
			{
				_peso_facturaNull = false;
				_peso_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_FACTURANull
		{
			get { return _peso_facturaNull; }
			set { _peso_facturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENVASE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENVASE_ID</c> column value.</value>
		public decimal ENVASE_ID
		{
			get { return _envase_id; }
			set { _envase_id = value; }
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESABLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESABLE</c> column value.</value>
		public string PESABLE
		{
			get { return _pesable; }
			set { _pesable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO</c> column value.</value>
		public decimal PESO
		{
			get
			{
				if(IsPESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso;
			}
			set
			{
				_pesoNull = false;
				_peso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESONull
		{
			get { return _pesoNull; }
			set { _pesoNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FACTURA_NRO_CASO=");
			dynStr.Append(FACTURA_NRO_CASO);
			dynStr.Append("@CBA@DETALLE_FACTURA_ID=");
			dynStr.Append(DETALLE_FACTURA_ID);
			dynStr.Append("@CBA@FACTURA_ENVASE_ID=");
			dynStr.Append(FACTURA_ENVASE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@PESO_FACTURA=");
			dynStr.Append(IsPESO_FACTURANull ? (object)"<NULL>" : PESO_FACTURA);
			dynStr.Append("@CBA@ENVASE_ID=");
			dynStr.Append(ENVASE_ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@PESABLE=");
			dynStr.Append(PESABLE);
			dynStr.Append("@CBA@PESO=");
			dynStr.Append(IsPESONull ? (object)"<NULL>" : PESO);
			return dynStr.ToString();
		}
	} // End of FACTURA_ENVASES_INFO_COMPLETARow_Base class
} // End of namespace
