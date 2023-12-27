// <fileinfo name="CONOCIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="CONOCIMIENTOSRow"/> that 
	/// represents a record in the <c>CONOCIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONOCIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONOCIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _manifiesto_id;
		private string _observaciones;
		private string _nro_conocimiento;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _bl;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOSRow_Base"/> class.
		/// </summary>
		public CONOCIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONOCIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.MANIFIESTO_ID != original.MANIFIESTO_ID) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.NRO_CONOCIMIENTO != original.NRO_CONOCIMIENTO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.BL != original.BL) return true;
			
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
		/// Gets or sets the <c>MANIFIESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MANIFIESTO_ID</c> column value.</value>
		public decimal MANIFIESTO_ID
		{
			get { return _manifiesto_id; }
			set { _manifiesto_id = value; }
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
		/// Gets or sets the <c>NRO_CONOCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CONOCIMIENTO</c> column value.</value>
		public string NRO_CONOCIMIENTO
		{
			get { return _nro_conocimiento; }
			set { _nro_conocimiento = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@MANIFIESTO_ID=");
			dynStr.Append(MANIFIESTO_ID);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@NRO_CONOCIMIENTO=");
			dynStr.Append(NRO_CONOCIMIENTO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@BL=");
			dynStr.Append(BL);
			return dynStr.ToString();
		}
	} // End of CONOCIMIENTOSRow_Base class
} // End of namespace
