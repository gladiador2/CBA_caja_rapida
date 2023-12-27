// <fileinfo name="PRESUPUESTOS_DET_CAS_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_DET_CAS_INF_COMPRow"/> that 
	/// represents a record in the <c>PRESUPUESTOS_DET_CAS_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOS_DET_CAS_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_DET_CAS_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _presupuestos_detalle_id;
		private string _presupuesto_detalle_obs;
		private decimal _presupuesto_etapa_id;
		private string _presupuesto_etapa_nombre;
		private decimal _presupuesto_id;
		private string _presupuesto_objeto;
		private decimal _caso_id;
		private decimal _caso_flujo_id;
		private string _caso_flujo_desc;
		private string _caso_estado_id;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DET_CAS_INF_COMPRow_Base"/> class.
		/// </summary>
		public PRESUPUESTOS_DET_CAS_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOS_DET_CAS_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRESUPUESTOS_DETALLE_ID != original.PRESUPUESTOS_DETALLE_ID) return true;
			if (this.PRESUPUESTO_DETALLE_OBS != original.PRESUPUESTO_DETALLE_OBS) return true;
			if (this.PRESUPUESTO_ETAPA_ID != original.PRESUPUESTO_ETAPA_ID) return true;
			if (this.PRESUPUESTO_ETAPA_NOMBRE != original.PRESUPUESTO_ETAPA_NOMBRE) return true;
			if (this.PRESUPUESTO_ID != original.PRESUPUESTO_ID) return true;
			if (this.PRESUPUESTO_OBJETO != original.PRESUPUESTO_OBJETO) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_FLUJO_ID != original.CASO_FLUJO_ID) return true;
			if (this.CASO_FLUJO_DESC != original.CASO_FLUJO_DESC) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
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
		/// Gets or sets the <c>PRESUPUESTOS_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTOS_DETALLE_ID</c> column value.</value>
		public decimal PRESUPUESTOS_DETALLE_ID
		{
			get { return _presupuestos_detalle_id; }
			set { _presupuestos_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_DETALLE_OBS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_DETALLE_OBS</c> column value.</value>
		public string PRESUPUESTO_DETALLE_OBS
		{
			get { return _presupuesto_detalle_obs; }
			set { _presupuesto_detalle_obs = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_ETAPA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ETAPA_ID</c> column value.</value>
		public decimal PRESUPUESTO_ETAPA_ID
		{
			get { return _presupuesto_etapa_id; }
			set { _presupuesto_etapa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_ETAPA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ETAPA_NOMBRE</c> column value.</value>
		public string PRESUPUESTO_ETAPA_NOMBRE
		{
			get { return _presupuesto_etapa_nombre; }
			set { _presupuesto_etapa_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ID</c> column value.</value>
		public decimal PRESUPUESTO_ID
		{
			get { return _presupuesto_id; }
			set { _presupuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_OBJETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_OBJETO</c> column value.</value>
		public string PRESUPUESTO_OBJETO
		{
			get { return _presupuesto_objeto; }
			set { _presupuesto_objeto = value; }
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
		/// Gets or sets the <c>CASO_FLUJO_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FLUJO_DESC</c> column value.</value>
		public string CASO_FLUJO_DESC
		{
			get { return _caso_flujo_desc; }
			set { _caso_flujo_desc = value; }
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
			dynStr.Append("@CBA@PRESUPUESTOS_DETALLE_ID=");
			dynStr.Append(PRESUPUESTOS_DETALLE_ID);
			dynStr.Append("@CBA@PRESUPUESTO_DETALLE_OBS=");
			dynStr.Append(PRESUPUESTO_DETALLE_OBS);
			dynStr.Append("@CBA@PRESUPUESTO_ETAPA_ID=");
			dynStr.Append(PRESUPUESTO_ETAPA_ID);
			dynStr.Append("@CBA@PRESUPUESTO_ETAPA_NOMBRE=");
			dynStr.Append(PRESUPUESTO_ETAPA_NOMBRE);
			dynStr.Append("@CBA@PRESUPUESTO_ID=");
			dynStr.Append(PRESUPUESTO_ID);
			dynStr.Append("@CBA@PRESUPUESTO_OBJETO=");
			dynStr.Append(PRESUPUESTO_OBJETO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_ID=");
			dynStr.Append(CASO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_DESC=");
			dynStr.Append(CASO_FLUJO_DESC);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOS_DET_CAS_INF_COMPRow_Base class
} // End of namespace
