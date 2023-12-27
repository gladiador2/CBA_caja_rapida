// <fileinfo name="PERSONAS_BLOQUEOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_BLOQUEOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>PERSONAS_BLOQUEOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_BLOQUEOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_BLOQUEOS_INFO_COMPRow_Base
	{
		private decimal _persona_id;
		private string _persona_nombre;
		private decimal _usuario_bloqueo_id;
		private string _usuario_bloqueo_nombre;
		private System.DateTime _fecha_bloqueo;
		private decimal _texto_motivo_id;
		private string _texto_motivo;
		private string _desbloqueado;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_BLOQUEOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public PERSONAS_BLOQUEOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_BLOQUEOS_INFO_COMPRow_Base original)
		{
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.USUARIO_BLOQUEO_ID != original.USUARIO_BLOQUEO_ID) return true;
			if (this.USUARIO_BLOQUEO_NOMBRE != original.USUARIO_BLOQUEO_NOMBRE) return true;
			if (this.FECHA_BLOQUEO != original.FECHA_BLOQUEO) return true;
			if (this.TEXTO_MOTIVO_ID != original.TEXTO_MOTIVO_ID) return true;
			if (this.TEXTO_MOTIVO != original.TEXTO_MOTIVO) return true;
			if (this.DESBLOQUEADO != original.DESBLOQUEADO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_BLOQUEO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_BLOQUEO_ID</c> column value.</value>
		public decimal USUARIO_BLOQUEO_ID
		{
			get { return _usuario_bloqueo_id; }
			set { _usuario_bloqueo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_BLOQUEO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_BLOQUEO_NOMBRE</c> column value.</value>
		public string USUARIO_BLOQUEO_NOMBRE
		{
			get { return _usuario_bloqueo_nombre; }
			set { _usuario_bloqueo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_BLOQUEO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_BLOQUEO</c> column value.</value>
		public System.DateTime FECHA_BLOQUEO
		{
			get { return _fecha_bloqueo; }
			set { _fecha_bloqueo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_MOTIVO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_MOTIVO_ID</c> column value.</value>
		public decimal TEXTO_MOTIVO_ID
		{
			get { return _texto_motivo_id; }
			set { _texto_motivo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_MOTIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_MOTIVO</c> column value.</value>
		public string TEXTO_MOTIVO
		{
			get { return _texto_motivo; }
			set { _texto_motivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESBLOQUEADO</c> column value.
		/// </summary>
		/// <value>The <c>DESBLOQUEADO</c> column value.</value>
		public string DESBLOQUEADO
		{
			get { return _desbloqueado; }
			set { _desbloqueado = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@USUARIO_BLOQUEO_ID=");
			dynStr.Append(USUARIO_BLOQUEO_ID);
			dynStr.Append("@CBA@USUARIO_BLOQUEO_NOMBRE=");
			dynStr.Append(USUARIO_BLOQUEO_NOMBRE);
			dynStr.Append("@CBA@FECHA_BLOQUEO=");
			dynStr.Append(FECHA_BLOQUEO);
			dynStr.Append("@CBA@TEXTO_MOTIVO_ID=");
			dynStr.Append(TEXTO_MOTIVO_ID);
			dynStr.Append("@CBA@TEXTO_MOTIVO=");
			dynStr.Append(TEXTO_MOTIVO);
			dynStr.Append("@CBA@DESBLOQUEADO=");
			dynStr.Append(DESBLOQUEADO);
			return dynStr.ToString();
		}
	} // End of PERSONAS_BLOQUEOS_INFO_COMPRow_Base class
} // End of namespace
