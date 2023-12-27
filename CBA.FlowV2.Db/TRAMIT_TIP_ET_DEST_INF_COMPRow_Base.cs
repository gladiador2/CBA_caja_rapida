// <fileinfo name="TRAMIT_TIP_ET_DEST_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TRAMIT_TIP_ET_DEST_INF_COMPRow"/> that 
	/// represents a record in the <c>TRAMIT_TIP_ET_DEST_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMIT_TIP_ET_DEST_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_TIP_ET_DEST_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _tramite_tipo_estado_origen_id;
		private string _tramite_tipo_estado_nombre;
		private decimal _tramite_tipo_etapa_destino_id;
		private string _tramites_tipos_etapas_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_TIP_ET_DEST_INF_COMPRow_Base"/> class.
		/// </summary>
		public TRAMIT_TIP_ET_DEST_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMIT_TIP_ET_DEST_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_TIPO_ESTADO_ORIGEN_ID != original.TRAMITE_TIPO_ESTADO_ORIGEN_ID) return true;
			if (this.TRAMITE_TIPO_ESTADO_NOMBRE != original.TRAMITE_TIPO_ESTADO_NOMBRE) return true;
			if (this.TRAMITE_TIPO_ETAPA_DESTINO_ID != original.TRAMITE_TIPO_ETAPA_DESTINO_ID) return true;
			if (this.TRAMITES_TIPOS_ETAPAS_NOMBRE != original.TRAMITES_TIPOS_ETAPAS_NOMBRE) return true;
			
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
		/// Gets or sets the <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ESTADO_ORIGEN_ID
		{
			get { return _tramite_tipo_estado_origen_id; }
			set { _tramite_tipo_estado_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ESTADO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ESTADO_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_ESTADO_NOMBRE
		{
			get { return _tramite_tipo_estado_nombre; }
			set { _tramite_tipo_estado_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_DESTINO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_DESTINO_ID
		{
			get { return _tramite_tipo_etapa_destino_id; }
			set { _tramite_tipo_etapa_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITES_TIPOS_ETAPAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITES_TIPOS_ETAPAS_NOMBRE</c> column value.</value>
		public string TRAMITES_TIPOS_ETAPAS_NOMBRE
		{
			get { return _tramites_tipos_etapas_nombre; }
			set { _tramites_tipos_etapas_nombre = value; }
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
			dynStr.Append("@CBA@TRAMITE_TIPO_ESTADO_ORIGEN_ID=");
			dynStr.Append(TRAMITE_TIPO_ESTADO_ORIGEN_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ESTADO_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_ESTADO_NOMBRE);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_DESTINO_ID=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_DESTINO_ID);
			dynStr.Append("@CBA@TRAMITES_TIPOS_ETAPAS_NOMBRE=");
			dynStr.Append(TRAMITES_TIPOS_ETAPAS_NOMBRE);
			return dynStr.ToString();
		}
	} // End of TRAMIT_TIP_ET_DEST_INF_COMPRow_Base class
} // End of namespace
