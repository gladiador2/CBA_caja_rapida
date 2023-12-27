// <fileinfo name="APLICACION_DOCUMEN_DOC_RECARGORow_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMEN_DOC_RECARGORow"/> that 
	/// represents a record in the <c>APLICACION_DOCUMEN_DOC_RECARGO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="APLICACION_DOCUMEN_DOC_RECARGORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMEN_DOC_RECARGORow_Base
	{
		private decimal _id;
		private decimal _tipo_recargo;
		private decimal _aplicacion_documento_doc_id;
		private bool _aplicacion_documento_doc_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _monto;
		private decimal _ctacte_concepto_id;
		private decimal _impuesto_id;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMEN_DOC_RECARGORow_Base"/> class.
		/// </summary>
		public APLICACION_DOCUMEN_DOC_RECARGORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(APLICACION_DOCUMEN_DOC_RECARGORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_RECARGO != original.TIPO_RECARGO) return true;
			if (this.IsAPLICACION_DOCUMENTO_DOC_IDNull != original.IsAPLICACION_DOCUMENTO_DOC_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTO_DOC_IDNull && !original.IsAPLICACION_DOCUMENTO_DOC_IDNull)
				if (this.APLICACION_DOCUMENTO_DOC_ID != original.APLICACION_DOCUMENTO_DOC_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>TIPO_RECARGO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_RECARGO</c> column value.</value>
		public decimal TIPO_RECARGO
		{
			get { return _tipo_recargo; }
			set { _tipo_recargo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_DOC_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTO_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documento_doc_id;
			}
			set
			{
				_aplicacion_documento_doc_idNull = false;
				_aplicacion_documento_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTO_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTO_DOC_IDNull
		{
			get { return _aplicacion_documento_doc_idNull; }
			set { _aplicacion_documento_doc_idNull = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>CTACTE_CONCEPTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONCEPTO_ID</c> column value.</value>
		public decimal CTACTE_CONCEPTO_ID
		{
			get { return _ctacte_concepto_id; }
			set { _ctacte_concepto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TIPO_RECARGO=");
			dynStr.Append(TIPO_RECARGO);
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_DOC_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTO_DOC_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTO_DOC_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_ID=");
			dynStr.Append(CTACTE_CONCEPTO_ID);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of APLICACION_DOCUMEN_DOC_RECARGORow_Base class
} // End of namespace
