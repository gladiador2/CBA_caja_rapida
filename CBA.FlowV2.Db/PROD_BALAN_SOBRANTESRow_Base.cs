// <fileinfo name="PROD_BALAN_SOBRANTESRow_Base.cs">
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
	/// The base class for <see cref="PROD_BALAN_SOBRANTESRow"/> that 
	/// represents a record in the <c>PROD_BALAN_SOBRANTES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PROD_BALAN_SOBRANTESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROD_BALAN_SOBRANTESRow_Base
	{
		private decimal _id;
		private decimal _prod_balan_id;
		private decimal _articulo_id;
		private decimal _lote_id;
		private string _unidad_medida_id;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROD_BALAN_SOBRANTESRow_Base"/> class.
		/// </summary>
		public PROD_BALAN_SOBRANTESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PROD_BALAN_SOBRANTESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PROD_BALAN_ID != original.PROD_BALAN_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
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
		/// Gets or sets the <c>PROD_BALAN_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROD_BALAN_ID</c> column value.</value>
		public decimal PROD_BALAN_ID
		{
			get { return _prod_balan_id; }
			set { _prod_balan_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
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
			dynStr.Append("@CBA@PROD_BALAN_ID=");
			dynStr.Append(PROD_BALAN_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of PROD_BALAN_SOBRANTESRow_Base class
} // End of namespace
