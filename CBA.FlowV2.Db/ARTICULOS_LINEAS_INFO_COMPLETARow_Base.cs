// <fileinfo name="ARTICULOS_LINEAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_LINEAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ARTICULOS_LINEAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_LINEAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_LINEAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private decimal _articulos_familia;
		private string _articulos_familia_nombre;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_LINEAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ARTICULOS_LINEAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_LINEAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ARTICULOS_FAMILIA != original.ARTICULOS_FAMILIA) return true;
			if (this.ARTICULOS_FAMILIA_NOMBRE != original.ARTICULOS_FAMILIA_NOMBRE) return true;
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
		/// Gets or sets the <c>ARTICULOS_FAMILIA</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_FAMILIA</c> column value.</value>
		public decimal ARTICULOS_FAMILIA
		{
			get { return _articulos_familia; }
			set { _articulos_familia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_FAMILIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_FAMILIA_NOMBRE</c> column value.</value>
		public string ARTICULOS_FAMILIA_NOMBRE
		{
			get { return _articulos_familia_nombre; }
			set { _articulos_familia_nombre = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ARTICULOS_FAMILIA=");
			dynStr.Append(ARTICULOS_FAMILIA);
			dynStr.Append("@CBA@ARTICULOS_FAMILIA_NOMBRE=");
			dynStr.Append(ARTICULOS_FAMILIA_NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_LINEAS_INFO_COMPLETARow_Base class
} // End of namespace
