// <fileinfo name="GENER_FC_CLIENTE_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="GENER_FC_CLIENTE_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>GENER_FC_CLIENTE_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GENER_FC_CLIENTE_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GENER_FC_CLIENTE_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _deposito_id;
		private string _deposito_nombre;
		private string _deposito_abreviatura;
		private decimal _autonumeracion_id;
		private string _autonumeracion_timbrado;
		private string _autonumeracion_codigo;
		private string _autonumeracion_prefijo;
		private decimal _autonumeracion_actual;
		private decimal _autonumeracion_limite;
		private decimal _condicion_pago_id;
		private string _condicion_nombre;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;
		private string _lista_precio_nombre;
		private string _lista_precio_abreviatura;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;
		private decimal _funcionario_vendedor_id;
		private bool _funcionario_vendedor_idNull = true;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private System.DateTime _fecha;

		/// <summary>
		/// Initializes a new instance of the <see cref="GENER_FC_CLIENTE_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public GENER_FC_CLIENTE_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GENER_FC_CLIENTE_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.DEPOSITO_ABREVIATURA != original.DEPOSITO_ABREVIATURA) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.AUTONUMERACION_CODIGO != original.AUTONUMERACION_CODIGO) return true;
			if (this.AUTONUMERACION_PREFIJO != original.AUTONUMERACION_PREFIJO) return true;
			if (this.AUTONUMERACION_ACTUAL != original.AUTONUMERACION_ACTUAL) return true;
			if (this.AUTONUMERACION_LIMITE != original.AUTONUMERACION_LIMITE) return true;
			if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.CONDICION_NOMBRE != original.CONDICION_NOMBRE) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			if (this.LISTA_PRECIO_NOMBRE != original.LISTA_PRECIO_NOMBRE) return true;
			if (this.LISTA_PRECIO_ABREVIATURA != original.LISTA_PRECIO_ABREVIATURA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.IsFUNCIONARIO_VENDEDOR_IDNull != original.IsFUNCIONARIO_VENDEDOR_IDNull) return true;
			if (!this.IsFUNCIONARIO_VENDEDOR_IDNull && !original.IsFUNCIONARIO_VENDEDOR_IDNull)
				if (this.FUNCIONARIO_VENDEDOR_ID != original.FUNCIONARIO_VENDEDOR_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.FECHA != original.FECHA) return true;
			
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
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
		/// Gets or sets the <c>DEPOSITO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ABREVIATURA</c> column value.</value>
		public string DEPOSITO_ABREVIATURA
		{
			get { return _deposito_abreviatura; }
			set { _deposito_abreviatura = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_PREFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_PREFIJO</c> column value.</value>
		public string AUTONUMERACION_PREFIJO
		{
			get { return _autonumeracion_prefijo; }
			set { _autonumeracion_prefijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ACTUAL</c> column value.</value>
		public decimal AUTONUMERACION_ACTUAL
		{
			get { return _autonumeracion_actual; }
			set { _autonumeracion_actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_LIMITE</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_LIMITE</c> column value.</value>
		public decimal AUTONUMERACION_LIMITE
		{
			get { return _autonumeracion_limite; }
			set { _autonumeracion_limite = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get { return _condicion_pago_id; }
			set { _condicion_pago_id = value; }
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
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_NOMBRE</c> column value.</value>
		public string LISTA_PRECIO_NOMBRE
		{
			get { return _lista_precio_nombre; }
			set { _lista_precio_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ABREVIATURA</c> column value.</value>
		public string LISTA_PRECIO_ABREVIATURA
		{
			get { return _lista_precio_abreviatura; }
			set { _lista_precio_abreviatura = value; }
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
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@DEPOSITO_ABREVIATURA=");
			dynStr.Append(DEPOSITO_ABREVIATURA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@AUTONUMERACION_CODIGO=");
			dynStr.Append(AUTONUMERACION_CODIGO);
			dynStr.Append("@CBA@AUTONUMERACION_PREFIJO=");
			dynStr.Append(AUTONUMERACION_PREFIJO);
			dynStr.Append("@CBA@AUTONUMERACION_ACTUAL=");
			dynStr.Append(AUTONUMERACION_ACTUAL);
			dynStr.Append("@CBA@AUTONUMERACION_LIMITE=");
			dynStr.Append(AUTONUMERACION_LIMITE);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(CONDICION_PAGO_ID);
			dynStr.Append("@CBA@CONDICION_NOMBRE=");
			dynStr.Append(CONDICION_NOMBRE);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			dynStr.Append("@CBA@LISTA_PRECIO_NOMBRE=");
			dynStr.Append(LISTA_PRECIO_NOMBRE);
			dynStr.Append("@CBA@LISTA_PRECIO_ABREVIATURA=");
			dynStr.Append(LISTA_PRECIO_ABREVIATURA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@FUNCIONARIO_VENDEDOR_ID=");
			dynStr.Append(IsFUNCIONARIO_VENDEDOR_IDNull ? (object)"<NULL>" : FUNCIONARIO_VENDEDOR_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			return dynStr.ToString();
		}
	} // End of GENER_FC_CLIENTE_INFO_COMPLETARow_Base class
} // End of namespace
