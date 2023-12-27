// <fileinfo name="NOMINA_CONTENEDORES_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENEDORES_DETALLESRow"/> that 
	/// represents a record in the <c>NOMINA_CONTENEDORES_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOMINA_CONTENEDORES_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENEDORES_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _nomina_contenedores_id;
		private bool _nomina_contenedores_idNull = true;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _puerta_movimiento_entrega_id;
		private bool _puerta_movimiento_entrega_idNull = true;
		private decimal _puerta_movimiento_devoluc_id;
		private bool _puerta_movimiento_devoluc_idNull = true;
		private decimal _usuario_creador_id;
		private bool _usuario_creador_idNull = true;
		private decimal _usuario_modificacion_id;
		private bool _usuario_modificacion_idNull = true;
		private string _observacion;
		private string _rechazado;
		private decimal _contenedores_operaciones_id;
		private bool _contenedores_operaciones_idNull = true;
		private decimal _pre_embarque_contenedor_id;
		private bool _pre_embarque_contenedor_idNull = true;
		private decimal _intercambio_equipo_id;
		private bool _intercambio_equipo_idNull = true;
		private decimal _puerto_devolucion_id;
		private bool _puerto_devolucion_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORES_DETALLESRow_Base"/> class.
		/// </summary>
		public NOMINA_CONTENEDORES_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOMINA_CONTENEDORES_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsNOMINA_CONTENEDORES_IDNull != original.IsNOMINA_CONTENEDORES_IDNull) return true;
			if (!this.IsNOMINA_CONTENEDORES_IDNull && !original.IsNOMINA_CONTENEDORES_IDNull)
				if (this.NOMINA_CONTENEDORES_ID != original.NOMINA_CONTENEDORES_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull != original.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull) return true;
			if (!this.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull && !original.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull)
				if (this.PUERTA_MOVIMIENTO_ENTREGA_ID != original.PUERTA_MOVIMIENTO_ENTREGA_ID) return true;
			if (this.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull != original.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull) return true;
			if (!this.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull && !original.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull)
				if (this.PUERTA_MOVIMIENTO_DEVOLUC_ID != original.PUERTA_MOVIMIENTO_DEVOLUC_ID) return true;
			if (this.IsUSUARIO_CREADOR_IDNull != original.IsUSUARIO_CREADOR_IDNull) return true;
			if (!this.IsUSUARIO_CREADOR_IDNull && !original.IsUSUARIO_CREADOR_IDNull)
				if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.IsUSUARIO_MODIFICACION_IDNull != original.IsUSUARIO_MODIFICACION_IDNull) return true;
			if (!this.IsUSUARIO_MODIFICACION_IDNull && !original.IsUSUARIO_MODIFICACION_IDNull)
				if (this.USUARIO_MODIFICACION_ID != original.USUARIO_MODIFICACION_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.RECHAZADO != original.RECHAZADO) return true;
			if (this.IsCONTENEDORES_OPERACIONES_IDNull != original.IsCONTENEDORES_OPERACIONES_IDNull) return true;
			if (!this.IsCONTENEDORES_OPERACIONES_IDNull && !original.IsCONTENEDORES_OPERACIONES_IDNull)
				if (this.CONTENEDORES_OPERACIONES_ID != original.CONTENEDORES_OPERACIONES_ID) return true;
			if (this.IsPRE_EMBARQUE_CONTENEDOR_IDNull != original.IsPRE_EMBARQUE_CONTENEDOR_IDNull) return true;
			if (!this.IsPRE_EMBARQUE_CONTENEDOR_IDNull && !original.IsPRE_EMBARQUE_CONTENEDOR_IDNull)
				if (this.PRE_EMBARQUE_CONTENEDOR_ID != original.PRE_EMBARQUE_CONTENEDOR_ID) return true;
			if (this.IsINTERCAMBIO_EQUIPO_IDNull != original.IsINTERCAMBIO_EQUIPO_IDNull) return true;
			if (!this.IsINTERCAMBIO_EQUIPO_IDNull && !original.IsINTERCAMBIO_EQUIPO_IDNull)
				if (this.INTERCAMBIO_EQUIPO_ID != original.INTERCAMBIO_EQUIPO_ID) return true;
			if (this.IsPUERTO_DEVOLUCION_IDNull != original.IsPUERTO_DEVOLUCION_IDNull) return true;
			if (!this.IsPUERTO_DEVOLUCION_IDNull && !original.IsPUERTO_DEVOLUCION_IDNull)
				if (this.PUERTO_DEVOLUCION_ID != original.PUERTO_DEVOLUCION_ID) return true;
			
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
		/// Gets or sets the <c>NOMINA_CONTENEDORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMINA_CONTENEDORES_ID</c> column value.</value>
		public decimal NOMINA_CONTENEDORES_ID
		{
			get
			{
				if(IsNOMINA_CONTENEDORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nomina_contenedores_id;
			}
			set
			{
				_nomina_contenedores_idNull = false;
				_nomina_contenedores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOMINA_CONTENEDORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOMINA_CONTENEDORES_IDNull
		{
			get { return _nomina_contenedores_idNull; }
			set { _nomina_contenedores_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get
			{
				if(IsCONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedor_id;
			}
			set
			{
				_contenedor_idNull = false;
				_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDOR_IDNull
		{
			get { return _contenedor_idNull; }
			set { _contenedor_idNull = value; }
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
		/// Gets or sets the <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</value>
		public decimal PUERTA_MOVIMIENTO_ENTREGA_ID
		{
			get
			{
				if(IsPUERTA_MOVIMIENTO_ENTREGA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerta_movimiento_entrega_id;
			}
			set
			{
				_puerta_movimiento_entrega_idNull = false;
				_puerta_movimiento_entrega_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTA_MOVIMIENTO_ENTREGA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTA_MOVIMIENTO_ENTREGA_IDNull
		{
			get { return _puerta_movimiento_entrega_idNull; }
			set { _puerta_movimiento_entrega_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</value>
		public decimal PUERTA_MOVIMIENTO_DEVOLUC_ID
		{
			get
			{
				if(IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerta_movimiento_devoluc_id;
			}
			set
			{
				_puerta_movimiento_devoluc_idNull = false;
				_puerta_movimiento_devoluc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTA_MOVIMIENTO_DEVOLUC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull
		{
			get { return _puerta_movimiento_devoluc_idNull; }
			set { _puerta_movimiento_devoluc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get
			{
				if(IsUSUARIO_CREADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creador_id;
			}
			set
			{
				_usuario_creador_idNull = false;
				_usuario_creador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREADOR_IDNull
		{
			get { return _usuario_creador_idNull; }
			set { _usuario_creador_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_ID</c> column value.</value>
		public decimal USUARIO_MODIFICACION_ID
		{
			get
			{
				if(IsUSUARIO_MODIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_modificacion_id;
			}
			set
			{
				_usuario_modificacion_idNull = false;
				_usuario_modificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_MODIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_MODIFICACION_IDNull
		{
			get { return _usuario_modificacion_idNull; }
			set { _usuario_modificacion_idNull = value; }
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
		/// Gets or sets the <c>RECHAZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECHAZADO</c> column value.</value>
		public string RECHAZADO
		{
			get { return _rechazado; }
			set { _rechazado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDORES_OPERACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</value>
		public decimal CONTENEDORES_OPERACIONES_ID
		{
			get
			{
				if(IsCONTENEDORES_OPERACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedores_operaciones_id;
			}
			set
			{
				_contenedores_operaciones_idNull = false;
				_contenedores_operaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDORES_OPERACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDORES_OPERACIONES_IDNull
		{
			get { return _contenedores_operaciones_idNull; }
			set { _contenedores_operaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</value>
		public decimal PRE_EMBARQUE_CONTENEDOR_ID
		{
			get
			{
				if(IsPRE_EMBARQUE_CONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pre_embarque_contenedor_id;
			}
			set
			{
				_pre_embarque_contenedor_idNull = false;
				_pre_embarque_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRE_EMBARQUE_CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRE_EMBARQUE_CONTENEDOR_IDNull
		{
			get { return _pre_embarque_contenedor_idNull; }
			set { _pre_embarque_contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERCAMBIO_EQUIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</value>
		public decimal INTERCAMBIO_EQUIPO_ID
		{
			get
			{
				if(IsINTERCAMBIO_EQUIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _intercambio_equipo_id;
			}
			set
			{
				_intercambio_equipo_idNull = false;
				_intercambio_equipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INTERCAMBIO_EQUIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINTERCAMBIO_EQUIPO_IDNull
		{
			get { return _intercambio_equipo_idNull; }
			set { _intercambio_equipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_DEVOLUCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_ID</c> column value.</value>
		public decimal PUERTO_DEVOLUCION_ID
		{
			get
			{
				if(IsPUERTO_DEVOLUCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_devolucion_id;
			}
			set
			{
				_puerto_devolucion_idNull = false;
				_puerto_devolucion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_DEVOLUCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_DEVOLUCION_IDNull
		{
			get { return _puerto_devolucion_idNull; }
			set { _puerto_devolucion_idNull = value; }
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
			dynStr.Append("@CBA@NOMINA_CONTENEDORES_ID=");
			dynStr.Append(IsNOMINA_CONTENEDORES_IDNull ? (object)"<NULL>" : NOMINA_CONTENEDORES_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PUERTA_MOVIMIENTO_ENTREGA_ID=");
			dynStr.Append(IsPUERTA_MOVIMIENTO_ENTREGA_IDNull ? (object)"<NULL>" : PUERTA_MOVIMIENTO_ENTREGA_ID);
			dynStr.Append("@CBA@PUERTA_MOVIMIENTO_DEVOLUC_ID=");
			dynStr.Append(IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull ? (object)"<NULL>" : PUERTA_MOVIMIENTO_DEVOLUC_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(IsUSUARIO_CREADOR_IDNull ? (object)"<NULL>" : USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_ID=");
			dynStr.Append(IsUSUARIO_MODIFICACION_IDNull ? (object)"<NULL>" : USUARIO_MODIFICACION_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@RECHAZADO=");
			dynStr.Append(RECHAZADO);
			dynStr.Append("@CBA@CONTENEDORES_OPERACIONES_ID=");
			dynStr.Append(IsCONTENEDORES_OPERACIONES_IDNull ? (object)"<NULL>" : CONTENEDORES_OPERACIONES_ID);
			dynStr.Append("@CBA@PRE_EMBARQUE_CONTENEDOR_ID=");
			dynStr.Append(IsPRE_EMBARQUE_CONTENEDOR_IDNull ? (object)"<NULL>" : PRE_EMBARQUE_CONTENEDOR_ID);
			dynStr.Append("@CBA@INTERCAMBIO_EQUIPO_ID=");
			dynStr.Append(IsINTERCAMBIO_EQUIPO_IDNull ? (object)"<NULL>" : INTERCAMBIO_EQUIPO_ID);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ID=");
			dynStr.Append(IsPUERTO_DEVOLUCION_IDNull ? (object)"<NULL>" : PUERTO_DEVOLUCION_ID);
			return dynStr.ToString();
		}
	} // End of NOMINA_CONTENEDORES_DETALLESRow_Base class
} // End of namespace
