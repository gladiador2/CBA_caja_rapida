// <fileinfo name="PRESUPUESTOS_DET_CASOSRow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_DET_CASOSRow"/> that 
	/// represents a record in the <c>PRESUPUESTOS_DET_CASOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOS_DET_CASOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_DET_CASOSRow_Base
	{
		private decimal _id;
		private decimal _presupuestos_detalle_id;
		private decimal _caso_id;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DET_CASOSRow_Base"/> class.
		/// </summary>
		public PRESUPUESTOS_DET_CASOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOS_DET_CASOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRESUPUESTOS_DETALLE_ID != original.PRESUPUESTOS_DETALLE_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
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
		/// Gets or sets the <c>PRESUPUESTOS_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTOS_DETALLE_ID</c> column value.</value>
		public decimal PRESUPUESTOS_DETALLE_ID
		{
			get { return _presupuestos_detalle_id; }
			set { _presupuestos_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
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
			dynStr.Append("@CBA@PRESUPUESTOS_DETALLE_ID=");
			dynStr.Append(PRESUPUESTOS_DETALLE_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOS_DET_CASOSRow_Base class
} // End of namespace
