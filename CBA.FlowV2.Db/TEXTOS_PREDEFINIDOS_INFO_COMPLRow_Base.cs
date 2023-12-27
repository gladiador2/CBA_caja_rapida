// <fileinfo name="TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="TEXTOS_PREDEFINIDOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>TEXTOS_PREDEFINIDOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TEXTOS_PREDEFINIDOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _tipo_texto_predefinido_id;
		private string _tipo_texto_predefinido_nombre;
		private string _texto;
		private string _solo_lectura;
		private string _estado;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private string _color_hexadecimal;

		/// <summary>
		/// Initializes a new instance of the <see cref="TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_NOMBRE != original.TIPO_TEXTO_PREDEFINIDO_NOMBRE) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.SOLO_LECTURA != original.SOLO_LECTURA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.COLOR_HEXADECIMAL != original.COLOR_HEXADECIMAL) return true;
			
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
		/// Gets or sets the <c>SOLO_LECTURA</c> column value.
		/// </summary>
		/// <value>The <c>SOLO_LECTURA</c> column value.</value>
		public string SOLO_LECTURA
		{
			get { return _solo_lectura; }
			set { _solo_lectura = value; }
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
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLOR_HEXADECIMAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLOR_HEXADECIMAL</c> column value.</value>
		public string COLOR_HEXADECIMAL
		{
			get { return _color_hexadecimal; }
			set { _color_hexadecimal = value; }
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
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_NOMBRE=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_NOMBRE);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@SOLO_LECTURA=");
			dynStr.Append(SOLO_LECTURA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@COLOR_HEXADECIMAL=");
			dynStr.Append(COLOR_HEXADECIMAL);
			return dynStr.ToString();
		}
	} // End of TEXTOS_PREDEFINIDOS_INFO_COMPLRow_Base class
} // End of namespace
