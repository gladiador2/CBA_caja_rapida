// <fileinfo name="DESEM_GIROS_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>DESEM_GIROS_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEM_GIROS_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _desembolso_giro_id;
		private decimal _ctacte_giros_movimiento_id;
		private decimal _monto_origen;
		private decimal _moneda_origen_id;
		private decimal _cotizacion_moneda_origen;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;
		private decimal _giro_mov_moneda_id;
		private bool _giro_mov_moneda_idNull = true;
		private System.DateTime _ctacte_giro_mov_fecha_desemb;
		private bool _ctacte_giro_mov_fecha_desembNull = true;
		private decimal _giro_mov_saldo;
		private bool _giro_mov_saldoNull = true;
		private string _giro_mov_cuota_des;
		private string _giro_comprobante;
		private string _giro_mov_moneda_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEM_GIROS_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public DESEM_GIROS_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESEM_GIROS_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESEMBOLSO_GIRO_ID != original.DESEMBOLSO_GIRO_ID) return true;
			if (this.CTACTE_GIROS_MOVIMIENTO_ID != original.CTACTE_GIROS_MOVIMIENTO_ID) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.IsMONTO_DESTINONull != original.IsMONTO_DESTINONull) return true;
			if (!this.IsMONTO_DESTINONull && !original.IsMONTO_DESTINONull)
				if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.IsGIRO_MOV_MONEDA_IDNull != original.IsGIRO_MOV_MONEDA_IDNull) return true;
			if (!this.IsGIRO_MOV_MONEDA_IDNull && !original.IsGIRO_MOV_MONEDA_IDNull)
				if (this.GIRO_MOV_MONEDA_ID != original.GIRO_MOV_MONEDA_ID) return true;
			if (this.IsCTACTE_GIRO_MOV_FECHA_DESEMBNull != original.IsCTACTE_GIRO_MOV_FECHA_DESEMBNull) return true;
			if (!this.IsCTACTE_GIRO_MOV_FECHA_DESEMBNull && !original.IsCTACTE_GIRO_MOV_FECHA_DESEMBNull)
				if (this.CTACTE_GIRO_MOV_FECHA_DESEMB != original.CTACTE_GIRO_MOV_FECHA_DESEMB) return true;
			if (this.IsGIRO_MOV_SALDONull != original.IsGIRO_MOV_SALDONull) return true;
			if (!this.IsGIRO_MOV_SALDONull && !original.IsGIRO_MOV_SALDONull)
				if (this.GIRO_MOV_SALDO != original.GIRO_MOV_SALDO) return true;
			if (this.GIRO_MOV_CUOTA_DES != original.GIRO_MOV_CUOTA_DES) return true;
			if (this.GIRO_COMPROBANTE != original.GIRO_COMPROBANTE) return true;
			if (this.GIRO_MOV_MONEDA_NOMBRE != original.GIRO_MOV_MONEDA_NOMBRE) return true;
			
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
		/// Gets or sets the <c>DESEMBOLSO_GIRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_GIRO_ID</c> column value.</value>
		public decimal DESEMBOLSO_GIRO_ID
		{
			get { return _desembolso_giro_id; }
			set { _desembolso_giro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</value>
		public decimal CTACTE_GIROS_MOVIMIENTO_ID
		{
			get { return _ctacte_giros_movimiento_id; }
			set { _ctacte_giros_movimiento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get { return _cotizacion_moneda_origen; }
			set { _cotizacion_moneda_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get
			{
				if(IsMONTO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_destino;
			}
			set
			{
				_monto_destinoNull = false;
				_monto_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESTINONull
		{
			get { return _monto_destinoNull; }
			set { _monto_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_MOV_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIRO_MOV_MONEDA_ID</c> column value.</value>
		public decimal GIRO_MOV_MONEDA_ID
		{
			get
			{
				if(IsGIRO_MOV_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _giro_mov_moneda_id;
			}
			set
			{
				_giro_mov_moneda_idNull = false;
				_giro_mov_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GIRO_MOV_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGIRO_MOV_MONEDA_IDNull
		{
			get { return _giro_mov_moneda_idNull; }
			set { _giro_mov_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_GIRO_MOV_FECHA_DESEMB</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_GIRO_MOV_FECHA_DESEMB</c> column value.</value>
		public System.DateTime CTACTE_GIRO_MOV_FECHA_DESEMB
		{
			get
			{
				if(IsCTACTE_GIRO_MOV_FECHA_DESEMBNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_giro_mov_fecha_desemb;
			}
			set
			{
				_ctacte_giro_mov_fecha_desembNull = false;
				_ctacte_giro_mov_fecha_desemb = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_GIRO_MOV_FECHA_DESEMB"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_GIRO_MOV_FECHA_DESEMBNull
		{
			get { return _ctacte_giro_mov_fecha_desembNull; }
			set { _ctacte_giro_mov_fecha_desembNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_MOV_SALDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIRO_MOV_SALDO</c> column value.</value>
		public decimal GIRO_MOV_SALDO
		{
			get
			{
				if(IsGIRO_MOV_SALDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _giro_mov_saldo;
			}
			set
			{
				_giro_mov_saldoNull = false;
				_giro_mov_saldo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GIRO_MOV_SALDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGIRO_MOV_SALDONull
		{
			get { return _giro_mov_saldoNull; }
			set { _giro_mov_saldoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_MOV_CUOTA_DES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIRO_MOV_CUOTA_DES</c> column value.</value>
		public string GIRO_MOV_CUOTA_DES
		{
			get { return _giro_mov_cuota_des; }
			set { _giro_mov_cuota_des = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIRO_COMPROBANTE</c> column value.</value>
		public string GIRO_COMPROBANTE
		{
			get { return _giro_comprobante; }
			set { _giro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_MOV_MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>GIRO_MOV_MONEDA_NOMBRE</c> column value.</value>
		public string GIRO_MOV_MONEDA_NOMBRE
		{
			get { return _giro_mov_moneda_nombre; }
			set { _giro_mov_moneda_nombre = value; }
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
			dynStr.Append("@CBA@DESEMBOLSO_GIRO_ID=");
			dynStr.Append(DESEMBOLSO_GIRO_ID);
			dynStr.Append("@CBA@CTACTE_GIROS_MOVIMIENTO_ID=");
			dynStr.Append(CTACTE_GIROS_MOVIMIENTO_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			dynStr.Append("@CBA@GIRO_MOV_MONEDA_ID=");
			dynStr.Append(IsGIRO_MOV_MONEDA_IDNull ? (object)"<NULL>" : GIRO_MOV_MONEDA_ID);
			dynStr.Append("@CBA@CTACTE_GIRO_MOV_FECHA_DESEMB=");
			dynStr.Append(IsCTACTE_GIRO_MOV_FECHA_DESEMBNull ? (object)"<NULL>" : CTACTE_GIRO_MOV_FECHA_DESEMB);
			dynStr.Append("@CBA@GIRO_MOV_SALDO=");
			dynStr.Append(IsGIRO_MOV_SALDONull ? (object)"<NULL>" : GIRO_MOV_SALDO);
			dynStr.Append("@CBA@GIRO_MOV_CUOTA_DES=");
			dynStr.Append(GIRO_MOV_CUOTA_DES);
			dynStr.Append("@CBA@GIRO_COMPROBANTE=");
			dynStr.Append(GIRO_COMPROBANTE);
			dynStr.Append("@CBA@GIRO_MOV_MONEDA_NOMBRE=");
			dynStr.Append(GIRO_MOV_MONEDA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of DESEM_GIROS_DET_INFO_COMPLRow_Base class
} // End of namespace
