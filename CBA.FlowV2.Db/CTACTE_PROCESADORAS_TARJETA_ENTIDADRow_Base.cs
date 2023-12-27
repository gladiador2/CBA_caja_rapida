// <fileinfo name="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/> that 
	/// represents a record in the <c>CTACTE_PROCESADORAS_TARJETA_ENTIDAD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private string _estado;
		private string _cred_comision_pos_dia;
		private string _deb_comision_pos_dia;
		private string _cred_comision_sob_imp_bruto;
		private string _deb_comision_sob_imp_bruto;
		private decimal _cred_lunes_horas;
		private decimal _cred_martes_horas;
		private decimal _cred_miercoles_horas;
		private decimal _cred_jueves_horas;
		private decimal _cred_viernes_horas;
		private decimal _cred_sabado_horas;
		private decimal _cred_domingo_horas;
		private decimal _deb_lunes_horas;
		private decimal _deb_martes_horas;
		private decimal _deb_miercoles_horas;
		private decimal _deb_jueves_horas;
		private decimal _deb_viernes_horas;
		private decimal _deb_sabado_horas;
		private decimal _deb_domingo_horas;
		private string _controla_dia_habil;
		private string _controla_feriado_bancario;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base"/> class.
		/// </summary>
		public CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CRED_COMISION_POS_DIA != original.CRED_COMISION_POS_DIA) return true;
			if (this.DEB_COMISION_POS_DIA != original.DEB_COMISION_POS_DIA) return true;
			if (this.CRED_COMISION_SOB_IMP_BRUTO != original.CRED_COMISION_SOB_IMP_BRUTO) return true;
			if (this.DEB_COMISION_SOB_IMP_BRUTO != original.DEB_COMISION_SOB_IMP_BRUTO) return true;
			if (this.CRED_LUNES_HORAS != original.CRED_LUNES_HORAS) return true;
			if (this.CRED_MARTES_HORAS != original.CRED_MARTES_HORAS) return true;
			if (this.CRED_MIERCOLES_HORAS != original.CRED_MIERCOLES_HORAS) return true;
			if (this.CRED_JUEVES_HORAS != original.CRED_JUEVES_HORAS) return true;
			if (this.CRED_VIERNES_HORAS != original.CRED_VIERNES_HORAS) return true;
			if (this.CRED_SABADO_HORAS != original.CRED_SABADO_HORAS) return true;
			if (this.CRED_DOMINGO_HORAS != original.CRED_DOMINGO_HORAS) return true;
			if (this.DEB_LUNES_HORAS != original.DEB_LUNES_HORAS) return true;
			if (this.DEB_MARTES_HORAS != original.DEB_MARTES_HORAS) return true;
			if (this.DEB_MIERCOLES_HORAS != original.DEB_MIERCOLES_HORAS) return true;
			if (this.DEB_JUEVES_HORAS != original.DEB_JUEVES_HORAS) return true;
			if (this.DEB_VIERNES_HORAS != original.DEB_VIERNES_HORAS) return true;
			if (this.DEB_SABADO_HORAS != original.DEB_SABADO_HORAS) return true;
			if (this.DEB_DOMINGO_HORAS != original.DEB_DOMINGO_HORAS) return true;
			if (this.CONTROLA_DIA_HABIL != original.CONTROLA_DIA_HABIL) return true;
			if (this.CONTROLA_FERIADO_BANCARIO != original.CONTROLA_FERIADO_BANCARIO) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
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
		/// Gets or sets the <c>CRED_COMISION_POS_DIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CRED_COMISION_POS_DIA</c> column value.</value>
		public string CRED_COMISION_POS_DIA
		{
			get { return _cred_comision_pos_dia; }
			set { _cred_comision_pos_dia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_COMISION_POS_DIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEB_COMISION_POS_DIA</c> column value.</value>
		public string DEB_COMISION_POS_DIA
		{
			get { return _deb_comision_pos_dia; }
			set { _deb_comision_pos_dia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_COMISION_SOB_IMP_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CRED_COMISION_SOB_IMP_BRUTO</c> column value.</value>
		public string CRED_COMISION_SOB_IMP_BRUTO
		{
			get { return _cred_comision_sob_imp_bruto; }
			set { _cred_comision_sob_imp_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_COMISION_SOB_IMP_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEB_COMISION_SOB_IMP_BRUTO</c> column value.</value>
		public string DEB_COMISION_SOB_IMP_BRUTO
		{
			get { return _deb_comision_sob_imp_bruto; }
			set { _deb_comision_sob_imp_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_LUNES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_LUNES_HORAS</c> column value.</value>
		public decimal CRED_LUNES_HORAS
		{
			get { return _cred_lunes_horas; }
			set { _cred_lunes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_MARTES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_MARTES_HORAS</c> column value.</value>
		public decimal CRED_MARTES_HORAS
		{
			get { return _cred_martes_horas; }
			set { _cred_martes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_MIERCOLES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_MIERCOLES_HORAS</c> column value.</value>
		public decimal CRED_MIERCOLES_HORAS
		{
			get { return _cred_miercoles_horas; }
			set { _cred_miercoles_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_JUEVES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_JUEVES_HORAS</c> column value.</value>
		public decimal CRED_JUEVES_HORAS
		{
			get { return _cred_jueves_horas; }
			set { _cred_jueves_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_VIERNES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_VIERNES_HORAS</c> column value.</value>
		public decimal CRED_VIERNES_HORAS
		{
			get { return _cred_viernes_horas; }
			set { _cred_viernes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_SABADO_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_SABADO_HORAS</c> column value.</value>
		public decimal CRED_SABADO_HORAS
		{
			get { return _cred_sabado_horas; }
			set { _cred_sabado_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CRED_DOMINGO_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CRED_DOMINGO_HORAS</c> column value.</value>
		public decimal CRED_DOMINGO_HORAS
		{
			get { return _cred_domingo_horas; }
			set { _cred_domingo_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_LUNES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_LUNES_HORAS</c> column value.</value>
		public decimal DEB_LUNES_HORAS
		{
			get { return _deb_lunes_horas; }
			set { _deb_lunes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_MARTES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_MARTES_HORAS</c> column value.</value>
		public decimal DEB_MARTES_HORAS
		{
			get { return _deb_martes_horas; }
			set { _deb_martes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_MIERCOLES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_MIERCOLES_HORAS</c> column value.</value>
		public decimal DEB_MIERCOLES_HORAS
		{
			get { return _deb_miercoles_horas; }
			set { _deb_miercoles_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_JUEVES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_JUEVES_HORAS</c> column value.</value>
		public decimal DEB_JUEVES_HORAS
		{
			get { return _deb_jueves_horas; }
			set { _deb_jueves_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_VIERNES_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_VIERNES_HORAS</c> column value.</value>
		public decimal DEB_VIERNES_HORAS
		{
			get { return _deb_viernes_horas; }
			set { _deb_viernes_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_SABADO_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_SABADO_HORAS</c> column value.</value>
		public decimal DEB_SABADO_HORAS
		{
			get { return _deb_sabado_horas; }
			set { _deb_sabado_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEB_DOMINGO_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>DEB_DOMINGO_HORAS</c> column value.</value>
		public decimal DEB_DOMINGO_HORAS
		{
			get { return _deb_domingo_horas; }
			set { _deb_domingo_horas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROLA_DIA_HABIL</c> column value.
		/// </summary>
		/// <value>The <c>CONTROLA_DIA_HABIL</c> column value.</value>
		public string CONTROLA_DIA_HABIL
		{
			get { return _controla_dia_habil; }
			set { _controla_dia_habil = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROLA_FERIADO_BANCARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTROLA_FERIADO_BANCARIO</c> column value.</value>
		public string CONTROLA_FERIADO_BANCARIO
		{
			get { return _controla_feriado_bancario; }
			set { _controla_feriado_bancario = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CRED_COMISION_POS_DIA=");
			dynStr.Append(CRED_COMISION_POS_DIA);
			dynStr.Append("@CBA@DEB_COMISION_POS_DIA=");
			dynStr.Append(DEB_COMISION_POS_DIA);
			dynStr.Append("@CBA@CRED_COMISION_SOB_IMP_BRUTO=");
			dynStr.Append(CRED_COMISION_SOB_IMP_BRUTO);
			dynStr.Append("@CBA@DEB_COMISION_SOB_IMP_BRUTO=");
			dynStr.Append(DEB_COMISION_SOB_IMP_BRUTO);
			dynStr.Append("@CBA@CRED_LUNES_HORAS=");
			dynStr.Append(CRED_LUNES_HORAS);
			dynStr.Append("@CBA@CRED_MARTES_HORAS=");
			dynStr.Append(CRED_MARTES_HORAS);
			dynStr.Append("@CBA@CRED_MIERCOLES_HORAS=");
			dynStr.Append(CRED_MIERCOLES_HORAS);
			dynStr.Append("@CBA@CRED_JUEVES_HORAS=");
			dynStr.Append(CRED_JUEVES_HORAS);
			dynStr.Append("@CBA@CRED_VIERNES_HORAS=");
			dynStr.Append(CRED_VIERNES_HORAS);
			dynStr.Append("@CBA@CRED_SABADO_HORAS=");
			dynStr.Append(CRED_SABADO_HORAS);
			dynStr.Append("@CBA@CRED_DOMINGO_HORAS=");
			dynStr.Append(CRED_DOMINGO_HORAS);
			dynStr.Append("@CBA@DEB_LUNES_HORAS=");
			dynStr.Append(DEB_LUNES_HORAS);
			dynStr.Append("@CBA@DEB_MARTES_HORAS=");
			dynStr.Append(DEB_MARTES_HORAS);
			dynStr.Append("@CBA@DEB_MIERCOLES_HORAS=");
			dynStr.Append(DEB_MIERCOLES_HORAS);
			dynStr.Append("@CBA@DEB_JUEVES_HORAS=");
			dynStr.Append(DEB_JUEVES_HORAS);
			dynStr.Append("@CBA@DEB_VIERNES_HORAS=");
			dynStr.Append(DEB_VIERNES_HORAS);
			dynStr.Append("@CBA@DEB_SABADO_HORAS=");
			dynStr.Append(DEB_SABADO_HORAS);
			dynStr.Append("@CBA@DEB_DOMINGO_HORAS=");
			dynStr.Append(DEB_DOMINGO_HORAS);
			dynStr.Append("@CBA@CONTROLA_DIA_HABIL=");
			dynStr.Append(CONTROLA_DIA_HABIL);
			dynStr.Append("@CBA@CONTROLA_FERIADO_BANCARIO=");
			dynStr.Append(CONTROLA_FERIADO_BANCARIO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PROCESADORAS_TARJETA_ENTIDADRow_Base class
} // End of namespace
