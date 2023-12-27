// <fileinfo name="TMP_PROVEEDORESRow_Base.cs">
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
	/// The base class for <see cref="TMP_PROVEEDORESRow"/> that 
	/// represents a record in the <c>TMP_PROVEEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TMP_PROVEEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_PROVEEDORESRow_Base
	{
		private string _codigo;
		private string _razon_social;
		private string _nombre_fantasia;
		private string _nacional;
		private string _ruc;
		private string _direccion;
		private string _telefono1;
		private string _telefono2;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_PROVEEDORESRow_Base"/> class.
		/// </summary>
		public TMP_PROVEEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TMP_PROVEEDORESRow_Base original)
		{
			if (this.CODIGO != original.CODIGO) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.NOMBRE_FANTASIA != original.NOMBRE_FANTASIA) return true;
			if (this.NACIONAL != original.NACIONAL) return true;
			if (this.RUC != original.RUC) return true;
			if (this.DIRECCION != original.DIRECCION) return true;
			if (this.TELEFONO1 != original.TELEFONO1) return true;
			if (this.TELEFONO2 != original.TELEFONO2) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_FANTASIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_FANTASIA</c> column value.</value>
		public string NOMBRE_FANTASIA
		{
			get { return _nombre_fantasia; }
			set { _nombre_fantasia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NACIONAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NACIONAL</c> column value.</value>
		public string NACIONAL
		{
			get { return _nacional; }
			set { _nacional = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUC</c> column value.</value>
		public string RUC
		{
			get { return _ruc; }
			set { _ruc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION</c> column value.</value>
		public string DIRECCION
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO1</c> column value.</value>
		public string TELEFONO1
		{
			get { return _telefono1; }
			set { _telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO2</c> column value.</value>
		public string TELEFONO2
		{
			get { return _telefono2; }
			set { _telefono2 = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@NOMBRE_FANTASIA=");
			dynStr.Append(NOMBRE_FANTASIA);
			dynStr.Append("@CBA@NACIONAL=");
			dynStr.Append(NACIONAL);
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@DIRECCION=");
			dynStr.Append(DIRECCION);
			dynStr.Append("@CBA@TELEFONO1=");
			dynStr.Append(TELEFONO1);
			dynStr.Append("@CBA@TELEFONO2=");
			dynStr.Append(TELEFONO2);
			return dynStr.ToString();
		}
	} // End of TMP_PROVEEDORESRow_Base class
} // End of namespace
