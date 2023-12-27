// <fileinfo name="PAGO_CONTRATISTASRow_Base.cs">
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
	/// The base class for <see cref="PAGO_CONTRATISTASRow"/> that 
	/// represents a record in the <c>PAGO_CONTRATISTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PAGO_CONTRATISTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PAGO_CONTRATISTASRow_Base
	{
		private decimal _id;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _monto_total;
		private bool _monto_totalNull = true;
		private decimal _moneda_id;
		private decimal _saldo_monto_adelanto_inicial;
		private bool _saldo_monto_adelanto_inicialNull = true;
		private decimal _saldo_monto_fijo;
		private bool _saldo_monto_fijoNull = true;
		private decimal _saldo_facturas;
		private bool _saldo_facturasNull = true;
		private decimal _saldo_adelantos;
		private bool _saldo_adelantosNull = true;
		private decimal _saldo_fondo_reparo;
		private bool _saldo_fondo_reparoNull = true;
		private decimal _impuesto_id;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PAGO_CONTRATISTASRow_Base"/> class.
		/// </summary>
		public PAGO_CONTRATISTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PAGO_CONTRATISTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsMONTO_TOTALNull != original.IsMONTO_TOTALNull) return true;
			if (!this.IsMONTO_TOTALNull && !original.IsMONTO_TOTALNull)
				if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsSALDO_MONTO_ADELANTO_INICIALNull != original.IsSALDO_MONTO_ADELANTO_INICIALNull) return true;
			if (!this.IsSALDO_MONTO_ADELANTO_INICIALNull && !original.IsSALDO_MONTO_ADELANTO_INICIALNull)
				if (this.SALDO_MONTO_ADELANTO_INICIAL != original.SALDO_MONTO_ADELANTO_INICIAL) return true;
			if (this.IsSALDO_MONTO_FIJONull != original.IsSALDO_MONTO_FIJONull) return true;
			if (!this.IsSALDO_MONTO_FIJONull && !original.IsSALDO_MONTO_FIJONull)
				if (this.SALDO_MONTO_FIJO != original.SALDO_MONTO_FIJO) return true;
			if (this.IsSALDO_FACTURASNull != original.IsSALDO_FACTURASNull) return true;
			if (!this.IsSALDO_FACTURASNull && !original.IsSALDO_FACTURASNull)
				if (this.SALDO_FACTURAS != original.SALDO_FACTURAS) return true;
			if (this.IsSALDO_ADELANTOSNull != original.IsSALDO_ADELANTOSNull) return true;
			if (!this.IsSALDO_ADELANTOSNull && !original.IsSALDO_ADELANTOSNull)
				if (this.SALDO_ADELANTOS != original.SALDO_ADELANTOS) return true;
			if (this.IsSALDO_FONDO_REPARONull != original.IsSALDO_FONDO_REPARONull) return true;
			if (!this.IsSALDO_FONDO_REPARONull && !original.IsSALDO_FONDO_REPARONull)
				if (this.SALDO_FONDO_REPARO != original.SALDO_FONDO_REPARO) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get
			{
				if(IsMONTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total;
			}
			set
			{
				_monto_totalNull = false;
				_monto_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTALNull
		{
			get { return _monto_totalNull; }
			set { _monto_totalNull = value; }
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
		/// Gets or sets the <c>SALDO_MONTO_ADELANTO_INICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_MONTO_ADELANTO_INICIAL</c> column value.</value>
		public decimal SALDO_MONTO_ADELANTO_INICIAL
		{
			get
			{
				if(IsSALDO_MONTO_ADELANTO_INICIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_monto_adelanto_inicial;
			}
			set
			{
				_saldo_monto_adelanto_inicialNull = false;
				_saldo_monto_adelanto_inicial = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_MONTO_ADELANTO_INICIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_MONTO_ADELANTO_INICIALNull
		{
			get { return _saldo_monto_adelanto_inicialNull; }
			set { _saldo_monto_adelanto_inicialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_MONTO_FIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_MONTO_FIJO</c> column value.</value>
		public decimal SALDO_MONTO_FIJO
		{
			get
			{
				if(IsSALDO_MONTO_FIJONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_monto_fijo;
			}
			set
			{
				_saldo_monto_fijoNull = false;
				_saldo_monto_fijo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_MONTO_FIJO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_MONTO_FIJONull
		{
			get { return _saldo_monto_fijoNull; }
			set { _saldo_monto_fijoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_FACTURAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_FACTURAS</c> column value.</value>
		public decimal SALDO_FACTURAS
		{
			get
			{
				if(IsSALDO_FACTURASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_facturas;
			}
			set
			{
				_saldo_facturasNull = false;
				_saldo_facturas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_FACTURAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_FACTURASNull
		{
			get { return _saldo_facturasNull; }
			set { _saldo_facturasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_ADELANTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_ADELANTOS</c> column value.</value>
		public decimal SALDO_ADELANTOS
		{
			get
			{
				if(IsSALDO_ADELANTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_adelantos;
			}
			set
			{
				_saldo_adelantosNull = false;
				_saldo_adelantos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_ADELANTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_ADELANTOSNull
		{
			get { return _saldo_adelantosNull; }
			set { _saldo_adelantosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_FONDO_REPARO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_FONDO_REPARO</c> column value.</value>
		public decimal SALDO_FONDO_REPARO
		{
			get
			{
				if(IsSALDO_FONDO_REPARONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_fondo_reparo;
			}
			set
			{
				_saldo_fondo_reparoNull = false;
				_saldo_fondo_reparo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_FONDO_REPARO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_FONDO_REPARONull
		{
			get { return _saldo_fondo_reparoNull; }
			set { _saldo_fondo_reparoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
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
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(IsMONTO_TOTALNull ? (object)"<NULL>" : MONTO_TOTAL);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@SALDO_MONTO_ADELANTO_INICIAL=");
			dynStr.Append(IsSALDO_MONTO_ADELANTO_INICIALNull ? (object)"<NULL>" : SALDO_MONTO_ADELANTO_INICIAL);
			dynStr.Append("@CBA@SALDO_MONTO_FIJO=");
			dynStr.Append(IsSALDO_MONTO_FIJONull ? (object)"<NULL>" : SALDO_MONTO_FIJO);
			dynStr.Append("@CBA@SALDO_FACTURAS=");
			dynStr.Append(IsSALDO_FACTURASNull ? (object)"<NULL>" : SALDO_FACTURAS);
			dynStr.Append("@CBA@SALDO_ADELANTOS=");
			dynStr.Append(IsSALDO_ADELANTOSNull ? (object)"<NULL>" : SALDO_ADELANTOS);
			dynStr.Append("@CBA@SALDO_FONDO_REPARO=");
			dynStr.Append(IsSALDO_FONDO_REPARONull ? (object)"<NULL>" : SALDO_FONDO_REPARO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			return dynStr.ToString();
		}
	} // End of PAGO_CONTRATISTASRow_Base class
} // End of namespace
