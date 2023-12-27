// <fileinfo name="TIPOS_CONTENEDORRow_Base.cs">
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
	/// The base class for <see cref="TIPOS_CONTENEDORRow"/> that 
	/// represents a record in the <c>TIPOS_CONTENEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_CONTENEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_CONTENEDORRow_Base
	{
		private decimal _id;
		private string _clasificacion;
		private string _estado;
		private decimal _tamano;
		private decimal _tara;
		private decimal _capacidad;
		private decimal _peso_maximo;
		private string _descripcion;
		private string _codigo_edi;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CONTENEDORRow_Base"/> class.
		/// </summary>
		public TIPOS_CONTENEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_CONTENEDORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CLASIFICACION != original.CLASIFICACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TAMANO != original.TAMANO) return true;
			if (this.TARA != original.TARA) return true;
			if (this.CAPACIDAD != original.CAPACIDAD) return true;
			if (this.PESO_MAXIMO != original.PESO_MAXIMO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CODIGO_EDI != original.CODIGO_EDI) return true;
			
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
		/// Gets or sets the <c>CLASIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>CLASIFICACION</c> column value.</value>
		public string CLASIFICACION
		{
			get { return _clasificacion; }
			set { _clasificacion = value; }
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
		/// Gets or sets the <c>TAMANO</c> column value.
		/// </summary>
		/// <value>The <c>TAMANO</c> column value.</value>
		public decimal TAMANO
		{
			get { return _tamano; }
			set { _tamano = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA</c> column value.
		/// </summary>
		/// <value>The <c>TARA</c> column value.</value>
		public decimal TARA
		{
			get { return _tara; }
			set { _tara = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPACIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CAPACIDAD</c> column value.</value>
		public decimal CAPACIDAD
		{
			get { return _capacidad; }
			set { _capacidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_MAXIMO</c> column value.
		/// </summary>
		/// <value>The <c>PESO_MAXIMO</c> column value.</value>
		public decimal PESO_MAXIMO
		{
			get { return _peso_maximo; }
			set { _peso_maximo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EDI</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EDI</c> column value.</value>
		public string CODIGO_EDI
		{
			get { return _codigo_edi; }
			set { _codigo_edi = value; }
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
			dynStr.Append("@CBA@CLASIFICACION=");
			dynStr.Append(CLASIFICACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TAMANO=");
			dynStr.Append(TAMANO);
			dynStr.Append("@CBA@TARA=");
			dynStr.Append(TARA);
			dynStr.Append("@CBA@CAPACIDAD=");
			dynStr.Append(CAPACIDAD);
			dynStr.Append("@CBA@PESO_MAXIMO=");
			dynStr.Append(PESO_MAXIMO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CODIGO_EDI=");
			dynStr.Append(CODIGO_EDI);
			return dynStr.ToString();
		}
	} // End of TIPOS_CONTENEDORRow_Base class
} // End of namespace
