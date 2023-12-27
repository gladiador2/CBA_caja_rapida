// <fileinfo name="CTB_PLANES_CUENTARow_Base.cs">
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
	/// The base class for <see cref="CTB_PLANES_CUENTARow"/> that 
	/// represents a record in the <c>CTB_PLANES_CUENTA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_PLANES_CUENTARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PLANES_CUENTARow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _observacion;
		private decimal _entidad_id;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_inactivado;
		private bool _fecha_inactivadoNull = true;
		private decimal _usuario_inactivado_id;
		private bool _usuario_inactivado_idNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PLANES_CUENTARow_Base"/> class.
		/// </summary>
		public CTB_PLANES_CUENTARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_PLANES_CUENTARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.IsFECHA_INACTIVADONull != original.IsFECHA_INACTIVADONull) return true;
			if (!this.IsFECHA_INACTIVADONull && !original.IsFECHA_INACTIVADONull)
				if (this.FECHA_INACTIVADO != original.FECHA_INACTIVADO) return true;
			if (this.IsUSUARIO_INACTIVADO_IDNull != original.IsUSUARIO_INACTIVADO_IDNull) return true;
			if (!this.IsUSUARIO_INACTIVADO_IDNull && !original.IsUSUARIO_INACTIVADO_IDNull)
				if (this.USUARIO_INACTIVADO_ID != original.USUARIO_INACTIVADO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INACTIVADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INACTIVADO</c> column value.</value>
		public System.DateTime FECHA_INACTIVADO
		{
			get
			{
				if(IsFECHA_INACTIVADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inactivado;
			}
			set
			{
				_fecha_inactivadoNull = false;
				_fecha_inactivado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INACTIVADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INACTIVADONull
		{
			get { return _fecha_inactivadoNull; }
			set { _fecha_inactivadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_INACTIVADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVADO_ID</c> column value.</value>
		public decimal USUARIO_INACTIVADO_ID
		{
			get
			{
				if(IsUSUARIO_INACTIVADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_inactivado_id;
			}
			set
			{
				_usuario_inactivado_idNull = false;
				_usuario_inactivado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_INACTIVADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_INACTIVADO_IDNull
		{
			get { return _usuario_inactivado_idNull; }
			set { _usuario_inactivado_idNull = value; }
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
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_INACTIVADO=");
			dynStr.Append(IsFECHA_INACTIVADONull ? (object)"<NULL>" : FECHA_INACTIVADO);
			dynStr.Append("@CBA@USUARIO_INACTIVADO_ID=");
			dynStr.Append(IsUSUARIO_INACTIVADO_IDNull ? (object)"<NULL>" : USUARIO_INACTIVADO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTB_PLANES_CUENTARow_Base class
} // End of namespace
