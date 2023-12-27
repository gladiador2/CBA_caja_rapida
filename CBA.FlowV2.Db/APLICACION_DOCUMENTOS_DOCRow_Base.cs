// <fileinfo name="APLICACION_DOCUMENTOS_DOCRow_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMENTOS_DOCRow"/> that 
	/// represents a record in the <c>APLICACION_DOCUMENTOS_DOC</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="APLICACION_DOCUMENTOS_DOCRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMENTOS_DOCRow_Base
	{
		private decimal _id;
		private decimal _aplicacion_documento_id;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _monto_origen;
		private decimal _monto_destino;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _aplicacion_docu_doc_referid_id;
		private bool _aplicacion_docu_doc_referid_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOS_DOCRow_Base"/> class.
		/// </summary>
		public APLICACION_DOCUMENTOS_DOCRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(APLICACION_DOCUMENTOS_DOCRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.APLICACION_DOCUMENTO_ID != original.APLICACION_DOCUMENTO_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsAPLICACION_DOCU_DOC_REFERID_IDNull != original.IsAPLICACION_DOCU_DOC_REFERID_IDNull) return true;
			if (!this.IsAPLICACION_DOCU_DOC_REFERID_IDNull && !original.IsAPLICACION_DOCU_DOC_REFERID_IDNull)
				if (this.APLICACION_DOCU_DOC_REFERID_ID != original.APLICACION_DOCU_DOC_REFERID_ID) return true;
			
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
		/// Gets or sets the <c>APLICACION_DOCUMENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_ID
		{
			get { return _aplicacion_documento_id; }
			set { _aplicacion_documento_id = value; }
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
		/// Gets or sets the <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</value>
		public decimal APLICACION_DOCU_DOC_REFERID_ID
		{
			get
			{
				if(IsAPLICACION_DOCU_DOC_REFERID_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_docu_doc_referid_id;
			}
			set
			{
				_aplicacion_docu_doc_referid_idNull = false;
				_aplicacion_docu_doc_referid_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCU_DOC_REFERID_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCU_DOC_REFERID_IDNull
		{
			get { return _aplicacion_docu_doc_referid_idNull; }
			set { _aplicacion_docu_doc_referid_idNull = value; }
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
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_ID=");
			dynStr.Append(APLICACION_DOCUMENTO_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@APLICACION_DOCU_DOC_REFERID_ID=");
			dynStr.Append(IsAPLICACION_DOCU_DOC_REFERID_IDNull ? (object)"<NULL>" : APLICACION_DOCU_DOC_REFERID_ID);
			return dynStr.ToString();
		}
	} // End of APLICACION_DOCUMENTOS_DOCRow_Base class
} // End of namespace
