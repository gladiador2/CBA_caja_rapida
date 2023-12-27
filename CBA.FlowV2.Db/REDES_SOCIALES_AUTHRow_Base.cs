// <fileinfo name="REDES_SOCIALES_AUTHRow_Base.cs">
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
	/// The base class for <see cref="REDES_SOCIALES_AUTHRow"/> that 
	/// represents a record in the <c>REDES_SOCIALES_AUTH</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REDES_SOCIALES_AUTHRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REDES_SOCIALES_AUTHRow_Base
	{
		private decimal _id;
		private decimal _red_social_id;
		private string _perfil_id;
		private string _datos_usuario;
		private string _protocolo;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _autenticado;
		private string _finalizado;

		/// <summary>
		/// Initializes a new instance of the <see cref="REDES_SOCIALES_AUTHRow_Base"/> class.
		/// </summary>
		public REDES_SOCIALES_AUTHRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REDES_SOCIALES_AUTHRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RED_SOCIAL_ID != original.RED_SOCIAL_ID) return true;
			if (this.PERFIL_ID != original.PERFIL_ID) return true;
			if (this.DATOS_USUARIO != original.DATOS_USUARIO) return true;
			if (this.PROTOCOLO != original.PROTOCOLO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.AUTENTICADO != original.AUTENTICADO) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			
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
		/// Gets or sets the <c>RED_SOCIAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>RED_SOCIAL_ID</c> column value.</value>
		public decimal RED_SOCIAL_ID
		{
			get { return _red_social_id; }
			set { _red_social_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public string PERFIL_ID
		{
			get { return _perfil_id; }
			set { _perfil_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DATOS_USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DATOS_USUARIO</c> column value.</value>
		public string DATOS_USUARIO
		{
			get { return _datos_usuario; }
			set { _datos_usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROTOCOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROTOCOLO</c> column value.</value>
		public string PROTOCOLO
		{
			get { return _protocolo; }
			set { _protocolo = value; }
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTENTICADO</c> column value.
		/// </summary>
		/// <value>The <c>AUTENTICADO</c> column value.</value>
		public string AUTENTICADO
		{
			get { return _autenticado; }
			set { _autenticado = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@RED_SOCIAL_ID=");
			dynStr.Append(RED_SOCIAL_ID);
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(PERFIL_ID);
			dynStr.Append("@CBA@DATOS_USUARIO=");
			dynStr.Append(DATOS_USUARIO);
			dynStr.Append("@CBA@PROTOCOLO=");
			dynStr.Append(PROTOCOLO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@AUTENTICADO=");
			dynStr.Append(AUTENTICADO);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			return dynStr.ToString();
		}
	} // End of REDES_SOCIALES_AUTHRow_Base class
} // End of namespace
