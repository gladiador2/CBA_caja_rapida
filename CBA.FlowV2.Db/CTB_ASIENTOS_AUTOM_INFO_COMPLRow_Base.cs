// <fileinfo name="CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_AUTOM_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private string _entidad_nombre;
		private decimal _pais_id;
		private string _pais_nombre;
		private decimal _transicion_id;
		private bool _transicion_idNull = true;
		private string _transicion_descripcion;
		private decimal _transicion_flujo_id;
		private bool _transicion_flujo_idNull = true;
		private string _transicion_flujo_descripcion;
		private string _estado;
		private string _nombre;
		private string _revision_posterior;
		private string _copiar_observacion_caso;
		private string _mostrar_obs_det_reporte;
		private string _usar_fecha_transicion;
		private string _estructura_observacion;
		private string _unificar_detalles_misma_cuenta;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.PAIS_NOMBRE != original.PAIS_NOMBRE) return true;
			if (this.IsTRANSICION_IDNull != original.IsTRANSICION_IDNull) return true;
			if (!this.IsTRANSICION_IDNull && !original.IsTRANSICION_IDNull)
				if (this.TRANSICION_ID != original.TRANSICION_ID) return true;
			if (this.TRANSICION_DESCRIPCION != original.TRANSICION_DESCRIPCION) return true;
			if (this.IsTRANSICION_FLUJO_IDNull != original.IsTRANSICION_FLUJO_IDNull) return true;
			if (!this.IsTRANSICION_FLUJO_IDNull && !original.IsTRANSICION_FLUJO_IDNull)
				if (this.TRANSICION_FLUJO_ID != original.TRANSICION_FLUJO_ID) return true;
			if (this.TRANSICION_FLUJO_DESCRIPCION != original.TRANSICION_FLUJO_DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.REVISION_POSTERIOR != original.REVISION_POSTERIOR) return true;
			if (this.COPIAR_OBSERVACION_CASO != original.COPIAR_OBSERVACION_CASO) return true;
			if (this.MOSTRAR_OBS_DET_REPORTE != original.MOSTRAR_OBS_DET_REPORTE) return true;
			if (this.USAR_FECHA_TRANSICION != original.USAR_FECHA_TRANSICION) return true;
			if (this.ESTRUCTURA_OBSERVACION != original.ESTRUCTURA_OBSERVACION) return true;
			if (this.UNIFICAR_DETALLES_MISMA_CUENTA != original.UNIFICAR_DETALLES_MISMA_CUENTA) return true;
			
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
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_NOMBRE</c> column value.</value>
		public string PAIS_NOMBRE
		{
			get { return _pais_nombre; }
			set { _pais_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_ID</c> column value.</value>
		public decimal TRANSICION_ID
		{
			get
			{
				if(IsTRANSICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_id;
			}
			set
			{
				_transicion_idNull = false;
				_transicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_IDNull
		{
			get { return _transicion_idNull; }
			set { _transicion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_DESCRIPCION</c> column value.</value>
		public string TRANSICION_DESCRIPCION
		{
			get { return _transicion_descripcion; }
			set { _transicion_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_FLUJO_ID</c> column value.</value>
		public decimal TRANSICION_FLUJO_ID
		{
			get
			{
				if(IsTRANSICION_FLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_flujo_id;
			}
			set
			{
				_transicion_flujo_idNull = false;
				_transicion_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_FLUJO_IDNull
		{
			get { return _transicion_flujo_idNull; }
			set { _transicion_flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_FLUJO_DESCRIPCION</c> column value.</value>
		public string TRANSICION_FLUJO_DESCRIPCION
		{
			get { return _transicion_flujo_descripcion; }
			set { _transicion_flujo_descripcion = value; }
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REVISION_POSTERIOR</c> column value.
		/// </summary>
		/// <value>The <c>REVISION_POSTERIOR</c> column value.</value>
		public string REVISION_POSTERIOR
		{
			get { return _revision_posterior; }
			set { _revision_posterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COPIAR_OBSERVACION_CASO</c> column value.
		/// </summary>
		/// <value>The <c>COPIAR_OBSERVACION_CASO</c> column value.</value>
		public string COPIAR_OBSERVACION_CASO
		{
			get { return _copiar_observacion_caso; }
			set { _copiar_observacion_caso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOSTRAR_OBS_DET_REPORTE</c> column value.
		/// </summary>
		/// <value>The <c>MOSTRAR_OBS_DET_REPORTE</c> column value.</value>
		public string MOSTRAR_OBS_DET_REPORTE
		{
			get { return _mostrar_obs_det_reporte; }
			set { _mostrar_obs_det_reporte = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_FECHA_TRANSICION</c> column value.
		/// </summary>
		/// <value>The <c>USAR_FECHA_TRANSICION</c> column value.</value>
		public string USAR_FECHA_TRANSICION
		{
			get { return _usar_fecha_transicion; }
			set { _usar_fecha_transicion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTRUCTURA_OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>ESTRUCTURA_OBSERVACION</c> column value.</value>
		public string ESTRUCTURA_OBSERVACION
		{
			get { return _estructura_observacion; }
			set { _estructura_observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIFICAR_DETALLES_MISMA_CUENTA</c> column value.
		/// </summary>
		/// <value>The <c>UNIFICAR_DETALLES_MISMA_CUENTA</c> column value.</value>
		public string UNIFICAR_DETALLES_MISMA_CUENTA
		{
			get { return _unificar_detalles_misma_cuenta; }
			set { _unificar_detalles_misma_cuenta = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@PAIS_NOMBRE=");
			dynStr.Append(PAIS_NOMBRE);
			dynStr.Append("@CBA@TRANSICION_ID=");
			dynStr.Append(IsTRANSICION_IDNull ? (object)"<NULL>" : TRANSICION_ID);
			dynStr.Append("@CBA@TRANSICION_DESCRIPCION=");
			dynStr.Append(TRANSICION_DESCRIPCION);
			dynStr.Append("@CBA@TRANSICION_FLUJO_ID=");
			dynStr.Append(IsTRANSICION_FLUJO_IDNull ? (object)"<NULL>" : TRANSICION_FLUJO_ID);
			dynStr.Append("@CBA@TRANSICION_FLUJO_DESCRIPCION=");
			dynStr.Append(TRANSICION_FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@REVISION_POSTERIOR=");
			dynStr.Append(REVISION_POSTERIOR);
			dynStr.Append("@CBA@COPIAR_OBSERVACION_CASO=");
			dynStr.Append(COPIAR_OBSERVACION_CASO);
			dynStr.Append("@CBA@MOSTRAR_OBS_DET_REPORTE=");
			dynStr.Append(MOSTRAR_OBS_DET_REPORTE);
			dynStr.Append("@CBA@USAR_FECHA_TRANSICION=");
			dynStr.Append(USAR_FECHA_TRANSICION);
			dynStr.Append("@CBA@ESTRUCTURA_OBSERVACION=");
			dynStr.Append(ESTRUCTURA_OBSERVACION);
			dynStr.Append("@CBA@UNIFICAR_DETALLES_MISMA_CUENTA=");
			dynStr.Append(UNIFICAR_DETALLES_MISMA_CUENTA);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_AUTOM_INFO_COMPLRow_Base class
} // End of namespace
