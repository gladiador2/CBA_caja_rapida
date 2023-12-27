// <fileinfo name="CASOS_ETIQUETAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CASOS_ETIQUETAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CASOS_ETIQUETAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CASOS_ETIQUETAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOS_ETIQUETAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_descripcion;
		private decimal _texto_predefinido_id;
		private decimal _tipo_texto_predefinido_id;
		private string _tipo_texto_predefinido_nombre;
		private string _texto;
		private string _tabla_nombre;
		private decimal _registro_id;
		private bool _registro_idNull = true;
		private System.DateTime _fecha_creacion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_ETIQUETAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CASOS_ETIQUETAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CASOS_ETIQUETAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_NOMBRE != original.TIPO_TEXTO_PREDEFINIDO_NOMBRE) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.TABLA_NOMBRE != original.TABLA_NOMBRE) return true;
			if (this.IsREGISTRO_IDNull != original.IsREGISTRO_IDNull) return true;
			if (!this.IsREGISTRO_IDNull && !original.IsREGISTRO_IDNull)
				if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get { return _tipo_texto_predefinido_id; }
			set { _tipo_texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_NOMBRE</c> column value.</value>
		public string TIPO_TEXTO_PREDEFINIDO_NOMBRE
		{
			get { return _tipo_texto_predefinido_nombre; }
			set { _tipo_texto_predefinido_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_NOMBRE</c> column value.</value>
		public string TABLA_NOMBRE
		{
			get { return _tabla_nombre; }
			set { _tabla_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get
			{
				if(IsREGISTRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _registro_id;
			}
			set
			{
				_registro_idNull = false;
				_registro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGISTRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGISTRO_IDNull
		{
			get { return _registro_idNull; }
			set { _registro_idNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_NOMBRE=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_NOMBRE);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@TABLA_NOMBRE=");
			dynStr.Append(TABLA_NOMBRE);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(IsREGISTRO_IDNull ? (object)"<NULL>" : REGISTRO_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CASOS_ETIQUETAS_INFO_COMPLETARow_Base class
} // End of namespace
