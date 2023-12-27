// <fileinfo name="ENTIDADES_TEXTO_PREDEFINIDORow_Base.cs">
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
	/// The base class for <see cref="ENTIDADES_TEXTO_PREDEFINIDORow"/> that 
	/// represents a record in the <c>ENTIDADES_TEXTO_PREDEFINIDO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENTIDADES_TEXTO_PREDEFINIDORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENTIDADES_TEXTO_PREDEFINIDORow_Base
	{
		private decimal _id;
		private string _tabla_id;
		private decimal _registro_id;
		private decimal _texto_predefinido_id;
		private System.DateTime _fecha_asignacion;
		private decimal _usuario_asignacion_id;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENTIDADES_TEXTO_PREDEFINIDORow_Base"/> class.
		/// </summary>
		public ENTIDADES_TEXTO_PREDEFINIDORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENTIDADES_TEXTO_PREDEFINIDORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.FECHA_ASIGNACION != original.FECHA_ASIGNACION) return true;
			if (this.USUARIO_ASIGNACION_ID != original.USUARIO_ASIGNACION_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIGNACION</c> column value.</value>
		public System.DateTime FECHA_ASIGNACION
		{
			get { return _fecha_asignacion; }
			set { _fecha_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION_ID</c> column value.</value>
		public decimal USUARIO_ASIGNACION_ID
		{
			get { return _usuario_asignacion_id; }
			set { _usuario_asignacion_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@FECHA_ASIGNACION=");
			dynStr.Append(FECHA_ASIGNACION);
			dynStr.Append("@CBA@USUARIO_ASIGNACION_ID=");
			dynStr.Append(USUARIO_ASIGNACION_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ENTIDADES_TEXTO_PREDEFINIDORow_Base class
} // End of namespace
