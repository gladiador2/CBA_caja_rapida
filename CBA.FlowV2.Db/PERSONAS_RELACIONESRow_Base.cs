// <fileinfo name="PERSONAS_RELACIONESRow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_RELACIONESRow"/> that 
	/// represents a record in the <c>PERSONAS_RELACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_RELACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_RELACIONESRow_Base
	{
		private decimal _id;
		private decimal _tipo_relacion_persona_id;
		private decimal _persona_id;
		private decimal _persona_relacionada_id;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_RELACIONESRow_Base"/> class.
		/// </summary>
		public PERSONAS_RELACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_RELACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_RELACION_PERSONA_ID != original.TIPO_RELACION_PERSONA_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_RELACIONADA_ID != original.PERSONA_RELACIONADA_ID) return true;
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
		/// Gets or sets the <c>TIPO_RELACION_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_RELACION_PERSONA_ID</c> column value.</value>
		public decimal TIPO_RELACION_PERSONA_ID
		{
			get { return _tipo_relacion_persona_id; }
			set { _tipo_relacion_persona_id = value; }
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
		/// Gets or sets the <c>PERSONA_RELACIONADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_RELACIONADA_ID</c> column value.</value>
		public decimal PERSONA_RELACIONADA_ID
		{
			get { return _persona_relacionada_id; }
			set { _persona_relacionada_id = value; }
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
			dynStr.Append("@CBA@TIPO_RELACION_PERSONA_ID=");
			dynStr.Append(TIPO_RELACION_PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_RELACIONADA_ID=");
			dynStr.Append(PERSONA_RELACIONADA_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of PERSONAS_RELACIONESRow_Base class
} // End of namespace
