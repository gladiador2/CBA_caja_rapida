// <fileinfo name="CREDITOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="CREDITOS_DETALLESRow"/> that 
	/// represents a record in the <c>CREDITOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CREDITOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _credito_id;
		private decimal _tipo_texto_predefinido_id;
		private decimal _texto_predefinido_id;
		private decimal _monto;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_DETALLESRow_Base"/> class.
		/// </summary>
		public CREDITOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CREDITOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CREDITO_ID != original.CREDITO_ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO_ID</c> column value.</value>
		public decimal CREDITO_ID
		{
			get { return _credito_id; }
			set { _credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get { return _tipo_texto_predefinido_id; }
			set { _tipo_texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@CREDITO_ID=");
			dynStr.Append(CREDITO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CREDITOS_DETALLESRow_Base class
} // End of namespace
