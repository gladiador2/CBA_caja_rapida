// <fileinfo name="TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> that 
	/// represents a record in the <c>TRAN_CTACTE_PERS_DET_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _transf_ctacte_persona_id;
		private decimal _ctacte_persona_orig_id;
		private decimal _monto_credito_origen;
		private decimal _monto_debito_origen;
		private decimal _moneda_origen_id;
		private string _moneda_origen_nombre;
		private string _moneda_origen_simbolo;
		private string _observacion;
		private decimal _ctacte_persona_dest_id;
		private bool _ctacte_persona_dest_idNull = true;
		private decimal _monto_credito_destino;
		private bool _monto_credito_destinoNull = true;
		private decimal _monto_debito_destino;
		private bool _monto_debito_destinoNull = true;
		private decimal _moneda_destino_id;
		private string _moneda_destino_nombre;
		private string _moenda_destino_simbolo;
		private decimal _cotizacion;
		private string _observacion_cuenta_origen;
		private System.DateTime _vencimiento_cuenta_origen;
		private bool _vencimiento_cuenta_origenNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base"/> class.
		/// </summary>
		public TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANSF_CTACTE_PERSONA_ID != original.TRANSF_CTACTE_PERSONA_ID) return true;
			if (this.CTACTE_PERSONA_ORIG_ID != original.CTACTE_PERSONA_ORIG_ID) return true;
			if (this.MONTO_CREDITO_ORIGEN != original.MONTO_CREDITO_ORIGEN) return true;
			if (this.MONTO_DEBITO_ORIGEN != original.MONTO_DEBITO_ORIGEN) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_ORIGEN_NOMBRE != original.MONEDA_ORIGEN_NOMBRE) return true;
			if (this.MONEDA_ORIGEN_SIMBOLO != original.MONEDA_ORIGEN_SIMBOLO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_PERSONA_DEST_IDNull != original.IsCTACTE_PERSONA_DEST_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_DEST_IDNull && !original.IsCTACTE_PERSONA_DEST_IDNull)
				if (this.CTACTE_PERSONA_DEST_ID != original.CTACTE_PERSONA_DEST_ID) return true;
			if (this.IsMONTO_CREDITO_DESTINONull != original.IsMONTO_CREDITO_DESTINONull) return true;
			if (!this.IsMONTO_CREDITO_DESTINONull && !original.IsMONTO_CREDITO_DESTINONull)
				if (this.MONTO_CREDITO_DESTINO != original.MONTO_CREDITO_DESTINO) return true;
			if (this.IsMONTO_DEBITO_DESTINONull != original.IsMONTO_DEBITO_DESTINONull) return true;
			if (!this.IsMONTO_DEBITO_DESTINONull && !original.IsMONTO_DEBITO_DESTINONull)
				if (this.MONTO_DEBITO_DESTINO != original.MONTO_DEBITO_DESTINO) return true;
			if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.MONEDA_DESTINO_NOMBRE != original.MONEDA_DESTINO_NOMBRE) return true;
			if (this.MOENDA_DESTINO_SIMBOLO != original.MOENDA_DESTINO_SIMBOLO) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION_CUENTA_ORIGEN != original.OBSERVACION_CUENTA_ORIGEN) return true;
			if (this.IsVENCIMIENTO_CUENTA_ORIGENNull != original.IsVENCIMIENTO_CUENTA_ORIGENNull) return true;
			if (!this.IsVENCIMIENTO_CUENTA_ORIGENNull && !original.IsVENCIMIENTO_CUENTA_ORIGENNull)
				if (this.VENCIMIENTO_CUENTA_ORIGEN != original.VENCIMIENTO_CUENTA_ORIGEN) return true;
			
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
		/// Gets or sets the <c>TRANSF_CTACTE_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</value>
		public decimal TRANSF_CTACTE_PERSONA_ID
		{
			get { return _transf_ctacte_persona_id; }
			set { _transf_ctacte_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ORIG_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ORIG_ID
		{
			get { return _ctacte_persona_orig_id; }
			set { _ctacte_persona_orig_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CREDITO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CREDITO_ORIGEN</c> column value.</value>
		public decimal MONTO_CREDITO_ORIGEN
		{
			get { return _monto_credito_origen; }
			set { _monto_credito_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DEBITO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DEBITO_ORIGEN</c> column value.</value>
		public decimal MONTO_DEBITO_ORIGEN
		{
			get { return _monto_debito_origen; }
			set { _monto_debito_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_NOMBRE</c> column value.</value>
		public string MONEDA_ORIGEN_NOMBRE
		{
			get { return _moneda_origen_nombre; }
			set { _moneda_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_SIMBOLO</c> column value.</value>
		public string MONEDA_ORIGEN_SIMBOLO
		{
			get { return _moneda_origen_simbolo; }
			set { _moneda_origen_simbolo = value; }
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
		/// Gets or sets the <c>CTACTE_PERSONA_DEST_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_DEST_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_DEST_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_DEST_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_dest_id;
			}
			set
			{
				_ctacte_persona_dest_idNull = false;
				_ctacte_persona_dest_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_DEST_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_DEST_IDNull
		{
			get { return _ctacte_persona_dest_idNull; }
			set { _ctacte_persona_dest_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CREDITO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CREDITO_DESTINO</c> column value.</value>
		public decimal MONTO_CREDITO_DESTINO
		{
			get
			{
				if(IsMONTO_CREDITO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_credito_destino;
			}
			set
			{
				_monto_credito_destinoNull = false;
				_monto_credito_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CREDITO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CREDITO_DESTINONull
		{
			get { return _monto_credito_destinoNull; }
			set { _monto_credito_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DEBITO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DEBITO_DESTINO</c> column value.</value>
		public decimal MONTO_DEBITO_DESTINO
		{
			get
			{
				if(IsMONTO_DEBITO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_debito_destino;
			}
			set
			{
				_monto_debito_destinoNull = false;
				_monto_debito_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DEBITO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DEBITO_DESTINONull
		{
			get { return _monto_debito_destinoNull; }
			set { _monto_debito_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get { return _moneda_destino_id; }
			set { _moneda_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_NOMBRE</c> column value.</value>
		public string MONEDA_DESTINO_NOMBRE
		{
			get { return _moneda_destino_nombre; }
			set { _moneda_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOENDA_DESTINO_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MOENDA_DESTINO_SIMBOLO</c> column value.</value>
		public string MOENDA_DESTINO_SIMBOLO
		{
			get { return _moenda_destino_simbolo; }
			set { _moenda_destino_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_CUENTA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_CUENTA_ORIGEN</c> column value.</value>
		public string OBSERVACION_CUENTA_ORIGEN
		{
			get { return _observacion_cuenta_origen; }
			set { _observacion_cuenta_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENCIMIENTO_CUENTA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENCIMIENTO_CUENTA_ORIGEN</c> column value.</value>
		public System.DateTime VENCIMIENTO_CUENTA_ORIGEN
		{
			get
			{
				if(IsVENCIMIENTO_CUENTA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vencimiento_cuenta_origen;
			}
			set
			{
				_vencimiento_cuenta_origenNull = false;
				_vencimiento_cuenta_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENCIMIENTO_CUENTA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENCIMIENTO_CUENTA_ORIGENNull
		{
			get { return _vencimiento_cuenta_origenNull; }
			set { _vencimiento_cuenta_origenNull = value; }
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
			dynStr.Append("@CBA@TRANSF_CTACTE_PERSONA_ID=");
			dynStr.Append(TRANSF_CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ORIG_ID=");
			dynStr.Append(CTACTE_PERSONA_ORIG_ID);
			dynStr.Append("@CBA@MONTO_CREDITO_ORIGEN=");
			dynStr.Append(MONTO_CREDITO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DEBITO_ORIGEN=");
			dynStr.Append(MONTO_DEBITO_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_NOMBRE=");
			dynStr.Append(MONEDA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ORIGEN_SIMBOLO=");
			dynStr.Append(MONEDA_ORIGEN_SIMBOLO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_PERSONA_DEST_ID=");
			dynStr.Append(IsCTACTE_PERSONA_DEST_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_DEST_ID);
			dynStr.Append("@CBA@MONTO_CREDITO_DESTINO=");
			dynStr.Append(IsMONTO_CREDITO_DESTINONull ? (object)"<NULL>" : MONTO_CREDITO_DESTINO);
			dynStr.Append("@CBA@MONTO_DEBITO_DESTINO=");
			dynStr.Append(IsMONTO_DEBITO_DESTINONull ? (object)"<NULL>" : MONTO_DEBITO_DESTINO);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@MONEDA_DESTINO_NOMBRE=");
			dynStr.Append(MONEDA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@MOENDA_DESTINO_SIMBOLO=");
			dynStr.Append(MOENDA_DESTINO_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@OBSERVACION_CUENTA_ORIGEN=");
			dynStr.Append(OBSERVACION_CUENTA_ORIGEN);
			dynStr.Append("@CBA@VENCIMIENTO_CUENTA_ORIGEN=");
			dynStr.Append(IsVENCIMIENTO_CUENTA_ORIGENNull ? (object)"<NULL>" : VENCIMIENTO_CUENTA_ORIGEN);
			return dynStr.ToString();
		}
	} // End of TRAN_CTACTE_PERS_DET_INF_COMPLRow_Base class
} // End of namespace
