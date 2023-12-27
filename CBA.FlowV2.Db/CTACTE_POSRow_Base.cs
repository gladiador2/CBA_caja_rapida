// <fileinfo name="CTACTE_POSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_POSRow"/> that 
	/// represents a record in the <c>CTACTE_POS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_POSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_POSRow_Base
	{
		private decimal _id;
		private string _codigo;
		private string _nombre;
		private decimal _sucursal_id;
		private string _estado;
		private string _red;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_POSRow_Base"/> class.
		/// </summary>
		public CTACTE_POSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_POSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.RED != original.RED) return true;
			
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
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RED</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RED</c> column value.</value>
		public string RED
		{
			get { return _red; }
			set { _red = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@RED=");
			dynStr.Append(RED);
			return dynStr.ToString();
		}
	} // End of CTACTE_POSRow_Base class
} // End of namespace
