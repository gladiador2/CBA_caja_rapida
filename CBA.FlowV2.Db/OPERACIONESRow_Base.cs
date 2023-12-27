// <fileinfo name="OPERACIONESRow_Base.cs">
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
	/// The base class for <see cref="OPERACIONESRow"/> that 
	/// represents a record in the <c>OPERACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OPERACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OPERACIONESRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _tipo_operacion_id;
		private System.DateTime _fecha;
		private string _estado_original_id;
		private string _estado_resultante_id;
		private string _comentario;
		private string _ip;
		private decimal _transicion_id;
		private bool _transicion_idNull = true;
		private decimal _fecha_formato_numero;

		/// <summary>
		/// Initializes a new instance of the <see cref="OPERACIONESRow_Base"/> class.
		/// </summary>
		public OPERACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OPERACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.TIPO_OPERACION_ID != original.TIPO_OPERACION_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.ESTADO_ORIGINAL_ID != original.ESTADO_ORIGINAL_ID) return true;
			if (this.ESTADO_RESULTANTE_ID != original.ESTADO_RESULTANTE_ID) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			if (this.IP != original.IP) return true;
			if (this.IsTRANSICION_IDNull != original.IsTRANSICION_IDNull) return true;
			if (!this.IsTRANSICION_IDNull && !original.IsTRANSICION_IDNull)
				if (this.TRANSICION_ID != original.TRANSICION_ID) return true;
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
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
		/// Gets or sets the <c>TIPO_OPERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_OPERACION_ID</c> column value.</value>
		public decimal TIPO_OPERACION_ID
		{
			get { return _tipo_operacion_id; }
			set { _tipo_operacion_id = value; }
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
		/// Gets or sets the <c>ESTADO_ORIGINAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGINAL_ID</c> column value.</value>
		public string ESTADO_ORIGINAL_ID
		{
			get { return _estado_original_id; }
			set { _estado_original_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_RESULTANTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_RESULTANTE_ID</c> column value.</value>
		public string ESTADO_RESULTANTE_ID
		{
			get { return _estado_resultante_id; }
			set { _estado_resultante_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
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
		/// Gets or sets the <c>TRANSICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_ID</c> column value.</value>
		public decimal TRANSICION_ID
		{
			get
			{
				if(IsTRANSICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_id;
			}
			set
			{
				_transicion_idNull = false;
				_transicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_IDNull
		{
			get { return _transicion_idNull; }
			set { _transicion_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@TIPO_OPERACION_ID=");
			dynStr.Append(TIPO_OPERACION_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@ESTADO_ORIGINAL_ID=");
			dynStr.Append(ESTADO_ORIGINAL_ID);
			dynStr.Append("@CBA@ESTADO_RESULTANTE_ID=");
			dynStr.Append(ESTADO_RESULTANTE_ID);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@TRANSICION_ID=");
			dynStr.Append(IsTRANSICION_IDNull ? (object)"<NULL>" : TRANSICION_ID);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			return dynStr.ToString();
		}
	} // End of OPERACIONESRow_Base class
} // End of namespace
