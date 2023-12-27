// <fileinfo name="INTERCAMBIO_EQUIPOSRow_Base.cs">
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
	/// The base class for <see cref="INTERCAMBIO_EQUIPOSRow"/> that 
	/// represents a record in the <c>INTERCAMBIO_EQUIPOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INTERCAMBIO_EQUIPOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INTERCAMBIO_EQUIPOSRow_Base
	{
		private decimal _id;
		private string _nro_comprobante;
		private decimal _buque_id;
		private bool _buque_idNull = true;
		private decimal _manifiesto_id;
		private bool _manifiesto_idNull = true;
		private string _tipo_equipo;
		private string _operacion;
		private decimal _pre_embarque_id;
		private bool _pre_embarque_idNull = true;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _finalizado;
		private decimal _muelle_id;
		private bool _muelle_idNull = true;
		private System.DateTime _inicio;
		private bool _inicioNull = true;
		private System.DateTime _fin;
		private bool _finNull = true;
		private System.DateTime _amarre;
		private bool _amarreNull = true;
		private System.DateTime _desamarre;
		private bool _desamarreNull = true;
		private decimal _removidos_bmb;
		private bool _removidos_bmbNull = true;
		private decimal _removidos_bb;
		private bool _removidos_bbNull = true;
		private decimal _removidos_otros;
		private bool _removidos_otrosNull = true;
		private string _notificado_clientes;
		private string _notificado_lineas;
		private string _notificado_armadores;

		/// <summary>
		/// Initializes a new instance of the <see cref="INTERCAMBIO_EQUIPOSRow_Base"/> class.
		/// </summary>
		public INTERCAMBIO_EQUIPOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INTERCAMBIO_EQUIPOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsBUQUE_IDNull != original.IsBUQUE_IDNull) return true;
			if (!this.IsBUQUE_IDNull && !original.IsBUQUE_IDNull)
				if (this.BUQUE_ID != original.BUQUE_ID) return true;
			if (this.IsMANIFIESTO_IDNull != original.IsMANIFIESTO_IDNull) return true;
			if (!this.IsMANIFIESTO_IDNull && !original.IsMANIFIESTO_IDNull)
				if (this.MANIFIESTO_ID != original.MANIFIESTO_ID) return true;
			if (this.TIPO_EQUIPO != original.TIPO_EQUIPO) return true;
			if (this.OPERACION != original.OPERACION) return true;
			if (this.IsPRE_EMBARQUE_IDNull != original.IsPRE_EMBARQUE_IDNull) return true;
			if (!this.IsPRE_EMBARQUE_IDNull && !original.IsPRE_EMBARQUE_IDNull)
				if (this.PRE_EMBARQUE_ID != original.PRE_EMBARQUE_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			if (this.IsMUELLE_IDNull != original.IsMUELLE_IDNull) return true;
			if (!this.IsMUELLE_IDNull && !original.IsMUELLE_IDNull)
				if (this.MUELLE_ID != original.MUELLE_ID) return true;
			if (this.IsINICIONull != original.IsINICIONull) return true;
			if (!this.IsINICIONull && !original.IsINICIONull)
				if (this.INICIO != original.INICIO) return true;
			if (this.IsFINNull != original.IsFINNull) return true;
			if (!this.IsFINNull && !original.IsFINNull)
				if (this.FIN != original.FIN) return true;
			if (this.IsAMARRENull != original.IsAMARRENull) return true;
			if (!this.IsAMARRENull && !original.IsAMARRENull)
				if (this.AMARRE != original.AMARRE) return true;
			if (this.IsDESAMARRENull != original.IsDESAMARRENull) return true;
			if (!this.IsDESAMARRENull && !original.IsDESAMARRENull)
				if (this.DESAMARRE != original.DESAMARRE) return true;
			if (this.IsREMOVIDOS_BMBNull != original.IsREMOVIDOS_BMBNull) return true;
			if (!this.IsREMOVIDOS_BMBNull && !original.IsREMOVIDOS_BMBNull)
				if (this.REMOVIDOS_BMB != original.REMOVIDOS_BMB) return true;
			if (this.IsREMOVIDOS_BBNull != original.IsREMOVIDOS_BBNull) return true;
			if (!this.IsREMOVIDOS_BBNull && !original.IsREMOVIDOS_BBNull)
				if (this.REMOVIDOS_BB != original.REMOVIDOS_BB) return true;
			if (this.IsREMOVIDOS_OTROSNull != original.IsREMOVIDOS_OTROSNull) return true;
			if (!this.IsREMOVIDOS_OTROSNull && !original.IsREMOVIDOS_OTROSNull)
				if (this.REMOVIDOS_OTROS != original.REMOVIDOS_OTROS) return true;
			if (this.NOTIFICADO_CLIENTES != original.NOTIFICADO_CLIENTES) return true;
			if (this.NOTIFICADO_LINEAS != original.NOTIFICADO_LINEAS) return true;
			if (this.NOTIFICADO_ARMADORES != original.NOTIFICADO_ARMADORES) return true;
			
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
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
		/// Gets or sets the <c>MANIFIESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MANIFIESTO_ID</c> column value.</value>
		public decimal MANIFIESTO_ID
		{
			get
			{
				if(IsMANIFIESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _manifiesto_id;
			}
			set
			{
				_manifiesto_idNull = false;
				_manifiesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MANIFIESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMANIFIESTO_IDNull
		{
			get { return _manifiesto_idNull; }
			set { _manifiesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EQUIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EQUIPO</c> column value.</value>
		public string TIPO_EQUIPO
		{
			get { return _tipo_equipo; }
			set { _tipo_equipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OPERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION</c> column value.</value>
		public string OPERACION
		{
			get { return _operacion; }
			set { _operacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRE_EMBARQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRE_EMBARQUE_ID</c> column value.</value>
		public decimal PRE_EMBARQUE_ID
		{
			get
			{
				if(IsPRE_EMBARQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pre_embarque_id;
			}
			set
			{
				_pre_embarque_idNull = false;
				_pre_embarque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRE_EMBARQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRE_EMBARQUE_IDNull
		{
			get { return _pre_embarque_idNull; }
			set { _pre_embarque_idNull = value; }
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
		/// Gets or sets the <c>FINALIZADO</c> column value.
		/// </summary>
		/// <value>The <c>FINALIZADO</c> column value.</value>
		public string FINALIZADO
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MUELLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MUELLE_ID</c> column value.</value>
		public decimal MUELLE_ID
		{
			get
			{
				if(IsMUELLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _muelle_id;
			}
			set
			{
				_muelle_idNull = false;
				_muelle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MUELLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMUELLE_IDNull
		{
			get { return _muelle_idNull; }
			set { _muelle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INICIO</c> column value.</value>
		public System.DateTime INICIO
		{
			get
			{
				if(IsINICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inicio;
			}
			set
			{
				_inicioNull = false;
				_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINICIONull
		{
			get { return _inicioNull; }
			set { _inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FIN</c> column value.</value>
		public System.DateTime FIN
		{
			get
			{
				if(IsFINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fin;
			}
			set
			{
				_finNull = false;
				_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFINNull
		{
			get { return _finNull; }
			set { _finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AMARRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AMARRE</c> column value.</value>
		public System.DateTime AMARRE
		{
			get
			{
				if(IsAMARRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _amarre;
			}
			set
			{
				_amarreNull = false;
				_amarre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AMARRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAMARRENull
		{
			get { return _amarreNull; }
			set { _amarreNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESAMARRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESAMARRE</c> column value.</value>
		public System.DateTime DESAMARRE
		{
			get
			{
				if(IsDESAMARRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desamarre;
			}
			set
			{
				_desamarreNull = false;
				_desamarre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESAMARRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESAMARRENull
		{
			get { return _desamarreNull; }
			set { _desamarreNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REMOVIDOS_BMB</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REMOVIDOS_BMB</c> column value.</value>
		public decimal REMOVIDOS_BMB
		{
			get
			{
				if(IsREMOVIDOS_BMBNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _removidos_bmb;
			}
			set
			{
				_removidos_bmbNull = false;
				_removidos_bmb = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REMOVIDOS_BMB"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREMOVIDOS_BMBNull
		{
			get { return _removidos_bmbNull; }
			set { _removidos_bmbNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REMOVIDOS_BB</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REMOVIDOS_BB</c> column value.</value>
		public decimal REMOVIDOS_BB
		{
			get
			{
				if(IsREMOVIDOS_BBNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _removidos_bb;
			}
			set
			{
				_removidos_bbNull = false;
				_removidos_bb = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REMOVIDOS_BB"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREMOVIDOS_BBNull
		{
			get { return _removidos_bbNull; }
			set { _removidos_bbNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REMOVIDOS_OTROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REMOVIDOS_OTROS</c> column value.</value>
		public decimal REMOVIDOS_OTROS
		{
			get
			{
				if(IsREMOVIDOS_OTROSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _removidos_otros;
			}
			set
			{
				_removidos_otrosNull = false;
				_removidos_otros = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REMOVIDOS_OTROS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREMOVIDOS_OTROSNull
		{
			get { return _removidos_otrosNull; }
			set { _removidos_otrosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTIFICADO_CLIENTES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTIFICADO_CLIENTES</c> column value.</value>
		public string NOTIFICADO_CLIENTES
		{
			get { return _notificado_clientes; }
			set { _notificado_clientes = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTIFICADO_LINEAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTIFICADO_LINEAS</c> column value.</value>
		public string NOTIFICADO_LINEAS
		{
			get { return _notificado_lineas; }
			set { _notificado_lineas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTIFICADO_ARMADORES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTIFICADO_ARMADORES</c> column value.</value>
		public string NOTIFICADO_ARMADORES
		{
			get { return _notificado_armadores; }
			set { _notificado_armadores = value; }
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
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@BUQUE_ID=");
			dynStr.Append(IsBUQUE_IDNull ? (object)"<NULL>" : BUQUE_ID);
			dynStr.Append("@CBA@MANIFIESTO_ID=");
			dynStr.Append(IsMANIFIESTO_IDNull ? (object)"<NULL>" : MANIFIESTO_ID);
			dynStr.Append("@CBA@TIPO_EQUIPO=");
			dynStr.Append(TIPO_EQUIPO);
			dynStr.Append("@CBA@OPERACION=");
			dynStr.Append(OPERACION);
			dynStr.Append("@CBA@PRE_EMBARQUE_ID=");
			dynStr.Append(IsPRE_EMBARQUE_IDNull ? (object)"<NULL>" : PRE_EMBARQUE_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			dynStr.Append("@CBA@MUELLE_ID=");
			dynStr.Append(IsMUELLE_IDNull ? (object)"<NULL>" : MUELLE_ID);
			dynStr.Append("@CBA@INICIO=");
			dynStr.Append(IsINICIONull ? (object)"<NULL>" : INICIO);
			dynStr.Append("@CBA@FIN=");
			dynStr.Append(IsFINNull ? (object)"<NULL>" : FIN);
			dynStr.Append("@CBA@AMARRE=");
			dynStr.Append(IsAMARRENull ? (object)"<NULL>" : AMARRE);
			dynStr.Append("@CBA@DESAMARRE=");
			dynStr.Append(IsDESAMARRENull ? (object)"<NULL>" : DESAMARRE);
			dynStr.Append("@CBA@REMOVIDOS_BMB=");
			dynStr.Append(IsREMOVIDOS_BMBNull ? (object)"<NULL>" : REMOVIDOS_BMB);
			dynStr.Append("@CBA@REMOVIDOS_BB=");
			dynStr.Append(IsREMOVIDOS_BBNull ? (object)"<NULL>" : REMOVIDOS_BB);
			dynStr.Append("@CBA@REMOVIDOS_OTROS=");
			dynStr.Append(IsREMOVIDOS_OTROSNull ? (object)"<NULL>" : REMOVIDOS_OTROS);
			dynStr.Append("@CBA@NOTIFICADO_CLIENTES=");
			dynStr.Append(NOTIFICADO_CLIENTES);
			dynStr.Append("@CBA@NOTIFICADO_LINEAS=");
			dynStr.Append(NOTIFICADO_LINEAS);
			dynStr.Append("@CBA@NOTIFICADO_ARMADORES=");
			dynStr.Append(NOTIFICADO_ARMADORES);
			return dynStr.ToString();
		}
	} // End of INTERCAMBIO_EQUIPOSRow_Base class
} // End of namespace
