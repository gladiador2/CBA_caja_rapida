// <fileinfo name="CAMPOS_CONFIGURABLES_ITEMSRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONFIGURABLES_ITEMSRow"/> that 
	/// represents a record in the <c>CAMPOS_CONFIGURABLES_ITEMS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONFIGURABLES_ITEMSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONFIGURABLES_ITEMSRow_Base
	{
		private decimal _id;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _tabla_id;
		private string _nombre;
		private decimal _campos_conf_grupo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGURABLES_ITEMSRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONFIGURABLES_ITEMSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONFIGURABLES_ITEMSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CAMPOS_CONF_GRUPO_ID != original.CAMPOS_CONF_GRUPO_ID) return true;
			
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
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONFIGURABLES_ITEMSRow_Base class
} // End of namespace
