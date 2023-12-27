// <fileinfo name="CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PER_COMPEN_ENTRADRow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PER_COMPEN_ENTRAD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PER_COMPEN_ENTRADRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagos_persona_doc_id;
		private bool _ctacte_pagos_persona_doc_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_pagos_persona_id;
		private decimal _ctacte_pago_persona_recargo_id;
		private bool _ctacte_pago_persona_recargo_idNull = true;
		private decimal _moneda_id;
		private decimal _monto;
		private decimal _cotizacion_moneda;
		private string _observacion;
		private string _estado;
		private System.DateTime _fecha_creacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_PAGOS_PERSONA_DOC_IDNull != original.IsCTACTE_PAGOS_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGOS_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGOS_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGOS_PERSONA_DOC_ID != original.CTACTE_PAGOS_PERSONA_DOC_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.CTACTE_PAGOS_PERSONA_ID != original.CTACTE_PAGOS_PERSONA_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull != original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && !original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
				if (this.CTACTE_PAGO_PERSONA_RECARGO_ID != original.CTACTE_PAGO_PERSONA_RECARGO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			
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
		/// Gets or sets the <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGOS_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagos_persona_doc_id;
			}
			set
			{
				_ctacte_pagos_persona_doc_idNull = false;
				_ctacte_pagos_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGOS_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGOS_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pagos_persona_doc_idNull; }
			set { _ctacte_pagos_persona_doc_idNull = value; }
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
		/// Gets or sets the <c>CTACTE_PAGOS_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_ID
		{
			get { return _ctacte_pagos_persona_id; }
			set { _ctacte_pagos_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_RECARGO_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_recargo_id;
			}
			set
			{
				_ctacte_pago_persona_recargo_idNull = false;
				_ctacte_pago_persona_recargo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_RECARGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_RECARGO_IDNull
		{
			get { return _ctacte_pago_persona_recargo_idNull; }
			set { _ctacte_pago_persona_recargo_idNull = value; }
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGOS_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGOS_PERSONA_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_ID=");
			dynStr.Append(CTACTE_PAGOS_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_RECARGO_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_RECARGO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PER_COMPEN_ENTRADRow_Base class
} // End of namespace
