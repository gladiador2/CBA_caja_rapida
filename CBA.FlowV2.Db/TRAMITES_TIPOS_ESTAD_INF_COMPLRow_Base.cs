// <fileinfo name="TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> that 
	/// represents a record in the <c>TRAMITES_TIPOS_ESTAD_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _tramite_tipo_etapa_id;
		private string _tramite_tipo_etapa_nombre;
		private decimal _tramite_tipo_id;
		private string _tramite_tipo_nombre;
		private string _es_inicio;
		private string _es_fin;
		private string _nombre;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base"/> class.
		/// </summary>
		public TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_ID != original.TRAMITE_TIPO_ETAPA_ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_NOMBRE != original.TRAMITE_TIPO_ETAPA_NOMBRE) return true;
			if (this.TRAMITE_TIPO_ID != original.TRAMITE_TIPO_ID) return true;
			if (this.TRAMITE_TIPO_NOMBRE != original.TRAMITE_TIPO_NOMBRE) return true;
			if (this.ES_INICIO != original.ES_INICIO) return true;
			if (this.ES_FIN != original.ES_FIN) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			
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
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_ID
		{
			get { return _tramite_tipo_etapa_id; }
			set { _tramite_tipo_etapa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_ETAPA_NOMBRE
		{
			get { return _tramite_tipo_etapa_nombre; }
			set { _tramite_tipo_etapa_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ID
		{
			get { return _tramite_tipo_id; }
			set { _tramite_tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_NOMBRE
		{
			get { return _tramite_tipo_nombre; }
			set { _tramite_tipo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>ES_INICIO</c> column value.</value>
		public string ES_INICIO
		{
			get { return _es_inicio; }
			set { _es_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_FIN</c> column value.
		/// </summary>
		/// <value>The <c>ES_FIN</c> column value.</value>
		public string ES_FIN
		{
			get { return _es_fin; }
			set { _es_fin = value; }
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_ID=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_NOMBRE);
			dynStr.Append("@CBA@TRAMITE_TIPO_ID=");
			dynStr.Append(TRAMITE_TIPO_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_NOMBRE);
			dynStr.Append("@CBA@ES_INICIO=");
			dynStr.Append(ES_INICIO);
			dynStr.Append("@CBA@ES_FIN=");
			dynStr.Append(ES_FIN);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of TRAMITES_TIPOS_ESTAD_INF_COMPLRow_Base class
} // End of namespace
