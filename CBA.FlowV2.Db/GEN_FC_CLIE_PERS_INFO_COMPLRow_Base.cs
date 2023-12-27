// <fileinfo name="GEN_FC_CLIE_PERS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>GEN_FC_CLIE_PERS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIE_PERS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private string _persona_codigo;
		private string _persona_nombre;
		private string _persona_documento;
		private decimal _generacion_fc_cliente_id;
		private decimal _condicion_id;
		private string _condicion_nombre;
		private decimal _funcionario_vendedor_id;
		private bool _funcionario_vendedor_idNull = true;
		private System.DateTime _fecha;
		private string _factura_generada;
		private string _funcionario_codigo;
		private string _funcionario_nombre;
		private decimal _caso_factura_generada_id;
		private bool _caso_factura_generada_idNull = true;
		private string _caso_estado;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidades_decimales;
		private bool _moneda_cantidades_decimalesNull = true;
		private string _moneda_cadena_decimales;
		private string _nro_comprobante;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion_codigo;
		private string _autonumeracion_timbrado;
		private string _anulada;
		private string _pagada;
		private string _afecta_stock;
		private string _afecta_ctacte;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public GEN_FC_CLIE_PERS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GEN_FC_CLIE_PERS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_DOCUMENTO != original.PERSONA_DOCUMENTO) return true;
			if (this.GENERACION_FC_CLIENTE_ID != original.GENERACION_FC_CLIENTE_ID) return true;
			if (this.CONDICION_ID != original.CONDICION_ID) return true;
			if (this.CONDICION_NOMBRE != original.CONDICION_NOMBRE) return true;
			if (this.IsFUNCIONARIO_VENDEDOR_IDNull != original.IsFUNCIONARIO_VENDEDOR_IDNull) return true;
			if (!this.IsFUNCIONARIO_VENDEDOR_IDNull && !original.IsFUNCIONARIO_VENDEDOR_IDNull)
				if (this.FUNCIONARIO_VENDEDOR_ID != original.FUNCIONARIO_VENDEDOR_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.FACTURA_GENERADA != original.FACTURA_GENERADA) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.IsCASO_FACTURA_GENERADA_IDNull != original.IsCASO_FACTURA_GENERADA_IDNull) return true;
			if (!this.IsCASO_FACTURA_GENERADA_IDNull && !original.IsCASO_FACTURA_GENERADA_IDNull)
				if (this.CASO_FACTURA_GENERADA_ID != original.CASO_FACTURA_GENERADA_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsMONEDA_CANTIDADES_DECIMALESNull != original.IsMONEDA_CANTIDADES_DECIMALESNull) return true;
			if (!this.IsMONEDA_CANTIDADES_DECIMALESNull && !original.IsMONEDA_CANTIDADES_DECIMALESNull)
				if (this.MONEDA_CANTIDADES_DECIMALES != original.MONEDA_CANTIDADES_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_CODIGO != original.AUTONUMERACION_CODIGO) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.ANULADA != original.ANULADA) return true;
			if (this.PAGADA != original.PAGADA) return true;
			if (this.AFECTA_STOCK != original.AFECTA_STOCK) return true;
			if (this.AFECTA_CTACTE != original.AFECTA_CTACTE) return true;
			
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
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DOCUMENTO</c> column value.</value>
		public string PERSONA_DOCUMENTO
		{
			get { return _persona_documento; }
			set { _persona_documento = value; }
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
		/// Gets or sets the <c>CONDICION_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CONDICION_NOMBRE</c> column value.</value>
		public string CONDICION_NOMBRE
		{
			get { return _condicion_nombre; }
			set { _condicion_nombre = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
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
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDADES_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDADES_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDADES_DECIMALES
		{
			get
			{
				if(IsMONEDA_CANTIDADES_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cantidades_decimales;
			}
			set
			{
				_moneda_cantidades_decimalesNull = false;
				_moneda_cantidades_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_CANTIDADES_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_CANTIDADES_DECIMALESNull
		{
			get { return _moneda_cantidades_decimalesNull; }
			set { _moneda_cantidades_decimalesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_CODIGO</c> column value.</value>
		public string AUTONUMERACION_CODIGO
		{
			get { return _autonumeracion_codigo; }
			set { _autonumeracion_codigo = value; }
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
		/// Gets or sets the <c>AFECTA_STOCK</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_STOCK</c> column value.</value>
		public string AFECTA_STOCK
		{
			get { return _afecta_stock; }
			set { _afecta_stock = value; }
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
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_DOCUMENTO=");
			dynStr.Append(PERSONA_DOCUMENTO);
			dynStr.Append("@CBA@GENERACION_FC_CLIENTE_ID=");
			dynStr.Append(GENERACION_FC_CLIENTE_ID);
			dynStr.Append("@CBA@CONDICION_ID=");
			dynStr.Append(CONDICION_ID);
			dynStr.Append("@CBA@CONDICION_NOMBRE=");
			dynStr.Append(CONDICION_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_VENDEDOR_ID=");
			dynStr.Append(IsFUNCIONARIO_VENDEDOR_IDNull ? (object)"<NULL>" : FUNCIONARIO_VENDEDOR_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FACTURA_GENERADA=");
			dynStr.Append(FACTURA_GENERADA);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@CASO_FACTURA_GENERADA_ID=");
			dynStr.Append(IsCASO_FACTURA_GENERADA_IDNull ? (object)"<NULL>" : CASO_FACTURA_GENERADA_ID);
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDADES_DECIMALES=");
			dynStr.Append(IsMONEDA_CANTIDADES_DECIMALESNull ? (object)"<NULL>" : MONEDA_CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_CODIGO=");
			dynStr.Append(AUTONUMERACION_CODIGO);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@ANULADA=");
			dynStr.Append(ANULADA);
			dynStr.Append("@CBA@PAGADA=");
			dynStr.Append(PAGADA);
			dynStr.Append("@CBA@AFECTA_STOCK=");
			dynStr.Append(AFECTA_STOCK);
			dynStr.Append("@CBA@AFECTA_CTACTE=");
			dynStr.Append(AFECTA_CTACTE);
			return dynStr.ToString();
		}
	} // End of GEN_FC_CLIE_PERS_INFO_COMPLRow_Base class
} // End of namespace
