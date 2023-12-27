// <fileinfo name="TIPOS_ADJUNTORow_Base.cs">
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
	/// The base class for <see cref="TIPOS_ADJUNTORow"/> that 
	/// represents a record in the <c>TIPOS_ADJUNTO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_ADJUNTORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_ADJUNTORow_Base
	{
		private decimal _id;
		private string _descripcion;
		private string _unico;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ADJUNTORow_Base"/> class.
		/// </summary>
		public TIPOS_ADJUNTORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_ADJUNTORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.UNICO != original.UNICO) return true;
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNICO</c> column value.
		/// </summary>
		/// <value>The <c>UNICO</c> column value.</value>
		public string UNICO
		{
			get { return _unico; }
			set { _unico = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@UNICO=");
			dynStr.Append(UNICO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of TIPOS_ADJUNTORow_Base class
} // End of namespace
