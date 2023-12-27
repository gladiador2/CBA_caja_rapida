// <fileinfo name="DESCUENTOSRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTOSRow"/> that 
	/// represents a record in the <c>DESCUENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTOSRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private string _nombre;
		private string _descripcion;
		private string _unica;
		private decimal _porcentaje_sugerido;
		private string _estado;
		private string _consumo;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _orden;
		private string _modificable;
		private string _incluir_a_aguinaldo;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOSRow_Base"/> class.
		/// </summary>
		public DESCUENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.UNICA != original.UNICA) return true;
			if (this.PORCENTAJE_SUGERIDO != original.PORCENTAJE_SUGERIDO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CONSUMO != original.CONSUMO) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.MODIFICABLE != original.MODIFICABLE) return true;
			if (this.INCLUIR_A_AGUINALDO != original.INCLUIR_A_AGUINALDO) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>UNICA</c> column value.
		/// </summary>
		/// <value>The <c>UNICA</c> column value.</value>
		public string UNICA
		{
			get { return _unica; }
			set { _unica = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_SUGERIDO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_SUGERIDO</c> column value.</value>
		public decimal PORCENTAJE_SUGERIDO
		{
			get { return _porcentaje_sugerido; }
			set { _porcentaje_sugerido = value; }
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
		/// Gets or sets the <c>CONSUMO</c> column value.
		/// </summary>
		/// <value>The <c>CONSUMO</c> column value.</value>
		public string CONSUMO
		{
			get { return _consumo; }
			set { _consumo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MODIFICABLE</c> column value.
		/// </summary>
		/// <value>The <c>MODIFICABLE</c> column value.</value>
		public string MODIFICABLE
		{
			get { return _modificable; }
			set { _modificable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUIR_A_AGUINALDO</c> column value.
		/// </summary>
		/// <value>The <c>INCLUIR_A_AGUINALDO</c> column value.</value>
		public string INCLUIR_A_AGUINALDO
		{
			get { return _incluir_a_aguinaldo; }
			set { _incluir_a_aguinaldo = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@UNICA=");
			dynStr.Append(UNICA);
			dynStr.Append("@CBA@PORCENTAJE_SUGERIDO=");
			dynStr.Append(PORCENTAJE_SUGERIDO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CONSUMO=");
			dynStr.Append(CONSUMO);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@MODIFICABLE=");
			dynStr.Append(MODIFICABLE);
			dynStr.Append("@CBA@INCLUIR_A_AGUINALDO=");
			dynStr.Append(INCLUIR_A_AGUINALDO);
			return dynStr.ToString();
		}
	} // End of DESCUENTOSRow_Base class
} // End of namespace
