// <fileinfo name="EGRESOS_VARIOS_CAJA_DETRow_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> that 
	/// represents a record in the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EGRESOS_VARIOS_CAJA_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJA_DETRow_Base
	{
		private decimal _id;
		private decimal _egreso_vario_caja_id;
		private decimal _ctacte_proveedor_id;
		private bool _ctacte_proveedor_idNull = true;
		private decimal _moneda_origen_id;
		private decimal _cotizacion_compra_origen;
		private decimal _monto_origen;
		private decimal _monto_destino;
		private string _observacion;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJA_DETRow_Base"/> class.
		/// </summary>
		public EGRESOS_VARIOS_CAJA_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EGRESOS_VARIOS_CAJA_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.IsCTACTE_PROVEEDOR_IDNull != original.IsCTACTE_PROVEEDOR_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_IDNull && !original.IsCTACTE_PROVEEDOR_IDNull)
				if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.COTIZACION_COMPRA_ORIGEN != original.COTIZACION_COMPRA_ORIGEN) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			
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
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_ID</c> column value.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_ID</c> column value.</value>
		public decimal EGRESO_VARIO_CAJA_ID
		{
			get { return _egreso_vario_caja_id; }
			set { _egreso_vario_caja_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_id;
			}
			set
			{
				_ctacte_proveedor_idNull = false;
				_ctacte_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_IDNull
		{
			get { return _ctacte_proveedor_idNull; }
			set { _ctacte_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_COMPRA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_COMPRA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_COMPRA_ORIGEN
		{
			get { return _cotizacion_compra_origen; }
			set { _cotizacion_compra_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get { return _monto_destino; }
			set { _monto_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
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
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
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
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_COMPRA_ORIGEN=");
			dynStr.Append(COTIZACION_COMPRA_ORIGEN);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of EGRESOS_VARIOS_CAJA_DETRow_Base class
} // End of namespace
