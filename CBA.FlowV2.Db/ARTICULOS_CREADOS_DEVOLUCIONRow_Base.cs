// <fileinfo name="ARTICULOS_CREADOS_DEVOLUCIONRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_CREADOS_DEVOLUCIONRow"/> that 
	/// represents a record in the <c>ARTICULOS_CREADOS_DEVOLUCION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_CREADOS_DEVOLUCIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_CREADOS_DEVOLUCIONRow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private decimal _tipo_nota_credito_id;
		private decimal _secuencia;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_CREADOS_DEVOLUCIONRow_Base"/> class.
		/// </summary>
		public ARTICULOS_CREADOS_DEVOLUCIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_CREADOS_DEVOLUCIONRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.TIPO_NOTA_CREDITO_ID != original.TIPO_NOTA_CREDITO_ID) return true;
			if (this.SECUENCIA != original.SECUENCIA) return true;
			
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
		/// Gets or sets the <c>TIPO_NOTA_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_NOTA_CREDITO_ID</c> column value.</value>
		public decimal TIPO_NOTA_CREDITO_ID
		{
			get { return _tipo_nota_credito_id; }
			set { _tipo_nota_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>SECUENCIA</c> column value.</value>
		public decimal SECUENCIA
		{
			get { return _secuencia; }
			set { _secuencia = value; }
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
			dynStr.Append("@CBA@TIPO_NOTA_CREDITO_ID=");
			dynStr.Append(TIPO_NOTA_CREDITO_ID);
			dynStr.Append("@CBA@SECUENCIA=");
			dynStr.Append(SECUENCIA);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_CREADOS_DEVOLUCIONRow_Base class
} // End of namespace
