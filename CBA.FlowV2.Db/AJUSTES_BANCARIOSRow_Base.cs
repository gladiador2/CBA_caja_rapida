// <fileinfo name="AJUSTES_BANCARIOSRow_Base.cs">
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
	/// The base class for <see cref="AJUSTES_BANCARIOSRow"/> that 
	/// represents a record in the <c>AJUSTES_BANCARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="AJUSTES_BANCARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AJUSTES_BANCARIOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private System.DateTime _fecha;
		private decimal _ctacte_bancaria_id;
		private decimal _total;
		private string _observacion;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="AJUSTES_BANCARIOSRow_Base"/> class.
		/// </summary>
		public AJUSTES_BANCARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(AJUSTES_BANCARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.TOTAL != original.TOTAL) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get { return _ctacte_bancaria_id; }
			set { _ctacte_bancaria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get { return _total; }
			set { _total = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(TOTAL);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			return dynStr.ToString();
		}
	} // End of AJUSTES_BANCARIOSRow_Base class
} // End of namespace
