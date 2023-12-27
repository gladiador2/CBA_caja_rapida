// <fileinfo name="FUNCIONARIOS_HIJOSRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_HIJOSRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_HIJOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_HIJOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_HIJOSRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private string _nombre;
		private System.DateTime _fecha_nacimiento;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_HIJOSRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_HIJOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_HIJOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.FECHA_NACIMIENTO != original.FECHA_NACIMIENTO) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
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
		/// Gets or sets the <c>FECHA_NACIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_NACIMIENTO</c> column value.</value>
		public System.DateTime FECHA_NACIMIENTO
		{
			get { return _fecha_nacimiento; }
			set { _fecha_nacimiento = value; }
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
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@FECHA_NACIMIENTO=");
			dynStr.Append(FECHA_NACIMIENTO);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_HIJOSRow_Base class
} // End of namespace
