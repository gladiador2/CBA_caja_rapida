// <fileinfo name="CTACTE_RETENC_EMIT_DET_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_RETENC_EMIT_DET_INFO_CRow"/> that 
	/// represents a record in the <c>CTACTE_RETENC_EMIT_DET_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_RETENC_EMIT_DET_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RETENC_EMIT_DET_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _ctacte_retencion_emitida_id;
		private decimal _flujo_id;
		private decimal _caso_id;
		private string _flujo_descripcion;
		private string _caso_estado_id;
		private string _caso_nro_comprobante;
		private decimal _monto;
		private decimal _retencion_tipo_id;
		private string _retencion_tipo_nombre;
		private decimal _total_impuesto;
		private bool _total_impuestoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RETENC_EMIT_DET_INFO_CRow_Base"/> class.
		/// </summary>
		public CTACTE_RETENC_EMIT_DET_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_RETENC_EMIT_DET_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_RETENCION_EMITIDA_ID != original.CTACTE_RETENCION_EMITIDA_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.RETENCION_TIPO_ID != original.RETENCION_TIPO_ID) return true;
			if (this.RETENCION_TIPO_NOMBRE != original.RETENCION_TIPO_NOMBRE) return true;
			if (this.IsTOTAL_IMPUESTONull != original.IsTOTAL_IMPUESTONull) return true;
			if (!this.IsTOTAL_IMPUESTONull && !original.IsTOTAL_IMPUESTONull)
				if (this.TOTAL_IMPUESTO != original.TOTAL_IMPUESTO) return true;
			
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
		/// Gets or sets the <c>CTACTE_RETENCION_EMITIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_RETENCION_EMITIDA_ID</c> column value.</value>
		public decimal CTACTE_RETENCION_EMITIDA_ID
		{
			get { return _ctacte_retencion_emitida_id; }
			set { _ctacte_retencion_emitida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>RETENCION_TIPO_ID</c> column value.</value>
		public decimal RETENCION_TIPO_ID
		{
			get { return _retencion_tipo_id; }
			set { _retencion_tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>RETENCION_TIPO_NOMBRE</c> column value.</value>
		public string RETENCION_TIPO_NOMBRE
		{
			get { return _retencion_tipo_nombre; }
			set { _retencion_tipo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO
		{
			get
			{
				if(IsTOTAL_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto;
			}
			set
			{
				_total_impuestoNull = false;
				_total_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTONull
		{
			get { return _total_impuestoNull; }
			set { _total_impuestoNull = value; }
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
			dynStr.Append("@CBA@CTACTE_RETENCION_EMITIDA_ID=");
			dynStr.Append(CTACTE_RETENCION_EMITIDA_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@RETENCION_TIPO_ID=");
			dynStr.Append(RETENCION_TIPO_ID);
			dynStr.Append("@CBA@RETENCION_TIPO_NOMBRE=");
			dynStr.Append(RETENCION_TIPO_NOMBRE);
			dynStr.Append("@CBA@TOTAL_IMPUESTO=");
			dynStr.Append(IsTOTAL_IMPUESTONull ? (object)"<NULL>" : TOTAL_IMPUESTO);
			return dynStr.ToString();
		}
	} // End of CTACTE_RETENC_EMIT_DET_INFO_CRow_Base class
} // End of namespace
