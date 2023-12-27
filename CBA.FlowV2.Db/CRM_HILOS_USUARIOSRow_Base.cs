// <fileinfo name="CRM_HILOS_USUARIOSRow_Base.cs">
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
	/// The base class for <see cref="CRM_HILOS_USUARIOSRow"/> that 
	/// represents a record in the <c>CRM_HILOS_USUARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CRM_HILOS_USUARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CRM_HILOS_USUARIOSRow_Base
	{
		private decimal _id;
		private decimal _crm_hilo_id;
		private decimal _usuario_id;
		private System.DateTime _fecha_archivado;
		private bool _fecha_archivadoNull = true;
		private string _destacado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CRM_HILOS_USUARIOSRow_Base"/> class.
		/// </summary>
		public CRM_HILOS_USUARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CRM_HILOS_USUARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CRM_HILO_ID != original.CRM_HILO_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsFECHA_ARCHIVADONull != original.IsFECHA_ARCHIVADONull) return true;
			if (!this.IsFECHA_ARCHIVADONull && !original.IsFECHA_ARCHIVADONull)
				if (this.FECHA_ARCHIVADO != original.FECHA_ARCHIVADO) return true;
			if (this.DESTACADO != original.DESTACADO) return true;
			
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ARCHIVADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ARCHIVADO</c> column value.</value>
		public System.DateTime FECHA_ARCHIVADO
		{
			get
			{
				if(IsFECHA_ARCHIVADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_archivado;
			}
			set
			{
				_fecha_archivadoNull = false;
				_fecha_archivado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ARCHIVADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ARCHIVADONull
		{
			get { return _fecha_archivadoNull; }
			set { _fecha_archivadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESTACADO</c> column value.
		/// </summary>
		/// <value>The <c>DESTACADO</c> column value.</value>
		public string DESTACADO
		{
			get { return _destacado; }
			set { _destacado = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FECHA_ARCHIVADO=");
			dynStr.Append(IsFECHA_ARCHIVADONull ? (object)"<NULL>" : FECHA_ARCHIVADO);
			dynStr.Append("@CBA@DESTACADO=");
			dynStr.Append(DESTACADO);
			return dynStr.ToString();
		}
	} // End of CRM_HILOS_USUARIOSRow_Base class
} // End of namespace
