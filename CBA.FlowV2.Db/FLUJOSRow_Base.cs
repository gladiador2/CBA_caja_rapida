// <fileinfo name="FLUJOSRow_Base.cs">
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
	/// The base class for <see cref="FLUJOSRow"/> that 
	/// represents a record in the <c>FLUJOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FLUJOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FLUJOSRow_Base
	{
		private decimal _id;
		private string _descripcion;
		private decimal _entidad_id;
		private decimal _orden;
		private bool _ordenNull = true;
		private string _descripcion_impresion;
		private decimal _rol_creacion_id;
		private bool _rol_creacion_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FLUJOSRow_Base"/> class.
		/// </summary>
		public FLUJOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FLUJOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.DESCRIPCION_IMPRESION != original.DESCRIPCION_IMPRESION) return true;
			if (this.IsROL_CREACION_IDNull != original.IsROL_CREACION_IDNull) return true;
			if (!this.IsROL_CREACION_IDNull && !original.IsROL_CREACION_IDNull)
				if (this.ROL_CREACION_ID != original.ROL_CREACION_ID) return true;
			
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
		/// Gets or sets the <c>DESCRIPCION_IMPRESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_IMPRESION</c> column value.</value>
		public string DESCRIPCION_IMPRESION
		{
			get { return _descripcion_impresion; }
			set { _descripcion_impresion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_CREACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_CREACION_ID</c> column value.</value>
		public decimal ROL_CREACION_ID
		{
			get
			{
				if(IsROL_CREACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_creacion_id;
			}
			set
			{
				_rol_creacion_idNull = false;
				_rol_creacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_CREACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_CREACION_IDNull
		{
			get { return _rol_creacion_idNull; }
			set { _rol_creacion_idNull = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@DESCRIPCION_IMPRESION=");
			dynStr.Append(DESCRIPCION_IMPRESION);
			dynStr.Append("@CBA@ROL_CREACION_ID=");
			dynStr.Append(IsROL_CREACION_IDNull ? (object)"<NULL>" : ROL_CREACION_ID);
			return dynStr.ToString();
		}
	} // End of FLUJOSRow_Base class
} // End of namespace
