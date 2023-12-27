// <fileinfo name="REQUISITOS_FLUJORow_Base.cs">
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
	/// The base class for <see cref="REQUISITOS_FLUJORow"/> that 
	/// represents a record in the <c>REQUISITOS_FLUJO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REQUISITOS_FLUJORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REQUISITOS_FLUJORow_Base
	{
		private decimal _id;
		private string _tipo_requisito_flujo_id;
		private decimal _flujo_id;
		private string _estado_id;
		private string _titulo;
		private string _descripcion;
		private decimal _entidad_id;
		private string _estado;
		private string _obligatorio;
		private decimal _rol_ver;
		private bool _rol_verNull = true;
		private decimal _rol_editar;
		private bool _rol_editarNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJORow_Base"/> class.
		/// </summary>
		public REQUISITOS_FLUJORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REQUISITOS_FLUJORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_REQUISITO_FLUJO_ID != original.TIPO_REQUISITO_FLUJO_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.OBLIGATORIO != original.OBLIGATORIO) return true;
			if (this.IsROL_VERNull != original.IsROL_VERNull) return true;
			if (!this.IsROL_VERNull && !original.IsROL_VERNull)
				if (this.ROL_VER != original.ROL_VER) return true;
			if (this.IsROL_EDITARNull != original.IsROL_EDITARNull) return true;
			if (!this.IsROL_EDITARNull && !original.IsROL_EDITARNull)
				if (this.ROL_EDITAR != original.ROL_EDITAR) return true;
			
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
		/// Gets or sets the <c>TIPO_REQUISITO_FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</value>
		public string TIPO_REQUISITO_FLUJO_ID
		{
			get { return _tipo_requisito_flujo_id; }
			set { _tipo_requisito_flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULO</c> column value.
		/// </summary>
		/// <value>The <c>TITULO</c> column value.</value>
		public string TITULO
		{
			get { return _titulo; }
			set { _titulo = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBLIGATORIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBLIGATORIO</c> column value.</value>
		public string OBLIGATORIO
		{
			get { return _obligatorio; }
			set { _obligatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_VER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_VER</c> column value.</value>
		public decimal ROL_VER
		{
			get
			{
				if(IsROL_VERNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_ver;
			}
			set
			{
				_rol_verNull = false;
				_rol_ver = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_VER"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_VERNull
		{
			get { return _rol_verNull; }
			set { _rol_verNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_EDITAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_EDITAR</c> column value.</value>
		public decimal ROL_EDITAR
		{
			get
			{
				if(IsROL_EDITARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_editar;
			}
			set
			{
				_rol_editarNull = false;
				_rol_editar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_EDITAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_EDITARNull
		{
			get { return _rol_editarNull; }
			set { _rol_editarNull = value; }
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
			dynStr.Append("@CBA@TIPO_REQUISITO_FLUJO_ID=");
			dynStr.Append(TIPO_REQUISITO_FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@OBLIGATORIO=");
			dynStr.Append(OBLIGATORIO);
			dynStr.Append("@CBA@ROL_VER=");
			dynStr.Append(IsROL_VERNull ? (object)"<NULL>" : ROL_VER);
			dynStr.Append("@CBA@ROL_EDITAR=");
			dynStr.Append(IsROL_EDITARNull ? (object)"<NULL>" : ROL_EDITAR);
			return dynStr.ToString();
		}
	} // End of REQUISITOS_FLUJORow_Base class
} // End of namespace
