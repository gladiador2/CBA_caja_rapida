// <fileinfo name="COPARN_DETALLES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="COPARN_DETALLES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>COPARN_DETALLES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COPARN_DETALLES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COPARN_DETALLES_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _coparn_id;
		private string _numero_contenedor;
		private decimal _tipo_contenedor_id;
		private string _tipo_contenedor_nombre;
		private string _mercaderia;

		/// <summary>
		/// Initializes a new instance of the <see cref="COPARN_DETALLES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public COPARN_DETALLES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COPARN_DETALLES_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.COPARN_ID != original.COPARN_ID) return true;
			if (this.NUMERO_CONTENEDOR != original.NUMERO_CONTENEDOR) return true;
			if (this.TIPO_CONTENEDOR_ID != original.TIPO_CONTENEDOR_ID) return true;
			if (this.TIPO_CONTENEDOR_NOMBRE != original.TIPO_CONTENEDOR_NOMBRE) return true;
			if (this.MERCADERIA != original.MERCADERIA) return true;
			
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
		/// Gets or sets the <c>COPARN_ID</c> column value.
		/// </summary>
		/// <value>The <c>COPARN_ID</c> column value.</value>
		public decimal COPARN_ID
		{
			get { return _coparn_id; }
			set { _coparn_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CONTENEDOR</c> column value.</value>
		public string NUMERO_CONTENEDOR
		{
			get { return _numero_contenedor; }
			set { _numero_contenedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_ID</c> column value.</value>
		public decimal TIPO_CONTENEDOR_ID
		{
			get { return _tipo_contenedor_id; }
			set { _tipo_contenedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_NOMBRE</c> column value.</value>
		public string TIPO_CONTENEDOR_NOMBRE
		{
			get { return _tipo_contenedor_nombre; }
			set { _tipo_contenedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA</c> column value.</value>
		public string MERCADERIA
		{
			get { return _mercaderia; }
			set { _mercaderia = value; }
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
			dynStr.Append("@CBA@COPARN_ID=");
			dynStr.Append(COPARN_ID);
			dynStr.Append("@CBA@NUMERO_CONTENEDOR=");
			dynStr.Append(NUMERO_CONTENEDOR);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_ID=");
			dynStr.Append(TIPO_CONTENEDOR_ID);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_NOMBRE=");
			dynStr.Append(TIPO_CONTENEDOR_NOMBRE);
			dynStr.Append("@CBA@MERCADERIA=");
			dynStr.Append(MERCADERIA);
			return dynStr.ToString();
		}
	} // End of COPARN_DETALLES_INFO_COMPLETARow_Base class
} // End of namespace
