// <fileinfo name="PROMOCIONES_PARAMETROSRow_Base.cs">
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
	/// The base class for <see cref="PROMOCIONES_PARAMETROSRow"/> that 
	/// represents a record in the <c>PROMOCIONES_PARAMETROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PROMOCIONES_PARAMETROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROMOCIONES_PARAMETROSRow_Base
	{
		private decimal _id;
		private decimal _texto_predefinido_id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _valor_minimo;
		private bool _valor_minimoNull = true;
		private decimal _lista_precio_id_destino;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROMOCIONES_PARAMETROSRow_Base"/> class.
		/// </summary>
		public PROMOCIONES_PARAMETROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PROMOCIONES_PARAMETROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsVALOR_MINIMONull != original.IsVALOR_MINIMONull) return true;
			if (!this.IsVALOR_MINIMONull && !original.IsVALOR_MINIMONull)
				if (this.VALOR_MINIMO != original.VALOR_MINIMO) return true;
			if (this.LISTA_PRECIO_ID_DESTINO != original.LISTA_PRECIO_ID_DESTINO) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
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
		/// Gets or sets the <c>VALOR_MINIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_MINIMO</c> column value.</value>
		public decimal VALOR_MINIMO
		{
			get
			{
				if(IsVALOR_MINIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_minimo;
			}
			set
			{
				_valor_minimoNull = false;
				_valor_minimo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_MINIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_MINIMONull
		{
			get { return _valor_minimoNull; }
			set { _valor_minimoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_ID_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID_DESTINO</c> column value.</value>
		public decimal LISTA_PRECIO_ID_DESTINO
		{
			get { return _lista_precio_id_destino; }
			set { _lista_precio_id_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@VALOR_MINIMO=");
			dynStr.Append(IsVALOR_MINIMONull ? (object)"<NULL>" : VALOR_MINIMO);
			dynStr.Append("@CBA@LISTA_PRECIO_ID_DESTINO=");
			dynStr.Append(LISTA_PRECIO_ID_DESTINO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			return dynStr.ToString();
		}
	} // End of PROMOCIONES_PARAMETROSRow_Base class
} // End of namespace
