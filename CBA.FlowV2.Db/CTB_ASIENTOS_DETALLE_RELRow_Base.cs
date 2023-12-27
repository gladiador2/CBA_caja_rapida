// <fileinfo name="CTB_ASIENTOS_DETALLE_RELRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_DETALLE_RELRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DETALLE_RELRow_Base
	{
		private decimal _id;
		private decimal _ctb_asientos_detalle;
		private string _tabla_relacionada_id;
		private decimal _registro_relacionado_id;
		private bool _registro_relacionado_idNull = true;
		private decimal _monto;
		private bool _montoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DETALLE_RELRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_DETALLE_RELRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_DETALLE_RELRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTOS_DETALLE != original.CTB_ASIENTOS_DETALLE) return true;
			if (this.TABLA_RELACIONADA_ID != original.TABLA_RELACIONADA_ID) return true;
			if (this.IsREGISTRO_RELACIONADO_IDNull != original.IsREGISTRO_RELACIONADO_IDNull) return true;
			if (!this.IsREGISTRO_RELACIONADO_IDNull && !original.IsREGISTRO_RELACIONADO_IDNull)
				if (this.REGISTRO_RELACIONADO_ID != original.REGISTRO_RELACIONADO_ID) return true;
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
		/// Gets or sets the <c>CTB_ASIENTOS_DETALLE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTOS_DETALLE</c> column value.</value>
		public decimal CTB_ASIENTOS_DETALLE
		{
			get { return _ctb_asientos_detalle; }
			set { _ctb_asientos_detalle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_RELACIONADA_ID</c> column value.</value>
		public string TABLA_RELACIONADA_ID
		{
			get { return _tabla_relacionada_id; }
			set { _tabla_relacionada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO_RELACIONADO_ID</c> column value.</value>
		public decimal REGISTRO_RELACIONADO_ID
		{
			get
			{
				if(IsREGISTRO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _registro_relacionado_id;
			}
			set
			{
				_registro_relacionado_idNull = false;
				_registro_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGISTRO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGISTRO_RELACIONADO_IDNull
		{
			get { return _registro_relacionado_idNull; }
			set { _registro_relacionado_idNull = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTOS_DETALLE=");
			dynStr.Append(CTB_ASIENTOS_DETALLE);
			dynStr.Append("@CBA@TABLA_RELACIONADA_ID=");
			dynStr.Append(TABLA_RELACIONADA_ID);
			dynStr.Append("@CBA@REGISTRO_RELACIONADO_ID=");
			dynStr.Append(IsREGISTRO_RELACIONADO_IDNull ? (object)"<NULL>" : REGISTRO_RELACIONADO_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_DETALLE_RELRow_Base class
} // End of namespace
