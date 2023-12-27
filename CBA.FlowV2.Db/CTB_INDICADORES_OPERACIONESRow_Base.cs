// <fileinfo name="CTB_INDICADORES_OPERACIONESRow_Base.cs">
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
	/// The base class for <see cref="CTB_INDICADORES_OPERACIONESRow"/> that 
	/// represents a record in the <c>CTB_INDICADORES_OPERACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_INDICADORES_OPERACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_INDICADORES_OPERACIONESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _simbolo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORES_OPERACIONESRow_Base"/> class.
		/// </summary>
		public CTB_INDICADORES_OPERACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_INDICADORES_OPERACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.SIMBOLO != original.SIMBOLO) return true;
			
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
		/// Gets or sets the <c>SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SIMBOLO</c> column value.</value>
		public string SIMBOLO
		{
			get { return _simbolo; }
			set { _simbolo = value; }
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
			dynStr.Append("@CBA@SIMBOLO=");
			dynStr.Append(SIMBOLO);
			return dynStr.ToString();
		}
	} // End of CTB_INDICADORES_OPERACIONESRow_Base class
} // End of namespace
