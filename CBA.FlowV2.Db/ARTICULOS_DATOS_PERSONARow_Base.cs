// <fileinfo name="ARTICULOS_DATOS_PERSONARow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_DATOS_PERSONARow"/> that 
	/// represents a record in the <c>ARTICULOS_DATOS_PERSONA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_DATOS_PERSONARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_DATOS_PERSONARow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private decimal _persona_id;
		private string _descripcion;
		private string _codigo;
		private string _codigo_barras;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_DATOS_PERSONARow_Base"/> class.
		/// </summary>
		public ARTICULOS_DATOS_PERSONARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_DATOS_PERSONARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.CODIGO_BARRAS != original.CODIGO_BARRAS) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BARRAS</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO_BARRAS</c> column value.</value>
		public string CODIGO_BARRAS
		{
			get { return _codigo_barras; }
			set { _codigo_barras = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@CODIGO_BARRAS=");
			dynStr.Append(CODIGO_BARRAS);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_DATOS_PERSONARow_Base class
} // End of namespace
