// <fileinfo name="MONEDASRow_Base.cs">
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
	/// The base class for <see cref="MONEDASRow"/> that 
	/// represents a record in the <c>MONEDAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MONEDASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MONEDASRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _observacion;
		private string _mascara;
		private string _simbolo;
		private string _iso_4217;
		private decimal _cantidades_decimales;
		private string _cadena_decimales;
		private decimal _orden;
		private bool _ordenNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="MONEDASRow_Base"/> class.
		/// </summary>
		public MONEDASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MONEDASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MASCARA != original.MASCARA) return true;
			if (this.SIMBOLO != original.SIMBOLO) return true;
			if (this.ISO_4217 != original.ISO_4217) return true;
			if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.CADENA_DECIMALES != original.CADENA_DECIMALES) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
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
		/// Gets or sets the <c>MASCARA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MASCARA</c> column value.</value>
		public string MASCARA
		{
			get { return _mascara; }
			set { _mascara = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>SIMBOLO</c> column value.</value>
		public string SIMBOLO
		{
			get { return _simbolo; }
			set { _simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ISO_4217</c> column value.
		/// </summary>
		/// <value>The <c>ISO_4217</c> column value.</value>
		public string ISO_4217
		{
			get { return _iso_4217; }
			set { _iso_4217 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDADES_DECIMALES</c> column value.</value>
		public decimal CANTIDADES_DECIMALES
		{
			get { return _cantidades_decimales; }
			set { _cantidades_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CADENA_DECIMALES</c> column value.</value>
		public string CADENA_DECIMALES
		{
			get { return _cadena_decimales; }
			set { _cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
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
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MASCARA=");
			dynStr.Append(MASCARA);
			dynStr.Append("@CBA@SIMBOLO=");
			dynStr.Append(SIMBOLO);
			dynStr.Append("@CBA@ISO_4217=");
			dynStr.Append(ISO_4217);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@CADENA_DECIMALES=");
			dynStr.Append(CADENA_DECIMALES);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of MONEDASRow_Base class
} // End of namespace
