// <fileinfo name="PLANES_FACTURACION_ETAPASRow_Base.cs">
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
	/// The base class for <see cref="PLANES_FACTURACION_ETAPASRow"/> that 
	/// represents a record in the <c>PLANES_FACTURACION_ETAPAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANES_FACTURACION_ETAPASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANES_FACTURACION_ETAPASRow_Base
	{
		private decimal _id;
		private decimal _plan_facturacion_id;
		private string _nombre;
		private System.DateTime _fecha_estimada_inicio;
		private bool _fecha_estimada_inicioNull = true;
		private System.DateTime _fecha_estimada_fin;
		private bool _fecha_estimada_finNull = true;
		private System.DateTime _fecha_facturacion_desde;
		private bool _fecha_facturacion_desdeNull = true;
		private System.DateTime _fecha_facturacion_hasta;
		private bool _fecha_facturacion_hastaNull = true;
		private System.DateTime _ultima_fc_creada_fecha;
		private bool _ultima_fc_creada_fechaNull = true;
		private decimal _ultima_fc_creada_caso_id;
		private bool _ultima_fc_creada_caso_idNull = true;
		private decimal _orden;
		private string _tipo_intervalo;
		private decimal _intervalo;
		private decimal _condicion_pago_id;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;
		private decimal _mora_porcentaje;
		private decimal _mora_dias_gracia;
		private System.DateTime _proxima_fecha;
		private bool _proxima_fechaNull = true;
		private decimal _autonumeracion_factura_id;
		private bool _autonumeracion_factura_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACTURACION_ETAPASRow_Base"/> class.
		/// </summary>
		public PLANES_FACTURACION_ETAPASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANES_FACTURACION_ETAPASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLAN_FACTURACION_ID != original.PLAN_FACTURACION_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsFECHA_ESTIMADA_INICIONull != original.IsFECHA_ESTIMADA_INICIONull) return true;
			if (!this.IsFECHA_ESTIMADA_INICIONull && !original.IsFECHA_ESTIMADA_INICIONull)
				if (this.FECHA_ESTIMADA_INICIO != original.FECHA_ESTIMADA_INICIO) return true;
			if (this.IsFECHA_ESTIMADA_FINNull != original.IsFECHA_ESTIMADA_FINNull) return true;
			if (!this.IsFECHA_ESTIMADA_FINNull && !original.IsFECHA_ESTIMADA_FINNull)
				if (this.FECHA_ESTIMADA_FIN != original.FECHA_ESTIMADA_FIN) return true;
			if (this.IsFECHA_FACTURACION_DESDENull != original.IsFECHA_FACTURACION_DESDENull) return true;
			if (!this.IsFECHA_FACTURACION_DESDENull && !original.IsFECHA_FACTURACION_DESDENull)
				if (this.FECHA_FACTURACION_DESDE != original.FECHA_FACTURACION_DESDE) return true;
			if (this.IsFECHA_FACTURACION_HASTANull != original.IsFECHA_FACTURACION_HASTANull) return true;
			if (!this.IsFECHA_FACTURACION_HASTANull && !original.IsFECHA_FACTURACION_HASTANull)
				if (this.FECHA_FACTURACION_HASTA != original.FECHA_FACTURACION_HASTA) return true;
			if (this.IsULTIMA_FC_CREADA_FECHANull != original.IsULTIMA_FC_CREADA_FECHANull) return true;
			if (!this.IsULTIMA_FC_CREADA_FECHANull && !original.IsULTIMA_FC_CREADA_FECHANull)
				if (this.ULTIMA_FC_CREADA_FECHA != original.ULTIMA_FC_CREADA_FECHA) return true;
			if (this.IsULTIMA_FC_CREADA_CASO_IDNull != original.IsULTIMA_FC_CREADA_CASO_IDNull) return true;
			if (!this.IsULTIMA_FC_CREADA_CASO_IDNull && !original.IsULTIMA_FC_CREADA_CASO_IDNull)
				if (this.ULTIMA_FC_CREADA_CASO_ID != original.ULTIMA_FC_CREADA_CASO_ID) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.TIPO_INTERVALO != original.TIPO_INTERVALO) return true;
			if (this.INTERVALO != original.INTERVALO) return true;
			if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			if (this.MORA_PORCENTAJE != original.MORA_PORCENTAJE) return true;
			if (this.MORA_DIAS_GRACIA != original.MORA_DIAS_GRACIA) return true;
			if (this.IsPROXIMA_FECHANull != original.IsPROXIMA_FECHANull) return true;
			if (!this.IsPROXIMA_FECHANull && !original.IsPROXIMA_FECHANull)
				if (this.PROXIMA_FECHA != original.PROXIMA_FECHA) return true;
			if (this.IsAUTONUMERACION_FACTURA_IDNull != original.IsAUTONUMERACION_FACTURA_IDNull) return true;
			if (!this.IsAUTONUMERACION_FACTURA_IDNull && !original.IsAUTONUMERACION_FACTURA_IDNull)
				if (this.AUTONUMERACION_FACTURA_ID != original.AUTONUMERACION_FACTURA_ID) return true;
			
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
		/// Gets or sets the <c>PLAN_FACTURACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLAN_FACTURACION_ID</c> column value.</value>
		public decimal PLAN_FACTURACION_ID
		{
			get { return _plan_facturacion_id; }
			set { _plan_facturacion_id = value; }
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
		/// Gets or sets the <c>FECHA_ESTIMADA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ESTIMADA_INICIO</c> column value.</value>
		public System.DateTime FECHA_ESTIMADA_INICIO
		{
			get
			{
				if(IsFECHA_ESTIMADA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_estimada_inicio;
			}
			set
			{
				_fecha_estimada_inicioNull = false;
				_fecha_estimada_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ESTIMADA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ESTIMADA_INICIONull
		{
			get { return _fecha_estimada_inicioNull; }
			set { _fecha_estimada_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ESTIMADA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ESTIMADA_FIN</c> column value.</value>
		public System.DateTime FECHA_ESTIMADA_FIN
		{
			get
			{
				if(IsFECHA_ESTIMADA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_estimada_fin;
			}
			set
			{
				_fecha_estimada_finNull = false;
				_fecha_estimada_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ESTIMADA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ESTIMADA_FINNull
		{
			get { return _fecha_estimada_finNull; }
			set { _fecha_estimada_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FACTURACION_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FACTURACION_DESDE</c> column value.</value>
		public System.DateTime FECHA_FACTURACION_DESDE
		{
			get
			{
				if(IsFECHA_FACTURACION_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_facturacion_desde;
			}
			set
			{
				_fecha_facturacion_desdeNull = false;
				_fecha_facturacion_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FACTURACION_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FACTURACION_DESDENull
		{
			get { return _fecha_facturacion_desdeNull; }
			set { _fecha_facturacion_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FACTURACION_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FACTURACION_HASTA</c> column value.</value>
		public System.DateTime FECHA_FACTURACION_HASTA
		{
			get
			{
				if(IsFECHA_FACTURACION_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_facturacion_hasta;
			}
			set
			{
				_fecha_facturacion_hastaNull = false;
				_fecha_facturacion_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FACTURACION_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FACTURACION_HASTANull
		{
			get { return _fecha_facturacion_hastaNull; }
			set { _fecha_facturacion_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMA_FC_CREADA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMA_FC_CREADA_FECHA</c> column value.</value>
		public System.DateTime ULTIMA_FC_CREADA_FECHA
		{
			get
			{
				if(IsULTIMA_FC_CREADA_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultima_fc_creada_fecha;
			}
			set
			{
				_ultima_fc_creada_fechaNull = false;
				_ultima_fc_creada_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMA_FC_CREADA_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMA_FC_CREADA_FECHANull
		{
			get { return _ultima_fc_creada_fechaNull; }
			set { _ultima_fc_creada_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</value>
		public decimal ULTIMA_FC_CREADA_CASO_ID
		{
			get
			{
				if(IsULTIMA_FC_CREADA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultima_fc_creada_caso_id;
			}
			set
			{
				_ultima_fc_creada_caso_idNull = false;
				_ultima_fc_creada_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMA_FC_CREADA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMA_FC_CREADA_CASO_IDNull
		{
			get { return _ultima_fc_creada_caso_idNull; }
			set { _ultima_fc_creada_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_INTERVALO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_INTERVALO</c> column value.</value>
		public string TIPO_INTERVALO
		{
			get { return _tipo_intervalo; }
			set { _tipo_intervalo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERVALO</c> column value.
		/// </summary>
		/// <value>The <c>INTERVALO</c> column value.</value>
		public decimal INTERVALO
		{
			get { return _intervalo; }
			set { _intervalo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get { return _condicion_pago_id; }
			set { _condicion_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>MORA_PORCENTAJE</c> column value.</value>
		public decimal MORA_PORCENTAJE
		{
			get { return _mora_porcentaje; }
			set { _mora_porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_DIAS_GRACIA</c> column value.
		/// </summary>
		/// <value>The <c>MORA_DIAS_GRACIA</c> column value.</value>
		public decimal MORA_DIAS_GRACIA
		{
			get { return _mora_dias_gracia; }
			set { _mora_dias_gracia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROXIMA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROXIMA_FECHA</c> column value.</value>
		public System.DateTime PROXIMA_FECHA
		{
			get
			{
				if(IsPROXIMA_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proxima_fecha;
			}
			set
			{
				_proxima_fechaNull = false;
				_proxima_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROXIMA_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROXIMA_FECHANull
		{
			get { return _proxima_fechaNull; }
			set { _proxima_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_FACTURA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_FACTURA_ID</c> column value.</value>
		public decimal AUTONUMERACION_FACTURA_ID
		{
			get
			{
				if(IsAUTONUMERACION_FACTURA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_factura_id;
			}
			set
			{
				_autonumeracion_factura_idNull = false;
				_autonumeracion_factura_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_FACTURA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_FACTURA_IDNull
		{
			get { return _autonumeracion_factura_idNull; }
			set { _autonumeracion_factura_idNull = value; }
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
			dynStr.Append("@CBA@PLAN_FACTURACION_ID=");
			dynStr.Append(PLAN_FACTURACION_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@FECHA_ESTIMADA_INICIO=");
			dynStr.Append(IsFECHA_ESTIMADA_INICIONull ? (object)"<NULL>" : FECHA_ESTIMADA_INICIO);
			dynStr.Append("@CBA@FECHA_ESTIMADA_FIN=");
			dynStr.Append(IsFECHA_ESTIMADA_FINNull ? (object)"<NULL>" : FECHA_ESTIMADA_FIN);
			dynStr.Append("@CBA@FECHA_FACTURACION_DESDE=");
			dynStr.Append(IsFECHA_FACTURACION_DESDENull ? (object)"<NULL>" : FECHA_FACTURACION_DESDE);
			dynStr.Append("@CBA@FECHA_FACTURACION_HASTA=");
			dynStr.Append(IsFECHA_FACTURACION_HASTANull ? (object)"<NULL>" : FECHA_FACTURACION_HASTA);
			dynStr.Append("@CBA@ULTIMA_FC_CREADA_FECHA=");
			dynStr.Append(IsULTIMA_FC_CREADA_FECHANull ? (object)"<NULL>" : ULTIMA_FC_CREADA_FECHA);
			dynStr.Append("@CBA@ULTIMA_FC_CREADA_CASO_ID=");
			dynStr.Append(IsULTIMA_FC_CREADA_CASO_IDNull ? (object)"<NULL>" : ULTIMA_FC_CREADA_CASO_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@TIPO_INTERVALO=");
			dynStr.Append(TIPO_INTERVALO);
			dynStr.Append("@CBA@INTERVALO=");
			dynStr.Append(INTERVALO);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(CONDICION_PAGO_ID);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			dynStr.Append("@CBA@MORA_PORCENTAJE=");
			dynStr.Append(MORA_PORCENTAJE);
			dynStr.Append("@CBA@MORA_DIAS_GRACIA=");
			dynStr.Append(MORA_DIAS_GRACIA);
			dynStr.Append("@CBA@PROXIMA_FECHA=");
			dynStr.Append(IsPROXIMA_FECHANull ? (object)"<NULL>" : PROXIMA_FECHA);
			dynStr.Append("@CBA@AUTONUMERACION_FACTURA_ID=");
			dynStr.Append(IsAUTONUMERACION_FACTURA_IDNull ? (object)"<NULL>" : AUTONUMERACION_FACTURA_ID);
			return dynStr.ToString();
		}
	} // End of PLANES_FACTURACION_ETAPASRow_Base class
} // End of namespace
