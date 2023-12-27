// <fileinfo name="PERS_JURID_REPRESENT_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="PERS_JURID_REPRESENT_INFO_COMPRow"/> that 
	/// represents a record in the <c>PERS_JURID_REPRESENT_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERS_JURID_REPRESENT_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERS_JURID_REPRESENT_INFO_COMPRow_Base
	{
		private decimal _representante_id;
		private string _representante_nombre;
		private string _representante_apellido;
		private string _persona_nombre;
		private string _persona_apellido;
		private decimal _persona_id;
		private decimal _id;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERS_JURID_REPRESENT_INFO_COMPRow_Base"/> class.
		/// </summary>
		public PERS_JURID_REPRESENT_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERS_JURID_REPRESENT_INFO_COMPRow_Base original)
		{
			if (this.REPRESENTANTE_ID != original.REPRESENTANTE_ID) return true;
			if (this.REPRESENTANTE_NOMBRE != original.REPRESENTANTE_NOMBRE) return true;
			if (this.REPRESENTANTE_APELLIDO != original.REPRESENTANTE_APELLIDO) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_APELLIDO != original.PERSONA_APELLIDO) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.ID != original.ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>REPRESENTANTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>REPRESENTANTE_ID</c> column value.</value>
		public decimal REPRESENTANTE_ID
		{
			get { return _representante_id; }
			set { _representante_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPRESENTANTE_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>REPRESENTANTE_NOMBRE</c> column value.</value>
		public string REPRESENTANTE_NOMBRE
		{
			get { return _representante_nombre; }
			set { _representante_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPRESENTANTE_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPRESENTANTE_APELLIDO</c> column value.</value>
		public string REPRESENTANTE_APELLIDO
		{
			get { return _representante_apellido; }
			set { _representante_apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_APELLIDO</c> column value.</value>
		public string PERSONA_APELLIDO
		{
			get { return _persona_apellido; }
			set { _persona_apellido = value; }
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
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@REPRESENTANTE_ID=");
			dynStr.Append(REPRESENTANTE_ID);
			dynStr.Append("@CBA@REPRESENTANTE_NOMBRE=");
			dynStr.Append(REPRESENTANTE_NOMBRE);
			dynStr.Append("@CBA@REPRESENTANTE_APELLIDO=");
			dynStr.Append(REPRESENTANTE_APELLIDO);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_APELLIDO=");
			dynStr.Append(PERSONA_APELLIDO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			return dynStr.ToString();
		}
	} // End of PERS_JURID_REPRESENT_INFO_COMPRow_Base class
} // End of namespace
