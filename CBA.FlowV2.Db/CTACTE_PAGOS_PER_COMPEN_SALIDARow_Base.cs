// <fileinfo name="CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagos_persona_doc_id;
		private decimal _ctacte_pagos_persona_id;
		private string _estado;
		private System.DateTime _fecha_creacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGOS_PERSONA_DOC_ID != original.CTACTE_PAGOS_PERSONA_DOC_ID) return true;
			if (this.CTACTE_PAGOS_PERSONA_ID != original.CTACTE_PAGOS_PERSONA_ID) return true;
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
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_DOC_ID
		{
			get { return _ctacte_pagos_persona_doc_id; }
			set { _ctacte_pagos_persona_doc_id = value; }
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
			dynStr.Append(CTACTE_PAGOS_PERSONA_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_ID=");
			dynStr.Append(CTACTE_PAGOS_PERSONA_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PER_COMPEN_SALIDARow_Base class
} // End of namespace
