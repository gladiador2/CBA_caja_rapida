// <fileinfo name="LOG_SESIONESRow_Base.cs">
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
	/// The base class for <see cref="LOG_SESIONESRow"/> that 
	/// represents a record in the <c>LOG_SESIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LOG_SESIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LOG_SESIONESRow_Base
	{
		private decimal _id;
		private string _usuario;
		private string _sucursal;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private string _externo;
		private System.DateTime _fecha_intento;
		private string _ip;
		private string _exito;
		private string _nro_sesion;
		private string _mensaje;
		private string _evento;

		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_SESIONESRow_Base"/> class.
		/// </summary>
		public LOG_SESIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LOG_SESIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.SUCURSAL != original.SUCURSAL) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.EXTERNO != original.EXTERNO) return true;
			if (this.FECHA_INTENTO != original.FECHA_INTENTO) return true;
			if (this.IP != original.IP) return true;
			if (this.EXITO != original.EXITO) return true;
			if (this.NRO_SESION != original.NRO_SESION) return true;
			if (this.MENSAJE != original.MENSAJE) return true;
			if (this.EVENTO != original.EVENTO) return true;
			
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
		/// Gets or sets the <c>USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL</c> column value.</value>
		public string SUCURSAL
		{
			get { return _sucursal; }
			set { _sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get
			{
				if(IsENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entidad_id;
			}
			set
			{
				_entidad_idNull = false;
				_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTIDAD_IDNull
		{
			get { return _entidad_idNull; }
			set { _entidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXTERNO</c> column value.</value>
		public string EXTERNO
		{
			get { return _externo; }
			set { _externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INTENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INTENTO</c> column value.</value>
		public System.DateTime FECHA_INTENTO
		{
			get { return _fecha_intento; }
			set { _fecha_intento = value; }
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
		/// Gets or sets the <c>EXITO</c> column value.
		/// </summary>
		/// <value>The <c>EXITO</c> column value.</value>
		public string EXITO
		{
			get { return _exito; }
			set { _exito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_SESION</c> column value.
		/// </summary>
		/// <value>The <c>NRO_SESION</c> column value.</value>
		public string NRO_SESION
		{
			get { return _nro_sesion; }
			set { _nro_sesion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MENSAJE</c> column value.
		/// </summary>
		/// <value>The <c>MENSAJE</c> column value.</value>
		public string MENSAJE
		{
			get { return _mensaje; }
			set { _mensaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EVENTO</c> column value.
		/// </summary>
		/// <value>The <c>EVENTO</c> column value.</value>
		public string EVENTO
		{
			get { return _evento; }
			set { _evento = value; }
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
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@SUCURSAL=");
			dynStr.Append(SUCURSAL);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@EXTERNO=");
			dynStr.Append(EXTERNO);
			dynStr.Append("@CBA@FECHA_INTENTO=");
			dynStr.Append(FECHA_INTENTO);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@EXITO=");
			dynStr.Append(EXITO);
			dynStr.Append("@CBA@NRO_SESION=");
			dynStr.Append(NRO_SESION);
			dynStr.Append("@CBA@MENSAJE=");
			dynStr.Append(MENSAJE);
			dynStr.Append("@CBA@EVENTO=");
			dynStr.Append(EVENTO);
			return dynStr.ToString();
		}
	} // End of LOG_SESIONESRow_Base class
} // End of namespace
