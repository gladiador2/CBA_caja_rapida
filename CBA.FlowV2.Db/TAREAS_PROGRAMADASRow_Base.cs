// <fileinfo name="TAREAS_PROGRAMADASRow_Base.cs">
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
	/// The base class for <see cref="TAREAS_PROGRAMADASRow"/> that 
	/// represents a record in the <c>TAREAS_PROGRAMADAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TAREAS_PROGRAMADASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TAREAS_PROGRAMADASRow_Base
	{
		private decimal _id;
		private decimal _tipo_id;
		private System.DateTime _fecha_proxima_ejecucion;
		private bool _fecha_proxima_ejecucionNull = true;
		private System.DateTime _fecha_ultima_ejecucion;
		private bool _fecha_ultima_ejecucionNull = true;
		private string _gestor_repeticion_json;
		private string _datos_json;
		private string _estado;
		private decimal _usuario_id;
		private System.DateTime _fecha_creacion;
		private string _observacion;
		private string _gestor_avisos_json;
		private string _en_ejecucion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_PROGRAMADASRow_Base"/> class.
		/// </summary>
		public TAREAS_PROGRAMADASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TAREAS_PROGRAMADASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_ID != original.TIPO_ID) return true;
			if (this.IsFECHA_PROXIMA_EJECUCIONNull != original.IsFECHA_PROXIMA_EJECUCIONNull) return true;
			if (!this.IsFECHA_PROXIMA_EJECUCIONNull && !original.IsFECHA_PROXIMA_EJECUCIONNull)
				if (this.FECHA_PROXIMA_EJECUCION != original.FECHA_PROXIMA_EJECUCION) return true;
			if (this.IsFECHA_ULTIMA_EJECUCIONNull != original.IsFECHA_ULTIMA_EJECUCIONNull) return true;
			if (!this.IsFECHA_ULTIMA_EJECUCIONNull && !original.IsFECHA_ULTIMA_EJECUCIONNull)
				if (this.FECHA_ULTIMA_EJECUCION != original.FECHA_ULTIMA_EJECUCION) return true;
			if (this.GESTOR_REPETICION_JSON != original.GESTOR_REPETICION_JSON) return true;
			if (this.DATOS_JSON != original.DATOS_JSON) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.GESTOR_AVISOS_JSON != original.GESTOR_AVISOS_JSON) return true;
			if (this.EN_EJECUCION != original.EN_EJECUCION) return true;
			
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
		/// Gets or sets the <c>TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ID</c> column value.</value>
		public decimal TIPO_ID
		{
			get { return _tipo_id; }
			set { _tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PROXIMA_EJECUCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_PROXIMA_EJECUCION</c> column value.</value>
		public System.DateTime FECHA_PROXIMA_EJECUCION
		{
			get
			{
				if(IsFECHA_PROXIMA_EJECUCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_proxima_ejecucion;
			}
			set
			{
				_fecha_proxima_ejecucionNull = false;
				_fecha_proxima_ejecucion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_PROXIMA_EJECUCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_PROXIMA_EJECUCIONNull
		{
			get { return _fecha_proxima_ejecucionNull; }
			set { _fecha_proxima_ejecucionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMA_EJECUCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMA_EJECUCION</c> column value.</value>
		public System.DateTime FECHA_ULTIMA_EJECUCION
		{
			get
			{
				if(IsFECHA_ULTIMA_EJECUCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultima_ejecucion;
			}
			set
			{
				_fecha_ultima_ejecucionNull = false;
				_fecha_ultima_ejecucion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMA_EJECUCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMA_EJECUCIONNull
		{
			get { return _fecha_ultima_ejecucionNull; }
			set { _fecha_ultima_ejecucionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GESTOR_REPETICION_JSON</c> column value.
		/// </summary>
		/// <value>The <c>GESTOR_REPETICION_JSON</c> column value.</value>
		public string GESTOR_REPETICION_JSON
		{
			get { return _gestor_repeticion_json; }
			set { _gestor_repeticion_json = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DATOS_JSON</c> column value.
		/// </summary>
		/// <value>The <c>DATOS_JSON</c> column value.</value>
		public string DATOS_JSON
		{
			get { return _datos_json; }
			set { _datos_json = value; }
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
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>GESTOR_AVISOS_JSON</c> column value.
		/// </summary>
		/// <value>The <c>GESTOR_AVISOS_JSON</c> column value.</value>
		public string GESTOR_AVISOS_JSON
		{
			get { return _gestor_avisos_json; }
			set { _gestor_avisos_json = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EN_EJECUCION</c> column value.
		/// </summary>
		/// <value>The <c>EN_EJECUCION</c> column value.</value>
		public string EN_EJECUCION
		{
			get { return _en_ejecucion; }
			set { _en_ejecucion = value; }
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
			dynStr.Append("@CBA@TIPO_ID=");
			dynStr.Append(TIPO_ID);
			dynStr.Append("@CBA@FECHA_PROXIMA_EJECUCION=");
			dynStr.Append(IsFECHA_PROXIMA_EJECUCIONNull ? (object)"<NULL>" : FECHA_PROXIMA_EJECUCION);
			dynStr.Append("@CBA@FECHA_ULTIMA_EJECUCION=");
			dynStr.Append(IsFECHA_ULTIMA_EJECUCIONNull ? (object)"<NULL>" : FECHA_ULTIMA_EJECUCION);
			dynStr.Append("@CBA@GESTOR_REPETICION_JSON=");
			dynStr.Append(GESTOR_REPETICION_JSON);
			dynStr.Append("@CBA@DATOS_JSON=");
			dynStr.Append(DATOS_JSON);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@GESTOR_AVISOS_JSON=");
			dynStr.Append(GESTOR_AVISOS_JSON);
			dynStr.Append("@CBA@EN_EJECUCION=");
			dynStr.Append(EN_EJECUCION);
			return dynStr.ToString();
		}
	} // End of TAREAS_PROGRAMADASRow_Base class
} // End of namespace
