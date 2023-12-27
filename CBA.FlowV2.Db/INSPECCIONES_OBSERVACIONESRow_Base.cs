// <fileinfo name="INSPECCIONES_OBSERVACIONESRow_Base.cs">
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
	/// The base class for <see cref="INSPECCIONES_OBSERVACIONESRow"/> that 
	/// represents a record in the <c>INSPECCIONES_OBSERVACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INSPECCIONES_OBSERVACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INSPECCIONES_OBSERVACIONESRow_Base
	{
		private string _descripcion;
		private decimal _id;
		private string _tipo;
		private string _estado;
		private string _parte;

		/// <summary>
		/// Initializes a new instance of the <see cref="INSPECCIONES_OBSERVACIONESRow_Base"/> class.
		/// </summary>
		public INSPECCIONES_OBSERVACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INSPECCIONES_OBSERVACIONESRow_Base original)
		{
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ID != original.ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.PARTE != original.PARTE) return true;
			
			return false;
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
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
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
		/// Gets or sets the <c>PARTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PARTE</c> column value.</value>
		public string PARTE
		{
			get { return _parte; }
			set { _parte = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PARTE=");
			dynStr.Append(PARTE);
			return dynStr.ToString();
		}
	} // End of INSPECCIONES_OBSERVACIONESRow_Base class
} // End of namespace
