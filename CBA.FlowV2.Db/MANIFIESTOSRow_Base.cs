// <fileinfo name="MANIFIESTOSRow_Base.cs">
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
	/// The base class for <see cref="MANIFIESTOSRow"/> that 
	/// represents a record in the <c>MANIFIESTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MANIFIESTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MANIFIESTOSRow_Base
	{
		private decimal _id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _nro_registro;
		private decimal _buque_id;
		private bool _buque_idNull = true;
		private string _nro_viaje;
		private System.DateTime _fecha_descarga;
		private bool _fecha_descargaNull = true;
		private string _tipo;
		private string _estado;
		private string _nro_carpeta;
		private decimal _puerto_id;
		private bool _puerto_idNull = true;
		private string _nro_viaje_cma;
		private string _nro_viaje_maersk;
		private decimal _armador_id;
		private bool _armador_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MANIFIESTOSRow_Base"/> class.
		/// </summary>
		public MANIFIESTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MANIFIESTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.NRO_REGISTRO != original.NRO_REGISTRO) return true;
			if (this.IsBUQUE_IDNull != original.IsBUQUE_IDNull) return true;
			if (!this.IsBUQUE_IDNull && !original.IsBUQUE_IDNull)
				if (this.BUQUE_ID != original.BUQUE_ID) return true;
			if (this.NRO_VIAJE != original.NRO_VIAJE) return true;
			if (this.IsFECHA_DESCARGANull != original.IsFECHA_DESCARGANull) return true;
			if (!this.IsFECHA_DESCARGANull && !original.IsFECHA_DESCARGANull)
				if (this.FECHA_DESCARGA != original.FECHA_DESCARGA) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NRO_CARPETA != original.NRO_CARPETA) return true;
			if (this.IsPUERTO_IDNull != original.IsPUERTO_IDNull) return true;
			if (!this.IsPUERTO_IDNull && !original.IsPUERTO_IDNull)
				if (this.PUERTO_ID != original.PUERTO_ID) return true;
			if (this.NRO_VIAJE_CMA != original.NRO_VIAJE_CMA) return true;
			if (this.NRO_VIAJE_MAERSK != original.NRO_VIAJE_MAERSK) return true;
			if (this.IsARMADOR_IDNull != original.IsARMADOR_IDNull) return true;
			if (!this.IsARMADOR_IDNull && !original.IsARMADOR_IDNull)
				if (this.ARMADOR_ID != original.ARMADOR_ID) return true;
			
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_REGISTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_REGISTRO</c> column value.</value>
		public string NRO_REGISTRO
		{
			get { return _nro_registro; }
			set { _nro_registro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BUQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BUQUE_ID</c> column value.</value>
		public decimal BUQUE_ID
		{
			get
			{
				if(IsBUQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _buque_id;
			}
			set
			{
				_buque_idNull = false;
				_buque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BUQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBUQUE_IDNull
		{
			get { return _buque_idNull; }
			set { _buque_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_VIAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_VIAJE</c> column value.</value>
		public string NRO_VIAJE
		{
			get { return _nro_viaje; }
			set { _nro_viaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESCARGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESCARGA</c> column value.</value>
		public System.DateTime FECHA_DESCARGA
		{
			get
			{
				if(IsFECHA_DESCARGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_descarga;
			}
			set
			{
				_fecha_descargaNull = false;
				_fecha_descarga = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESCARGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESCARGANull
		{
			get { return _fecha_descargaNull; }
			set { _fecha_descargaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
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
		/// Gets or sets the <c>NRO_CARPETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CARPETA</c> column value.</value>
		public string NRO_CARPETA
		{
			get { return _nro_carpeta; }
			set { _nro_carpeta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_ID</c> column value.</value>
		public decimal PUERTO_ID
		{
			get
			{
				if(IsPUERTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_id;
			}
			set
			{
				_puerto_idNull = false;
				_puerto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_IDNull
		{
			get { return _puerto_idNull; }
			set { _puerto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_VIAJE_CMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_VIAJE_CMA</c> column value.</value>
		public string NRO_VIAJE_CMA
		{
			get { return _nro_viaje_cma; }
			set { _nro_viaje_cma = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_VIAJE_MAERSK</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_VIAJE_MAERSK</c> column value.</value>
		public string NRO_VIAJE_MAERSK
		{
			get { return _nro_viaje_maersk; }
			set { _nro_viaje_maersk = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARMADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARMADOR_ID</c> column value.</value>
		public decimal ARMADOR_ID
		{
			get
			{
				if(IsARMADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _armador_id;
			}
			set
			{
				_armador_idNull = false;
				_armador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARMADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARMADOR_IDNull
		{
			get { return _armador_idNull; }
			set { _armador_idNull = value; }
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
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@NRO_REGISTRO=");
			dynStr.Append(NRO_REGISTRO);
			dynStr.Append("@CBA@BUQUE_ID=");
			dynStr.Append(IsBUQUE_IDNull ? (object)"<NULL>" : BUQUE_ID);
			dynStr.Append("@CBA@NRO_VIAJE=");
			dynStr.Append(NRO_VIAJE);
			dynStr.Append("@CBA@FECHA_DESCARGA=");
			dynStr.Append(IsFECHA_DESCARGANull ? (object)"<NULL>" : FECHA_DESCARGA);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NRO_CARPETA=");
			dynStr.Append(NRO_CARPETA);
			dynStr.Append("@CBA@PUERTO_ID=");
			dynStr.Append(IsPUERTO_IDNull ? (object)"<NULL>" : PUERTO_ID);
			dynStr.Append("@CBA@NRO_VIAJE_CMA=");
			dynStr.Append(NRO_VIAJE_CMA);
			dynStr.Append("@CBA@NRO_VIAJE_MAERSK=");
			dynStr.Append(NRO_VIAJE_MAERSK);
			dynStr.Append("@CBA@ARMADOR_ID=");
			dynStr.Append(IsARMADOR_IDNull ? (object)"<NULL>" : ARMADOR_ID);
			return dynStr.ToString();
		}
	} // End of MANIFIESTOSRow_Base class
} // End of namespace
