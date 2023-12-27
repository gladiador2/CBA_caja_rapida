// <fileinfo name="OBJ_VEND_CLIE_DETALLERow_Base.cs">
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
	/// The base class for <see cref="OBJ_VEND_CLIE_DETALLERow"/> that 
	/// represents a record in the <c>OBJ_VEND_CLIE_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OBJ_VEND_CLIE_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJ_VEND_CLIE_DETALLERow_Base
	{
		private decimal _id;
		private decimal _objetivo_vendedor_cliente_id;
		private bool _objetivo_vendedor_cliente_idNull = true;
		private decimal _cliente_id;
		private bool _cliente_idNull = true;
		private decimal _vendedor_id;
		private bool _vendedor_idNull = true;
		private decimal _monto;
		private bool _montoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJ_VEND_CLIE_DETALLERow_Base"/> class.
		/// </summary>
		public OBJ_VEND_CLIE_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OBJ_VEND_CLIE_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull != original.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull) return true;
			if (!this.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull && !original.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull)
				if (this.OBJETIVO_VENDEDOR_CLIENTE_ID != original.OBJETIVO_VENDEDOR_CLIENTE_ID) return true;
			if (this.IsCLIENTE_IDNull != original.IsCLIENTE_IDNull) return true;
			if (!this.IsCLIENTE_IDNull && !original.IsCLIENTE_IDNull)
				if (this.CLIENTE_ID != original.CLIENTE_ID) return true;
			if (this.IsVENDEDOR_IDNull != original.IsVENDEDOR_IDNull) return true;
			if (!this.IsVENDEDOR_IDNull && !original.IsVENDEDOR_IDNull)
				if (this.VENDEDOR_ID != original.VENDEDOR_ID) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
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
		/// Gets or sets the <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</value>
		public decimal OBJETIVO_VENDEDOR_CLIENTE_ID
		{
			get
			{
				if(IsOBJETIVO_VENDEDOR_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _objetivo_vendedor_cliente_id;
			}
			set
			{
				_objetivo_vendedor_cliente_idNull = false;
				_objetivo_vendedor_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="OBJETIVO_VENDEDOR_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsOBJETIVO_VENDEDOR_CLIENTE_IDNull
		{
			get { return _objetivo_vendedor_cliente_idNull; }
			set { _objetivo_vendedor_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE_ID</c> column value.</value>
		public decimal CLIENTE_ID
		{
			get
			{
				if(IsCLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cliente_id;
			}
			set
			{
				_cliente_idNull = false;
				_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCLIENTE_IDNull
		{
			get { return _cliente_idNull; }
			set { _cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_ID</c> column value.</value>
		public decimal VENDEDOR_ID
		{
			get
			{
				if(IsVENDEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_id;
			}
			set
			{
				_vendedor_idNull = false;
				_vendedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_IDNull
		{
			get { return _vendedor_idNull; }
			set { _vendedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
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
			dynStr.Append("@CBA@OBJETIVO_VENDEDOR_CLIENTE_ID=");
			dynStr.Append(IsOBJETIVO_VENDEDOR_CLIENTE_IDNull ? (object)"<NULL>" : OBJETIVO_VENDEDOR_CLIENTE_ID);
			dynStr.Append("@CBA@CLIENTE_ID=");
			dynStr.Append(IsCLIENTE_IDNull ? (object)"<NULL>" : CLIENTE_ID);
			dynStr.Append("@CBA@VENDEDOR_ID=");
			dynStr.Append(IsVENDEDOR_IDNull ? (object)"<NULL>" : VENDEDOR_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			return dynStr.ToString();
		}
	} // End of OBJ_VEND_CLIE_DETALLERow_Base class
} // End of namespace
