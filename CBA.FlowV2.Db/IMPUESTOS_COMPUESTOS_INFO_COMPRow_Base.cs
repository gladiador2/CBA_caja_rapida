// <fileinfo name="IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="IMPUESTOS_COMPUESTOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>IMPUESTOS_COMPUESTOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPUESTOS_COMPUESTOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _impuesto_padre_id;
		private string _impuesto_padre_nombre;
		private decimal _impuesto_hijo_id;
		private string _impuesto_hijo_nombre;
		private decimal _impuesto_hijo_porcentaje;
		private decimal _porcentaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IMPUESTO_PADRE_ID != original.IMPUESTO_PADRE_ID) return true;
			if (this.IMPUESTO_PADRE_NOMBRE != original.IMPUESTO_PADRE_NOMBRE) return true;
			if (this.IMPUESTO_HIJO_ID != original.IMPUESTO_HIJO_ID) return true;
			if (this.IMPUESTO_HIJO_NOMBRE != original.IMPUESTO_HIJO_NOMBRE) return true;
			if (this.IMPUESTO_HIJO_PORCENTAJE != original.IMPUESTO_HIJO_PORCENTAJE) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			
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
		/// Gets or sets the <c>IMPUESTO_PADRE_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_PADRE_ID</c> column value.</value>
		public decimal IMPUESTO_PADRE_ID
		{
			get { return _impuesto_padre_id; }
			set { _impuesto_padre_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_PADRE_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_PADRE_NOMBRE</c> column value.</value>
		public string IMPUESTO_PADRE_NOMBRE
		{
			get { return _impuesto_padre_nombre; }
			set { _impuesto_padre_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_HIJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_HIJO_ID</c> column value.</value>
		public decimal IMPUESTO_HIJO_ID
		{
			get { return _impuesto_hijo_id; }
			set { _impuesto_hijo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_HIJO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_HIJO_NOMBRE</c> column value.</value>
		public string IMPUESTO_HIJO_NOMBRE
		{
			get { return _impuesto_hijo_nombre; }
			set { _impuesto_hijo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_HIJO_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_HIJO_PORCENTAJE</c> column value.</value>
		public decimal IMPUESTO_HIJO_PORCENTAJE
		{
			get { return _impuesto_hijo_porcentaje; }
			set { _impuesto_hijo_porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
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
			dynStr.Append("@CBA@IMPUESTO_PADRE_ID=");
			dynStr.Append(IMPUESTO_PADRE_ID);
			dynStr.Append("@CBA@IMPUESTO_PADRE_NOMBRE=");
			dynStr.Append(IMPUESTO_PADRE_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_HIJO_ID=");
			dynStr.Append(IMPUESTO_HIJO_ID);
			dynStr.Append("@CBA@IMPUESTO_HIJO_NOMBRE=");
			dynStr.Append(IMPUESTO_HIJO_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_HIJO_PORCENTAJE=");
			dynStr.Append(IMPUESTO_HIJO_PORCENTAJE);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of IMPUESTOS_COMPUESTOS_INFO_COMPRow_Base class
} // End of namespace
