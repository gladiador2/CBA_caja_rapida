// <fileinfo name="STOCK_UBICACIONRow_Base.cs">
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
	/// The base class for <see cref="STOCK_UBICACIONRow"/> that 
	/// represents a record in the <c>STOCK_UBICACION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_UBICACIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_UBICACIONRow_Base
	{
		private decimal _id;
		private decimal _stock_suc_dep_art_id;
		private string _pasillo;
		private string _estante;
		private string _nivel;
		private string _columna;
		private decimal _cantidad;
		private bool _cantidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_UBICACIONRow_Base"/> class.
		/// </summary>
		public STOCK_UBICACIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_UBICACIONRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.STOCK_SUC_DEP_ART_ID != original.STOCK_SUC_DEP_ART_ID) return true;
			if (this.PASILLO != original.PASILLO) return true;
			if (this.ESTANTE != original.ESTANTE) return true;
			if (this.NIVEL != original.NIVEL) return true;
			if (this.COLUMNA != original.COLUMNA) return true;
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
		/// Gets or sets the <c>STOCK_SUC_DEP_ART_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_SUC_DEP_ART_ID</c> column value.</value>
		public decimal STOCK_SUC_DEP_ART_ID
		{
			get { return _stock_suc_dep_art_id; }
			set { _stock_suc_dep_art_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASILLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASILLO</c> column value.</value>
		public string PASILLO
		{
			get { return _pasillo; }
			set { _pasillo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTANTE</c> column value.</value>
		public string ESTANTE
		{
			get { return _estante; }
			set { _estante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NIVEL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NIVEL</c> column value.</value>
		public string NIVEL
		{
			get { return _nivel; }
			set { _nivel = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLUMNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLUMNA</c> column value.</value>
		public string COLUMNA
		{
			get { return _columna; }
			set { _columna = value; }
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
			dynStr.Append("@CBA@STOCK_SUC_DEP_ART_ID=");
			dynStr.Append(STOCK_SUC_DEP_ART_ID);
			dynStr.Append("@CBA@PASILLO=");
			dynStr.Append(PASILLO);
			dynStr.Append("@CBA@ESTANTE=");
			dynStr.Append(ESTANTE);
			dynStr.Append("@CBA@NIVEL=");
			dynStr.Append(NIVEL);
			dynStr.Append("@CBA@COLUMNA=");
			dynStr.Append(COLUMNA);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			return dynStr.ToString();
		}
	} // End of STOCK_UBICACIONRow_Base class
} // End of namespace
