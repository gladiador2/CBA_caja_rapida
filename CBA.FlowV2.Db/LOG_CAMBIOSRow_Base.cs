// <fileinfo name="LOG_CAMBIOSRow_Base.cs">
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
	/// The base class for <see cref="LOG_CAMBIOSRow"/> that 
	/// represents a record in the <c>LOG_CAMBIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LOG_CAMBIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LOG_CAMBIOSRow_Base
	{
		private decimal _id;
		private decimal _log_campo_id;
		private decimal _registro_id;
		private string _valor_anterior;
		private string _valor_nuevo;
		private System.DateTime _fecha;
		private decimal _usuario_id;
		private string _ip;
		private decimal _fecha_formato_numero;

		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_CAMBIOSRow_Base"/> class.
		/// </summary>
		public LOG_CAMBIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LOG_CAMBIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LOG_CAMPO_ID != original.LOG_CAMPO_ID) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.VALOR_ANTERIOR != original.VALOR_ANTERIOR) return true;
			if (this.VALOR_NUEVO != original.VALOR_NUEVO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IP != original.IP) return true;
			if (this.FECHA_FORMATO_NUMERO != original.FECHA_FORMATO_NUMERO) return true;
			
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
		/// Gets or sets the <c>LOG_CAMPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_ID</c> column value.</value>
		public decimal LOG_CAMPO_ID
		{
			get { return _log_campo_id; }
			set { _log_campo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_ANTERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_ANTERIOR</c> column value.</value>
		public string VALOR_ANTERIOR
		{
			get { return _valor_anterior; }
			set { _valor_anterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_NUEVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NUEVO</c> column value.</value>
		public string VALOR_NUEVO
		{
			get { return _valor_nuevo; }
			set { _valor_nuevo = value; }
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IP</c> column value.</value>
		public string IP
		{
			get { return _ip; }
			set { _ip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMATO_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMATO_NUMERO</c> column value.</value>
		public decimal FECHA_FORMATO_NUMERO
		{
			get { return _fecha_formato_numero; }
			set { _fecha_formato_numero = value; }
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
			dynStr.Append("@CBA@LOG_CAMPO_ID=");
			dynStr.Append(LOG_CAMPO_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			dynStr.Append("@CBA@VALOR_ANTERIOR=");
			dynStr.Append(VALOR_ANTERIOR);
			dynStr.Append("@CBA@VALOR_NUEVO=");
			dynStr.Append(VALOR_NUEVO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			return dynStr.ToString();
		}
	} // End of LOG_CAMBIOSRow_Base class
} // End of namespace
