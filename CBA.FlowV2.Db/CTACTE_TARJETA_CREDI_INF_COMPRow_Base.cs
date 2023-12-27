// <fileinfo name="CTACTE_TARJETA_CREDI_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_TARJETA_CREDI_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETA_CREDI_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _ctacte_procesadora;
		private bool _ctacte_procesadoraNull = true;
		private decimal _ctacte_tarjeta_cred_emis_id;
		private bool _ctacte_tarjeta_cred_emis_idNull = true;
		private decimal _ctacte_banco_emisora_id;
		private bool _ctacte_banco_emisora_idNull = true;
		private string _emisora;
		private string _numero;
		private string _titular;
		private decimal _limite_credito;
		private string _bloqueado;
		private string _motivo_ultimo_bloqueo;
		private decimal _usuario_ultimo_bloqueo_id;
		private bool _usuario_ultimo_bloqueo_idNull = true;
		private System.DateTime _fecha_ultimo_bloqueo;
		private bool _fecha_ultimo_bloqueoNull = true;
		private decimal _usuario_ultimo_desbloqueo_id;
		private bool _usuario_ultimo_desbloqueo_idNull = true;
		private System.DateTime _fecha_ultimo_desbloqueo;
		private bool _fecha_ultimo_desbloqueoNull = true;
		private decimal _usuario_creacion;
		private System.DateTime _fecha_creacion;
		private string _estado;
		private string _nombre_tarjeta;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_TARJETA_CREDI_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_TARJETA_CREDI_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_PROCESADORANull != original.IsCTACTE_PROCESADORANull) return true;
			if (!this.IsCTACTE_PROCESADORANull && !original.IsCTACTE_PROCESADORANull)
				if (this.CTACTE_PROCESADORA != original.CTACTE_PROCESADORA) return true;
			if (this.IsCTACTE_TARJETA_CRED_EMIS_IDNull != original.IsCTACTE_TARJETA_CRED_EMIS_IDNull) return true;
			if (!this.IsCTACTE_TARJETA_CRED_EMIS_IDNull && !original.IsCTACTE_TARJETA_CRED_EMIS_IDNull)
				if (this.CTACTE_TARJETA_CRED_EMIS_ID != original.CTACTE_TARJETA_CRED_EMIS_ID) return true;
			if (this.IsCTACTE_BANCO_EMISORA_IDNull != original.IsCTACTE_BANCO_EMISORA_IDNull) return true;
			if (!this.IsCTACTE_BANCO_EMISORA_IDNull && !original.IsCTACTE_BANCO_EMISORA_IDNull)
				if (this.CTACTE_BANCO_EMISORA_ID != original.CTACTE_BANCO_EMISORA_ID) return true;
			if (this.EMISORA != original.EMISORA) return true;
			if (this.NUMERO != original.NUMERO) return true;
			if (this.TITULAR != original.TITULAR) return true;
			if (this.LIMITE_CREDITO != original.LIMITE_CREDITO) return true;
			if (this.BLOQUEADO != original.BLOQUEADO) return true;
			if (this.MOTIVO_ULTIMO_BLOQUEO != original.MOTIVO_ULTIMO_BLOQUEO) return true;
			if (this.IsUSUARIO_ULTIMO_BLOQUEO_IDNull != original.IsUSUARIO_ULTIMO_BLOQUEO_IDNull) return true;
			if (!this.IsUSUARIO_ULTIMO_BLOQUEO_IDNull && !original.IsUSUARIO_ULTIMO_BLOQUEO_IDNull)
				if (this.USUARIO_ULTIMO_BLOQUEO_ID != original.USUARIO_ULTIMO_BLOQUEO_ID) return true;
			if (this.IsFECHA_ULTIMO_BLOQUEONull != original.IsFECHA_ULTIMO_BLOQUEONull) return true;
			if (!this.IsFECHA_ULTIMO_BLOQUEONull && !original.IsFECHA_ULTIMO_BLOQUEONull)
				if (this.FECHA_ULTIMO_BLOQUEO != original.FECHA_ULTIMO_BLOQUEO) return true;
			if (this.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull != original.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull) return true;
			if (!this.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull && !original.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull)
				if (this.USUARIO_ULTIMO_DESBLOQUEO_ID != original.USUARIO_ULTIMO_DESBLOQUEO_ID) return true;
			if (this.IsFECHA_ULTIMO_DESBLOQUEONull != original.IsFECHA_ULTIMO_DESBLOQUEONull) return true;
			if (!this.IsFECHA_ULTIMO_DESBLOQUEONull && !original.IsFECHA_ULTIMO_DESBLOQUEONull)
				if (this.FECHA_ULTIMO_DESBLOQUEO != original.FECHA_ULTIMO_DESBLOQUEO) return true;
			if (this.USUARIO_CREACION != original.USUARIO_CREACION) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE_TARJETA != original.NOMBRE_TARJETA) return true;
			
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
		/// Gets or sets the <c>CTACTE_PROCESADORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROCESADORA</c> column value.</value>
		public decimal CTACTE_PROCESADORA
		{
			get
			{
				if(IsCTACTE_PROCESADORANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_procesadora;
			}
			set
			{
				_ctacte_procesadoraNull = false;
				_ctacte_procesadora = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROCESADORA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROCESADORANull
		{
			get { return _ctacte_procesadoraNull; }
			set { _ctacte_procesadoraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</value>
		public decimal CTACTE_TARJETA_CRED_EMIS_ID
		{
			get
			{
				if(IsCTACTE_TARJETA_CRED_EMIS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_tarjeta_cred_emis_id;
			}
			set
			{
				_ctacte_tarjeta_cred_emis_idNull = false;
				_ctacte_tarjeta_cred_emis_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_TARJETA_CRED_EMIS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_TARJETA_CRED_EMIS_IDNull
		{
			get { return _ctacte_tarjeta_cred_emis_idNull; }
			set { _ctacte_tarjeta_cred_emis_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_EMISORA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_EMISORA_ID</c> column value.</value>
		public decimal CTACTE_BANCO_EMISORA_ID
		{
			get
			{
				if(IsCTACTE_BANCO_EMISORA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_emisora_id;
			}
			set
			{
				_ctacte_banco_emisora_idNull = false;
				_ctacte_banco_emisora_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_EMISORA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_EMISORA_IDNull
		{
			get { return _ctacte_banco_emisora_idNull; }
			set { _ctacte_banco_emisora_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMISORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMISORA</c> column value.</value>
		public string EMISORA
		{
			get { return _emisora; }
			set { _emisora = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO</c> column value.</value>
		public string NUMERO
		{
			get { return _numero; }
			set { _numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULAR</c> column value.
		/// </summary>
		/// <value>The <c>TITULAR</c> column value.</value>
		public string TITULAR
		{
			get { return _titular; }
			set { _titular = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_CREDITO</c> column value.</value>
		public decimal LIMITE_CREDITO
		{
			get { return _limite_credito; }
			set { _limite_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEADO</c> column value.
		/// </summary>
		/// <value>The <c>BLOQUEADO</c> column value.</value>
		public string BLOQUEADO
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ULTIMO_BLOQUEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_ULTIMO_BLOQUEO</c> column value.</value>
		public string MOTIVO_ULTIMO_BLOQUEO
		{
			get { return _motivo_ultimo_bloqueo; }
			set { _motivo_ultimo_bloqueo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</value>
		public decimal USUARIO_ULTIMO_BLOQUEO_ID
		{
			get
			{
				if(IsUSUARIO_ULTIMO_BLOQUEO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_ultimo_bloqueo_id;
			}
			set
			{
				_usuario_ultimo_bloqueo_idNull = false;
				_usuario_ultimo_bloqueo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ULTIMO_BLOQUEO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ULTIMO_BLOQUEO_IDNull
		{
			get { return _usuario_ultimo_bloqueo_idNull; }
			set { _usuario_ultimo_bloqueo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMO_BLOQUEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMO_BLOQUEO</c> column value.</value>
		public System.DateTime FECHA_ULTIMO_BLOQUEO
		{
			get
			{
				if(IsFECHA_ULTIMO_BLOQUEONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultimo_bloqueo;
			}
			set
			{
				_fecha_ultimo_bloqueoNull = false;
				_fecha_ultimo_bloqueo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMO_BLOQUEO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMO_BLOQUEONull
		{
			get { return _fecha_ultimo_bloqueoNull; }
			set { _fecha_ultimo_bloqueoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</value>
		public decimal USUARIO_ULTIMO_DESBLOQUEO_ID
		{
			get
			{
				if(IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_ultimo_desbloqueo_id;
			}
			set
			{
				_usuario_ultimo_desbloqueo_idNull = false;
				_usuario_ultimo_desbloqueo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ULTIMO_DESBLOQUEO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull
		{
			get { return _usuario_ultimo_desbloqueo_idNull; }
			set { _usuario_ultimo_desbloqueo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMO_DESBLOQUEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMO_DESBLOQUEO</c> column value.</value>
		public System.DateTime FECHA_ULTIMO_DESBLOQUEO
		{
			get
			{
				if(IsFECHA_ULTIMO_DESBLOQUEONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultimo_desbloqueo;
			}
			set
			{
				_fecha_ultimo_desbloqueoNull = false;
				_fecha_ultimo_desbloqueo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMO_DESBLOQUEO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMO_DESBLOQUEONull
		{
			get { return _fecha_ultimo_desbloqueoNull; }
			set { _fecha_ultimo_desbloqueoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION</c> column value.</value>
		public decimal USUARIO_CREACION
		{
			get { return _usuario_creacion; }
			set { _usuario_creacion = value; }
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
		/// Gets or sets the <c>NOMBRE_TARJETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_TARJETA</c> column value.</value>
		public string NOMBRE_TARJETA
		{
			get { return _nombre_tarjeta; }
			set { _nombre_tarjeta = value; }
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
			dynStr.Append("@CBA@CTACTE_PROCESADORA=");
			dynStr.Append(IsCTACTE_PROCESADORANull ? (object)"<NULL>" : CTACTE_PROCESADORA);
			dynStr.Append("@CBA@CTACTE_TARJETA_CRED_EMIS_ID=");
			dynStr.Append(IsCTACTE_TARJETA_CRED_EMIS_IDNull ? (object)"<NULL>" : CTACTE_TARJETA_CRED_EMIS_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_EMISORA_ID=");
			dynStr.Append(IsCTACTE_BANCO_EMISORA_IDNull ? (object)"<NULL>" : CTACTE_BANCO_EMISORA_ID);
			dynStr.Append("@CBA@EMISORA=");
			dynStr.Append(EMISORA);
			dynStr.Append("@CBA@NUMERO=");
			dynStr.Append(NUMERO);
			dynStr.Append("@CBA@TITULAR=");
			dynStr.Append(TITULAR);
			dynStr.Append("@CBA@LIMITE_CREDITO=");
			dynStr.Append(LIMITE_CREDITO);
			dynStr.Append("@CBA@BLOQUEADO=");
			dynStr.Append(BLOQUEADO);
			dynStr.Append("@CBA@MOTIVO_ULTIMO_BLOQUEO=");
			dynStr.Append(MOTIVO_ULTIMO_BLOQUEO);
			dynStr.Append("@CBA@USUARIO_ULTIMO_BLOQUEO_ID=");
			dynStr.Append(IsUSUARIO_ULTIMO_BLOQUEO_IDNull ? (object)"<NULL>" : USUARIO_ULTIMO_BLOQUEO_ID);
			dynStr.Append("@CBA@FECHA_ULTIMO_BLOQUEO=");
			dynStr.Append(IsFECHA_ULTIMO_BLOQUEONull ? (object)"<NULL>" : FECHA_ULTIMO_BLOQUEO);
			dynStr.Append("@CBA@USUARIO_ULTIMO_DESBLOQUEO_ID=");
			dynStr.Append(IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull ? (object)"<NULL>" : USUARIO_ULTIMO_DESBLOQUEO_ID);
			dynStr.Append("@CBA@FECHA_ULTIMO_DESBLOQUEO=");
			dynStr.Append(IsFECHA_ULTIMO_DESBLOQUEONull ? (object)"<NULL>" : FECHA_ULTIMO_DESBLOQUEO);
			dynStr.Append("@CBA@USUARIO_CREACION=");
			dynStr.Append(USUARIO_CREACION);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE_TARJETA=");
			dynStr.Append(NOMBRE_TARJETA);
			return dynStr.ToString();
		}
	} // End of CTACTE_TARJETA_CREDI_INF_COMPRow_Base class
} // End of namespace
