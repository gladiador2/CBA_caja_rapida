// <fileinfo name="MONEDAS_DENOM_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="MONEDAS_DENOM_INFO_COMPLRow"/> that 
	/// represents a record in the <c>MONEDAS_DENOM_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MONEDAS_DENOM_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MONEDAS_DENOM_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _denominacion;
		private string _denominacion_descripcion;
		private decimal _tipo;
		private bool _tipoNull = true;
		private string _estado;
		private decimal _cantidades_decimales;
		private string _cadena_decimales;

		/// <summary>
		/// Initializes a new instance of the <see cref="MONEDAS_DENOM_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public MONEDAS_DENOM_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MONEDAS_DENOM_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.DENOMINACION != original.DENOMINACION) return true;
			if (this.DENOMINACION_DESCRIPCION != original.DENOMINACION_DESCRIPCION) return true;
			if (this.IsTIPONull != original.IsTIPONull) return true;
			if (!this.IsTIPONull && !original.IsTIPONull)
				if (this.TIPO != original.TIPO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.CADENA_DECIMALES != original.CADENA_DECIMALES) return true;
			
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_NOMBRE</c> column value.</value>
		public string CTACTE_VALOR_NOMBRE
		{
			get { return _ctacte_valor_nombre; }
			set { _ctacte_valor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DENOMINACION</c> column value.
		/// </summary>
		/// <value>The <c>DENOMINACION</c> column value.</value>
		public decimal DENOMINACION
		{
			get { return _denominacion; }
			set { _denominacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DENOMINACION_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DENOMINACION_DESCRIPCION</c> column value.</value>
		public string DENOMINACION_DESCRIPCION
		{
			get { return _denominacion_descripcion; }
			set { _denominacion_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get
			{
				if(IsTIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo;
			}
			set
			{
				_tipoNull = false;
				_tipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPONull
		{
			get { return _tipoNull; }
			set { _tipoNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@DENOMINACION=");
			dynStr.Append(DENOMINACION);
			dynStr.Append("@CBA@DENOMINACION_DESCRIPCION=");
			dynStr.Append(DENOMINACION_DESCRIPCION);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(IsTIPONull ? (object)"<NULL>" : TIPO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@CADENA_DECIMALES=");
			dynStr.Append(CADENA_DECIMALES);
			return dynStr.ToString();
		}
	} // End of MONEDAS_DENOM_INFO_COMPLRow_Base class
} // End of namespace
