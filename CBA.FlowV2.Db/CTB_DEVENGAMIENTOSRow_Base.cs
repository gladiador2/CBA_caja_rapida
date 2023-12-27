// <fileinfo name="CTB_DEVENGAMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="CTB_DEVENGAMIENTOSRow"/> that 
	/// represents a record in the <c>CTB_DEVENGAMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_DEVENGAMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_DEVENGAMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _region_id;
		private bool _region_idNull = true;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _limite_dias_en_suspenso;
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
		private string _estado;
		private decimal _capital_vencido_cobrado;
		private decimal _interes_vencido_cobrado;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;
		private decimal _persona_relacionada_id;
		private bool _persona_relacionada_idNull = true;
		private string _existe_persona_relacionada;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_DEVENGAMIENTOSRow_Base"/> class.
		/// </summary>
		public CTB_DEVENGAMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_DEVENGAMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.LIMITE_DIAS_EN_SUSPENSO != original.LIMITE_DIAS_EN_SUSPENSO) return true;
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
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CAPITAL_VENCIDO_COBRADO != original.CAPITAL_VENCIDO_COBRADO) return true;
			if (this.INTERES_VENCIDO_COBRADO != original.INTERES_VENCIDO_COBRADO) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			if (this.IsPERSONA_RELACIONADA_IDNull != original.IsPERSONA_RELACIONADA_IDNull) return true;
			if (!this.IsPERSONA_RELACIONADA_IDNull && !original.IsPERSONA_RELACIONADA_IDNull)
				if (this.PERSONA_RELACIONADA_ID != original.PERSONA_RELACIONADA_ID) return true;
			if (this.EXISTE_PERSONA_RELACIONADA != original.EXISTE_PERSONA_RELACIONADA) return true;
			
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
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>LIMITE_DIAS_EN_SUSPENSO</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_DIAS_EN_SUSPENSO</c> column value.</value>
		public decimal LIMITE_DIAS_EN_SUSPENSO
		{
			get { return _limite_dias_en_suspenso; }
			set { _limite_dias_en_suspenso = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Gets or sets the <c>CANAL_VENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANAL_VENTA_ID</c> column value.</value>
		public decimal CANAL_VENTA_ID
		{
			get
			{
				if(IsCANAL_VENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canal_venta_id;
			}
			set
			{
				_canal_venta_idNull = false;
				_canal_venta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANAL_VENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANAL_VENTA_IDNull
		{
			get { return _canal_venta_idNull; }
			set { _canal_venta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_RELACIONADA_ID</c> column value.</value>
		public decimal PERSONA_RELACIONADA_ID
		{
			get
			{
				if(IsPERSONA_RELACIONADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_relacionada_id;
			}
			set
			{
				_persona_relacionada_idNull = false;
				_persona_relacionada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_RELACIONADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_RELACIONADA_IDNull
		{
			get { return _persona_relacionada_idNull; }
			set { _persona_relacionada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTE_PERSONA_RELACIONADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTE_PERSONA_RELACIONADA</c> column value.</value>
		public string EXISTE_PERSONA_RELACIONADA
		{
			get { return _existe_persona_relacionada; }
			set { _existe_persona_relacionada = value; }
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
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@LIMITE_DIAS_EN_SUSPENSO=");
			dynStr.Append(LIMITE_DIAS_EN_SUSPENSO);
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
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CAPITAL_VENCIDO_COBRADO=");
			dynStr.Append(CAPITAL_VENCIDO_COBRADO);
			dynStr.Append("@CBA@INTERES_VENCIDO_COBRADO=");
			dynStr.Append(INTERES_VENCIDO_COBRADO);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			dynStr.Append("@CBA@PERSONA_RELACIONADA_ID=");
			dynStr.Append(IsPERSONA_RELACIONADA_IDNull ? (object)"<NULL>" : PERSONA_RELACIONADA_ID);
			dynStr.Append("@CBA@EXISTE_PERSONA_RELACIONADA=");
			dynStr.Append(EXISTE_PERSONA_RELACIONADA);
			return dynStr.ToString();
		}
	} // End of CTB_DEVENGAMIENTOSRow_Base class
} // End of namespace
