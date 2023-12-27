// <fileinfo name="LOG_ACTIVIDADESRow_Base.cs">
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
	/// The base class for <see cref="LOG_ACTIVIDADESRow"/> that 
	/// represents a record in the <c>LOG_ACTIVIDADES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LOG_ACTIVIDADESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LOG_ACTIVIDADESRow_Base
	{
		private decimal _id;
		private string _tns_name;
		private string _ip;
		private System.DateTime _fecha_actividad;
		private System.DateTime _fecha_proxima_estimada;
		private string _identificador;

		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_ACTIVIDADESRow_Base"/> class.
		/// </summary>
		public LOG_ACTIVIDADESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LOG_ACTIVIDADESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TNS_NAME != original.TNS_NAME) return true;
			if (this.IP != original.IP) return true;
			if (this.FECHA_ACTIVIDAD != original.FECHA_ACTIVIDAD) return true;
			if (this.FECHA_PROXIMA_ESTIMADA != original.FECHA_PROXIMA_ESTIMADA) return true;
			if (this.IDENTIFICADOR != original.IDENTIFICADOR) return true;
			
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
		/// Gets or sets the <c>TNS_NAME</c> column value.
		/// </summary>
		/// <value>The <c>TNS_NAME</c> column value.</value>
		public string TNS_NAME
		{
			get { return _tns_name; }
			set { _tns_name = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IP</c> column value.
		/// </summary>
		/// <value>The <c>IP</c> column value.</value>
		public string IP
		{
			get { return _ip; }
			set { _ip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ACTIVIDAD</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ACTIVIDAD</c> column value.</value>
		public System.DateTime FECHA_ACTIVIDAD
		{
			get { return _fecha_actividad; }
			set { _fecha_actividad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PROXIMA_ESTIMADA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_PROXIMA_ESTIMADA</c> column value.</value>
		public System.DateTime FECHA_PROXIMA_ESTIMADA
		{
			get { return _fecha_proxima_estimada; }
			set { _fecha_proxima_estimada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IDENTIFICADOR</c> column value.
		/// </summary>
		/// <value>The <c>IDENTIFICADOR</c> column value.</value>
		public string IDENTIFICADOR
		{
			get { return _identificador; }
			set { _identificador = value; }
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
			dynStr.Append("@CBA@TNS_NAME=");
			dynStr.Append(TNS_NAME);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@FECHA_ACTIVIDAD=");
			dynStr.Append(FECHA_ACTIVIDAD);
			dynStr.Append("@CBA@FECHA_PROXIMA_ESTIMADA=");
			dynStr.Append(FECHA_PROXIMA_ESTIMADA);
			dynStr.Append("@CBA@IDENTIFICADOR=");
			dynStr.Append(IDENTIFICADOR);
			return dynStr.ToString();
		}
	} // End of LOG_ACTIVIDADESRow_Base class
} // End of namespace
