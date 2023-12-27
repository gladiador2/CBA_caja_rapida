// <fileinfo name="STOCK_ART_RESERVA_POR_TRANSFERRow_Base.cs">
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
	/// The base class for <see cref="STOCK_ART_RESERVA_POR_TRANSFERRow"/> that 
	/// represents a record in the <c>STOCK_ART_RESERVA_POR_TRANSFER</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_ART_RESERVA_POR_TRANSFERRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_ART_RESERVA_POR_TRANSFERRow_Base
	{
		private decimal _sucursal_origen_id;
		private string _sucursal_origen;
		private decimal _deposito_origen_id;
		private string _deposito_origen;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _comprobante;
		private decimal _sucursal_destino_id;
		private string _sucursal_destino;
		private decimal _deposito_destino_id;
		private string _deposito_destino;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _lote;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _cantidad_unitaria_dest_total;
		private bool _cantidad_unitaria_dest_totalNull = true;
		private string _unidad_medida_destino_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ART_RESERVA_POR_TRANSFERRow_Base"/> class.
		/// </summary>
		public STOCK_ART_RESERVA_POR_TRANSFERRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_ART_RESERVA_POR_TRANSFERRow_Base original)
		{
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_ORIGEN != original.SUCURSAL_ORIGEN) return true;
			if (this.DEPOSITO_ORIGEN_ID != original.DEPOSITO_ORIGEN_ID) return true;
			if (this.DEPOSITO_ORIGEN != original.DEPOSITO_ORIGEN) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.COMPROBANTE != original.COMPROBANTE) return true;
			if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSAL_DESTINO != original.SUCURSAL_DESTINO) return true;
			if (this.DEPOSITO_DESTINO_ID != original.DEPOSITO_DESTINO_ID) return true;
			if (this.DEPOSITO_DESTINO != original.DEPOSITO_DESTINO) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsCANTIDAD_UNITARIA_DEST_TOTALNull != original.IsCANTIDAD_UNITARIA_DEST_TOTALNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_DEST_TOTALNull && !original.IsCANTIDAD_UNITARIA_DEST_TOTALNull)
				if (this.CANTIDAD_UNITARIA_DEST_TOTAL != original.CANTIDAD_UNITARIA_DEST_TOTAL) return true;
			if (this.UNIDAD_MEDIDA_DESTINO_ID != original.UNIDAD_MEDIDA_DESTINO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN</c> column value.</value>
		public string SUCURSAL_ORIGEN
		{
			get { return _sucursal_origen; }
			set { _sucursal_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ORIGEN_ID</c> column value.</value>
		public decimal DEPOSITO_ORIGEN_ID
		{
			get { return _deposito_origen_id; }
			set { _deposito_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ORIGEN</c> column value.</value>
		public string DEPOSITO_ORIGEN
		{
			get { return _deposito_origen; }
			set { _deposito_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMPROBANTE</c> column value.</value>
		public string COMPROBANTE
		{
			get { return _comprobante; }
			set { _comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get { return _sucursal_destino_id; }
			set { _sucursal_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO</c> column value.</value>
		public string SUCURSAL_DESTINO
		{
			get { return _sucursal_destino; }
			set { _sucursal_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_DESTINO_ID</c> column value.</value>
		public decimal DEPOSITO_DESTINO_ID
		{
			get { return _deposito_destino_id; }
			set { _deposito_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_DESTINO</c> column value.</value>
		public string DEPOSITO_DESTINO
		{
			get { return _deposito_destino; }
			set { _deposito_destino = value; }
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_DEST_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_DEST_TOTAL</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_DEST_TOTAL
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_DEST_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_dest_total;
			}
			set
			{
				_cantidad_unitaria_dest_totalNull = false;
				_cantidad_unitaria_dest_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_DEST_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_DEST_TOTALNull
		{
			get { return _cantidad_unitaria_dest_totalNull; }
			set { _cantidad_unitaria_dest_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_DESTINO_ID
		{
			get { return _unidad_medida_destino_id; }
			set { _unidad_medida_destino_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN=");
			dynStr.Append(SUCURSAL_ORIGEN);
			dynStr.Append("@CBA@DEPOSITO_ORIGEN_ID=");
			dynStr.Append(DEPOSITO_ORIGEN_ID);
			dynStr.Append("@CBA@DEPOSITO_ORIGEN=");
			dynStr.Append(DEPOSITO_ORIGEN);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@COMPROBANTE=");
			dynStr.Append(COMPROBANTE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO=");
			dynStr.Append(SUCURSAL_DESTINO);
			dynStr.Append("@CBA@DEPOSITO_DESTINO_ID=");
			dynStr.Append(DEPOSITO_DESTINO_ID);
			dynStr.Append("@CBA@DEPOSITO_DESTINO=");
			dynStr.Append(DEPOSITO_DESTINO);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_DEST_TOTAL=");
			dynStr.Append(IsCANTIDAD_UNITARIA_DEST_TOTALNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_DEST_TOTAL);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESTINO_ID=");
			dynStr.Append(UNIDAD_MEDIDA_DESTINO_ID);
			return dynStr.ToString();
		}
	} // End of STOCK_ART_RESERVA_POR_TRANSFERRow_Base class
} // End of namespace
