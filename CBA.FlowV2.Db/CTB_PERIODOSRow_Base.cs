// <fileinfo name="CTB_PERIODOSRow_Base.cs">
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
	/// The base class for <see cref="CTB_PERIODOSRow"/> that 
	/// represents a record in the <c>CTB_PERIODOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_PERIODOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PERIODOSRow_Base
	{
		private decimal _id;
		private decimal _ctb_ejercicio_id;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private string _nombre;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_inactivacion_id;
		private bool _usuario_inactivacion_idNull = true;
		private System.DateTime _fecha_inactivacion;
		private bool _fecha_inactivacionNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PERIODOSRow_Base"/> class.
		/// </summary>
		public CTB_PERIODOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_PERIODOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_EJERCICIO_ID != original.CTB_EJERCICIO_ID) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_INACTIVACION_IDNull != original.IsUSUARIO_INACTIVACION_IDNull) return true;
			if (!this.IsUSUARIO_INACTIVACION_IDNull && !original.IsUSUARIO_INACTIVACION_IDNull)
				if (this.USUARIO_INACTIVACION_ID != original.USUARIO_INACTIVACION_ID) return true;
			if (this.IsFECHA_INACTIVACIONNull != original.IsFECHA_INACTIVACIONNull) return true;
			if (!this.IsFECHA_INACTIVACIONNull && !original.IsFECHA_INACTIVACIONNull)
				if (this.FECHA_INACTIVACION != original.FECHA_INACTIVACION) return true;
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
		/// Gets or sets the <c>CTB_EJERCICIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_EJERCICIO_ID</c> column value.</value>
		public decimal CTB_EJERCICIO_ID
		{
			get { return _ctb_ejercicio_id; }
			set { _ctb_ejercicio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get { return _fecha_fin; }
			set { _fecha_fin = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
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
		/// Gets or sets the <c>USUARIO_INACTIVACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVACION_ID</c> column value.</value>
		public decimal USUARIO_INACTIVACION_ID
		{
			get
			{
				if(IsUSUARIO_INACTIVACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_inactivacion_id;
			}
			set
			{
				_usuario_inactivacion_idNull = false;
				_usuario_inactivacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_INACTIVACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_INACTIVACION_IDNull
		{
			get { return _usuario_inactivacion_idNull; }
			set { _usuario_inactivacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INACTIVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INACTIVACION</c> column value.</value>
		public System.DateTime FECHA_INACTIVACION
		{
			get
			{
				if(IsFECHA_INACTIVACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inactivacion;
			}
			set
			{
				_fecha_inactivacionNull = false;
				_fecha_inactivacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INACTIVACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INACTIVACIONNull
		{
			get { return _fecha_inactivacionNull; }
			set { _fecha_inactivacionNull = value; }
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
			dynStr.Append("@CBA@CTB_EJERCICIO_ID=");
			dynStr.Append(CTB_EJERCICIO_ID);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(FECHA_FIN);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_INACTIVACION_ID=");
			dynStr.Append(IsUSUARIO_INACTIVACION_IDNull ? (object)"<NULL>" : USUARIO_INACTIVACION_ID);
			dynStr.Append("@CBA@FECHA_INACTIVACION=");
			dynStr.Append(IsFECHA_INACTIVACIONNull ? (object)"<NULL>" : FECHA_INACTIVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTB_PERIODOSRow_Base class
} // End of namespace
