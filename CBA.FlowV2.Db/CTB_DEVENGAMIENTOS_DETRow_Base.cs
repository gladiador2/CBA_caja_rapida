// <fileinfo name="CTB_DEVENGAMIENTOS_DETRow_Base.cs">
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
	/// The base class for <see cref="CTB_DEVENGAMIENTOS_DETRow"/> that 
	/// represents a record in the <c>CTB_DEVENGAMIENTOS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_DEVENGAMIENTOS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_DEVENGAMIENTOS_DETRow_Base
	{
		private decimal _id;
		private decimal _ctb_devengamiento_id;
		private decimal _calendario_pagos_cr_pers_id;
		private decimal _a_devengar_vigente;
		private decimal _a_devengar_vigente_aum;
		private decimal _a_devengar_vigente_dis;
		private decimal _a_devengar_vencido;
		private decimal _a_devengar_vencido_aum;
		private decimal _a_devengar_vencido_dis;
		private decimal _devengado;
		private decimal _devengado_aum;
		private decimal _devengado_dis;
		private decimal _en_suspenso;
		private decimal _en_suspenso_aum;
		private decimal _en_suspenso_dis;
		private decimal _capital_a_cobrar_vigente;
		private decimal _capital_a_cobrar_vigente_aum;
		private decimal _capital_a_cobrar_vigente_dis;
		private decimal _capital_a_cobrar_vencido;
		private decimal _capital_a_cobrar_vencido_aum;
		private decimal _capital_a_cobrar_vencido_dis;
		private decimal _interes_a_cobrar_vigente;
		private decimal _interes_a_cobrar_vigente_aum;
		private decimal _interes_a_cobrar_vigente_dis;
		private decimal _interes_a_cobrar_vencido;
		private decimal _interes_a_cobrar_vencido_aum;
		private decimal _interes_a_cobrar_vencido_dis;
		private decimal _capital_vencido_cobrado;
		private decimal _interes_vencido_cobrado;
		private string _estado;
		private decimal _cantidad_dias_devengados;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_DEVENGAMIENTOS_DETRow_Base"/> class.
		/// </summary>
		public CTB_DEVENGAMIENTOS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_DEVENGAMIENTOS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_DEVENGAMIENTO_ID != original.CTB_DEVENGAMIENTO_ID) return true;
			if (this.CALENDARIO_PAGOS_CR_PERS_ID != original.CALENDARIO_PAGOS_CR_PERS_ID) return true;
			if (this.A_DEVENGAR_VIGENTE != original.A_DEVENGAR_VIGENTE) return true;
			if (this.A_DEVENGAR_VIGENTE_AUM != original.A_DEVENGAR_VIGENTE_AUM) return true;
			if (this.A_DEVENGAR_VIGENTE_DIS != original.A_DEVENGAR_VIGENTE_DIS) return true;
			if (this.A_DEVENGAR_VENCIDO != original.A_DEVENGAR_VENCIDO) return true;
			if (this.A_DEVENGAR_VENCIDO_AUM != original.A_DEVENGAR_VENCIDO_AUM) return true;
			if (this.A_DEVENGAR_VENCIDO_DIS != original.A_DEVENGAR_VENCIDO_DIS) return true;
			if (this.DEVENGADO != original.DEVENGADO) return true;
			if (this.DEVENGADO_AUM != original.DEVENGADO_AUM) return true;
			if (this.DEVENGADO_DIS != original.DEVENGADO_DIS) return true;
			if (this.EN_SUSPENSO != original.EN_SUSPENSO) return true;
			if (this.EN_SUSPENSO_AUM != original.EN_SUSPENSO_AUM) return true;
			if (this.EN_SUSPENSO_DIS != original.EN_SUSPENSO_DIS) return true;
			if (this.CAPITAL_A_COBRAR_VIGENTE != original.CAPITAL_A_COBRAR_VIGENTE) return true;
			if (this.CAPITAL_A_COBRAR_VIGENTE_AUM != original.CAPITAL_A_COBRAR_VIGENTE_AUM) return true;
			if (this.CAPITAL_A_COBRAR_VIGENTE_DIS != original.CAPITAL_A_COBRAR_VIGENTE_DIS) return true;
			if (this.CAPITAL_A_COBRAR_VENCIDO != original.CAPITAL_A_COBRAR_VENCIDO) return true;
			if (this.CAPITAL_A_COBRAR_VENCIDO_AUM != original.CAPITAL_A_COBRAR_VENCIDO_AUM) return true;
			if (this.CAPITAL_A_COBRAR_VENCIDO_DIS != original.CAPITAL_A_COBRAR_VENCIDO_DIS) return true;
			if (this.INTERES_A_COBRAR_VIGENTE != original.INTERES_A_COBRAR_VIGENTE) return true;
			if (this.INTERES_A_COBRAR_VIGENTE_AUM != original.INTERES_A_COBRAR_VIGENTE_AUM) return true;
			if (this.INTERES_A_COBRAR_VIGENTE_DIS != original.INTERES_A_COBRAR_VIGENTE_DIS) return true;
			if (this.INTERES_A_COBRAR_VENCIDO != original.INTERES_A_COBRAR_VENCIDO) return true;
			if (this.INTERES_A_COBRAR_VENCIDO_AUM != original.INTERES_A_COBRAR_VENCIDO_AUM) return true;
			if (this.INTERES_A_COBRAR_VENCIDO_DIS != original.INTERES_A_COBRAR_VENCIDO_DIS) return true;
			if (this.CAPITAL_VENCIDO_COBRADO != original.CAPITAL_VENCIDO_COBRADO) return true;
			if (this.INTERES_VENCIDO_COBRADO != original.INTERES_VENCIDO_COBRADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CANTIDAD_DIAS_DEVENGADOS != original.CANTIDAD_DIAS_DEVENGADOS) return true;
			
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
		/// Gets or sets the <c>CTB_DEVENGAMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_DEVENGAMIENTO_ID</c> column value.</value>
		public decimal CTB_DEVENGAMIENTO_ID
		{
			get { return _ctb_devengamiento_id; }
			set { _ctb_devengamiento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_CR_PERS_ID</c> column value.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_CR_PERS_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_CR_PERS_ID
		{
			get { return _calendario_pagos_cr_pers_id; }
			set { _calendario_pagos_cr_pers_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VIGENTE</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VIGENTE</c> column value.</value>
		public decimal A_DEVENGAR_VIGENTE
		{
			get { return _a_devengar_vigente; }
			set { _a_devengar_vigente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VIGENTE_AUM</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VIGENTE_AUM</c> column value.</value>
		public decimal A_DEVENGAR_VIGENTE_AUM
		{
			get { return _a_devengar_vigente_aum; }
			set { _a_devengar_vigente_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VIGENTE_DIS</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VIGENTE_DIS</c> column value.</value>
		public decimal A_DEVENGAR_VIGENTE_DIS
		{
			get { return _a_devengar_vigente_dis; }
			set { _a_devengar_vigente_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VENCIDO</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VENCIDO</c> column value.</value>
		public decimal A_DEVENGAR_VENCIDO
		{
			get { return _a_devengar_vencido; }
			set { _a_devengar_vencido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VENCIDO_AUM</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VENCIDO_AUM</c> column value.</value>
		public decimal A_DEVENGAR_VENCIDO_AUM
		{
			get { return _a_devengar_vencido_aum; }
			set { _a_devengar_vencido_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_DEVENGAR_VENCIDO_DIS</c> column value.
		/// </summary>
		/// <value>The <c>A_DEVENGAR_VENCIDO_DIS</c> column value.</value>
		public decimal A_DEVENGAR_VENCIDO_DIS
		{
			get { return _a_devengar_vencido_dis; }
			set { _a_devengar_vencido_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVENGADO</c> column value.
		/// </summary>
		/// <value>The <c>DEVENGADO</c> column value.</value>
		public decimal DEVENGADO
		{
			get { return _devengado; }
			set { _devengado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVENGADO_AUM</c> column value.
		/// </summary>
		/// <value>The <c>DEVENGADO_AUM</c> column value.</value>
		public decimal DEVENGADO_AUM
		{
			get { return _devengado_aum; }
			set { _devengado_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVENGADO_DIS</c> column value.
		/// </summary>
		/// <value>The <c>DEVENGADO_DIS</c> column value.</value>
		public decimal DEVENGADO_DIS
		{
			get { return _devengado_dis; }
			set { _devengado_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EN_SUSPENSO</c> column value.
		/// </summary>
		/// <value>The <c>EN_SUSPENSO</c> column value.</value>
		public decimal EN_SUSPENSO
		{
			get { return _en_suspenso; }
			set { _en_suspenso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EN_SUSPENSO_AUM</c> column value.
		/// </summary>
		/// <value>The <c>EN_SUSPENSO_AUM</c> column value.</value>
		public decimal EN_SUSPENSO_AUM
		{
			get { return _en_suspenso_aum; }
			set { _en_suspenso_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EN_SUSPENSO_DIS</c> column value.
		/// </summary>
		/// <value>The <c>EN_SUSPENSO_DIS</c> column value.</value>
		public decimal EN_SUSPENSO_DIS
		{
			get { return _en_suspenso_dis; }
			set { _en_suspenso_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VIGENTE</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VIGENTE</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VIGENTE
		{
			get { return _capital_a_cobrar_vigente; }
			set { _capital_a_cobrar_vigente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VIGENTE_AUM</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VIGENTE_AUM</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VIGENTE_AUM
		{
			get { return _capital_a_cobrar_vigente_aum; }
			set { _capital_a_cobrar_vigente_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VIGENTE_DIS</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VIGENTE_DIS</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VIGENTE_DIS
		{
			get { return _capital_a_cobrar_vigente_dis; }
			set { _capital_a_cobrar_vigente_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VENCIDO</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VENCIDO</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VENCIDO
		{
			get { return _capital_a_cobrar_vencido; }
			set { _capital_a_cobrar_vencido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VENCIDO_AUM</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VENCIDO_AUM</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VENCIDO_AUM
		{
			get { return _capital_a_cobrar_vencido_aum; }
			set { _capital_a_cobrar_vencido_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_A_COBRAR_VENCIDO_DIS</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_A_COBRAR_VENCIDO_DIS</c> column value.</value>
		public decimal CAPITAL_A_COBRAR_VENCIDO_DIS
		{
			get { return _capital_a_cobrar_vencido_dis; }
			set { _capital_a_cobrar_vencido_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VIGENTE</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VIGENTE</c> column value.</value>
		public decimal INTERES_A_COBRAR_VIGENTE
		{
			get { return _interes_a_cobrar_vigente; }
			set { _interes_a_cobrar_vigente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VIGENTE_AUM</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VIGENTE_AUM</c> column value.</value>
		public decimal INTERES_A_COBRAR_VIGENTE_AUM
		{
			get { return _interes_a_cobrar_vigente_aum; }
			set { _interes_a_cobrar_vigente_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VIGENTE_DIS</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VIGENTE_DIS</c> column value.</value>
		public decimal INTERES_A_COBRAR_VIGENTE_DIS
		{
			get { return _interes_a_cobrar_vigente_dis; }
			set { _interes_a_cobrar_vigente_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VENCIDO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VENCIDO</c> column value.</value>
		public decimal INTERES_A_COBRAR_VENCIDO
		{
			get { return _interes_a_cobrar_vencido; }
			set { _interes_a_cobrar_vencido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VENCIDO_AUM</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VENCIDO_AUM</c> column value.</value>
		public decimal INTERES_A_COBRAR_VENCIDO_AUM
		{
			get { return _interes_a_cobrar_vencido_aum; }
			set { _interes_a_cobrar_vencido_aum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_A_COBRAR_VENCIDO_DIS</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_A_COBRAR_VENCIDO_DIS</c> column value.</value>
		public decimal INTERES_A_COBRAR_VENCIDO_DIS
		{
			get { return _interes_a_cobrar_vencido_dis; }
			set { _interes_a_cobrar_vencido_dis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPITAL_VENCIDO_COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>CAPITAL_VENCIDO_COBRADO</c> column value.</value>
		public decimal CAPITAL_VENCIDO_COBRADO
		{
			get { return _capital_vencido_cobrado; }
			set { _capital_vencido_cobrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_VENCIDO_COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_VENCIDO_COBRADO</c> column value.</value>
		public decimal INTERES_VENCIDO_COBRADO
		{
			get { return _interes_vencido_cobrado; }
			set { _interes_vencido_cobrado = value; }
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
		/// Gets or sets the <c>CANTIDAD_DIAS_DEVENGADOS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_DIAS_DEVENGADOS</c> column value.</value>
		public decimal CANTIDAD_DIAS_DEVENGADOS
		{
			get { return _cantidad_dias_devengados; }
			set { _cantidad_dias_devengados = value; }
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
			dynStr.Append("@CBA@CTB_DEVENGAMIENTO_ID=");
			dynStr.Append(CTB_DEVENGAMIENTO_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_CR_PERS_ID=");
			dynStr.Append(CALENDARIO_PAGOS_CR_PERS_ID);
			dynStr.Append("@CBA@A_DEVENGAR_VIGENTE=");
			dynStr.Append(A_DEVENGAR_VIGENTE);
			dynStr.Append("@CBA@A_DEVENGAR_VIGENTE_AUM=");
			dynStr.Append(A_DEVENGAR_VIGENTE_AUM);
			dynStr.Append("@CBA@A_DEVENGAR_VIGENTE_DIS=");
			dynStr.Append(A_DEVENGAR_VIGENTE_DIS);
			dynStr.Append("@CBA@A_DEVENGAR_VENCIDO=");
			dynStr.Append(A_DEVENGAR_VENCIDO);
			dynStr.Append("@CBA@A_DEVENGAR_VENCIDO_AUM=");
			dynStr.Append(A_DEVENGAR_VENCIDO_AUM);
			dynStr.Append("@CBA@A_DEVENGAR_VENCIDO_DIS=");
			dynStr.Append(A_DEVENGAR_VENCIDO_DIS);
			dynStr.Append("@CBA@DEVENGADO=");
			dynStr.Append(DEVENGADO);
			dynStr.Append("@CBA@DEVENGADO_AUM=");
			dynStr.Append(DEVENGADO_AUM);
			dynStr.Append("@CBA@DEVENGADO_DIS=");
			dynStr.Append(DEVENGADO_DIS);
			dynStr.Append("@CBA@EN_SUSPENSO=");
			dynStr.Append(EN_SUSPENSO);
			dynStr.Append("@CBA@EN_SUSPENSO_AUM=");
			dynStr.Append(EN_SUSPENSO_AUM);
			dynStr.Append("@CBA@EN_SUSPENSO_DIS=");
			dynStr.Append(EN_SUSPENSO_DIS);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VIGENTE=");
			dynStr.Append(CAPITAL_A_COBRAR_VIGENTE);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VIGENTE_AUM=");
			dynStr.Append(CAPITAL_A_COBRAR_VIGENTE_AUM);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VIGENTE_DIS=");
			dynStr.Append(CAPITAL_A_COBRAR_VIGENTE_DIS);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VENCIDO=");
			dynStr.Append(CAPITAL_A_COBRAR_VENCIDO);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VENCIDO_AUM=");
			dynStr.Append(CAPITAL_A_COBRAR_VENCIDO_AUM);
			dynStr.Append("@CBA@CAPITAL_A_COBRAR_VENCIDO_DIS=");
			dynStr.Append(CAPITAL_A_COBRAR_VENCIDO_DIS);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VIGENTE=");
			dynStr.Append(INTERES_A_COBRAR_VIGENTE);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VIGENTE_AUM=");
			dynStr.Append(INTERES_A_COBRAR_VIGENTE_AUM);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VIGENTE_DIS=");
			dynStr.Append(INTERES_A_COBRAR_VIGENTE_DIS);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VENCIDO=");
			dynStr.Append(INTERES_A_COBRAR_VENCIDO);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VENCIDO_AUM=");
			dynStr.Append(INTERES_A_COBRAR_VENCIDO_AUM);
			dynStr.Append("@CBA@INTERES_A_COBRAR_VENCIDO_DIS=");
			dynStr.Append(INTERES_A_COBRAR_VENCIDO_DIS);
			dynStr.Append("@CBA@CAPITAL_VENCIDO_COBRADO=");
			dynStr.Append(CAPITAL_VENCIDO_COBRADO);
			dynStr.Append("@CBA@INTERES_VENCIDO_COBRADO=");
			dynStr.Append(INTERES_VENCIDO_COBRADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CANTIDAD_DIAS_DEVENGADOS=");
			dynStr.Append(CANTIDAD_DIAS_DEVENGADOS);
			return dynStr.ToString();
		}
	} // End of CTB_DEVENGAMIENTOS_DETRow_Base class
} // End of namespace
