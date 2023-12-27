// <fileinfo name="TIPOS_ARTICULO_FINANCIERORow_Base.cs">
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
	/// The base class for <see cref="TIPOS_ARTICULO_FINANCIERORow"/> that 
	/// represents a record in the <c>TIPOS_ARTICULO_FINANCIERO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_ARTICULO_FINANCIERORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_ARTICULO_FINANCIERORow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _cantidad_aprobaciones;
		private string _estado;
		private string _deducir_porcentajes;
		private string _interes_compuesto;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ARTICULO_FINANCIERORow_Base"/> class.
		/// </summary>
		public TIPOS_ARTICULO_FINANCIERORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_ARTICULO_FINANCIERORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CANTIDAD_APROBACIONES != original.CANTIDAD_APROBACIONES) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.DEDUCIR_PORCENTAJES != original.DEDUCIR_PORCENTAJES) return true;
			if (this.INTERES_COMPUESTO != original.INTERES_COMPUESTO) return true;
			
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
		/// Gets or sets the <c>CANTIDAD_APROBACIONES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_APROBACIONES</c> column value.</value>
		public decimal CANTIDAD_APROBACIONES
		{
			get { return _cantidad_aprobaciones; }
			set { _cantidad_aprobaciones = value; }
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
		/// Gets or sets the <c>DEDUCIR_PORCENTAJES</c> column value.
		/// </summary>
		/// <value>The <c>DEDUCIR_PORCENTAJES</c> column value.</value>
		public string DEDUCIR_PORCENTAJES
		{
			get { return _deducir_porcentajes; }
			set { _deducir_porcentajes = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_COMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_COMPUESTO</c> column value.</value>
		public string INTERES_COMPUESTO
		{
			get { return _interes_compuesto; }
			set { _interes_compuesto = value; }
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
			dynStr.Append("@CBA@CANTIDAD_APROBACIONES=");
			dynStr.Append(CANTIDAD_APROBACIONES);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@DEDUCIR_PORCENTAJES=");
			dynStr.Append(DEDUCIR_PORCENTAJES);
			dynStr.Append("@CBA@INTERES_COMPUESTO=");
			dynStr.Append(INTERES_COMPUESTO);
			return dynStr.ToString();
		}
	} // End of TIPOS_ARTICULO_FINANCIERORow_Base class
} // End of namespace
