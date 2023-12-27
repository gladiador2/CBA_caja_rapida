// <fileinfo name="REPORTES_CONTADORESRow_Base.cs">
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
	/// The base class for <see cref="REPORTES_CONTADORESRow"/> that 
	/// represents a record in the <c>REPORTES_CONTADORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REPORTES_CONTADORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPORTES_CONTADORESRow_Base
	{
		private decimal _id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _cliente_ip;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _exito;
		private decimal _reporte_id;
		private bool _reporte_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTES_CONTADORESRow_Base"/> class.
		/// </summary>
		public REPORTES_CONTADORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REPORTES_CONTADORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.CLIENTE_IP != original.CLIENTE_IP) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.EXITO != original.EXITO) return true;
			if (this.IsREPORTE_IDNull != original.IsREPORTE_IDNull) return true;
			if (!this.IsREPORTE_IDNull && !original.IsREPORTE_IDNull)
				if (this.REPORTE_ID != original.REPORTE_ID) return true;
			
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CLIENTE_IP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE_IP</c> column value.</value>
		public string CLIENTE_IP
		{
			get { return _cliente_ip; }
			set { _cliente_ip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXITO</c> column value.</value>
		public string EXITO
		{
			get { return _exito; }
			set { _exito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_ID</c> column value.</value>
		public decimal REPORTE_ID
		{
			get
			{
				if(IsREPORTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_id;
			}
			set
			{
				_reporte_idNull = false;
				_reporte_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_IDNull
		{
			get { return _reporte_idNull; }
			set { _reporte_idNull = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@CLIENTE_IP=");
			dynStr.Append(CLIENTE_IP);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@EXITO=");
			dynStr.Append(EXITO);
			dynStr.Append("@CBA@REPORTE_ID=");
			dynStr.Append(IsREPORTE_IDNull ? (object)"<NULL>" : REPORTE_ID);
			return dynStr.ToString();
		}
	} // End of REPORTES_CONTADORESRow_Base class
} // End of namespace
