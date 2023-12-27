// <fileinfo name="ORDENES_SERVICIO_CASOS_ASOCRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_CASOS_ASOCRow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO_CASOS_ASOC</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIO_CASOS_ASOCRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_CASOS_ASOCRow_Base
	{
		private decimal _id;
		private decimal _orden_servicio_id;
		private decimal _caso_id;
		private string _observacion;
		private string _considerar_como_pago;
		private System.DateTime _fecha_agregado;
		private decimal _usuario_id;
		private string _editable;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_CASOS_ASOCRow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIO_CASOS_ASOCRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIO_CASOS_ASOCRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_SERVICIO_ID != original.ORDEN_SERVICIO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.CONSIDERAR_COMO_PAGO != original.CONSIDERAR_COMO_PAGO) return true;
			if (this.FECHA_AGREGADO != original.FECHA_AGREGADO) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.EDITABLE != original.EDITABLE) return true;
			
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
		/// Gets or sets the <c>CONSIDERAR_COMO_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIDERAR_COMO_PAGO</c> column value.</value>
		public string CONSIDERAR_COMO_PAGO
		{
			get { return _considerar_como_pago; }
			set { _considerar_como_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_AGREGADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_AGREGADO</c> column value.</value>
		public System.DateTime FECHA_AGREGADO
		{
			get { return _fecha_agregado; }
			set { _fecha_agregado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDITABLE</c> column value.
		/// </summary>
		/// <value>The <c>EDITABLE</c> column value.</value>
		public string EDITABLE
		{
			get { return _editable; }
			set { _editable = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CONSIDERAR_COMO_PAGO=");
			dynStr.Append(CONSIDERAR_COMO_PAGO);
			dynStr.Append("@CBA@FECHA_AGREGADO=");
			dynStr.Append(FECHA_AGREGADO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@EDITABLE=");
			dynStr.Append(EDITABLE);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIO_CASOS_ASOCRow_Base class
} // End of namespace
