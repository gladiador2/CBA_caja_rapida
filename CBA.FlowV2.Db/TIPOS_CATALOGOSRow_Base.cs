// <fileinfo name="TIPOS_CATALOGOSRow_Base.cs">
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
	/// The base class for <see cref="TIPOS_CATALOGOSRow"/> that 
	/// represents a record in the <c>TIPOS_CATALOGOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_CATALOGOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_CATALOGOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _estado;
		private decimal _tipo_articulo_conjunto;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CATALOGOSRow_Base"/> class.
		/// </summary>
		public TIPOS_CATALOGOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_CATALOGOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_ARTICULO_CONJUNTO != original.TIPO_ARTICULO_CONJUNTO) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>TIPO_ARTICULO_CONJUNTO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ARTICULO_CONJUNTO</c> column value.</value>
		public decimal TIPO_ARTICULO_CONJUNTO
		{
			get { return _tipo_articulo_conjunto; }
			set { _tipo_articulo_conjunto = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_ARTICULO_CONJUNTO=");
			dynStr.Append(TIPO_ARTICULO_CONJUNTO);
			return dynStr.ToString();
		}
	} // End of TIPOS_CATALOGOSRow_Base class
} // End of namespace
