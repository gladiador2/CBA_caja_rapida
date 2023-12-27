// <fileinfo name="EMPRESA_CARGOS_FUNCIONARIOSRow_Base.cs">
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
	/// The base class for <see cref="EMPRESA_CARGOS_FUNCIONARIOSRow"/> that 
	/// represents a record in the <c>EMPRESA_CARGOS_FUNCIONARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EMPRESA_CARGOS_FUNCIONARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EMPRESA_CARGOS_FUNCIONARIOSRow_Base
	{
		private decimal _funcionario_id;
		private decimal _empresa_cargo_id;
		private decimal _porcentaje_cargo;

		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_CARGOS_FUNCIONARIOSRow_Base"/> class.
		/// </summary>
		public EMPRESA_CARGOS_FUNCIONARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EMPRESA_CARGOS_FUNCIONARIOSRow_Base original)
		{
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.EMPRESA_CARGO_ID != original.EMPRESA_CARGO_ID) return true;
			if (this.PORCENTAJE_CARGO != original.PORCENTAJE_CARGO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_CARGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_CARGO_ID</c> column value.</value>
		public decimal EMPRESA_CARGO_ID
		{
			get { return _empresa_cargo_id; }
			set { _empresa_cargo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_CARGO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_CARGO</c> column value.</value>
		public decimal PORCENTAJE_CARGO
		{
			get { return _porcentaje_cargo; }
			set { _porcentaje_cargo = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@EMPRESA_CARGO_ID=");
			dynStr.Append(EMPRESA_CARGO_ID);
			dynStr.Append("@CBA@PORCENTAJE_CARGO=");
			dynStr.Append(PORCENTAJE_CARGO);
			return dynStr.ToString();
		}
	} // End of EMPRESA_CARGOS_FUNCIONARIOSRow_Base class
} // End of namespace
