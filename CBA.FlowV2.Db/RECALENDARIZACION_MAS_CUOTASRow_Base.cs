// <fileinfo name="RECALENDARIZACION_MAS_CUOTASRow_Base.cs">
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
	/// The base class for <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> that 
	/// represents a record in the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RECALENDARIZACION_MAS_CUOTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECALENDARIZACION_MAS_CUOTASRow_Base
	{
		private decimal _id;
		private decimal _recal_masiva_det_id;
		private decimal _cal_pago_cli_fc_original_id;
		private decimal _cal_pago_cli_fc_nuevo_id;
		private bool _cal_pago_cli_fc_nuevo_idNull = true;
		private System.DateTime _nuevo_vencimiento;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECALENDARIZACION_MAS_CUOTASRow_Base"/> class.
		/// </summary>
		public RECALENDARIZACION_MAS_CUOTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RECALENDARIZACION_MAS_CUOTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RECAL_MASIVA_DET_ID != original.RECAL_MASIVA_DET_ID) return true;
			if (this.CAL_PAGO_CLI_FC_ORIGINAL_ID != original.CAL_PAGO_CLI_FC_ORIGINAL_ID) return true;
			if (this.IsCAL_PAGO_CLI_FC_NUEVO_IDNull != original.IsCAL_PAGO_CLI_FC_NUEVO_IDNull) return true;
			if (!this.IsCAL_PAGO_CLI_FC_NUEVO_IDNull && !original.IsCAL_PAGO_CLI_FC_NUEVO_IDNull)
				if (this.CAL_PAGO_CLI_FC_NUEVO_ID != original.CAL_PAGO_CLI_FC_NUEVO_ID) return true;
			if (this.NUEVO_VENCIMIENTO != original.NUEVO_VENCIMIENTO) return true;
			
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
		/// Gets or sets the <c>RECAL_MASIVA_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>RECAL_MASIVA_DET_ID</c> column value.</value>
		public decimal RECAL_MASIVA_DET_ID
		{
			get { return _recal_masiva_det_id; }
			set { _recal_masiva_det_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</value>
		public decimal CAL_PAGO_CLI_FC_ORIGINAL_ID
		{
			get { return _cal_pago_cli_fc_original_id; }
			set { _cal_pago_cli_fc_original_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</value>
		public decimal CAL_PAGO_CLI_FC_NUEVO_ID
		{
			get
			{
				if(IsCAL_PAGO_CLI_FC_NUEVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cal_pago_cli_fc_nuevo_id;
			}
			set
			{
				_cal_pago_cli_fc_nuevo_idNull = false;
				_cal_pago_cli_fc_nuevo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAL_PAGO_CLI_FC_NUEVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAL_PAGO_CLI_FC_NUEVO_IDNull
		{
			get { return _cal_pago_cli_fc_nuevo_idNull; }
			set { _cal_pago_cli_fc_nuevo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUEVO_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>NUEVO_VENCIMIENTO</c> column value.</value>
		public System.DateTime NUEVO_VENCIMIENTO
		{
			get { return _nuevo_vencimiento; }
			set { _nuevo_vencimiento = value; }
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
			dynStr.Append("@CBA@RECAL_MASIVA_DET_ID=");
			dynStr.Append(RECAL_MASIVA_DET_ID);
			dynStr.Append("@CBA@CAL_PAGO_CLI_FC_ORIGINAL_ID=");
			dynStr.Append(CAL_PAGO_CLI_FC_ORIGINAL_ID);
			dynStr.Append("@CBA@CAL_PAGO_CLI_FC_NUEVO_ID=");
			dynStr.Append(IsCAL_PAGO_CLI_FC_NUEVO_IDNull ? (object)"<NULL>" : CAL_PAGO_CLI_FC_NUEVO_ID);
			dynStr.Append("@CBA@NUEVO_VENCIMIENTO=");
			dynStr.Append(NUEVO_VENCIMIENTO);
			return dynStr.ToString();
		}
	} // End of RECALENDARIZACION_MAS_CUOTASRow_Base class
} // End of namespace
