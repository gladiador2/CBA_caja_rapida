// <fileinfo name="CASOSRow_Base.cs">
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
	/// The base class for <see cref="CASOSRow"/> that 
	/// represents a record in the <c>CASOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CASOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOSRow_Base
	{
		private decimal _id;
		private decimal _flujo_id;
		private decimal _sucursal_id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _estado_id;
		private string _estado_anterior_id;
		private System.DateTime _ultima_modificacion;
		private bool _ultima_modificacionNull = true;
		private decimal _ultimo_usuario_id;
		private bool _ultimo_usuario_idNull = true;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private bool _usuario_creacion_idNull = true;
		private decimal _fecha_formato_numero;
		private string _nro_comprobante;
		private System.DateTime _fecha_formulario;
		private bool _fecha_formularioNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _tipo_especifico;
		private bool _tipo_especificoNull = true;
		private string _estado;
		private decimal _fecha_form_formato_numero;
		private bool _fecha_form_formato_numeroNull = true;
		private string _nro_comprobante_2;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOSRow_Base"/> class.
		/// </summary>
		public CASOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CASOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.ESTADO_ANTERIOR_ID != original.ESTADO_ANTERIOR_ID) return true;
			if (this.IsULTIMA_MODIFICACIONNull != original.IsULTIMA_MODIFICACIONNull) return true;
			if (!this.IsULTIMA_MODIFICACIONNull && !original.IsULTIMA_MODIFICACIONNull)
				if (this.ULTIMA_MODIFICACION != original.ULTIMA_MODIFICACION) return true;
			if (this.IsULTIMO_USUARIO_IDNull != original.IsULTIMO_USUARIO_IDNull) return true;
			if (!this.IsULTIMO_USUARIO_IDNull && !original.IsULTIMO_USUARIO_IDNull)
				if (this.ULTIMO_USUARIO_ID != original.ULTIMO_USUARIO_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_CREACION_IDNull != original.IsUSUARIO_CREACION_IDNull) return true;
			if (!this.IsUSUARIO_CREACION_IDNull && !original.IsUSUARIO_CREACION_IDNull)
				if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_FORMATO_NUMERO != original.FECHA_FORMATO_NUMERO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHA_FORMULARIONull != original.IsFECHA_FORMULARIONull) return true;
			if (!this.IsFECHA_FORMULARIONull && !original.IsFECHA_FORMULARIONull)
				if (this.FECHA_FORMULARIO != original.FECHA_FORMULARIO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsTIPO_ESPECIFICONull != original.IsTIPO_ESPECIFICONull) return true;
			if (!this.IsTIPO_ESPECIFICONull && !original.IsTIPO_ESPECIFICONull)
				if (this.TIPO_ESPECIFICO != original.TIPO_ESPECIFICO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsFECHA_FORM_FORMATO_NUMERONull != original.IsFECHA_FORM_FORMATO_NUMERONull) return true;
			if (!this.IsFECHA_FORM_FORMATO_NUMERONull && !original.IsFECHA_FORM_FORMATO_NUMERONull)
				if (this.FECHA_FORM_FORMATO_NUMERO != original.FECHA_FORM_FORMATO_NUMERO) return true;
			if (this.NRO_COMPROBANTE_2 != original.NRO_COMPROBANTE_2) return true;
			
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
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
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ANTERIOR_ID</c> column value.</value>
		public string ESTADO_ANTERIOR_ID
		{
			get { return _estado_anterior_id; }
			set { _estado_anterior_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMA_MODIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMA_MODIFICACION</c> column value.</value>
		public System.DateTime ULTIMA_MODIFICACION
		{
			get
			{
				if(IsULTIMA_MODIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultima_modificacion;
			}
			set
			{
				_ultima_modificacionNull = false;
				_ultima_modificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMA_MODIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMA_MODIFICACIONNull
		{
			get { return _ultima_modificacionNull; }
			set { _ultima_modificacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMO_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMO_USUARIO_ID</c> column value.</value>
		public decimal ULTIMO_USUARIO_ID
		{
			get
			{
				if(IsULTIMO_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultimo_usuario_id;
			}
			set
			{
				_ultimo_usuario_idNull = false;
				_ultimo_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMO_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMO_USUARIO_IDNull
		{
			get { return _ultimo_usuario_idNull; }
			set { _ultimo_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get
			{
				if(IsUSUARIO_CREACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creacion_id;
			}
			set
			{
				_usuario_creacion_idNull = false;
				_usuario_creacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREACION_IDNull
		{
			get { return _usuario_creacion_idNull; }
			set { _usuario_creacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMATO_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMATO_NUMERO</c> column value.</value>
		public decimal FECHA_FORMATO_NUMERO
		{
			get { return _fecha_formato_numero; }
			set { _fecha_formato_numero = value; }
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
		/// Gets or sets the <c>FECHA_FORMULARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FORMULARIO</c> column value.</value>
		public System.DateTime FECHA_FORMULARIO
		{
			get
			{
				if(IsFECHA_FORMULARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_formulario;
			}
			set
			{
				_fecha_formularioNull = false;
				_fecha_formulario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FORMULARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FORMULARIONull
		{
			get { return _fecha_formularioNull; }
			set { _fecha_formularioNull = value; }
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ESPECIFICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ESPECIFICO</c> column value.</value>
		public decimal TIPO_ESPECIFICO
		{
			get
			{
				if(IsTIPO_ESPECIFICONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_especifico;
			}
			set
			{
				_tipo_especificoNull = false;
				_tipo_especifico = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_ESPECIFICO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_ESPECIFICONull
		{
			get { return _tipo_especificoNull; }
			set { _tipo_especificoNull = value; }
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
		/// Gets or sets the <c>FECHA_FORM_FORMATO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FORM_FORMATO_NUMERO</c> column value.</value>
		public decimal FECHA_FORM_FORMATO_NUMERO
		{
			get
			{
				if(IsFECHA_FORM_FORMATO_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_form_formato_numero;
			}
			set
			{
				_fecha_form_formato_numeroNull = false;
				_fecha_form_formato_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FORM_FORMATO_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FORM_FORMATO_NUMERONull
		{
			get { return _fecha_form_formato_numeroNull; }
			set { _fecha_form_formato_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_2</c> column value.</value>
		public string NRO_COMPROBANTE_2
		{
			get { return _nro_comprobante_2; }
			set { _nro_comprobante_2 = value; }
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
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@ESTADO_ANTERIOR_ID=");
			dynStr.Append(ESTADO_ANTERIOR_ID);
			dynStr.Append("@CBA@ULTIMA_MODIFICACION=");
			dynStr.Append(IsULTIMA_MODIFICACIONNull ? (object)"<NULL>" : ULTIMA_MODIFICACION);
			dynStr.Append("@CBA@ULTIMO_USUARIO_ID=");
			dynStr.Append(IsULTIMO_USUARIO_IDNull ? (object)"<NULL>" : ULTIMO_USUARIO_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(IsUSUARIO_CREACION_IDNull ? (object)"<NULL>" : USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_FORMULARIO=");
			dynStr.Append(IsFECHA_FORMULARIONull ? (object)"<NULL>" : FECHA_FORMULARIO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@TIPO_ESPECIFICO=");
			dynStr.Append(IsTIPO_ESPECIFICONull ? (object)"<NULL>" : TIPO_ESPECIFICO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_FORM_FORMATO_NUMERO=");
			dynStr.Append(IsFECHA_FORM_FORMATO_NUMERONull ? (object)"<NULL>" : FECHA_FORM_FORMATO_NUMERO);
			dynStr.Append("@CBA@NRO_COMPROBANTE_2=");
			dynStr.Append(NRO_COMPROBANTE_2);
			return dynStr.ToString();
		}
	} // End of CASOSRow_Base class
} // End of namespace
