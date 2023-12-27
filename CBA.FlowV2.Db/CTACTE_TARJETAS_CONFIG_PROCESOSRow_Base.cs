// <fileinfo name="CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> that 
	/// represents a record in the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base
	{
		private decimal _id;
		private decimal _pos_id;
		private decimal _procesadora_id;
		private decimal _comision_porc;
		private decimal _iva_sobre_comision_porc;
		private decimal _renta_sobre_iva_porc;
		private decimal _ctacte_bancaria_id_dest;
		private string _es_tarjeta_credito;
		private decimal _ctacte_caja_id;
		private bool _ctacte_caja_idNull = true;
		private decimal _procesadora_id_red_dinelco;
		private bool _procesadora_id_red_dinelcoNull = true;
		private decimal _procesadora_id_red_infonet;
		private bool _procesadora_id_red_infonetNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base"/> class.
		/// </summary>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.POS_ID != original.POS_ID) return true;
			if (this.PROCESADORA_ID != original.PROCESADORA_ID) return true;
			if (this.COMISION_PORC != original.COMISION_PORC) return true;
			if (this.IVA_SOBRE_COMISION_PORC != original.IVA_SOBRE_COMISION_PORC) return true;
			if (this.RENTA_SOBRE_IVA_PORC != original.RENTA_SOBRE_IVA_PORC) return true;
			if (this.CTACTE_BANCARIA_ID_DEST != original.CTACTE_BANCARIA_ID_DEST) return true;
			if (this.ES_TARJETA_CREDITO != original.ES_TARJETA_CREDITO) return true;
			if (this.IsCTACTE_CAJA_IDNull != original.IsCTACTE_CAJA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_IDNull && !original.IsCTACTE_CAJA_IDNull)
				if (this.CTACTE_CAJA_ID != original.CTACTE_CAJA_ID) return true;
			if (this.IsPROCESADORA_ID_RED_DINELCONull != original.IsPROCESADORA_ID_RED_DINELCONull) return true;
			if (!this.IsPROCESADORA_ID_RED_DINELCONull && !original.IsPROCESADORA_ID_RED_DINELCONull)
				if (this.PROCESADORA_ID_RED_DINELCO != original.PROCESADORA_ID_RED_DINELCO) return true;
			if (this.IsPROCESADORA_ID_RED_INFONETNull != original.IsPROCESADORA_ID_RED_INFONETNull) return true;
			if (!this.IsPROCESADORA_ID_RED_INFONETNull && !original.IsPROCESADORA_ID_RED_INFONETNull)
				if (this.PROCESADORA_ID_RED_INFONET != original.PROCESADORA_ID_RED_INFONET) return true;
			
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
		/// Gets or sets the <c>POS_ID</c> column value.
		/// </summary>
		/// <value>The <c>POS_ID</c> column value.</value>
		public decimal POS_ID
		{
			get { return _pos_id; }
			set { _pos_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADORA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROCESADORA_ID</c> column value.</value>
		public decimal PROCESADORA_ID
		{
			get { return _procesadora_id; }
			set { _procesadora_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_PORC</c> column value.
		/// </summary>
		/// <value>The <c>COMISION_PORC</c> column value.</value>
		public decimal COMISION_PORC
		{
			get { return _comision_porc; }
			set { _comision_porc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IVA_SOBRE_COMISION_PORC</c> column value.
		/// </summary>
		/// <value>The <c>IVA_SOBRE_COMISION_PORC</c> column value.</value>
		public decimal IVA_SOBRE_COMISION_PORC
		{
			get { return _iva_sobre_comision_porc; }
			set { _iva_sobre_comision_porc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RENTA_SOBRE_IVA_PORC</c> column value.
		/// </summary>
		/// <value>The <c>RENTA_SOBRE_IVA_PORC</c> column value.</value>
		public decimal RENTA_SOBRE_IVA_PORC
		{
			get { return _renta_sobre_iva_porc; }
			set { _renta_sobre_iva_porc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID_DEST</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID_DEST
		{
			get { return _ctacte_bancaria_id_dest; }
			set { _ctacte_bancaria_id_dest = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_TARJETA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>ES_TARJETA_CREDITO</c> column value.</value>
		public string ES_TARJETA_CREDITO
		{
			get { return _es_tarjeta_credito; }
			set { _es_tarjeta_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_ID
		{
			get
			{
				if(IsCTACTE_CAJA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_id;
			}
			set
			{
				_ctacte_caja_idNull = false;
				_ctacte_caja_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_IDNull
		{
			get { return _ctacte_caja_idNull; }
			set { _ctacte_caja_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADORA_ID_RED_DINELCO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</value>
		public decimal PROCESADORA_ID_RED_DINELCO
		{
			get
			{
				if(IsPROCESADORA_ID_RED_DINELCONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _procesadora_id_red_dinelco;
			}
			set
			{
				_procesadora_id_red_dinelcoNull = false;
				_procesadora_id_red_dinelco = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROCESADORA_ID_RED_DINELCO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROCESADORA_ID_RED_DINELCONull
		{
			get { return _procesadora_id_red_dinelcoNull; }
			set { _procesadora_id_red_dinelcoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADORA_ID_RED_INFONET</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCESADORA_ID_RED_INFONET</c> column value.</value>
		public decimal PROCESADORA_ID_RED_INFONET
		{
			get
			{
				if(IsPROCESADORA_ID_RED_INFONETNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _procesadora_id_red_infonet;
			}
			set
			{
				_procesadora_id_red_infonetNull = false;
				_procesadora_id_red_infonet = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROCESADORA_ID_RED_INFONET"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROCESADORA_ID_RED_INFONETNull
		{
			get { return _procesadora_id_red_infonetNull; }
			set { _procesadora_id_red_infonetNull = value; }
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
			dynStr.Append("@CBA@POS_ID=");
			dynStr.Append(POS_ID);
			dynStr.Append("@CBA@PROCESADORA_ID=");
			dynStr.Append(PROCESADORA_ID);
			dynStr.Append("@CBA@COMISION_PORC=");
			dynStr.Append(COMISION_PORC);
			dynStr.Append("@CBA@IVA_SOBRE_COMISION_PORC=");
			dynStr.Append(IVA_SOBRE_COMISION_PORC);
			dynStr.Append("@CBA@RENTA_SOBRE_IVA_PORC=");
			dynStr.Append(RENTA_SOBRE_IVA_PORC);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID_DEST=");
			dynStr.Append(CTACTE_BANCARIA_ID_DEST);
			dynStr.Append("@CBA@ES_TARJETA_CREDITO=");
			dynStr.Append(ES_TARJETA_CREDITO);
			dynStr.Append("@CBA@CTACTE_CAJA_ID=");
			dynStr.Append(IsCTACTE_CAJA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_ID);
			dynStr.Append("@CBA@PROCESADORA_ID_RED_DINELCO=");
			dynStr.Append(IsPROCESADORA_ID_RED_DINELCONull ? (object)"<NULL>" : PROCESADORA_ID_RED_DINELCO);
			dynStr.Append("@CBA@PROCESADORA_ID_RED_INFONET=");
			dynStr.Append(IsPROCESADORA_ID_RED_INFONETNull ? (object)"<NULL>" : PROCESADORA_ID_RED_INFONET);
			return dynStr.ToString();
		}
	} // End of CTACTE_TARJETAS_CONFIG_PROCESOSRow_Base class
} // End of namespace
