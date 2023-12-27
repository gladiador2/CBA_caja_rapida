// <fileinfo name="ARTICULOS_FINANCIEROS_RANGOSRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> that 
	/// represents a record in the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_FINANCIEROS_RANGOSRow_Base
	{
		private decimal _id;
		private decimal _articulo_financiero_id;
		private decimal _tipo_articulo_financ_rango_id;
		private decimal _dias_desde;
		private decimal _monto_desde;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private string _estado;
		private string _considerar_plazo;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FINANCIEROS_RANGOSRow_Base"/> class.
		/// </summary>
		public ARTICULOS_FINANCIEROS_RANGOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_FINANCIEROS_RANGOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_FINANCIERO_ID != original.ARTICULO_FINANCIERO_ID) return true;
			if (this.TIPO_ARTICULO_FINANC_RANGO_ID != original.TIPO_ARTICULO_FINANC_RANGO_ID) return true;
			if (this.DIAS_DESDE != original.DIAS_DESDE) return true;
			if (this.MONTO_DESDE != original.MONTO_DESDE) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CONSIDERAR_PLAZO != original.CONSIDERAR_PLAZO) return true;
			
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
		/// Gets or sets the <c>ARTICULO_FINANCIERO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_FINANCIERO_ID</c> column value.</value>
		public decimal ARTICULO_FINANCIERO_ID
		{
			get { return _articulo_financiero_id; }
			set { _articulo_financiero_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</value>
		public decimal TIPO_ARTICULO_FINANC_RANGO_ID
		{
			get { return _tipo_articulo_financ_rango_id; }
			set { _tipo_articulo_financ_rango_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_DESDE</c> column value.</value>
		public decimal DIAS_DESDE
		{
			get { return _dias_desde; }
			set { _dias_desde = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESDE</c> column value.</value>
		public decimal MONTO_DESDE
		{
			get { return _monto_desde; }
			set { _monto_desde = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIDERAR_PLAZO</c> column value.
		/// </summary>
		/// <value>The <c>CONSIDERAR_PLAZO</c> column value.</value>
		public string CONSIDERAR_PLAZO
		{
			get { return _considerar_plazo; }
			set { _considerar_plazo = value; }
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
			dynStr.Append("@CBA@ARTICULO_FINANCIERO_ID=");
			dynStr.Append(ARTICULO_FINANCIERO_ID);
			dynStr.Append("@CBA@TIPO_ARTICULO_FINANC_RANGO_ID=");
			dynStr.Append(TIPO_ARTICULO_FINANC_RANGO_ID);
			dynStr.Append("@CBA@DIAS_DESDE=");
			dynStr.Append(DIAS_DESDE);
			dynStr.Append("@CBA@MONTO_DESDE=");
			dynStr.Append(MONTO_DESDE);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CONSIDERAR_PLAZO=");
			dynStr.Append(CONSIDERAR_PLAZO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_FINANCIEROS_RANGOSRow_Base class
} // End of namespace
