// <fileinfo name="CUSTODIA_VALORES_DET_SALIDARow_Base.cs">
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
	/// The base class for <see cref="CUSTODIA_VALORES_DET_SALIDARow"/> that 
	/// represents a record in the <c>CUSTODIA_VALORES_DET_SALIDA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CUSTODIA_VALORES_DET_SALIDARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CUSTODIA_VALORES_DET_SALIDARow_Base
	{
		private decimal _id;
		private decimal _custodia_valor_det_id;
		private decimal _custodia_valor_id;
		private string _estado;
		private System.DateTime _fecha;

		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORES_DET_SALIDARow_Base"/> class.
		/// </summary>
		public CUSTODIA_VALORES_DET_SALIDARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CUSTODIA_VALORES_DET_SALIDARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CUSTODIA_VALOR_DET_ID != original.CUSTODIA_VALOR_DET_ID) return true;
			if (this.CUSTODIA_VALOR_ID != original.CUSTODIA_VALOR_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA != original.FECHA) return true;
			
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
		/// Gets or sets the <c>CUSTODIA_VALOR_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALOR_DET_ID</c> column value.</value>
		public decimal CUSTODIA_VALOR_DET_ID
		{
			get { return _custodia_valor_det_id; }
			set { _custodia_valor_det_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALOR_ID</c> column value.</value>
		public decimal CUSTODIA_VALOR_ID
		{
			get { return _custodia_valor_id; }
			set { _custodia_valor_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
			dynStr.Append("@CBA@CUSTODIA_VALOR_DET_ID=");
			dynStr.Append(CUSTODIA_VALOR_DET_ID);
			dynStr.Append("@CBA@CUSTODIA_VALOR_ID=");
			dynStr.Append(CUSTODIA_VALOR_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			return dynStr.ToString();
		}
	} // End of CUSTODIA_VALORES_DET_SALIDARow_Base class
} // End of namespace
