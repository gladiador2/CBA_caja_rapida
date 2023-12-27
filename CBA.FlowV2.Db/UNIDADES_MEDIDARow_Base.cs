// <fileinfo name="UNIDADES_MEDIDARow_Base.cs">
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
	/// The base class for <see cref="UNIDADES_MEDIDARow"/> that 
	/// represents a record in the <c>UNIDADES_MEDIDA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="UNIDADES_MEDIDARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class UNIDADES_MEDIDARow_Base
	{
		private string _id;
		private string _descripcion;
		private decimal _factor_metro;
		private bool _factor_metroNull = true;
		private decimal _factor_kilo;
		private bool _factor_kiloNull = true;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _cantidad_decimales;

		/// <summary>
		/// Initializes a new instance of the <see cref="UNIDADES_MEDIDARow_Base"/> class.
		/// </summary>
		public UNIDADES_MEDIDARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(UNIDADES_MEDIDARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.IsFACTOR_METRONull != original.IsFACTOR_METRONull) return true;
			if (!this.IsFACTOR_METRONull && !original.IsFACTOR_METRONull)
				if (this.FACTOR_METRO != original.FACTOR_METRO) return true;
			if (this.IsFACTOR_KILONull != original.IsFACTOR_KILONull) return true;
			if (!this.IsFACTOR_KILONull && !original.IsFACTOR_KILONull)
				if (this.FACTOR_KILO != original.FACTOR_KILO) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.CANTIDAD_DECIMALES != original.CANTIDAD_DECIMALES) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_METRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTOR_METRO</c> column value.</value>
		public decimal FACTOR_METRO
		{
			get
			{
				if(IsFACTOR_METRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factor_metro;
			}
			set
			{
				_factor_metroNull = false;
				_factor_metro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTOR_METRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTOR_METRONull
		{
			get { return _factor_metroNull; }
			set { _factor_metroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_KILO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTOR_KILO</c> column value.</value>
		public decimal FACTOR_KILO
		{
			get
			{
				if(IsFACTOR_KILONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factor_kilo;
			}
			set
			{
				_factor_kiloNull = false;
				_factor_kilo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTOR_KILO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTOR_KILONull
		{
			get { return _factor_kiloNull; }
			set { _factor_kiloNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_DECIMALES</c> column value.</value>
		public decimal CANTIDAD_DECIMALES
		{
			get { return _cantidad_decimales; }
			set { _cantidad_decimales = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@FACTOR_METRO=");
			dynStr.Append(IsFACTOR_METRONull ? (object)"<NULL>" : FACTOR_METRO);
			dynStr.Append("@CBA@FACTOR_KILO=");
			dynStr.Append(IsFACTOR_KILONull ? (object)"<NULL>" : FACTOR_KILO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@CANTIDAD_DECIMALES=");
			dynStr.Append(CANTIDAD_DECIMALES);
			return dynStr.ToString();
		}
	} // End of UNIDADES_MEDIDARow_Base class
} // End of namespace
