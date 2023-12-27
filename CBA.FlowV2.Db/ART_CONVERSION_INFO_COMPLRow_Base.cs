// <fileinfo name="ART_CONVERSION_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ART_CONVERSION_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ART_CONVERSION_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ART_CONVERSION_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_CONVERSION_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private decimal _articulo_entidad_id;
		private string _articulo_descripcion;
		private string _unidad_principal_id;
		private string _unidad_principal_nombre;
		private string _unidad_destino_id;
		private string _unidad_destino_nombre;
		private decimal _factor_conversion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_CONVERSION_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ART_CONVERSION_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ART_CONVERSION_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_ENTIDAD_ID != original.ARTICULO_ENTIDAD_ID) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.UNIDAD_PRINCIPAL_ID != original.UNIDAD_PRINCIPAL_ID) return true;
			if (this.UNIDAD_PRINCIPAL_NOMBRE != original.UNIDAD_PRINCIPAL_NOMBRE) return true;
			if (this.UNIDAD_DESTINO_ID != original.UNIDAD_DESTINO_ID) return true;
			if (this.UNIDAD_DESTINO_NOMBRE != original.UNIDAD_DESTINO_NOMBRE) return true;
			if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ENTIDAD_ID</c> column value.</value>
		public decimal ARTICULO_ENTIDAD_ID
		{
			get { return _articulo_entidad_id; }
			set { _articulo_entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_PRINCIPAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_PRINCIPAL_ID</c> column value.</value>
		public string UNIDAD_PRINCIPAL_ID
		{
			get { return _unidad_principal_id; }
			set { _unidad_principal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_PRINCIPAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_PRINCIPAL_NOMBRE</c> column value.</value>
		public string UNIDAD_PRINCIPAL_NOMBRE
		{
			get { return _unidad_principal_nombre; }
			set { _unidad_principal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_ID</c> column value.</value>
		public string UNIDAD_DESTINO_ID
		{
			get { return _unidad_destino_id; }
			set { _unidad_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_NOMBRE</c> column value.</value>
		public string UNIDAD_DESTINO_NOMBRE
		{
			get { return _unidad_destino_nombre; }
			set { _unidad_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_CONVERSION</c> column value.
		/// </summary>
		/// <value>The <c>FACTOR_CONVERSION</c> column value.</value>
		public decimal FACTOR_CONVERSION
		{
			get { return _factor_conversion; }
			set { _factor_conversion = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_ENTIDAD_ID=");
			dynStr.Append(ARTICULO_ENTIDAD_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@UNIDAD_PRINCIPAL_ID=");
			dynStr.Append(UNIDAD_PRINCIPAL_ID);
			dynStr.Append("@CBA@UNIDAD_PRINCIPAL_NOMBRE=");
			dynStr.Append(UNIDAD_PRINCIPAL_NOMBRE);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@UNIDAD_DESTINO_NOMBRE=");
			dynStr.Append(UNIDAD_DESTINO_NOMBRE);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(FACTOR_CONVERSION);
			return dynStr.ToString();
		}
	} // End of ART_CONVERSION_INFO_COMPLRow_Base class
} // End of namespace
