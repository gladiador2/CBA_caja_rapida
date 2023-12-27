// <fileinfo name="CONTRATOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="CONTRATOS_DETALLESRow"/> that 
	/// represents a record in the <c>CONTRATOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTRATOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTRATOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _contrato_id;
		private string _titulo_etapa;
		private string _descripcio_etapa;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private string _estado_etapa;
		private decimal _monto_etapa;
		private bool _monto_etapaNull = true;
		private string _requerimiento_cobrar;
		private string _cobrado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTRATOS_DETALLESRow_Base"/> class.
		/// </summary>
		public CONTRATOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTRATOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CONTRATO_ID != original.CONTRATO_ID) return true;
			if (this.TITULO_ETAPA != original.TITULO_ETAPA) return true;
			if (this.DESCRIPCIO_ETAPA != original.DESCRIPCIO_ETAPA) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.ESTADO_ETAPA != original.ESTADO_ETAPA) return true;
			if (this.IsMONTO_ETAPANull != original.IsMONTO_ETAPANull) return true;
			if (!this.IsMONTO_ETAPANull && !original.IsMONTO_ETAPANull)
				if (this.MONTO_ETAPA != original.MONTO_ETAPA) return true;
			if (this.REQUERIMIENTO_COBRAR != original.REQUERIMIENTO_COBRAR) return true;
			if (this.COBRADO != original.COBRADO) return true;
			
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
		/// Gets or sets the <c>CONTRATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTRATO_ID</c> column value.</value>
		public decimal CONTRATO_ID
		{
			get { return _contrato_id; }
			set { _contrato_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULO_ETAPA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULO_ETAPA</c> column value.</value>
		public string TITULO_ETAPA
		{
			get { return _titulo_etapa; }
			set { _titulo_etapa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCIO_ETAPA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCIO_ETAPA</c> column value.</value>
		public string DESCRIPCIO_ETAPA
		{
			get { return _descripcio_etapa; }
			set { _descripcio_etapa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ETAPA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ETAPA</c> column value.</value>
		public string ESTADO_ETAPA
		{
			get { return _estado_etapa; }
			set { _estado_etapa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ETAPA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_ETAPA</c> column value.</value>
		public decimal MONTO_ETAPA
		{
			get
			{
				if(IsMONTO_ETAPANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_etapa;
			}
			set
			{
				_monto_etapaNull = false;
				_monto_etapa = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_ETAPA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_ETAPANull
		{
			get { return _monto_etapaNull; }
			set { _monto_etapaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REQUERIMIENTO_COBRAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REQUERIMIENTO_COBRAR</c> column value.</value>
		public string REQUERIMIENTO_COBRAR
		{
			get { return _requerimiento_cobrar; }
			set { _requerimiento_cobrar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>COBRADO</c> column value.</value>
		public string COBRADO
		{
			get { return _cobrado; }
			set { _cobrado = value; }
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
			dynStr.Append("@CBA@CONTRATO_ID=");
			dynStr.Append(CONTRATO_ID);
			dynStr.Append("@CBA@TITULO_ETAPA=");
			dynStr.Append(TITULO_ETAPA);
			dynStr.Append("@CBA@DESCRIPCIO_ETAPA=");
			dynStr.Append(DESCRIPCIO_ETAPA);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@ESTADO_ETAPA=");
			dynStr.Append(ESTADO_ETAPA);
			dynStr.Append("@CBA@MONTO_ETAPA=");
			dynStr.Append(IsMONTO_ETAPANull ? (object)"<NULL>" : MONTO_ETAPA);
			dynStr.Append("@CBA@REQUERIMIENTO_COBRAR=");
			dynStr.Append(REQUERIMIENTO_COBRAR);
			dynStr.Append("@CBA@COBRADO=");
			dynStr.Append(COBRADO);
			return dynStr.ToString();
		}
	} // End of CONTRATOS_DETALLESRow_Base class
} // End of namespace
