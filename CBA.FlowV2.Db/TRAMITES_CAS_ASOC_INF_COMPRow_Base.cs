// <fileinfo name="TRAMITES_CAS_ASOC_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_CAS_ASOC_INF_COMPRow"/> that 
	/// represents a record in the <c>TRAMITES_CAS_ASOC_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_CAS_ASOC_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_CAS_ASOC_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _tramite_id;
		private string _tramite_titulo;
		private decimal _caso_id;
		private decimal _caso_flujo_id;
		private string _caso_flujo_descripcion;
		private string _observacion;
		private System.DateTime _fecha_agregado;
		private decimal _usuario_id;
		private string _usuario_nombre;
		private decimal _tramite_tipo_etapa_id;
		private bool _tramite_tipo_etapa_idNull = true;
		private string _tramite_tipo_etapa_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_CAS_ASOC_INF_COMPRow_Base"/> class.
		/// </summary>
		public TRAMITES_CAS_ASOC_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_CAS_ASOC_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_ID != original.TRAMITE_ID) return true;
			if (this.TRAMITE_TITULO != original.TRAMITE_TITULO) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_FLUJO_ID != original.CASO_FLUJO_ID) return true;
			if (this.CASO_FLUJO_DESCRIPCION != original.CASO_FLUJO_DESCRIPCION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FECHA_AGREGADO != original.FECHA_AGREGADO) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.IsTRAMITE_TIPO_ETAPA_IDNull != original.IsTRAMITE_TIPO_ETAPA_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ETAPA_IDNull && !original.IsTRAMITE_TIPO_ETAPA_IDNull)
				if (this.TRAMITE_TIPO_ETAPA_ID != original.TRAMITE_TIPO_ETAPA_ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_NOMBRE != original.TRAMITE_TIPO_ETAPA_NOMBRE) return true;
			
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
		/// Gets or sets the <c>TRAMITE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_ID</c> column value.</value>
		public decimal TRAMITE_ID
		{
			get { return _tramite_id; }
			set { _tramite_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TITULO</c> column value.</value>
		public string TRAMITE_TITULO
		{
			get { return _tramite_titulo; }
			set { _tramite_titulo = value; }
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
		/// Gets or sets the <c>FECHA_AGREGADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_AGREGADO</c> column value.</value>
		public System.DateTime FECHA_AGREGADO
		{
			get { return _fecha_agregado; }
			set { _fecha_agregado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ETAPA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_etapa_id;
			}
			set
			{
				_tramite_tipo_etapa_idNull = false;
				_tramite_tipo_etapa_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ETAPA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ETAPA_IDNull
		{
			get { return _tramite_tipo_etapa_idNull; }
			set { _tramite_tipo_etapa_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_ETAPA_NOMBRE
		{
			get { return _tramite_tipo_etapa_nombre; }
			set { _tramite_tipo_etapa_nombre = value; }
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
			dynStr.Append("@CBA@TRAMITE_ID=");
			dynStr.Append(TRAMITE_ID);
			dynStr.Append("@CBA@TRAMITE_TITULO=");
			dynStr.Append(TRAMITE_TITULO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_ID=");
			dynStr.Append(CASO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_FLUJO_DESCRIPCION=");
			dynStr.Append(CASO_FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FECHA_AGREGADO=");
			dynStr.Append(FECHA_AGREGADO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ETAPA_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ETAPA_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of TRAMITES_CAS_ASOC_INF_COMPRow_Base class
} // End of namespace
