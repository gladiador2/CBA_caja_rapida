// <fileinfo name="CASOS_JUDICIALIZADOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CASOS_JUDICIALIZADOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>CASOS_JUDICIALIZADOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CASOS_JUDICIALIZADOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOS_JUDICIALIZADOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _usuario_entrada_id;
		private System.DateTime _fecha_entrada;
		private decimal _usuario_salida_id;
		private bool _usuario_salida_idNull = true;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private decimal _motivo_entrada_id;
		private string _motivo_entrada;
		private string _observacion_entrada;
		private decimal _motivo_salida_id;
		private bool _motivo_salida_idNull = true;
		private string _motivo_salida;
		private string _observacion_salida;
		private decimal _flujo_id;
		private string _flujo_descripcion;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _proveedor_razon_social;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _nro_comprobante;
		private string _estado_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_JUDICIALIZADOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CASOS_JUDICIALIZADOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CASOS_JUDICIALIZADOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.USUARIO_ENTRADA_ID != original.USUARIO_ENTRADA_ID) return true;
			if (this.FECHA_ENTRADA != original.FECHA_ENTRADA) return true;
			if (this.IsUSUARIO_SALIDA_IDNull != original.IsUSUARIO_SALIDA_IDNull) return true;
			if (!this.IsUSUARIO_SALIDA_IDNull && !original.IsUSUARIO_SALIDA_IDNull)
				if (this.USUARIO_SALIDA_ID != original.USUARIO_SALIDA_ID) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.MOTIVO_ENTRADA_ID != original.MOTIVO_ENTRADA_ID) return true;
			if (this.MOTIVO_ENTRADA != original.MOTIVO_ENTRADA) return true;
			if (this.OBSERVACION_ENTRADA != original.OBSERVACION_ENTRADA) return true;
			if (this.IsMOTIVO_SALIDA_IDNull != original.IsMOTIVO_SALIDA_IDNull) return true;
			if (!this.IsMOTIVO_SALIDA_IDNull && !original.IsMOTIVO_SALIDA_IDNull)
				if (this.MOTIVO_SALIDA_ID != original.MOTIVO_SALIDA_ID) return true;
			if (this.MOTIVO_SALIDA != original.MOTIVO_SALIDA) return true;
			if (this.OBSERVACION_SALIDA != original.OBSERVACION_SALIDA) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			
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
		/// Gets or sets the <c>USUARIO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ENTRADA_ID</c> column value.</value>
		public decimal USUARIO_ENTRADA_ID
		{
			get { return _usuario_entrada_id; }
			set { _usuario_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTRADA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ENTRADA</c> column value.</value>
		public System.DateTime FECHA_ENTRADA
		{
			get { return _fecha_entrada; }
			set { _fecha_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_SALIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_SALIDA_ID</c> column value.</value>
		public decimal USUARIO_SALIDA_ID
		{
			get
			{
				if(IsUSUARIO_SALIDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_salida_id;
			}
			set
			{
				_usuario_salida_idNull = false;
				_usuario_salida_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_SALIDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_SALIDA_IDNull
		{
			get { return _usuario_salida_idNull; }
			set { _usuario_salida_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MOTIVO_ENTRADA_ID</c> column value.</value>
		public decimal MOTIVO_ENTRADA_ID
		{
			get { return _motivo_entrada_id; }
			set { _motivo_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_ENTRADA</c> column value.</value>
		public string MOTIVO_ENTRADA
		{
			get { return _motivo_entrada; }
			set { _motivo_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_ENTRADA</c> column value.</value>
		public string OBSERVACION_ENTRADA
		{
			get { return _observacion_entrada; }
			set { _observacion_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_SALIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_SALIDA_ID</c> column value.</value>
		public decimal MOTIVO_SALIDA_ID
		{
			get
			{
				if(IsMOTIVO_SALIDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _motivo_salida_id;
			}
			set
			{
				_motivo_salida_idNull = false;
				_motivo_salida_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOTIVO_SALIDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOTIVO_SALIDA_IDNull
		{
			get { return _motivo_salida_idNull; }
			set { _motivo_salida_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_SALIDA</c> column value.</value>
		public string MOTIVO_SALIDA
		{
			get { return _motivo_salida; }
			set { _motivo_salida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_SALIDA</c> column value.</value>
		public string OBSERVACION_SALIDA
		{
			get { return _observacion_salida; }
			set { _observacion_salida = value; }
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
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
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
			dynStr.Append("@CBA@USUARIO_ENTRADA_ID=");
			dynStr.Append(USUARIO_ENTRADA_ID);
			dynStr.Append("@CBA@FECHA_ENTRADA=");
			dynStr.Append(FECHA_ENTRADA);
			dynStr.Append("@CBA@USUARIO_SALIDA_ID=");
			dynStr.Append(IsUSUARIO_SALIDA_IDNull ? (object)"<NULL>" : USUARIO_SALIDA_ID);
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@MOTIVO_ENTRADA_ID=");
			dynStr.Append(MOTIVO_ENTRADA_ID);
			dynStr.Append("@CBA@MOTIVO_ENTRADA=");
			dynStr.Append(MOTIVO_ENTRADA);
			dynStr.Append("@CBA@OBSERVACION_ENTRADA=");
			dynStr.Append(OBSERVACION_ENTRADA);
			dynStr.Append("@CBA@MOTIVO_SALIDA_ID=");
			dynStr.Append(IsMOTIVO_SALIDA_IDNull ? (object)"<NULL>" : MOTIVO_SALIDA_ID);
			dynStr.Append("@CBA@MOTIVO_SALIDA=");
			dynStr.Append(MOTIVO_SALIDA);
			dynStr.Append("@CBA@OBSERVACION_SALIDA=");
			dynStr.Append(OBSERVACION_SALIDA);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			return dynStr.ToString();
		}
	} // End of CASOS_JUDICIALIZADOS_INFO_COMPRow_Base class
} // End of namespace
