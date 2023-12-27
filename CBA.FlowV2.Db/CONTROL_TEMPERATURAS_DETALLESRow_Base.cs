// <fileinfo name="CONTROL_TEMPERATURAS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="CONTROL_TEMPERATURAS_DETALLESRow"/> that 
	/// represents a record in the <c>CONTROL_TEMPERATURAS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTROL_TEMPERATURAS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTROL_TEMPERATURAS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _control_temperatura_id;
		private decimal _contenedor_id;
		private decimal _set_point;
		private bool _set_pointNull = true;
		private decimal _temperatura;
		private bool _temperaturaNull = true;
		private string _observaciones;
		private decimal _nro_lectura;
		private System.DateTime _hora;
		private bool _horaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMPERATURAS_DETALLESRow_Base"/> class.
		/// </summary>
		public CONTROL_TEMPERATURAS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTROL_TEMPERATURAS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CONTROL_TEMPERATURA_ID != original.CONTROL_TEMPERATURA_ID) return true;
			if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.IsSET_POINTNull != original.IsSET_POINTNull) return true;
			if (!this.IsSET_POINTNull && !original.IsSET_POINTNull)
				if (this.SET_POINT != original.SET_POINT) return true;
			if (this.IsTEMPERATURANull != original.IsTEMPERATURANull) return true;
			if (!this.IsTEMPERATURANull && !original.IsTEMPERATURANull)
				if (this.TEMPERATURA != original.TEMPERATURA) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.NRO_LECTURA != original.NRO_LECTURA) return true;
			if (this.IsHORANull != original.IsHORANull) return true;
			if (!this.IsHORANull && !original.IsHORANull)
				if (this.HORA != original.HORA) return true;
			
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
		/// Gets or sets the <c>CONTROL_TEMPERATURA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTROL_TEMPERATURA_ID</c> column value.</value>
		public decimal CONTROL_TEMPERATURA_ID
		{
			get { return _control_temperatura_id; }
			set { _control_temperatura_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CONTROL_TEMPERATURA_ID=");
			dynStr.Append(CONTROL_TEMPERATURA_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(CONTENEDOR_ID);
			dynStr.Append("@CBA@SET_POINT=");
			dynStr.Append(IsSET_POINTNull ? (object)"<NULL>" : SET_POINT);
			dynStr.Append("@CBA@TEMPERATURA=");
			dynStr.Append(IsTEMPERATURANull ? (object)"<NULL>" : TEMPERATURA);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@NRO_LECTURA=");
			dynStr.Append(NRO_LECTURA);
			dynStr.Append("@CBA@HORA=");
			dynStr.Append(IsHORANull ? (object)"<NULL>" : HORA);
			return dynStr.ToString();
		}
	} // End of CONTROL_TEMPERATURAS_DETALLESRow_Base class
} // End of namespace
