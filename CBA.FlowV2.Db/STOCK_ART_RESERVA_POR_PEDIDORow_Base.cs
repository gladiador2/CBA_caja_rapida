// <fileinfo name="STOCK_ART_RESERVA_POR_PEDIDORow_Base.cs">
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
	/// The base class for <see cref="STOCK_ART_RESERVA_POR_PEDIDORow"/> that 
	/// represents a record in the <c>STOCK_ART_RESERVA_POR_PEDIDO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_ART_RESERVA_POR_PEDIDORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_ART_RESERVA_POR_PEDIDORow_Base
	{
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito;
		private decimal _caso_id;
		private string _nro_comprobante;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_codigo;
		private string _persona;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _lote;
		private decimal _articulo_id;
		private decimal _cantidad_total_entregada;
		private bool _cantidad_total_entregadaNull = true;
		private string _unidad_destino;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ART_RESERVA_POR_PEDIDORow_Base"/> class.
		/// </summary>
		public STOCK_ART_RESERVA_POR_PEDIDORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_ART_RESERVA_POR_PEDIDORow_Base original)
		{
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL != original.SUCURSAL) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO != original.DEPOSITO) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA != original.PERSONA) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsCANTIDAD_TOTAL_ENTREGADANull != original.IsCANTIDAD_TOTAL_ENTREGADANull) return true;
			if (!this.IsCANTIDAD_TOTAL_ENTREGADANull && !original.IsCANTIDAD_TOTAL_ENTREGADANull)
				if (this.CANTIDAD_TOTAL_ENTREGADA != original.CANTIDAD_TOTAL_ENTREGADA) return true;
			if (this.UNIDAD_DESTINO != original.UNIDAD_DESTINO) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA</c> column value.</value>
		public string PERSONA
		{
			get { return _persona; }
			set { _persona = value; }
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
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
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
		/// Gets or sets the <c>CANTIDAD_TOTAL_ENTREGADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL_ENTREGADA</c> column value.</value>
		public decimal CANTIDAD_TOTAL_ENTREGADA
		{
			get
			{
				if(IsCANTIDAD_TOTAL_ENTREGADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_total_entregada;
			}
			set
			{
				_cantidad_total_entregadaNull = false;
				_cantidad_total_entregada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_TOTAL_ENTREGADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_TOTAL_ENTREGADANull
		{
			get { return _cantidad_total_entregadaNull; }
			set { _cantidad_total_entregadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO</c> column value.</value>
		public string UNIDAD_DESTINO
		{
			get { return _unidad_destino; }
			set { _unidad_destino = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA=");
			dynStr.Append(PERSONA);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD_TOTAL_ENTREGADA=");
			dynStr.Append(IsCANTIDAD_TOTAL_ENTREGADANull ? (object)"<NULL>" : CANTIDAD_TOTAL_ENTREGADA);
			dynStr.Append("@CBA@UNIDAD_DESTINO=");
			dynStr.Append(UNIDAD_DESTINO);
			return dynStr.ToString();
		}
	} // End of STOCK_ART_RESERVA_POR_PEDIDORow_Base class
} // End of namespace
