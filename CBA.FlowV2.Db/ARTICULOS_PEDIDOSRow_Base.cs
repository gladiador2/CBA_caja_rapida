// <fileinfo name="ARTICULOS_PEDIDOSRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_PEDIDOSRow"/> that 
	/// represents a record in the <c>ARTICULOS_PEDIDOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_PEDIDOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_PEDIDOSRow_Base
	{
		private decimal _pedido_cliente_id;
		private decimal _preventa_orden;
		private bool _preventa_ordenNull = true;
		private System.DateTime _preventa_fecha_entrega;
		private bool _preventa_fecha_entregaNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre;
		private decimal _articulo_id;
		private string _descripcion_interna;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _familia_descripcion;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _grupo_descripcion;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private decimal _cantidad_pedido;
		private string _subgrupo_descripcion;
		private decimal _existencia;
		private bool _existenciaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PEDIDOSRow_Base"/> class.
		/// </summary>
		public ARTICULOS_PEDIDOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_PEDIDOSRow_Base original)
		{
			if (this.PEDIDO_CLIENTE_ID != original.PEDIDO_CLIENTE_ID) return true;
			if (this.IsPREVENTA_ORDENNull != original.IsPREVENTA_ORDENNull) return true;
			if (!this.IsPREVENTA_ORDENNull && !original.IsPREVENTA_ORDENNull)
				if (this.PREVENTA_ORDEN != original.PREVENTA_ORDEN) return true;
			if (this.IsPREVENTA_FECHA_ENTREGANull != original.IsPREVENTA_FECHA_ENTREGANull) return true;
			if (!this.IsPREVENTA_FECHA_ENTREGANull && !original.IsPREVENTA_FECHA_ENTREGANull)
				if (this.PREVENTA_FECHA_ENTREGA != original.PREVENTA_FECHA_ENTREGA) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.CANTIDAD_PEDIDO != original.CANTIDAD_PEDIDO) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.IsEXISTENCIANull != original.IsEXISTENCIANull) return true;
			if (!this.IsEXISTENCIANull && !original.IsEXISTENCIANull)
				if (this.EXISTENCIA != original.EXISTENCIA) return true;
			
			return false;
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
		/// Gets or sets the <c>PREVENTA_ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREVENTA_ORDEN</c> column value.</value>
		public decimal PREVENTA_ORDEN
		{
			get
			{
				if(IsPREVENTA_ORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _preventa_orden;
			}
			set
			{
				_preventa_ordenNull = false;
				_preventa_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PREVENTA_ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPREVENTA_ORDENNull
		{
			get { return _preventa_ordenNull; }
			set { _preventa_ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREVENTA_FECHA_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREVENTA_FECHA_ENTREGA</c> column value.</value>
		public System.DateTime PREVENTA_FECHA_ENTREGA
		{
			get
			{
				if(IsPREVENTA_FECHA_ENTREGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _preventa_fecha_entrega;
			}
			set
			{
				_preventa_fecha_entregaNull = false;
				_preventa_fecha_entrega = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PREVENTA_FECHA_ENTREGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPREVENTA_FECHA_ENTREGANull
		{
			get { return _preventa_fecha_entregaNull; }
			set { _preventa_fecha_entregaNull = value; }
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public string FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public string GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_PEDIDO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_PEDIDO</c> column value.</value>
		public decimal CANTIDAD_PEDIDO
		{
			get { return _cantidad_pedido; }
			set { _cantidad_pedido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PEDIDO_CLIENTE_ID=");
			dynStr.Append(PEDIDO_CLIENTE_ID);
			dynStr.Append("@CBA@PREVENTA_ORDEN=");
			dynStr.Append(IsPREVENTA_ORDENNull ? (object)"<NULL>" : PREVENTA_ORDEN);
			dynStr.Append("@CBA@PREVENTA_FECHA_ENTREGA=");
			dynStr.Append(IsPREVENTA_FECHA_ENTREGANull ? (object)"<NULL>" : PREVENTA_FECHA_ENTREGA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@CANTIDAD_PEDIDO=");
			dynStr.Append(CANTIDAD_PEDIDO);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(IsEXISTENCIANull ? (object)"<NULL>" : EXISTENCIA);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_PEDIDOSRow_Base class
} // End of namespace
