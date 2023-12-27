// <fileinfo name="CTACTE_CONDICIONES_DESEMBOLSORow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> that 
	/// represents a record in the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CONDICIONES_DESEMBOLSORow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private decimal _cantidad_cuotas;
		private decimal _fecha_desembolso_1;
		private bool _fecha_desembolso_1Null = true;
		private decimal _fecha_desembolso_2;
		private bool _fecha_desembolso_2Null = true;
		private decimal _fecha_desembolso_3;
		private bool _fecha_desembolso_3Null = true;
		private decimal _fecha_desembolso_4;
		private bool _fecha_desembolso_4Null = true;
		private decimal _fecha_desembolso_5;
		private bool _fecha_desembolso_5Null = true;
		private decimal _fecha_desembolso_6;
		private bool _fecha_desembolso_6Null = true;
		private decimal _fecha_desembolso_7;
		private bool _fecha_desembolso_7Null = true;
		private decimal _fecha_desembolso_8;
		private bool _fecha_desembolso_8Null = true;
		private decimal _fecha_desembolso_9;
		private bool _fecha_desembolso_9Null = true;
		private decimal _fecha_desembolso_10;
		private bool _fecha_desembolso_10Null = true;
		private decimal _fecha_desembolso_11;
		private bool _fecha_desembolso_11Null = true;
		private decimal _fecha_desembolso_12;
		private bool _fecha_desembolso_12Null = true;
		private string _estado;
		private string _tipo_calculo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONDICIONES_DESEMBOLSORow_Base"/> class.
		/// </summary>
		public CTACTE_CONDICIONES_DESEMBOLSORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CONDICIONES_DESEMBOLSORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CANTIDAD_CUOTAS != original.CANTIDAD_CUOTAS) return true;
			if (this.IsFECHA_DESEMBOLSO_1Null != original.IsFECHA_DESEMBOLSO_1Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_1Null && !original.IsFECHA_DESEMBOLSO_1Null)
				if (this.FECHA_DESEMBOLSO_1 != original.FECHA_DESEMBOLSO_1) return true;
			if (this.IsFECHA_DESEMBOLSO_2Null != original.IsFECHA_DESEMBOLSO_2Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_2Null && !original.IsFECHA_DESEMBOLSO_2Null)
				if (this.FECHA_DESEMBOLSO_2 != original.FECHA_DESEMBOLSO_2) return true;
			if (this.IsFECHA_DESEMBOLSO_3Null != original.IsFECHA_DESEMBOLSO_3Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_3Null && !original.IsFECHA_DESEMBOLSO_3Null)
				if (this.FECHA_DESEMBOLSO_3 != original.FECHA_DESEMBOLSO_3) return true;
			if (this.IsFECHA_DESEMBOLSO_4Null != original.IsFECHA_DESEMBOLSO_4Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_4Null && !original.IsFECHA_DESEMBOLSO_4Null)
				if (this.FECHA_DESEMBOLSO_4 != original.FECHA_DESEMBOLSO_4) return true;
			if (this.IsFECHA_DESEMBOLSO_5Null != original.IsFECHA_DESEMBOLSO_5Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_5Null && !original.IsFECHA_DESEMBOLSO_5Null)
				if (this.FECHA_DESEMBOLSO_5 != original.FECHA_DESEMBOLSO_5) return true;
			if (this.IsFECHA_DESEMBOLSO_6Null != original.IsFECHA_DESEMBOLSO_6Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_6Null && !original.IsFECHA_DESEMBOLSO_6Null)
				if (this.FECHA_DESEMBOLSO_6 != original.FECHA_DESEMBOLSO_6) return true;
			if (this.IsFECHA_DESEMBOLSO_7Null != original.IsFECHA_DESEMBOLSO_7Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_7Null && !original.IsFECHA_DESEMBOLSO_7Null)
				if (this.FECHA_DESEMBOLSO_7 != original.FECHA_DESEMBOLSO_7) return true;
			if (this.IsFECHA_DESEMBOLSO_8Null != original.IsFECHA_DESEMBOLSO_8Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_8Null && !original.IsFECHA_DESEMBOLSO_8Null)
				if (this.FECHA_DESEMBOLSO_8 != original.FECHA_DESEMBOLSO_8) return true;
			if (this.IsFECHA_DESEMBOLSO_9Null != original.IsFECHA_DESEMBOLSO_9Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_9Null && !original.IsFECHA_DESEMBOLSO_9Null)
				if (this.FECHA_DESEMBOLSO_9 != original.FECHA_DESEMBOLSO_9) return true;
			if (this.IsFECHA_DESEMBOLSO_10Null != original.IsFECHA_DESEMBOLSO_10Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_10Null && !original.IsFECHA_DESEMBOLSO_10Null)
				if (this.FECHA_DESEMBOLSO_10 != original.FECHA_DESEMBOLSO_10) return true;
			if (this.IsFECHA_DESEMBOLSO_11Null != original.IsFECHA_DESEMBOLSO_11Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_11Null && !original.IsFECHA_DESEMBOLSO_11Null)
				if (this.FECHA_DESEMBOLSO_11 != original.FECHA_DESEMBOLSO_11) return true;
			if (this.IsFECHA_DESEMBOLSO_12Null != original.IsFECHA_DESEMBOLSO_12Null) return true;
			if (!this.IsFECHA_DESEMBOLSO_12Null && !original.IsFECHA_DESEMBOLSO_12Null)
				if (this.FECHA_DESEMBOLSO_12 != original.FECHA_DESEMBOLSO_12) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_CALCULO != original.TIPO_CALCULO) return true;
			
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
		/// Gets or sets the <c>CANTIDAD_CUOTAS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CUOTAS</c> column value.</value>
		public decimal CANTIDAD_CUOTAS
		{
			get { return _cantidad_cuotas; }
			set { _cantidad_cuotas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_1</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_1
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_1;
			}
			set
			{
				_fecha_desembolso_1Null = false;
				_fecha_desembolso_1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_1Null
		{
			get { return _fecha_desembolso_1Null; }
			set { _fecha_desembolso_1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_2</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_2
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_2;
			}
			set
			{
				_fecha_desembolso_2Null = false;
				_fecha_desembolso_2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_2Null
		{
			get { return _fecha_desembolso_2Null; }
			set { _fecha_desembolso_2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_3</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_3
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_3Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_3;
			}
			set
			{
				_fecha_desembolso_3Null = false;
				_fecha_desembolso_3 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_3"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_3Null
		{
			get { return _fecha_desembolso_3Null; }
			set { _fecha_desembolso_3Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_4</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_4
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_4Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_4;
			}
			set
			{
				_fecha_desembolso_4Null = false;
				_fecha_desembolso_4 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_4"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_4Null
		{
			get { return _fecha_desembolso_4Null; }
			set { _fecha_desembolso_4Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_5</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_5
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_5Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_5;
			}
			set
			{
				_fecha_desembolso_5Null = false;
				_fecha_desembolso_5 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_5"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_5Null
		{
			get { return _fecha_desembolso_5Null; }
			set { _fecha_desembolso_5Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_6</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_6</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_6
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_6Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_6;
			}
			set
			{
				_fecha_desembolso_6Null = false;
				_fecha_desembolso_6 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_6"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_6Null
		{
			get { return _fecha_desembolso_6Null; }
			set { _fecha_desembolso_6Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_7</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_7</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_7
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_7Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_7;
			}
			set
			{
				_fecha_desembolso_7Null = false;
				_fecha_desembolso_7 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_7"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_7Null
		{
			get { return _fecha_desembolso_7Null; }
			set { _fecha_desembolso_7Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_8</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_8</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_8
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_8Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_8;
			}
			set
			{
				_fecha_desembolso_8Null = false;
				_fecha_desembolso_8 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_8"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_8Null
		{
			get { return _fecha_desembolso_8Null; }
			set { _fecha_desembolso_8Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_9</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_9</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_9
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_9Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_9;
			}
			set
			{
				_fecha_desembolso_9Null = false;
				_fecha_desembolso_9 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_9"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_9Null
		{
			get { return _fecha_desembolso_9Null; }
			set { _fecha_desembolso_9Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_10</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_10</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_10
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_10Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_10;
			}
			set
			{
				_fecha_desembolso_10Null = false;
				_fecha_desembolso_10 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_10"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_10Null
		{
			get { return _fecha_desembolso_10Null; }
			set { _fecha_desembolso_10Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_11</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_11</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_11
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_11Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_11;
			}
			set
			{
				_fecha_desembolso_11Null = false;
				_fecha_desembolso_11 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_11"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_11Null
		{
			get { return _fecha_desembolso_11Null; }
			set { _fecha_desembolso_11Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO_12</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO_12</c> column value.</value>
		public decimal FECHA_DESEMBOLSO_12
		{
			get
			{
				if(IsFECHA_DESEMBOLSO_12Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso_12;
			}
			set
			{
				_fecha_desembolso_12Null = false;
				_fecha_desembolso_12 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO_12"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSO_12Null
		{
			get { return _fecha_desembolso_12Null; }
			set { _fecha_desembolso_12Null = value; }
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
		/// Gets or sets the <c>TIPO_CALCULO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CALCULO</c> column value.</value>
		public string TIPO_CALCULO
		{
			get { return _tipo_calculo; }
			set { _tipo_calculo = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD_CUOTAS=");
			dynStr.Append(CANTIDAD_CUOTAS);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_1=");
			dynStr.Append(IsFECHA_DESEMBOLSO_1Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_1);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_2=");
			dynStr.Append(IsFECHA_DESEMBOLSO_2Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_2);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_3=");
			dynStr.Append(IsFECHA_DESEMBOLSO_3Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_3);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_4=");
			dynStr.Append(IsFECHA_DESEMBOLSO_4Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_4);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_5=");
			dynStr.Append(IsFECHA_DESEMBOLSO_5Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_5);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_6=");
			dynStr.Append(IsFECHA_DESEMBOLSO_6Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_6);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_7=");
			dynStr.Append(IsFECHA_DESEMBOLSO_7Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_7);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_8=");
			dynStr.Append(IsFECHA_DESEMBOLSO_8Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_8);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_9=");
			dynStr.Append(IsFECHA_DESEMBOLSO_9Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_9);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_10=");
			dynStr.Append(IsFECHA_DESEMBOLSO_10Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_10);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_11=");
			dynStr.Append(IsFECHA_DESEMBOLSO_11Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_11);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO_12=");
			dynStr.Append(IsFECHA_DESEMBOLSO_12Null ? (object)"<NULL>" : FECHA_DESEMBOLSO_12);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_CALCULO=");
			dynStr.Append(TIPO_CALCULO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CONDICIONES_DESEMBOLSORow_Base class
} // End of namespace
