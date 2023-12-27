// <fileinfo name="ORDENES_SERVICIO_FUNCIONARIOSRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_FUNCIONARIOSRow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO_FUNCIONARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIO_FUNCIONARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_FUNCIONARIOSRow_Base
	{
		private decimal _id;
		private decimal _orden_servicio_id;
		private decimal _funcionario_id;
		private decimal _porcentaje_comision;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_FUNCIONARIOSRow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIO_FUNCIONARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIO_FUNCIONARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_SERVICIO_ID != original.ORDEN_SERVICIO_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			
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
		/// Gets or sets the <c>ORDEN_SERVICIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_SERVICIO_ID</c> column value.</value>
		public decimal ORDEN_SERVICIO_ID
		{
			get { return _orden_servicio_id; }
			set { _orden_servicio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION</c> column value.</value>
		public decimal PORCENTAJE_COMISION
		{
			get { return _porcentaje_comision; }
			set { _porcentaje_comision = value; }
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
			dynStr.Append("@CBA@ORDEN_SERVICIO_ID=");
			dynStr.Append(ORDEN_SERVICIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(PORCENTAJE_COMISION);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIO_FUNCIONARIOSRow_Base class
} // End of namespace
