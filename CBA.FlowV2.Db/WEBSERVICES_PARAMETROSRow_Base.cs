// <fileinfo name="WEBSERVICES_PARAMETROSRow_Base.cs">
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
	/// The base class for <see cref="WEBSERVICES_PARAMETROSRow"/> that 
	/// represents a record in the <c>WEBSERVICES_PARAMETROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="WEBSERVICES_PARAMETROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class WEBSERVICES_PARAMETROSRow_Base
	{
		private decimal _id;
		private string _hash;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _parametros;
		private System.DateTime _fecha_creacion;
		private string _ip;
		private decimal _webservice_id;
		private bool _webservice_idNull = true;
		private string _utilizado;
		private string _finalizado;
		private string _resultado;
		private string _webmethod;

		/// <summary>
		/// Initializes a new instance of the <see cref="WEBSERVICES_PARAMETROSRow_Base"/> class.
		/// </summary>
		public WEBSERVICES_PARAMETROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(WEBSERVICES_PARAMETROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.HASH != original.HASH) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.PARAMETROS != original.PARAMETROS) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IP != original.IP) return true;
			if (this.IsWEBSERVICE_IDNull != original.IsWEBSERVICE_IDNull) return true;
			if (!this.IsWEBSERVICE_IDNull && !original.IsWEBSERVICE_IDNull)
				if (this.WEBSERVICE_ID != original.WEBSERVICE_ID) return true;
			if (this.UTILIZADO != original.UTILIZADO) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			if (this.RESULTADO != original.RESULTADO) return true;
			if (this.WEBMETHOD != original.WEBMETHOD) return true;
			
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
		/// Gets or sets the <c>HASH</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HASH</c> column value.</value>
		public string HASH
		{
			get { return _hash; }
			set { _hash = value; }
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
		/// Gets or sets the <c>PARAMETROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PARAMETROS</c> column value.</value>
		public string PARAMETROS
		{
			get { return _parametros; }
			set { _parametros = value; }
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
		/// Gets or sets the <c>WEBSERVICE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>WEBSERVICE_ID</c> column value.</value>
		public decimal WEBSERVICE_ID
		{
			get
			{
				if(IsWEBSERVICE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _webservice_id;
			}
			set
			{
				_webservice_idNull = false;
				_webservice_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="WEBSERVICE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsWEBSERVICE_IDNull
		{
			get { return _webservice_idNull; }
			set { _webservice_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZADO</c> column value.
		/// </summary>
		/// <value>The <c>UTILIZADO</c> column value.</value>
		public string UTILIZADO
		{
			get { return _utilizado; }
			set { _utilizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FINALIZADO</c> column value.
		/// </summary>
		/// <value>The <c>FINALIZADO</c> column value.</value>
		public string FINALIZADO
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESULTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESULTADO</c> column value.</value>
		public string RESULTADO
		{
			get { return _resultado; }
			set { _resultado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>WEBMETHOD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>WEBMETHOD</c> column value.</value>
		public string WEBMETHOD
		{
			get { return _webmethod; }
			set { _webmethod = value; }
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
			dynStr.Append("@CBA@HASH=");
			dynStr.Append(HASH);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@PARAMETROS=");
			dynStr.Append(PARAMETROS);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@WEBSERVICE_ID=");
			dynStr.Append(IsWEBSERVICE_IDNull ? (object)"<NULL>" : WEBSERVICE_ID);
			dynStr.Append("@CBA@UTILIZADO=");
			dynStr.Append(UTILIZADO);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			dynStr.Append("@CBA@RESULTADO=");
			dynStr.Append(RESULTADO);
			dynStr.Append("@CBA@WEBMETHOD=");
			dynStr.Append(WEBMETHOD);
			return dynStr.ToString();
		}
	} // End of WEBSERVICES_PARAMETROSRow_Base class
} // End of namespace
