// <fileinfo name="CTACTE_PLANES_DESEM_ESCALASRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PLANES_DESEM_ESCALASRow"/> that 
	/// represents a record in the <c>CTACTE_PLANES_DESEM_ESCALAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PLANES_DESEM_ESCALASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PLANES_DESEM_ESCALASRow_Base
	{
		private decimal _id;
		private decimal _ctacte_plan_desembolso_id;
		private decimal _monto_desde;
		private bool _monto_desdeNull = true;
		private decimal _monto_hasta;
		private bool _monto_hastaNull = true;
		private decimal _porcentaje_comision;
		private bool _porcentaje_comisionNull = true;
		private decimal _monto_comision;
		private bool _monto_comisionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PLANES_DESEM_ESCALASRow_Base"/> class.
		/// </summary>
		public CTACTE_PLANES_DESEM_ESCALASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PLANES_DESEM_ESCALASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PLAN_DESEMBOLSO_ID != original.CTACTE_PLAN_DESEMBOLSO_ID) return true;
			if (this.IsMONTO_DESDENull != original.IsMONTO_DESDENull) return true;
			if (!this.IsMONTO_DESDENull && !original.IsMONTO_DESDENull)
				if (this.MONTO_DESDE != original.MONTO_DESDE) return true;
			if (this.IsMONTO_HASTANull != original.IsMONTO_HASTANull) return true;
			if (!this.IsMONTO_HASTANull && !original.IsMONTO_HASTANull)
				if (this.MONTO_HASTA != original.MONTO_HASTA) return true;
			if (this.IsPORCENTAJE_COMISIONNull != original.IsPORCENTAJE_COMISIONNull) return true;
			if (!this.IsPORCENTAJE_COMISIONNull && !original.IsPORCENTAJE_COMISIONNull)
				if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			if (this.IsMONTO_COMISIONNull != original.IsMONTO_COMISIONNull) return true;
			if (!this.IsMONTO_COMISIONNull && !original.IsMONTO_COMISIONNull)
				if (this.MONTO_COMISION != original.MONTO_COMISION) return true;
			
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
		/// Gets or sets the <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</value>
		public decimal CTACTE_PLAN_DESEMBOLSO_ID
		{
			get { return _ctacte_plan_desembolso_id; }
			set { _ctacte_plan_desembolso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESDE</c> column value.</value>
		public decimal MONTO_DESDE
		{
			get
			{
				if(IsMONTO_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_desde;
			}
			set
			{
				_monto_desdeNull = false;
				_monto_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESDENull
		{
			get { return _monto_desdeNull; }
			set { _monto_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_HASTA</c> column value.</value>
		public decimal MONTO_HASTA
		{
			get
			{
				if(IsMONTO_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_hasta;
			}
			set
			{
				_monto_hastaNull = false;
				_monto_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_HASTANull
		{
			get { return _monto_hastaNull; }
			set { _monto_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION</c> column value.</value>
		public decimal PORCENTAJE_COMISION
		{
			get
			{
				if(IsPORCENTAJE_COMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_comision;
			}
			set
			{
				_porcentaje_comisionNull = false;
				_porcentaje_comision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_COMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_COMISIONNull
		{
			get { return _porcentaje_comisionNull; }
			set { _porcentaje_comisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COMISION</c> column value.</value>
		public decimal MONTO_COMISION
		{
			get
			{
				if(IsMONTO_COMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_comision;
			}
			set
			{
				_monto_comisionNull = false;
				_monto_comision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COMISIONNull
		{
			get { return _monto_comisionNull; }
			set { _monto_comisionNull = value; }
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
			dynStr.Append("@CBA@CTACTE_PLAN_DESEMBOLSO_ID=");
			dynStr.Append(CTACTE_PLAN_DESEMBOLSO_ID);
			dynStr.Append("@CBA@MONTO_DESDE=");
			dynStr.Append(IsMONTO_DESDENull ? (object)"<NULL>" : MONTO_DESDE);
			dynStr.Append("@CBA@MONTO_HASTA=");
			dynStr.Append(IsMONTO_HASTANull ? (object)"<NULL>" : MONTO_HASTA);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(IsPORCENTAJE_COMISIONNull ? (object)"<NULL>" : PORCENTAJE_COMISION);
			dynStr.Append("@CBA@MONTO_COMISION=");
			dynStr.Append(IsMONTO_COMISIONNull ? (object)"<NULL>" : MONTO_COMISION);
			return dynStr.ToString();
		}
	} // End of CTACTE_PLANES_DESEM_ESCALASRow_Base class
} // End of namespace
