// <fileinfo name="ENCUESTAS_RESPUESTASRow_Base.cs">
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
	/// The base class for <see cref="ENCUESTAS_RESPUESTASRow"/> that 
	/// represents a record in the <c>ENCUESTAS_RESPUESTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENCUESTAS_RESPUESTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENCUESTAS_RESPUESTASRow_Base
	{
		private decimal _id;
		private decimal _encuestas_pregunta_id;
		private string _texto;
		private decimal _valor_numerico;
		private decimal _orden;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_RESPUESTASRow_Base"/> class.
		/// </summary>
		public ENCUESTAS_RESPUESTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENCUESTAS_RESPUESTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENCUESTAS_PREGUNTA_ID != original.ENCUESTAS_PREGUNTA_ID) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.VALOR_NUMERICO != original.VALOR_NUMERICO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>ENCUESTAS_PREGUNTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENCUESTAS_PREGUNTA_ID</c> column value.</value>
		public decimal ENCUESTAS_PREGUNTA_ID
		{
			get { return _encuestas_pregunta_id; }
			set { _encuestas_pregunta_id = value; }
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
		/// Gets or sets the <c>VALOR_NUMERICO</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_NUMERICO</c> column value.</value>
		public decimal VALOR_NUMERICO
		{
			get { return _valor_numerico; }
			set { _valor_numerico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
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
			dynStr.Append("@CBA@ENCUESTAS_PREGUNTA_ID=");
			dynStr.Append(ENCUESTAS_PREGUNTA_ID);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@VALOR_NUMERICO=");
			dynStr.Append(VALOR_NUMERICO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			return dynStr.ToString();
		}
	} // End of ENCUESTAS_RESPUESTASRow_Base class
} // End of namespace
