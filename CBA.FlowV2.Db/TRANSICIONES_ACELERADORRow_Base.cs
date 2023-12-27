// <fileinfo name="TRANSICIONES_ACELERADORRow_Base.cs">
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
	/// The base class for <see cref="TRANSICIONES_ACELERADORRow"/> that 
	/// represents a record in the <c>TRANSICIONES_ACELERADOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSICIONES_ACELERADORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSICIONES_ACELERADORRow_Base
	{
		private decimal _entidad_id;
		private decimal _flujo_id;
		private decimal _transicion_ocurrida_id;
		private decimal _transicion_siguiente_id;
		private string _estado;
		private decimal _rol_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSICIONES_ACELERADORRow_Base"/> class.
		/// </summary>
		public TRANSICIONES_ACELERADORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSICIONES_ACELERADORRow_Base original)
		{
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.TRANSICION_OCURRIDA_ID != original.TRANSICION_OCURRIDA_ID) return true;
			if (this.TRANSICION_SIGUIENTE_ID != original.TRANSICION_SIGUIENTE_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_OCURRIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSICION_OCURRIDA_ID</c> column value.</value>
		public decimal TRANSICION_OCURRIDA_ID
		{
			get { return _transicion_ocurrida_id; }
			set { _transicion_ocurrida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_SIGUIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSICION_SIGUIENTE_ID</c> column value.</value>
		public decimal TRANSICION_SIGUIENTE_ID
		{
			get { return _transicion_siguiente_id; }
			set { _transicion_siguiente_id = value; }
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
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@TRANSICION_OCURRIDA_ID=");
			dynStr.Append(TRANSICION_OCURRIDA_ID);
			dynStr.Append("@CBA@TRANSICION_SIGUIENTE_ID=");
			dynStr.Append(TRANSICION_SIGUIENTE_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			return dynStr.ToString();
		}
	} // End of TRANSICIONES_ACELERADORRow_Base class
} // End of namespace
