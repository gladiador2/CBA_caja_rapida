// <fileinfo name="VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="VENDEDOR_CLIENTE_FAM_INFO_COMPRow"/> that 
	/// represents a record in the <c>VENDEDOR_CLIENTE_FAM_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="VENDEDOR_CLIENTE_FAM_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base
	{
		private decimal _funcionario_id;
		private decimal _persona_id;
		private decimal _articulo_familia_id;
		private string _vendedor_codigo;
		private string _vendedor_nombre_completo;
		private string _cliente_nombre_completo;
		private string _articulo_familia_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base"/> class.
		/// </summary>
		public VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base original)
		{
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.VENDEDOR_CODIGO != original.VENDEDOR_CODIGO) return true;
			if (this.VENDEDOR_NOMBRE_COMPLETO != original.VENDEDOR_NOMBRE_COMPLETO) return true;
			if (this.CLIENTE_NOMBRE_COMPLETO != original.CLIENTE_NOMBRE_COMPLETO) return true;
			if (this.ARTICULO_FAMILIA_NOMBRE != original.ARTICULO_FAMILIA_NOMBRE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get { return _articulo_familia_id; }
			set { _articulo_familia_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_CODIGO</c> column value.</value>
		public string VENDEDOR_CODIGO
		{
			get { return _vendedor_codigo; }
			set { _vendedor_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_NOMBRE_COMPLETO</c> column value.</value>
		public string VENDEDOR_NOMBRE_COMPLETO
		{
			get { return _vendedor_nombre_completo; }
			set { _vendedor_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CLIENTE_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE_NOMBRE_COMPLETO</c> column value.</value>
		public string CLIENTE_NOMBRE_COMPLETO
		{
			get { return _cliente_nombre_completo; }
			set { _cliente_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_FAMILIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_NOMBRE</c> column value.</value>
		public string ARTICULO_FAMILIA_NOMBRE
		{
			get { return _articulo_familia_nombre; }
			set { _articulo_familia_nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@VENDEDOR_CODIGO=");
			dynStr.Append(VENDEDOR_CODIGO);
			dynStr.Append("@CBA@VENDEDOR_NOMBRE_COMPLETO=");
			dynStr.Append(VENDEDOR_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@CLIENTE_NOMBRE_COMPLETO=");
			dynStr.Append(CLIENTE_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_NOMBRE=");
			dynStr.Append(ARTICULO_FAMILIA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of VENDEDOR_CLIENTE_FAM_INFO_COMPRow_Base class
} // End of namespace
