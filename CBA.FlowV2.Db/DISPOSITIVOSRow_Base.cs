// <fileinfo name="DISPOSITIVOSRow_Base.cs">
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
	/// The base class for <see cref="DISPOSITIVOSRow"/> that 
	/// represents a record in the <c>DISPOSITIVOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DISPOSITIVOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DISPOSITIVOSRow_Base
	{
		private decimal _id;
		private decimal _usuario_id;
		private string _nombre;
		private string _caracteristica;
		private string _token;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="DISPOSITIVOSRow_Base"/> class.
		/// </summary>
		public DISPOSITIVOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DISPOSITIVOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CARACTERISTICA != original.CARACTERISTICA) return true;
			if (this.TOKEN != original.TOKEN) return true;
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CARACTERISTICA</c> column value.
		/// </summary>
		/// <value>The <c>CARACTERISTICA</c> column value.</value>
		public string CARACTERISTICA
		{
			get { return _caracteristica; }
			set { _caracteristica = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOKEN</c> column value.
		/// </summary>
		/// <value>The <c>TOKEN</c> column value.</value>
		public string TOKEN
		{
			get { return _token; }
			set { _token = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@CARACTERISTICA=");
			dynStr.Append(CARACTERISTICA);
			dynStr.Append("@CBA@TOKEN=");
			dynStr.Append(TOKEN);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of DISPOSITIVOSRow_Base class
} // End of namespace
