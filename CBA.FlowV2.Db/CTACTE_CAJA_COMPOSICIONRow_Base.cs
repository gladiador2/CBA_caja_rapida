// <fileinfo name="CTACTE_CAJA_COMPOSICIONRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJA_COMPOSICIONRow"/> that 
	/// represents a record in the <c>CTACTE_CAJA_COMPOSICION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJA_COMPOSICIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJA_COMPOSICIONRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private System.DateTime _fecha;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJA_COMPOSICIONRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJA_COMPOSICIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJA_COMPOSICIONRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJA_COMPOSICIONRow_Base class
} // End of namespace
