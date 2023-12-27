// <fileinfo name="CTACTE_CONCEPTOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CONCEPTOSRow"/> that 
	/// represents a record in the <c>CTACTE_CONCEPTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CONCEPTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CONCEPTOSRow_Base
	{
		private decimal _id;
		private string _descripcion;
		private decimal _positivo_o_negativo;
		private string _afecta_caja;
		private string _grupo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONCEPTOSRow_Base"/> class.
		/// </summary>
		public CTACTE_CONCEPTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CONCEPTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.POSITIVO_O_NEGATIVO != original.POSITIVO_O_NEGATIVO) return true;
			if (this.AFECTA_CAJA != original.AFECTA_CAJA) return true;
			if (this.GRUPO != original.GRUPO) return true;
			
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POSITIVO_O_NEGATIVO</c> column value.
		/// </summary>
		/// <value>The <c>POSITIVO_O_NEGATIVO</c> column value.</value>
		public decimal POSITIVO_O_NEGATIVO
		{
			get { return _positivo_o_negativo; }
			set { _positivo_o_negativo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CAJA</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CAJA</c> column value.</value>
		public string AFECTA_CAJA
		{
			get { return _afecta_caja; }
			set { _afecta_caja = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO</c> column value.</value>
		public string GRUPO
		{
			get { return _grupo; }
			set { _grupo = value; }
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
			dynStr.Append("@CBA@POSITIVO_O_NEGATIVO=");
			dynStr.Append(POSITIVO_O_NEGATIVO);
			dynStr.Append("@CBA@AFECTA_CAJA=");
			dynStr.Append(AFECTA_CAJA);
			dynStr.Append("@CBA@GRUPO=");
			dynStr.Append(GRUPO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CONCEPTOSRow_Base class
} // End of namespace
