// <fileinfo name="PERSONAS_LINEA_CREDITO_ACTIVARow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> that 
	/// represents a record in the <c>PERSONAS_LINEA_CREDITO_ACTIVA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_LINEA_CREDITO_ACTIVARow_Base
	{
		private decimal _personas_linea_credito_id;
		private string _temporal;
		private string _aprobado;
		private string _utilizado;
		private decimal _monto_linea_credito;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private System.DateTime _fecha_asignacion;
		private decimal _persona_id;
		private string _nombre_completo;
		private decimal _credito_menos_debito;
		private bool _credito_menos_debitoNull = true;
		private decimal _credito_menos_debito_moneda_lc;
		private bool _credito_menos_debito_moneda_lcNull = true;
		private decimal _tot_cheq_no_deposit_ni_efectiv;
		private bool _tot_cheq_no_deposit_ni_efectivNull = true;
		private decimal _tot_cheq_no_dep_ni_efec_mon_lc;
		private bool _tot_cheq_no_dep_ni_efec_mon_lcNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow_Base"/> class.
		/// </summary>
		public PERSONAS_LINEA_CREDITO_ACTIVARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_LINEA_CREDITO_ACTIVARow_Base original)
		{
			if (this.PERSONAS_LINEA_CREDITO_ID != original.PERSONAS_LINEA_CREDITO_ID) return true;
			if (this.TEMPORAL != original.TEMPORAL) return true;
			if (this.APROBADO != original.APROBADO) return true;
			if (this.UTILIZADO != original.UTILIZADO) return true;
			if (this.MONTO_LINEA_CREDITO != original.MONTO_LINEA_CREDITO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.FECHA_ASIGNACION != original.FECHA_ASIGNACION) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.IsCREDITO_MENOS_DEBITONull != original.IsCREDITO_MENOS_DEBITONull) return true;
			if (!this.IsCREDITO_MENOS_DEBITONull && !original.IsCREDITO_MENOS_DEBITONull)
				if (this.CREDITO_MENOS_DEBITO != original.CREDITO_MENOS_DEBITO) return true;
			if (this.IsCREDITO_MENOS_DEBITO_MONEDA_LCNull != original.IsCREDITO_MENOS_DEBITO_MONEDA_LCNull) return true;
			if (!this.IsCREDITO_MENOS_DEBITO_MONEDA_LCNull && !original.IsCREDITO_MENOS_DEBITO_MONEDA_LCNull)
				if (this.CREDITO_MENOS_DEBITO_MONEDA_LC != original.CREDITO_MENOS_DEBITO_MONEDA_LC) return true;
			if (this.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull != original.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull) return true;
			if (!this.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull && !original.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull)
				if (this.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV != original.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV) return true;
			if (this.IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull != original.IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull) return true;
			if (!this.IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull && !original.IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull)
				if (this.TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC != original.TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONAS_LINEA_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONAS_LINEA_CREDITO_ID</c> column value.</value>
		public decimal PERSONAS_LINEA_CREDITO_ID
		{
			get { return _personas_linea_credito_id; }
			set { _personas_linea_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPORAL</c> column value.
		/// </summary>
		/// <value>The <c>TEMPORAL</c> column value.</value>
		public string TEMPORAL
		{
			get { return _temporal; }
			set { _temporal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBADO</c> column value.</value>
		public string APROBADO
		{
			get { return _aprobado; }
			set { _aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UTILIZADO</c> column value.</value>
		public string UTILIZADO
		{
			get { return _utilizado; }
			set { _utilizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_LINEA_CREDITO</c> column value.</value>
		public decimal MONTO_LINEA_CREDITO
		{
			get { return _monto_linea_credito; }
			set { _monto_linea_credito = value; }
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
		/// Gets or sets the <c>FECHA_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIGNACION</c> column value.</value>
		public System.DateTime FECHA_ASIGNACION
		{
			get { return _fecha_asignacion; }
			set { _fecha_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_COMPLETO</c> column value.</value>
		public string NOMBRE_COMPLETO
		{
			get { return _nombre_completo; }
			set { _nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO_MENOS_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO_MENOS_DEBITO</c> column value.</value>
		public decimal CREDITO_MENOS_DEBITO
		{
			get
			{
				if(IsCREDITO_MENOS_DEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito_menos_debito;
			}
			set
			{
				_credito_menos_debitoNull = false;
				_credito_menos_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO_MENOS_DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITO_MENOS_DEBITONull
		{
			get { return _credito_menos_debitoNull; }
			set { _credito_menos_debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO_MENOS_DEBITO_MONEDA_LC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO_MENOS_DEBITO_MONEDA_LC</c> column value.</value>
		public decimal CREDITO_MENOS_DEBITO_MONEDA_LC
		{
			get
			{
				if(IsCREDITO_MENOS_DEBITO_MONEDA_LCNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito_menos_debito_moneda_lc;
			}
			set
			{
				_credito_menos_debito_moneda_lcNull = false;
				_credito_menos_debito_moneda_lc = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO_MENOS_DEBITO_MONEDA_LC"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITO_MENOS_DEBITO_MONEDA_LCNull
		{
			get { return _credito_menos_debito_moneda_lcNull; }
			set { _credito_menos_debito_moneda_lcNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV</c> column value.</value>
		public decimal TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV
		{
			get
			{
				if(IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tot_cheq_no_deposit_ni_efectiv;
			}
			set
			{
				_tot_cheq_no_deposit_ni_efectivNull = false;
				_tot_cheq_no_deposit_ni_efectiv = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull
		{
			get { return _tot_cheq_no_deposit_ni_efectivNull; }
			set { _tot_cheq_no_deposit_ni_efectivNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC</c> column value.</value>
		public decimal TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC
		{
			get
			{
				if(IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tot_cheq_no_dep_ni_efec_mon_lc;
			}
			set
			{
				_tot_cheq_no_dep_ni_efec_mon_lcNull = false;
				_tot_cheq_no_dep_ni_efec_mon_lc = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull
		{
			get { return _tot_cheq_no_dep_ni_efec_mon_lcNull; }
			set { _tot_cheq_no_dep_ni_efec_mon_lcNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERSONAS_LINEA_CREDITO_ID=");
			dynStr.Append(PERSONAS_LINEA_CREDITO_ID);
			dynStr.Append("@CBA@TEMPORAL=");
			dynStr.Append(TEMPORAL);
			dynStr.Append("@CBA@APROBADO=");
			dynStr.Append(APROBADO);
			dynStr.Append("@CBA@UTILIZADO=");
			dynStr.Append(UTILIZADO);
			dynStr.Append("@CBA@MONTO_LINEA_CREDITO=");
			dynStr.Append(MONTO_LINEA_CREDITO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@FECHA_ASIGNACION=");
			dynStr.Append(FECHA_ASIGNACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@CREDITO_MENOS_DEBITO=");
			dynStr.Append(IsCREDITO_MENOS_DEBITONull ? (object)"<NULL>" : CREDITO_MENOS_DEBITO);
			dynStr.Append("@CBA@CREDITO_MENOS_DEBITO_MONEDA_LC=");
			dynStr.Append(IsCREDITO_MENOS_DEBITO_MONEDA_LCNull ? (object)"<NULL>" : CREDITO_MENOS_DEBITO_MONEDA_LC);
			dynStr.Append("@CBA@TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV=");
			dynStr.Append(IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull ? (object)"<NULL>" : TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV);
			dynStr.Append("@CBA@TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC=");
			dynStr.Append(IsTOT_CHEQ_NO_DEP_NI_EFEC_MON_LCNull ? (object)"<NULL>" : TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC);
			return dynStr.ToString();
		}
	} // End of PERSONAS_LINEA_CREDITO_ACTIVARow_Base class
} // End of namespace
