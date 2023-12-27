// <fileinfo name="REPARTOS_DETALLERow_Base.cs">
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
	/// The base class for <see cref="REPARTOS_DETALLERow"/> that 
	/// represents a record in the <c>REPARTOS_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPARTOS_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTOS_DETALLERow_Base
	{
		private decimal _id;
		private decimal _reparto_id;
		private decimal _caso_id;
		private string _observacion;
		private string _entrega_exitosa;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _bultos;
		private bool _bultosNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTOS_DETALLERow_Base"/> class.
		/// </summary>
		public REPARTOS_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPARTOS_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.REPARTO_ID != original.REPARTO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ENTREGA_EXITOSA != original.ENTREGA_EXITOSA) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.IsBULTOSNull != original.IsBULTOSNull) return true;
			if (!this.IsBULTOSNull && !original.IsBULTOSNull)
				if (this.BULTOS != original.BULTOS) return true;
			
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
		/// Gets or sets the <c>REPARTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REPARTO_ID</c> column value.</value>
		public decimal REPARTO_ID
		{
			get { return _reparto_id; }
			set { _reparto_id = value; }
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
		/// Gets or sets the <c>ENTREGA_EXITOSA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTREGA_EXITOSA</c> column value.</value>
		public string ENTREGA_EXITOSA
		{
			get { return _entrega_exitosa; }
			set { _entrega_exitosa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BULTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BULTOS</c> column value.</value>
		public decimal BULTOS
		{
			get
			{
				if(IsBULTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _bultos;
			}
			set
			{
				_bultosNull = false;
				_bultos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BULTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBULTOSNull
		{
			get { return _bultosNull; }
			set { _bultosNull = value; }
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
			dynStr.Append("@CBA@REPARTO_ID=");
			dynStr.Append(REPARTO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ENTREGA_EXITOSA=");
			dynStr.Append(ENTREGA_EXITOSA);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@BULTOS=");
			dynStr.Append(IsBULTOSNull ? (object)"<NULL>" : BULTOS);
			return dynStr.ToString();
		}
	} // End of REPARTOS_DETALLERow_Base class
} // End of namespace
