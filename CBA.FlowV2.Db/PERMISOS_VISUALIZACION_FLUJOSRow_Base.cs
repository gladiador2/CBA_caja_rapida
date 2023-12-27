// <fileinfo name="PERMISOS_VISUALIZACION_FLUJOSRow_Base.cs">
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
	/// The base class for <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> that 
	/// represents a record in the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERMISOS_VISUALIZACION_FLUJOSRow_Base
	{
		private decimal _id;
		private decimal _flujo_id;
		private string _estado_id;
		private string _tipo_especifico;
		private decimal _rol_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERMISOS_VISUALIZACION_FLUJOSRow_Base"/> class.
		/// </summary>
		public PERMISOS_VISUALIZACION_FLUJOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERMISOS_VISUALIZACION_FLUJOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.TIPO_ESPECIFICO != original.TIPO_ESPECIFICO) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ESPECIFICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ESPECIFICO</c> column value.</value>
		public string TIPO_ESPECIFICO
		{
			get { return _tipo_especifico; }
			set { _tipo_especifico = value; }
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
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@TIPO_ESPECIFICO=");
			dynStr.Append(TIPO_ESPECIFICO);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			return dynStr.ToString();
		}
	} // End of PERMISOS_VISUALIZACION_FLUJOSRow_Base class
} // End of namespace
