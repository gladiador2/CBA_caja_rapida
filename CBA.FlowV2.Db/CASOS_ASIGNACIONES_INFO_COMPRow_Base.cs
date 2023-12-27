// <fileinfo name="CASOS_ASIGNACIONES_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CASOS_ASIGNACIONES_INFO_COMPRow"/> that 
	/// represents a record in the <c>CASOS_ASIGNACIONES_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CASOS_ASIGNACIONES_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOS_ASIGNACIONES_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _caso_flujo_id;
		private string _caso_flujo_descripcion;
		private string _caso_estado_id;
		private decimal _usuario_asignado_id;
		private bool _usuario_asignado_idNull = true;
		private string _usuario_asignado_nombre;
		private decimal _usuario_creacion_id;
		private string _usuario_creacion_nombre;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido_texto;
		private string _acciones_finalizadas;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_accion_finalizada;
		private bool _fecha_accion_finalizadaNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_ASIGNACIONES_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CASOS_ASIGNACIONES_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CASOS_ASIGNACIONES_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_FLUJO_ID != original.CASO_FLUJO_ID) return true;
			if (this.CASO_FLUJO_DESCRIPCION != original.CASO_FLUJO_DESCRIPCION) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.IsUSUARIO_ASIGNADO_IDNull != original.IsUSUARIO_ASIGNADO_IDNull) return true;
			if (!this.IsUSUARIO_ASIGNADO_IDNull && !original.IsUSUARIO_ASIGNADO_IDNull)
				if (this.USUARIO_ASIGNADO_ID != original.USUARIO_ASIGNADO_ID) return true;
			if (this.USUARIO_ASIGNADO_NOMBRE != original.USUARIO_ASIGNADO_NOMBRE) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_TEXTO != original.TEXTO_PREDEFINIDO_TEXTO) return true;
			if (this.ACCIONES_FINALIZADAS != original.ACCIONES_FINALIZADAS) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFECHA_ACCION_FINALIZADANull != original.IsFECHA_ACCION_FINALIZADANull) return true;
			if (!this.IsFECHA_ACCION_FINALIZADANull && !original.IsFECHA_ACCION_FINALIZADANull)
				if (this.FECHA_ACCION_FINALIZADA != original.FECHA_ACCION_FINALIZADA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_ID</c> column value.</value>
		public decimal CASO_FLUJO_ID
		{
			get { return _caso_flujo_id; }
			set { _caso_flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_DESCRIPCION</c> column value.</value>
		public string CASO_FLUJO_DESCRIPCION
		{
			get { return _caso_flujo_descripcion; }
			set { _caso_flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNADO_ID</c> column value.</value>
		public decimal USUARIO_ASIGNADO_ID
		{
			get
			{
				if(IsUSUARIO_ASIGNADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_asignado_id;
			}
			set
			{
				_usuario_asignado_idNull = false;
				_usuario_asignado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ASIGNADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ASIGNADO_IDNull
		{
			get { return _usuario_asignado_idNull; }
			set { _usuario_asignado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNADO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNADO_NOMBRE</c> column value.</value>
		public string USUARIO_ASIGNADO_NOMBRE
		{
			get { return _usuario_asignado_nombre; }
			set { _usuario_asignado_nombre = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_NOMBRE</c> column value.</value>
		public string USUARIO_CREACION_NOMBRE
		{
			get { return _usuario_creacion_nombre; }
			set { _usuario_creacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.</value>
		public string TEXTO_PREDEFINIDO_TEXTO
		{
			get { return _texto_predefinido_texto; }
			set { _texto_predefinido_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACCIONES_FINALIZADAS</c> column value.
		/// </summary>
		/// <value>The <c>ACCIONES_FINALIZADAS</c> column value.</value>
		public string ACCIONES_FINALIZADAS
		{
			get { return _acciones_finalizadas; }
			set { _acciones_finalizadas = value; }
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
		/// Gets or sets the <c>FECHA_ACCION_FINALIZADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ACCION_FINALIZADA</c> column value.</value>
		public System.DateTime FECHA_ACCION_FINALIZADA
		{
			get
			{
				if(IsFECHA_ACCION_FINALIZADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_accion_finalizada;
			}
			set
			{
				_fecha_accion_finalizadaNull = false;
				_fecha_accion_finalizada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ACCION_FINALIZADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ACCION_FINALIZADANull
		{
			get { return _fecha_accion_finalizadaNull; }
			set { _fecha_accion_finalizadaNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_ID=");
			dynStr.Append(CASO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_DESCRIPCION=");
			dynStr.Append(CASO_FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@USUARIO_ASIGNADO_ID=");
			dynStr.Append(IsUSUARIO_ASIGNADO_IDNull ? (object)"<NULL>" : USUARIO_ASIGNADO_ID);
			dynStr.Append("@CBA@USUARIO_ASIGNADO_NOMBRE=");
			dynStr.Append(USUARIO_ASIGNADO_NOMBRE);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_TEXTO=");
			dynStr.Append(TEXTO_PREDEFINIDO_TEXTO);
			dynStr.Append("@CBA@ACCIONES_FINALIZADAS=");
			dynStr.Append(ACCIONES_FINALIZADAS);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_ACCION_FINALIZADA=");
			dynStr.Append(IsFECHA_ACCION_FINALIZADANull ? (object)"<NULL>" : FECHA_ACCION_FINALIZADA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CASOS_ASIGNACIONES_INFO_COMPRow_Base class
} // End of namespace
