// <fileinfo name="TIPOS_DETALLES_PERSONALIZADOSRow_Base.cs">
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
	/// The base class for <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> that 
	/// represents a record in the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_DETALLES_PERSONALIZADOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _observacion;
		private string _estado;
		private string _privado;
		private string _titulos;
		private string _obligatorios;
		private string _disparan_alarma;
		private string _tipos_dato;
		private string _orden;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_DETALLES_PERSONALIZADOSRow_Base"/> class.
		/// </summary>
		public TIPOS_DETALLES_PERSONALIZADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_DETALLES_PERSONALIZADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.PRIVADO != original.PRIVADO) return true;
			if (this.TITULOS != original.TITULOS) return true;
			if (this.OBLIGATORIOS != original.OBLIGATORIOS) return true;
			if (this.DISPARAN_ALARMA != original.DISPARAN_ALARMA) return true;
			if (this.TIPOS_DATO != original.TIPOS_DATO) return true;
			if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
		/// Gets or sets the <c>PRIVADO</c> column value.
		/// </summary>
		/// <value>The <c>PRIVADO</c> column value.</value>
		public string PRIVADO
		{
			get { return _privado; }
			set { _privado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULOS</c> column value.</value>
		public string TITULOS
		{
			get { return _titulos; }
			set { _titulos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBLIGATORIOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBLIGATORIOS</c> column value.</value>
		public string OBLIGATORIOS
		{
			get { return _obligatorios; }
			set { _obligatorios = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DISPARAN_ALARMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DISPARAN_ALARMA</c> column value.</value>
		public string DISPARAN_ALARMA
		{
			get { return _disparan_alarma; }
			set { _disparan_alarma = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPOS_DATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPOS_DATO</c> column value.</value>
		public string TIPOS_DATO
		{
			get { return _tipos_dato; }
			set { _tipos_dato = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public string ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
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
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PRIVADO=");
			dynStr.Append(PRIVADO);
			dynStr.Append("@CBA@TITULOS=");
			dynStr.Append(TITULOS);
			dynStr.Append("@CBA@OBLIGATORIOS=");
			dynStr.Append(OBLIGATORIOS);
			dynStr.Append("@CBA@DISPARAN_ALARMA=");
			dynStr.Append(DISPARAN_ALARMA);
			dynStr.Append("@CBA@TIPOS_DATO=");
			dynStr.Append(TIPOS_DATO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			return dynStr.ToString();
		}
	} // End of TIPOS_DETALLES_PERSONALIZADOSRow_Base class
} // End of namespace
