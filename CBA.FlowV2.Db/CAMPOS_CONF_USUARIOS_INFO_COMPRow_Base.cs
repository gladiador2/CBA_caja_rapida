// <fileinfo name="CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>CAMPOS_CONF_USUARIOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _campo_conf_item_id;
		private bool _campo_conf_item_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _valor;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private decimal _grupo_asignado_id;
		private bool _grupo_asignado_idNull = true;
		private decimal _campo_grupo_asignado_id;
		private bool _campo_grupo_asignado_idNull = true;
		private decimal _tipo_dato_id;
		private bool _tipo_dato_idNull = true;
		private string _grupo_nombre;
		private decimal _campo_flujo_id;
		private bool _campo_flujo_idNull = true;
		private string _flujo_nombre;
		private string _campo_tabla_id;
		private string _tabla_nombre;
		private string _campo_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCAMPO_CONF_ITEM_IDNull != original.IsCAMPO_CONF_ITEM_IDNull) return true;
			if (!this.IsCAMPO_CONF_ITEM_IDNull && !original.IsCAMPO_CONF_ITEM_IDNull)
				if (this.CAMPO_CONF_ITEM_ID != original.CAMPO_CONF_ITEM_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.VALOR != original.VALOR) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.IsGRUPO_ASIGNADO_IDNull != original.IsGRUPO_ASIGNADO_IDNull) return true;
			if (!this.IsGRUPO_ASIGNADO_IDNull && !original.IsGRUPO_ASIGNADO_IDNull)
				if (this.GRUPO_ASIGNADO_ID != original.GRUPO_ASIGNADO_ID) return true;
			if (this.IsCAMPO_GRUPO_ASIGNADO_IDNull != original.IsCAMPO_GRUPO_ASIGNADO_IDNull) return true;
			if (!this.IsCAMPO_GRUPO_ASIGNADO_IDNull && !original.IsCAMPO_GRUPO_ASIGNADO_IDNull)
				if (this.CAMPO_GRUPO_ASIGNADO_ID != original.CAMPO_GRUPO_ASIGNADO_ID) return true;
			if (this.IsTIPO_DATO_IDNull != original.IsTIPO_DATO_IDNull) return true;
			if (!this.IsTIPO_DATO_IDNull && !original.IsTIPO_DATO_IDNull)
				if (this.TIPO_DATO_ID != original.TIPO_DATO_ID) return true;
			if (this.GRUPO_NOMBRE != original.GRUPO_NOMBRE) return true;
			if (this.IsCAMPO_FLUJO_IDNull != original.IsCAMPO_FLUJO_IDNull) return true;
			if (!this.IsCAMPO_FLUJO_IDNull && !original.IsCAMPO_FLUJO_IDNull)
				if (this.CAMPO_FLUJO_ID != original.CAMPO_FLUJO_ID) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			if (this.CAMPO_TABLA_ID != original.CAMPO_TABLA_ID) return true;
			if (this.TABLA_NOMBRE != original.TABLA_NOMBRE) return true;
			if (this.CAMPO_NOMBRE != original.CAMPO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>CAMPO_CONF_ITEM_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_CONF_ITEM_ID</c> column value.</value>
		public decimal CAMPO_CONF_ITEM_ID
		{
			get
			{
				if(IsCAMPO_CONF_ITEM_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _campo_conf_item_id;
			}
			set
			{
				_campo_conf_item_idNull = false;
				_campo_conf_item_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMPO_CONF_ITEM_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMPO_CONF_ITEM_IDNull
		{
			get { return _campo_conf_item_idNull; }
			set { _campo_conf_item_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR</c> column value.</value>
		public string VALOR
		{
			get { return _valor; }
			set { _valor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ASIGNADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ASIGNADO_ID</c> column value.</value>
		public decimal GRUPO_ASIGNADO_ID
		{
			get
			{
				if(IsGRUPO_ASIGNADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_asignado_id;
			}
			set
			{
				_grupo_asignado_idNull = false;
				_grupo_asignado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ASIGNADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_ASIGNADO_IDNull
		{
			get { return _grupo_asignado_idNull; }
			set { _grupo_asignado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPO_GRUPO_ASIGNADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_GRUPO_ASIGNADO_ID</c> column value.</value>
		public decimal CAMPO_GRUPO_ASIGNADO_ID
		{
			get
			{
				if(IsCAMPO_GRUPO_ASIGNADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _campo_grupo_asignado_id;
			}
			set
			{
				_campo_grupo_asignado_idNull = false;
				_campo_grupo_asignado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMPO_GRUPO_ASIGNADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMPO_GRUPO_ASIGNADO_IDNull
		{
			get { return _campo_grupo_asignado_idNull; }
			set { _campo_grupo_asignado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DATO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DATO_ID</c> column value.</value>
		public decimal TIPO_DATO_ID
		{
			get
			{
				if(IsTIPO_DATO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_dato_id;
			}
			set
			{
				_tipo_dato_idNull = false;
				_tipo_dato_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_DATO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_DATO_IDNull
		{
			get { return _tipo_dato_idNull; }
			set { _tipo_dato_idNull = value; }
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
		/// Gets or sets the <c>CAMPO_FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_FLUJO_ID</c> column value.</value>
		public decimal CAMPO_FLUJO_ID
		{
			get
			{
				if(IsCAMPO_FLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _campo_flujo_id;
			}
			set
			{
				_campo_flujo_idNull = false;
				_campo_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMPO_FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMPO_FLUJO_IDNull
		{
			get { return _campo_flujo_idNull; }
			set { _campo_flujo_idNull = value; }
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
		/// Gets or sets the <c>CAMPO_TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_TABLA_ID</c> column value.</value>
		public string CAMPO_TABLA_ID
		{
			get { return _campo_tabla_id; }
			set { _campo_tabla_id = value; }
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
		/// Gets or sets the <c>CAMPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_NOMBRE</c> column value.</value>
		public string CAMPO_NOMBRE
		{
			get { return _campo_nombre; }
			set { _campo_nombre = value; }
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
			dynStr.Append("@CBA@CAMPO_CONF_ITEM_ID=");
			dynStr.Append(IsCAMPO_CONF_ITEM_IDNull ? (object)"<NULL>" : CAMPO_CONF_ITEM_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@VALOR=");
			dynStr.Append(VALOR);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_ASIGNADO_ID=");
			dynStr.Append(IsGRUPO_ASIGNADO_IDNull ? (object)"<NULL>" : GRUPO_ASIGNADO_ID);
			dynStr.Append("@CBA@CAMPO_GRUPO_ASIGNADO_ID=");
			dynStr.Append(IsCAMPO_GRUPO_ASIGNADO_IDNull ? (object)"<NULL>" : CAMPO_GRUPO_ASIGNADO_ID);
			dynStr.Append("@CBA@TIPO_DATO_ID=");
			dynStr.Append(IsTIPO_DATO_IDNull ? (object)"<NULL>" : TIPO_DATO_ID);
			dynStr.Append("@CBA@GRUPO_NOMBRE=");
			dynStr.Append(GRUPO_NOMBRE);
			dynStr.Append("@CBA@CAMPO_FLUJO_ID=");
			dynStr.Append(IsCAMPO_FLUJO_IDNull ? (object)"<NULL>" : CAMPO_FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			dynStr.Append("@CBA@CAMPO_TABLA_ID=");
			dynStr.Append(CAMPO_TABLA_ID);
			dynStr.Append("@CBA@TABLA_NOMBRE=");
			dynStr.Append(TABLA_NOMBRE);
			dynStr.Append("@CBA@CAMPO_NOMBRE=");
			dynStr.Append(CAMPO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONF_USUARIOS_INFO_COMPRow_Base class
} // End of namespace
