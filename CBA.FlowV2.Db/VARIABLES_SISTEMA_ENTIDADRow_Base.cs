// <fileinfo name="VARIABLES_SISTEMA_ENTIDADRow_Base.cs">
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
	/// The base class for <see cref="VARIABLES_SISTEMA_ENTIDADRow"/> that 
	/// represents a record in the <c>VARIABLES_SISTEMA_ENTIDAD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="VARIABLES_SISTEMA_ENTIDADRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VARIABLES_SISTEMA_ENTIDADRow_Base
	{
		private decimal _id;
		private decimal _variable_sistema_id;
		private decimal _entidad_id;
		private string _valor;

		/// <summary>
		/// Initializes a new instance of the <see cref="VARIABLES_SISTEMA_ENTIDADRow_Base"/> class.
		/// </summary>
		public VARIABLES_SISTEMA_ENTIDADRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(VARIABLES_SISTEMA_ENTIDADRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.VARIABLE_SISTEMA_ID != original.VARIABLE_SISTEMA_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.VALOR != original.VALOR) return true;
			
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
		/// Gets or sets the <c>VARIABLE_SISTEMA_ID</c> column value.
		/// </summary>
		/// <value>The <c>VARIABLE_SISTEMA_ID</c> column value.</value>
		public decimal VARIABLE_SISTEMA_ID
		{
			get { return _variable_sistema_id; }
			set { _variable_sistema_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR</c> column value.
		/// </summary>
		/// <value>The <c>VALOR</c> column value.</value>
		public string VALOR
		{
			get { return _valor; }
			set { _valor = value; }
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
			dynStr.Append("@CBA@VARIABLE_SISTEMA_ID=");
			dynStr.Append(VARIABLE_SISTEMA_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@VALOR=");
			dynStr.Append(VALOR);
			return dynStr.ToString();
		}
	} // End of VARIABLES_SISTEMA_ENTIDADRow_Base class
} // End of namespace
