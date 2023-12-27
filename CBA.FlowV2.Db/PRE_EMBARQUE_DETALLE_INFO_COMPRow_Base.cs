// <fileinfo name="PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> that 
	/// represents a record in the <c>PRE_EMBARQUE_DETALLE_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _pre_embarque_id;
		private string _numero;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _person_nombre;
		private string _persona_numero_documento;
		private string _despacho_numero;
		private System.DateTime _despacho_fecha;
		private bool _despacho_fechaNull = true;
		private string _factura_pagado;
		private string _factura_numero;
		private string _bl;
		private string _observaciones;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base"/> class.
		/// </summary>
		public PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRE_EMBARQUE_ID != original.PRE_EMBARQUE_ID) return true;
			if (this.NUMERO != original.NUMERO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSON_NOMBRE != original.PERSON_NOMBRE) return true;
			if (this.PERSONA_NUMERO_DOCUMENTO != original.PERSONA_NUMERO_DOCUMENTO) return true;
			if (this.DESPACHO_NUMERO != original.DESPACHO_NUMERO) return true;
			if (this.IsDESPACHO_FECHANull != original.IsDESPACHO_FECHANull) return true;
			if (!this.IsDESPACHO_FECHANull && !original.IsDESPACHO_FECHANull)
				if (this.DESPACHO_FECHA != original.DESPACHO_FECHA) return true;
			if (this.FACTURA_PAGADO != original.FACTURA_PAGADO) return true;
			if (this.FACTURA_NUMERO != original.FACTURA_NUMERO) return true;
			if (this.BL != original.BL) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			
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
		/// Gets or sets the <c>PRE_EMBARQUE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRE_EMBARQUE_ID</c> column value.</value>
		public decimal PRE_EMBARQUE_ID
		{
			get { return _pre_embarque_id; }
			set { _pre_embarque_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO</c> column value.</value>
		public string NUMERO
		{
			get { return _numero; }
			set { _numero = value; }
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
		/// Gets or sets the <c>PERSON_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSON_NOMBRE</c> column value.</value>
		public string PERSON_NOMBRE
		{
			get { return _person_nombre; }
			set { _person_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NUMERO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NUMERO_DOCUMENTO</c> column value.</value>
		public string PERSONA_NUMERO_DOCUMENTO
		{
			get { return _persona_numero_documento; }
			set { _persona_numero_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO_NUMERO</c> column value.</value>
		public string DESPACHO_NUMERO
		{
			get { return _despacho_numero; }
			set { _despacho_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO_FECHA</c> column value.</value>
		public System.DateTime DESPACHO_FECHA
		{
			get
			{
				if(IsDESPACHO_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _despacho_fecha;
			}
			set
			{
				_despacho_fechaNull = false;
				_despacho_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESPACHO_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESPACHO_FECHANull
		{
			get { return _despacho_fechaNull; }
			set { _despacho_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PAGADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_PAGADO</c> column value.</value>
		public string FACTURA_PAGADO
		{
			get { return _factura_pagado; }
			set { _factura_pagado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NUMERO</c> column value.</value>
		public string FACTURA_NUMERO
		{
			get { return _factura_numero; }
			set { _factura_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BL</c> column value.</value>
		public string BL
		{
			get { return _bl; }
			set { _bl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
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
			dynStr.Append("@CBA@PRE_EMBARQUE_ID=");
			dynStr.Append(PRE_EMBARQUE_ID);
			dynStr.Append("@CBA@NUMERO=");
			dynStr.Append(NUMERO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSON_NOMBRE=");
			dynStr.Append(PERSON_NOMBRE);
			dynStr.Append("@CBA@PERSONA_NUMERO_DOCUMENTO=");
			dynStr.Append(PERSONA_NUMERO_DOCUMENTO);
			dynStr.Append("@CBA@DESPACHO_NUMERO=");
			dynStr.Append(DESPACHO_NUMERO);
			dynStr.Append("@CBA@DESPACHO_FECHA=");
			dynStr.Append(IsDESPACHO_FECHANull ? (object)"<NULL>" : DESPACHO_FECHA);
			dynStr.Append("@CBA@FACTURA_PAGADO=");
			dynStr.Append(FACTURA_PAGADO);
			dynStr.Append("@CBA@FACTURA_NUMERO=");
			dynStr.Append(FACTURA_NUMERO);
			dynStr.Append("@CBA@BL=");
			dynStr.Append(BL);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			return dynStr.ToString();
		}
	} // End of PRE_EMBARQUE_DETALLE_INFO_COMPRow_Base class
} // End of namespace
