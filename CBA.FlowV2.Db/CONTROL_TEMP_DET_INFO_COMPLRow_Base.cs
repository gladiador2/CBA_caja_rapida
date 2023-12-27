// <fileinfo name="CONTROL_TEMP_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CONTROL_TEMP_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CONTROL_TEMP_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTROL_TEMP_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTROL_TEMP_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _nro_lectura;
		private System.DateTime _hora;
		private bool _horaNull = true;
		private decimal _control_temperatura_id;
		private string _nro_comprobante;
		private decimal _contenedor_id;
		private string _contenedor_numero;
		private decimal _linea_id;
		private string _linea_nombre;
		private decimal _set_point;
		private bool _set_pointNull = true;
		private decimal _temperatura;
		private bool _temperaturaNull = true;
		private string _observaciones;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMP_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CONTROL_TEMP_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTROL_TEMP_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NRO_LECTURA != original.NRO_LECTURA) return true;
			if (this.IsHORANull != original.IsHORANull) return true;
			if (!this.IsHORANull && !original.IsHORANull)
				if (this.HORA != original.HORA) return true;
			if (this.CONTROL_TEMPERATURA_ID != original.CONTROL_TEMPERATURA_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.LINEA_NOMBRE != original.LINEA_NOMBRE) return true;
			if (this.IsSET_POINTNull != original.IsSET_POINTNull) return true;
			if (!this.IsSET_POINTNull && !original.IsSET_POINTNull)
				if (this.SET_POINT != original.SET_POINT) return true;
			if (this.IsTEMPERATURANull != original.IsTEMPERATURANull) return true;
			if (!this.IsTEMPERATURANull && !original.IsTEMPERATURANull)
				if (this.TEMPERATURA != original.TEMPERATURA) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			
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
		/// Gets or sets the <c>NRO_LECTURA</c> column value.
		/// </summary>
		/// <value>The <c>NRO_LECTURA</c> column value.</value>
		public decimal NRO_LECTURA
		{
			get { return _nro_lectura; }
			set { _nro_lectura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORA</c> column value.</value>
		public System.DateTime HORA
		{
			get
			{
				if(IsHORANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _hora;
			}
			set
			{
				_horaNull = false;
				_hora = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HORA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHORANull
		{
			get { return _horaNull; }
			set { _horaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROL_TEMPERATURA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTROL_TEMPERATURA_ID</c> column value.</value>
		public decimal CONTROL_TEMPERATURA_ID
		{
			get { return _control_temperatura_id; }
			set { _control_temperatura_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get { return _contenedor_id; }
			set { _contenedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_NUMERO</c> column value.</value>
		public string CONTENEDOR_NUMERO
		{
			get { return _contenedor_numero; }
			set { _contenedor_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get { return _linea_id; }
			set { _linea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINEA_NOMBRE</c> column value.</value>
		public string LINEA_NOMBRE
		{
			get { return _linea_nombre; }
			set { _linea_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SET_POINT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SET_POINT</c> column value.</value>
		public decimal SET_POINT
		{
			get
			{
				if(IsSET_POINTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _set_point;
			}
			set
			{
				_set_pointNull = false;
				_set_point = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SET_POINT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSET_POINTNull
		{
			get { return _set_pointNull; }
			set { _set_pointNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPERATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEMPERATURA</c> column value.</value>
		public decimal TEMPERATURA
		{
			get
			{
				if(IsTEMPERATURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _temperatura;
			}
			set
			{
				_temperaturaNull = false;
				_temperatura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEMPERATURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEMPERATURANull
		{
			get { return _temperaturaNull; }
			set { _temperaturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
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
			dynStr.Append("@CBA@NRO_LECTURA=");
			dynStr.Append(NRO_LECTURA);
			dynStr.Append("@CBA@HORA=");
			dynStr.Append(IsHORANull ? (object)"<NULL>" : HORA);
			dynStr.Append("@CBA@CONTROL_TEMPERATURA_ID=");
			dynStr.Append(CONTROL_TEMPERATURA_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(LINEA_ID);
			dynStr.Append("@CBA@LINEA_NOMBRE=");
			dynStr.Append(LINEA_NOMBRE);
			dynStr.Append("@CBA@SET_POINT=");
			dynStr.Append(IsSET_POINTNull ? (object)"<NULL>" : SET_POINT);
			dynStr.Append("@CBA@TEMPERATURA=");
			dynStr.Append(IsTEMPERATURANull ? (object)"<NULL>" : TEMPERATURA);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			return dynStr.ToString();
		}
	} // End of CONTROL_TEMP_DET_INFO_COMPLRow_Base class
} // End of namespace
