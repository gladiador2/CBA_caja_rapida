// <fileinfo name="PLANTILLAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="PLANTILLAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>PLANTILLAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANTILLAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANTILLAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _tipo_plantilla_id;
		private string _tipo_plantilla_nombre;
		private decimal _entidad_id;
		private string _entidad_nombre;
		private string _estado;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _usuario_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANTILLAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public PLANTILLAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANTILLAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.TIPO_PLANTILLA_ID != original.TIPO_PLANTILLA_ID) return true;
			if (this.TIPO_PLANTILLA_NOMBRE != original.TIPO_PLANTILLA_NOMBRE) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>TIPO_PLANTILLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_PLANTILLA_ID</c> column value.</value>
		public decimal TIPO_PLANTILLA_ID
		{
			get { return _tipo_plantilla_id; }
			set { _tipo_plantilla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_PLANTILLA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_PLANTILLA_NOMBRE</c> column value.</value>
		public string TIPO_PLANTILLA_NOMBRE
		{
			get { return _tipo_plantilla_nombre; }
			set { _tipo_plantilla_nombre = value; }
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
		/// Gets or sets the <c>ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_NOMBRE</c> column value.</value>
		public string ENTIDAD_NOMBRE
		{
			get { return _entidad_nombre; }
			set { _entidad_nombre = value; }
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
		/// Gets or sets the <c>USUARIO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@TIPO_PLANTILLA_ID=");
			dynStr.Append(TIPO_PLANTILLA_ID);
			dynStr.Append("@CBA@TIPO_PLANTILLA_NOMBRE=");
			dynStr.Append(TIPO_PLANTILLA_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of PLANTILLAS_INFO_COMPLETARow_Base class
} // End of namespace
