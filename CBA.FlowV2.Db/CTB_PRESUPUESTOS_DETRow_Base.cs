// <fileinfo name="CTB_PRESUPUESTOS_DETRow_Base.cs">
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
	/// The base class for <see cref="CTB_PRESUPUESTOS_DETRow"/> that 
	/// represents a record in the <c>CTB_PRESUPUESTOS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_PRESUPUESTOS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PRESUPUESTOS_DETRow_Base
	{
		private decimal _id;
		private decimal _ctb_presupuesto_id;
		private decimal _ctb_cuenta_id;
		private decimal _mes_desde;
		private decimal _mes_hasta;
		private decimal _monto;
		private string _estado;
		private string _nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PRESUPUESTOS_DETRow_Base"/> class.
		/// </summary>
		public CTB_PRESUPUESTOS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_PRESUPUESTOS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_PRESUPUESTO_ID != original.CTB_PRESUPUESTO_ID) return true;
			if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.MES_DESDE != original.MES_DESDE) return true;
			if (this.MES_HASTA != original.MES_HASTA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			
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
		/// Gets or sets the <c>CTB_PRESUPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PRESUPUESTO_ID</c> column value.</value>
		public decimal CTB_PRESUPUESTO_ID
		{
			get { return _ctb_presupuesto_id; }
			set { _ctb_presupuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get { return _ctb_cuenta_id; }
			set { _ctb_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MES_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>MES_DESDE</c> column value.</value>
		public decimal MES_DESDE
		{
			get { return _mes_desde; }
			set { _mes_desde = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MES_HASTA</c> column value.
		/// </summary>
		/// <value>The <c>MES_HASTA</c> column value.</value>
		public decimal MES_HASTA
		{
			get { return _mes_hasta; }
			set { _mes_hasta = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CTB_PRESUPUESTO_ID=");
			dynStr.Append(CTB_PRESUPUESTO_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(CTB_CUENTA_ID);
			dynStr.Append("@CBA@MES_DESDE=");
			dynStr.Append(MES_DESDE);
			dynStr.Append("@CBA@MES_HASTA=");
			dynStr.Append(MES_HASTA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTB_PRESUPUESTOS_DETRow_Base class
} // End of namespace
