// <fileinfo name="STOCK_ART_RESERVA_PEDIDORow_Base.cs">
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
	/// The base class for <see cref="STOCK_ART_RESERVA_PEDIDORow"/> that 
	/// represents a record in the <c>STOCK_ART_RESERVA_PEDIDO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_ART_RESERVA_PEDIDORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_ART_RESERVA_PEDIDORow_Base
	{
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _articulo_id;
		private decimal _reservado;
		private bool _reservadoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ART_RESERVA_PEDIDORow_Base"/> class.
		/// </summary>
		public STOCK_ART_RESERVA_PEDIDORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_ART_RESERVA_PEDIDORow_Base original)
		{
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL != original.SUCURSAL) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO != original.DEPOSITO) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsRESERVADONull != original.IsRESERVADONull) return true;
			if (!this.IsRESERVADONull && !original.IsRESERVADONull)
				if (this.RESERVADO != original.RESERVADO) return true;
			
			return false;
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
		/// Gets or sets the <c>SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL</c> column value.</value>
		public string SUCURSAL
		{
			get { return _sucursal; }
			set { _sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO</c> column value.</value>
		public string DEPOSITO
		{
			get { return _deposito; }
			set { _deposito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO</c> column value.</value>
		public decimal RESERVADO
		{
			get
			{
				if(IsRESERVADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado;
			}
			set
			{
				_reservadoNull = false;
				_reservado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADONull
		{
			get { return _reservadoNull; }
			set { _reservadoNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL=");
			dynStr.Append(SUCURSAL);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO=");
			dynStr.Append(DEPOSITO);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@RESERVADO=");
			dynStr.Append(IsRESERVADONull ? (object)"<NULL>" : RESERVADO);
			return dynStr.ToString();
		}
	} // End of STOCK_ART_RESERVA_PEDIDORow_Base class
} // End of namespace
