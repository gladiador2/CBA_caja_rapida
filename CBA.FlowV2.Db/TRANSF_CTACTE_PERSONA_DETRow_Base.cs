// <fileinfo name="TRANSF_CTACTE_PERSONA_DETRow_Base.cs">
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
	/// The base class for <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> that 
	/// represents a record in the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSF_CTACTE_PERSONA_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSF_CTACTE_PERSONA_DETRow_Base
	{
		private decimal _id;
		private decimal _transf_ctacte_persona_id;
		private decimal _ctacte_persona_orig_id;
		private decimal _monto_credito_origen;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private string _observacion;
		private decimal _ctacte_persona_dest_id;
		private bool _ctacte_persona_dest_idNull = true;
		private decimal _monto_credito_destino;
		private bool _monto_credito_destinoNull = true;
		private decimal _monto_debito_origen;
		private decimal _monto_debito_destino;
		private bool _monto_debito_destinoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSF_CTACTE_PERSONA_DETRow_Base"/> class.
		/// </summary>
		public TRANSF_CTACTE_PERSONA_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSF_CTACTE_PERSONA_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANSF_CTACTE_PERSONA_ID != original.TRANSF_CTACTE_PERSONA_ID) return true;
			if (this.CTACTE_PERSONA_ORIG_ID != original.CTACTE_PERSONA_ORIG_ID) return true;
			if (this.MONTO_CREDITO_ORIGEN != original.MONTO_CREDITO_ORIGEN) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_PERSONA_DEST_IDNull != original.IsCTACTE_PERSONA_DEST_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_DEST_IDNull && !original.IsCTACTE_PERSONA_DEST_IDNull)
				if (this.CTACTE_PERSONA_DEST_ID != original.CTACTE_PERSONA_DEST_ID) return true;
			if (this.IsMONTO_CREDITO_DESTINONull != original.IsMONTO_CREDITO_DESTINONull) return true;
			if (!this.IsMONTO_CREDITO_DESTINONull && !original.IsMONTO_CREDITO_DESTINONull)
				if (this.MONTO_CREDITO_DESTINO != original.MONTO_CREDITO_DESTINO) return true;
			if (this.MONTO_DEBITO_ORIGEN != original.MONTO_DEBITO_ORIGEN) return true;
			if (this.IsMONTO_DEBITO_DESTINONull != original.IsMONTO_DEBITO_DESTINONull) return true;
			if (!this.IsMONTO_DEBITO_DESTINONull && !original.IsMONTO_DEBITO_DESTINONull)
				if (this.MONTO_DEBITO_DESTINO != original.MONTO_DEBITO_DESTINO) return true;
			
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
		/// Gets or sets the <c>MONTO_DEBITO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DEBITO_ORIGEN</c> column value.</value>
		public decimal MONTO_DEBITO_ORIGEN
		{
			get { return _monto_debito_origen; }
			set { _monto_debito_origen = value; }
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
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_PERSONA_DEST_ID=");
			dynStr.Append(IsCTACTE_PERSONA_DEST_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_DEST_ID);
			dynStr.Append("@CBA@MONTO_CREDITO_DESTINO=");
			dynStr.Append(IsMONTO_CREDITO_DESTINONull ? (object)"<NULL>" : MONTO_CREDITO_DESTINO);
			dynStr.Append("@CBA@MONTO_DEBITO_ORIGEN=");
			dynStr.Append(MONTO_DEBITO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DEBITO_DESTINO=");
			dynStr.Append(IsMONTO_DEBITO_DESTINONull ? (object)"<NULL>" : MONTO_DEBITO_DESTINO);
			return dynStr.ToString();
		}
	} // End of TRANSF_CTACTE_PERSONA_DETRow_Base class
} // End of namespace
