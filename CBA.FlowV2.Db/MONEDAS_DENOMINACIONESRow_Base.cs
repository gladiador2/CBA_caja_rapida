// <fileinfo name="MONEDAS_DENOMINACIONESRow_Base.cs">
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
	/// The base class for <see cref="MONEDAS_DENOMINACIONESRow"/> that 
	/// represents a record in the <c>MONEDAS_DENOMINACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MONEDAS_DENOMINACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MONEDAS_DENOMINACIONESRow_Base
	{
		private decimal _id;
		private decimal _moneda_id;
		private decimal _ctacte_valor_id;
		private decimal _denominacion;
		private decimal _tipo;
		private bool _tipoNull = true;
		private string _estado;
		private string _denominacion_descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="MONEDAS_DENOMINACIONESRow_Base"/> class.
		/// </summary>
		public MONEDAS_DENOMINACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MONEDAS_DENOMINACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.DENOMINACION != original.DENOMINACION) return true;
			if (this.IsTIPONull != original.IsTIPONull) return true;
			if (!this.IsTIPONull && !original.IsTIPONull)
				if (this.TIPO != original.TIPO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.DENOMINACION_DESCRIPCION != original.DENOMINACION_DESCRIPCION) return true;
			
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
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
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
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@DENOMINACION=");
			dynStr.Append(DENOMINACION);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(IsTIPONull ? (object)"<NULL>" : TIPO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@DENOMINACION_DESCRIPCION=");
			dynStr.Append(DENOMINACION_DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of MONEDAS_DENOMINACIONESRow_Base class
} // End of namespace
