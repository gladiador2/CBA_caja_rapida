// <fileinfo name="CAMPOS_CONF_ITEMS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONF_ITEMS_INFO_COMPRow"/> that 
	/// represents a record in the <c>CAMPOS_CONF_ITEMS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONF_ITEMS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONF_ITEMS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _tabla_id;
		private string _nombre;
		private decimal _campos_conf_grupo_id;
		private string _grupo_nombre;
		private decimal _tipo_dato_id;
		private string _tabla_nombre;
		private string _flujo_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONF_ITEMS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONF_ITEMS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONF_ITEMS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CAMPOS_CONF_GRUPO_ID != original.CAMPOS_CONF_GRUPO_ID) return true;
			if (this.GRUPO_NOMBRE != original.GRUPO_NOMBRE) return true;
			if (this.TIPO_DATO_ID != original.TIPO_DATO_ID) return true;
			if (this.TABLA_NOMBRE != original.TABLA_NOMBRE) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPOS_CONF_GRUPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAMPOS_CONF_GRUPO_ID</c> column value.</value>
		public decimal CAMPOS_CONF_GRUPO_ID
		{
			get { return _campos_conf_grupo_id; }
			set { _campos_conf_grupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_NOMBRE</c> column value.</value>
		public string GRUPO_NOMBRE
		{
			get { return _grupo_nombre; }
			set { _grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DATO_ID</c> column value.</value>
		public decimal TIPO_DATO_ID
		{
			get { return _tipo_dato_id; }
			set { _tipo_dato_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_NOMBRE</c> column value.</value>
		public string TABLA_NOMBRE
		{
			get { return _tabla_nombre; }
			set { _tabla_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_NOMBRE</c> column value.</value>
		public string FLUJO_NOMBRE
		{
			get { return _flujo_nombre; }
			set { _flujo_nombre = value; }
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
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@CAMPOS_CONF_GRUPO_ID=");
			dynStr.Append(CAMPOS_CONF_GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_NOMBRE=");
			dynStr.Append(GRUPO_NOMBRE);
			dynStr.Append("@CBA@TIPO_DATO_ID=");
			dynStr.Append(TIPO_DATO_ID);
			dynStr.Append("@CBA@TABLA_NOMBRE=");
			dynStr.Append(TABLA_NOMBRE);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONF_ITEMS_INFO_COMPRow_Base class
} // End of namespace
