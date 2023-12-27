// <fileinfo name="PERFILES_ROLES_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PERFILES_ROLES_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PERFILES_ROLES_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERFILES_ROLES_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERFILES_ROLES_INFO_COMPLRow_Base
	{
		private decimal _perfil_id;
		private string _perfil_descripcion;
		private string _estado;
		private decimal _rol_id;
		private string _rol_descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERFILES_ROLES_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PERFILES_ROLES_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERFILES_ROLES_INFO_COMPLRow_Base original)
		{
			if (this.PERFIL_ID != original.PERFIL_ID) return true;
			if (this.PERFIL_DESCRIPCION != original.PERFIL_DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			if (this.ROL_DESCRIPCION != original.ROL_DESCRIPCION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public decimal PERFIL_ID
		{
			get { return _perfil_id; }
			set { _perfil_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERFIL_DESCRIPCION</c> column value.</value>
		public string PERFIL_DESCRIPCION
		{
			get { return _perfil_descripcion; }
			set { _perfil_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESCRIPCION</c> column value.</value>
		public string ROL_DESCRIPCION
		{
			get { return _rol_descripcion; }
			set { _rol_descripcion = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(PERFIL_ID);
			dynStr.Append("@CBA@PERFIL_DESCRIPCION=");
			dynStr.Append(PERFIL_DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			dynStr.Append("@CBA@ROL_DESCRIPCION=");
			dynStr.Append(ROL_DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of PERFILES_ROLES_INFO_COMPLRow_Base class
} // End of namespace
