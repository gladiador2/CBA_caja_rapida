// <fileinfo name="FUNCIONARIOS_LIQUIDACIONES_DETRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_LIQUIDACIONES_DETRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_LIQUIDACIONES_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_LIQUIDACIONES_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_LIQUIDACIONES_DETRow_Base
	{
		private decimal _id;
		private decimal _funcionarios_liquidaciones_id;
		private decimal _tipo_item;
		private bool _tipo_itemNull = true;
		private decimal _item_id;
		private bool _item_idNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQUIDACIONES_DETRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_LIQUIDACIONES_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_LIQUIDACIONES_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIOS_LIQUIDACIONES_ID != original.FUNCIONARIOS_LIQUIDACIONES_ID) return true;
			if (this.IsTIPO_ITEMNull != original.IsTIPO_ITEMNull) return true;
			if (!this.IsTIPO_ITEMNull && !original.IsTIPO_ITEMNull)
				if (this.TIPO_ITEM != original.TIPO_ITEM) return true;
			if (this.IsITEM_IDNull != original.IsITEM_IDNull) return true;
			if (!this.IsITEM_IDNull && !original.IsITEM_IDNull)
				if (this.ITEM_ID != original.ITEM_ID) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIOS_LIQUIDACIONES_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIOS_LIQUIDACIONES_ID</c> column value.</value>
		public decimal FUNCIONARIOS_LIQUIDACIONES_ID
		{
			get { return _funcionarios_liquidaciones_id; }
			set { _funcionarios_liquidaciones_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ITEM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ITEM</c> column value.</value>
		public decimal TIPO_ITEM
		{
			get
			{
				if(IsTIPO_ITEMNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_item;
			}
			set
			{
				_tipo_itemNull = false;
				_tipo_item = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_ITEM"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_ITEMNull
		{
			get { return _tipo_itemNull; }
			set { _tipo_itemNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ITEM_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEM_ID</c> column value.</value>
		public decimal ITEM_ID
		{
			get
			{
				if(IsITEM_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _item_id;
			}
			set
			{
				_item_idNull = false;
				_item_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEM_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEM_IDNull
		{
			get { return _item_idNull; }
			set { _item_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
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
			dynStr.Append("@CBA@FUNCIONARIOS_LIQUIDACIONES_ID=");
			dynStr.Append(FUNCIONARIOS_LIQUIDACIONES_ID);
			dynStr.Append("@CBA@TIPO_ITEM=");
			dynStr.Append(IsTIPO_ITEMNull ? (object)"<NULL>" : TIPO_ITEM);
			dynStr.Append("@CBA@ITEM_ID=");
			dynStr.Append(IsITEM_IDNull ? (object)"<NULL>" : ITEM_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_LIQUIDACIONES_DETRow_Base class
} // End of namespace
