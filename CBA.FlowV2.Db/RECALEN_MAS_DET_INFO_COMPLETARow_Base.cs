// <fileinfo name="RECALEN_MAS_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="RECALEN_MAS_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>RECALEN_MAS_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RECALEN_MAS_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECALEN_MAS_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _recalendarizacion_masiva_id;
		private decimal _caso_factura_id;
		private string _caso_estado_id;
		private string _persona_codigo;
		private string _persona_nombre_completo;
		private string _factura_nro_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECALEN_MAS_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public RECALEN_MAS_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RECALEN_MAS_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RECALENDARIZACION_MASIVA_ID != original.RECALENDARIZACION_MASIVA_ID) return true;
			if (this.CASO_FACTURA_ID != original.CASO_FACTURA_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.FACTURA_NRO_COMPROBANTE != original.FACTURA_NRO_COMPROBANTE) return true;
			
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
		/// Gets or sets the <c>RECALENDARIZACION_MASIVA_ID</c> column value.
		/// </summary>
		/// <value>The <c>RECALENDARIZACION_MASIVA_ID</c> column value.</value>
		public decimal RECALENDARIZACION_MASIVA_ID
		{
			get { return _recalendarizacion_masiva_id; }
			set { _recalendarizacion_masiva_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FACTURA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FACTURA_ID</c> column value.</value>
		public decimal CASO_FACTURA_ID
		{
			get { return _caso_factura_id; }
			set { _caso_factura_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NRO_COMPROBANTE</c> column value.</value>
		public string FACTURA_NRO_COMPROBANTE
		{
			get { return _factura_nro_comprobante; }
			set { _factura_nro_comprobante = value; }
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
			dynStr.Append("@CBA@RECALENDARIZACION_MASIVA_ID=");
			dynStr.Append(RECALENDARIZACION_MASIVA_ID);
			dynStr.Append("@CBA@CASO_FACTURA_ID=");
			dynStr.Append(CASO_FACTURA_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FACTURA_NRO_COMPROBANTE=");
			dynStr.Append(FACTURA_NRO_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of RECALEN_MAS_DET_INFO_COMPLETARow_Base class
} // End of namespace
