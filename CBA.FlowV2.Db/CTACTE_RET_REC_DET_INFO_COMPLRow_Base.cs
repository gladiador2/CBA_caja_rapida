// <fileinfo name="CTACTE_RET_REC_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_RET_REC_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_RET_REC_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_RET_REC_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RET_REC_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctacte_retencion_recibida_id;
		private decimal _flujo_id;
		private string _flujo_descripcion;
		private decimal _caso_id;
		private decimal _monto;
		private decimal _tipo_id;
		private string _tipo_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RET_REC_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_RET_REC_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_RET_REC_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_RETENCION_RECIBIDA_ID != original.CTACTE_RETENCION_RECIBIDA_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.TIPO_ID != original.TIPO_ID) return true;
			if (this.TIPO_NOMBRE != original.TIPO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</value>
		public decimal CTACTE_RETENCION_RECIBIDA_ID
		{
			get { return _ctacte_retencion_recibida_id; }
			set { _ctacte_retencion_recibida_id = value; }
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
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
		/// Gets or sets the <c>TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ID</c> column value.</value>
		public decimal TIPO_ID
		{
			get { return _tipo_id; }
			set { _tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_NOMBRE</c> column value.</value>
		public string TIPO_NOMBRE
		{
			get { return _tipo_nombre; }
			set { _tipo_nombre = value; }
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
			dynStr.Append("@CBA@CTACTE_RETENCION_RECIBIDA_ID=");
			dynStr.Append(CTACTE_RETENCION_RECIBIDA_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@TIPO_ID=");
			dynStr.Append(TIPO_ID);
			dynStr.Append("@CBA@TIPO_NOMBRE=");
			dynStr.Append(TIPO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTACTE_RET_REC_DET_INFO_COMPLRow_Base class
} // End of namespace
