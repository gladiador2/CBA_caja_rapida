// <fileinfo name="DESCUENTOS_LLEGADAS_TAR_DETRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> that 
	/// represents a record in the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTOS_LLEGADAS_TAR_DETRow_Base
	{
		private decimal _id;
		private decimal _descuento_llegada_tardia_id;
		private decimal _monto_descuento;
		private bool _monto_descuentoNull = true;
		private System.DateTime _horas_penalizadas;
		private bool _horas_penalizadasNull = true;
		private decimal _punto_inicio;
		private bool _punto_inicioNull = true;
		private decimal _punto_fin;
		private bool _punto_finNull = true;
		private System.DateTime _tiempo_inicio;
		private bool _tiempo_inicioNull = true;
		private System.DateTime _tiempo_fin;
		private bool _tiempo_finNull = true;
		private string _mensaje;
		private string _estado;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow_Base"/> class.
		/// </summary>
		public DESCUENTOS_LLEGADAS_TAR_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTOS_LLEGADAS_TAR_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_LLEGADA_TARDIA_ID != original.DESCUENTO_LLEGADA_TARDIA_ID) return true;
			if (this.IsMONTO_DESCUENTONull != original.IsMONTO_DESCUENTONull) return true;
			if (!this.IsMONTO_DESCUENTONull && !original.IsMONTO_DESCUENTONull)
				if (this.MONTO_DESCUENTO != original.MONTO_DESCUENTO) return true;
			if (this.IsHORAS_PENALIZADASNull != original.IsHORAS_PENALIZADASNull) return true;
			if (!this.IsHORAS_PENALIZADASNull && !original.IsHORAS_PENALIZADASNull)
				if (this.HORAS_PENALIZADAS != original.HORAS_PENALIZADAS) return true;
			if (this.IsPUNTO_INICIONull != original.IsPUNTO_INICIONull) return true;
			if (!this.IsPUNTO_INICIONull && !original.IsPUNTO_INICIONull)
				if (this.PUNTO_INICIO != original.PUNTO_INICIO) return true;
			if (this.IsPUNTO_FINNull != original.IsPUNTO_FINNull) return true;
			if (!this.IsPUNTO_FINNull && !original.IsPUNTO_FINNull)
				if (this.PUNTO_FIN != original.PUNTO_FIN) return true;
			if (this.IsTIEMPO_INICIONull != original.IsTIEMPO_INICIONull) return true;
			if (!this.IsTIEMPO_INICIONull && !original.IsTIEMPO_INICIONull)
				if (this.TIEMPO_INICIO != original.TIEMPO_INICIO) return true;
			if (this.IsTIEMPO_FINNull != original.IsTIEMPO_FINNull) return true;
			if (!this.IsTIEMPO_FINNull && !original.IsTIEMPO_FINNull)
				if (this.TIEMPO_FIN != original.TIEMPO_FIN) return true;
			if (this.MENSAJE != original.MENSAJE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</value>
		public decimal DESCUENTO_LLEGADA_TARDIA_ID
		{
			get { return _descuento_llegada_tardia_id; }
			set { _descuento_llegada_tardia_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESCUENTO</c> column value.</value>
		public decimal MONTO_DESCUENTO
		{
			get
			{
				if(IsMONTO_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_descuento;
			}
			set
			{
				_monto_descuentoNull = false;
				_monto_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESCUENTONull
		{
			get { return _monto_descuentoNull; }
			set { _monto_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORAS_PENALIZADAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORAS_PENALIZADAS</c> column value.</value>
		public System.DateTime HORAS_PENALIZADAS
		{
			get
			{
				if(IsHORAS_PENALIZADASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _horas_penalizadas;
			}
			set
			{
				_horas_penalizadasNull = false;
				_horas_penalizadas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HORAS_PENALIZADAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHORAS_PENALIZADASNull
		{
			get { return _horas_penalizadasNull; }
			set { _horas_penalizadasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUNTO_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUNTO_INICIO</c> column value.</value>
		public decimal PUNTO_INICIO
		{
			get
			{
				if(IsPUNTO_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _punto_inicio;
			}
			set
			{
				_punto_inicioNull = false;
				_punto_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUNTO_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUNTO_INICIONull
		{
			get { return _punto_inicioNull; }
			set { _punto_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUNTO_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUNTO_FIN</c> column value.</value>
		public decimal PUNTO_FIN
		{
			get
			{
				if(IsPUNTO_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _punto_fin;
			}
			set
			{
				_punto_finNull = false;
				_punto_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUNTO_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUNTO_FINNull
		{
			get { return _punto_finNull; }
			set { _punto_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIEMPO_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIEMPO_INICIO</c> column value.</value>
		public System.DateTime TIEMPO_INICIO
		{
			get
			{
				if(IsTIEMPO_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tiempo_inicio;
			}
			set
			{
				_tiempo_inicioNull = false;
				_tiempo_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIEMPO_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIEMPO_INICIONull
		{
			get { return _tiempo_inicioNull; }
			set { _tiempo_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIEMPO_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIEMPO_FIN</c> column value.</value>
		public System.DateTime TIEMPO_FIN
		{
			get
			{
				if(IsTIEMPO_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tiempo_fin;
			}
			set
			{
				_tiempo_finNull = false;
				_tiempo_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIEMPO_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIEMPO_FINNull
		{
			get { return _tiempo_finNull; }
			set { _tiempo_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MENSAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MENSAJE</c> column value.</value>
		public string MENSAJE
		{
			get { return _mensaje; }
			set { _mensaje = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@DESCUENTO_LLEGADA_TARDIA_ID=");
			dynStr.Append(DESCUENTO_LLEGADA_TARDIA_ID);
			dynStr.Append("@CBA@MONTO_DESCUENTO=");
			dynStr.Append(IsMONTO_DESCUENTONull ? (object)"<NULL>" : MONTO_DESCUENTO);
			dynStr.Append("@CBA@HORAS_PENALIZADAS=");
			dynStr.Append(IsHORAS_PENALIZADASNull ? (object)"<NULL>" : HORAS_PENALIZADAS);
			dynStr.Append("@CBA@PUNTO_INICIO=");
			dynStr.Append(IsPUNTO_INICIONull ? (object)"<NULL>" : PUNTO_INICIO);
			dynStr.Append("@CBA@PUNTO_FIN=");
			dynStr.Append(IsPUNTO_FINNull ? (object)"<NULL>" : PUNTO_FIN);
			dynStr.Append("@CBA@TIEMPO_INICIO=");
			dynStr.Append(IsTIEMPO_INICIONull ? (object)"<NULL>" : TIEMPO_INICIO);
			dynStr.Append("@CBA@TIEMPO_FIN=");
			dynStr.Append(IsTIEMPO_FINNull ? (object)"<NULL>" : TIEMPO_FIN);
			dynStr.Append("@CBA@MENSAJE=");
			dynStr.Append(MENSAJE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of DESCUENTOS_LLEGADAS_TAR_DETRow_Base class
} // End of namespace
