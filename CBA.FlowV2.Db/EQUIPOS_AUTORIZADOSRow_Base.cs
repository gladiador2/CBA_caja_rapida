// <fileinfo name="EQUIPOS_AUTORIZADOSRow_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOSRow"/> that 
	/// represents a record in the <c>EQUIPOS_AUTORIZADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EQUIPOS_AUTORIZADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOSRow_Base
	{
		private decimal _id;
		private string _numero_factura;
		private string _asamar;
		private string _despacho;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _confirmado;
		private decimal _persona_id;
		private bool _persona_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOSRow_Base"/> class.
		/// </summary>
		public EQUIPOS_AUTORIZADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EQUIPOS_AUTORIZADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NUMERO_FACTURA != original.NUMERO_FACTURA) return true;
			if (this.ASAMAR != original.ASAMAR) return true;
			if (this.DESPACHO != original.DESPACHO) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.CONFIRMADO != original.CONFIRMADO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			
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
		/// Gets or sets the <c>NUMERO_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_FACTURA</c> column value.</value>
		public string NUMERO_FACTURA
		{
			get { return _numero_factura; }
			set { _numero_factura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ASAMAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ASAMAR</c> column value.</value>
		public string ASAMAR
		{
			get { return _asamar; }
			set { _asamar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO</c> column value.</value>
		public string DESPACHO
		{
			get { return _despacho; }
			set { _despacho = value; }
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
		/// Gets or sets the <c>CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONFIRMADO</c> column value.</value>
		public string CONFIRMADO
		{
			get { return _confirmado; }
			set { _confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
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
			dynStr.Append("@CBA@NUMERO_FACTURA=");
			dynStr.Append(NUMERO_FACTURA);
			dynStr.Append("@CBA@ASAMAR=");
			dynStr.Append(ASAMAR);
			dynStr.Append("@CBA@DESPACHO=");
			dynStr.Append(DESPACHO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@CONFIRMADO=");
			dynStr.Append(CONFIRMADO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of EQUIPOS_AUTORIZADOSRow_Base class
} // End of namespace
