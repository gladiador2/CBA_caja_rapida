// <fileinfo name="STOCK_TRANSF_BALANC_PRECINTOSRow_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSF_BALANC_PRECINTOSRow"/> that 
	/// represents a record in the <c>STOCK_TRANSF_BALANC_PRECINTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_TRANSF_BALANC_PRECINTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSF_BALANC_PRECINTOSRow_Base
	{
		private decimal _id;
		private decimal _transferencia_balanc_id;
		private string _codigo;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSF_BALANC_PRECINTOSRow_Base"/> class.
		/// </summary>
		public STOCK_TRANSF_BALANC_PRECINTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_TRANSF_BALANC_PRECINTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANSFERENCIA_BALANC_ID != original.TRANSFERENCIA_BALANC_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			
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
		/// Gets or sets the <c>TRANSFERENCIA_BALANC_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_BALANC_ID</c> column value.</value>
		public decimal TRANSFERENCIA_BALANC_ID
		{
			get { return _transferencia_balanc_id; }
			set { _transferencia_balanc_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TRANSFERENCIA_BALANC_ID=");
			dynStr.Append(TRANSFERENCIA_BALANC_ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of STOCK_TRANSF_BALANC_PRECINTOSRow_Base class
} // End of namespace
