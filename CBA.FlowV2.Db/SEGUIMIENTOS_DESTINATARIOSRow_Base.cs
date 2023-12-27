// <fileinfo name="SEGUIMIENTOS_DESTINATARIOSRow_Base.cs">
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
	/// The base class for <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> that 
	/// represents a record in the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SEGUIMIENTOS_DESTINATARIOSRow_Base
	{
		private decimal _id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _mail;
		private System.DateTime _fecha_inicia_seguimiento;
		private System.DateTime _fecha_cancela_seguimiento;
		private bool _fecha_cancela_seguimientoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _log_campo_id;
		private bool _log_campo_idNull = true;
		private decimal _registro_id;
		private bool _registro_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="SEGUIMIENTOS_DESTINATARIOSRow_Base"/> class.
		/// </summary>
		public SEGUIMIENTOS_DESTINATARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(SEGUIMIENTOS_DESTINATARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.MAIL != original.MAIL) return true;
			if (this.FECHA_INICIA_SEGUIMIENTO != original.FECHA_INICIA_SEGUIMIENTO) return true;
			if (this.IsFECHA_CANCELA_SEGUIMIENTONull != original.IsFECHA_CANCELA_SEGUIMIENTONull) return true;
			if (!this.IsFECHA_CANCELA_SEGUIMIENTONull && !original.IsFECHA_CANCELA_SEGUIMIENTONull)
				if (this.FECHA_CANCELA_SEGUIMIENTO != original.FECHA_CANCELA_SEGUIMIENTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsLOG_CAMPO_IDNull != original.IsLOG_CAMPO_IDNull) return true;
			if (!this.IsLOG_CAMPO_IDNull && !original.IsLOG_CAMPO_IDNull)
				if (this.LOG_CAMPO_ID != original.LOG_CAMPO_ID) return true;
			if (this.IsREGISTRO_IDNull != original.IsREGISTRO_IDNull) return true;
			if (!this.IsREGISTRO_IDNull && !original.IsREGISTRO_IDNull)
				if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			
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
		/// Gets or sets the <c>MAIL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MAIL</c> column value.</value>
		public string MAIL
		{
			get { return _mail; }
			set { _mail = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIA_SEGUIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIA_SEGUIMIENTO</c> column value.</value>
		public System.DateTime FECHA_INICIA_SEGUIMIENTO
		{
			get { return _fecha_inicia_seguimiento; }
			set { _fecha_inicia_seguimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CANCELA_SEGUIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CANCELA_SEGUIMIENTO</c> column value.</value>
		public System.DateTime FECHA_CANCELA_SEGUIMIENTO
		{
			get
			{
				if(IsFECHA_CANCELA_SEGUIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cancela_seguimiento;
			}
			set
			{
				_fecha_cancela_seguimientoNull = false;
				_fecha_cancela_seguimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CANCELA_SEGUIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CANCELA_SEGUIMIENTONull
		{
			get { return _fecha_cancela_seguimientoNull; }
			set { _fecha_cancela_seguimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOG_CAMPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_ID</c> column value.</value>
		public decimal LOG_CAMPO_ID
		{
			get
			{
				if(IsLOG_CAMPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _log_campo_id;
			}
			set
			{
				_log_campo_idNull = false;
				_log_campo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOG_CAMPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOG_CAMPO_IDNull
		{
			get { return _log_campo_idNull; }
			set { _log_campo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get
			{
				if(IsREGISTRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _registro_id;
			}
			set
			{
				_registro_idNull = false;
				_registro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGISTRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGISTRO_IDNull
		{
			get { return _registro_idNull; }
			set { _registro_idNull = value; }
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
			dynStr.Append("@CBA@MAIL=");
			dynStr.Append(MAIL);
			dynStr.Append("@CBA@FECHA_INICIA_SEGUIMIENTO=");
			dynStr.Append(FECHA_INICIA_SEGUIMIENTO);
			dynStr.Append("@CBA@FECHA_CANCELA_SEGUIMIENTO=");
			dynStr.Append(IsFECHA_CANCELA_SEGUIMIENTONull ? (object)"<NULL>" : FECHA_CANCELA_SEGUIMIENTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@LOG_CAMPO_ID=");
			dynStr.Append(IsLOG_CAMPO_IDNull ? (object)"<NULL>" : LOG_CAMPO_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(IsREGISTRO_IDNull ? (object)"<NULL>" : REGISTRO_ID);
			return dynStr.ToString();
		}
	} // End of SEGUIMIENTOS_DESTINATARIOSRow_Base class
} // End of namespace
