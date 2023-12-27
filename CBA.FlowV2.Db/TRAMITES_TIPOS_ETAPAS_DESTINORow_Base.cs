// <fileinfo name="TRAMITES_TIPOS_ETAPAS_DESTINORow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_TIPOS_ETAPAS_DESTINORow"/> that 
	/// represents a record in the <c>TRAMITES_TIPOS_ETAPAS_DESTINO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_TIPOS_ETAPAS_DESTINORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOS_ETAPAS_DESTINORow_Base
	{
		private decimal _id;
		private decimal _tramite_tipo_estado_origen_id;
		private decimal _tramite_tipo_etapa_destino_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOS_ETAPAS_DESTINORow_Base"/> class.
		/// </summary>
		public TRAMITES_TIPOS_ETAPAS_DESTINORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_TIPOS_ETAPAS_DESTINORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_TIPO_ESTADO_ORIGEN_ID != original.TRAMITE_TIPO_ESTADO_ORIGEN_ID) return true;
			if (this.TRAMITE_TIPO_ETAPA_DESTINO_ID != original.TRAMITE_TIPO_ETAPA_DESTINO_ID) return true;
			
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
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_DESTINO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_DESTINO_ID
		{
			get { return _tramite_tipo_etapa_destino_id; }
			set { _tramite_tipo_etapa_destino_id = value; }
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
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_DESTINO_ID=");
			dynStr.Append(TRAMITE_TIPO_ETAPA_DESTINO_ID);
			return dynStr.ToString();
		}
	} // End of TRAMITES_TIPOS_ETAPAS_DESTINORow_Base class
} // End of namespace
