// <fileinfo name="DEPARTAMENTOSRow_Base.cs">
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
	/// The base class for <see cref="DEPARTAMENTOSRow"/> that 
	/// represents a record in the <c>DEPARTAMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DEPARTAMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPARTAMENTOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private decimal _pais_id;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPARTAMENTOSRow_Base"/> class.
		/// </summary>
		public DEPARTAMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DEPARTAMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
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
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of DEPARTAMENTOSRow_Base class
} // End of namespace
