// <fileinfo name="LINEA_CREDITO_PEDIDO_PENDIENTERow_Base.cs">
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
	/// The base class for <see cref="LINEA_CREDITO_PEDIDO_PENDIENTERow"/> that 
	/// represents a record in the <c>LINEA_CREDITO_PEDIDO_PENDIENTE</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LINEA_CREDITO_PEDIDO_PENDIENTERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEA_CREDITO_PEDIDO_PENDIENTERow_Base
	{
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _cotizacion_destino;
		private bool _cotizacion_destinoNull = true;
		private decimal _moneda_destino_id;
		private bool _moneda_destino_idNull = true;
		private decimal _pendiente;
		private bool _pendienteNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEA_CREDITO_PEDIDO_PENDIENTERow_Base"/> class.
		/// </summary>
		public LINEA_CREDITO_PEDIDO_PENDIENTERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LINEA_CREDITO_PEDIDO_PENDIENTERow_Base original)
		{
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsCOTIZACION_DESTINONull != original.IsCOTIZACION_DESTINONull) return true;
			if (!this.IsCOTIZACION_DESTINONull && !original.IsCOTIZACION_DESTINONull)
				if (this.COTIZACION_DESTINO != original.COTIZACION_DESTINO) return true;
			if (this.IsMONEDA_DESTINO_IDNull != original.IsMONEDA_DESTINO_IDNull) return true;
			if (!this.IsMONEDA_DESTINO_IDNull && !original.IsMONEDA_DESTINO_IDNull)
				if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.IsPENDIENTENull != original.IsPENDIENTENull) return true;
			if (!this.IsPENDIENTENull && !original.IsPENDIENTENull)
				if (this.PENDIENTE != original.PENDIENTE) return true;
			
			return false;
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
		/// Gets or sets the <c>COTIZACION_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_DESTINO</c> column value.</value>
		public decimal COTIZACION_DESTINO
		{
			get
			{
				if(IsCOTIZACION_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_destino;
			}
			set
			{
				_cotizacion_destinoNull = false;
				_cotizacion_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_DESTINONull
		{
			get { return _cotizacion_destinoNull; }
			set { _cotizacion_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get
			{
				if(IsMONEDA_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_destino_id;
			}
			set
			{
				_moneda_destino_idNull = false;
				_moneda_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_DESTINO_IDNull
		{
			get { return _moneda_destino_idNull; }
			set { _moneda_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PENDIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PENDIENTE</c> column value.</value>
		public decimal PENDIENTE
		{
			get
			{
				if(IsPENDIENTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pendiente;
			}
			set
			{
				_pendienteNull = false;
				_pendiente = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PENDIENTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPENDIENTENull
		{
			get { return _pendienteNull; }
			set { _pendienteNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@COTIZACION_DESTINO=");
			dynStr.Append(IsCOTIZACION_DESTINONull ? (object)"<NULL>" : COTIZACION_DESTINO);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(IsMONEDA_DESTINO_IDNull ? (object)"<NULL>" : MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@PENDIENTE=");
			dynStr.Append(IsPENDIENTENull ? (object)"<NULL>" : PENDIENTE);
			return dynStr.ToString();
		}
	} // End of LINEA_CREDITO_PEDIDO_PENDIENTERow_Base class
} // End of namespace
