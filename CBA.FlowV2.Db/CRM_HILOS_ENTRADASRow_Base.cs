// <fileinfo name="CRM_HILOS_ENTRADASRow_Base.cs">
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
	/// The base class for <see cref="CRM_HILOS_ENTRADASRow"/> that 
	/// represents a record in the <c>CRM_HILOS_ENTRADAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CRM_HILOS_ENTRADASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CRM_HILOS_ENTRADASRow_Base
	{
		private decimal _id;
		private decimal _crm_hilo_id;
		private System.DateTime _fecha;
		private string _texto;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
		private string _estado;
		private System.DateTime _fecha_alarma;
		private bool _fecha_alarmaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CRM_HILOS_ENTRADASRow_Base"/> class.
		/// </summary>
		public CRM_HILOS_ENTRADASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CRM_HILOS_ENTRADASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CRM_HILO_ID != original.CRM_HILO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsFECHA_ALARMANull != original.IsFECHA_ALARMANull) return true;
			if (!this.IsFECHA_ALARMANull && !original.IsFECHA_ALARMANull)
				if (this.FECHA_ALARMA != original.FECHA_ALARMA) return true;
			
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
		/// Gets or sets the <c>CRM_HILO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CRM_HILO_ID</c> column value.</value>
		public decimal CRM_HILO_ID
		{
			get { return _crm_hilo_id; }
			set { _crm_hilo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ALARMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ALARMA</c> column value.</value>
		public System.DateTime FECHA_ALARMA
		{
			get
			{
				if(IsFECHA_ALARMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_alarma;
			}
			set
			{
				_fecha_alarmaNull = false;
				_fecha_alarma = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ALARMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ALARMANull
		{
			get { return _fecha_alarmaNull; }
			set { _fecha_alarmaNull = value; }
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
			dynStr.Append("@CBA@CRM_HILO_ID=");
			dynStr.Append(CRM_HILO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_ALARMA=");
			dynStr.Append(IsFECHA_ALARMANull ? (object)"<NULL>" : FECHA_ALARMA);
			return dynStr.ToString();
		}
	} // End of CRM_HILOS_ENTRADASRow_Base class
} // End of namespace
