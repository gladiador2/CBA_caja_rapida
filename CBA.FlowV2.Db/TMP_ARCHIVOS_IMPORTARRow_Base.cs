// <fileinfo name="TMP_ARCHIVOS_IMPORTARRow_Base.cs">
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
	/// The base class for <see cref="TMP_ARCHIVOS_IMPORTARRow"/> that 
	/// represents a record in the <c>TMP_ARCHIVOS_IMPORTAR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TMP_ARCHIVOS_IMPORTARRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_ARCHIVOS_IMPORTARRow_Base
	{
		private string _codigo;
		private string _descripcion;
		private string _unidad_medida;
		private string _familia;
		private decimal _tyc;
		private bool _tycNull = true;
		private decimal _ande;
		private bool _andeNull = true;
		private decimal _consorcio;
		private bool _consorcioNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_ARCHIVOS_IMPORTARRow_Base"/> class.
		/// </summary>
		public TMP_ARCHIVOS_IMPORTARRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TMP_ARCHIVOS_IMPORTARRow_Base original)
		{
			if (this.CODIGO != original.CODIGO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.UNIDAD_MEDIDA != original.UNIDAD_MEDIDA) return true;
			if (this.FAMILIA != original.FAMILIA) return true;
			if (this.IsTYCNull != original.IsTYCNull) return true;
			if (!this.IsTYCNull && !original.IsTYCNull)
				if (this.TYC != original.TYC) return true;
			if (this.IsANDENull != original.IsANDENull) return true;
			if (!this.IsANDENull && !original.IsANDENull)
				if (this.ANDE != original.ANDE) return true;
			if (this.IsCONSORCIONull != original.IsCONSORCIONull) return true;
			if (!this.IsCONSORCIONull && !original.IsCONSORCIONull)
				if (this.CONSORCIO != original.CONSORCIO) return true;
			
			return false;
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA</c> column value.</value>
		public string UNIDAD_MEDIDA
		{
			get { return _unidad_medida; }
			set { _unidad_medida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA</c> column value.
		/// </summary>
		/// <value>The <c>FAMILIA</c> column value.</value>
		public string FAMILIA
		{
			get { return _familia; }
			set { _familia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TYC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TYC</c> column value.</value>
		public decimal TYC
		{
			get
			{
				if(IsTYCNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tyc;
			}
			set
			{
				_tycNull = false;
				_tyc = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TYC"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTYCNull
		{
			get { return _tycNull; }
			set { _tycNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANDE</c> column value.</value>
		public decimal ANDE
		{
			get
			{
				if(IsANDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ande;
			}
			set
			{
				_andeNull = false;
				_ande = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANDENull
		{
			get { return _andeNull; }
			set { _andeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSORCIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSORCIO</c> column value.</value>
		public decimal CONSORCIO
		{
			get
			{
				if(IsCONSORCIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _consorcio;
			}
			set
			{
				_consorcioNull = false;
				_consorcio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONSORCIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONSORCIONull
		{
			get { return _consorcioNull; }
			set { _consorcioNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@UNIDAD_MEDIDA=");
			dynStr.Append(UNIDAD_MEDIDA);
			dynStr.Append("@CBA@FAMILIA=");
			dynStr.Append(FAMILIA);
			dynStr.Append("@CBA@TYC=");
			dynStr.Append(IsTYCNull ? (object)"<NULL>" : TYC);
			dynStr.Append("@CBA@ANDE=");
			dynStr.Append(IsANDENull ? (object)"<NULL>" : ANDE);
			dynStr.Append("@CBA@CONSORCIO=");
			dynStr.Append(IsCONSORCIONull ? (object)"<NULL>" : CONSORCIO);
			return dynStr.ToString();
		}
	} // End of TMP_ARCHIVOS_IMPORTARRow_Base class
} // End of namespace
