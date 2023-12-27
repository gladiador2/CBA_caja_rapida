// <fileinfo name="CONOCIMIENTOS_CONTENIDOSRow_Base.cs">
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
	/// The base class for <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> that 
	/// represents a record in the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONOCIMIENTOS_CONTENIDOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONOCIMIENTOS_CONTENIDOSRow_Base
	{
		private decimal _id;
		private string _tipo;
		private string _descripcion;
		private string _codigo;
		private string _marca;
		private string _modelo;
		private string _anho;
		private string _color;
		private string _chasis;
		private string _observacion;
		private string _nuevo;
		private string _tipo_embarque;
		private string _nro_inspeccion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOS_CONTENIDOSRow_Base"/> class.
		/// </summary>
		public CONOCIMIENTOS_CONTENIDOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONOCIMIENTOS_CONTENIDOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.MARCA != original.MARCA) return true;
			if (this.MODELO != original.MODELO) return true;
			if (this.ANHO != original.ANHO) return true;
			if (this.COLOR != original.COLOR) return true;
			if (this.CHASIS != original.CHASIS) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NUEVO != original.NUEVO) return true;
			if (this.TIPO_EMBARQUE != original.TIPO_EMBARQUE) return true;
			if (this.NRO_INSPECCION != original.NRO_INSPECCION) return true;
			
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
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
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
		/// Gets or sets the <c>MARCA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA</c> column value.</value>
		public string MARCA
		{
			get { return _marca; }
			set { _marca = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MODELO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MODELO</c> column value.</value>
		public string MODELO
		{
			get { return _modelo; }
			set { _modelo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public string ANHO
		{
			get { return _anho; }
			set { _anho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLOR</c> column value.</value>
		public string COLOR
		{
			get { return _color; }
			set { _color = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHASIS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHASIS</c> column value.</value>
		public string CHASIS
		{
			get { return _chasis; }
			set { _chasis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUEVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUEVO</c> column value.</value>
		public string NUEVO
		{
			get { return _nuevo; }
			set { _nuevo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMBARQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMBARQUE</c> column value.</value>
		public string TIPO_EMBARQUE
		{
			get { return _tipo_embarque; }
			set { _tipo_embarque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_INSPECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_INSPECCION</c> column value.</value>
		public string NRO_INSPECCION
		{
			get { return _nro_inspeccion; }
			set { _nro_inspeccion = value; }
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
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@MARCA=");
			dynStr.Append(MARCA);
			dynStr.Append("@CBA@MODELO=");
			dynStr.Append(MODELO);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(ANHO);
			dynStr.Append("@CBA@COLOR=");
			dynStr.Append(COLOR);
			dynStr.Append("@CBA@CHASIS=");
			dynStr.Append(CHASIS);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NUEVO=");
			dynStr.Append(NUEVO);
			dynStr.Append("@CBA@TIPO_EMBARQUE=");
			dynStr.Append(TIPO_EMBARQUE);
			dynStr.Append("@CBA@NRO_INSPECCION=");
			dynStr.Append(NRO_INSPECCION);
			return dynStr.ToString();
		}
	} // End of CONOCIMIENTOS_CONTENIDOSRow_Base class
} // End of namespace
