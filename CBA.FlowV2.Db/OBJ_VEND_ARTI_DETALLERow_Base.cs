// <fileinfo name="OBJ_VEND_ARTI_DETALLERow_Base.cs">
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
	/// The base class for <see cref="OBJ_VEND_ARTI_DETALLERow"/> that 
	/// represents a record in the <c>OBJ_VEND_ARTI_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OBJ_VEND_ARTI_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJ_VEND_ARTI_DETALLERow_Base
	{
		private decimal _id;
		private decimal _objetivo_vendedor_articulo_id;
		private bool _objetivo_vendedor_articulo_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _vendedor_id;
		private bool _vendedor_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJ_VEND_ARTI_DETALLERow_Base"/> class.
		/// </summary>
		public OBJ_VEND_ARTI_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OBJ_VEND_ARTI_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull != original.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull) return true;
			if (!this.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull && !original.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull)
				if (this.OBJETIVO_VENDEDOR_ARTICULO_ID != original.OBJETIVO_VENDEDOR_ARTICULO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsVENDEDOR_IDNull != original.IsVENDEDOR_IDNull) return true;
			if (!this.IsVENDEDOR_IDNull && !original.IsVENDEDOR_IDNull)
				if (this.VENDEDOR_ID != original.VENDEDOR_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			
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
		/// Gets or sets the <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</value>
		public decimal OBJETIVO_VENDEDOR_ARTICULO_ID
		{
			get
			{
				if(IsOBJETIVO_VENDEDOR_ARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _objetivo_vendedor_articulo_id;
			}
			set
			{
				_objetivo_vendedor_articulo_idNull = false;
				_objetivo_vendedor_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="OBJETIVO_VENDEDOR_ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsOBJETIVO_VENDEDOR_ARTICULO_IDNull
		{
			get { return _objetivo_vendedor_articulo_idNull; }
			set { _objetivo_vendedor_articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_ID</c> column value.</value>
		public decimal VENDEDOR_ID
		{
			get
			{
				if(IsVENDEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_id;
			}
			set
			{
				_vendedor_idNull = false;
				_vendedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_IDNull
		{
			get { return _vendedor_idNull; }
			set { _vendedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
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
			dynStr.Append("@CBA@OBJETIVO_VENDEDOR_ARTICULO_ID=");
			dynStr.Append(IsOBJETIVO_VENDEDOR_ARTICULO_IDNull ? (object)"<NULL>" : OBJETIVO_VENDEDOR_ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@VENDEDOR_ID=");
			dynStr.Append(IsVENDEDOR_IDNull ? (object)"<NULL>" : VENDEDOR_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			return dynStr.ToString();
		}
	} // End of OBJ_VEND_ARTI_DETALLERow_Base class
} // End of namespace
