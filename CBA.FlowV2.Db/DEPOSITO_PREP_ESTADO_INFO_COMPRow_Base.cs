// <fileinfo name="DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/> that 
	/// represents a record in the <c>DEPOSITO_PREP_ESTADO_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _pedido_cliente_id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _funcionario_preparacion_id;
		private bool _funcionario_preparacion_idNull = true;
		private string _deposito_estado;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _puede_procesar;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _estado;
		private string _articulo_codigo;
		private string _articulo_nombre;
		private decimal _caso_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _cliente;
		private string _funcionario;
		private string _funcionario_preparacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base"/> class.
		/// </summary>
		public DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PEDIDO_CLIENTE_ID != original.PEDIDO_CLIENTE_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsFUNCIONARIO_PREPARACION_IDNull != original.IsFUNCIONARIO_PREPARACION_IDNull) return true;
			if (!this.IsFUNCIONARIO_PREPARACION_IDNull && !original.IsFUNCIONARIO_PREPARACION_IDNull)
				if (this.FUNCIONARIO_PREPARACION_ID != original.FUNCIONARIO_PREPARACION_ID) return true;
			if (this.DEPOSITO_ESTADO != original.DEPOSITO_ESTADO) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.PUEDE_PROCESAR != original.PUEDE_PROCESAR) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_NOMBRE != original.ARTICULO_NOMBRE) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.CLIENTE != original.CLIENTE) return true;
			if (this.FUNCIONARIO != original.FUNCIONARIO) return true;
			if (this.FUNCIONARIO_PREPARACION != original.FUNCIONARIO_PREPARACION) return true;
			
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
		/// Gets or sets the <c>PEDIDO_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PEDIDO_CLIENTE_ID</c> column value.</value>
		public decimal PEDIDO_CLIENTE_ID
		{
			get { return _pedido_cliente_id; }
			set { _pedido_cliente_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_PREPARACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</value>
		public decimal FUNCIONARIO_PREPARACION_ID
		{
			get
			{
				if(IsFUNCIONARIO_PREPARACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_preparacion_id;
			}
			set
			{
				_funcionario_preparacion_idNull = false;
				_funcionario_preparacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_PREPARACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_PREPARACION_IDNull
		{
			get { return _funcionario_preparacion_idNull; }
			set { _funcionario_preparacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ESTADO</c> column value.</value>
		public string DEPOSITO_ESTADO
		{
			get { return _deposito_estado; }
			set { _deposito_estado = value; }
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
		/// Gets or sets the <c>PUEDE_PROCESAR</c> column value.
		/// </summary>
		/// <value>The <c>PUEDE_PROCESAR</c> column value.</value>
		public string PUEDE_PROCESAR
		{
			get { return _puede_procesar; }
			set { _puede_procesar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
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
		/// Gets or sets the <c>ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO</c> column value.</value>
		public string ARTICULO_CODIGO
		{
			get { return _articulo_codigo; }
			set { _articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_NOMBRE</c> column value.</value>
		public string ARTICULO_NOMBRE
		{
			get { return _articulo_nombre; }
			set { _articulo_nombre = value; }
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
		/// Gets or sets the <c>CLIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE</c> column value.</value>
		public string CLIENTE
		{
			get { return _cliente; }
			set { _cliente = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_PREPARACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_PREPARACION</c> column value.</value>
		public string FUNCIONARIO_PREPARACION
		{
			get { return _funcionario_preparacion; }
			set { _funcionario_preparacion = value; }
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
			dynStr.Append("@CBA@PEDIDO_CLIENTE_ID=");
			dynStr.Append(PEDIDO_CLIENTE_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_PREPARACION_ID=");
			dynStr.Append(IsFUNCIONARIO_PREPARACION_IDNull ? (object)"<NULL>" : FUNCIONARIO_PREPARACION_ID);
			dynStr.Append("@CBA@DEPOSITO_ESTADO=");
			dynStr.Append(DEPOSITO_ESTADO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@PUEDE_PROCESAR=");
			dynStr.Append(PUEDE_PROCESAR);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_NOMBRE=");
			dynStr.Append(ARTICULO_NOMBRE);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@CLIENTE=");
			dynStr.Append(CLIENTE);
			dynStr.Append("@CBA@FUNCIONARIO=");
			dynStr.Append(FUNCIONARIO);
			dynStr.Append("@CBA@FUNCIONARIO_PREPARACION=");
			dynStr.Append(FUNCIONARIO_PREPARACION);
			return dynStr.ToString();
		}
	} // End of DEPOSITO_PREP_ESTADO_INFO_COMPRow_Base class
} // End of namespace
