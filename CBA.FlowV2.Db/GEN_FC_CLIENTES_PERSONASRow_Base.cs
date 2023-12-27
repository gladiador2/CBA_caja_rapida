// <fileinfo name="GEN_FC_CLIENTES_PERSONASRow_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIENTES_PERSONASRow"/> that 
	/// represents a record in the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GEN_FC_CLIENTES_PERSONASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIENTES_PERSONASRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _generacion_fc_cliente_id;
		private decimal _condicion_id;
		private decimal _funcionario_vendedor_id;
		private bool _funcionario_vendedor_idNull = true;
		private System.DateTime _fecha;
		private string _factura_generada;
		private decimal _caso_factura_generada_id;
		private bool _caso_factura_generada_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _nro_comprobante;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _anulada;
		private string _pagada;
		private string _afecta_ctacte;
		private string _afecta_stock;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIENTES_PERSONASRow_Base"/> class.
		/// </summary>
		public GEN_FC_CLIENTES_PERSONASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GEN_FC_CLIENTES_PERSONASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.GENERACION_FC_CLIENTE_ID != original.GENERACION_FC_CLIENTE_ID) return true;
			if (this.CONDICION_ID != original.CONDICION_ID) return true;
			if (this.IsFUNCIONARIO_VENDEDOR_IDNull != original.IsFUNCIONARIO_VENDEDOR_IDNull) return true;
			if (!this.IsFUNCIONARIO_VENDEDOR_IDNull && !original.IsFUNCIONARIO_VENDEDOR_IDNull)
				if (this.FUNCIONARIO_VENDEDOR_ID != original.FUNCIONARIO_VENDEDOR_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.FACTURA_GENERADA != original.FACTURA_GENERADA) return true;
			if (this.IsCASO_FACTURA_GENERADA_IDNull != original.IsCASO_FACTURA_GENERADA_IDNull) return true;
			if (!this.IsCASO_FACTURA_GENERADA_IDNull && !original.IsCASO_FACTURA_GENERADA_IDNull)
				if (this.CASO_FACTURA_GENERADA_ID != original.CASO_FACTURA_GENERADA_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.ANULADA != original.ANULADA) return true;
			if (this.PAGADA != original.PAGADA) return true;
			if (this.AFECTA_CTACTE != original.AFECTA_CTACTE) return true;
			if (this.AFECTA_STOCK != original.AFECTA_STOCK) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERACION_FC_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>GENERACION_FC_CLIENTE_ID</c> column value.</value>
		public decimal GENERACION_FC_CLIENTE_ID
		{
			get { return _generacion_fc_cliente_id; }
			set { _generacion_fc_cliente_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONDICION_ID</c> column value.</value>
		public decimal CONDICION_ID
		{
			get { return _condicion_id; }
			set { _condicion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_VENDEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</value>
		public decimal FUNCIONARIO_VENDEDOR_ID
		{
			get
			{
				if(IsFUNCIONARIO_VENDEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_vendedor_id;
			}
			set
			{
				_funcionario_vendedor_idNull = false;
				_funcionario_vendedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_VENDEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_VENDEDOR_IDNull
		{
			get { return _funcionario_vendedor_idNull; }
			set { _funcionario_vendedor_idNull = value; }
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
		/// Gets or sets the <c>FACTURA_GENERADA</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_GENERADA</c> column value.</value>
		public string FACTURA_GENERADA
		{
			get { return _factura_generada; }
			set { _factura_generada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FACTURA_GENERADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FACTURA_GENERADA_ID</c> column value.</value>
		public decimal CASO_FACTURA_GENERADA_ID
		{
			get
			{
				if(IsCASO_FACTURA_GENERADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_factura_generada_id;
			}
			set
			{
				_caso_factura_generada_idNull = false;
				_caso_factura_generada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_FACTURA_GENERADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_FACTURA_GENERADA_IDNull
		{
			get { return _caso_factura_generada_idNull; }
			set { _caso_factura_generada_idNull = value; }
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
		/// Gets or sets the <c>ANULADA</c> column value.
		/// </summary>
		/// <value>The <c>ANULADA</c> column value.</value>
		public string ANULADA
		{
			get { return _anulada; }
			set { _anulada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGADA</c> column value.
		/// </summary>
		/// <value>The <c>PAGADA</c> column value.</value>
		public string PAGADA
		{
			get { return _pagada; }
			set { _pagada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CTACTE</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CTACTE</c> column value.</value>
		public string AFECTA_CTACTE
		{
			get { return _afecta_ctacte; }
			set { _afecta_ctacte = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_STOCK</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_STOCK</c> column value.</value>
		public string AFECTA_STOCK
		{
			get { return _afecta_stock; }
			set { _afecta_stock = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@GENERACION_FC_CLIENTE_ID=");
			dynStr.Append(GENERACION_FC_CLIENTE_ID);
			dynStr.Append("@CBA@CONDICION_ID=");
			dynStr.Append(CONDICION_ID);
			dynStr.Append("@CBA@FUNCIONARIO_VENDEDOR_ID=");
			dynStr.Append(IsFUNCIONARIO_VENDEDOR_IDNull ? (object)"<NULL>" : FUNCIONARIO_VENDEDOR_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FACTURA_GENERADA=");
			dynStr.Append(FACTURA_GENERADA);
			dynStr.Append("@CBA@CASO_FACTURA_GENERADA_ID=");
			dynStr.Append(IsCASO_FACTURA_GENERADA_IDNull ? (object)"<NULL>" : CASO_FACTURA_GENERADA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@ANULADA=");
			dynStr.Append(ANULADA);
			dynStr.Append("@CBA@PAGADA=");
			dynStr.Append(PAGADA);
			dynStr.Append("@CBA@AFECTA_CTACTE=");
			dynStr.Append(AFECTA_CTACTE);
			dynStr.Append("@CBA@AFECTA_STOCK=");
			dynStr.Append(AFECTA_STOCK);
			return dynStr.ToString();
		}
	} // End of GEN_FC_CLIENTES_PERSONASRow_Base class
} // End of namespace
