// <fileinfo name="CTACTE_GIROS_MOVIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> that 
	/// represents a record in the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_GIROS_MOVIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _ctacte_giro_id;
		private bool _ctacte_giro_idNull = true;
		private System.DateTime _fecha_insercion;
		private bool _fecha_insercionNull = true;
		private System.DateTime _fecha_desembolso;
		private bool _fecha_desembolsoNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _credito;
		private bool _creditoNull = true;
		private decimal _debito;
		private bool _debitoNull = true;
		private decimal _ctacte_giro_relacionado_id;
		private bool _ctacte_giro_relacionado_idNull = true;
		private decimal _nro_cuota;
		private bool _nro_cuotaNull = true;
		private decimal _total_cuotas;
		private bool _total_cuotasNull = true;
		private decimal _desembolso_giro_det_id;
		private bool _desembolso_giro_det_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROS_MOVIMIENTOSRow_Base"/> class.
		/// </summary>
		public CTACTE_GIROS_MOVIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_GIROS_MOVIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_GIRO_IDNull != original.IsCTACTE_GIRO_IDNull) return true;
			if (!this.IsCTACTE_GIRO_IDNull && !original.IsCTACTE_GIRO_IDNull)
				if (this.CTACTE_GIRO_ID != original.CTACTE_GIRO_ID) return true;
			if (this.IsFECHA_INSERCIONNull != original.IsFECHA_INSERCIONNull) return true;
			if (!this.IsFECHA_INSERCIONNull && !original.IsFECHA_INSERCIONNull)
				if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.IsFECHA_DESEMBOLSONull != original.IsFECHA_DESEMBOLSONull) return true;
			if (!this.IsFECHA_DESEMBOLSONull && !original.IsFECHA_DESEMBOLSONull)
				if (this.FECHA_DESEMBOLSO != original.FECHA_DESEMBOLSO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsCREDITONull != original.IsCREDITONull) return true;
			if (!this.IsCREDITONull && !original.IsCREDITONull)
				if (this.CREDITO != original.CREDITO) return true;
			if (this.IsDEBITONull != original.IsDEBITONull) return true;
			if (!this.IsDEBITONull && !original.IsDEBITONull)
				if (this.DEBITO != original.DEBITO) return true;
			if (this.IsCTACTE_GIRO_RELACIONADO_IDNull != original.IsCTACTE_GIRO_RELACIONADO_IDNull) return true;
			if (!this.IsCTACTE_GIRO_RELACIONADO_IDNull && !original.IsCTACTE_GIRO_RELACIONADO_IDNull)
				if (this.CTACTE_GIRO_RELACIONADO_ID != original.CTACTE_GIRO_RELACIONADO_ID) return true;
			if (this.IsNRO_CUOTANull != original.IsNRO_CUOTANull) return true;
			if (!this.IsNRO_CUOTANull && !original.IsNRO_CUOTANull)
				if (this.NRO_CUOTA != original.NRO_CUOTA) return true;
			if (this.IsTOTAL_CUOTASNull != original.IsTOTAL_CUOTASNull) return true;
			if (!this.IsTOTAL_CUOTASNull && !original.IsTOTAL_CUOTASNull)
				if (this.TOTAL_CUOTAS != original.TOTAL_CUOTAS) return true;
			if (this.IsDESEMBOLSO_GIRO_DET_IDNull != original.IsDESEMBOLSO_GIRO_DET_IDNull) return true;
			if (!this.IsDESEMBOLSO_GIRO_DET_IDNull && !original.IsDESEMBOLSO_GIRO_DET_IDNull)
				if (this.DESEMBOLSO_GIRO_DET_ID != original.DESEMBOLSO_GIRO_DET_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_GIRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_GIRO_ID</c> column value.</value>
		public decimal CTACTE_GIRO_ID
		{
			get
			{
				if(IsCTACTE_GIRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_giro_id;
			}
			set
			{
				_ctacte_giro_idNull = false;
				_ctacte_giro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_GIRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_GIRO_IDNull
		{
			get { return _ctacte_giro_idNull; }
			set { _ctacte_giro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get
			{
				if(IsFECHA_INSERCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_insercion;
			}
			set
			{
				_fecha_insercionNull = false;
				_fecha_insercion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INSERCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INSERCIONNull
		{
			get { return _fecha_insercionNull; }
			set { _fecha_insercionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO</c> column value.</value>
		public System.DateTime FECHA_DESEMBOLSO
		{
			get
			{
				if(IsFECHA_DESEMBOLSONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso;
			}
			set
			{
				_fecha_desembolsoNull = false;
				_fecha_desembolso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSONull
		{
			get { return _fecha_desembolsoNull; }
			set { _fecha_desembolsoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO</c> column value.</value>
		public decimal CREDITO
		{
			get
			{
				if(IsCREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito;
			}
			set
			{
				_creditoNull = false;
				_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITONull
		{
			get { return _creditoNull; }
			set { _creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get
			{
				if(IsDEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debito;
			}
			set
			{
				_debitoNull = false;
				_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBITONull
		{
			get { return _debitoNull; }
			set { _debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</value>
		public decimal CTACTE_GIRO_RELACIONADO_ID
		{
			get
			{
				if(IsCTACTE_GIRO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_giro_relacionado_id;
			}
			set
			{
				_ctacte_giro_relacionado_idNull = false;
				_ctacte_giro_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_GIRO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_GIRO_RELACIONADO_IDNull
		{
			get { return _ctacte_giro_relacionado_idNull; }
			set { _ctacte_giro_relacionado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CUOTA</c> column value.</value>
		public decimal NRO_CUOTA
		{
			get
			{
				if(IsNRO_CUOTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_cuota;
			}
			set
			{
				_nro_cuotaNull = false;
				_nro_cuota = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_CUOTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_CUOTANull
		{
			get { return _nro_cuotaNull; }
			set { _nro_cuotaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_CUOTAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_CUOTAS</c> column value.</value>
		public decimal TOTAL_CUOTAS
		{
			get
			{
				if(IsTOTAL_CUOTASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_cuotas;
			}
			set
			{
				_total_cuotasNull = false;
				_total_cuotas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_CUOTAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_CUOTASNull
		{
			get { return _total_cuotasNull; }
			set { _total_cuotasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSO_GIRO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</value>
		public decimal DESEMBOLSO_GIRO_DET_ID
		{
			get
			{
				if(IsDESEMBOLSO_GIRO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desembolso_giro_det_id;
			}
			set
			{
				_desembolso_giro_det_idNull = false;
				_desembolso_giro_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESEMBOLSO_GIRO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESEMBOLSO_GIRO_DET_IDNull
		{
			get { return _desembolso_giro_det_idNull; }
			set { _desembolso_giro_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
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
			dynStr.Append("@CBA@CTACTE_GIRO_ID=");
			dynStr.Append(IsCTACTE_GIRO_IDNull ? (object)"<NULL>" : CTACTE_GIRO_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(IsFECHA_INSERCIONNull ? (object)"<NULL>" : FECHA_INSERCION);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO=");
			dynStr.Append(IsFECHA_DESEMBOLSONull ? (object)"<NULL>" : FECHA_DESEMBOLSO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(IsCREDITONull ? (object)"<NULL>" : CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(IsDEBITONull ? (object)"<NULL>" : DEBITO);
			dynStr.Append("@CBA@CTACTE_GIRO_RELACIONADO_ID=");
			dynStr.Append(IsCTACTE_GIRO_RELACIONADO_IDNull ? (object)"<NULL>" : CTACTE_GIRO_RELACIONADO_ID);
			dynStr.Append("@CBA@NRO_CUOTA=");
			dynStr.Append(IsNRO_CUOTANull ? (object)"<NULL>" : NRO_CUOTA);
			dynStr.Append("@CBA@TOTAL_CUOTAS=");
			dynStr.Append(IsTOTAL_CUOTASNull ? (object)"<NULL>" : TOTAL_CUOTAS);
			dynStr.Append("@CBA@DESEMBOLSO_GIRO_DET_ID=");
			dynStr.Append(IsDESEMBOLSO_GIRO_DET_IDNull ? (object)"<NULL>" : DESEMBOLSO_GIRO_DET_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_GIROS_MOVIMIENTOSRow_Base class
} // End of namespace
