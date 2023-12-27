// <fileinfo name="CRM_HILOS_ENTRADAS_USUARIOSRow_Base.cs">
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
	/// The base class for <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> that 
	/// represents a record in the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CRM_HILOS_ENTRADAS_USUARIOSRow_Base
	{
		private decimal _id;
		private decimal _crm_hilos_entrada_id;
		private decimal _usuario_id;
		private System.DateTime _fecha_lectura;
		private bool _fecha_lecturaNull = true;
		private System.DateTime _fecha_recordatorio;
		private bool _fecha_recordatorioNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow_Base"/> class.
		/// </summary>
		public CRM_HILOS_ENTRADAS_USUARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CRM_HILOS_ENTRADAS_USUARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CRM_HILOS_ENTRADA_ID != original.CRM_HILOS_ENTRADA_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsFECHA_LECTURANull != original.IsFECHA_LECTURANull) return true;
			if (!this.IsFECHA_LECTURANull && !original.IsFECHA_LECTURANull)
				if (this.FECHA_LECTURA != original.FECHA_LECTURA) return true;
			if (this.IsFECHA_RECORDATORIONull != original.IsFECHA_RECORDATORIONull) return true;
			if (!this.IsFECHA_RECORDATORIONull && !original.IsFECHA_RECORDATORIONull)
				if (this.FECHA_RECORDATORIO != original.FECHA_RECORDATORIO) return true;
			
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
		/// Gets or sets the <c>CRM_HILOS_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CRM_HILOS_ENTRADA_ID</c> column value.</value>
		public decimal CRM_HILOS_ENTRADA_ID
		{
			get { return _crm_hilos_entrada_id; }
			set { _crm_hilos_entrada_id = value; }
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
		/// Gets or sets the <c>FECHA_LECTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_LECTURA</c> column value.</value>
		public System.DateTime FECHA_LECTURA
		{
			get
			{
				if(IsFECHA_LECTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_lectura;
			}
			set
			{
				_fecha_lecturaNull = false;
				_fecha_lectura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_LECTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_LECTURANull
		{
			get { return _fecha_lecturaNull; }
			set { _fecha_lecturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECORDATORIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECORDATORIO</c> column value.</value>
		public System.DateTime FECHA_RECORDATORIO
		{
			get
			{
				if(IsFECHA_RECORDATORIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_recordatorio;
			}
			set
			{
				_fecha_recordatorioNull = false;
				_fecha_recordatorio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECORDATORIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECORDATORIONull
		{
			get { return _fecha_recordatorioNull; }
			set { _fecha_recordatorioNull = value; }
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
			dynStr.Append("@CBA@CRM_HILOS_ENTRADA_ID=");
			dynStr.Append(CRM_HILOS_ENTRADA_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FECHA_LECTURA=");
			dynStr.Append(IsFECHA_LECTURANull ? (object)"<NULL>" : FECHA_LECTURA);
			dynStr.Append("@CBA@FECHA_RECORDATORIO=");
			dynStr.Append(IsFECHA_RECORDATORIONull ? (object)"<NULL>" : FECHA_RECORDATORIO);
			return dynStr.ToString();
		}
	} // End of CRM_HILOS_ENTRADAS_USUARIOSRow_Base class
} // End of namespace
