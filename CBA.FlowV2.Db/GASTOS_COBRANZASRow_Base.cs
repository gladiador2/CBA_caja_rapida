// <fileinfo name="GASTOS_COBRANZASRow_Base.cs">
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
	/// The base class for <see cref="GASTOS_COBRANZASRow"/> that 
	/// represents a record in the <c>GASTOS_COBRANZAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GASTOS_COBRANZASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GASTOS_COBRANZASRow_Base
	{
		private decimal _id;
		private decimal _dias_atraso_desde;
		private decimal _monto_adeudado_desde;
		private decimal _moneda_id;
		private string _estado;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _monto;

		/// <summary>
		/// Initializes a new instance of the <see cref="GASTOS_COBRANZASRow_Base"/> class.
		/// </summary>
		public GASTOS_COBRANZASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GASTOS_COBRANZASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DIAS_ATRASO_DESDE != original.DIAS_ATRASO_DESDE) return true;
			if (this.MONTO_ADEUDADO_DESDE != original.MONTO_ADEUDADO_DESDE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			
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
		/// Gets or sets the <c>DIAS_ATRASO_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_ATRASO_DESDE</c> column value.</value>
		public decimal DIAS_ATRASO_DESDE
		{
			get { return _dias_atraso_desde; }
			set { _dias_atraso_desde = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ADEUDADO_DESDE</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ADEUDADO_DESDE</c> column value.</value>
		public decimal MONTO_ADEUDADO_DESDE
		{
			get { return _monto_adeudado_desde; }
			set { _monto_adeudado_desde = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@DIAS_ATRASO_DESDE=");
			dynStr.Append(DIAS_ATRASO_DESDE);
			dynStr.Append("@CBA@MONTO_ADEUDADO_DESDE=");
			dynStr.Append(MONTO_ADEUDADO_DESDE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			return dynStr.ToString();
		}
	} // End of GASTOS_COBRANZASRow_Base class
} // End of namespace
