// <fileinfo name="CAMPOS_CONFIGURABLES_USUARIOSRow_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONFIGURABLES_USUARIOSRow"/> that 
	/// represents a record in the <c>CAMPOS_CONFIGURABLES_USUARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMPOS_CONFIGURABLES_USUARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONFIGURABLES_USUARIOSRow_Base
	{
		private decimal _id;
		private decimal _campo_conf_item_id;
		private bool _campo_conf_item_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _valor_numero;
		private bool _valor_numeroNull = true;
		private string _valor_texto;
		private System.DateTime _valor_fecha;
		private bool _valor_fechaNull = true;
		private decimal _campo_conf_grupo_id;
		private bool _campo_conf_grupo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGURABLES_USUARIOSRow_Base"/> class.
		/// </summary>
		public CAMPOS_CONFIGURABLES_USUARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMPOS_CONFIGURABLES_USUARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCAMPO_CONF_ITEM_IDNull != original.IsCAMPO_CONF_ITEM_IDNull) return true;
			if (!this.IsCAMPO_CONF_ITEM_IDNull && !original.IsCAMPO_CONF_ITEM_IDNull)
				if (this.CAMPO_CONF_ITEM_ID != original.CAMPO_CONF_ITEM_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsVALOR_NUMERONull != original.IsVALOR_NUMERONull) return true;
			if (!this.IsVALOR_NUMERONull && !original.IsVALOR_NUMERONull)
				if (this.VALOR_NUMERO != original.VALOR_NUMERO) return true;
			if (this.VALOR_TEXTO != original.VALOR_TEXTO) return true;
			if (this.IsVALOR_FECHANull != original.IsVALOR_FECHANull) return true;
			if (!this.IsVALOR_FECHANull && !original.IsVALOR_FECHANull)
				if (this.VALOR_FECHA != original.VALOR_FECHA) return true;
			if (this.IsCAMPO_CONF_GRUPO_IDNull != original.IsCAMPO_CONF_GRUPO_IDNull) return true;
			if (!this.IsCAMPO_CONF_GRUPO_IDNull && !original.IsCAMPO_CONF_GRUPO_IDNull)
				if (this.CAMPO_CONF_GRUPO_ID != original.CAMPO_CONF_GRUPO_ID) return true;
			
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
		/// Gets or sets the <c>CAMPO_CONF_ITEM_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_CONF_ITEM_ID</c> column value.</value>
		public decimal CAMPO_CONF_ITEM_ID
		{
			get
			{
				if(IsCAMPO_CONF_ITEM_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _campo_conf_item_id;
			}
			set
			{
				_campo_conf_item_idNull = false;
				_campo_conf_item_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMPO_CONF_ITEM_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMPO_CONF_ITEM_IDNull
		{
			get { return _campo_conf_item_idNull; }
			set { _campo_conf_item_idNull = value; }
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
		/// Gets or sets the <c>VALOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NUMERO</c> column value.</value>
		public decimal VALOR_NUMERO
		{
			get
			{
				if(IsVALOR_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_numero;
			}
			set
			{
				_valor_numeroNull = false;
				_valor_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_NUMERONull
		{
			get { return _valor_numeroNull; }
			set { _valor_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_TEXTO</c> column value.</value>
		public string VALOR_TEXTO
		{
			get { return _valor_texto; }
			set { _valor_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_FECHA</c> column value.</value>
		public System.DateTime VALOR_FECHA
		{
			get
			{
				if(IsVALOR_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_fecha;
			}
			set
			{
				_valor_fechaNull = false;
				_valor_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_FECHANull
		{
			get { return _valor_fechaNull; }
			set { _valor_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPO_CONF_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPO_CONF_GRUPO_ID</c> column value.</value>
		public decimal CAMPO_CONF_GRUPO_ID
		{
			get
			{
				if(IsCAMPO_CONF_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _campo_conf_grupo_id;
			}
			set
			{
				_campo_conf_grupo_idNull = false;
				_campo_conf_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMPO_CONF_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMPO_CONF_GRUPO_IDNull
		{
			get { return _campo_conf_grupo_idNull; }
			set { _campo_conf_grupo_idNull = value; }
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
			dynStr.Append("@CBA@CAMPO_CONF_ITEM_ID=");
			dynStr.Append(IsCAMPO_CONF_ITEM_IDNull ? (object)"<NULL>" : CAMPO_CONF_ITEM_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@VALOR_NUMERO=");
			dynStr.Append(IsVALOR_NUMERONull ? (object)"<NULL>" : VALOR_NUMERO);
			dynStr.Append("@CBA@VALOR_TEXTO=");
			dynStr.Append(VALOR_TEXTO);
			dynStr.Append("@CBA@VALOR_FECHA=");
			dynStr.Append(IsVALOR_FECHANull ? (object)"<NULL>" : VALOR_FECHA);
			dynStr.Append("@CBA@CAMPO_CONF_GRUPO_ID=");
			dynStr.Append(IsCAMPO_CONF_GRUPO_IDNull ? (object)"<NULL>" : CAMPO_CONF_GRUPO_ID);
			return dynStr.ToString();
		}
	} // End of CAMPOS_CONFIGURABLES_USUARIOSRow_Base class
} // End of namespace
