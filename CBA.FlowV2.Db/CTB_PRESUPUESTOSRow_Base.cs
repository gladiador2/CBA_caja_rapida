// <fileinfo name="CTB_PRESUPUESTOSRow_Base.cs">
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
	/// The base class for <see cref="CTB_PRESUPUESTOSRow"/> that 
	/// represents a record in the <c>CTB_PRESUPUESTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_PRESUPUESTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PRESUPUESTOSRow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _region_id;
		private bool _region_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _estado;
		private decimal _moneda_id;
		private string _rangos;
		private decimal _ctb_plan_cuenta_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PRESUPUESTOSRow_Base"/> class.
		/// </summary>
		public CTB_PRESUPUESTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_PRESUPUESTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.RANGOS != original.RANGOS) return true;
			if (this.CTB_PLAN_CUENTA_ID != original.CTB_PLAN_CUENTA_ID) return true;
			
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Gets or sets the <c>RANGOS</c> column value.
		/// </summary>
		/// <value>The <c>RANGOS</c> column value.</value>
		public string RANGOS
		{
			get { return _rangos; }
			set { _rangos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ID</c> column value.</value>
		public decimal CTB_PLAN_CUENTA_ID
		{
			get { return _ctb_plan_cuenta_id; }
			set { _ctb_plan_cuenta_id = value; }
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
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@RANGOS=");
			dynStr.Append(RANGOS);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ID=");
			dynStr.Append(CTB_PLAN_CUENTA_ID);
			return dynStr.ToString();
		}
	} // End of CTB_PRESUPUESTOSRow_Base class
} // End of namespace
