// <fileinfo name="ARTICULOS_COSTOSRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COSTOSRow"/> that 
	/// represents a record in the <c>ARTICULOS_COSTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COSTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COSTOSRow_Base
	{
		private decimal _id;
		private decimal _lote_id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _cantidad_inicial;
		private decimal _cantidad_restante;
		private decimal _moneda_id;
		private decimal _costo;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _cotizacion;
		private decimal _costo_ponderado;
		private bool _costo_ponderadoNull = true;
		private string _ajuste_manual;
		private System.DateTime _fecha_insercion;
		private bool _fecha_insercionNull = true;
		private decimal _cantidad_rest_fecha_insercion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOSRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COSTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COSTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CANTIDAD_INICIAL != original.CANTIDAD_INICIAL) return true;
			if (this.CANTIDAD_RESTANTE != original.CANTIDAD_RESTANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COSTO != original.COSTO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsCOSTO_PONDERADONull != original.IsCOSTO_PONDERADONull) return true;
			if (!this.IsCOSTO_PONDERADONull && !original.IsCOSTO_PONDERADONull)
				if (this.COSTO_PONDERADO != original.COSTO_PONDERADO) return true;
			if (this.AJUSTE_MANUAL != original.AJUSTE_MANUAL) return true;
			if (this.IsFECHA_INSERCIONNull != original.IsFECHA_INSERCIONNull) return true;
			if (!this.IsFECHA_INSERCIONNull && !original.IsFECHA_INSERCIONNull)
				if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.CANTIDAD_REST_FECHA_INSERCION != original.CANTIDAD_REST_FECHA_INSERCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_INICIAL</c> column value.</value>
		public decimal CANTIDAD_INICIAL
		{
			get { return _cantidad_inicial; }
			set { _cantidad_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_RESTANTE</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_RESTANTE</c> column value.</value>
		public decimal CANTIDAD_RESTANTE
		{
			get { return _cantidad_restante; }
			set { _cantidad_restante = value; }
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
		/// Gets or sets the <c>COSTO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get { return _costo; }
			set { _costo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_PONDERADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_PONDERADO</c> column value.</value>
		public decimal COSTO_PONDERADO
		{
			get
			{
				if(IsCOSTO_PONDERADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_ponderado;
			}
			set
			{
				_costo_ponderadoNull = false;
				_costo_ponderado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_PONDERADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_PONDERADONull
		{
			get { return _costo_ponderadoNull; }
			set { _costo_ponderadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTE_MANUAL</c> column value.
		/// </summary>
		/// <value>The <c>AJUSTE_MANUAL</c> column value.</value>
		public string AJUSTE_MANUAL
		{
			get { return _ajuste_manual; }
			set { _ajuste_manual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get
			{
				if(IsFECHA_INSERCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_insercion;
			}
			set
			{
				_fecha_insercionNull = false;
				_fecha_insercion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INSERCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INSERCIONNull
		{
			get { return _fecha_insercionNull; }
			set { _fecha_insercionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_REST_FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_REST_FECHA_INSERCION</c> column value.</value>
		public decimal CANTIDAD_REST_FECHA_INSERCION
		{
			get { return _cantidad_rest_fecha_insercion; }
			set { _cantidad_rest_fecha_insercion = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CANTIDAD_INICIAL=");
			dynStr.Append(CANTIDAD_INICIAL);
			dynStr.Append("@CBA@CANTIDAD_RESTANTE=");
			dynStr.Append(CANTIDAD_RESTANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(COSTO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@COSTO_PONDERADO=");
			dynStr.Append(IsCOSTO_PONDERADONull ? (object)"<NULL>" : COSTO_PONDERADO);
			dynStr.Append("@CBA@AJUSTE_MANUAL=");
			dynStr.Append(AJUSTE_MANUAL);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(IsFECHA_INSERCIONNull ? (object)"<NULL>" : FECHA_INSERCION);
			dynStr.Append("@CBA@CANTIDAD_REST_FECHA_INSERCION=");
			dynStr.Append(CANTIDAD_REST_FECHA_INSERCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COSTOSRow_Base class
} // End of namespace
