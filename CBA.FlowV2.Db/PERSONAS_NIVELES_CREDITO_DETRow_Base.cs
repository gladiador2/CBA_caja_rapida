// <fileinfo name="PERSONAS_NIVELES_CREDITO_DETRow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_NIVELES_CREDITO_DETRow"/> that 
	/// represents a record in the <c>PERSONAS_NIVELES_CREDITO_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_NIVELES_CREDITO_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_NIVELES_CREDITO_DETRow_Base
	{
		private decimal _id;
		private decimal _persona_nivel_credito_id;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_NIVELES_CREDITO_DETRow_Base"/> class.
		/// </summary>
		public PERSONAS_NIVELES_CREDITO_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_NIVELES_CREDITO_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_NIVEL_CREDITO_ID != original.PERSONA_NIVEL_CREDITO_ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			
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
		/// Gets or sets the <c>PERSONA_NIVEL_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_NIVEL_CREDITO_ID</c> column value.</value>
		public decimal PERSONA_NIVEL_CREDITO_ID
		{
			get { return _persona_nivel_credito_id; }
			set { _persona_nivel_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
			dynStr.Append("@CBA@PERSONA_NIVEL_CREDITO_ID=");
			dynStr.Append(PERSONA_NIVEL_CREDITO_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of PERSONAS_NIVELES_CREDITO_DETRow_Base class
} // End of namespace
