// <fileinfo name="CTACTE_GIROSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_GIROSRow"/> that 
	/// represents a record in the <c>CTACTE_GIROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_GIROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_GIROSRow_Base
	{
		private decimal _id;
		private System.DateTime _fecha;
		private decimal _monto_pago;
		private bool _monto_pagoNull = true;
		private decimal _comision_porcentaje;
		private bool _comision_porcentajeNull = true;
		private decimal _comision_monto_fijo;
		private bool _comision_monto_fijoNull = true;
		private decimal _moto_a_cobrar;
		private bool _moto_a_cobrarNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _persona_id;
		private decimal _condicion_desembolso_id;
		private bool _condicion_desembolso_idNull = true;
		private string _desembolso_automatico;
		private decimal _politica_primer_desembolso;
		private bool _politica_primer_desembolsoNull = true;
		private decimal _dias_desde_inicio_mes;
		private bool _dias_desde_inicio_mesNull = true;
		private string _comprobante;
		private string _observaciones;
		private decimal _ctacte_planes_desembolso_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROSRow_Base"/> class.
		/// </summary>
		public CTACTE_GIROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_GIROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsMONTO_PAGONull != original.IsMONTO_PAGONull) return true;
			if (!this.IsMONTO_PAGONull && !original.IsMONTO_PAGONull)
				if (this.MONTO_PAGO != original.MONTO_PAGO) return true;
			if (this.IsCOMISION_PORCENTAJENull != original.IsCOMISION_PORCENTAJENull) return true;
			if (!this.IsCOMISION_PORCENTAJENull && !original.IsCOMISION_PORCENTAJENull)
				if (this.COMISION_PORCENTAJE != original.COMISION_PORCENTAJE) return true;
			if (this.IsCOMISION_MONTO_FIJONull != original.IsCOMISION_MONTO_FIJONull) return true;
			if (!this.IsCOMISION_MONTO_FIJONull && !original.IsCOMISION_MONTO_FIJONull)
				if (this.COMISION_MONTO_FIJO != original.COMISION_MONTO_FIJO) return true;
			if (this.IsMOTO_A_COBRARNull != original.IsMOTO_A_COBRARNull) return true;
			if (!this.IsMOTO_A_COBRARNull && !original.IsMOTO_A_COBRARNull)
				if (this.MOTO_A_COBRAR != original.MOTO_A_COBRAR) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsCONDICION_DESEMBOLSO_IDNull != original.IsCONDICION_DESEMBOLSO_IDNull) return true;
			if (!this.IsCONDICION_DESEMBOLSO_IDNull && !original.IsCONDICION_DESEMBOLSO_IDNull)
				if (this.CONDICION_DESEMBOLSO_ID != original.CONDICION_DESEMBOLSO_ID) return true;
			if (this.DESEMBOLSO_AUTOMATICO != original.DESEMBOLSO_AUTOMATICO) return true;
			if (this.IsPOLITICA_PRIMER_DESEMBOLSONull != original.IsPOLITICA_PRIMER_DESEMBOLSONull) return true;
			if (!this.IsPOLITICA_PRIMER_DESEMBOLSONull && !original.IsPOLITICA_PRIMER_DESEMBOLSONull)
				if (this.POLITICA_PRIMER_DESEMBOLSO != original.POLITICA_PRIMER_DESEMBOLSO) return true;
			if (this.IsDIAS_DESDE_INICIO_MESNull != original.IsDIAS_DESDE_INICIO_MESNull) return true;
			if (!this.IsDIAS_DESDE_INICIO_MESNull && !original.IsDIAS_DESDE_INICIO_MESNull)
				if (this.DIAS_DESDE_INICIO_MES != original.DIAS_DESDE_INICIO_MES) return true;
			if (this.COMPROBANTE != original.COMPROBANTE) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.CTACTE_PLANES_DESEMBOLSO_ID != original.CTACTE_PLANES_DESEMBOLSO_ID) return true;
			
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PAGO</c> column value.</value>
		public decimal MONTO_PAGO
		{
			get
			{
				if(IsMONTO_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_pago;
			}
			set
			{
				_monto_pagoNull = false;
				_monto_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PAGONull
		{
			get { return _monto_pagoNull; }
			set { _monto_pagoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_PORCENTAJE</c> column value.</value>
		public decimal COMISION_PORCENTAJE
		{
			get
			{
				if(IsCOMISION_PORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_porcentaje;
			}
			set
			{
				_comision_porcentajeNull = false;
				_comision_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_PORCENTAJENull
		{
			get { return _comision_porcentajeNull; }
			set { _comision_porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_MONTO_FIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_MONTO_FIJO</c> column value.</value>
		public decimal COMISION_MONTO_FIJO
		{
			get
			{
				if(IsCOMISION_MONTO_FIJONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_monto_fijo;
			}
			set
			{
				_comision_monto_fijoNull = false;
				_comision_monto_fijo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_MONTO_FIJO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_MONTO_FIJONull
		{
			get { return _comision_monto_fijoNull; }
			set { _comision_monto_fijoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTO_A_COBRAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTO_A_COBRAR</c> column value.</value>
		public decimal MOTO_A_COBRAR
		{
			get
			{
				if(IsMOTO_A_COBRARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moto_a_cobrar;
			}
			set
			{
				_moto_a_cobrarNull = false;
				_moto_a_cobrar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOTO_A_COBRAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOTO_A_COBRARNull
		{
			get { return _moto_a_cobrarNull; }
			set { _moto_a_cobrarNull = value; }
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_DESEMBOLSO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_DESEMBOLSO_ID</c> column value.</value>
		public decimal CONDICION_DESEMBOLSO_ID
		{
			get
			{
				if(IsCONDICION_DESEMBOLSO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_desembolso_id;
			}
			set
			{
				_condicion_desembolso_idNull = false;
				_condicion_desembolso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_DESEMBOLSO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_DESEMBOLSO_IDNull
		{
			get { return _condicion_desembolso_idNull; }
			set { _condicion_desembolso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSO_AUTOMATICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_AUTOMATICO</c> column value.</value>
		public string DESEMBOLSO_AUTOMATICO
		{
			get { return _desembolso_automatico; }
			set { _desembolso_automatico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POLITICA_PRIMER_DESEMBOLSO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>POLITICA_PRIMER_DESEMBOLSO</c> column value.</value>
		public decimal POLITICA_PRIMER_DESEMBOLSO
		{
			get
			{
				if(IsPOLITICA_PRIMER_DESEMBOLSONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _politica_primer_desembolso;
			}
			set
			{
				_politica_primer_desembolsoNull = false;
				_politica_primer_desembolso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="POLITICA_PRIMER_DESEMBOLSO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPOLITICA_PRIMER_DESEMBOLSONull
		{
			get { return _politica_primer_desembolsoNull; }
			set { _politica_primer_desembolsoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_DESDE_INICIO_MES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_DESDE_INICIO_MES</c> column value.</value>
		public decimal DIAS_DESDE_INICIO_MES
		{
			get
			{
				if(IsDIAS_DESDE_INICIO_MESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_desde_inicio_mes;
			}
			set
			{
				_dias_desde_inicio_mesNull = false;
				_dias_desde_inicio_mes = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_DESDE_INICIO_MES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_DESDE_INICIO_MESNull
		{
			get { return _dias_desde_inicio_mesNull; }
			set { _dias_desde_inicio_mesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMPROBANTE</c> column value.</value>
		public string COMPROBANTE
		{
			get { return _comprobante; }
			set { _comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</value>
		public decimal CTACTE_PLANES_DESEMBOLSO_ID
		{
			get { return _ctacte_planes_desembolso_id; }
			set { _ctacte_planes_desembolso_id = value; }
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
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONTO_PAGO=");
			dynStr.Append(IsMONTO_PAGONull ? (object)"<NULL>" : MONTO_PAGO);
			dynStr.Append("@CBA@COMISION_PORCENTAJE=");
			dynStr.Append(IsCOMISION_PORCENTAJENull ? (object)"<NULL>" : COMISION_PORCENTAJE);
			dynStr.Append("@CBA@COMISION_MONTO_FIJO=");
			dynStr.Append(IsCOMISION_MONTO_FIJONull ? (object)"<NULL>" : COMISION_MONTO_FIJO);
			dynStr.Append("@CBA@MOTO_A_COBRAR=");
			dynStr.Append(IsMOTO_A_COBRARNull ? (object)"<NULL>" : MOTO_A_COBRAR);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@CONDICION_DESEMBOLSO_ID=");
			dynStr.Append(IsCONDICION_DESEMBOLSO_IDNull ? (object)"<NULL>" : CONDICION_DESEMBOLSO_ID);
			dynStr.Append("@CBA@DESEMBOLSO_AUTOMATICO=");
			dynStr.Append(DESEMBOLSO_AUTOMATICO);
			dynStr.Append("@CBA@POLITICA_PRIMER_DESEMBOLSO=");
			dynStr.Append(IsPOLITICA_PRIMER_DESEMBOLSONull ? (object)"<NULL>" : POLITICA_PRIMER_DESEMBOLSO);
			dynStr.Append("@CBA@DIAS_DESDE_INICIO_MES=");
			dynStr.Append(IsDIAS_DESDE_INICIO_MESNull ? (object)"<NULL>" : DIAS_DESDE_INICIO_MES);
			dynStr.Append("@CBA@COMPROBANTE=");
			dynStr.Append(COMPROBANTE);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@CTACTE_PLANES_DESEMBOLSO_ID=");
			dynStr.Append(CTACTE_PLANES_DESEMBOLSO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_GIROSRow_Base class
} // End of namespace
