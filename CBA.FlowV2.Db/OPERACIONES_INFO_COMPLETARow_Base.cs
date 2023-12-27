// <fileinfo name="OPERACIONES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="OPERACIONES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>OPERACIONES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OPERACIONES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OPERACIONES_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _transicion_id;
		private bool _transicion_idNull = true;
		private decimal _caso_id;
		private decimal _flujo_id;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _caso_estado;
		private decimal _tipo_operacion_id;
		private string _tipo_operacion_nombre;
		private string _estado_original_id;
		private string _estado_resultante_id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _usuario_nombre_completo;
		private System.DateTime _fecha;
		private System.DateTime _fecha_formulario;
		private bool _fecha_formularioNull = true;
		private string _comentario;
		private string _comentario_tipo;
		private decimal _fecha_formato_numero;

		/// <summary>
		/// Initializes a new instance of the <see cref="OPERACIONES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public OPERACIONES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OPERACIONES_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsTRANSICION_IDNull != original.IsTRANSICION_IDNull) return true;
			if (!this.IsTRANSICION_IDNull && !original.IsTRANSICION_IDNull)
				if (this.TRANSICION_ID != original.TRANSICION_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.TIPO_OPERACION_ID != original.TIPO_OPERACION_ID) return true;
			if (this.TIPO_OPERACION_NOMBRE != original.TIPO_OPERACION_NOMBRE) return true;
			if (this.ESTADO_ORIGINAL_ID != original.ESTADO_ORIGINAL_ID) return true;
			if (this.ESTADO_RESULTANTE_ID != original.ESTADO_RESULTANTE_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE_COMPLETO != original.USUARIO_NOMBRE_COMPLETO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsFECHA_FORMULARIONull != original.IsFECHA_FORMULARIONull) return true;
			if (!this.IsFECHA_FORMULARIONull && !original.IsFECHA_FORMULARIONull)
				if (this.FECHA_FORMULARIO != original.FECHA_FORMULARIO) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			if (this.COMENTARIO_TIPO != original.COMENTARIO_TIPO) return true;
			if (this.FECHA_FORMATO_NUMERO != original.FECHA_FORMATO_NUMERO) return true;
			
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
		/// Gets or sets the <c>TRANSICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_ID</c> column value.</value>
		public decimal TRANSICION_ID
		{
			get
			{
				if(IsTRANSICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_id;
			}
			set
			{
				_transicion_idNull = false;
				_transicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_IDNull
		{
			get { return _transicion_idNull; }
			set { _transicion_idNull = value; }
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
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_OPERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_OPERACION_ID</c> column value.</value>
		public decimal TIPO_OPERACION_ID
		{
			get { return _tipo_operacion_id; }
			set { _tipo_operacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_OPERACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_OPERACION_NOMBRE</c> column value.</value>
		public string TIPO_OPERACION_NOMBRE
		{
			get { return _tipo_operacion_nombre; }
			set { _tipo_operacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGINAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGINAL_ID</c> column value.</value>
		public string ESTADO_ORIGINAL_ID
		{
			get { return _estado_original_id; }
			set { _estado_original_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_RESULTANTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_RESULTANTE_ID</c> column value.</value>
		public string ESTADO_RESULTANTE_ID
		{
			get { return _estado_resultante_id; }
			set { _estado_resultante_id = value; }
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
		/// Gets or sets the <c>USUARIO_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE_COMPLETO</c> column value.</value>
		public string USUARIO_NOMBRE_COMPLETO
		{
			get { return _usuario_nombre_completo; }
			set { _usuario_nombre_completo = value; }
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
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO_TIPO</c> column value.</value>
		public string COMENTARIO_TIPO
		{
			get { return _comentario_tipo; }
			set { _comentario_tipo = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TRANSICION_ID=");
			dynStr.Append(IsTRANSICION_IDNull ? (object)"<NULL>" : TRANSICION_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@TIPO_OPERACION_ID=");
			dynStr.Append(TIPO_OPERACION_ID);
			dynStr.Append("@CBA@TIPO_OPERACION_NOMBRE=");
			dynStr.Append(TIPO_OPERACION_NOMBRE);
			dynStr.Append("@CBA@ESTADO_ORIGINAL_ID=");
			dynStr.Append(ESTADO_ORIGINAL_ID);
			dynStr.Append("@CBA@ESTADO_RESULTANTE_ID=");
			dynStr.Append(ESTADO_RESULTANTE_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE_COMPLETO=");
			dynStr.Append(USUARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FECHA_FORMULARIO=");
			dynStr.Append(IsFECHA_FORMULARIONull ? (object)"<NULL>" : FECHA_FORMULARIO);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			dynStr.Append("@CBA@COMENTARIO_TIPO=");
			dynStr.Append(COMENTARIO_TIPO);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			return dynStr.ToString();
		}
	} // End of OPERACIONES_INFO_COMPLETARow_Base class
} // End of namespace
